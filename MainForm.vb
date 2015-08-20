'Program written by Rick ardmore for the purpose of helping
'The IT tech support folk and engineers quickly find employees
'IP address, last PC they  logged into, remote controll the PC,
'Get database information out of ConfigMGR about the PC,
'reset Ad passwords, connect to PC functions such as manage this PC,
'Get logon history, unlock accounts and much much more
'This tool set allows level1 techs to make use of the common features in
'ConfigMGR and Active directory without having to know how to use either.
Imports System.Text
Imports System.Security.Cryptography
Imports System.Security.AccessControl
Imports System.IO
Imports System.Security
Imports System.Security.Principal
Imports System.DirectoryServices
Imports System.Management
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Win32

Public Class frmMainForm
    'List of people. Later I plan to check AD for this list
    Dim TechOps As String = "shoops,rick-,dshank,chetrick,schroedr,cbarrick,dustin,rice,benboyles"
    Dim TheADPGroup As String = ""
    Dim MeGroups() As String = Nothing
    Public tHEpROCmACHINE As String = ""
    Public TheSaltValue As String 'set in INI
    Public passIterations As Integer = 2
    Public TheinitialVector As String 'set in INI
    Public TheAESpassPhrase As String 'set in INI
    Public ThekeySize As Integer 'set in INI
    Public TheDomain As String 'set in INI
    Public TheDomainRoot As String 'set in INI
    Public LDAPBaseDN As String 'set in INI
    Public SMSServer As String 'set in INI
    Public SMSServerDB As String 'set in INI
    Public usrLogPath As String 'set in INI
    Public SMSDB As String 'set in INI
    Public usrLogonDB As String 'set in INI
    Public driveMapScriptLocation As String 'set in INI
    Public userLDAPPaths As List(Of String) = New List(Of String) 'set in INI
    Public computerLDAPPaths As List(Of String) = New List(Of String) 'set in INI
    Private Sub GetTheINIs()
        'read in all the INI values and assign them to their vars
        If Not File.Exists(IO.Directory.GetCurrentDirectory() & "\config.ini") Then
            MessageBox.Show("config.ini is missing.")
            Exit Sub
        End If
        Dim objFileReader As New StreamReader("config.ini")
        Dim TheTextLine() As String
        Do While objFileReader.Peek() <> -1
            Try
                TheTextLine = objFileReader.ReadLine().Split(Chr(9))
                If TheTextLine(0).ToLower = "thesaltvalue" Then
                    TheSaltValue = TheTextLine(1)
                End If
                If TheTextLine(0).ToLower = "theinitialvector" Then
                    TheinitialVector = TheTextLine(1)
                End If
                If TheTextLine(0).ToLower = "thekeysize" Then
                    ThekeySize = TheTextLine(1)
                End If
                If TheTextLine(0).ToLower = "theaespassphrase" Then
                    TheAESpassPhrase = TheTextLine(1)
                End If
                If TheTextLine(0).ToLower = "thedomain" Then
                    TheDomain = TheTextLine(1)
                End If
                If TheTextLine(0).ToLower = "thedomainroot" Then
                    TheDomainRoot = TheTextLine(1)
                End If
                If TheTextLine(0).ToLower = "ldapbasedn" Then
                    LDAPBaseDN = TheTextLine(1)
                End If
                If TheTextLine(0).ToLower = "smsserver" Then
                    SMSServer = TheTextLine(1)
                End If
                If TheTextLine(0).ToLower = "smsserverdb" Then
                    SMSServerDB = TheTextLine(1)
                End If
                If TheTextLine(0).ToLower = "usrlogpath" Then
                    usrLogPath = TheTextLine(1)
                End If
                If TheTextLine(0).ToLower = "smsdb" Then
                    SMSDB = TheTextLine(1)
                End If
                If TheTextLine(0).ToLower = "usrlogondb" Then
                    usrLogonDB = TheTextLine(1)
                End If
                If TheTextLine(0).ToLower = "drivemapscriptlocation" Then
                    driveMapScriptLocation = TheTextLine(1)
                End If
                If TheTextLine(0).ToLower = "acomputerldappath" Then
                    computerLDAPPaths.Add(TheTextLine(1))
                End If
                If TheTextLine(0).ToLower = "auserldappath" Then
                    userLDAPPaths.Add(TheTextLine(1))
                End If
            Catch ex As Exception
            End Try
        Loop
        objFileReader.Close()
    End Sub
    Public Sub UpdateADMainPGDB()
        'Clear all the forms and vars
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

            If tbxTitle.Text = "" Then
                MessageBox.Show("Please enter a title.")
                Exit Sub
            Else
                strtitle = tbxTitle.Text
            End If
            If tbxDept.Text = "" Then
                MessageBox.Show("Please enter a department.")
                Exit Sub
            Else
                strDept = tbxDept.Text
            End If
            If tbxOffice.Text = "" Then
                MessageBox.Show("Please enter an office.")
                Exit Sub
            Else
                strOfficeM = tbxOffice.Text
            End If
            If tbxCompany.Text = "" Then
                MessageBox.Show("Please enter a company.")
                Exit Sub
            Else
                strCompanyM = tbxCompany.Text
            End If
            If tbxAddress.Text = "" Then
                MessageBox.Show("Please enter an address.")
                Exit Sub
            Else
                strStreetM = tbxAddress.Text
            End If
            If tbxCity.Text = "" Then
                MessageBox.Show("Please enter a city.")
                Exit Sub
            Else
                strCityM = tbxCity.Text
            End If
            If cboState.Text = "" Then
                MessageBox.Show("Please enter a state.")
                Exit Sub
            Else
                strStateM = cboState.Text
            End If
            If tbxZip.Text = "" Then
                MessageBox.Show("Please enter a zip code.")
                Exit Sub
            Else
                strZipM = tbxZip.Text
            End If
            If tbxTel.Text = "" Then
                MessageBox.Show("Please enter a telephone number.")
                Exit Sub
            Else
                strTelM = tbxTel.Text
            End If
            If tbxFax.Text = "" Then
                MessageBox.Show("Please enter a fax number.")
                Exit Sub
            Else
                strFaxM = tbxFax.Text
            End If

            Dim auser As String = tbxUserName.Text
            Dim userLDAPpath As String
            Dim notFound As Boolean = True
            For Each userLDAPpath In userLDAPPaths
                Dim dirEntry As New DirectoryEntry("LDAP://" & userLDAPpath)
                dirEntry.Username = Nothing
                dirEntry.Password = Nothing
                dirEntry.AuthenticationType = AuthenticationTypes.Secure
                Dim dirSearcher As DirectorySearcher = New DirectorySearcher(dirEntry)
                dirSearcher.Filter = "(&(objectCategory=Person)(|(SAMAccountName=" & auser & ")(cn=" & auser & ")))"
                dirSearcher.SearchScope = SearchScope.Subtree
                Dim results As SearchResult = dirSearcher.FindOne()

                If Not results Is Nothing Then
                    notFound = False
                    Dim dirEntryResults As New DirectoryEntry(results.Path)
                    dirEntry.Username = Nothing
                    dirEntry.Password = Nothing
                    dirEntry.AuthenticationType = AuthenticationTypes.Secure
                    dirEntryResults.Properties("physicalDeliveryOfficeName").Value = strOfficeM
                    dirEntryResults.Properties("telephoneNumber").Value = strTelM
                    dirEntryResults.Properties("streetAddress").Value = strStreetM
                    dirEntryResults.Properties("l").Value = strCityM
                    dirEntryResults.Properties("st").Value = strStateM
                    dirEntryResults.Properties("postalCode").Value = strZipM
                    dirEntryResults.Properties("facsimileTelephoneNumber").Value = strFaxM
                    dirEntryResults.Properties("company").Value = strCompanyM
                    dirEntryResults.Properties("title").Value = strtitle
                    dirEntryResults.Properties("department").Value = strDept
                    If TextBoxCellPhone.Text <> "" Then
                        dirEntryResults.Properties("mobile").Value = TextBoxCellPhone.Text
                    End If
                    If TextBoxDiscription.Text <> "" Then
                        dirEntryResults.Properties("Description").Value = TextBoxDiscription.Text
                    End If
                    If dirEntryResults.SchemaClassName = "user" Then
                        If tbxProfilePath.Text <> "" Then
                            dirEntryResults.Properties("profilePath").Value = tbxProfilePath.Text
                        Else
                            dirEntryResults.Properties("profilePath").Clear()
                        End If
                    End If
                    dirEntryResults.CommitChanges()
                    dirEntryResults.Close()
                    MessageBox.Show("Success! " & auser & "'s info has been updated.")
                Else
                End If
                dirEntry.Close()
            Next
            If notFound Then
                MessageBox.Show("Error!" & vbCrLf & "Cannot locate this user.")
            End If
        Catch ex As Exception
            MessageBox.Show("Unfortunately you do not have permission to update one of the feilds.")
        End Try
    End Sub
    Public Shared Function BeDecrypted(ByVal cipherText As String, ByVal passPhrase As String, _
                                   ByVal saltyValue As String, ByVal hashAlgorithm As String, _
                                   ByVal passwordIterations As Integer, ByVal initVector As String, _
                                   ByVal keySize As Integer) As String
        'This function decrypts the EmployeeID feild in Active Directory. The company wanted to make sure no one could read the feild by browsing though active directory.
        Dim initVectorBytes As Byte()
        initVectorBytes = Encoding.ASCII.GetBytes(initVector)
        Dim saltyBytes As Byte()
        saltyBytes = Encoding.ASCII.GetBytes(saltyValue)
        Dim cipherTextBytes As Byte()
        cipherTextBytes = Convert.FromBase64String(cipherText)
        Dim Apassword As PasswordDeriveBytes
        Apassword = New PasswordDeriveBytes(passPhrase, saltyBytes, hashAlgorithm, passwordIterations)
        Dim keyBytes As Byte()
        keyBytes = Apassword.GetBytes(keySize / 8)
        Dim TheSymmetricAKAsingleKey As RijndaelManaged
        TheSymmetricAKAsingleKey = New RijndaelManaged()
        TheSymmetricAKAsingleKey.Mode = CipherMode.CBC
        Dim TheDecryptor As ICryptoTransform
        TheDecryptor = TheSymmetricAKAsingleKey.CreateDecryptor(keyBytes, initVectorBytes)
        Dim SomeMemoryStream As MemoryStream
        SomeMemoryStream = New MemoryStream(cipherTextBytes)
        Dim SomeCryptoStream As CryptoStream
        SomeCryptoStream = New CryptoStream(SomeMemoryStream, TheDecryptor, CryptoStreamMode.Read)
        Dim TheBitesOfPlainText As Byte()
        ReDim TheBitesOfPlainText(cipherTextBytes.Length)
        Dim decryptedByteCount As Integer
        decryptedByteCount = SomeCryptoStream.Read(TheBitesOfPlainText, 0, TheBitesOfPlainText.Length)
        SomeMemoryStream.Close()
        SomeCryptoStream.Close()
        Dim ThePlainText As String
        ThePlainText = Encoding.UTF8.GetString(TheBitesOfPlainText, 0, decryptedByteCount)
        BeDecrypted = ThePlainText
    End Function
    Public Shared Function BeEncrypted(ByVal plainText As String, ByVal passPhrase As String, _
                                   ByVal SaltyValue As String, ByVal hashAlgorithm As String, _
                                   ByVal passwordIterations As Integer, ByVal initVector As String, _
                                   ByVal keySize As Integer) As String
        'This function encrypts the EmployeeID feild in Active Directory. The company wanted to make sure no one could read the feild by browsing though active directory.
        Dim initVectorBytes As Byte()
        initVectorBytes = Encoding.ASCII.GetBytes(initVector)
        Dim SaltyBytes As Byte()
        SaltyBytes = Encoding.ASCII.GetBytes(SaltyValue)
        Dim plainTextBytes As Byte()
        plainTextBytes = Encoding.UTF8.GetBytes(plainText)
        Dim Apassword As PasswordDeriveBytes
        Apassword = New PasswordDeriveBytes(passPhrase, SaltyBytes, hashAlgorithm, passwordIterations)
        Dim keyBytes As Byte()
        keyBytes = Apassword.GetBytes(keySize / 8)
        Dim TheSymmetricAKAsingleKey As RijndaelManaged
        TheSymmetricAKAsingleKey = New RijndaelManaged()
        TheSymmetricAKAsingleKey.Mode = CipherMode.CBC
        Dim encryptor As ICryptoTransform
        encryptor = TheSymmetricAKAsingleKey.CreateEncryptor(keyBytes, initVectorBytes)
        Dim SomeMemoryStream As MemoryStream
        SomeMemoryStream = New MemoryStream()
        Dim SomeCryptoStream As CryptoStream
        SomeCryptoStream = New CryptoStream(SomeMemoryStream, encryptor, CryptoStreamMode.Write)
        SomeCryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
        SomeCryptoStream.FlushFinalBlock()
        Dim TextOcipher As Byte()
        TextOcipher = SomeMemoryStream.ToArray()
        SomeMemoryStream.Close()
        SomeCryptoStream.Close()
        Dim TheCipherText As String
        TheCipherText = Convert.ToBase64String(TextOcipher)
        BeEncrypted = TheCipherText
    End Function
    Public Sub GetADInfo()
        'This sub searches Ad for the username or partial username that is entered into the form.
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
            Dim expiredate As DateTime
            Dim vGroups As Array
            Dim UsersAccountStatus As Boolean
            Dim ImEnabledMa As Boolean
            If tbxUserName.Text = "" Then
                MessageBox.Show("Please enter a user first.")
                Exit Sub
            End If
            'Search ALL of domain (from base) if ur a sweet admin, else only search specified userLDAPpaths
            If GetCurrentUserGroups() Then
                Dim dirEntry As New DirectoryEntry("LDAP://" & LDAPBaseDN)
                Dim auser As String = tbxUserName.Text
                dirEntry.Username = Nothing
                dirEntry.Password = Nothing
                dirEntry.AuthenticationType = AuthenticationTypes.Secure
                Dim dirSearcher As DirectorySearcher = New DirectorySearcher(dirEntry)
                dirSearcher.Filter = "(&(objectCategory=Person)(|(SAMAccountName=" & auser & ")(cn=" & auser & ")))"
                dirSearcher.PropertiesToLoad.Add("createTimeStamp")
                dirSearcher.PropertiesToLoad.Add("modifyTimeStamp")
                dirSearcher.PropertiesToLoad.Add("canonicalName")
                dirSearcher.PropertiesToLoad.Add("pwdLastSet")
                dirSearcher.PropertiesToLoad.Add("description")
                dirSearcher.PropertiesToLoad.Add("info")
                dirSearcher.PropertiesToLoad.Add("adminDisplayName")
                dirSearcher.SearchScope = SearchScope.Subtree
                Dim results As SearchResult = dirSearcher.FindOne()
                If Not results Is Nothing Then
                    Dim dirEntryResults As New DirectoryEntry(results.Path)
                    dirEntryResults.Username = Nothing
                    dirEntryResults.Password = Nothing
                    dirEntryResults.AuthenticationType = AuthenticationTypes.Secure
                    tbxTitle.Text = dirEntryResults.Properties("title").Value
                    tbxDept.Text = dirEntryResults.Properties("department").Value
                    tbxOffice.Text = dirEntryResults.Properties("physicalDeliveryOfficeName").Value
                    tbxCompany.Text = dirEntryResults.Properties("company").Value
                    tbxAddress.Text = dirEntryResults.Properties("streetAddress").Value
                    tbxCity.Text = dirEntryResults.Properties("l").Value
                    cboState.Text = dirEntryResults.Properties("st").Value
                    tbxZip.Text = dirEntryResults.Properties("postalCode").Value
                    TextBoxCellPhone.Text = dirEntryResults.Properties("mobile").Value
                    tbxTel.Text = dirEntryResults.Properties("telephoneNumber").Value
                    If Not dirEntryResults.Properties("employeeNumber").Value Is Nothing Then
                        LabelADPID.Text = BeDecrypted(dirEntryResults.Properties("employeeNumber").Value, TheAESpassPhrase,
                            TheSaltValue, "SHA1", 2, TheinitialVector, ThekeySize)
                        LabelADPID.ForeColor = Color.Blue
                    Else
                        LabelADPID.Text = "Null"
                        LabelADPID.ForeColor = Color.Red
                    End If
                    Try
                        TextBoxADPName.Text = dirEntryResults.Properties("adminDisplayName").Value.ToString
                        TextBoxADPName.ForeColor = Color.Blue
                    Catch ex As Exception
                        TextBoxADPName.Text = "Null"
                        TextBoxADPName.ForeColor = Color.Red
                    End Try
                    Try
                        ImEnabledMa = Boolean.Parse(dirEntryResults.Properties("msRTCSIP-UserEnabled").Value.ToString)
                        If ImEnabledMa Then
                            LabelHasIM.Text = True
                            LabelHasIM.ForeColor = Color.Green
                        End If
                    Catch ex As Exception
                        LabelHasIM.Text = False
                        LabelHasIM.ForeColor = Color.Blue
                    End Try
                    tbxFax.Text = dirEntryResults.Properties("facsimileTelephoneNumber").Value
                    txtCreationDate.Text = Format(results.Properties("createTimeStamp")(0), "M-d-yy h:mm tt")
                    txtLastModified.Text = Format(results.Properties("modifyTimeStamp")(0), "M-d-yy h:mm tt")
                    txtDisplayName.Text = dirEntryResults.Properties("displayName").Value
                    LabelADPath.Text = results.Properties("canonicalName")(0)
                    LabelADPath.Text = LabelADPath.Text.Replace("/", "\").Replace(TheDomainRoot + "\", "")
                    lblObjType.Text = dirEntryResults.SchemaClassName
                    Try
                        TextBoxDiscription.Text = dirEntryResults.Properties("description").Value.ToString
                    Catch ex As Exception
                    End Try
                    If dirEntryResults.SchemaClassName = "user" Then
                        txtLocked.Text = dirEntryResults.InvokeGet("IsAccountLocked")
                        UsersAccountStatus = Boolean.Parse(dirEntryResults.InvokeGet("AccountDisabled"))
                        If UsersAccountStatus Then
                            LabelUserActStat.Text = "Account Disabled"
                            LabelUserActStat.ForeColor = Color.Red
                        Else
                            LabelUserActStat.Text = "Active"
                            LabelUserActStat.ForeColor = Color.Green
                        End If
                        If txtLocked.Text = "True" Then
                            txtLocked.ForeColor = Color.Red
                            txtLocked.Font = New Font(Label1.Font, FontStyle.Bold)
                        Else
                            txtLocked.ForeColor = Color.Green
                        End If
                        txtpwdlastset.Text = Format(DateTime.FromFileTime(results.Properties("pwdLastSet")(0)), "M-d-yy h:mm tt")
                        tbxProfilePath.Text = dirEntryResults.Properties("profilePath").Value
                        expiredate = Format(DateTime.FromFileTime(results.Properties("pwdLastSet")(0)), "M-d-yy h:mm tt")
                        txtPassExpire.Text = Format(expiredate.AddDays(90), "M-d-yy h:mm tt")
                    End If
                    Dim groupEntry As String
                    Dim groupEntryR As String
                    Dim groupEntryS As Array
                    cboMemberOf.Items.Clear()
                    If IsArray(dirEntryResults.InvokeGet("memberOf")) Then
                        vGroups = dirEntryResults.InvokeGet("memberOf")
                        If Not vGroups Is Nothing Then
                            For Each groupEntry In vGroups
                                groupEntryR = Mid(groupEntry, 4)
                                groupEntryS = Split(groupEntryR, ",")
                                cboMemberOf.Items.Add(groupEntryS(0))
                            Next
                        End If
                    End If
                    dirEntryResults.Close()
                Else
                    FoundUsers.Show()
                End If
                dirEntry.Close()
            Else
                Dim userLDAPpath As String
                Dim notFound As Boolean = True
                For Each userLDAPpath In userLDAPPaths
                    Dim dirEntry As New DirectoryEntry("LDAP://" & userLDAPpath)
                    Dim auser As String = tbxUserName.Text
                    dirEntry.Username = Nothing
                    dirEntry.Password = Nothing
                    dirEntry.AuthenticationType = AuthenticationTypes.Secure
                    Dim dirSearcher As DirectorySearcher = New DirectorySearcher(dirEntry)
                    dirSearcher.Filter = "(&(objectCategory=Person)(|(SAMAccountName=" & auser & ")(cn=" & auser & ")))"
                    dirSearcher.PropertiesToLoad.Add("createTimeStamp")
                    dirSearcher.PropertiesToLoad.Add("modifyTimeStamp")
                    dirSearcher.PropertiesToLoad.Add("canonicalName")
                    dirSearcher.PropertiesToLoad.Add("pwdLastSet")
                    dirSearcher.PropertiesToLoad.Add("description")
                    dirSearcher.PropertiesToLoad.Add("info")
                    dirSearcher.PropertiesToLoad.Add("adminDisplayName")
                    dirSearcher.SearchScope = SearchScope.Subtree
                    Dim results As SearchResult = dirSearcher.FindOne()
                    If Not results Is Nothing Then
                        notFound = False
                        Dim dirEntryResults As New DirectoryEntry(results.Path)
                        dirEntryResults.Username = Nothing
                        dirEntryResults.Password = Nothing
                        dirEntryResults.AuthenticationType = AuthenticationTypes.Secure
                        tbxTitle.Text = dirEntryResults.Properties("title").Value
                        tbxDept.Text = dirEntryResults.Properties("department").Value
                        tbxOffice.Text = dirEntryResults.Properties("physicalDeliveryOfficeName").Value
                        tbxCompany.Text = dirEntryResults.Properties("company").Value
                        tbxAddress.Text = dirEntryResults.Properties("streetAddress").Value
                        tbxCity.Text = dirEntryResults.Properties("l").Value
                        cboState.Text = dirEntryResults.Properties("st").Value
                        tbxZip.Text = dirEntryResults.Properties("postalCode").Value
                        TextBoxCellPhone.Text = dirEntryResults.Properties("mobile").Value
                        tbxTel.Text = dirEntryResults.Properties("telephoneNumber").Value
                        If Not dirEntryResults.Properties("employeeNumber").Value Is Nothing Then
                            LabelADPID.Text = BeDecrypted(dirEntryResults.Properties("employeeNumber").Value, TheAESpassPhrase,
                                TheSaltValue, "SHA1", 2, TheinitialVector, ThekeySize)
                            LabelADPID.ForeColor = Color.Blue
                        Else
                            LabelADPID.Text = "Null"
                            LabelADPID.ForeColor = Color.Red
                        End If
                        Try
                            TextBoxADPName.Text = dirEntryResults.Properties("adminDisplayName").Value.ToString
                            TextBoxADPName.ForeColor = Color.Blue
                        Catch ex As Exception
                            TextBoxADPName.Text = "Null"
                            TextBoxADPName.ForeColor = Color.Red
                        End Try
                        Try
                            ImEnabledMa = Boolean.Parse(dirEntryResults.Properties("msRTCSIP-UserEnabled").Value.ToString)
                            If ImEnabledMa Then
                                LabelHasIM.Text = True
                                LabelHasIM.ForeColor = Color.Green
                            End If
                        Catch ex As Exception
                            LabelHasIM.Text = False
                            LabelHasIM.ForeColor = Color.Blue
                        End Try
                        tbxFax.Text = dirEntryResults.Properties("facsimileTelephoneNumber").Value
                        txtCreationDate.Text = Format(results.Properties("createTimeStamp")(0), "M-d-yy h:mm tt")
                        txtLastModified.Text = Format(results.Properties("modifyTimeStamp")(0), "M-d-yy h:mm tt")
                        txtDisplayName.Text = dirEntryResults.Properties("displayName").Value
                        LabelADPath.Text = results.Properties("canonicalName")(0)
                        LabelADPath.Text = LabelADPath.Text.Replace("/", "\").Replace(TheDomainRoot + "\", "")
                        lblObjType.Text = dirEntryResults.SchemaClassName
                        Try
                            TextBoxDiscription.Text = dirEntryResults.Properties("description").Value.ToString
                        Catch ex As Exception
                        End Try
                        If dirEntryResults.SchemaClassName = "user" Then
                            txtLocked.Text = dirEntryResults.InvokeGet("IsAccountLocked")
                            UsersAccountStatus = Boolean.Parse(dirEntryResults.InvokeGet("AccountDisabled"))
                            If UsersAccountStatus Then
                                LabelUserActStat.Text = "Account Disabled"
                                LabelUserActStat.ForeColor = Color.Red
                            Else
                                LabelUserActStat.Text = "Active"
                                LabelUserActStat.ForeColor = Color.Green
                            End If
                            If txtLocked.Text = "True" Then
                                txtLocked.ForeColor = Color.Red
                                txtLocked.Font = New Font(Label1.Font, FontStyle.Bold)
                            Else
                                txtLocked.ForeColor = Color.Green
                            End If
                            txtpwdlastset.Text = Format(DateTime.FromFileTime(results.Properties("pwdLastSet")(0)), "M-d-yy h:mm tt")
                            tbxProfilePath.Text = dirEntryResults.Properties("profilePath").Value
                            expiredate = Format(DateTime.FromFileTime(results.Properties("pwdLastSet")(0)), "M-d-yy h:mm tt")
                            txtPassExpire.Text = Format(expiredate.AddDays(90), "M-d-yy h:mm tt")
                        End If
                        Dim groupEntry As String
                        Dim groupEntryR As String
                        Dim groupEntryS As Array
                        cboMemberOf.Items.Clear()
                        If IsArray(dirEntryResults.InvokeGet("memberOf")) Then
                            vGroups = dirEntryResults.InvokeGet("memberOf")
                            If Not vGroups Is Nothing Then
                                For Each groupEntry In vGroups
                                    groupEntryR = Mid(groupEntry, 4)
                                    groupEntryS = Split(groupEntryR, ",")
                                    cboMemberOf.Items.Add(groupEntryS(0))
                                Next
                            End If
                        End If
                        dirEntryResults.Close()
                    End If
                    dirEntry.Close()
                Next
                If notFound Then
                    FoundUsers.Show()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error - there was an exception.  Please report this bug to Rick or Dustin.")
        End Try
    End Sub
    Public Sub WhosLoggedIn(ByVal MachineName As String)
        'This sub connects to WMI on the target machine to respond with the presently logged on user account
        Try
            Dim myConnectionOptions As New System.Management.ConnectionOptions
            With myConnectionOptions
                .Impersonation = System.Management.ImpersonationLevel.Impersonate
                .Authentication = System.Management.AuthenticationLevel.Packet
            End With
            Dim myManagementScope As System.Management.ManagementScope
            Dim myServerName As String = MachineName
            myManagementScope = New System.Management.ManagementScope("\\" & myServerName & "\root\cimv2", myConnectionOptions)
            myManagementScope.Connect()
            If myManagementScope.IsConnected = False Then
                MsgBox("Error - could not connect.")
            End If
            Dim myObjectSearcher As System.Management.ManagementObjectSearcher
            Dim myObjectCollection As System.Management.ManagementObjectCollection
            Dim myObject As System.Management.ManagementObject
            myObjectSearcher = New System.Management.ManagementObjectSearcher(myManagementScope.Path.ToString, "SELECT UserName from Win32_ComputerSystem")
            myObjectCollection = myObjectSearcher.Get()
            Dim luser
            For Each myObject In myObjectCollection
                If Not myObject("UserName") Is Nothing Then
                    luser = myObject("UserName").ToString
                    MessageBox.Show(luser & " is currently logged in")
                Else
                    MessageBox.Show("No one is logged in")
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Problems Connecting to machine")
        End Try
    End Sub
    Public Sub GetADComputerInfo()
        'This sub searches Ad for the computer name or partial computer name that is entered into the form.
        dgvComputerList.Rows.Clear()
        Dim aComputer As String
        If tbxPlistCname.Text = "" Then
            MsgBox("Please enter a valid host.")
            Exit Sub
        End If
        aComputer = LCase(tbxPlistCname.Text)
        Dim count As Integer
        Dim dirEntry As New DirectoryEntry("LDAP://" & LDAPBaseDN)
        dirEntry.Username = Nothing
        dirEntry.Password = Nothing
        dirEntry.AuthenticationType = AuthenticationTypes.Secure
        Dim dirSearcher As DirectorySearcher
        Dim resultCollection As SearchResultCollection
        dirSearcher = New DirectorySearcher(dirEntry)
        dirSearcher.Filter = "(&(objectCategory=computer)(CN=" & aComputer & "))"
        dirSearcher.PropertiesToLoad.Add("canonicalName")
        dirSearcher.SearchScope = SearchScope.Subtree
        resultCollection = dirSearcher.FindAll()
        count = resultCollection.Count
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = count
        Dim row1 As String
        Dim row2 As String
        If count > 0 Then
            For i As Integer = 0 To count - 1 Step 1
                row1 = resultCollection(i).GetDirectoryEntry.Properties("CN").Value
                row2 = resultCollection(i).Properties("canonicalName")(0)
                dgvComputerList.Rows.Add(row1, row2)
                ProgressBar1.Value = i
            Next i
        Else
            MsgBox("Error - could not find specified host.")
        End If
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = 100
        dirEntry.Close()
    End Sub
    Public Sub GetADComputerInfo1()
        'This sub searches Ad for the computer name or partial computer name that is entered into the form.
        'This sub is just another variation of the other sub by the same name
        dgvComputerList.Rows.Clear()
        Dim count As Integer
        Dim dirEntry As New DirectoryEntry("LDAP://" & LDAPBaseDN)
        dirEntry.Username = Nothing
        dirEntry.Password = Nothing
        dirEntry.AuthenticationType = AuthenticationTypes.Secure
        Dim dirSearcher As DirectorySearcher
        Dim resultCollection As SearchResultCollection
        dirSearcher = New DirectorySearcher(dirEntry)
        dirSearcher.Filter = "(objectCategory=computer)"
        dirSearcher.PropertiesToLoad.Add("canonicalName")
        dirSearcher.PropertiesToLoad.Add("Lastlogon")
        dirSearcher.PropertiesToLoad.Add("LastlogontimeStamp")
        dirSearcher.SearchScope = SearchScope.Subtree
        resultCollection = dirSearcher.FindAll()
        count = resultCollection.Count
        txtCount.Text = count & " Computers in this domain"
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = count
        Dim row1 As String
        Dim row2 As String
        dgvComputerList.Rows.Clear()
        If count > 0 Then
            For i As Integer = 0 To count - 1 Step 1
                row1 = resultCollection(i).GetDirectoryEntry.Properties("CN").Value
                row2 = resultCollection(i).Properties("canonicalName")(0)
                dgvComputerList.Rows.Add(row1, row2)
                ProgressBar1.Value = i
                Me.Refresh()
            Next i
        End If
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = 100
        dirEntry.Close()
    End Sub
    Public Sub AddRemoveProgram(ByVal MachineName As String)
        ' This Sub connects to WMI on the specified computer and then reads in the add remove program list for that PC
        Dim myConnectionOptions As New System.Management.ConnectionOptions
        With myConnectionOptions
            .Impersonation = System.Management.ImpersonationLevel.Impersonate
            .Authentication = System.Management.AuthenticationLevel.Packet
        End With
        Dim myManagementScope As System.Management.ManagementScope
        Dim myServerName As String = MachineName
        myManagementScope = New System.Management.ManagementScope("\" & myServerName & "\root\cimv2", myConnectionOptions)
        myManagementScope.Connect()
        If myManagementScope.IsConnected = False Then
            MsgBox("Error - could not connect.")
        End If
        Dim myObjectSearcher As System.Management.ManagementObjectSearcher
        Dim myObjectCollection As System.Management.ManagementObjectCollection
        Dim myObject As System.Management.ManagementObject
        myObjectSearcher = New System.Management.ManagementObjectSearcher(myManagementScope.Path.ToString, "Select * From Win32_Product")
        myObjectCollection = myObjectSearcher.Get()
        For Each myObject In myObjectCollection
            Console.WriteLine(myObject.GetPropertyValue("Caption"))
        Next

    End Sub
    Public Sub Unlock()
        'This sub unlocks the specified user account in Active Directory
        Try
            If tbxUserName.Text = "" Then
                MessageBox.Show("Please enter a user first.")
                Exit Sub
            End If
            Dim auser As String = tbxUserName.Text
            Dim dirEntry As New DirectoryEntry("LDAP://" & LDAPBaseDN)
            dirEntry.Username = Nothing
            dirEntry.Password = Nothing
            dirEntry.AuthenticationType = AuthenticationTypes.Secure
            Dim dirSearcher As DirectorySearcher = New DirectorySearcher(dirEntry)
            dirSearcher.Filter = "(&(objectCategory=Person)(objectClass=user)(SAMAccountName=" & auser & "))"
            dirSearcher.SearchScope = SearchScope.Subtree
            Dim results As SearchResult = dirSearcher.FindOne()
            If Not results Is Nothing Then
                Dim dirEntryResults As New DirectoryEntry(results.Path)
                dirEntry.Username = Nothing
                dirEntry.Password = Nothing
                dirEntry.AuthenticationType = AuthenticationTypes.Secure
                dirEntryResults.InvokeSet("IsAccountLocked", False)
                dirEntryResults.CommitChanges()
                dirEntryResults.Close()
                MessageBox.Show("Success - user unlocked!")
            Else
                MessageBox.Show("Error - unable to locate specified user.")
            End If
            dirEntry.Close()
        Catch ex As Exception
            MessageBox.Show("Error - you do not have permission to unlock this user.")
        End Try
    End Sub
    Function MegroupsCheck(ByVal TheGroupToCheck As String)
        'Check what groups the user of this program belongs to
        For Each groupIgot As String In MeGroups
            Try
                If groupIgot.IndexOf(TheGroupToCheck) <> -1 Then
                    Return True
                    Exit Function
                End If
            Catch ex As Exception
            End Try
        Next
        Return False
    End Function
    Public Sub ClearExtraAccountInfo()
        'Clears the extra account info text fields on the main form
        txtLocked.Text = " "
        cboMemberOf.Items.Clear()
        txtCreationDate.Text = " "
        txtLastModified.Text = " "
        txtpwdlastset.Text = " "
        txtPassExpire.Text = " "
        lblObjType.Text = " "
        txtDisplayName.Text = " "
        LabelADPath.Text = " "
        LabelUserActStat.Text = " "
        LabelHasIM.Text = " "
        LabelADPID.Text = " "
        TextBoxADPName.Text = " "
        If MegroupsCheck("canupdateempid") = True Then
            ButtonUpdateADP.Visible = True
            ButtonClearADP.Visible = True
        End If
    End Sub
    Private Sub psexecKey()
        'This program makes use of PSexec. This sub eliminates the first time popups when it is used on a new PC
        Dim PSexecRegKey As RegistryKey
        Dim strPsexecRegKey As String = "HKEY_CURRENT_USER\Software\Sysinternals\PsExec"
        PSexecRegKey = Registry.CurrentUser.OpenSubKey("Software\Sysinternals\PsExec", True)
        If PSexecRegKey Is Nothing Then
            My.Computer.Registry.SetValue(strPsexecRegKey, "EulaAccepted", "1", Microsoft.Win32.RegistryValueKind.DWord)
        End If
    End Sub
    Sub PsexecExist()
        'Let's make sure PSexec exists on the local PC and put it there if it doesnt
        Try
            Dim FileDestination As String = "c:\windows\system32\psexec.exe"
            Dim FileSource As String = "\\ccmfs\msipub$\Icons\psexec.exe"
            If System.IO.File.Exists(FileDestination) = False Then
                System.IO.File.Copy(FileSource, FileDestination, True)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MakeDisableWallpaperBatch()
        'This sub creates a batch file that hides the walpaper on the remote PC, which improves the remote control performance.
        Try
            Dim BatchFile1 As String = "c:\windows\DisableWallpaper.bat"
            Dim ObjFileSystem As New IO.StreamWriter(BatchFile1, False)
            ObjFileSystem.Write("reg add " & Chr(34) & "hkcu\control panel\desktop" & Chr(34) & " /v wallpaper /t REG_SZ /d " & Chr(34) & Chr(34) & " /f " & vbCrLf)
            ObjFileSystem.Write("RUNDLL32.EXE user32.dll,UpdatePerUserSystemParameters")
            ObjFileSystem.Close()
            Dim BatchFile2 As String = "c:\windows\launchNotePad.bat"
            Dim ObjFileSystem2 As New IO.StreamWriter(BatchFile2, False)
            ObjFileSystem2.Write("start /max notepad")
            ObjFileSystem2.Close()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GetADComputerInfoByDate()
        'This sub loads a list of PC's in the domain who have not checked in With AD over a date that you select.
        dgvComputerList.Rows.Clear()
        Dim count As Integer
        Dim dirEntry As New DirectoryEntry("LDAP://" & LDAPBaseDN)
        dirEntry.Username = Nothing
        dirEntry.Password = Nothing
        dirEntry.AuthenticationType = AuthenticationTypes.Secure
        Dim dirSearcher As DirectorySearcher
        Dim resultCollection As SearchResultCollection
        dirSearcher = New DirectorySearcher(dirEntry)
        dirSearcher.Filter = "(objectCategory=computer)"
        dirSearcher.PropertiesToLoad.Add("canonicalName")
        dirSearcher.SearchScope = SearchScope.Subtree
        resultCollection = dirSearcher.FindAll()
        count = resultCollection.Count
        txtCount.Text = count & " Computers in this domain"
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = count
        Dim row1 As String
        Dim row2 As String
        dgvComputerList.Rows.Clear()
        If count > 0 Then
            For i As Integer = 0 To count - 1 Step 1
                row1 = resultCollection(i).GetDirectoryEntry.Properties("CN").Value
                row2 = resultCollection(i).Properties("canonicalName")(0)
                dgvComputerList.Rows.Add(row1, row2)
                ProgressBar1.Value = i
            Next i
        End If
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = 100
        dirEntry.Close()
    End Sub
    Public Sub ResetPass()
        'This sub resets the Ad Pass of the selected user and even includes a neat password generator
        Try
            Dim newpass As String = "12345678"
            If resetchk.txtNewPass.Text = "" Then
                MessageBox.Show("Please enter a password.")
                Exit Sub
            Else
                newpass = resetchk.txtNewPass.Text
            End If
            If tbxUserName.Text = "" Then
                MessageBox.Show("Please enter a user first.")
                Exit Sub
            End If
            Dim auser As String = tbxUserName.Text
            Dim notFound As Boolean = True
            Dim userLDAPpath As String
            For Each userLDAPpath In userLDAPPaths
                Dim dirEntry As New DirectoryEntry("LDAP://" & userLDAPpath)
                dirEntry.Username = Nothing
                dirEntry.Password = Nothing
                dirEntry.AuthenticationType = AuthenticationTypes.Secure
                Dim dirSearcher As DirectorySearcher = New DirectorySearcher(dirEntry)
                dirSearcher.Filter = "(&(objectCategory=Person)(objectClass=user)(SAMAccountName=" & auser & "))"
                dirSearcher.SearchScope = SearchScope.Subtree
                Dim results As SearchResult = dirSearcher.FindOne()
                If Not results Is Nothing Then
                    notFound = False
                    Dim dirEntryResults As New DirectoryEntry(results.Path)
                    dirEntry.Username = Nothing
                    dirEntry.Password = Nothing
                    dirEntry.AuthenticationType = AuthenticationTypes.Secure
                    dirEntryResults.Invoke("SetPassword", newpass)
                    If newpass = "12345678" Then
                        dirEntryResults.Properties("pwdLastSet").Value = "0"
                    End If
                    dirEntryResults.CommitChanges()
                    dirEntryResults.Close()
                    If newpass = "12345678" Then
                        MessageBox.Show("The password for " & auser & vbCrLf & "has been reset to " & newpass & vbCrLf & auser & " will be required to change it at next logon.")
                    Else
                        MessageBox.Show("The password for " & auser & vbCrLf & "has been reset to " & newpass)
                    End If
                End If
                dirEntry.Close()
            Next

            If notFound Then
                MessageBox.Show("Error - unable to locate specified user.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error - you do not have permission to reset this user's password.")
        End Try
    End Sub
    Function GetCurrentUserGroups()
        'This sub enumerates the active directory group membership of the person using the program
        Try
            Dim MySelf As String = System.Environment.UserName.ToString
            Dim ADPath As String = "LDAP://" + LDAPBaseDN
            Dim dirEntry As New DirectoryEntry(ADPath)
            dirEntry.Username = Nothing
            dirEntry.Password = Nothing
            dirEntry.AuthenticationType = AuthenticationTypes.Secure
            Dim dirSearcher As DirectorySearcher = New DirectorySearcher(dirEntry)
            dirSearcher.Filter = "(&(objectCategory=Person)(objectClass=user)(SAMAccountName=" & MySelf & "))"
            dirSearcher.SearchScope = SearchScope.Subtree
            Dim results As SearchResult = dirSearcher.FindOne()
            If Not results Is Nothing Then
                Dim DirectoryEntryTheGroup As New DirectoryEntry(results.Path)
                DirectoryEntryTheGroup.Username = Nothing
                DirectoryEntryTheGroup.Password = Nothing
                DirectoryEntryTheGroup.AuthenticationType = AuthenticationTypes.Secure
                For Each group As String In DirectoryEntryTheGroup.Properties("memberOf").Value
                    If group.ToLower.IndexOf("domain admins") <> -1 Or _
                    group.ToLower.IndexOf("canresetitpass") <> -1 Then
                        Return True
                        DirectoryEntryTheGroup.Close()
                        Exit Function
                    End If
                Next
                DirectoryEntryTheGroup.Close()
                Return False
            Else
                Return False
            End If
            dirEntry.Close()
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXit.Click
        Me.Close()
    End Sub
    Sub ClearAllFeilds()
        'Quick sub to clear all the txt and forms on the main form
        tbxTitle.Text = ""
        tbxDept.Text = ""
        tbxOffice.Text = ""
        tbxCompany.Text = ""
        tbxAddress.Text = ""
        tbxCity.Text = ""
        cboState.Text = ""
        tbxZip.Text = ""
        tbxTel.Text = ""
        tbxFax.Text = ""
        TextBoxDiscription.Text = ""
        tbxProfilePath.Text = ""
        TextBoxCellPhone.Text = ""
        TextBoxADPName.Text = ""
        LabelADPID.Text = ""
        ClearExtraAccountInfo()
    End Sub
    Private Sub tbxUserName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Run these when opened
        GetTheINIs()
        PsexecExist()
        ChkForNewVersions()
        CheckMeGroups()
        ClearExtraAccountInfo()
        psexecKey()
        MakeDisableWallpaperBatch()
        If ((File.Exists("C:\Program Files\Microsoft\Exchange Server\bin\exshell.psc1") = True) And _
           (MegroupsCheck("domain admins") = True)) Then
            MailboxSize.Visible = True
        End If
        Me.Refresh()
    End Sub
    Sub CheckMeGroups()
        'Check what groups I belong to
        Try
            Dim MySelf As String = System.Environment.UserName.ToString
            Dim ADPath As String = "LDAP://" + LDAPBaseDN
            Dim dirEntry As New DirectoryEntry(ADPath)
            dirEntry.Username = Nothing
            dirEntry.Password = Nothing
            dirEntry.AuthenticationType = AuthenticationTypes.Secure
            Dim dirSearcher As DirectorySearcher = New DirectorySearcher(dirEntry)
            dirSearcher.Filter = "(&(objectCategory=Person)(objectClass=user)(SAMAccountName=" & MySelf & "))"
            dirSearcher.SearchScope = SearchScope.Subtree
            Dim results As SearchResult = dirSearcher.FindOne()
            If Not results Is Nothing Then
                Dim DirectoryEntryTheGroup As New DirectoryEntry(results.Path)
                DirectoryEntryTheGroup.Username = Nothing
                DirectoryEntryTheGroup.Password = Nothing
                DirectoryEntryTheGroup.AuthenticationType = AuthenticationTypes.Secure
                Dim MeGroupsIndexCount As Integer = 1
                For Each group As String In DirectoryEntryTheGroup.Properties("memberOf").Value
                    If MeGroups Is Nothing Then
                        ReDim MeGroups(1)
                        MeGroups(0) = group.ToLower.ToString
                        Continue For
                    End If
                    ReDim Preserve MeGroups(MeGroupsIndexCount + 1)
                    MeGroups(MeGroupsIndexCount) = group.ToLower.ToString
                    MeGroupsIndexCount += 1
                    If MeGroupsIndexCount > 6 Then
                        MeGroupsIndexCount = MeGroupsIndexCount
                    End If
                Next
                DirectoryEntryTheGroup.Close()
            Else
            End If
            dirEntry.Close()
        Catch ex As Exception
        End Try
    End Sub
    Sub ChkForNewVersions()
        'Checks a central share to see if I've created a new version. I plan to create an auto updater in the future.
        'THIS NEEDS TO BE UPDATED TO SUPPORT NON-CCM DOMAINS...
        'Or i guess we could give Jim and Ed permission to this share or create a specific one.  We'll see.
        Dim ThisProgram As String = ""
        Dim ThatProgram As String = ""
        Try
            ThisProgram = System.Diagnostics.FileVersionInfo.GetVersionInfo("SyntecADUserEditor.exe").ProductVersion
            ThatProgram = System.Diagnostics.FileVersionInfo.GetVersionInfo("\\ccmfs\software$\CCMUserEditor\SyntecADUserEditor.exe").ProductVersion
            If ThisProgram < ThatProgram Then
                NewVersionInfo.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        UpdateADMainPGDB()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetInfo.Click
        ClearAllFeilds()
        GetADInfo()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        resetchk.Show()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ClearAllFeilds()
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Unlock()
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Uinfo.Show()
    End Sub
    Private Sub btnListC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListC.Click
        GetADComputerInfo1()
    End Sub
    Private Sub DataGridView1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvComputerList.CellContentClick
        Dim ppart
        ppart = dgvComputerList.SelectedRows(0).Index.ToString
        tbxPlistCname.Text = dgvComputerList.Rows(ppart).Cells(0).Value
        Me.Refresh()
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub TabPage2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Enter
    End Sub
    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindComputer.Click
        GetADComputerInfo()
    End Sub
    Private Sub Button4_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If LastLoggedOnCoputer.Visible Then
            LastLoggedOnCoputer.Close()
        End If
        LastLoggedOnCoputer.Show()
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If RControl.Visible Then
            RControl.Close()
        End If
        RControl.Show()
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Shadow.Show()
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        popup.Show()
    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If tbxPlistCname.Text = "" Then
            MessageBox.Show("Please enter a valid host.")
        Else
            tHEpROCmACHINE = tbxPlistCname.Text
            ProcList.Show()
        End If
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        If tbxPlistCname.Text = "" Then
            MessageBox.Show("Please enter a valid host.")
        Else
            AddRemoveP.Show()
        End If
    End Sub
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        If tbxPlistCname.Text = "" Then
            MessageBox.Show("Please enter a valid host.")
        Else
            WhosLoggedIn(tbxPlistCname.Text)
        End If
    End Sub
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If tbxPlistCname.Text = "" Then
            MessageBox.Show("Please enter a valid host.")
        Else
            System.Diagnostics.Process.Start("ping", " " & tbxPlistCname.Text & " -t")
        End If
    End Sub
    Private Sub btnShowUserHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowUserHistory.Click
        If LogonHistory.Visible Then
            LogonHistory.BringToFront()
            LogonHistory.Focus()
        End If
        LogonHistory.Show()
    End Sub
    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim DevmgrProcess As Process = New Process()
        ' DevmgrProcess.StartInfo.FileName = "psexec"
        ' DevmgrProcess.StartInfo.Arguments = " \\" & tbxElComputerNamo.Text & _
        '   " -i 0 -d -u  -p  rundll32 devmgr.dll DeviceManager_Execute Device Manager /il"
        'DevmgrProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        ' If tbxElComputerNamo.Text = "" Then
        'MessageBox.Show("A computer name would really help here")
        ' Else
        ' DevmgrProcess.Start()
        ' Do Until DevmgrProcess.HasExited = True
        ' Loop
        ' MessageBox.Show("DeviceManager Launched")
        '  End If
    End Sub
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub TabPage3_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        psexecKey()
    End Sub
    Private Sub dgvComputerList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvComputerList.SelectionChanged
        Dim ppart
        ppart = dgvComputerList.SelectedRows(0).Index.ToString
        tbxPlistCname.Text = dgvComputerList.Rows(ppart).Cells(0).Value
        Me.Refresh()
    End Sub
    Private Sub ButtonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFind.Click
        If tbxUserName.Text = "" Then
            Dim box As MsgBoxResult = MsgBox("Are you sure you want to search AD for ALL users?  This could take a really long time and you won't be able to close the search until complete.", MsgBoxStyle.YesNo)
            If box = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        FoundUsers.Show()
    End Sub
    Private Sub Button18_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        MakeFolders.Show()
    End Sub
    Private Sub ButtonWwwDenied_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWwwDenied.Click
        'This will need to be made multi-domain compatible!
        Dim ThisUsersName As String
        ThisUsersName = Environment.UserName.ToLower
        If TechOps.IndexOf(ThisUsersName) = -1 Then
            MessageBox.Show("Please ask a member of Techops to complete this for you. Thanks.")
            Exit Sub
        End If
        If TextBoxWwwDenied.Text = "" Then
            MessageBox.Show("Please enter a domain name")
            Exit Sub
        Else
            Me.Cursor = Cursors.WaitCursor
            Dim VBPopProcess As Process = New Process()
            VBPopProcess.StartInfo.FileName = "psexec.exe"
            VBPopProcess.StartInfo.Arguments = " \\isa3.ccm.local -u  -p  cscript c:\windows\domainadd.vbs " & TextBoxWwwDenied.Text & " " & ThisUsersName
            VBPopProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            VBPopProcess.Start()
            VBPopProcess.WaitForExit()
            MessageBox.Show("Complete")
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub TabPage4_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage4.Enter
        psexecKey()
    End Sub
    Private Sub ButtonDomain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDomain.Click
        'This will need to be made multi-domain compatible!
        Dim ThisUsersName As String
        ThisUsersName = Environment.UserName.ToLower
        If TechOps.IndexOf(ThisUsersName) = -1 Then
            MessageBox.Show("Please ask a member of Techops to complete this for you. Thanks.")
            Exit Sub
        End If
        If TextBoxFreeDomain.Text = "" Then
            MessageBox.Show("Please enter a domain name")
            Exit Sub
        Else
            Me.Cursor = Cursors.WaitCursor
            Dim VBPopProcess As Process = New Process()
            VBPopProcess.StartInfo.FileName = "psexec.exe"
            VBPopProcess.StartInfo.Arguments = " \\isa3.ccm.local -u  -p  cscript c:\windows\freesiteDomainadd.vbs " & TextBoxFreeDomain.Text & " " & ThisUsersName
            VBPopProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            VBPopProcess.Start()
            VBPopProcess.WaitForExit()
            MessageBox.Show("Complete")
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub ButtonURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonURL.Click
        'This will need to be made multi-domain compatible!
        Dim ThisUsersName As String
        ThisUsersName = Environment.UserName.ToLower
        If TechOps.IndexOf(ThisUsersName) = -1 Then
            MessageBox.Show("Please ask a member of Techops to complete this for you. Thanks.")
            Exit Sub
        End If
        If TextBoxFreeURL.Text = "" Then
            MessageBox.Show("Please enter a URL")
            Exit Sub
        Else
            Me.Cursor = Cursors.WaitCursor
            Dim VBPopProcess As Process = New Process()
            VBPopProcess.StartInfo.FileName = "psexec.exe"
            VBPopProcess.StartInfo.Arguments = " \\isa3.ccm.local -u  -p  cscript c:\windows\freesitesURLAdd.vbs " & TextBoxFreeURL.Text & " " & ThisUsersName
            VBPopProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            VBPopProcess.Start()
            VBPopProcess.WaitForExit()
            MessageBox.Show("Complete")
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub Button15_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        WhichDrive.Show()
    End Sub
    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        FindSoftware.Show()
    End Sub
    Private Sub ButtonURLlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonURLlist.Click
        'This will need to be made multi-domain compatible!
        Dim ThisUsersName As String
        ThisUsersName = Environment.UserName.ToLower
        If TechOps.IndexOf(ThisUsersName) = -1 Then
            MessageBox.Show("Please ask a member of Techops to complete this for you. Thanks.")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim VBPopProcess As Process = New Process()
        VBPopProcess.StartInfo.FileName = "psexec.exe"
        'cscript c:\windows\ListFreeSitesURL.vbs > c:\windows\urllist.txt
        VBPopProcess.StartInfo.Arguments = _
        " \\isa3.ccm.local -u  -p  cscript c:\windows\ListFreeSitesURL.vbs"
        VBPopProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        VBPopProcess.Start()
        VBPopProcess.WaitForExit()
        Me.Cursor = Cursors.Default
        Dim path As String = "\\isa3\c$\windows\urllist.txt"
        Dim AllTheUrl As String = ""
        Dim TheNextLine As String = ""
        Try
            Dim objReader As New StreamReader(path)
            Do While objReader.Peek() <> -1
                TheNextLine = objReader.ReadLine() & vbCrLf
                'If TheNextLine.IndexOf("Windows Script Host Version") = -1 Or TheNextLine.IndexOf("All rights reserved") = -1 Then
                AllTheUrl += TheNextLine
                'End If
            Loop
            objReader.Close()
        Catch ex As Exception
        End Try
        AllUrl.Show()
        AllUrl.TextBoxUrlList.Text = AllTheUrl
    End Sub
    Private Sub Button17_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        'This will need to be made multi-domain compatible!
        Dim ThisUsersName As String
        ThisUsersName = Environment.UserName.ToLower
        If TechOps.IndexOf(ThisUsersName) = -1 Then
            MessageBox.Show("Please ask a member of Techops to complete this for you. Thanks.")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim VBPopProcess As Process = New Process()
        VBPopProcess.StartInfo.FileName = "psexec.exe"
        'cscript c:\windows\ListFreeSitesURL.vbs > c:\windows\urllist.txt
        VBPopProcess.StartInfo.Arguments = _
        " \\isa3.ccm.local -u  -p  cscript c:\windows\ListFreeSitesDomains.vbs"
        VBPopProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        VBPopProcess.Start()
        VBPopProcess.WaitForExit()
        Me.Cursor = Cursors.Default
        Dim path As String = "\\isa3\c$\windows\Domainlist.txt"
        Dim AllTheUrl As String = ""
        Dim TheNextLine As String = ""
        Try
            Dim objReader As New StreamReader(path)
            Do While objReader.Peek() <> -1
                TheNextLine = objReader.ReadLine() & vbCrLf
                'If TheNextLine.IndexOf("Windows Script Host Version") = -1 Or TheNextLine.IndexOf("All rights reserved") = -1 Then
                AllTheUrl += TheNextLine
                'End If
            Loop
            objReader.Close()
        Catch ex As Exception
        End Try
        AllUrl.Show()
        AllUrl.TextBoxUrlList.Text = AllTheUrl
    End Sub
    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        'This will need to be made multi-domain compatible!
        Dim ThisUsersName As String
        ThisUsersName = Environment.UserName.ToLower
        If TechOps.IndexOf(ThisUsersName) = -1 Then
            MessageBox.Show("Please ask a member of Techops to complete this for you. Thanks.")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim VBPopProcess As Process = New Process()
        VBPopProcess.StartInfo.FileName = "psexec.exe"
        'cscript c:\windows\ListFreeSitesURL.vbs > c:\windows\urllist.txt
        VBPopProcess.StartInfo.Arguments = _
        " \\isa3.ccm.local -u  -p  cscript c:\windows\ListDeniedExceptions.vbs"
        VBPopProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        VBPopProcess.Start()
        VBPopProcess.WaitForExit()
        Me.Cursor = Cursors.Default
        Dim path As String = "\\isa3\c$\windows\Deniedlist.txt"
        Dim AllTheUrl As String = ""
        Dim TheNextLine As String = ""
        Try
            Dim objReader As New StreamReader(path)
            Do While objReader.Peek() <> -1
                TheNextLine = objReader.ReadLine() & vbCrLf
                'If TheNextLine.IndexOf("Windows Script Host Version") = -1 Or TheNextLine.IndexOf("All rights reserved") = -1 Then
                AllTheUrl += TheNextLine
                'End If
            Loop
            objReader.Close()
        Catch ex As Exception
        End Try
        AllUrl.Show()
        AllUrl.TextBoxUrlList.Text = AllTheUrl
    End Sub
    Private Sub ButtonRCMD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRCMD.Click
        If tbxPlistCname.Text = "" Then
            MessageBox.Show("Please select a computer to R-CMD")
            Exit Sub
        End If
        Dim RCMD As Process = New Process()
        RCMD.StartInfo.FileName = "psexec"
        RCMD.StartInfo.Arguments = " \\" & tbxPlistCname.Text & " cmd.exe"
        RCMD.StartInfo.WindowStyle = ProcessWindowStyle.Normal
        RCMD.Start()
    End Sub
    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        CCMPopUp.Visible = True
    End Sub
    Private Sub ButtonUpdateADP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdateADP.Click
        'Update the ADP values for the selected employee
        Try
            If tbxUserName.Text = "" Then
                MessageBox.Show("Please enter a user first.")
                Exit Sub
            End If
            If TextBoxADPName.Text = "Null" And LabelADPID.Text = "Null" Then
                MessageBox.Show("Both ADP Name and ADP ID values cannot be null, please complete at least one and try again.")
                Exit Sub
            End If
            Dim auser As String = tbxUserName.Text
            Dim dirEntry As New DirectoryEntry("LDAP://" + LDAPBaseDN)
            dirEntry.Username = Nothing
            dirEntry.Password = Nothing
            dirEntry.AuthenticationType = AuthenticationTypes.Secure
            Dim dirSearcher As DirectorySearcher = New DirectorySearcher(dirEntry)
            dirSearcher.Filter = "(&(objectCategory=Person)(SAMAccountName=" & auser & "))"
            dirSearcher.SearchScope = SearchScope.Subtree
            Dim results As SearchResult = dirSearcher.FindOne()
            If Not results Is Nothing Then
                Dim dirEntryResults As New DirectoryEntry(results.Path)
                dirEntryResults.Username = Nothing
                dirEntryResults.Password = Nothing
                dirEntryResults.AuthenticationType = AuthenticationTypes.Secure
                If (LabelADPID.Text <> "") And (LabelADPID.Text <> "Null") Then
                    dirEntryResults.Properties("employeeNumber").Value = BeEncrypted(LabelADPID.Text, TheAESpassPhrase,
                        TheSaltValue, "SHA1", 2, TheinitialVector, ThekeySize)
                End If
                If TextBoxADPName.Text <> "" And TextBoxADPName.Text <> "Null" Then
                    dirEntryResults.Properties("adminDisplayName").Value = TextBoxADPName.Text
                End If
                dirEntryResults.CommitChanges()
            End If
            dirEntry.Close()
            MsgBox("ADP info successfully updated.")
        Catch ex As Exception
            MessageBox.Show("Error while Updating. And the error was:" & vbCrLf & ex.Message)
        End Try
        GetADInfo()
    End Sub
    Private Sub GetMailboxSize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MailboxSize.Click
        'Gets the size of the selected users mailbox
        If tbxUserName.Text = "" Then
            MessageBox.Show("Please enter a user first.")
            Exit Sub
        End If
        Dim GetMailBoxSizeProcess As Process = New Process()
        GetMailBoxSizeProcess.StartInfo.FileName = "C:\WINDOWS\system32\windowspowershell\v1.0\powershell.exe"
        GetMailBoxSizeProcess.StartInfo.Arguments = "-PSConsoleFile " & Chr(34) _
        & "C:\Program Files\Microsoft\Exchange Server\bin\exshell.psc1" & Chr(34) _
        & " -noExit -command " & Chr(34) & ". Get-MailboxStatistics " & tbxUserName.Text & _
        " | ft StorageLimitStatus, @{expression={$_.TotalItemSize.Value.ToKB()}}" & Chr(34)
        GetMailBoxSizeProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
        GetMailBoxSizeProcess.Start()
    End Sub
    Private Sub ButtonClearADP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearADP.Click
        'Update the ADP values for the selected employee
        Try
            If tbxUserName.Text = "" Then
                MessageBox.Show("Please enter a user first.")
                Exit Sub
            End If
            Dim box As MsgBoxResult = MsgBox("Are you sure you want to clear this user's ADP ID and ADP Name?", MsgBoxStyle.YesNo)
            If box = MsgBoxResult.No Then
                Exit Sub
            End If
            Dim auser As String = tbxUserName.Text
            Dim dirEntry As New DirectoryEntry("LDAP://" + LDAPBaseDN)
            dirEntry.Username = Nothing
            dirEntry.Password = Nothing
            dirEntry.AuthenticationType = AuthenticationTypes.Secure
            Dim dirSearcher As DirectorySearcher = New DirectorySearcher(dirEntry)
            dirSearcher.Filter = "(&(objectCategory=Person)(SAMAccountName=" & auser & "))"
            dirSearcher.SearchScope = SearchScope.Subtree
            Dim results As SearchResult = dirSearcher.FindOne()
            If Not results Is Nothing Then
                Dim dirEntryResults As New DirectoryEntry(results.Path)
                dirEntryResults.Username = Nothing
                dirEntryResults.Password = Nothing
                dirEntryResults.AuthenticationType = AuthenticationTypes.Secure
                dirEntryResults.Properties("adminDisplayName").Clear()
                dirEntryResults.Properties("employeeNumber").Clear()
                dirEntryResults.CommitChanges()
            End If
            dirEntry.Close()
            MsgBox("Success")
        Catch ex As Exception
            MessageBox.Show("Error while Updating. And the error was:" & vbCrLf & ex.Message)
        End Try
        GetADInfo()
    End Sub
End Class