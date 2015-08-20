Imports System.IO
Imports System.Threading
Imports System.Data
Imports System.Data.SqlClient
'This form is another attempt at the use of multi threading
'This form provides a differnt list of user login history to the PC. The source of this is collected by logon script and contains a complete history
'Where as the config mgr ssource only contains the single last login.
'From the information in this form the user can perforrm several management tasks on the user or PC
Public Class LogonHistory
    'Dim thread2 As New Thread(New System.Threading.ThreadStart(AddressOf CallTheSecondThread))
    Dim thread2 As Threading.Thread
    Dim ExportFile As String = ""
    Dim SMSServerDB As String = frmMainForm.SMSServerDB
    Dim usrLogonDB As String = frmMainForm.usrLogonDB
    Private Delegate Sub PopulateGridView(ByVal Colarray As Object, ByVal userCount As String)
    Private invoker As PopulateGridView
    Private Sub AddGridItems(ByVal Colarray As Object, ByVal userCount As String)
        'this is what we want to be done on the primary thread
        ' tvServer.Nodes.Add(DirectCast(state, TreeNode))
        'CheckBoxTodayOnly
        Try
            If UBound(Colarray) < 11 Then
                dgvUserHistory.Rows.Add(Colarray(0), Colarray(1), Colarray(2), DateTime.Parse(Colarray(3).trim).ToString("MM-dd-yy h:mm tt"), Colarray(4), _
                        DateTime.Parse(Colarray(5).trim).ToString("MM-dd-yy h:mm tt"), Colarray(6), Colarray(7), Colarray(8))
                txtUsrCount.Text = userCount
            ElseIf UBound(Colarray) < 12 Then
                dgvUserHistory.Rows.Add(Colarray(0), Colarray(1), Colarray(2), DateTime.Parse(Colarray(3).trim).ToString("MM-dd-yy h:mm tt"), Colarray(4), _
                        DateTime.Parse(Colarray(5).trim).ToString("MM-dd-yy h:mm tt"), Colarray(6), Colarray(7), Colarray(8), Colarray(9), Colarray(10), Colarray(11))
                txtUsrCount.Text = userCount
            ElseIf UBound(Colarray) < 13 Then
                dgvUserHistory.Rows.Add(Colarray(0), Colarray(1), Colarray(2), DateTime.Parse(Colarray(3).trim).ToString("MM-dd-yy h:mm tt"), Colarray(4), _
                        DateTime.Parse(Colarray(5).trim).ToString("MM-dd-yy h:mm tt"), Colarray(6), Colarray(7), Colarray(8), Colarray(9), Colarray(10), Colarray(11), Colarray(12))
                txtUsrCount.Text = userCount
            Else
                dgvUserHistory.Rows.Add(Colarray(0), Colarray(1), Colarray(2), DateTime.Parse(Colarray(3).trim).ToString("MM-dd-yy h:mm tt"), Colarray(4), _
                        DateTime.Parse(Colarray(5).trim).ToString("MM-dd-yy h:mm tt"), Colarray(6), Colarray(7), Colarray(8), Colarray(9), Colarray(10), Colarray(11), Colarray(12), Colarray(13))
                txtUsrCount.Text = userCount
            End If
        Catch ex As Exception
        End Try
        Try
            If CheckBoxColorCode.Checked Then
                Dim MyRowCount As Integer = dgvUserHistory.Rows.Count - 1
                Dim LogEventTypeString As DataGridViewCell = dgvUserHistory.Rows(MyRowCount).Cells(1)
                If Not LogEventTypeString.Value Is Nothing Then
                    If Not LogEventTypeString.Value Is DBNull.Value Then
                        If LogEventTypeString.Value.ToString.ToLower.IndexOf("logoff") <> -1 Then
                            dgvUserHistory.Rows(MyRowCount).DefaultCellStyle.BackColor = Color.PeachPuff
                        End If
                        If LogEventTypeString.Value.ToString.ToLower.IndexOf("logon") <> -1 Then
                            dgvUserHistory.Rows(MyRowCount).DefaultCellStyle.BackColor = Color.Honeydew
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub AddAGridItem(ByVal Colarray As Object, ByVal userCount As String)
        'this is run by the secondary thread
        'it INVOKES the desired action on the primary thread
        invoker = New PopulateGridView(AddressOf AddGridItems)
        dgvUserHistory.Invoke(invoker, Colarray, userCount)
    End Sub
    Sub UserInfoBox()
        Dim MyCurrentRow
        Dim SelectedUname
        Dim SelectedComputer
        Dim SelectedIP
        Dim SelectedLogonTime
        Dim EventType
        MyCurrentRow = dgvUserHistory.CurrentCell.RowIndex
        SelectedUname = dgvUserHistory.Rows(MyCurrentRow).Cells(0).Value
        SelectedComputer = dgvUserHistory.Rows(MyCurrentRow).Cells(2).Value
        SelectedIP = dgvUserHistory.Rows(MyCurrentRow).Cells(4).Value
        SelectedLogonTime = dgvUserHistory.Rows(MyCurrentRow).Cells(3).Value
        EventType = dgvUserHistory.Rows(MyCurrentRow).Cells(1).Value
        TextBoxStatus.Text = "Username=" & SelectedUname & "  Station=" & _
        SelectedComputer & "  IP=" & SelectedIP & "  " & EventType & "=" & SelectedLogonTime
    End Sub
    Sub CallTheSecondThread()
        Try
            Dim UserCount As Integer = 0
            Dim SecondArray() = Nothing
            ReDim SecondArray(14)
            Dim strSQLConn As String = "data source=" & SMSServerDB & "; " & "initial catalog=" & usrLogonDB & "; integrated security=true;"
            Dim SMSSQLconn As New SqlConnection(strSQLConn)
            SMSSQLconn.Open()
            Dim MySQLCommand As String = "Select EventTime, IP, LastReboot, Ram, CPU, Cfree, EventType, Manufacturer, Model, PCName, TheOS, " & _
                                         "TheDC, ServiceTag, TheUsers.TheUserName " & _
                                         "From LogonTable " & _
                                         "Inner Join TheUsers on LogonTable.FK_UserID = TheUsers.UserID " & _
                                         "Where LogonTable.EventTime = TheUsers.LastEvent " & _
                                         "Order by TheUserName asc"
            Dim sqlComm As New SqlCommand(MySQLCommand, SMSSQLconn)
            Dim MySQLreader As SqlDataReader = sqlComm.ExecuteReader()
            While MySQLreader.Read()
                Dim TempIPArray() As String
                Dim TheEventType As String = MySQLreader("EventType")
                If TheEventType = True Then
                    TheEventType = "LogON"
                Else
                    TheEventType = "LogOFF"
                End If
                SecondArray(0) = MySQLreader("TheUserName").ToString.Trim
                SecondArray(1) = TheEventType.Trim
                SecondArray(2) = MySQLreader("PCName").ToString.Trim
                SecondArray(3) = DateTime.Parse(MySQLreader("EventTime").ToString.Trim).ToString("MM-dd-yy h:mm tt")
                SecondArray(4) = MySQLreader("IP").ToString.Replace("0.0.0.0", " ").Replace("/", " ").Trim
                Try
                    TempIPArray = SecondArray(4).split(" ")
                    Dim NoDupArray As New ArrayList
                    For Each IPString As String In TempIPArray
                        If Not NoDupArray.Contains(IPString) Then
                            NoDupArray.Add(IPString)
                        End If
                    Next
                    Dim finalListofIPs As String = ""
                    For Each i As String In NoDupArray
                        If finalListofIPs = "" Then
                            finalListofIPs = i
                        Else
                            finalListofIPs = finalListofIPs & ", " & i
                        End If
                    Next
                    SecondArray(4) = finalListofIPs
                    'SecondArray(4) = String.Join(" ", NoDupArray.ToArray(GetType(String))).Trim.Replace(" ", "/")
                Catch ex As Exception
                End Try
                SecondArray(5) = DateTime.Parse(MySQLreader("LastReboot").ToString.Trim).ToString("MM-dd-yy h:mm tt")
                SecondArray(6) = MySQLreader("Ram").ToString.Trim
                SecondArray(7) = MySQLreader("Manufacturer").ToString.Trim
                SecondArray(8) = MySQLreader("Model").ToString().Trim
                SecondArray(9) = MySQLreader("CPU").ToString.Trim
                SecondArray(10) = MySQLreader("Cfree").ToString.Trim
                SecondArray(11) = MySQLreader("ServiceTag").ToString().Trim
                SecondArray(12) = MySQLreader("TheOS").ToString.Trim
                SecondArray(13) = MySQLreader("TheDC").ToString.Trim
                If CheckBoxTodayOnly.Checked Then
                    Dim TodaysDate As String = Now().ToString("MM-dd-yy")
                    Dim TheLineDate As String = DateTime.Parse(MySQLreader("EventTime").ToString.Trim).ToString("MM-dd-yy")
                    If TheLineDate = TodaysDate Then
                        UserCount = UserCount + 1
                        AddAGridItem(SecondArray, UserCount)
                    End If
                Else
                    UserCount = UserCount + 1
                    AddAGridItem(SecondArray, UserCount)
                End If
            End While
            MySQLreader.Close()
            SMSSQLconn.Close()
        Catch ex As Exception
        End Try
    End Sub
    Sub GetByIP(ByVal theIPAddress As String)
        dgvUserHistory.Rows.Clear()
        Try
            Dim UserCount As Integer = 0
            Dim SecondArray() = Nothing
            ReDim SecondArray(14)
            Dim strSQLConn As String = "data source=" & SMSServerDB & "; " & "initial catalog=" & usrLogonDB & "; integrated security=true;"
            Dim SMSSQLconn As New SqlConnection(strSQLConn)
            SMSSQLconn.Open()
            Dim MySQLCommand As String = "Select EventTime, IP, LastReboot, Ram, CPU, Cfree, EventType, Manufacturer, Model, PCName, TheOS, " & _
                                         "TheDC, ServiceTag, TheUsers.TheUserName " & _
                                         "From LogonTable " & _
                                         "Inner Join TheUsers on LogonTable.FK_UserID = TheUsers.UserID " & _
                                         "Where LogonTable.IP like '%" & theIPAddress & "%' " & _
                                         "Order by EventTime asc"
            Dim sqlComm As New SqlCommand(MySQLCommand, SMSSQLconn)
            Dim MySQLreader As SqlDataReader = sqlComm.ExecuteReader()
            While MySQLreader.Read()
                Dim TempIPArray() As String
                Dim TheEventType As String = MySQLreader("EventType")
                If TheEventType = True Then
                    TheEventType = "LogON"
                Else
                    TheEventType = "LogOFF"
                End If
                SecondArray(0) = MySQLreader("TheUserName").ToString.Trim
                SecondArray(1) = TheEventType.Trim
                SecondArray(2) = MySQLreader("PCName").ToString.Trim
                SecondArray(3) = DateTime.Parse(MySQLreader("EventTime").ToString.Trim).ToString("MM-dd-yy h:mm tt")
                SecondArray(4) = MySQLreader("IP").ToString.Replace("0.0.0.0", " ").Replace("/", " ").Trim
                Try
                    TempIPArray = SecondArray(4).split(" ")
                    Dim NoDupArray As New ArrayList
                    For Each IPString As String In TempIPArray
                        If Not NoDupArray.Contains(IPString) Then
                            NoDupArray.Add(IPString)
                        End If
                    Next
                    Dim finalListofIPs As String = ""
                    For Each i As String In NoDupArray
                        If finalListofIPs = "" Then
                            finalListofIPs = i
                        Else
                            finalListofIPs = finalListofIPs & ", " & i
                        End If
                    Next
                    SecondArray(4) = finalListofIPs
                    'SecondArray(4) = String.Join(" ", NoDupArray.ToArray(GetType(String))).Trim.Replace(" ", "/")
                Catch ex As Exception
                End Try
                SecondArray(5) = DateTime.Parse(MySQLreader("LastReboot").ToString.Trim).ToString("MM-dd-yy h:mm tt")
                SecondArray(6) = MySQLreader("Ram").ToString.Trim
                SecondArray(7) = MySQLreader("Manufacturer").ToString.Trim
                SecondArray(8) = MySQLreader("Model").ToString().Trim
                SecondArray(9) = MySQLreader("CPU").ToString.Trim
                SecondArray(10) = MySQLreader("Cfree").ToString.Trim
                SecondArray(11) = MySQLreader("ServiceTag").ToString().Trim
                SecondArray(12) = MySQLreader("TheOS").ToString.Trim
                SecondArray(13) = MySQLreader("TheDC").ToString.Trim
                UserCount = UserCount + 1
                AddGridItems(SecondArray, UserCount)
            End While
            dgvUserHistory.CurrentCell = dgvUserHistory.Rows(dgvUserHistory.Rows.Count - 1).Cells(0)
            UserInfoBox()
            MySQLreader.Close()
            SMSSQLconn.Close()
        Catch ex As Exception
        End Try
    End Sub
    Sub GetByPCName(ByVal ThePCName As String)
        dgvUserHistory.Rows.Clear()
        Try
            Dim UserCount As Integer = 0
            Dim SecondArray() = Nothing
            ReDim SecondArray(14)
            Dim strSQLConn As String = "data source=" & SMSServerDB & "; " & "initial catalog=" & usrLogonDB & "; integrated security=true;"
            Dim SMSSQLconn As New SqlConnection(strSQLConn)
            SMSSQLconn.Open()
            Dim MySQLCommand As String = "Select EventTime, IP, LastReboot, Ram, CPU, Cfree, EventType, Manufacturer, Model, PCName, TheOS, " & _
                                         "TheDC, ServiceTag, TheUsers.TheUserName " & _
                                         "From LogonTable " & _
                                         "Inner Join TheUsers on LogonTable.FK_UserID = TheUsers.UserID " & _
                                         "Where LogonTable.PCName = '" & ThePCName & "' " & _
                                         "Order by EventTime asc"
            Dim sqlComm As New SqlCommand(MySQLCommand, SMSSQLconn)
            Dim MySQLreader As SqlDataReader = sqlComm.ExecuteReader()
            While MySQLreader.Read()
                Dim TempIPArray() As String
                Dim TheEventType As String = MySQLreader("EventType")
                If TheEventType = True Then
                    TheEventType = "LogON"
                Else
                    TheEventType = "LogOFF"
                End If
                SecondArray(0) = MySQLreader("TheUserName").ToString.Trim
                SecondArray(1) = TheEventType.Trim
                SecondArray(2) = MySQLreader("PCName").ToString.Trim
                SecondArray(3) = DateTime.Parse(MySQLreader("EventTime").ToString.Trim).ToString("MM-dd-yy h:mm tt")
                SecondArray(4) = MySQLreader("IP").ToString.Replace("0.0.0.0", " ").Replace("/", " ").Trim
                Try
                    TempIPArray = SecondArray(4).split(" ")
                    Dim NoDupArray As New ArrayList
                    For Each IPString As String In TempIPArray
                        If Not NoDupArray.Contains(IPString) Then
                            NoDupArray.Add(IPString)
                        End If
                    Next
                    Dim finalListofIPs As String = ""
                    For Each i As String In NoDupArray
                        If finalListofIPs = "" Then
                            finalListofIPs = i
                        Else
                            finalListofIPs = finalListofIPs & ", " & i
                        End If
                    Next
                    SecondArray(4) = finalListofIPs
                    'SecondArray(4) = String.Join(" ", NoDupArray.ToArray(GetType(String))).Trim.Replace(" ", "/")
                Catch ex As Exception
                End Try
                SecondArray(5) = DateTime.Parse(MySQLreader("LastReboot").ToString.Trim).ToString("MM-dd-yy h:mm tt")
                SecondArray(6) = MySQLreader("Ram").ToString.Trim
                SecondArray(7) = MySQLreader("Manufacturer").ToString.Trim
                SecondArray(8) = MySQLreader("Model").ToString().Trim
                SecondArray(9) = MySQLreader("CPU").ToString.Trim
                SecondArray(10) = MySQLreader("Cfree").ToString.Trim
                SecondArray(11) = MySQLreader("ServiceTag").ToString().Trim
                SecondArray(12) = MySQLreader("TheOS").ToString.Trim
                SecondArray(13) = MySQLreader("TheDC").ToString.Trim
                UserCount = UserCount + 1
                AddGridItems(SecondArray, UserCount)
            End While
            dgvUserHistory.CurrentCell = dgvUserHistory.Rows(dgvUserHistory.Rows.Count - 1).Cells(0)
            UserInfoBox()
            MySQLreader.Close()
            SMSSQLconn.Close()
        Catch ex As Exception
        End Try
    End Sub
    Sub getRam(ByVal TheRam As String)
        dgvUserHistory.Rows.Clear()
        Try
            Dim TheMaxRam As Integer = Integer.Parse(TheRam)
            Dim UserCount As Integer = 0
            Dim SecondArray() = Nothing
            Dim strSQLConn As String = "data source=" & SMSServerDB & "; " & "initial catalog=" & usrLogonDB & "; integrated security=true;"
            Dim SMSSQLconn As New SqlConnection(strSQLConn)
            SMSSQLconn.Open()
            Dim MySQLCommand As String = "Select EventTime, IP, LastReboot, Ram, CPU, Cfree, EventType, Manufacturer, Model, PCName, TheOS, " & _
                                         "TheDC, ServiceTag, TheUsers.TheUserName " & _
                                         "From LogonTable " & _
                                         "Inner Join TheUsers on LogonTable.FK_UserID = TheUsers.UserID " & _
                                         "Where LogonTable.EventTime = TheUsers.LastEvent " & _
                                         "Order by TheUserName asc"
            Dim sqlComm As New SqlCommand(MySQLCommand, SMSSQLconn)
            Dim MySQLreader As SqlDataReader = sqlComm.ExecuteReader()
            While MySQLreader.Read()
                ReDim SecondArray(14)
                Dim TempIPArray() As String
                Dim TheEventType As String = MySQLreader("EventType")
                If TheEventType = True Then
                    TheEventType = "LogON"
                Else
                    TheEventType = "LogOFF"
                End If
                SecondArray(0) = MySQLreader("TheUserName").ToString.Trim
                SecondArray(1) = TheEventType.Trim
                SecondArray(2) = MySQLreader("PCName").ToString.Trim
                SecondArray(3) = DateTime.Parse(MySQLreader("EventTime").ToString.Trim).ToString("MM-dd-yy h:mm tt")
                SecondArray(4) = MySQLreader("IP").ToString.Replace("0.0.0.0", " ").Replace("/", " ").Trim
                Try
                    TempIPArray = SecondArray(4).split(" ")
                    Dim NoDupArray As New ArrayList
                    For Each IPString As String In TempIPArray
                        If Not NoDupArray.Contains(IPString) Then
                            NoDupArray.Add(IPString)
                        End If
                    Next
                    Dim finalListofIPs As String = ""
                    For Each i As String In NoDupArray
                        If finalListofIPs = "" Then
                            finalListofIPs = i
                        Else
                            finalListofIPs = finalListofIPs & ", " & i
                        End If
                    Next
                    SecondArray(4) = finalListofIPs
                    'SecondArray(4) = String.Join(" ", NoDupArray.ToArray(GetType(String))).Trim.Replace(" ", "/")
                Catch ex As Exception
                End Try
                SecondArray(5) = DateTime.Parse(MySQLreader("LastReboot").ToString.Trim).ToString("MM-dd-yy h:mm tt")
                SecondArray(6) = MySQLreader("Ram").ToString.Trim
                Try
                    Dim MegaBiter As String = MySQLreader("Ram").ToString.Trim
                    If (Integer.Parse(MegaBiter.ToString.Replace(" MB", "").Replace("MB", "").Trim)) > TheMaxRam Then
                        Continue While
                    End If
                Catch ex As Exception
                    Continue While
                End Try
                SecondArray(7) = MySQLreader("Manufacturer").ToString.Trim
                SecondArray(8) = MySQLreader("Model").ToString().Trim
                SecondArray(9) = MySQLreader("CPU").ToString.Trim
                SecondArray(10) = MySQLreader("Cfree").ToString.Trim
                SecondArray(11) = MySQLreader("ServiceTag").ToString().Trim
                SecondArray(12) = MySQLreader("TheOS").ToString.Trim
                SecondArray(13) = MySQLreader("TheDC").ToString.Trim
                UserCount = UserCount + 1
                AddGridItems(SecondArray, UserCount)
            End While
            MySQLreader.Close()
            SMSSQLconn.Close()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GetLastLine_Old(ByVal path As String)
        Dim retval As String = ""
        Dim FirstArray = Nothing
        Dim SecondArray = Nothing
        Dim fs As FileStream = New FileStream(path, FileMode.Open)
        Dim col1, col2, col3, col4, col5, col6, col7, col8, col9 As String
        Dim pos As Long = 0
        If fs.Length < 400 Then
            pos = 0
        Else
            pos = 400
        End If
        fs.Seek(pos, SeekOrigin.Current)
        Dim ts As StreamReader = New StreamReader(fs)
        retval = ts.ReadToEnd
        FirstArray = Split(retval, vbCrLf)
        If IsArray(FirstArray) = True Then
            If UBound(FirstArray) > 0 Then
                SecondArray = Split(FirstArray(UBound(FirstArray) - 1), ",")
            End If
        Else
            SecondArray = Split(retval, ",")
        End If
        If Not SecondArray Is Nothing Then
            If UBound(SecondArray) > 8 Then
                col1 = SecondArray(0)
                col2 = SecondArray(1)
                col3 = SecondArray(2)
                col4 = SecondArray(3)
                col5 = SecondArray(4)
                col6 = SecondArray(5)
                col7 = SecondArray(6)
                col8 = SecondArray(7)
                col9 = SecondArray(8)
                dgvUserHistory.Rows.Add(col1, col2, col3, col4, col5, col6, col7, col8, col9)
            End If
        End If
        ts.Close()
        fs.Close()
    End Sub
    Public Sub GetLastLine(ByVal path As String)
        Dim strSQLConn As String = "data source=" & SMSServerDB & "; " & "initial catalog=" & usrLogonDB & "; integrated security=true;"
        Dim SMSSQLconn As New SqlConnection(strSQLConn)
        SMSSQLconn.Open()
        Dim MySQLCommand As String = "Select EventTime, IP, LastReboot, Ram, CPU, Cfree, EventType, Manufacturer, Model, PCName, TheOS, " & _
                                     "TheDC, ServiceTag, TheUsers.TheUserName " & _
                                     "From LogonTable " & _
                                     "Inner Join TheUsers on LogonTable.FK_UserID = TheUsers.UserID " & _
                                     "Where LogonTable.EventTime = TheUsers.LastEvent"
        Dim sqlComm As New SqlCommand(MySQLCommand, SMSSQLconn)
        Dim MySQLreader As SqlDataReader = sqlComm.ExecuteReader()
        While MySQLreader.Read()
            Dim TheEventType As String = MySQLreader("EventType").ToString
            If TheEventType = "1" Then
                TheEventType = "LogON"
            Else
                TheEventType = "LogOFF"
            End If
            dgvUserHistory.Rows.Add(MySQLreader("TheUserName").ToString, TheEventType, MySQLreader("PCName").ToString, DateTime.Parse(MySQLreader("EventTime").ToString.Trim).ToString("MM-dd-yy h:mm tt"), _
                                    MySQLreader("IP").ToString, DateTime.Parse(MySQLreader("LastReboot").ToString.Trim).ToString("MM-dd-yy h:mm tt"), MySQLreader("Ram").ToString, _
                                    MySQLreader("Manufacturer").ToString, MySQLreader("Model").ToString, MySQLreader("CPU").ToString, _
                                    MySQLreader("Cfree").ToString, MySQLreader("ServiceTag").ToString, MySQLreader("TheOS").ToString, MySQLreader("TheDC").ToString)
        End While
        MySQLreader.Close()
        SMSSQLconn.Close()
    End Sub
    Public Sub getUser_old(ByVal user As String)
        Dim path As String = frmMainForm.usrLogPath
        Dim FileName As String = path & user & ".txt"
        Dim SecondArray
        If File.Exists(FileName) = True Then
            Dim objReader As New StreamReader(FileName)
            Do While objReader.Peek() <> -1
                SecondArray = Split(objReader.ReadLine() & vbNewLine, ",")
                Try
                    If UBound(SecondArray) > 7 And UBound(SecondArray) < 11 Then
                        dgvUserHistory.Rows.Add(SecondArray(0), SecondArray(1), SecondArray(2), DateTime.Parse(SecondArray(3).trim).ToString("MM-dd-yy h:mm tt"), SecondArray(4), _
                        DateTime.Parse(SecondArray(5).trim).ToString("MM-dd-yy h:mm tt"), SecondArray(6), SecondArray(7), SecondArray(8))
                    ElseIf UBound(SecondArray) > 7 And UBound(SecondArray) < 12 Then
                        dgvUserHistory.Rows.Add(SecondArray(0), SecondArray(1), SecondArray(2), DateTime.Parse(SecondArray(3).trim).ToString("MM-dd-yy h:mm tt"), SecondArray(4), _
                        DateTime.Parse(SecondArray(5).trim).ToString("MM-dd-yy h:mm tt"), SecondArray(6), SecondArray(7), SecondArray(8), SecondArray(9), SecondArray(10), SecondArray(11))
                    ElseIf UBound(SecondArray) > 7 And UBound(SecondArray) < 13 Then
                        dgvUserHistory.Rows.Add(SecondArray(0), SecondArray(1), SecondArray(2), DateTime.Parse(SecondArray(3).trim).ToString("MM-dd-yy h:mm tt"), SecondArray(4), _
                        DateTime.Parse(SecondArray(5).trim).ToString("MM-dd-yy h:mm tt"), SecondArray(6), SecondArray(7), SecondArray(8), SecondArray(9), SecondArray(10), SecondArray(11), SecondArray(12))
                    ElseIf UBound(SecondArray) > 7 Then
                        dgvUserHistory.Rows.Add(SecondArray(0), SecondArray(1), SecondArray(2), DateTime.Parse(SecondArray(3).trim).ToString("MM-dd-yy h:mm tt"), SecondArray(4), _
                        DateTime.Parse(SecondArray(5).trim).ToString("MM-dd-yy h:mm tt"), SecondArray(6), SecondArray(7), SecondArray(8), SecondArray(9), SecondArray(10), SecondArray(11), SecondArray(12), SecondArray(13))
                    End If
                Catch ex As Exception
                End Try
            Loop
            objReader.Close()
            dgvUserHistory.CurrentCell = dgvUserHistory.Rows(dgvUserHistory.Rows.Count - 1).Cells(0)
            UserInfoBox()
        Else
            MsgBox("Sorry, that file does not exist.")
        End If
    End Sub
    Public Sub getUser(ByVal user As String)
        Try
            Dim UserCount As Integer = 0
            Dim strSQLConn As String = "data source=" & SMSServerDB & "; " & "initial catalog=" & usrLogonDB & "; " & "integrated security=true;"
            Dim SMSSQLconn As New SqlConnection(strSQLConn)
            SMSSQLconn.Open()
            Dim MySQLCommand As String = "Select EventTime, IP, LastReboot, Ram, CPU, Cfree, EventType, Manufacturer, Model, PCName, TheOS, " & _
                                         "TheDC, ServiceTag, TheUsers.TheUserName " & _
                                         "From LogonTable " & _
                                         "Inner Join TheUsers on LogonTable.FK_UserID = TheUsers.UserID " & _
                                         "Where TheUsers.TheUserName = '" & user & "' " & _
                                         "order by EventTime asc"
            Dim sqlComm As New SqlCommand(MySQLCommand, SMSSQLconn)
            Dim MySQLreader As SqlDataReader = sqlComm.ExecuteReader()
            While MySQLreader.Read()
                Dim TheEventType As String = MySQLreader("EventType")
                If TheEventType = True Then
                    TheEventType = "LogON"
                Else
                    TheEventType = "LogOFF"
                End If
                If CheckBoxTodayOnly.Checked Then
                    Dim TodaysDate As String = Now().ToString("MM-dd-yy")
                    Dim TheLineDate As String = DateTime.Parse(MySQLreader("EventTime").ToString.Trim).ToString("MM-dd-yy")
                    If TheLineDate = TodaysDate Then
                        dgvUserHistory.Rows.Add(MySQLreader("TheUserName").ToString.Trim, TheEventType, MySQLreader("PCName").ToString.Trim, DateTime.Parse(MySQLreader("EventTime").ToString.Trim).ToString("MM-dd-yy h:mm tt"), _
                                        MySQLreader("IP").ToString.Replace("0.0.0.0", " ").Replace("/", " ").Trim, DateTime.Parse(MySQLreader("LastReboot").ToString.Trim).ToString("MM-dd-yy h:mm tt"), MySQLreader("Ram").ToString.Trim, _
                                        MySQLreader("Manufacturer").ToString.Trim, MySQLreader("Model").ToString.Trim, MySQLreader("CPU").ToString.Trim, _
                                        MySQLreader("Cfree").ToString.Trim, MySQLreader("ServiceTag").ToString.Trim, MySQLreader("TheOS").ToString.Trim, MySQLreader("TheDC").ToString.Trim)
                        UserCount = UserCount + 1
                    End If
                Else
                    dgvUserHistory.Rows.Add(MySQLreader("TheUserName").ToString.Trim, TheEventType, MySQLreader("PCName").ToString.Trim, DateTime.Parse(MySQLreader("EventTime").ToString.Trim).ToString("MM-dd-yy h:mm tt"), _
                                        MySQLreader("IP").ToString.Replace("0.0.0.0", " ").Replace("/", " ").Trim, DateTime.Parse(MySQLreader("LastReboot").ToString.Trim).ToString("MM-dd-yy h:mm tt"), MySQLreader("Ram").ToString.Trim, _
                                        MySQLreader("Manufacturer").ToString.Trim, MySQLreader("Model").ToString.Trim, MySQLreader("CPU").ToString.Trim, _
                                        MySQLreader("Cfree").ToString.Trim, MySQLreader("ServiceTag").ToString.Trim, MySQLreader("TheOS").ToString.Trim, MySQLreader("TheDC").ToString.Trim)
                    UserCount = UserCount + 1
                End If
                Try
                    If CheckBoxColorCode.Checked Then
                        Dim MyRowCount As Integer = dgvUserHistory.Rows.Count - 1
                        Dim LogEventTypeString As DataGridViewCell = dgvUserHistory.Rows(MyRowCount).Cells(1)
                        If Not LogEventTypeString.Value Is Nothing Then
                            If Not LogEventTypeString.Value Is DBNull.Value Then
                                If LogEventTypeString.Value.ToString.ToLower.IndexOf("logoff") <> -1 Then
                                    dgvUserHistory.Rows(MyRowCount).DefaultCellStyle.BackColor = Color.PeachPuff
                                End If
                                If LogEventTypeString.Value.ToString.ToLower.IndexOf("logon") <> -1 Then
                                    dgvUserHistory.Rows(MyRowCount).DefaultCellStyle.BackColor = Color.Honeydew
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                End Try
            End While
            txtUsrCount.Text = UserCount.ToString
            dgvUserHistory.CurrentCell = dgvUserHistory.Rows(dgvUserHistory.Rows.Count - 1).Cells(0)
            UserInfoBox()
            MySQLreader.Close()
            SMSSQLconn.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LogonHistory_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If thread2.IsAlive() Then
            thread2.Abort()
        End If
        thread2 = Nothing
    End Sub
    Private Sub LogonHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        dgvUserHistory.Rows.Clear()
        Me.txtUsrCount.Text = " "
        thread2 = New Thread(New System.Threading.ThreadStart(AddressOf CallTheSecondThread))
        thread2.IsBackground = True
        thread2.Start()
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Sub dgvExport()
        If TextBoxExportFilename.Text = "" Then
            MessageBox.Show("Please enter a valid filename.")
            Exit Sub
        End If
        Dim toFileValue As String = ""
        ExportFile = TextBoxExportFilename.Text
        Try
            Dim ObjFileSystem As New IO.StreamWriter(TextBoxExportFilename.Text, False)
            For rowCount As Integer = 0 To CInt(txtUsrCount.Text) - 1
                toFileValue = ""
                For CellCount As Integer = 0 To dgvUserHistory.ColumnCount - 1
                    If dgvUserHistory.Item(CellCount, rowCount).Value = vbNullString Then
                        toFileValue = toFileValue & ","
                    Else
                        toFileValue = toFileValue & dgvUserHistory.Item(CellCount, rowCount).Value & ","
                    End If
                Next
                ObjFileSystem.Write(toFileValue & vbCrLf)
            Next
            MessageBox.Show("Export complete.")
            ObjFileSystem.Close()
        Catch ex As Exception
            MessageBox.Show("Something unexpected occured with the filename, please examine what was entered.")
        End Try
    End Sub
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        dgvUserHistory.Rows.Clear()
        Me.txtUsrCount.Text = " "
        If Not thread2 Is Nothing Then
            If thread2.IsAlive Then
                thread2.Abort()
            End If
        End If
        thread2 = New Thread(New System.Threading.ThreadStart(AddressOf CallTheSecondThread))
        thread2.IsBackground = True
        thread2.Start()
    End Sub
    Sub WallPaperWacker(ByVal TheComputer As String)
        If CheckBoxnukeWallpaper.Checked Then
            Dim KillWallPaper As Process = New Process()
            KillWallPaper.StartInfo.FileName = "psexec.exe"
            KillWallPaper.StartInfo.Arguments = " \\" & TheComputer & "  -i -c c:\windows\disablewallpaper.bat"
            KillWallPaper.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            KillWallPaper.Start()
        End If
        If CheckBoxNpad.Checked Then
            Dim KillWallPaper As Process = New Process()
            KillWallPaper.StartInfo.FileName = "psexec.exe"
            KillWallPaper.StartInfo.Arguments = " \\" & TheComputer & "  -i -c c:\WINDOWS\launchNotePad.bat"
            KillWallPaper.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            KillWallPaper.Start()
        End If
    End Sub
    Private Sub btnGetUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetUser.Click
        If thread2.IsAlive() Then
            thread2.Abort()
        End If
        Dim ppart
        Dim RSelected As String
        If dgvUserHistory.SelectedCells.Count < 1 Then
            MsgBox("Please select at least one item.")
        Else
            ppart = dgvUserHistory.SelectedRows(0).Index.ToString
            RSelected = dgvUserHistory.Rows(ppart).Cells(0).Value
            dgvUserHistory.Rows.Clear()
            getUser(RSelected)
        End If
    End Sub
    Private Sub btnRcontrol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRcontrol.Click
        Dim ppart
        Dim RSelected As String
        ppart = dgvUserHistory.CurrentCell.RowIndex
        RSelected = dgvUserHistory.Rows(ppart).Cells(2).Value
        If CheckBoxnukeWallpaper.Checked Then
            Dim KillWallPaper As Process = New Process()
            KillWallPaper.StartInfo.FileName = "psexec.exe"
            KillWallPaper.StartInfo.Arguments = " \\" & RSelected & "  -i -c c:\windows\disablewallpaper.bat"
            KillWallPaper.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            KillWallPaper.Start()
        End If
        If CheckBoxNpad.Checked Then
            Dim KillWallPaper As Process = New Process()
            KillWallPaper.StartInfo.FileName = "psexec.exe"
            KillWallPaper.StartInfo.Arguments = " \\" & RSelected & "  -i -c c:\WINDOWS\launchNotePad.bat"
            KillWallPaper.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            KillWallPaper.Start()
        End If
        System.Diagnostics.Process.Start("rc.exe", " 1 " & RSelected & " \\" & frmMainForm.SMSServer & "\")
    End Sub
    Private Sub btnShadow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShadow.Click
        Dim ppart
        Dim RSelected As String
        If dgvUserHistory.SelectedCells.Count < 1 Then
            MsgBox("Please select at least one item.")
        Else
            ppart = dgvUserHistory.CurrentCell.RowIndex
            RSelected = dgvUserHistory.Rows(ppart).Cells(2).Value
            If CheckBoxnukeWallpaper.Checked Then
                Dim KillWallPaper As Process = New Process()
                KillWallPaper.StartInfo.FileName = "psexec.exe"
                KillWallPaper.StartInfo.Arguments = " \\" & RSelected & "  -i -c -d c:\windows\disablewallpaper.bat"
                KillWallPaper.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                KillWallPaper.Start()
            End If
            If CheckBoxNpad.Checked Then
                Dim OpenNotePad As Process = New Process()
                OpenNotePad.StartInfo.FileName = "psexec.exe"
                OpenNotePad.StartInfo.Arguments = " \\" & RSelected & "  -i -c -d c:\WINDOWS\launchNotePad.bat"
                OpenNotePad.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                OpenNotePad.Start()
            End If
            System.Diagnostics.Process.Start("shadow", " Console /server:" & RSelected)
        End If
    End Sub
    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Dim found As Boolean = False
        Dim x As Integer = 0
        If dgvUserHistory.SelectedRows.Count > 0 Then
            x = dgvUserHistory.CurrentRow.Index + 2
        Else
            x = 0
        End If
        While (x < dgvUserHistory.Rows.Count) And (found <> True)
            Dim y As Integer = 0
            While (y < dgvUserHistory.Rows(x).Cells.Count - 1) And (found <> True)
                Dim CellValue As DataGridViewCell = dgvUserHistory.Rows(x).Cells(y)
                If Not CellValue.Value Is Nothing Then
                    If Not CellValue.Value Is DBNull.Value Then
                        If CellValue.Value.ToString.ToLower.IndexOf(tbxFindString.Text.ToLower) <> -1 Then
                            dgvUserHistory.ClearSelection()
                            dgvUserHistory.FirstDisplayedScrollingRowIndex = dgvUserHistory.Rows(x).Index
                            dgvUserHistory.Refresh()
                            dgvUserHistory.Rows(x).Selected = True
                            dgvUserHistory.CurrentCell = dgvUserHistory.Rows(x).Cells(0)
                            found = True
                        End If
                    End If
                End If
                y += 1
            End While
            x += 1
        End While
        UserInfoBox()
        If found = False Then
            MessageBox.Show("Unable to locate.")
        End If
    End Sub
    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        dgvExport()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ppart
        Dim RSelected As String
        If dgvUserHistory.SelectedCells.Count < 1 Then
            MessageBox.Show("Please select a computer first.")
            Exit Sub
        End If
        ppart = dgvUserHistory.CurrentCell.RowIndex
        RSelected = dgvUserHistory.Rows(ppart).Cells(2).Value
        Dim ThePinger As Process = New Process()
        ThePinger.StartInfo.FileName = "ping.exe"
        ThePinger.StartInfo.Arguments = " " & RSelected & " -t"
        ThePinger.StartInfo.WindowStyle = ProcessWindowStyle.Normal
        ThePinger.Start()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ppart
        Dim RSelected As String
        If dgvUserHistory.SelectedCells.Count < 1 Then
            MessageBox.Show("Please select a computer first.")
            Exit Sub
        End If
        ppart = dgvUserHistory.CurrentCell.RowIndex
        RSelected = dgvUserHistory.Rows(ppart).Cells(2).Value
        Dim TheCDrive As Process = New Process()
        TheCDrive.StartInfo.FileName = "Explorer.exe"
        TheCDrive.StartInfo.Arguments = " \\" & RSelected & "\c$"
        TheCDrive.StartInfo.WindowStyle = ProcessWindowStyle.Normal
        TheCDrive.Start()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim ppart
        Dim RSelected As String
        If dgvUserHistory.SelectedCells.Count < 1 Then
            MessageBox.Show("Please select a computer first.")
            Exit Sub
        End If
        ppart = dgvUserHistory.CurrentCell.RowIndex
        RSelected = dgvUserHistory.Rows(ppart).Cells(2).Value
        Dim ManageComputer As Process = New Process()
        ManageComputer.StartInfo.FileName = "compmgmt.msc"
        ManageComputer.StartInfo.Arguments = "  /computer=\\" & RSelected
        ManageComputer.StartInfo.WindowStyle = ProcessWindowStyle.Normal
        ManageComputer.Start()
    End Sub
    Private Sub dgvUserHistory_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvUserHistory.MouseUp
        Try
            If e.Button = MouseButtons.Right Then
                Dim MyhitTestInfo As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
                If MyhitTestInfo.Type = DataGridViewHitTestType.Cell Then
                    dgvUserHistory.CurrentCell = dgvUserHistory.Item(MyhitTestInfo.ColumnIndex, MyhitTestInfo.RowIndex)
                End If
                ContextMenuStrip1.Show(dgvUserHistory, New Point(e.X, e.Y))
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub dgvUserHistory_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvUserHistory.SelectionChanged
        UserInfoBox()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFilter.Click
        HistoryFilter.Show()
    End Sub
    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            Clipboard.SetDataObject(dgvUserHistory.CurrentCell.Value.ToString)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CheckBoxTodayOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxTodayOnly.CheckedChanged
        dgvUserHistory.Rows.Clear()
        Me.txtUsrCount.Text = " "
        If Not thread2 Is Nothing Then
            If thread2.IsAlive Then
                thread2.Abort()
            End If
        End If
        thread2 = New Thread(New System.Threading.ThreadStart(AddressOf CallTheSecondThread))
        thread2.IsBackground = True
        thread2.Start()
    End Sub
    Private Sub CheckBoxColorCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxColorCode.CheckedChanged
        dgvUserHistory.Rows.Clear()
        Me.txtUsrCount.Text = " "
        If Not thread2 Is Nothing Then
            If thread2.IsAlive Then
                thread2.Abort()
            End If
        End If
        thread2 = New Thread(New System.Threading.ThreadStart(AddressOf CallTheSecondThread))
        thread2.IsBackground = True
        thread2.Start()
    End Sub
End Class