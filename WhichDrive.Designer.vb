<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WhichDrive
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WhichDrive))
        Me.ButtonLookUp = New System.Windows.Forms.Button
        Me.TextBoxUserShare = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.RadioButtonGroup = New System.Windows.Forms.RadioButton
        Me.RadioButtonUser = New System.Windows.Forms.RadioButton
        Me.RadioButtonShare = New System.Windows.Forms.RadioButton
        Me.ButtonExit = New System.Windows.Forms.Button
        Me.ListBoxMappings = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'ButtonLookUp
        '
        Me.ButtonLookUp.Location = New System.Drawing.Point(305, 7)
        Me.ButtonLookUp.Name = "ButtonLookUp"
        Me.ButtonLookUp.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLookUp.TabIndex = 1
        Me.ButtonLookUp.Text = "Lookup"
        Me.ButtonLookUp.UseVisualStyleBackColor = True
        '
        'TextBoxUserShare
        '
        Me.TextBoxUserShare.Location = New System.Drawing.Point(90, 9)
        Me.TextBoxUserShare.Name = "TextBoxUserShare"
        Me.TextBoxUserShare.Size = New System.Drawing.Size(207, 20)
        Me.TextBoxUserShare.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(4, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 65)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Enter User: -->" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Or Group" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Or Server" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Or Share"
        '
        'RadioButtonGroup
        '
        Me.RadioButtonGroup.AutoSize = True
        Me.RadioButtonGroup.Location = New System.Drawing.Point(228, 42)
        Me.RadioButtonGroup.Name = "RadioButtonGroup"
        Me.RadioButtonGroup.Size = New System.Drawing.Size(69, 17)
        Me.RadioButtonGroup.TabIndex = 10
        Me.RadioButtonGroup.TabStop = True
        Me.RadioButtonGroup.Text = "By Group"
        Me.RadioButtonGroup.UseVisualStyleBackColor = True
        '
        'RadioButtonUser
        '
        Me.RadioButtonUser.AutoSize = True
        Me.RadioButtonUser.Checked = True
        Me.RadioButtonUser.Location = New System.Drawing.Point(90, 42)
        Me.RadioButtonUser.Name = "RadioButtonUser"
        Me.RadioButtonUser.Size = New System.Drawing.Size(62, 17)
        Me.RadioButtonUser.TabIndex = 9
        Me.RadioButtonUser.TabStop = True
        Me.RadioButtonUser.Text = "By User"
        Me.RadioButtonUser.UseVisualStyleBackColor = True
        '
        'RadioButtonShare
        '
        Me.RadioButtonShare.AutoSize = True
        Me.RadioButtonShare.Location = New System.Drawing.Point(154, 42)
        Me.RadioButtonShare.Name = "RadioButtonShare"
        Me.RadioButtonShare.Size = New System.Drawing.Size(68, 17)
        Me.RadioButtonShare.TabIndex = 8
        Me.RadioButtonShare.Text = "By Share"
        Me.RadioButtonShare.UseVisualStyleBackColor = True
        '
        'ButtonExit
        '
        Me.ButtonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonExit.Location = New System.Drawing.Point(311, 424)
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonExit.TabIndex = 11
        Me.ButtonExit.Text = "Exit"
        Me.ButtonExit.UseVisualStyleBackColor = True
        '
        'ListBoxMappings
        '
        Me.ListBoxMappings.Location = New System.Drawing.Point(4, 77)
        Me.ListBoxMappings.Multiline = True
        Me.ListBoxMappings.Name = "ListBoxMappings"
        Me.ListBoxMappings.Size = New System.Drawing.Size(382, 341)
        Me.ListBoxMappings.TabIndex = 12
        '
        'WhichDrive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 459)
        Me.Controls.Add(Me.ListBoxMappings)
        Me.Controls.Add(Me.ButtonExit)
        Me.Controls.Add(Me.RadioButtonGroup)
        Me.Controls.Add(Me.RadioButtonUser)
        Me.Controls.Add(Me.RadioButtonShare)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxUserShare)
        Me.Controls.Add(Me.ButtonLookUp)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WhichDrive"
        Me.Text = "WhatMapped?"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonLookUp As System.Windows.Forms.Button
    Friend WithEvents TextBoxUserShare As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadioButtonGroup As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonUser As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonShare As System.Windows.Forms.RadioButton
    Friend WithEvents ButtonExit As System.Windows.Forms.Button
    Friend WithEvents ListBoxMappings As System.Windows.Forms.TextBox
End Class
