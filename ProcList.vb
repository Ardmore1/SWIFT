Public Class ProcList
    Public Sub GetProcList(ByVal MachineName As String)
        Try
            dgvProcList.Rows.Clear()
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
                MsgBox("Could not connect.")
            End If
            Dim myObjectSearcher As System.Management.ManagementObjectSearcher
            Dim myObjectSearcherCpuType As System.Management.ManagementObjectSearcher
            Dim myObjectSearcher2 As System.Management.ManagementObjectSearcher
            Dim myObjectCollection As System.Management.ManagementObjectCollection
            Dim myObjectCollectionCPU1 As System.Management.ManagementObjectCollection
            Dim myObjectCollectionCPU2 As System.Management.ManagementObjectCollection
            Dim myObjectCollectionCPUType As System.Management.ManagementObjectCollection
            Dim myObject As System.Management.ManagementObject
            Dim myObjectCPU1 As System.Management.ManagementObject
            Dim myObjectCPU2 As System.Management.ManagementObject
            Dim myObjectCPUType As System.Management.ManagementObject
            myObjectSearcher = New System.Management.ManagementObjectSearcher(myManagementScope.Path.ToString, _
                 "Select Name, ProcessID, WorkingSetSize, CommandLine, KernelModeTime, UserModeTime From Win32_Process")
            myObjectCollection = myObjectSearcher.Get()
            myObjectSearcherCpuType = New System.Management.ManagementObjectSearcher(myManagementScope.Path.ToString, _
                 "Select NumberOfLogicalProcessors From Win32_Processor")
            myObjectCollectionCPUType = myObjectSearcherCpuType.Get()
            Dim CpuCount As Decimal = 1
            For Each myObjectCPUType In myObjectCollectionCPUType
                Try
                    If Integer.Parse(myObjectCPUType.GetPropertyValue("NumberOfLogicalProcessors")) > 1 Then
                        CpuCount = Decimal.Parse(myObjectCPUType.GetPropertyValue("NumberOfLogicalProcessors"))
                    End If
                Catch ex As Exception
                End Try
            Next
            myObjectSearcher = New System.Management.ManagementObjectSearcher(myManagementScope.Path.ToString, _
                 "Select IDProcess, PercentProcessorTime, TimeStamp_Sys100NS from Win32_PerfRawData_PerfProc_Process")
            myObjectCollectionCPU1 = myObjectSearcher.Get()
            System.Threading.Thread.Sleep(2000)
            myObjectSearcher2 = New System.Management.ManagementObjectSearcher(myManagementScope.Path.ToString, _
                 "Select IDProcess, PercentProcessorTime, TimeStamp_Sys100NS from Win32_PerfRawData_PerfProc_Process")
            myObjectCollectionCPU2 = myObjectSearcher2.Get()
            Dim col1, col2, Col4, col5
            Dim Col3 As String = "0"
            Dim TheRAm As Decimal
            For Each myObject In myObjectCollection
                If myObject.GetPropertyValue("Name") <> "System Idle Process" Then
                    col1 = (myObject.GetPropertyValue("Name"))
                    col2 = (myObject.GetPropertyValue("ProcessID"))
                    For Each myObjectCPU1 In myObjectCollectionCPU1
                        If myObjectCPU1.GetPropertyValue("IDProcess") = col2 Then
                            Dim Value1 As Decimal = myObjectCPU1.GetPropertyValue("PercentProcessorTime")
                            Dim Time1 As Decimal = myObjectCPU1.GetPropertyValue("TimeStamp_Sys100NS")
                            For Each myObjectCPU2 In myObjectCollectionCPU2
                                If myObjectCPU2.GetPropertyValue("IDProcess") = col2 Then
                                    Dim Value2 As Decimal = myObjectCPU2.GetPropertyValue("PercentProcessorTime")
                                    Dim Time2 As Decimal = myObjectCPU2.GetPropertyValue("TimeStamp_Sys100NS")
                                    Try
                                        Dim ValueUsed As Decimal = (Value2 - Value1)
                                        Dim TimeUsed As Decimal = (Time2 - Time1)
                                        Dim CPUValue As Decimal = ValueUsed / TimeUsed
                                        Col3 = ((CPUValue * 100) / CpuCount).ToString("##.#")
                                        If Col3 = "" Then
                                            Col3 = "0"
                                        End If
                                    Catch ex As Exception
                                        Col3 = "0"
                                    End Try
                                    Exit For
                                End If
                            Next
                            Exit For
                        End If
                    Next
                    TheRAm = Decimal.Parse(myObject.GetPropertyValue("WorkingSetSize"))
                    Col4 = (TheRAm / 1024).ToString("###,###") & " K  "
                    col5 = (myObject.GetPropertyValue("CommandLine"))
                    dgvProcList.Rows.Add(col1, col2, Col3, Col4, col5)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("I'm having problems connecting to the machine specified.")
        End Try
    End Sub
    Public Sub pkiller(ByVal processToKill As String, ByVal MachineName As String)
        Dim myConnectionOptions As New System.Management.ConnectionOptions
        With myConnectionOptions
            .Impersonation = System.Management.ImpersonationLevel.Impersonate
            .Authentication = System.Management.AuthenticationLevel.Packet
        End With
        Dim myManagementScope As System.Management.ManagementScope
        Dim myServerName As String = MachineName
        myManagementScope = New System.Management.ManagementScope("\\" & MachineName & "\root\cimv2", myConnectionOptions) '4
        myManagementScope.Connect()
        If myManagementScope.IsConnected = False Then
            MsgBox("Could not connect.")
        End If
        Dim myObjectSearcher As System.Management.ManagementObjectSearcher
        Dim myObjectCollection As System.Management.ManagementObjectCollection
        Dim myObject As System.Management.ManagementObject '2
        myObjectSearcher = New System.Management.ManagementObjectSearcher(myManagementScope.Path.ToString, "Select * From Win32_Process") '3
        myObjectCollection = myObjectSearcher.Get()
        Dim colObserver As New System.Management.ManagementOperationObserver
        For Each myObject In myObjectCollection
            myObject.InvokeMethod(colObserver, "Terminate", Nothing)
        Next
    End Sub
    Private Sub ProcList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetProcList(frmMainForm.tHEpROCmACHINE)
        tbxRefresh.Text = frmMainForm.tHEpROCmACHINE
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        GetProcList(tbxRefresh.Text)
    End Sub
    Private Sub btnKill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKill.Click
        Dim ppart As Array
        If dgvProcList.SelectedCells.Count < 1 Then
            MsgBox("Please select a process to kill.")
        Else
            ppart = Split(dgvProcList.CurrentCell.Value, ".")
            System.Diagnostics.Process.Start("tskill", " " & ppart(0) & " /server:" & tbxRefresh.Text & " /A")
        End If
    End Sub
End Class