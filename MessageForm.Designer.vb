<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MessageForm
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
        LabelMessage = New Label()
        BtnClose = New Button()
        SuspendLayout()
        ' 
        ' LabelMessage
        ' 
        LabelMessage.AutoSize = True
        LabelMessage.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        LabelMessage.Location = New Point(83, 19)
        LabelMessage.Name = "LabelMessage"
        LabelMessage.Size = New Size(76, 21)
        LabelMessage.TabIndex = 0
        LabelMessage.Text = "message"
        ' 
        ' BtnClose
        ' 
        BtnClose.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        BtnClose.Location = New Point(83, 56)
        BtnClose.Name = "BtnClose"
        BtnClose.Size = New Size(75, 10)
        BtnClose.TabIndex = 1
        BtnClose.Text = "Close"
        BtnClose.UseVisualStyleBackColor = True
        BtnClose.Visible = False
        ' 
        ' MessageForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(272, 68)
        ControlBox = False
        Controls.Add(BtnClose)
        Controls.Add(LabelMessage)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Name = "MessageForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "For Your Information"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LabelMessage As Label
    Friend WithEvents BtnClose As Button
End Class
