Public Class RControl
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RC()
    End Sub
    Private Sub keydownhandler(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbxIP.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            RC()
        End If
    End Sub
    Private Sub RC()
        If CheckBoxDisableWallpaper.Checked Then
            Dim KillWallPaper As Process = New Process()
            KillWallPaper.StartInfo.FileName = "psexec.exe"
            KillWallPaper.StartInfo.Arguments = " \\" & tbxIP.Text & "  -i -c c:\windows\disablewallpaper.bat"
            KillWallPaper.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            KillWallPaper.Start()
        End If
        If CheckBoxFullNotepad.Checked Then
            Dim KillWallPaper As Process = New Process()
            KillWallPaper.StartInfo.FileName = "psexec.exe"
            KillWallPaper.StartInfo.Arguments = " \\" & tbxIP.Text & "  -i -c c:\WINDOWS\launchNotePad.bat"
            KillWallPaper.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            KillWallPaper.Start()
        End If
        System.Diagnostics.Process.Start("rc.exe", " 1 " & tbxIP.Text & " \\" & frmMainForm.SMSServer & "\")
    End Sub
End Class