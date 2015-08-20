Imports System.Data
Imports System.Data.SqlClient
'This is one of the most heavily used forms in this program.
'It allows you to select a user and quickly see what PC they are logged into and all the information about that PC
'Such as auto starting programs, installed software
'It also lets you perform many management tasks such as remote control the PC, jump to it's C drive, task manager, ping, etc.
Public Class LastLoggedOnCoputer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Sub InventoryThePC()
        Try
            Dim strSQLConn As String = "data source=" & frmMainForm.SMSServerDB & "; " & "initial catalog=" & frmMainForm.SMSDB & "; " & "integrated security=true;"
            If tbxComputers.Text = "" Then
                ClearMoreInfo()
                Exit Sub
            Else
                Dim SMSSQLconn As New SqlConnection(strSQLConn)
                SMSSQLconn.Open()
                Dim username As String = ""
                Dim computername As String = tbxComputers.Text
                Dim MySQLCommand As String = "Select System_DISC.Operating_System_name_and0, v_GS_OPERATING_SYSTEM.Name0, vMacAddresses.MacAddresses, " & _
                                            "v_RA_System_SystemOUName.System_OU_Name0, Operating_System_DATA.TotalVisibleMemorySize00, " & _
                                            "v_GS_LOGICAL_DISK.FreeSpace0, v_GS_LOGICAL_DISK.Size0,v_GS_PROCESSOR.Name0 as Processor, " & _
                                            "v_GS_WORKSTATION_STATUS.LastHWScan, v_GS_PC_BIOS.Manufacturer0, v_GS_PC_BIOS.SerialNumber0, " & _
                                            "v_GS_PC_BIOS.SMBIOSBIOSVersion0, v_GS_SYSTEM_ENCLOSURE.ChassisTypes0, v_GS_COMPUTER_SYSTEM.Model0, " & _
                                            "v_GS_COMPUTER_SYSTEM.CurrentTimeZone0, System_DISC.User_Name0, Operating_System_DATA.InstallDate0, " & _
                                            "v_GS_OPERATING_SYSTEM.CSDVersion0 " & _
                                            "From System_DISC " & _
                                            "Inner join vMacAddresses on System_DISC.ItemKey = vMacAddresses.ItemKey " & _
                                            "Inner join v_GS_OPERATING_SYSTEM on System_DISC.ItemKey = v_GS_OPERATING_SYSTEM.ResourceID " & _
                                            "Inner join v_RA_System_SystemOUName on System_DISC.ItemKey = v_RA_System_SystemOUName.ResourceID " & _
                                            "Inner join Operating_System_DATA on System_DISC.ItemKey = Operating_System_DATA.MachineID " & _
                                            "Inner join v_GS_LOGICAL_DISK on System_DISC.ItemKey = v_GS_LOGICAL_DISK.ResourceID " & _
                                            "Inner join v_GS_PROCESSOR on System_DISC.ItemKey = v_GS_PROCESSOR.ResourceID " & _
                                            "Inner join v_GS_WORKSTATION_STATUS on System_DISC.ItemKey =v_GS_WORKSTATION_STATUS.ResourceID " & _
                                            "Inner join v_GS_PC_BIOS on System_DISC.ItemKey = v_GS_PC_BIOS.ResourceID " & _
                                            "Inner join v_GS_SYSTEM_ENCLOSURE on System_DISC.ItemKey = v_GS_SYSTEM_ENCLOSURE.ResourceID " & _
                                            "Inner join v_GS_COMPUTER_SYSTEM on System_DISC.ItemKey = v_GS_COMPUTER_SYSTEM.ResourceID " & _
                                            "Where System_DISC.Netbios_name0 = '" & computername & "' and v_GS_LOGICAL_DISK.Name0 = 'C:'"
                Dim MySQLIPCommand As String = "Select System_DISC.Operating_System_name_and0, vMacAddresses.MacAddresses, Network_DATA.IPAddress0 " & _
                                                "From System_DISC " & _
                                                "Inner join vMacAddresses on System_DISC.ItemKey = vMacAddresses.ItemKey " & _
                                                "Inner Join Network_DATA on System_DISC.ItemKey =Network_DATA.machineID " & _
                                                "Where System_DISC.Netbios_name0 = '" & computername & "' and Network_DATA.IPAddress0 IS NOT NULL and not Network_DATA.IPAddress0 = '0.0.0.0'"
                Dim sqlComm As New SqlCommand(MySQLCommand, SMSSQLconn)
                Dim MySQLreader As SqlDataReader = sqlComm.ExecuteReader()
                Dim ServPack As String = ""
                While MySQLreader.Read()
                    If MySQLreader("CSDVersion0").ToString <> "" Then
                        ServPack = " + " & MySQLreader("CSDVersion0").ToString.Replace("Service Pack ", "SP")
                    End If
                    LabelPCName.Text = computername & ": This info last collected on --> " & MySQLreader("LastHWScan").ToString
                    LabelOSType.Text = MySQLreader("Name0").ToString & " " & ServPack
                    If LabelOSType.Text.IndexOf("|") <> -1 Then
                        Try
                            Dim OSSplit() As String
                            OSSplit = LabelOSType.Text.Split("|")
                            LabelOSType.Text = OSSplit(0).Replace("Microsoft", "") & " " & ServPack
                        Catch ex As Exception
                        End Try
                    End If
                    LabelADPath.Text = MySQLreader("System_OU_Name0").ToString
                    LabelRAM.Text = Long.Parse(MySQLreader("TotalVisibleMemorySize00")).ToString("#,###") & " MB"
                    LabelProcessor.Text = MySQLreader("Processor").ToString.Replace("(R)", "").Replace("(TM)", "").Trim
                    LabelHardDrive.Text = "Total = " & Long.Parse(MySQLreader("Size0")).ToString("#,###") & " MB" & _
                                        "   Free = " & Long.Parse(MySQLreader("FreeSpace0")).ToString("#,###") & " MB"
                    LabelMACs.Text = MySQLreader("MacAddresses").ToString.Replace(";", " ; ")
                    LabelServiceTag.Text = MySQLreader("SerialNumber0").ToString
                    LabelManufacturer.Text = MySQLreader("Manufacturer0").ToString
                    LabelBIOSV.Text = MySQLreader("SMBIOSBIOSVersion0").ToString
                    LabelModel.Text = MySQLreader("Model0").ToString
                    LabelTimeZone.Text = MySQLreader("CurrentTimeZone0").ToString
                    LabelLastUsedBy.Text = MySQLreader("User_Name0").ToString
                    LabelImagedDate.Text = MySQLreader("InstallDate0").ToString
                    LabelPCType.Text = GetPCType(Integer.Parse(MySQLreader("ChassisTypes0").ToString))
                End While
                MySQLreader.Close()
                Dim sqlComm2 As New SqlCommand(MySQLIPCommand, SMSSQLconn)
                Dim MySQLreader2 As SqlDataReader = sqlComm2.ExecuteReader()
                Dim IPString As String = ""
                While MySQLreader2.Read()
                    IPString += MySQLreader2("IPAddress0").ToString & " - "
                End While
                LabelIP.Text = IPString
                MySQLreader2.Close()
            End If
        Catch ex As Exception
            ClearMoreInfo()
        End Try
    End Sub
    Function GetPCType(ByVal TheType As Integer)
        Select Case TheType
            Case 3
                Return "Desktop"
            Case 4
                Return "Low Profile Desktop"
            Case 5
                Return "Pizza Box"
            Case 6
                Return "Mini Tower"
            Case 7
                Return "Tower"
            Case 8
                Return "Portable"
            Case 9
                Return "Laptop"
            Case 10
                Return "Notebook"
            Case 11
                Return "Hand Held"
            Case 12
                Return "Notebook"
            Case 13
                Return "All in One"
            Case 14
                Return "Sub Notebook"
            Case 15
                Return "Space-Saving"
            Case 16
                Return "Lunch Box"
            Case 17
                Return "Main System Chassis"
            Case 18
                Return "Expansion Chassis"
            Case 19
                Return "SubChassis"
            Case 20
                Return "Bus Expansion Chassis"
            Case 21
                Return "Peripheral Chassis"
            Case 22
                Return "Storage Chassis"
            Case 23
                Return "Rack Mount Chassis"
            Case 24
                Return "Sealed-Case PC"
            Case Else
                Return "Not Classified"
        End Select
    End Function
    Sub RecentProgramInventory()
        Try
            Dim strSQLConn As String = "data source=" & frmMainForm.SMSServerDB & "; " & "initial catalog=" & frmMainForm.SMSDB & "; " & "integrated security=true;"
            If tbxComputers.Text = "" Then
                ClearMoreInfo()
                Exit Sub
            Else
                Dim SMSSQLconn As New SqlConnection(strSQLConn)
                SMSSQLconn.Open()
                Dim username As String = ""
                Dim computername As String = tbxComputers.Text
                Dim MySQLCommand As String = "Select System_DISC.Operating_System_name_and0, v_GS_CCM_RECENTLY_USED_APPS.ExplorerFileName0, v_GS_CCM_RECENTLY_USED_APPS.LastUsedTime0 " & _
                                            "From System_DISC " & _
                                            "Inner join v_GS_CCM_RECENTLY_USED_APPS on System_DISC.ItemKey = v_GS_CCM_RECENTLY_USED_APPS.ResourceID " & _
                                            "Where System_DISC.Netbios_name0 = '" & computername & "' " & _
                                            "Order by ExplorerFileName0 Asc"
                Dim sqlComm As New SqlCommand(MySQLCommand, SMSSQLconn)
                Dim MySQLreader As SqlDataReader = sqlComm.ExecuteReader()
                While MySQLreader.Read()
                    Try
                        Dim DisplayName As String = ""
                        Dim installDate As String = ""
                        If MySQLreader("ExplorerFileName0") Is DBNull.Value Then
                            DisplayName = " "
                        Else
                            DisplayName = MySQLreader("ExplorerFileName0").ToString
                        End If
                        If MySQLreader("LastUsedTime0") Is DBNull.Value Then
                            installDate = " "
                        Else
                            installDate = MySQLreader("LastUsedTime0").ToString
                        End If
                        DataGridViewRecentPrograms.Rows.Add(DisplayName, installDate)
                    Catch ex As Exception
                    End Try
                End While
                MySQLreader.Close()
            End If
        Catch ex As Exception
            ClearMoreInfo()
        End Try
    End Sub
    Sub InvetoryServices()
        Try
            Dim strSQLConn As String = "data source=" & frmMainForm.SMSServerDB & "; " & "initial catalog=" & frmMainForm.SMSDB & "; " & "integrated security=true;"
            If tbxComputers.Text = "" Then
                ClearMoreInfo()
                Exit Sub
            Else
                Dim SMSSQLconn As New SqlConnection(strSQLConn)
                SMSSQLconn.Open()
                Dim username As String = ""
                Dim computername As String = tbxComputers.Text
                Dim MySQLCommand As String = "Select System_DISC.Operating_System_name_and0, Services_DATA.DisplayName0, Services_DATA.StartMode0 " & _
                                            "From System_DISC " & _
                                            "Inner join Services_DATA on System_DISC.ItemKey = Services_DATA.MachineID " & _
                                            "Where System_DISC.Netbios_name0 = '" & computername & "' " & _
                                            "Order by DisplayName0 Asc"
                Dim sqlComm As New SqlCommand(MySQLCommand, SMSSQLconn)
                Dim MySQLreader As SqlDataReader = sqlComm.ExecuteReader()
                While MySQLreader.Read()
                    Try
                        Dim DisplayName As String = ""
                        Dim installDate As String = ""
                        If MySQLreader("DisplayName0") Is DBNull.Value Then
                            DisplayName = " "
                        Else
                            DisplayName = MySQLreader("DisplayName0").ToString
                        End If
                        If MySQLreader("StartMode0") Is DBNull.Value Then
                            installDate = " "
                        Else
                            installDate = MySQLreader("StartMode0").ToString
                        End If
                        DataGridViewServices.Rows.Add(DisplayName, installDate)
                    Catch ex As Exception
                    End Try
                End While
                MySQLreader.Close()
            End If
        Catch ex As Exception
            ClearMoreInfo()
        End Try
    End Sub
    Sub InventoryAddRemove()
        Dim redListPresent As Boolean = False
        If redListPresent = False Then
            LabelRedList.Visible = False
        End If
        Dim theRedstring As String = ""
        Dim theGreenString As String = ""
        Try
            Dim strSQLConn As String = "data source=" & frmMainForm.SMSServerDB & "; " & "initial catalog=" & frmMainForm.SMSDB & "; " & "integrated security=true;"
            If tbxComputers.Text = "" Then
                ClearMoreInfo()
                Exit Sub
            Else
                Dim SMSSQLconn As New SqlConnection(strSQLConn)
                SMSSQLconn.Open()
                Dim username As String = ""
                Dim computername As String = tbxComputers.Text
                Dim MySQLCommand As String = "Select distinct System_DISC.Operating_System_name_and0, v_Add_Remove_Programs.DisplayName0, v_Add_Remove_Programs.InstallDate0 " & _
                                            "From System_DISC " & _
                                            "Inner join v_Add_Remove_Programs on System_DISC.ItemKey = v_Add_Remove_Programs.ResourceID " & _
                                            "Where System_DISC.Netbios_name0 = '" & computername & "' " & _
                                            "Order by DisplayName0 Asc"
                If CheckBoxFilterPatches.Checked Then
                    MySQLCommand = "Select distinct System_DISC.Operating_System_name_and0, v_Add_Remove_Programs.DisplayName0, v_Add_Remove_Programs.InstallDate0 " & _
                                    "From System_DISC " & _
                                    "Inner join v_Add_Remove_Programs on System_DISC.ItemKey = v_Add_Remove_Programs.ResourceID " & _
                                    "Where System_DISC.Netbios_name0 = '" & computername & "' " & _
                                    "and DisplayName0 Not like '%Hotfix%' " & _
                                    "and DisplayName0 Not like '%Security Update%' " & _
                                    "and DisplayName0 Not like 'Update for%' " & _
                                    "and DisplayName0 Not like '%SP1%' " & _
                                    "and DisplayName0 Not like '%SP2%' " & _
                                    "and DisplayName0 Not like '%SP3%' " & _
                                    "and DisplayName0 Not like '%(KB%' " & _
                                    "and DisplayName0 Not like '%Service Pack%' " & _
                                    "Order by DisplayName0 Asc"
                End If
                Dim sqlComm As New SqlCommand(MySQLCommand, SMSSQLconn)
                Dim MySQLreader As SqlDataReader = sqlComm.ExecuteReader()
                While MySQLreader.Read()
                    Try
                        Dim DisplayName As String = ""
                        Dim installDate As String = ""
                        If MySQLreader("DisplayName0") Is DBNull.Value Then
                            Continue While
                        Else
                            DisplayName = MySQLreader("DisplayName0").ToString
                        End If
                        If MySQLreader("InstallDate0") Is DBNull.Value Then
                            installDate = " "
                        Else
                            installDate = MySQLreader("InstallDate0").ToString
                            installDate = installDate.Insert(4, "-").Insert(7, "-")
                        End If
                        DataGridViewADDRemove.Rows.Add(DisplayName, installDate)
                    Catch ex As Exception
                    End Try
                End While
                MySQLreader.Close()
                SMSSQLconn.Close()
                Dim strSQLConn2 As String = "data source=" & frmMainForm.SMSServerDB & "; " & "initial catalog=" & frmMainForm.usrLogonDB & "; " & "integrated security=true;"
                Dim SMSSQLconn2 As New SqlConnection(strSQLConn2)
                SMSSQLconn2.Open()
                Dim redCommand As String = "select * from TheRedList"
                sqlComm = New SqlCommand(redCommand, SMSSQLconn2)
                MySQLreader = sqlComm.ExecuteReader()
                While MySQLreader.Read()
                    theRedstring += MySQLreader("RedList").ToString & ","
                End While
                MySQLreader.Close()
                Dim theRedAry() As String = theRedstring.Split(",")
                Dim GreenCommand As String = "select * from TheGreenTable"
                sqlComm = New SqlCommand(GreenCommand, SMSSQLconn2)
                MySQLreader = sqlComm.ExecuteReader()
                While MySQLreader.Read()
                    theGreenString += MySQLreader("GreenList").ToString & ","
                End While
                MySQLreader.Close()
                SMSSQLconn2.Close()
                Dim theGreenAry() As String = theGreenString.Split(",")
                For RowCount As Integer = 0 To DataGridViewADDRemove.Rows.Count - 1
                    Dim ProgramNamString As DataGridViewCell = DataGridViewADDRemove.Rows(RowCount).Cells(0)
                    If Not ProgramNamString.Value Is Nothing Then
                        If Not ProgramNamString.Value Is DBNull.Value Then
                            For Each RedString As String In theRedAry
                                If RedString <> "" Then
                                    If ProgramNamString.Value.ToString.ToLower.IndexOf(RedString.ToLower) <> -1 Then
                                        DataGridViewADDRemove.Rows(RowCount).DefaultCellStyle.BackColor = Color.Red
                                        redListPresent = True
                                    End If
                                End If
                            Next
                            For Each GreenString As String In theGreenAry
                                If GreenString <> "" Then
                                    If ProgramNamString.Value.ToString.ToLower.IndexOf(GreenString.ToLower) <> -1 Then
                                        DataGridViewADDRemove.Rows(RowCount).DefaultCellStyle.ForeColor = Color.Green
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            ClearMoreInfo()
        End Try
        If redListPresent Then
            LabelRedList.Visible = True
        End If
    End Sub
    Sub DeploymentHistory()
        Try
            Dim strSQLConn As String = "data source=" & frmMainForm.SMSServerDB & "; " & "initial catalog=" & frmMainForm.SMSDB & "; " & "integrated security=true;"
            If tbxComputers.Text = "" Then
                ClearMoreInfo()
                Exit Sub
            Else
                Dim SMSSQLconn As New SqlConnection(strSQLConn)
                SMSSQLconn.Open()
                Dim username As String = ""
                Dim computername As String = tbxComputers.Text
                Dim MySQLCommand As String = "SELECT v_Package.Name, v_ClientAdvertisementStatus.LastStatusmessageIDName, v_ClientAdvertisementStatus.LastStatusTime, v_ClientAdvertisementStatus.LastExecutionResult  " & _
                                            "From v_Advertisement " & _
                                            "INNER JOIN v_Package ON v_Advertisement.PackageID = v_Package.PackageID " & _
                                            "INNER JOIN v_ClientAdvertisementStatus on v_Advertisement.AdvertisementID = v_ClientAdvertisementStatus.AdvertisementID " & _
                                            "INNER JOIN V_R_SYSTEM ON V_R_SYSTEM.Resourceid = v_ClientAdvertisementStatus.resourceid " & _
                                            "INNER JOIN v_GS_WORKSTATION_STATUS ON V_R_SYSTEM.resourceid = v_GS_WORKSTATION_STATUS.resourceid " & _
                                            "LEFT OUTER JOIN v_RA_System_SMSInstalledSites site ON V_R_SYSTEM.resourceid = site.resourceid  " & _
                                            "where V_R_SYSTEM.Netbios_name0 = '" & computername & "' " & _
                                            "order by v_Package.Name"
                Dim sqlComm As New SqlCommand(MySQLCommand, SMSSQLconn)
                Dim MySQLreader As SqlDataReader = sqlComm.ExecuteReader()
                While MySQLreader.Read()
                    Try
                        Dim PackageName As String = ""
                        Dim PackageStatus As String = ""
                        Dim installDate As String = ""
                        Dim PackageResult As String = ""
                        If MySQLreader("Name") Is DBNull.Value Then
                            PackageName = " "
                        Else
                            PackageName = MySQLreader("Name").ToString
                        End If
                        If MySQLreader("LastStatusmessageIDName") Is DBNull.Value Then
                            PackageStatus = " "
                        Else
                            PackageStatus = MySQLreader("LastStatusmessageIDName").ToString
                        End If
                        If MySQLreader("LastStatusTime") Is DBNull.Value Then
                            installDate = " "
                        Else
                            installDate = MySQLreader("LastStatusTime").ToString
                            installDate = installDate.Replace("/", "-")
                        End If
                        If MySQLreader("LastExecutionResult") Is DBNull.Value Then
                            PackageResult = "Null"
                        Else
                            PackageResult = MySQLreader("LastExecutionResult").ToString
                        End If
                        DataGridViewDeployment.Rows.Add(PackageName, PackageStatus, installDate, PackageResult)
                    Catch ex As Exception
                    End Try
                End While
                MySQLreader.Close()
            End If
        Catch ex As Exception
            ClearMoreInfo()
        End Try
    End Sub
    Sub AutoStartInventory()
        Try
            Dim strSQLConn As String = "data source=" & frmMainForm.SMSServerDB & "; " & "initial catalog=" & frmMainForm.SMSDB & "; " & "integrated security=true;"
            If tbxComputers.Text = "" Then
                ClearMoreInfo()
                Exit Sub
            Else
                Dim SMSSQLconn As New SqlConnection(strSQLConn)
                SMSSQLconn.Open()
                Dim username As String = ""
                Dim computername As String = tbxComputers.Text
                Dim MySQLCommand As String = "Select System_DISC.Operating_System_name_and0, v_GS_AUTOSTART_SOFTWARE.FileName0, v_GS_AUTOSTART_SOFTWARE.StartupValue0 " & _
                                            "From System_DISC " & _
                                            "Inner join v_GS_AUTOSTART_SOFTWARE on System_DISC.ItemKey = v_GS_AUTOSTART_SOFTWARE.ResourceID " & _
                                            "Where System_DISC.Netbios_name0 = '" & computername & "' " & _
                                            "Order by FileName0 Asc"
                Dim sqlComm As New SqlCommand(MySQLCommand, SMSSQLconn)
                Dim MySQLreader As SqlDataReader = sqlComm.ExecuteReader()
                While MySQLreader.Read()
                    Try
                        Dim DisplayName As String = ""
                        Dim installDate As String = ""
                        If MySQLreader("FileName0") Is DBNull.Value Then
                            DisplayName = " "
                        Else
                            DisplayName = MySQLreader("FileName0").ToString
                        End If
                        If MySQLreader("StartupValue0") Is DBNull.Value Then
                            installDate = " "
                        Else
                            installDate = MySQLreader("StartupValue0").ToString
                        End If
                        DataGridViewAutoStart.Rows.Add(DisplayName, installDate)
                    Catch ex As Exception
                    End Try
                End While
                MySQLreader.Close()
            End If
        Catch ex As Exception
            ClearMoreInfo()
        End Try
    End Sub
    Sub ClearMoreInfo()
        LabelPCName.Text = "No Valid PC Selected"
        LabelOSType.Text = ""
        LabelOSType.Text = ""
        LabelADPath.Text = ""
        LabelProcessor.Text = ""
        LabelHardDrive.Text = ""
        LabelMACs.Text = ""
        LabelIP.Text = ""
        LabelRAM.Text = ""
        LabelServiceTag.Text = ""
        LabelManufacturer.Text = ""
        LabelBIOSV.Text = ""
        LabelModel.Text = ""
        LabelTimeZone.Text = ""
        LabelLastUsedBy.Text = ""
        LabelImagedDate.Text = ""
        LabelPCType.Text = ""
        DataGridViewADDRemove.Rows.Clear()
        DataGridViewAutoStart.Rows.Clear()
        DataGridViewRecentPrograms.Rows.Clear()
        DataGridViewServices.Rows.Clear()
        DataGridViewUserInventory.Rows.Clear()
        DataGridViewDeployment.Rows.Clear()
    End Sub
    Public Sub getComputerNameByUser()
        Try
            Dim strSQLConn As String = "data source=" & frmMainForm.SMSServerDB & "; " & "initial catalog=" & frmMainForm.SMSDB & "; " & "integrated security=true;"
            If frmMainForm.tbxUserName.Text = "" Then
                tbxUsername.Text = "Please enter a user first."
                Exit Sub
            Else
                Dim SMSSQLconn As New SqlConnection(strSQLConn)
                SMSSQLconn.Open()
                Dim username As String = ""
                Dim computername As String = ""
                Dim sqlComm As New SqlCommand("select all SMS_R_System.User_Name0,SMS_R_System.Netbios_Name0 from System_DISC AS SMS_R_System  where SMS_R_System.User_Name0 = '" & frmMainForm.tbxUserName.Text & "'", SMSSQLconn)
                Dim r As SqlDataReader = sqlComm.ExecuteReader()
                While r.Read()
                    username = CStr(r("User_Name0"))
                    computername = CStr(r("Netbios_Name0"))
                    tbxComputers.Items.Add(computername)
                End While
                r.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Unfortunately you do not have appropriate permissions to perform this function.")
        End Try
    End Sub
    Sub UserInventory()
        Try
            Dim strSQLConn As String = "data source=" & frmMainForm.SMSServerDB & "; " & "initial catalog=" & frmMainForm.usrLogonDB & "; " & "integrated security=true;"
            Dim SMSSQLconn As New SqlConnection(strSQLConn)
            SMSSQLconn.Open()
            Dim MySQLCommand As String = "Select TheUsers.TheUserName, EventType, EventTime, IP, TheDC " & _
                                         "From LogonTable " & _
                                         "Inner Join TheUsers on LogonTable.FK_UserID = TheUsers.UserID " & _
                                         "Where PCName = '" & tbxComputers.Text & "' " & _
                                         "Order by EventTime Desc"
            Dim sqlComm As New SqlCommand(MySQLCommand, SMSSQLconn)
            Dim MySQLreader As SqlDataReader = sqlComm.ExecuteReader()
            While MySQLreader.Read()
                Dim TheEventType As String = MySQLreader("EventType")
                If TheEventType = True Then
                    TheEventType = "LogON"
                Else
                    TheEventType = "LogOFF"
                End If
                Dim TheIP As String = MySQLreader("IP").ToString.Replace("0.0.0.0", " ").Replace("/", " ").Trim
                DataGridViewUserInventory.Rows.Add(MySQLreader("TheUserName").ToString.Trim, TheEventType, _
                                                   DateTime.Parse(MySQLreader("EventTime").ToString.Trim).ToString("MM-dd-yy h:mm tt"), _
                                                   TheIP, MySQLreader("TheDC").ToString.Trim)
            End While
            MySQLreader.Close()
            SMSSQLconn.Close()
        Catch ex As Exception
        End Try
    End Sub
    Sub MakeSmall()
        Me.Height = 438
        Me.Width = 349
    End Sub
    Sub MakeBig()
        Me.Height = 438
        Me.Width = 980
    End Sub
    Sub InventoryLoad()
        ClearMoreInfo()
        InventoryThePC()
        InventoryAddRemove()
        InvetoryServices()
        RecentProgramInventory()
        AutoStartInventory()
        UserInventory()
        DeploymentHistory()
    End Sub
    Public Sub getComputerNameByUser1()
        Try
            Dim strSQLConn As String = "data source=" & frmMainForm.SMSServerDB & "; " & "initial catalog=" & frmMainForm.SMSDB & "; " & "integrated security=true;"
            If tbxUsername.Text = "" Then
                MessageBox.Show("Please enter a user first.")
                Exit Sub
            Else
                Dim SMSSQLconn As New SqlConnection(strSQLConn)
                SMSSQLconn.Open()
                Dim username As String = ""
                Dim computername As String = ""
                Dim sqlComm As New SqlCommand("select all SMS_R_System.User_Name0,SMS_R_System.Netbios_Name0 from System_DISC AS SMS_R_System  where SMS_R_System.User_Name0 = '" & tbxUsername.Text & "'", SMSSQLconn)
                Dim r As SqlDataReader = sqlComm.ExecuteReader()
                While r.Read()
                    username = CStr(r("User_Name0"))
                    computername = CStr(r("Netbios_Name0"))
                    tbxComputers.Items.Add(computername)
                End While
                r.Close()
            End If
        Catch ex As Exception
            MsgBox("I'm having problems with this machine or user, please double check your options.")
        End Try
    End Sub
    Private Sub LastLoggedOnCoputer_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MakeSmall()
        tbxUsername.Text = frmMainForm.tbxUserName.Text
        getComputerNameByUser()
        If tbxComputers.Items.Count = 0 Then
            tbxComputers.Items.Add("Sorry no results - try all users history")
            tbxComputers.Items.Add("Maybe this user was not")
            tbxComputers.Items.Add("the last logged on user")
            tbxComputers.Items.Add("of any computer")
        End If
        If tbxComputers.Items.Item(0) <> "Sorry no results - try all users history" Then
            tbxComputers.SelectedIndex = 0
            tbxComputers.Text = tbxComputers.Items.Item(0)
        End If
    End Sub
    Private Sub ButtonMore_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMore.Click
        If ButtonMore.Text = "More >>" Then
            ButtonMore.Text = "<< Less"
            MakeBig()
            InventoryLoad()
        Else
            ButtonMore.Text = "More >>"
            MakeSmall()
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If tbxComputers.Text = "" Then
            MessageBox.Show("Please select a computer first.")
            Exit Sub
        End If
        frmMainForm.WhosLoggedIn(tbxComputers.Text)
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If tbxComputers.Text = "" Then
            MessageBox.Show("Please select a computer first.")
            Exit Sub
        End If
        Dim TheCDrive As Process = New Process()
        TheCDrive.StartInfo.FileName = "Explorer.exe"
        TheCDrive.StartInfo.Arguments = " \\" & tbxComputers.Text & "\c$"
        TheCDrive.StartInfo.WindowStyle = ProcessWindowStyle.Normal
        TheCDrive.Start()
    End Sub
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        tbxComputers.Items.Clear()
        getComputerNameByUser1()
        If tbxComputers.Items.Count = 0 Then
            tbxComputers.Items.Add("Sorry no results - try all users history")
            tbxComputers.Items.Add("Maybe this user was not")
            tbxComputers.Items.Add("the last logged on user")
            tbxComputers.Items.Add("of any computer")
        End If
        If tbxComputers.Items.Count = 1 Then
            tbxComputers.SelectedIndex = 0
        End If
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If tbxComputers.Text = "" Then
            MessageBox.Show("Please select a computer first.")
            Exit Sub
        End If
        Dim ThePinger As Process = New Process()
        ThePinger.StartInfo.FileName = "ping.exe"
        ThePinger.StartInfo.Arguments = " " & tbxComputers.Text & " -t"
        ThePinger.StartInfo.WindowStyle = ProcessWindowStyle.Normal
        ThePinger.Start()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If tbxComputers.Text = "" Then
            MessageBox.Show("Please select a computer first.")
            Exit Sub
        End If
        Dim ManageComputer As Process = New Process()
        ManageComputer.StartInfo.FileName = "compmgmt.msc"
        ManageComputer.StartInfo.Arguments = "  /computer=\\" & tbxComputers.Text
        ManageComputer.StartInfo.WindowStyle = ProcessWindowStyle.Normal
        ManageComputer.Start()
    End Sub
    Private Sub Shadow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Shadow.Click
        Dim ppart
        If tbxComputers.SelectedItem = "" Then
            MsgBox("Please select a computer first.")
        Else
            ppart = tbxComputers.Text
            System.Diagnostics.Process.Start("shadow", " Console /server:" & ppart)
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If CheckBoxDisableWallpaper.Checked Then
            Dim KillWallPaper As Process = New Process()
            KillWallPaper.StartInfo.FileName = "psexec.exe"
            KillWallPaper.StartInfo.Arguments = " \\" & tbxComputers.SelectedItem & "  -i -c c:\windows\disablewallpaper.bat"
            KillWallPaper.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            KillWallPaper.Start()
        End If
        If CheckBoxFullNotepad.Checked Then
            Dim KillWallPaper As Process = New Process()
            KillWallPaper.StartInfo.FileName = "psexec.exe"
            KillWallPaper.StartInfo.Arguments = " \\" & tbxComputers.SelectedItem & "  -i -c c:\WINDOWS\launchNotePad.bat"
            KillWallPaper.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            KillWallPaper.Start()
        End If
        If tbxComputers.Text = "" Then
            MsgBox("Please select a computer first.")
        Else
            Try
               System.Diagnostics.Process.Start("rc.exe", " 1 " & tbxComputers.Text & " \\" & frmMainForm.SMSServer & "\")
            Catch ex As Exception
                MsgBox("I'm having problems with this machine or user, please double check your options.")
            End Try
        End If
    End Sub
    Private Sub tbxComputers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxComputers.SelectedIndexChanged
        If ButtonMore.Text = "<< Less" Then
            InventoryLoad()
        End If
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If tbxComputers.Text = "" Then
            MessageBox.Show("Please select a computer first.")
        Else
            Me.Cursor = Cursors.WaitCursor
            frmMainForm.tHEpROCmACHINE = tbxComputers.Text
            ProcList.Show()
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If tbxComputers.Text = "" Then
            MessageBox.Show("Please select a computer first.")
            Exit Sub
        End If
        Dim RCMD As Process = New Process()
        RCMD.StartInfo.FileName = "psexec"
        RCMD.StartInfo.Arguments = " \\" & tbxComputers.Text & " cmd.exe"
        RCMD.StartInfo.WindowStyle = ProcessWindowStyle.Normal
        RCMD.Start()
    End Sub
    Private Sub CheckBoxFilterPatches_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxFilterPatches.CheckedChanged
        DataGridViewADDRemove.Rows.Clear()
        InventoryAddRemove()
    End Sub
    Private Sub DataGridViewUserInventory_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridViewUserInventory.MouseUp
        Try
            If e.Button = MouseButtons.Right Then
                Dim MyhitTestInfo As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
                If MyhitTestInfo.Type = DataGridViewHitTestType.Cell Then
                    DataGridViewUserInventory.CurrentCell = DataGridViewUserInventory.Item(MyhitTestInfo.ColumnIndex, MyhitTestInfo.RowIndex)
                End If
                ContextMenuStripUserInventory.Show(DataGridViewUserInventory, New Point(e.X, e.Y))
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            Clipboard.SetDataObject(DataGridViewUserInventory.CurrentCell.Value.ToString)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CopyToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem1.Click
        Try
            Clipboard.SetDataObject(LabelIP.Text)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CopyToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem2.Click
        Try
            Clipboard.SetDataObject(LabelMACs.Text)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CopyToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem3.Click
        Try
            Clipboard.SetDataObject(LabelServiceTag.Text)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CopyToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem4.Click
        Try
            Clipboard.SetDataObject(LabelModel.Text)
        Catch ex As Exception
        End Try
    End Sub
End Class