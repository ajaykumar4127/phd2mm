<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4_CreateOrDuplicateTheme
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
        Label2 = New Label()
        NewThemeName_TextBox = New TextBox()
        Form4_CreateNewTheme_Button = New Button()
        Form4_Cancel_Button = New Button()
        Label1 = New Label()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(114, 58)
        Label2.Name = "Label2"
        Label2.Size = New Size(258, 21)
        Label2.TabIndex = 1
        Label2.Text = "Enter a name for your theme below:"
        ' 
        ' NewThemeName_TextBox
        ' 
        NewThemeName_TextBox.Location = New Point(12, 102)
        NewThemeName_TextBox.Name = "NewThemeName_TextBox"
        NewThemeName_TextBox.Size = New Size(470, 23)
        NewThemeName_TextBox.TabIndex = 2
        ' 
        ' Form4_CreateNewTheme_Button
        ' 
        Form4_CreateNewTheme_Button.Font = New Font("Segoe UI", 12F)
        Form4_CreateNewTheme_Button.Location = New Point(114, 148)
        Form4_CreateNewTheme_Button.Name = "Form4_CreateNewTheme_Button"
        Form4_CreateNewTheme_Button.Size = New Size(151, 46)
        Form4_CreateNewTheme_Button.TabIndex = 3
        Form4_CreateNewTheme_Button.Text = "Create New Theme"
        Form4_CreateNewTheme_Button.UseVisualStyleBackColor = True
        ' 
        ' Form4_Cancel_Button
        ' 
        Form4_Cancel_Button.Font = New Font("Segoe UI", 12F)
        Form4_Cancel_Button.Location = New Point(310, 148)
        Form4_Cancel_Button.Name = "Form4_Cancel_Button"
        Form4_Cancel_Button.Size = New Size(82, 46)
        Form4_Cancel_Button.TabIndex = 4
        Form4_Cancel_Button.Text = "Cancel"
        Form4_Cancel_Button.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(140, 21)
        Label1.TabIndex = 5
        Label1.Text = "Duplicating theme:"
        ' 
        ' Label3
        ' 
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.Location = New Point(158, 9)
        Label3.Name = "Label3"
        Label3.Size = New Size(324, 49)
        Label3.TabIndex = 6
        Label3.Text = "Theme to be duplicated"
        ' 
        ' Form4_CreateOrDuplicateTheme
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(494, 206)
        Controls.Add(Label3)
        Controls.Add(Label1)
        Controls.Add(Form4_Cancel_Button)
        Controls.Add(Form4_CreateNewTheme_Button)
        Controls.Add(NewThemeName_TextBox)
        Controls.Add(Label2)
        Name = "Form4_CreateOrDuplicateTheme"
        Text = "Create Theme"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents NewThemeName_TextBox As TextBox
    Friend WithEvents Form4_CreateNewTheme_Button As Button
    Friend WithEvents Form4_Cancel_Button As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
End Class
