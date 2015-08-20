Imports System.Windows.Forms
'I finally added the auto updater to this program.
'If they click yes this will automatically close the program, install the update and then reopen the program for them
Public Class NewVersionInfo
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Dim theCurrentWorkingDir As String = System.IO.Directory.GetCurrentDirectory()
        Dim theVBcontent0 As String = "wscript.echo " & Chr(34) & "Updating Swift -> I'll restart for you shortly, Please standBy..." & Chr(34)
        Dim theVBcontent1 As String = "wshShell.Run " & Chr(34) & "taskkill /F /IM SyntecADUserEditor.exe" & Chr(34)
        Dim theVBcontent2 As String = "wscript.sleep 5000"
        Dim theVBcontent3 As String = "Set MyFileSystemObject = WScript.createObject(" & Chr(34) & "Scripting.FileSystemObject" & Chr(34) & ")"
        Dim theVBcontent4 As String = "SourcePath = " & Chr(34) & "\\ccmfs\software$\CCMUserEditor" & Chr(34)
        Dim theVBcontent5 As String = "DestinationPath = " & Chr(34) & theCurrentWorkingDir & Chr(34)
        Dim theVBcontent6 As String = "MyFileSystemObject.CopyFile SourcePath & " & Chr(34) & "\*.*" & Chr(34) & ", DestinationPath, True"
        Dim theVBcontent7 As String = "Set wshShell = CreateObject(" & Chr(34) & "wscript.shell" & Chr(34) & ")"
        Dim theVBcontent8 As String = "wshShell.Run " & Chr(34) & "SyntecADUserEditor.exe" & Chr(34)
        Dim ObjFileSystem As New IO.StreamWriter("UpdateVersion.vbs", False)
        ObjFileSystem.WriteLine(theVBcontent0)
        'ObjFileSystem.WriteLine(theVBcontent1)
        ObjFileSystem.WriteLine(theVBcontent2)
        ObjFileSystem.WriteLine(theVBcontent3)
        ObjFileSystem.WriteLine(theVBcontent4)
        ObjFileSystem.WriteLine(theVBcontent5)
        ObjFileSystem.WriteLine(theVBcontent6)
        ObjFileSystem.WriteLine(theVBcontent7)
        ObjFileSystem.WriteLine(theVBcontent8)
        ObjFileSystem.Close()
        Dim UpdateProcess As Process = New Process()
        UpdateProcess.StartInfo.FileName = "cscript.exe"
        UpdateProcess.StartInfo.Arguments = " UpdateVersion.vbs"
        UpdateProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
        UpdateProcess.Start()
        Environment.Exit(0)
        frmMainForm.Close()
        frmMainForm.Dispose()
        Me.Close()
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub NewVersionInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
