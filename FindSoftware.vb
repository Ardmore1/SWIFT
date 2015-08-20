Imports System.Data
Imports System.Data.SqlClient
'This form reads in a list of all of the software installed onthe PC's from Config manager.
'It then lets you select a PC to see what is installed on it. Or to select a software package and see where it is installed
Public Class FindSoftware
    Sub FillSoftwareDropdown()
        Dim SoftwareCount As Integer = 0
        Try
            Dim strSQLConn As String = "data source=" & frmMainForm.SMSServerDB & "; " & "initial catalog=" & frmMainForm.SMSDB & "; " & "integrated security=true;"
            Dim SMSSQLconn As New SqlConnection(strSQLConn)
            SMSSQLconn.Open()
            Dim MySQLCommand As String = "Select Distinct Add_remove_Programs_DATA.DisplayName00 " & _
                                        "From System_DISC " & _
                                        "Inner join Add_remove_Programs_DATA on System_DISC.ItemKey = Add_remove_Programs_DATA.MachineID " & _
                                        "Order by DisplayName00 Asc"
            Dim sqlComm As New SqlCommand(MySQLCommand, SMSSQLconn)
            Dim MySQLreader As SqlDataReader = sqlComm.ExecuteReader()
            While MySQLreader.Read()
                Try
                    If MySQLreader("DisplayName00").ToString <> "" Then
                        ComboBoxSoftList.Items.Add(MySQLreader("DisplayName00").ToString)
                    End If
                Catch ex As Exception
                End Try
                SoftwareCount += 1
            End While
            MySQLreader.Close()
            ComboBoxSoftList.Text = ComboBoxSoftList.Items.Item(0)
            LabelSoftCount.Text = SoftwareCount.ToString
        Catch ex As Exception
        End Try
    End Sub
    Sub LoadTheResults(ByVal ThesoftwareName As String)
        DataGridViewSoftwareinv.Rows.Clear()
        Dim PCCount As Integer = 0
        Try
            Dim strSQLConn As String = "data source=" & frmMainForm.SMSServerDB & "; " & "initial catalog=" & frmMainForm.SMSDB & "; " & "integrated security=true;"
            Dim SMSSQLconn As New SqlConnection(strSQLConn)
            SMSSQLconn.Open()
            Dim username As String = ""
            Dim MySQLCommand As String
            If RadioButtonPositive.Checked Then
                MySQLCommand = "Select Distinct System_DISC.Netbios_name0, System_DISC.User_Name0, v_GS_WORKSTATION_STATUS.LastHWScan " & _
                                            "From System_DISC " & _
                                            "Inner join Add_remove_Programs_DATA on System_DISC.ItemKey = Add_remove_Programs_DATA.MachineID " & _
                                            "Inner join v_GS_WORKSTATION_STATUS on System_DISC.ItemKey = v_GS_WORKSTATION_STATUS.ResourceID " & _
                                            "Where Add_remove_Programs_DATA.DisplayName00 = '" & ThesoftwareName & "' " & _
                                            "Order by Netbios_name0 Asc"
            Else
                MySQLCommand = "Select Distinct System_DISC.Netbios_name0, System_DISC.User_Name0, v_GS_WORKSTATION_STATUS.LastHWScan " & _
                                            "From System_DISC " & _
                                            "Inner join v_GS_WORKSTATION_STATUS on System_DISC.ItemKey = v_GS_WORKSTATION_STATUS.ResourceID " & _
                                            "Where System_DISC.Netbios_name0 Not In (Select System_DISC.Netbios_name0 From System_DISC " & _
                                            "Inner join Add_remove_Programs_DATA on System_DISC.ItemKey = Add_remove_Programs_DATA.MachineID " & _
                                            "Inner join v_GS_WORKSTATION_STATUS on System_DISC.ItemKey = v_GS_WORKSTATION_STATUS.ResourceID " & _
                                            "Where Add_remove_Programs_DATA.DisplayName00 = '" & ThesoftwareName & "')"
            End If

            Dim sqlComm As New SqlCommand(MySQLCommand, SMSSQLconn)
            Dim MySQLreader As SqlDataReader = sqlComm.ExecuteReader()
            While MySQLreader.Read()
                Try
                    Dim PCName As String = ""
                    Dim TheUsername As String = ""
                    Dim ScanDate As String = ""

                    If MySQLreader("Netbios_name0") Is DBNull.Value Then
                        PCName = " "
                    Else
                        PCName = MySQLreader("Netbios_name0").ToString
                    End If
                    If MySQLreader("User_Name0") Is DBNull.Value Then
                        TheUsername = " "
                    Else
                        TheUsername = MySQLreader("User_Name0").ToString
                    End If
                    If MySQLreader("LastHWScan") Is DBNull.Value Then
                        ScanDate = " "
                    Else
                        ScanDate = MySQLreader("LastHWScan").ToString
                    End If
                    DataGridViewSoftwareinv.Rows.Add(PCName, TheUsername, ScanDate)
                    PCCount += 1
                Catch ex As Exception
                End Try
            End While
            MySQLreader.Close()
            LabelPCCount.Text = PCCount.ToString
        Catch ex As Exception
        End Try
    End Sub
    Sub ClearStuff()
        LabelSoftCount.Text = ""
        LabelPCCount.Text = ""
        DataGridViewSoftwareinv.Rows.Clear()
    End Sub
    Private Sub FindSoftware_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearStuff()
        FillSoftwareDropdown()
    End Sub
    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub
    Private Sub ComboBoxSoftList_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxSoftList.TextChanged
        LoadTheResults(ComboBoxSoftList.Text)
    End Sub
    Private Sub RadioButtonPositive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonPositive.CheckedChanged
        LoadTheResults(ComboBoxSoftList.Text)
    End Sub
End Class