<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2_CreateNewProfile
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
        ProfileName_TextBox = New TextBox()
        CreateNewProfile_button = New Button()
        CancelCreateProfile_button = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(114, 18)
        Label1.Name = "Label1"
        Label1.Size = New Size(280, 21)
        Label1.TabIndex = 0
        Label1.Text = "Enter name for your new profile below:"
        ' 
        ' ProfileName_TextBox
        ' 
        ProfileName_TextBox.Location = New Point(12, 55)
        ProfileName_TextBox.Name = "ProfileName_TextBox"
        ProfileName_TextBox.Size = New Size(470, 23)
        ProfileName_TextBox.TabIndex = 1
        ' 
        ' CreateNewProfile_button
        ' 
        CreateNewProfile_button.Font = New Font("Segoe UI", 12F)
        CreateNewProfile_button.Location = New Point(114, 101)
        CreateNewProfile_button.Name = "CreateNewProfile_button"
        CreateNewProfile_button.Size = New Size(151, 46)
        CreateNewProfile_button.TabIndex = 2
        CreateNewProfile_button.Text = "Create New Profile"
        CreateNewProfile_button.UseVisualStyleBackColor = True
        ' 
        ' CancelCreateProfile_button
        ' 
        CancelCreateProfile_button.Font = New Font("Segoe UI", 12F)
        CancelCreateProfile_button.Location = New Point(312, 101)
        CancelCreateProfile_button.Name = "CancelCreateProfile_button"
        CancelCreateProfile_button.Size = New Size(82, 46)
        CancelCreateProfile_button.TabIndex = 3
        CancelCreateProfile_button.Text = "Cancel"
        CancelCreateProfile_button.UseVisualStyleBackColor = True
        ' 
        ' Form2_CreateNewProfile
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(494, 172)
        Controls.Add(CancelCreateProfile_button)
        Controls.Add(CreateNewProfile_button)
        Controls.Add(ProfileName_TextBox)
        Controls.Add(Label1)
        Name = "Form2_CreateNewProfile"
        Text = "Creating New Profile"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ProfileName_TextBox As TextBox
    Friend WithEvents CreateNewProfile_button As Button
    Friend WithEvents CancelCreateProfile_button As Button
End Class
