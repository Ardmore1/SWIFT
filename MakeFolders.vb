Imports System.Security.AccessControl
Imports System.IO
Imports System.Security
Imports System.Security.Principal
Imports System.DirectoryServices
Imports System.Management
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Win32
Imports ActiveDs
Public Class MakeFolders
    'Data Connector
    Public m_ServersDBConection As New OleDb.OleDbConnection()
    Public m_LocationsDBConection As New OleDb.OleDbConnection()
    'Data Addaptors
    Public m_ConfigDBdataAdaptorTableServers As OleDb.OleDbDataAdapter
    Public m_ConfigDBdataAdaptorTableDirectories As OleDb.OleDbDataAdapter
    Public m_ConfigDBdataAdaptorTablelocations As OleDb.OleDbDataAdapter
    Public m_ConfigDBdataAdaptorOU As OleDb.OleDbDataAdapter
    Public m_ConfigDBdataAdaptorEXDB As OleDb.OleDbDataAdapter
    'CommandBuilders
    Public m_cbComandBuilderServers As OleDb.OleDbCommandBuilder
    Public m_cbComandBuilderdirectories As OleDb.OleDbCommandBuilder
    Public m_cbComandBuilderLocations As OleDb.OleDbCommandBuilder
    Public m_cbComandBuilderOU As OleDb.OleDbCommandBuilder
    Public m_cbComandBuilderEXDB As OleDb.OleDbCommandBuilder
    'Data Tables
    Public m_dtServer As New DataTable
    Public m_dtDIrectories As New DataTable
    Public m_dtLocations As New DataTable
    Public m_dtOU As New DataTable
    Public m_dtEXDB As New DataTable
    Dim OUlock As Boolean = False
    Dim DirProblem As String = ""
    Public Sub LoadServerListDB()
        m_ServersDBConection.ConnectionString = _
        "Provider=Microsoft.jet.OLEDB.4.0;Data Source=config.mdb"
        m_ServersDBConection.Open()
        m_ConfigDBdataAdaptorTableServers = New OleDb.OleDbDataAdapter _
        ("Select * From servers where Dname = '" & frmMainForm.TheDomain & "'", m_ServersDBConection)
        m_cbComandBuilderServers = New OleDb.OleDbCommandBuilder _
        (m_ConfigDBdataAdaptorTableServers)
        m_ConfigDBdataAdaptorTableServers.Fill(m_dtServer)
        Dim rowcount As Integer = 0
        Dim d_rwServers As String
        lstServerList.Items.Clear()
        lstCreateIn.Items.Clear()
        Do Until rowcount = m_dtServer.Rows.Count
            d_rwServers = _
        m_dtServer.Rows(rowcount)("Server").ToString()
            lstServerList.Items.Add(d_rwServers)
            rowcount = rowcount + 1
        Loop
        m_ServersDBConection.Close()
        m_ServersDBConection.Dispose()
        m_ConfigDBdataAdaptorTableServers.Dispose()
        m_cbComandBuilderServers.Dispose()
        m_dtServer.Clear()
        m_dtServer.Dispose()
    End Sub
    Public Sub LoadDirListMainDB(ByVal strServerName As String)
        m_ServersDBConection.ConnectionString = _
        "Provider=Microsoft.jet.OLEDB.4.0;Data Source=config.mdb"
        m_ServersDBConection.Open()
        m_ConfigDBdataAdaptorTableDirectories = New OleDb.OleDbDataAdapter _
        ("Select * From directories WHERE server = '" & strServerName & "'", m_ServersDBConection)
        m_cbComandBuilderdirectories = New OleDb.OleDbCommandBuilder _
        (m_ConfigDBdataAdaptorTableDirectories)
        m_ConfigDBdataAdaptorTableDirectories.Fill(m_dtDIrectories)
        Dim rowcount As Integer = 0
        Dim d_rwdirectories As String
        lstCreateIn.Items.Clear()
        Do Until rowcount = m_dtDIrectories.Rows.Count
            d_rwdirectories = _
        m_dtDIrectories.Rows(rowcount)("path").ToString()
            lstCreateIn.Items.Add(d_rwdirectories)
            rowcount = rowcount + 1
        Loop
        m_ServersDBConection.Close()
        m_ServersDBConection.Dispose()
        m_ConfigDBdataAdaptorTableDirectories.Dispose()
        m_cbComandBuilderdirectories.Dispose()
        m_dtDIrectories.Clear()
        m_dtDIrectories.Dispose()
    End Sub
    Public Sub SetPermissions()
        Dim SelectedItemCount As Integer = lstCreateIn.SelectedItems.Count - 1
        Dim dInfo1(SelectedItemCount) As DirectoryInfo
        Dim DumUser As String = frmMainForm.TheDomain & "\"
        Dim acctRemove As New NTAccount(DumUser & "domain users")
        Dim acctAdd As New NTAccount(DumUser & txtUName.Text)
        Dim count As Integer = 0
        For count = 0 To SelectedItemCount
            Dim dInfo As New DirectoryInfo _
            (lstCreateIn.SelectedItems(count).ToString() & "\" & txtUName.Text)
            Dim dSecurity As DirectorySecurity = _
            dInfo.GetAccessControl(AccessControlSections.Access)
            ' Turn off inheritance and apply to directory.
            dSecurity.SetAccessRuleProtection(True, True)
            dInfo.SetAccessControl(dSecurity)
            ' Now, re-get the security with inheritance turned off and remove the group.
            dSecurity = dInfo.GetAccessControl(AccessControlSections.Access)
            dSecurity.AddAccessRule _
            (New FileSystemAccessRule _
            (acctAdd, FileSystemRights.FullControl, InheritanceFlags.ObjectInherit _
            Or InheritanceFlags.ContainerInherit, PropagationFlags.None, _
            AccessControlType.Allow))
            dSecurity.RemoveAccessRuleAll _
            (New FileSystemAccessRule _
            (acctRemove, FileSystemRights.FullControl, _
            InheritanceFlags.ObjectInherit Or InheritanceFlags.ContainerInherit, _
            PropagationFlags.None, AccessControlType.Allow))
            dInfo.SetAccessControl(dSecurity)
        Next count
    End Sub
    Public Sub CreateDirectories()
        Dim dSelectedItemCount As Integer = lstCreateIn.SelectedItems.Count - 1
        Dim dcount As Integer = 0
        Try
            For dcount = 0 To dSelectedItemCount
                Directory.CreateDirectory _
                (lstCreateIn.SelectedItems(dcount).ToString() & "\" & txtUName.Text)
            Next dcount
        Catch ex As Exception
            DirProblem = "Problem creating directory."
        End Try
    End Sub
    Function SeeIfAccountExists()
        Dim ADPath As String = "LDAP://" & frmMainForm.LDAPBaseDN
        Dim auser As String = txtUName.Text
        Dim dirEntry As New DirectoryEntry(ADPath)
        dirEntry.Username = Nothing
        dirEntry.Password = Nothing
        dirEntry.AuthenticationType = AuthenticationTypes.Secure
        Dim dirSearcher As DirectorySearcher = New DirectorySearcher(dirEntry)
        dirSearcher.Filter = "(&(objectCategory=Person)(objectClass=user)(SAMAccountName=" & auser & "))"
        dirSearcher.SearchScope = SearchScope.Subtree
        Dim results As SearchResult = dirSearcher.FindOne()
        If results Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function direxist(ByVal aDirectoryName As String)
        Dim SomeDirectory As New DirectoryInfo(aDirectoryName)
        If SomeDirectory.Exists Then
            Return aDirectoryName
        Else
            Return "notexist"
        End If
    End Function
    Public Sub clearStatus()
        LabelFoldersCreated.Visible = False
        PictureBoxFoldersCreated.Visible = False
        LabelDirFailReason.Visible = False
    End Sub
    Private Sub MakeFolders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clearStatus()
        LoadServerListDB()
    End Sub
    Private Sub lstServerList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstServerList.SelectedIndexChanged
        LoadDirListMainDB(CStr(lstServerList.SelectedItem))
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        clearStatus()
        Me.Cursor = Cursors.WaitCursor
        LabelFoldersCreated.Text = "Creating folders..."
        LabelFoldersCreated.Visible = True
        Me.Refresh()
        If lstServerList.SelectedItems.Count = 0 Then
            LabelFoldersCreated.Text = "Folders failed."
            PictureBoxFoldersCreated.BackColor = Color.Red
            PictureBoxFoldersCreated.Visible = True
            MessageBox.Show("Please select a server from the list.")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        If lstCreateIn.SelectedItems.Count = 0 Then
            LabelFoldersCreated.Text = "Folders Failed"
            PictureBoxFoldersCreated.BackColor = Color.Red
            PictureBoxFoldersCreated.Visible = True
            MessageBox.Show("Please select at least one directory from the directory list.")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        If Not SeeIfAccountExists() Then
            LabelFoldersCreated.Text = "Folders failed."
            PictureBoxFoldersCreated.BackColor = Color.Red
            PictureBoxFoldersCreated.Visible = True
            LabelDirFailReason.Text = "Username does not exist."
            LabelDirFailReason.Visible = True
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        Dim DireStatus As String = ""
        For InnDex As Integer = 0 To lstCreateIn.SelectedItems.Count - 1
            If direxist(lstCreateIn.SelectedItems(InnDex).ToString() & "\" & txtUName.Text) = "notexist" Then
            Else
                DireStatus += direxist(lstCreateIn.SelectedItems(InnDex).ToString() & "\" & txtUName.Text) & vbCrLf
            End If
        Next
        If DireStatus <> "" Then
            LabelFoldersCreated.Text = "Folders failed."
            PictureBoxFoldersCreated.BackColor = Color.Red
            PictureBoxFoldersCreated.Visible = True
            LabelDirFailReason.Text = "These directories already exist." & vbCrLf & DireStatus
            LabelDirFailReason.Visible = True
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        If txtUName.Text = "" Then
            LabelFoldersCreated.Text = "Folders failed."
            PictureBoxFoldersCreated.BackColor = Color.Red
            PictureBoxFoldersCreated.Visible = True
            LabelDirFailReason.Text = "No username entered."
            LabelDirFailReason.Visible = True
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        CreateDirectories()
        SetPermissions()
        LabelFoldersCreated.Text = "Folders created."
        PictureBoxFoldersCreated.BackColor = Color.Lime
        PictureBoxFoldersCreated.Visible = True
        Me.Cursor = Cursors.Default
    End Sub
End Class