Public Class HistoryFilter
    'creates some basic search filters for the logon history screen
    Private Sub ButtonFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFilter.Click
        If RadioButtonPCName.Checked Then
            If TextBoxPCName.Text = "" Then
                MsgBox("Please enter a valid host.")
                Exit Sub
            Else
                LogonHistory.GetByPCName(TextBoxPCName.Text)
            End If
        ElseIf RadioButtonIP.Checked Then
            If TextBoxTheIP.Text = "" Then
                MsgBox("Please enter a valid IP address.")
                Exit Sub
            Else
                LogonHistory.GetByIP(TextBoxTheIP.Text)
            End If
        Else
            If TextBoxRAM.Text = "" Then
                MsgBox("Please enter a valid size of RAM.")
                Exit Sub
            Else
                Try
                    Integer.Parse(TextBoxRAM.Text)
                Catch ex As Exception
                    MsgBox("Please only enter a number.")
                    Exit Sub
                End Try
                LogonHistory.getRam(TextBoxRAM.Text)
            End If
        End If
        Me.Close()
    End Sub
    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

    Private Sub HistoryFilter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class