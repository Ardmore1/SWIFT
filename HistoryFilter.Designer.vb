<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HistoryFilter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HistoryFilter))
        Me.RadioButtonPCName = New System.Windows.Forms.RadioButton()
        Me.RadioButtonIP = New System.Windows.Forms.RadioButton()
        Me.TextBoxTheIP = New System.Windows.Forms.TextBox()
        Me.TextBoxPCName = New System.Windows.Forms.TextBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.TextBoxRAM = New System.Windows.Forms.TextBox()
        Me.ButtonFilter = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'RadioButtonPCName
        '
        Me.RadioButtonPCName.AutoSize = True
        Me.RadioButtonPCName.Location = New System.Drawing.Point(12, 12)
        Me.RadioButtonPCName.Name = "RadioButtonPCName"
        Me.RadioButtonPCName.Size = New System.Drawing.Size(82, 17)
        Me.RadioButtonPCName.TabIndex = 0
        Me.RadioButtonPCName.TabStop = True
        Me.RadioButtonPCName.Text = "By PCName"
        Me.RadioButtonPCName.UseVisualStyleBackColor = True
        '
        'RadioButtonIP
        '
        Me.RadioButtonIP.AutoSize = True
        Me.RadioButtonIP.Location = New System.Drawing.Point(12, 73)
        Me.RadioButtonIP.Name = "RadioButtonIP"
        Me.RadioButtonIP.Size = New System.Drawing.Size(50, 17)
        Me.RadioButtonIP.TabIndex = 1
        Me.RadioButtonIP.TabStop = True
        Me.RadioButtonIP.Text = "By IP"
        Me.RadioButtonIP.UseVisualStyleBackColor = True
        '
        'TextBoxTheIP
        '
        Me.TextBoxTheIP.Location = New System.Drawing.Point(12, 96)
        Me.TextBoxTheIP.Name = "TextBoxTheIP"
        Me.TextBoxTheIP.Size = New System.Drawing.Size(147, 20)
        Me.TextBoxTheIP.TabIndex = 1
        '
        'TextBoxPCName
        '
        Me.TextBoxPCName.Location = New System.Drawing.Point(12, 35)
        Me.TextBoxPCName.Name = "TextBoxPCName"
        Me.TextBoxPCName.Size = New System.Drawing.Size(147, 20)
        Me.TextBoxPCName.TabIndex = 0
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(12, 134)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(184, 17)
        Me.RadioButton3.TabIndex = 4
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "By RAM - Enter max display value"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'TextBoxRAM
        '
        Me.TextBoxRAM.Location = New System.Drawing.Point(12, 157)
        Me.TextBoxRAM.Name = "TextBoxRAM"
        Me.TextBoxRAM.Size = New System.Drawing.Size(147, 20)
        Me.TextBoxRAM.TabIndex = 2
        '
        'ButtonFilter
        '
        Me.ButtonFilter.Location = New System.Drawing.Point(205, 194)
        Me.ButtonFilter.Name = "ButtonFilter"
        Me.ButtonFilter.Size = New System.Drawing.Size(75, 23)
        Me.ButtonFilter.TabIndex = 3
        Me.ButtonFilter.Text = "Filter"
        Me.ButtonFilter.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(121, 194)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 7
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'HistoryFilter
        '
        Me.AcceptButton = Me.ButtonFilter
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(298, 232)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonFilter)
        Me.Controls.Add(Me.TextBoxRAM)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.TextBoxPCName)
        Me.Controls.Add(Me.TextBoxTheIP)
        Me.Controls.Add(Me.RadioButtonIP)
        Me.Controls.Add(Me.RadioButtonPCName)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "HistoryFilter"
        Me.Text = "HistoryFilter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadioButtonPCName As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonIP As System.Windows.Forms.RadioButton
    Friend WithEvents TextBoxTheIP As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPCName As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents TextBoxRAM As System.Windows.Forms.TextBox
    Friend WithEvents ButtonFilter As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
End Class
