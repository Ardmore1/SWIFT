Public Class popup
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If tbxComputerPop.Text = "" Then
            MsgBox("Please enter a valid host.")
            Exit Sub
        End If
        If tbxMessage.Text = "" Then
            MsgBox("Please enter text for the popup.")
            Exit Sub
        End If
        System.Diagnostics.Process.Start("msg", " 0 /server:" & tbxComputerPop.Text & " /TIME:0 " & tbxMessage.Text)
    End Sub
End Class