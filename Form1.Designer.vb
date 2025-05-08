<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        TextArea = New TextBox()
        Panel2 = New Panel()
        BtnExit = New Button()
        BtnDEVSubstitute = New Button()
        CbSortingASC = New CheckBox()
        BtnUndo = New Button()
        CBToUpperCase = New CheckBox()
        BtnCIASubstitute = New Button()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.Controls.Add(TextArea)
        Panel1.Location = New Point(4, 44)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(748, 650)
        Panel1.TabIndex = 1
        ' 
        ' TextArea
        ' 
        TextArea.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TextArea.Location = New Point(3, 9)
        TextArea.Multiline = True
        TextArea.Name = "TextArea"
        TextArea.ScrollBars = ScrollBars.Vertical
        TextArea.Size = New Size(745, 641)
        TextArea.TabIndex = 0
        TextArea.Text = "*SELECT * FROM []abc"
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Panel2.BorderStyle = BorderStyle.Fixed3D
        Panel2.Controls.Add(BtnExit)
        Panel2.Controls.Add(BtnDEVSubstitute)
        Panel2.Controls.Add(CbSortingASC)
        Panel2.Controls.Add(BtnUndo)
        Panel2.Controls.Add(CBToUpperCase)
        Panel2.Controls.Add(BtnCIASubstitute)
        Panel2.Location = New Point(4, 8)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(748, 39)
        Panel2.TabIndex = 2
        ' 
        ' BtnExit
        ' 
        BtnExit.Location = New Point(662, 9)
        BtnExit.Name = "BtnExit"
        BtnExit.Size = New Size(75, 23)
        BtnExit.TabIndex = 7
        BtnExit.Text = "Exit"
        BtnExit.UseVisualStyleBackColor = True
        ' 
        ' BtnDEVSubstitute
        ' 
        BtnDEVSubstitute.Location = New Point(89, 3)
        BtnDEVSubstitute.Name = "BtnDEVSubstitute"
        BtnDEVSubstitute.Size = New Size(75, 23)
        BtnDEVSubstitute.TabIndex = 6
        BtnDEVSubstitute.Text = "SUB DEV"
        BtnDEVSubstitute.UseVisualStyleBackColor = True
        ' 
        ' CbSortingASC
        ' 
        CbSortingASC.AutoSize = True
        CbSortingASC.Checked = True
        CbSortingASC.CheckState = CheckState.Checked
        CbSortingASC.Location = New Point(287, 6)
        CbSortingASC.Name = "CbSortingASC"
        CbSortingASC.Size = New Size(48, 19)
        CbSortingASC.TabIndex = 5
        CbSortingASC.Text = "ASC"
        CbSortingASC.UseVisualStyleBackColor = True
        ' 
        ' BtnUndo
        ' 
        BtnUndo.Location = New Point(530, 8)
        BtnUndo.Name = "BtnUndo"
        BtnUndo.Size = New Size(75, 23)
        BtnUndo.TabIndex = 4
        BtnUndo.Text = "Undo"
        BtnUndo.UseVisualStyleBackColor = True
        ' 
        ' CBToUpperCase
        ' 
        CBToUpperCase.AutoSize = True
        CBToUpperCase.Checked = True
        CBToUpperCase.CheckState = CheckState.Checked
        CBToUpperCase.Location = New Point(170, 8)
        CBToUpperCase.Name = "CBToUpperCase"
        CBToUpperCase.RightToLeft = RightToLeft.No
        CBToUpperCase.Size = New Size(96, 19)
        CBToUpperCase.TabIndex = 3
        CBToUpperCase.Text = "ToUpperCase"
        CBToUpperCase.UseVisualStyleBackColor = True
        ' 
        ' BtnCIASubstitute
        ' 
        BtnCIASubstitute.Location = New Point(8, 4)
        BtnCIASubstitute.Name = "BtnCIASubstitute"
        BtnCIASubstitute.Size = New Size(75, 23)
        BtnCIASubstitute.TabIndex = 2
        BtnCIASubstitute.Text = "SUB CIA"
        BtnCIASubstitute.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(755, 695)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "Form1"
        Text = "SQL Helper migrated from Java 8.2 to MS VS 2022"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextArea As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnCIASubstitute As Button
    Friend WithEvents CBToUpperCase As CheckBox
    Friend WithEvents BtnUndo As Button
    Friend WithEvents CbSortingASC As CheckBox
    Friend WithEvents BtnDEVSubstitute As Button
    Friend WithEvents BtnExit As Button

End Class
