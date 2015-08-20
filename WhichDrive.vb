Imports System.Security.AccessControl
Imports System.IO
Imports System.Security
Imports System.Security.Principal
Imports System.DirectoryServices
Imports System.Management
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Win32
Public Class WhichDrive
    Dim TheDriveMappingScriptFileLocation As String = frmMainForm.driveMapScriptLocation
    Public AllTheMapping() As MappingType
    Dim CurrentUsersGroups() As String
    Structure MappingType
        Implements IComparable
        Public TheServer As String
        Public TheGroup As String
        Public TheDrive As String
        Public TheShare As String
        Public Overloads Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
            Dim StructToCompare As MappingType = DirectCast(obj, MappingType)
            Return Me.TheServer.CompareTo(StructToCompare.TheServer)
        End Function
    End Structure
    Sub ReadMapper()
        ReDim AllTheMapping(0)
        Dim objFileReader As New System.IO.StreamReader(TheDriveMappingScriptFileLocation)
        Dim TextLine As String = ""
        Dim FileHasStarted As Boolean = False
        Dim LastCustomerIndex = 0
        Do While objFileReader.Peek() <> -1
            Dim splitTextLine() As String
            Dim ServerSplit() As String
            TextLine = objFileReader.ReadLine().ToLower
            If TextLine.IndexOf("'beginofmappingsection") <> -1 Then
                FileHasStarted = True
                Continue Do
            End If
            If TextLine.IndexOf("'endofmappingsection") <> -1 Then
                FileHasStarted = False
                Continue Do
            End If
            If Not FileHasStarted Then
                Continue Do
            End If
            If TextLine = "" Then
                Continue Do
            End If
            Try
                If (TextLine.Substring(0, 1) = "'") Then
                    Continue Do
                End If
            Catch ex As Exception
            End Try
            TextLine = TextLine.Replace("call fundrivemapping(", "")
            TextLine = TextLine.Replace(Chr(34), "")
            TextLine = TextLine.Replace(" ", "")
            TextLine = TextLine.Replace(")", "")
            splitTextLine = TextLine.Split(",")
            ServerSplit = splitTextLine(2).Replace("\\", "").Split("\")
            If AllTheMapping(0).TheServer Is Nothing Then
                AllTheMapping(0).TheServer = ServerSplit(0)
                AllTheMapping(0).TheDrive = splitTextLine(1)
                AllTheMapping(0).TheGroup = splitTextLine(0)
                AllTheMapping(0).TheShare = splitTextLine(2)
            Else
                Dim Newlength As Integer = AllTheMapping.Length
                ReDim Preserve AllTheMapping(Newlength)
                AllTheMapping(Newlength).TheServer = ServerSplit(0)
                AllTheMapping(Newlength).TheDrive = splitTextLine(1)
                AllTheMapping(Newlength).TheGroup = splitTextLine(0)
                AllTheMapping(Newlength).TheShare = splitTextLine(2)
            End If
        Loop
        objFileReader.Close()
    End Sub
    Sub GetUsersGroupMembership(ByVal Username As String)
        ReDim CurrentUsersGroups(0)
        CurrentUsersGroups(0) = Nothing
        Try
            Dim MySelf As String = System.Environment.UserName.ToString
            Dim userLDAPpath As String
            For Each userLDAPpath In frmMainForm.userLDAPPaths
                Dim ADPath As String = "LDAP://" & userLDAPpath
                Dim dirEntry As New DirectoryEntry(ADPath)
                dirEntry.Username = Nothing
                dirEntry.Password = Nothing
                dirEntry.AuthenticationType = AuthenticationTypes.Secure
                Dim dirSearcher As DirectorySearcher = New DirectorySearcher(dirEntry)
                dirSearcher.Filter = "(&(objectCategory=Person)(objectClass=user)(SAMAccountName=" & Username & "))"
                dirSearcher.SearchScope = SearchScope.Subtree
                Dim results As SearchResult = dirSearcher.FindOne()
                If Not results Is Nothing Then
                    Dim DirectoryEntryTheGroup As New DirectoryEntry(results.Path)
                    DirectoryEntryTheGroup.Username = Nothing
                    DirectoryEntryTheGroup.Password = Nothing
                    DirectoryEntryTheGroup.AuthenticationType = AuthenticationTypes.Secure
                    For Each group As String In DirectoryEntryTheGroup.Properties("memberOf").Value
                        Dim GroupSplit() As String
                        If CurrentUsersGroups(0) Is Nothing Then
                            GroupSplit = group.Split(",")
                            CurrentUsersGroups(0) = GroupSplit(0).Replace("CN=", "").ToLower
                        Else
                            Dim newIndex As Integer = CurrentUsersGroups.Length
                            GroupSplit = group.Split(",")
                            ReDim Preserve CurrentUsersGroups(newIndex)
                            CurrentUsersGroups(newIndex) = GroupSplit(0).Replace("CN=", "").ToLower
                        End If
                    Next
                    DirectoryEntryTheGroup.Close()
                End If
                dirEntry.Close()
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ButtonLookUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLookUp.Click
        ListBoxMappings.Text = ""
        If RadioButtonUser.Checked Then
            GetUsersGroupMembership(TextBoxUserShare.Text)
            If Not CurrentUsersGroups(0) Is Nothing Then
                For Each UserGroup As String In CurrentUsersGroups
                    For i As Integer = 0 To AllTheMapping.Length - 1
                        If AllTheMapping(i).TheGroup.ToLower.IndexOf(UserGroup) <> -1 Then
                            ListBoxMappings.Text += " " & AllTheMapping(i).TheDrive.ToUpper & " --> " & AllTheMapping(i).TheShare.Replace("&wshnet.username", TextBoxUserShare.Text) & vbCrLf
                        End If
                    Next
                Next
            End If
        ElseIf RadioButtonShare.Checked Then
            For i As Integer = 0 To AllTheMapping.Length - 1
                If AllTheMapping(i).TheShare.ToLower.IndexOf(TextBoxUserShare.Text.ToLower) <> -1 Then
                    ListBoxMappings.Text += " " & AllTheMapping(i).TheGroup & " --> Mapps --> " & AllTheMapping(i).TheDrive.ToUpper & " ---> " & AllTheMapping(i).TheShare & vbCrLf
                End If
            Next
        ElseIf RadioButtonGroup.Checked Then
            For i As Integer = 0 To AllTheMapping.Length - 1
                If AllTheMapping(i).TheGroup.ToLower.IndexOf(TextBoxUserShare.Text.ToLower) <> -1 Then
                    ListBoxMappings.Text += " " & AllTheMapping(i).TheGroup & " --> Mapps --> " & AllTheMapping(i).TheDrive.ToUpper & " ---> " & AllTheMapping(i).TheShare & vbCrLf
                End If
            Next
        End If
    End Sub
    Private Sub WhichDrive_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReadMapper()
        If frmMainForm.tbxUserName.Text <> "" Then
            TextBoxUserShare.Text = frmMainForm.tbxUserName.Text
        End If
    End Sub
    Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
        Me.Close()
    End Sub
End Class