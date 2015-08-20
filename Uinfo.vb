Imports System.Security.AccessControl
Imports System.IO
Imports System.Security
Imports System.Security.Principal
Imports System.DirectoryServices
Imports System.Management
Public Class Uinfo
    Public Sub GetADInfo()
        Try
            Dim strOfficeM As String = "na"
            Dim strTelM As String = "na"
            Dim strStreetM As String = "na"
            Dim strCityM As String = "na"
            Dim strStateM As String = "na"
            Dim strZipM As String = "na"
            Dim strCountryM As String = "na"
            Dim strFaxM As String = "na"
            Dim strCompanyM As String = "na"
            Dim strtitle As String = "na"
            Dim strDept As String = "na"
            If frmMainForm.tbxUserName.Text = "" Then
                MessageBox.Show("Please enter a user first.")
                Me.Close()
                Exit Sub
            End If
            Dim auser As String = frmMainForm.tbxUserName.Text
            Dim userLDAPpath As String
            Dim notFound As Boolean = True
            For Each userLDAPpath In frmMainForm.userLDAPPaths
                Dim dirEntry As New DirectoryEntry("LDAP://" & userLDAPpath)
                dirEntry.Username = Nothing
                dirEntry.Password = Nothing
                dirEntry.AuthenticationType = AuthenticationTypes.Secure
                Dim dirSearcher As DirectorySearcher = New DirectorySearcher(dirEntry)
                dirSearcher.Filter = "(&(objectCategory=Person)(objectClass=user)(SAMAccountName=" & auser & "))"
                dirSearcher.PropertiesToLoad.Add("info")
                dirSearcher.SearchScope = SearchScope.Subtree
                Dim results As SearchResult = dirSearcher.FindOne()
                If Not results Is Nothing Then
                    notFound = False
                    Dim dirEntryResults As New DirectoryEntry(results.Path)
                    dirEntryResults.Username = Nothing
                    dirEntryResults.Password = Nothing
                    dirEntryResults.AuthenticationType = AuthenticationTypes.Secure
                    rtxUserInfo.Text = dirEntryResults.Properties("info").Value
                    txtaccountName.Text = auser
                    dirEntryResults.Close()
                End If
                dirEntry.Close()
            Next
            If notFound Then
                MessageBox.Show("Unable to find this user.")
            End If
        Catch ex As Exception
            MessageBox.Show("Unfortunately you do not have permissions to perform this function.")
        End Try
    End Sub
    Public Sub NotesUpdate()
        Try
            Dim strOfficeM As String = "na"
            Dim strTelM As String = "na"
            Dim strStreetM As String = "na"
            Dim strCityM As String = "na"
            Dim strStateM As String = "na"
            Dim strZipM As String = "na"
            Dim strCountryM As String = "na"
            Dim strFaxM As String = "na"
            Dim strCompanyM As String = "na"
            Dim strtitle As String = "na"
            Dim strDept As String = "na"
            If frmMainForm.tbxUserName.Text = "" Then
                MessageBox.Show("Please enter a user first.")
                Me.Close()
                Exit Sub
            End If
            Dim auser As String = frmMainForm.tbxUserName.Text
            Dim notFound As Boolean = True
            Dim userLDAPpath As String
            For Each userLDAPpath In frmMainForm.userLDAPPaths
                Dim dirEntry As New DirectoryEntry("LDAP://" & userLDAPpath)
                dirEntry.Username = Nothing
                dirEntry.Password = Nothing
                dirEntry.AuthenticationType = AuthenticationTypes.Secure
                Dim dirSearcher As DirectorySearcher = New DirectorySearcher(dirEntry)
                dirSearcher.Filter = "(&(objectCategory=Person)(objectClass=user)(SAMAccountName=" & auser & "))"
                dirSearcher.PropertiesToLoad.Add("info")
                dirSearcher.SearchScope = SearchScope.Subtree
                Dim results As SearchResult = dirSearcher.FindOne()
                If Not results Is Nothing Then
                    notFound = False
                    Dim dirEntryResults As New DirectoryEntry(results.Path)
                    dirEntryResults.Username = Nothing
                    dirEntryResults.Password = Nothing
                    dirEntryResults.AuthenticationType = AuthenticationTypes.Secure
                    If rtxUserInfo.Text = "" Then
                        dirEntryResults.Properties("info").Value = " "
                    Else
                        dirEntryResults.Properties("info").Value = rtxUserInfo.Text
                    End If
                    dirEntryResults.CommitChanges()
                    dirEntryResults.Close()
                End If
                dirEntry.Close()
            Next
            If notFound Then
                MessageBox.Show("Unable to find this user.")
            End If
        Catch ex As Exception
            MessageBox.Show("Unfortunately you do not have permissions to perform this function.")
        End Try
    End Sub
    Private Sub Uinfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetADInfo()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub btnUpdateNotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateNotes.Click
        NotesUpdate()
        Me.Close()
    End Sub
End Class