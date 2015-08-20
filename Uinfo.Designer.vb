<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Uinfo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Uinfo))
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnUpdateNotes = New System.Windows.Forms.Button
        Me.rtxUserInfo = New System.Windows.Forms.RichTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtaccountName = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(276, 349)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnUpdateNotes
        '
        Me.btnUpdateNotes.Location = New System.Drawing.Point(195, 349)
        Me.btnUpdateNotes.Name = "btnUpdateNotes"
        Me.btnUpdateNotes.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdateNotes.TabIndex = 4
        Me.btnUpdateNotes.Text = "Update"
        Me.btnUpdateNotes.UseVisualStyleBackColor = True
        '
        'rtxUserInfo
        '
        Me.rtxUserInfo.Location = New System.Drawing.Point(12, 35)
        Me.rtxUserInfo.Name = "rtxUserInfo"
        Me.rtxUserInfo.Size = New System.Drawing.Size(339, 308)
        Me.rtxUserInfo.TabIndex = 5
        Me.rtxUserInfo.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(321, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "**Warning** These notes are not private. Although not easily done,"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(55, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(242, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "A user could read them, so type nice notes only  :)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 354)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Notes for Account: "
        '
        'txtaccountName
        '
        Me.txtaccountName.AutoSize = True
        Me.txtaccountName.Location = New System.Drawing.Point(95, 354)
        Me.txtaccountName.Name = "txtaccountName"
        Me.txtaccountName.Size = New System.Drawing.Size(10, 13)
        Me.txtaccountName.TabIndex = 9
        Me.txtaccountName.Text = "-"
        '
        'Uinfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 390)
        Me.Controls.Add(Me.txtaccountName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rtxUserInfo)
        Me.Controls.Add(Me.btnUpdateNotes)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Uinfo"
        Me.Text = "Uinfo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnUpdateNotes As System.Windows.Forms.Button
    Friend WithEvents rtxUserInfo As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtaccountName As System.Windows.Forms.Label
End Class
