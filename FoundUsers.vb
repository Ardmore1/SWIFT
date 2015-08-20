Imports System.Security.AccessControl
Imports System.IO
Imports System.Security
Imports System.Security.Principal
Imports System.DirectoryServices
Imports System.Management
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Win32
Imports System.Threading
'This form is my first attemp at multithreading.
'It allows you to search through active directory and does not freeze while searching.
'It also let's you select and use a user before the search has completed
Public Class FoundUsers
    Dim thread1, thread2 As Threading.Thread
    Dim searchDone As Boolean = True
    Public UserFilterOn As String = frmMainForm.tbxUserName.Text
    Public LDAPBaseDN As String = frmMainForm.LDAPBaseDN
    Private Delegate Sub PopulateListView(ByVal userItems As String, ByVal progbarCount As Integer, ByVal Max As Integer)
    Private Delegate Sub ProgressBarView(ByVal progbarCount As Integer)
    Private invoker As PopulateListView
    Private invoker1 As ProgressBarView
    Private Sub AddListItems(ByVal ListItem As String, ByVal progbarCount As Integer, ByVal Max As Integer)
        'this is what we want to be done on the primary thread
        ' tvServer.Nodes.Add(DirectCast(state, TreeNode))
        LabelSearching.Visible = True
        lbxFoundUsers.Items.Add(ListItem)
        ProgressBar1.Maximum = Max
        ProgressBar1.Value = progbarCount
        If progbarCount = Max Then
            LabelSearching.Visible = False
        End If
    End Sub
    Private Sub SetProgressBar(ByVal progbarCount As Integer)
        ProgressBar1.Maximum = progbarCount
    End Sub
    Private Sub ProgressBarInvoker(ByVal progbarCount As Integer)
        'this is run by the secondary thread
        'it INVOKES the desired action on the primary thread
        invoker1 = New ProgressBarView(AddressOf SetProgressBar)
        ProgressBar1.Invoke(invoker, progbarCount)
    End Sub
    Private Sub AddAListItem(ByVal ListItems As String, ByVal progbarCount As Integer, ByVal Max As Integer)
        'this is run by the secondary thread
        'it INVOKES the desired action on the primary thread
        invoker = New PopulateListView(AddressOf AddListItems)
        lbxFoundUsers.Invoke(invoker, ListItems, progbarCount, Max)
    End Sub
    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub
    Public Sub GetADInfoFind()
        Try
            Dim count As Integer
            searchDone = False
            Dim dirEntry As New DirectoryEntry("LDAP://" & LDAPBaseDN)
            dirEntry.Username = Nothing
            dirEntry.Password = Nothing
            dirEntry.AuthenticationType = AuthenticationTypes.Secure
            Dim dirSearcher As DirectorySearcher
            Dim resultCollection As SearchResultCollection
            dirSearcher = New DirectorySearcher(dirEntry)
            If UserFilterOn = "" Then
                dirSearcher.Filter = "(objectClass=user)"
            Else
                dirSearcher.Filter = "(&(objectClass=user)(|(cn=*" & UserFilterOn & "*)(sn=*" & UserFilterOn & "*)(givenName=*" & UserFilterOn & "*)(cn=*" & UserFilterOn & ")(sn=" & UserFilterOn & ")(givenName=" & UserFilterOn & ")(sAMAccountName=*" & UserFilterOn & "*)))"
            End If
            dirSearcher.PropertiesToLoad.Add("canonicalName")
            dirSearcher.PropertiesToLoad.Add("Lastlogon")
            dirSearcher.PropertiesToLoad.Add("LastlogontimeStamp")
            dirSearcher.PropertiesToLoad.Add("sn")
            dirSearcher.SearchScope = SearchScope.Subtree
            resultCollection = dirSearcher.FindAll()
            If resultCollection.Count <> 0 Then
                count = resultCollection.Count - 1
                Dim UserItem As String = ""
                For i As Integer = 0 To count Step 1
                    UserItem = resultCollection(i).GetDirectoryEntry.Properties("SAMAccountName").Value & _
                    " ---> " & resultCollection(i).GetDirectoryEntry.Properties("givenName").Value & " " & _
                    resultCollection(i).GetDirectoryEntry.Properties("sn").Value
                    AddAListItem(UserItem, i, count)
                Next i
            Else
                AddAListItem("None Found", 0, 0)
            End If
            dirEntry.Close()
        Catch ex As Exception
            MessageBox.Show(LDAPBaseDN)
            AddAListItem("None Found", 0, 0)
        End Try
        searchDone = True
    End Sub
    Private Sub FoundUsers_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Not thread1 Is Nothing Then
            If thread1.IsAlive() Then
                thread1.Abort()
            End If
            thread1 = Nothing
        End If
    End Sub
    Private Sub FoundUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        ProgressBar1.Minimum = 0
        If Not thread1 Is Nothing Then
            If thread1.IsAlive Then
                thread1.Abort()
            End If
        End If
        thread1 = New Thread(New System.Threading.ThreadStart(AddressOf GetADInfoFind))
        thread1.IsBackground = True
        thread1.Start()
    End Sub
    Private Sub lbxFoundUsers_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbxFoundUsers.MouseDoubleClick
        selectUser()
    End Sub
    Private Sub ButtonGetUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGetUser.Click
        selectUser()
    End Sub
    Private Sub selectUser()
        Dim theUser
        If lbxFoundUsers.SelectedItem <> "" Then
            theUser = Split(lbxFoundUsers.SelectedItem, " ---> ")
            frmMainForm.tbxUserName.Text = theUser(0)
            frmMainForm.ClearAllFeilds()
            frmMainForm.Focus()
            frmMainForm.Refresh()
            frmMainForm.GetADInfo()
            Me.Close()
        Else
            MessageBox.Show("Please select a user.")
        End If
    End Sub
    Private Sub FoundUsers_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not searchDone Then
            e.Cancel = True
        End If
    End Sub
End Class