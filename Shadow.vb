Public Class Shadow
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Sub remoteBatchExist(ByVal ComputerNameas As String)
        Try
            Dim FileDestination As String = "\\" & tbxShadow.Text & "\c$\windows\disablewallpaper.bat"
            Dim FileSource As String = "c:\windows\disablewallpaper.bat"
            If System.IO.File.Exists(FileDestination) = False Then
                System.IO.File.Copy(FileSource, FileDestination, True)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If CheckBoxDisableWallPaper.Checked Then
            Dim KillWallPaper As Process = New Process()
            KillWallPaper.StartInfo.FileName = "psexec.exe"
            KillWallPaper.StartInfo.Arguments = " \\" & tbxShadow.Text & "  -i -c c:\windows\disablewallpaper.bat"
            KillWallPaper.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            KillWallPaper.Start()
        End If
        If CheckBoxFullNotepad.Checked Then
            Dim KillWallPaper As Process = New Process()
            KillWallPaper.StartInfo.FileName = "psexec.exe"
            KillWallPaper.StartInfo.Arguments = " \\" & tbxShadow.Text & "  -i -c c:\WINDOWS\launchNotePad.bat"
            KillWallPaper.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            KillWallPaper.Start()
        End If
        If tbxShadow.Text = "" Then
            MsgBox("Please enter a computer first.")
        Else
            System.Diagnostics.Process.Start("shadow", " Console /server:" & tbxShadow.Text)
        End If
    End Sub
End Class