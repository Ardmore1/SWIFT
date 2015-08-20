Public Class AddRemoveP
    Public Sub AddRemoveProgram(ByVal MachineName As String)
        'This sub connects to WMI on the tager PC and lists the software that is installed on the PC
        Try
            dgvAddRemove.Rows.Clear()
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
            myObjectSearcher = New System.Management.ManagementObjectSearcher(myManagementScope.Path.ToString, "Select * From Win32_Product")
            myObjectCollection = myObjectSearcher.Get()
            Dim row1
            For Each myObject In myObjectCollection
                row1 = (myObject.GetPropertyValue("Caption"))
                dgvAddRemove.Rows.Add(row1)
            Next
        Catch ex As Exception
            MessageBox.Show("Problems connecting to machine or WMI may be stuck.")
        End Try
    End Sub
    Private Sub AddRemoveP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tbxMachineName.Text = frmMainForm.tbxPlistCname.Text
        AddRemoveProgram(tbxMachineName.Text)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If tbxMachineName.Text = "" Then
            MessageBox.Show("Please enter a valid host.")
        Else
            AddRemoveProgram(tbxMachineName.Text)
        End If
    End Sub
End Class