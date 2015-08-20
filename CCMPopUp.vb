Imports Microsoft.Win32
Imports System.Net.NetworkInformation
Imports System.DirectoryServices
Imports System.IO
Imports System.Threading
Imports System.ComponentModel
'This form was created as a way to communicate with all employees when there is a system problem that 
'interupts normal communication such as the email servers being down
'It pops up a message on all PC's or the selected PCs
Public Class CCMPopUp
    Dim thread2 As Threading.Thread
    Dim supa_list_O_threadz, sooper_sendur As List(Of Threading.Thread)
    Dim numbaOfPingythreadsUwant As Integer = 0
    Dim numbaOfSendyThreadsUwant As Integer = 0
    Dim CurrentComputer As Integer
    Dim ThreadLocka As String = "this keeps thread racing from jacking up the currentComputer incrementing variable"
    Dim ThreadLocka2 As String = "this keeps thread racing from doing a bunch of extra work to set the tableBeSortable" & _
        "variable and allows us to only have one thread pause before setting tableBeSortable to true"
    Dim tableBeSortable As Boolean = False
    Dim computerLDAPpaths As List(Of String) = frmMainForm.computerLDAPPaths
    Private Delegate Sub PopulateGridView(ByVal Colarray As Object, ByVal userCount As String)
    Private invoker As PopulateGridView
    Private Delegate Sub updateGridView(ByVal status As String, ByVal RowCount As Integer)
    Private invoker2 As updateGridView
    Private Delegate Sub updateGridViewMessageStat(ByVal RowCount As Integer, ByVal Stat As String)
    Private invoker3Message As updateGridViewMessageStat
    Private Sub AddGridItems(ByVal Colarray As Object, ByVal userCount As String)
        'this is what we want to be done on the primary thread
        dgvComputerList.Rows.Add(Colarray(0), Colarray(1), Colarray(2), Colarray(3))
        LabelComputers.Text = dgvComputerList.RowCount
    End Sub
    Private Sub AddAGridItem(ByVal Colarray As Object, ByVal userCount As String)
        'this is run by the secondary thread
        'it INVOKES the desired action on the primary thread
        invoker = New PopulateGridView(AddressOf AddGridItems)
        dgvComputerList.Invoke(invoker, Colarray, userCount)
    End Sub
    Private Sub AddGridOnlineItems(ByVal status As String, ByVal RowCount As Integer)
        dgvComputerList.Item(2, RowCount).Value = status
    End Sub
    Private Sub AddAOnlineItem(ByVal status As String, ByVal RowCount As Integer)
        invoker2 = New updateGridView(AddressOf AddGridOnlineItems)
        dgvComputerList.Invoke(invoker2, status, RowCount)
    End Sub
    Private Sub AddGridOKItems(ByVal RowCount As Integer, ByVal Stat As String)
        dgvComputerList.Item(4, RowCount).Value = Stat
    End Sub
    Private Sub AddAOKItem(ByVal RowCount As Integer, ByVal Stat As String)
        invoker3Message = New updateGridViewMessageStat(AddressOf AddGridOKItems)
        dgvComputerList.Invoke(invoker3Message, RowCount, Stat)
    End Sub
    Private Sub CheckCloseThreads()
        If Not thread2 Is Nothing Then
            If thread2.IsAlive() Then
                thread2.Abort()
            End If
            thread2 = Nothing
        End If
        Try
            For i As Integer = 0 To numbaOfPingythreadsUwant - 1
                If Not supa_list_O_threadz(i) Is Nothing Then
                    If supa_list_O_threadz(i).IsAlive() Then
                        supa_list_O_threadz.Item(i).Abort()
                    End If
                    supa_list_O_threadz(i) = Nothing
                End If
            Next
        Catch ex As Exception
            'this is so we don't crash if u exit before supa_list_O_threadz contains any thread objects
        End Try
        Try
            For i As Integer = 0 To numbaOfSendyThreadsUwant - 1
                If Not sooper_sendur(i) Is Nothing Then
                    If sooper_sendur(i).IsAlive() Then
                        sooper_sendur.Item(i).Abort()
                    End If
                    sooper_sendur(i) = Nothing
                End If
            Next
        Catch ex As Exception
            'this is so we don't crash if u exit before sooper_sendur contains any thread objects
        End Try
    End Sub
    Private Sub CreateVB()
        Dim vbPop As String = "c:\windows\vbPop.vbs"
        Dim TheMessage As String = ""
        Dim TheTitle As String = ""
        Dim TheType As String = ""
        Dim ObjFileSystem As New IO.StreamWriter(vbPop, False)
        TextBoxTheMessage.Text = TextBoxTheMessage.Text.TrimEnd(vbCrLf.ToCharArray)
        TextBoxTheMessage.Text = TextBoxTheMessage.Text.Replace(Chr(34), "")
        TheMessage = TextBoxTheMessage.Text.Replace(vbCrLf, Chr(34) & " & vbcrlf & " & Chr(34))
        Select Case ComboBoxType.Text.ToLower
            Case "information"
                TheType = "vbInformation"
            Case "exclaimation"
                TheType = "vbExclamation"
            Case "error"
                TheType = "vbCritical"
            Case "question"
                TheType = "vbQuestion"
        End Select
        TheTitle = TextBoxTitle.Text.Replace(Chr(34), "")
        ObjFileSystem.Write("On Error Resume Next" & vbCrLf)
        ObjFileSystem.Write("set objShell = CreateObject(" & Chr(34) & "wscript.shell" & Chr(34) & ")" & vbCrLf)
        ObjFileSystem.Write("title = " & Chr(34) & TheTitle & Chr(34) & vbCrLf)
        ObjFileSystem.Write("msg = " & Chr(34) & TheMessage.Trim(Chr(34)) & Chr(34) & vbCrLf)
        ObjFileSystem.Write("objShell.Popup msg, 0, title, " & TheType & " + vbOKOnly")
        ObjFileSystem.Close()
    End Sub
    Private Function PingyPingy(ByVal ComputerName As String)
        Try
            If ComputerName Is Nothing Then
                Return False
                Exit Function
            End If
            Dim ping As New Ping
            Dim theTimeout As Integer = pingTimeout.Value
            Dim pingstat As IPStatus
            pingstat = ping.Send(ComputerName, theTimeout).Status
            If pingstat <> IPStatus.Success Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub GetADComputerInfo()
        Dim count As Integer = 0
        CurrentComputer = 0
        tableBeSortable = False
        supa_list_O_threadz = New List(Of Threading.Thread)
        Dim strDomainPath As String
        For Each strDomainPath In computerLDAPpaths
            Dim dirEntry As New DirectoryEntry("LDAP://" & strDomainPath)
            dirEntry.Username = Nothing
            dirEntry.Password = Nothing
            dirEntry.AuthenticationType = AuthenticationTypes.Secure
            Dim dirSearcher As DirectorySearcher
            Dim resultCollection As SearchResultCollection
            dirSearcher = New DirectorySearcher(dirEntry)
            dirSearcher.Filter = "(objectCategory=computer)"
            dirSearcher.PropertiesToLoad.Add("canonicalName")
            dirSearcher.SearchScope = SearchScope.Subtree
            dirSearcher.Sort.PropertyName = "canonicalName"(0)
            dirSearcher.Sort.Direction = SortDirection.Descending
            dirSearcher.PageSize = 25000
            resultCollection = dirSearcher.FindAll()
            count = resultCollection.Count
            Dim TheRows(3) As String
            If count > 0 Then
                For i As Integer = 0 To count - 1 Step 1
                    TheRows(0) = False
                    TheRows(1) = resultCollection(i).GetDirectoryEntry.Properties("CN").Value
                    TheRows(3) = resultCollection(i).Properties("canonicalName")(0)
                    TheRows(2) = ""
                    AddAGridItem(TheRows, i)
                Next i
            End If
            dirEntry.Close()
        Next
        If dgvComputerList.RowCount > 1000 Then
            numbaOfPingythreadsUwant = 250
        Else
            numbaOfPingythreadsUwant = dgvComputerList.RowCount / 4 + 1
        End If
        For i As Integer = 0 To numbaOfPingythreadsUwant - 1
            Dim temp As Threading.Thread = New Threading.Thread(AddressOf resolvathon)
            temp.IsBackground = True
            supa_list_O_threadz.Add(temp)
            supa_list_O_threadz.Item(i).Start()
        Next
    End Sub
    Private Sub resolvathon()
        Dim pos As Integer
        Do While (CurrentComputer < (dgvComputerList.RowCount))
            SyncLock ThreadLocka
                pos = CurrentComputer
                CurrentComputer += 1
            End SyncLock
            If PingyPingy(dgvComputerList.Item(1, pos).Value()) Then
                AddAOnlineItem("Online", pos)
                dgvComputerList.Rows(pos).DefaultCellStyle.BackColor = Color.LightGreen
            Else
                AddAOnlineItem("Offline", pos)
                dgvComputerList.Rows(pos).DefaultCellStyle.BackColor = Color.Red
            End If
        Loop
        SyncLock ThreadLocka2
            If Not tableBeSortable Then
                Thread.Sleep(pingTimeout.Value * 2 + 5000)
                makeTableSortable()
                tableBeSortable = True
            End If
        End SyncLock
    End Sub
    Private Sub ChkAll()
        For rowCount As Integer = 0 To dgvComputerList.RowCount - 1
            dgvComputerList.Item(0, rowCount).Value = True
        Next
    End Sub
    Private Sub SendDaMessage()
        Dim pos As Integer
        Do While (CurrentComputer < (dgvComputerList.RowCount))
            SyncLock ThreadLocka
                pos = CurrentComputer
                CurrentComputer += 1
            End SyncLock
            If dgvComputerList.Item(2, pos).Value = "Offline" Then
                Continue Do
            End If
            Dim FileSource As String = "vbpop.vbs"
            Dim FileDestination As String
            Try
                FileDestination = "\\" & dgvComputerList.Item(1, pos).Value & "\c$\windows\"
                If dgvComputerList.Item(0, pos).Value Then
                    Dim VBCopyProcess As Process = New Process()
                    VBCopyProcess.StartInfo.FileName = "cmd.exe"
                    VBCopyProcess.StartInfo.Arguments = "/C copy /y c:\windows\vbpop.vbs \\" & _
                        dgvComputerList.Item(1, pos).Value & "\c$\windows\" & " && exit"
                    VBCopyProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    VBCopyProcess.Start()
                    VBCopyProcess.WaitForExit(3000)
                    If Not VBCopyProcess.HasExited Then
                        VBCopyProcess.Kill()
                        AddAOKItem(pos, "Failed")
                        dgvComputerList.Rows(pos).DefaultCellStyle.BackColor = Color.Orange
                    Else
                        Dim VBPopProcess As Process = New Process()
                        VBPopProcess.StartInfo.FileName = "psexec"
                        VBPopProcess.StartInfo.Arguments = " \\" & dgvComputerList.Item(1, pos).Value & _
                        " -s -i 0 -d wscript c:\windows\vbpop.vbs"
                        VBPopProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                        VBPopProcess.Start()
                        AddAOKItem(pos, "Successs")
                        dgvComputerList.Rows(pos).DefaultCellStyle.BackColor = Color.Green
                    End If
                End If
            Catch ex As Exception
            End Try
        Loop
        SyncLock ThreadLocka2
            If Not tableBeSortable Then
                Thread.Sleep(pingTimeout.Value * 2 + 5000)
                makeTableSortable()
                tableBeSortable = True
            End If
        End SyncLock
    End Sub
    Private Sub ButtonSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSend.Click
        CreateVB()
        sooper_sendur = New List(Of Threading.Thread)
        CurrentComputer = 0
        tableBeSortable = False
        deleteOfflineComputers.Visible = False
        dgvComputerList.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvComputerList.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvComputerList.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvComputerList.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvComputerList.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        numbaOfSendyThreadsUwant = 0
        For pos As Integer = 0 To dgvComputerList.RowCount - 1
            If dgvComputerList.Item(0, pos).Value Then
                numbaOfSendyThreadsUwant += 1
            End If
        Next
        If numbaOfSendyThreadsUwant > 1000 Then
            numbaOfSendyThreadsUwant = 250
        Else
            numbaOfSendyThreadsUwant = numbaOfSendyThreadsUwant / 4 + 1
        End If
        For i As Integer = 0 To numbaOfSendyThreadsUwant - 1
            Dim temp As Threading.Thread = New Threading.Thread(AddressOf SendDaMessage)
            temp.IsBackground = True
            sooper_sendur.Add(temp)
            sooper_sendur.Item(i).Start()
        Next
    End Sub
    Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
        CheckCloseThreads()
        Me.Close()
    End Sub
    Private Sub ButtonPrevue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrevue.Click
        CreateVB()
        Dim PreVueProcess As Process = New Process()
        PreVueProcess.StartInfo.FileName = "c:\windows\vbPop.vbs"
        PreVueProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        PreVueProcess.Start()
    End Sub
    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        CheckCloseThreads()
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LabelComputers.Text = ""
        ComboBoxType.Text = "Exclaimation"
        Dim PSexecRegKey As RegistryKey
        Dim strPsexecRegKey As String = "HKEY_CURRENT_USER\Software\Sysinternals\PsExec"
        PSexecRegKey = Registry.CurrentUser.OpenSubKey("Software\Sysinternals\PsExec", True)
        If PSexecRegKey Is Nothing Then
            My.Computer.Registry.SetValue(strPsexecRegKey, "EulaAccepted", "1", Microsoft.Win32.RegistryValueKind.DWord)
        End If
        dgvComputerList.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvComputerList.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvComputerList.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvComputerList.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvComputerList.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub
    Private Sub ButtonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFind.Click
        dgvComputerList.Rows.Clear()
        dgvComputerList.Rows.Clear()
        deleteOfflineComputers.Visible = False
        dgvComputerList.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvComputerList.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvComputerList.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvComputerList.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvComputerList.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        LabelComputers.Text = " "
        If Not thread2 Is Nothing Then
            If thread2.IsAlive Then
                thread2.Abort()
            End If
        End If
        thread2 = New Thread(New System.Threading.ThreadStart(AddressOf GetADComputerInfo))
        thread2.IsBackground = True
        thread2.Start()
    End Sub
    Private Sub makeTableSortable()
        If Me.InvokeRequired Then
            Try
                Me.Invoke(New MethodInvoker(AddressOf makeTableSortable))
            Catch ex As Exception
                'dunno what breaks here... haven't figured it out yet.
            End Try
        Else
            deleteOfflineComputers.Visible = True
            dgvComputerList.Columns(0).SortMode = DataGridViewColumnSortMode.Automatic
            dgvComputerList.Columns(1).SortMode = DataGridViewColumnSortMode.Automatic
            dgvComputerList.Columns(2).SortMode = DataGridViewColumnSortMode.Automatic
            dgvComputerList.Columns(3).SortMode = DataGridViewColumnSortMode.Automatic
            dgvComputerList.Columns(4).SortMode = DataGridViewColumnSortMode.Automatic
        End If
    End Sub
    Private Sub ButtonCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCheckAll.Click
        ChkAll()
    End Sub
    Private Sub deleteOfflineComputers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deleteOfflineComputers.Click
        Dim pos As Integer = 0
        Do While (pos < dgvComputerList.RowCount)
            If dgvComputerList.Item(2, pos).Value = "Offline" Then
                dgvComputerList.Rows.Remove(dgvComputerList.Rows(pos))
                pos -= 1
            End If
            pos += 1
        Loop
        LabelComputers.Text = pos.ToString
    End Sub
End Class