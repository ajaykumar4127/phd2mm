<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1_phd2mm
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
        Label1 = New Label()
        Label2 = New Label()
        Hd2DataPathPreview_TextBox = New TextBox()
        BrowseHd2DataPath_Button = New Button()
        Hd2DataPath_FolderBrowserDialogue = New FolderBrowserDialog()
        Label3 = New Label()
        ProfilesList_ComboBox = New ComboBox()
        Label4 = New Label()
        LastInstalledProfile_Label = New Label()
        Label6 = New Label()
        Label7 = New Label()
        CreateProfile_Button = New Button()
        AddSelectedMod_Button = New Button()
        RemoveSelectedMod_Button = New Button()
        SaveProfile_Button = New Button()
        DeleteProfile_Button = New Button()
        UnusedMods_ListBox = New ListBox()
        UsedMods_ListBox = New ListBox()
        MoveModUp_Button = New Button()
        MoveModDown_Button = New Button()
        InstallMods_Button = New Button()
        ToggleLightDarkMode_Button = New Button()
        MoreInfo_Button = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(466, 21)
        Label1.TabIndex = 0
        Label1.Text = "Hello! Welcome to Personal Helldivers 2 Mod Manager (phd2mm)"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(12, 35)
        Label2.Name = "Label2"
        Label2.Size = New Size(322, 21)
        Label2.TabIndex = 1
        Label2.Text = "Please select your Helldivers 2 data directory:"
        ' 
        ' Hd2DataPathPreview_TextBox
        ' 
        Hd2DataPathPreview_TextBox.Location = New Point(411, 32)
        Hd2DataPathPreview_TextBox.Name = "Hd2DataPathPreview_TextBox"
        Hd2DataPathPreview_TextBox.ReadOnly = True
        Hd2DataPathPreview_TextBox.Size = New Size(742, 23)
        Hd2DataPathPreview_TextBox.TabIndex = 3
        ' 
        ' BrowseHd2DataPath_Button
        ' 
        BrowseHd2DataPath_Button.Location = New Point(340, 32)
        BrowseHd2DataPath_Button.Name = "BrowseHd2DataPath_Button"
        BrowseHd2DataPath_Button.Size = New Size(65, 24)
        BrowseHd2DataPath_Button.TabIndex = 2
        BrowseHd2DataPath_Button.Text = "Browse"
        BrowseHd2DataPath_Button.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.Location = New Point(12, 61)
        Label3.Name = "Label3"
        Label3.Size = New Size(161, 21)
        Label3.TabIndex = 4
        Label3.Text = "Please select a profile:"
        ' 
        ' ProfilesList_ComboBox
        ' 
        ProfilesList_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ProfilesList_ComboBox.FormattingEnabled = True
        ProfilesList_ComboBox.Location = New Point(179, 61)
        ProfilesList_ComboBox.Name = "ProfilesList_ComboBox"
        ProfilesList_ComboBox.Size = New Size(455, 23)
        ProfilesList_ComboBox.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.Location = New Point(640, 61)
        Label4.Name = "Label4"
        Label4.Size = New Size(152, 21)
        Label4.TabIndex = 6
        Label4.Text = "Last installed profile:"
        ' 
        ' LastInstalledProfile_Label
        ' 
        LastInstalledProfile_Label.Font = New Font("Segoe UI", 12F)
        LastInstalledProfile_Label.Location = New Point(798, 61)
        LastInstalledProfile_Label.Name = "LastInstalledProfile_Label"
        LastInstalledProfile_Label.Size = New Size(355, 24)
        LastInstalledProfile_Label.TabIndex = 7
        LastInstalledProfile_Label.Text = "N/A"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.Location = New Point(12, 87)
        Label6.Name = "Label6"
        Label6.Size = New Size(211, 21)
        Label6.TabIndex = 8
        Label6.Text = "Mods not used in this profile:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12F)
        Label7.Location = New Point(573, 87)
        Label7.Name = "Label7"
        Label7.Size = New Size(184, 21)
        Label7.TabIndex = 9
        Label7.Text = "Mods used in this profile:"
        ' 
        ' CreateProfile_Button
        ' 
        CreateProfile_Button.Location = New Point(1056, 112)
        CreateProfile_Button.Name = "CreateProfile_Button"
        CreateProfile_Button.Size = New Size(97, 31)
        CreateProfile_Button.TabIndex = 12
        CreateProfile_Button.Text = "Create Profile"
        CreateProfile_Button.UseVisualStyleBackColor = True
        ' 
        ' AddSelectedMod_Button
        ' 
        AddSelectedMod_Button.Location = New Point(492, 112)
        AddSelectedMod_Button.Name = "AddSelectedMod_Button"
        AddSelectedMod_Button.Size = New Size(75, 57)
        AddSelectedMod_Button.TabIndex = 13
        AddSelectedMod_Button.Text = "Add Selected Mod"
        AddSelectedMod_Button.UseVisualStyleBackColor = True
        ' 
        ' RemoveSelectedMod_Button
        ' 
        RemoveSelectedMod_Button.Location = New Point(492, 185)
        RemoveSelectedMod_Button.Name = "RemoveSelectedMod_Button"
        RemoveSelectedMod_Button.Size = New Size(75, 57)
        RemoveSelectedMod_Button.TabIndex = 14
        RemoveSelectedMod_Button.Text = "Remove Selected Mod"
        RemoveSelectedMod_Button.UseVisualStyleBackColor = True
        ' 
        ' SaveProfile_Button
        ' 
        SaveProfile_Button.Location = New Point(1056, 161)
        SaveProfile_Button.Name = "SaveProfile_Button"
        SaveProfile_Button.Size = New Size(97, 31)
        SaveProfile_Button.TabIndex = 15
        SaveProfile_Button.Text = "Save Profile"
        SaveProfile_Button.UseVisualStyleBackColor = True
        ' 
        ' DeleteProfile_Button
        ' 
        DeleteProfile_Button.Location = New Point(1056, 210)
        DeleteProfile_Button.Name = "DeleteProfile_Button"
        DeleteProfile_Button.Size = New Size(97, 31)
        DeleteProfile_Button.TabIndex = 16
        DeleteProfile_Button.Text = "Delete Profile"
        DeleteProfile_Button.UseVisualStyleBackColor = True
        ' 
        ' UnusedMods_ListBox
        ' 
        UnusedMods_ListBox.FormattingEnabled = True
        UnusedMods_ListBox.Location = New Point(12, 111)
        UnusedMods_ListBox.Name = "UnusedMods_ListBox"
        UnusedMods_ListBox.ScrollAlwaysVisible = True
        UnusedMods_ListBox.Size = New Size(474, 709)
        UnusedMods_ListBox.Sorted = True
        UnusedMods_ListBox.TabIndex = 17
        ' 
        ' UsedMods_ListBox
        ' 
        UsedMods_ListBox.AllowDrop = True
        UsedMods_ListBox.FormattingEnabled = True
        UsedMods_ListBox.Location = New Point(573, 112)
        UsedMods_ListBox.Name = "UsedMods_ListBox"
        UsedMods_ListBox.ScrollAlwaysVisible = True
        UsedMods_ListBox.Size = New Size(474, 709)
        UsedMods_ListBox.TabIndex = 18
        ' 
        ' MoveModUp_Button
        ' 
        MoveModUp_Button.Location = New Point(1056, 285)
        MoveModUp_Button.Name = "MoveModUp_Button"
        MoveModUp_Button.Size = New Size(97, 55)
        MoveModUp_Button.TabIndex = 19
        MoveModUp_Button.Text = "Move Up Selected Mod"
        MoveModUp_Button.UseVisualStyleBackColor = True
        ' 
        ' MoveModDown_Button
        ' 
        MoveModDown_Button.Location = New Point(1056, 369)
        MoveModDown_Button.Name = "MoveModDown_Button"
        MoveModDown_Button.Size = New Size(97, 55)
        MoveModDown_Button.TabIndex = 20
        MoveModDown_Button.Text = "Move Down  Selected Mod"
        MoveModDown_Button.UseVisualStyleBackColor = True
        ' 
        ' InstallMods_Button
        ' 
        InstallMods_Button.Location = New Point(1056, 480)
        InstallMods_Button.Name = "InstallMods_Button"
        InstallMods_Button.Size = New Size(97, 79)
        InstallMods_Button.TabIndex = 21
        InstallMods_Button.Text = "Install All Mods from Current Profile"
        InstallMods_Button.UseVisualStyleBackColor = True
        ' 
        ' ToggleLightDarkMode_Button
        ' 
        ToggleLightDarkMode_Button.Location = New Point(1008, 7)
        ToggleLightDarkMode_Button.Name = "ToggleLightDarkMode_Button"
        ToggleLightDarkMode_Button.Size = New Size(145, 23)
        ToggleLightDarkMode_Button.TabIndex = 22
        ToggleLightDarkMode_Button.Text = "Toggle Light/Dark Mode"
        ToggleLightDarkMode_Button.UseVisualStyleBackColor = True
        ' 
        ' MoreInfo_Button
        ' 
        MoreInfo_Button.Location = New Point(927, 7)
        MoreInfo_Button.Name = "MoreInfo_Button"
        MoreInfo_Button.Size = New Size(75, 23)
        MoreInfo_Button.TabIndex = 23
        MoreInfo_Button.Text = "More Info"
        MoreInfo_Button.UseVisualStyleBackColor = True
        ' 
        ' Form1_phd2mm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1165, 851)
        Controls.Add(MoreInfo_Button)
        Controls.Add(ToggleLightDarkMode_Button)
        Controls.Add(InstallMods_Button)
        Controls.Add(MoveModDown_Button)
        Controls.Add(MoveModUp_Button)
        Controls.Add(UsedMods_ListBox)
        Controls.Add(UnusedMods_ListBox)
        Controls.Add(DeleteProfile_Button)
        Controls.Add(SaveProfile_Button)
        Controls.Add(RemoveSelectedMod_Button)
        Controls.Add(AddSelectedMod_Button)
        Controls.Add(CreateProfile_Button)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(LastInstalledProfile_Label)
        Controls.Add(Label4)
        Controls.Add(ProfilesList_ComboBox)
        Controls.Add(Label3)
        Controls.Add(Hd2DataPathPreview_TextBox)
        Controls.Add(BrowseHd2DataPath_Button)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "Form1_phd2mm"
        Text = "Personal Helldivers 2 Mod Manager (phd2mm) v1.1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Hd2DataPathPreview_TextBox As TextBox
    Friend WithEvents BrowseHd2DataPath_Button As Button
    Friend WithEvents Hd2DataPath_FolderBrowserDialogue As FolderBrowserDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents ProfilesList_ComboBox As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents LastInstalledProfile_Label As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CreateProfile_Button As Button
    Friend WithEvents AddSelectedMod_Button As Button
    Friend WithEvents RemoveSelectedMod_Button As Button
    Friend WithEvents SaveProfile_Button As Button
    Friend WithEvents DeleteProfile_Button As Button
    Friend WithEvents UnusedMods_ListBox As ListBox
    Friend WithEvents UsedMods_ListBox As ListBox
    Friend WithEvents MoveModUp_Button As Button
    Friend WithEvents MoveModDown_Button As Button
    Friend WithEvents InstallMods_Button As Button
    Friend WithEvents ToggleLightDarkMode_Button As Button
    Friend WithEvents MoreInfo_Button As Button

End Class
