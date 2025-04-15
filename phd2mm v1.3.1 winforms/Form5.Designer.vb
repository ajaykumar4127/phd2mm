<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5_ModRandomizationOptions
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
        Label1 = New Label()
        RandomizationModes_GroupBox = New GroupBox()
        RadioButton4 = New RadioButton()
        RadioButton2 = New RadioButton()
        RadioButton3 = New RadioButton()
        RadioButton1 = New RadioButton()
        Form5_ConfirmButton = New Button()
        Form5_CancelButton = New Button()
        RandomizationModes_GroupBox.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(333, 21)
        Label1.TabIndex = 1
        Label1.Text = "Choose your mod randomization options here:"
        ' 
        ' RandomizationModes_GroupBox
        ' 
        RandomizationModes_GroupBox.Controls.Add(RadioButton4)
        RandomizationModes_GroupBox.Controls.Add(RadioButton2)
        RandomizationModes_GroupBox.Controls.Add(RadioButton3)
        RandomizationModes_GroupBox.Controls.Add(RadioButton1)
        RandomizationModes_GroupBox.Font = New Font("Segoe UI", 12F)
        RandomizationModes_GroupBox.Location = New Point(12, 33)
        RandomizationModes_GroupBox.Name = "RandomizationModes_GroupBox"
        RandomizationModes_GroupBox.Size = New Size(582, 159)
        RandomizationModes_GroupBox.TabIndex = 2
        RandomizationModes_GroupBox.TabStop = False
        RandomizationModes_GroupBox.Text = "Randomization modes:"
        ' 
        ' RadioButton4
        ' 
        RadioButton4.AutoSize = True
        RadioButton4.Location = New Point(6, 121)
        RadioButton4.Name = "RadioButton4"
        RadioButton4.Size = New Size(548, 25)
        RadioButton4.TabIndex = 5
        RadioButton4.TabStop = True
        RadioButton4.Text = "Add and remove, has guarantee of filling only 1 mod per category and item"
        RadioButton4.UseVisualStyleBackColor = True
        ' 
        ' RadioButton2
        ' 
        RadioButton2.AutoSize = True
        RadioButton2.Location = New Point(6, 59)
        RadioButton2.Name = "RadioButton2"
        RadioButton2.Size = New Size(496, 25)
        RadioButton2.TabIndex = 4
        RadioButton2.TabStop = True
        RadioButton2.Text = "Only add, has guarantee of filling only 1 mod per category and item"
        RadioButton2.UseVisualStyleBackColor = True
        ' 
        ' RadioButton3
        ' 
        RadioButton3.AutoSize = True
        RadioButton3.Location = New Point(6, 90)
        RadioButton3.Name = "RadioButton3"
        RadioButton3.Size = New Size(561, 25)
        RadioButton3.TabIndex = 2
        RadioButton3.Text = "Add and remove, no guarantee of filling at least 1 mod per category and item"
        RadioButton3.UseVisualStyleBackColor = True
        ' 
        ' RadioButton1
        ' 
        RadioButton1.AutoSize = True
        RadioButton1.Checked = True
        RadioButton1.Location = New Point(6, 28)
        RadioButton1.Name = "RadioButton1"
        RadioButton1.Size = New Size(509, 25)
        RadioButton1.TabIndex = 0
        RadioButton1.TabStop = True
        RadioButton1.Text = "Only add, no guarantee of filling at least 1 mod per category and item"
        RadioButton1.UseVisualStyleBackColor = True
        ' 
        ' Form5_ConfirmButton
        ' 
        Form5_ConfirmButton.Font = New Font("Segoe UI", 12F)
        Form5_ConfirmButton.Location = New Point(165, 211)
        Form5_ConfirmButton.Name = "Form5_ConfirmButton"
        Form5_ConfirmButton.Size = New Size(93, 52)
        Form5_ConfirmButton.TabIndex = 3
        Form5_ConfirmButton.Text = "Confirm"
        Form5_ConfirmButton.UseVisualStyleBackColor = True
        ' 
        ' Form5_CancelButton
        ' 
        Form5_CancelButton.Font = New Font("Segoe UI", 12F)
        Form5_CancelButton.Location = New Point(321, 211)
        Form5_CancelButton.Name = "Form5_CancelButton"
        Form5_CancelButton.Size = New Size(93, 52)
        Form5_CancelButton.TabIndex = 4
        Form5_CancelButton.Text = "Cancel"
        Form5_CancelButton.UseVisualStyleBackColor = True
        ' 
        ' Form5_ModRandomizationOptions
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(609, 286)
        Controls.Add(Form5_CancelButton)
        Controls.Add(Form5_ConfirmButton)
        Controls.Add(RandomizationModes_GroupBox)
        Controls.Add(Label1)
        Name = "Form5_ModRandomizationOptions"
        Text = "Mod Randomization Options"
        RandomizationModes_GroupBox.ResumeLayout(False)
        RandomizationModes_GroupBox.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents CategoryOfModsToRandomize_GroupBox As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RandomizationModes_GroupBox As GroupBox
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents Form5_ConfirmButton As Button
    Friend WithEvents Form5_CancelButton As Button
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
End Class
