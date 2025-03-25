Imports System.Diagnostics.Tracing
Imports System.Globalization
Imports System.IO
Imports System.Reflection.Emit

Public Class Form1_phd2mm

    Public currentDirectoryPath As String = Directory.GetCurrentDirectory()
    Public profileDirectoryPath As String = currentDirectoryPath & "\phd2mm_profiles"
    Public modDirectoryPath As String = currentDirectoryPath & "\phd2mm_mods"
    Public settingsTextFilePath As String = currentDirectoryPath & "\phd2mm_settings.txt"
    Public lightDarkMode As String = "light"

    Private Sub Form1_phd2mm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Directory.Exists(modDirectoryPath) Then
            My.Computer.FileSystem.CreateDirectory(modDirectoryPath)
        End If

        If Directory.Exists(profileDirectoryPath) Then
            Dim profileTextFiles As String() = Directory.GetFiles(profileDirectoryPath, "*.txt")
            If profileTextFiles.Length = 0 Then
                Dim defaultProfilePath As String = profileDirectoryPath & "\default.txt"
                Dim defaultProfileTextFile As FileStream = File.Create(defaultProfilePath)
                defaultProfileTextFile.Close()
            End If
        Else
            My.Computer.FileSystem.CreateDirectory(profileDirectoryPath)
            Dim defaultProfilePath As String = profileDirectoryPath & "\default.txt"
            Dim defaultProfileTextFile As FileStream = File.Create(defaultProfilePath)
            defaultProfileTextFile.Close()
        End If
        For Each profileFile As String In My.Computer.FileSystem.GetFiles(profileDirectoryPath)
            Dim profileFile2 As String = Path.GetFileName(profileFile)
            profileFile2 = profileFile2.Substring(0, profileFile2.Length - 4)
            ProfilesList_ComboBox.Items.Add(Path.GetFileName(profileFile2))
        Next
        ProfilesList_ComboBox.SelectedIndex = 0

        Dim checkIfSettingsFileIsCorrect As Boolean = True
        If File.Exists(settingsTextFilePath) Then
            For Each settingsFileByLineString As String In File.ReadLines(settingsTextFilePath)
                If settingsFileByLineString.Contains("current_hd2_data_directory: ") = True Then
                    Dim getsavedHd2DataDirectoryString() As String = settingsFileByLineString.Split("current_hd2_data_directory: ")
                    Dim savedHd2DataDirectoryString As String = getsavedHd2DataDirectoryString(1)
                    Hd2DataPathPreview_TextBox.Text = savedHd2DataDirectoryString
                ElseIf settingsFileByLineString.Contains("last_installed_profile: ") = True Then
                    Dim getsavedProfileString() As String = settingsFileByLineString.Split("last_installed_profile: ")
                    Dim savedProfileString As String = getsavedProfileString(1)
                    If ProfilesList_ComboBox.Items.Contains(savedProfileString) Then
                        ProfilesList_ComboBox.SelectedItem = savedProfileString
                    End If
                    LastInstalledProfile_Label.Text = savedProfileString
                ElseIf settingsFileByLineString.Contains("toggle_light_dark_mode: ") = True Then
                    Dim getsavedLightDarkMode() As String = settingsFileByLineString.Split("toggle_light_dark_mode: ")
                    Dim savedLightDarkMode As String = getsavedLightDarkMode(1)
                    lightDarkMode = savedLightDarkMode
                    If lightDarkMode = "dark" Then
                        ThemeManager.CurrentMode = "dark"
                    Else
                        ThemeManager.CurrentMode = "light"
                    End If
                    ThemeManager.ApplyTheme(Me)
                Else
                    checkIfSettingsFileIsCorrect = False
                    Exit For
                End If
            Next
        Else
            Dim tempString1 As String = "current_hd2_data_directory: " & vbCrLf & "last_installed_profile: " & vbCrLf & "toggle_light_dark_mode: " & "light"
            My.Computer.FileSystem.WriteAllText(settingsTextFilePath, tempString1, False)
        End If
        If checkIfSettingsFileIsCorrect = False Then
            Dim tempString1 As String = "current_hd2_data_directory: " & vbCrLf & "last_installed_profile: " & vbCrLf & "toggle_light_dark_mode: " & "light"
            My.Computer.FileSystem.WriteAllText(settingsTextFilePath, tempString1, False)
        End If
    End Sub

    Private Sub BrowseHd2DataPath_Button_Click(sender As Object, e As EventArgs) Handles BrowseHd2DataPath_Button.Click
        If Hd2DataPath_FolderBrowserDialogue.ShowDialog() = DialogResult.OK Then
            If Hd2DataPath_FolderBrowserDialogue.SelectedPath.EndsWith("Helldivers 2\data") Then
                Hd2DataPathPreview_TextBox.Text = Hd2DataPath_FolderBrowserDialogue.SelectedPath
                Dim savedProfileString As String = LastInstalledProfile_Label.Text
                'Dim savedProfileString As String = getsavedProfileString(1)
                Dim tempString1 As String = "current_hd2_data_directory: " & Hd2DataPathPreview_TextBox.Text & vbCrLf &
                    "last_installed_profile: " & savedProfileString & vbCrLf &
                    "toggle_light_dark_mode: " & lightDarkMode
                My.Computer.FileSystem.WriteAllText(settingsTextFilePath, tempString1, False)
                MessageBox.Show("Helldivers 2 data folder found! Please continue.")
            Else
                MessageBox.Show("Invalid directory! Please locate your Helldivers 2 data folder." & vbCrLf &
                "If it's bought on Steam, the path is usually: " & vbCrLf &
                "YourSteamPath\Steam\steamapps\common\Helldivers 2\data")
            End If
        End If
    End Sub

    Private Sub CreateProfile_Button_Click(sender As Object, e As EventArgs) Handles CreateProfile_Button.Click
        Dim form2 As New Form2_CreateNewProfile()
        form2.ShowDialog()
        If Not String.IsNullOrEmpty(form2.newProfileName) Then
            If Not ProfilesList_ComboBox.Items.Contains(form2.newProfileName) Then
                ProfilesList_ComboBox.Items.Add(form2.newProfileName)
                My.Computer.FileSystem.CreateDirectory(profileDirectoryPath)
                Dim newProfilePath As String = profileDirectoryPath & "\" & form2.newProfileName & ".txt"
                Dim newProfileTextFile As FileStream = File.Create(newProfilePath)
                newProfileTextFile.Close()
            Else
                MessageBox.Show("A profile with the name you entered already exists!")
            End If
        Else
        End If
    End Sub

    Private Sub SaveProfile_Button_Click(sender As Object, e As EventArgs) Handles SaveProfile_Button.Click
        Dim tempString1 As String = "Are you sure you want to save the current mod list to the selected profile?" & vbCrLf & ProfilesList_ComboBox.SelectedItem
        Dim confirmSaveProfile As DialogResult = MessageBox.Show(tempString1, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmSaveProfile = DialogResult.Yes Then
            Dim savedProfileDirectoryPathFile = profileDirectoryPath & "\" & ProfilesList_ComboBox.SelectedItem & ".txt"
            Using writer As New System.IO.StreamWriter(savedProfileDirectoryPathFile, False)
                For Each modItem As String In UsedMods_ListBox.Items
                    writer.WriteLine(modItem)
                Next
            End Using
            MessageBox.Show("Mod list order saved in: phd2mm_profiles\" & ProfilesList_ComboBox.SelectedItem & ".txt")
        End If
    End Sub

    Private Sub DeleteProfile_Button_Click(sender As Object, e As EventArgs) Handles DeleteProfile_Button.Click
        If ProfilesList_ComboBox.Items.Count > 0 Then
            If ProfilesList_ComboBox.SelectedItem IsNot Nothing Then
                Dim tempString1 As String = "Are you sure you want to delete current profile? Once deleted, it cannot be undone: " & vbCrLf & ProfilesList_ComboBox.SelectedItem
                Dim confirmDeleteProfile As DialogResult = MessageBox.Show(tempString1, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmDeleteProfile = DialogResult.Yes Then
                    Dim currentProfileDirectoryPathFile = profileDirectoryPath & "\" & ProfilesList_ComboBox.SelectedItem & ".txt"
                    My.Computer.FileSystem.DeleteFile(currentProfileDirectoryPathFile)
                    MessageBox.Show("Deleted profile: " & ProfilesList_ComboBox.SelectedItem)
                    ProfilesList_ComboBox.Items.Remove(ProfilesList_ComboBox.SelectedItem)
                    If ProfilesList_ComboBox.Items.Count >= 1 Then
                        ProfilesList_ComboBox.SelectedIndex = 0
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ProfilesList_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProfilesList_ComboBox.SelectedIndexChanged
        UnusedMods_ListBox.Items.Clear()
        UsedMods_ListBox.Items.Clear()
        Dim currentProfileTextFilePath As String = profileDirectoryPath + "\" + ProfilesList_ComboBox.SelectedItem + ".txt"
        For Each selectedModLine As String In File.ReadLines(currentProfileTextFilePath)
            UsedMods_ListBox.Items.Add(selectedModLine)
        Next
        For Each modFolder As String In Directory.GetDirectories(modDirectoryPath)
            If Directory.GetFiles(modFolder).Length = 0 AndAlso Directory.GetDirectories(modFolder).Length = 0 Then
            ElseIf Not UsedMods_ListBox.Items.Contains(Path.GetFileName(modFolder)) Then
                UnusedMods_ListBox.Items.Add(Path.GetFileName(modFolder))
            End If
        Next
    End Sub

    Private Sub UnusedMods_ListBox_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles UnusedMods_ListBox.MouseDoubleClick
        If UnusedMods_ListBox.SelectedItem IsNot Nothing Then
            UsedMods_ListBox.Items.Add(UnusedMods_ListBox.SelectedItem)
            UnusedMods_ListBox.Items.Remove(UnusedMods_ListBox.SelectedItem)
        End If
    End Sub

    'Currently unused due to bug related to drag and drop.
    Private Sub UsedMods_ListBox_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles UsedMods_ListBox.MouseDoubleClick
        If UsedMods_ListBox.SelectedItem IsNot Nothing Then
            UnusedMods_ListBox.Items.Add(UsedMods_ListBox.SelectedItem)
            UsedMods_ListBox.Items.Remove(UsedMods_ListBox.SelectedItem)
        End If
    End Sub

    Private Sub AddSelectedMod_Button_Click(sender As Object, e As EventArgs) Handles AddSelectedMod_Button.Click
        If UnusedMods_ListBox.SelectedItem IsNot Nothing Then
            UsedMods_ListBox.Items.Add(UnusedMods_ListBox.SelectedItem)
            UnusedMods_ListBox.Items.Remove(UnusedMods_ListBox.SelectedItem)
        End If
    End Sub

    Private Sub RemoveSelectedMod_Button_Click(sender As Object, e As EventArgs) Handles RemoveSelectedMod_Button.Click
        If UsedMods_ListBox.SelectedItem IsNot Nothing Then
            UnusedMods_ListBox.Items.Add(UsedMods_ListBox.SelectedItem)
            UsedMods_ListBox.Items.Remove(UsedMods_ListBox.SelectedItem)
        End If
    End Sub

    Private Sub MoveModUp_Button_Click(sender As Object, e As EventArgs) Handles MoveModUp_Button.Click
        If UsedMods_ListBox.SelectedIndex > 0 Then
            Dim currentIndex As Integer = UsedMods_ListBox.SelectedIndex
            Dim selectedItem As String = UsedMods_ListBox.SelectedItem.ToString()
            UsedMods_ListBox.Items.RemoveAt(currentIndex)
            UsedMods_ListBox.Items.Insert(currentIndex - 1, selectedItem)
            UsedMods_ListBox.SelectedIndex = currentIndex - 1
        End If
    End Sub

    Private Sub MoveModDown_Button_Click(sender As Object, e As EventArgs) Handles MoveModDown_Button.Click
        If UsedMods_ListBox.SelectedIndex < UsedMods_ListBox.Items.Count - 1 Then
            If UsedMods_ListBox.SelectedIndex >= 0 Then
                Dim currentIndex As Integer = UsedMods_ListBox.SelectedIndex
                Dim selectedItem As String = UsedMods_ListBox.SelectedItem.ToString()
                UsedMods_ListBox.Items.RemoveAt(currentIndex)
                UsedMods_ListBox.Items.Insert(currentIndex + 1, selectedItem)
                UsedMods_ListBox.SelectedIndex = currentIndex + 1
            End If
        End If
    End Sub

    Private Sub InstallMods_Button_Click(sender As Object, e As EventArgs) Handles InstallMods_Button.Click
        Dim tempString1 As String = "Are you sure you want to install all mods from current profile? This will delete all your currently installed Helldivers 2 mods." & vbCrLf &
            "Current profile: " & ProfilesList_ComboBox.SelectedItem
        Dim confirmInstallMods As DialogResult = MessageBox.Show(tempString1, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmInstallMods = DialogResult.Yes Then
            If Not Directory.Exists(Hd2DataPathPreview_TextBox.Text) Or String.IsNullOrEmpty(Hd2DataPathPreview_TextBox.Text) Or String.IsNullOrWhiteSpace(Hd2DataPathPreview_TextBox.Text) Then
                MessageBox.Show("Directory not found: " & Hd2DataPathPreview_TextBox.Text)
            ElseIf Not Hd2DataPathPreview_TextBox.Text.EndsWith("Helldivers 2\data") Then
                MessageBox.Show("Invalid directory! Please locate your Helldivers 2 data folder." & vbCrLf &
                                "If it's bought on Steam, the path is usually: " & vbCrLf &
                                "YourSteamPath\Steam\steamapps\common\Helldivers 2\data")
            Else
                Dim modList As New List(Of String)()
                For Each item As String In UsedMods_ListBox.Items
                    modList.Add(item)
                Next
                Dim form3 As New Form3_InstallMods()
                form3.hd2DirectoryPath = Hd2DataPathPreview_TextBox.Text
                form3.modDirectoryPath = modDirectoryPath
                form3.profileName = ProfilesList_ComboBox.SelectedItem
                form3.selectedModsList = modList
                LastInstalledProfile_Label.Text = ProfilesList_ComboBox.SelectedItem
                Dim tempString2 As String = "current_hd2_data_directory: " & Hd2DataPathPreview_TextBox.Text & vbCrLf &
                    "last_installed_profile: " & ProfilesList_ComboBox.SelectedItem & vbCrLf &
                    "toggle_light_dark_mode: " & lightDarkMode

                My.Computer.FileSystem.WriteAllText(settingsTextFilePath, tempString2, False)
                form3.ShowDialog()
            End If
        End If
    End Sub

    Private Sub MoreInfo_Button_Click(sender As Object, e As EventArgs) Handles MoreInfo_Button.Click
        Dim form4 As New Form4_MoreInfo()
        form4.ShowDialog()
    End Sub


    Public Class ThemeManager
        Public Shared CurrentMode As String = "light"
        Public Shared Sub ApplyTheme(form As Form)
            If CurrentMode = "dark" Then
                form.BackColor = Color.FromArgb(40, 40, 40) ' Dark gray background
                form.ForeColor = Color.White

                For Each ctrl As Control In form.Controls
                    If TypeOf ctrl Is Button Then
                        ctrl.BackColor = Color.FromArgb(60, 60, 60)
                        ctrl.ForeColor = Color.White
                    ElseIf TypeOf ctrl Is System.Windows.Forms.Label Then
                        ctrl.ForeColor = Color.White
                        ctrl.BackColor = Color.FromArgb(50, 50, 50)
                    ElseIf TypeOf ctrl Is TextBox Then
                        ctrl.BackColor = Color.FromArgb(50, 50, 50)
                        ctrl.ForeColor = Color.White
                    ElseIf TypeOf ctrl Is ComboBox Then
                        ctrl.BackColor = Color.FromArgb(50, 50, 50)
                        ctrl.ForeColor = Color.White
                    ElseIf TypeOf ctrl Is ListBox Then
                        ctrl.BackColor = Color.FromArgb(50, 50, 50)
                        ctrl.ForeColor = Color.White
                    End If
                Next
            Else
                form.BackColor = Color.FromArgb(240, 240, 240) ' Light gray background
                form.ForeColor = Color.FromArgb(0, 0, 0) ' Black text color

                For Each ctrl As Control In form.Controls
                    If TypeOf ctrl Is Button Then
                        ctrl.BackColor = Color.FromArgb(230, 230, 230)
                        ctrl.ForeColor = Color.FromArgb(0, 0, 0)
                    ElseIf TypeOf ctrl Is System.Windows.Forms.Label Then
                        ctrl.ForeColor = Color.FromArgb(0, 0, 0)
                        ctrl.BackColor = Color.FromArgb(240, 240, 240)
                    ElseIf TypeOf ctrl Is TextBox Then
                        ctrl.BackColor = Color.White
                        ctrl.ForeColor = Color.FromArgb(0, 0, 0)
                    ElseIf TypeOf ctrl Is ComboBox Then
                        ctrl.BackColor = Color.White
                        ctrl.ForeColor = Color.FromArgb(0, 0, 0)
                    ElseIf TypeOf ctrl Is ListBox Then
                        ctrl.BackColor = Color.White
                        ctrl.ForeColor = Color.FromArgb(0, 0, 0)
                    End If
                Next
            End If
        End Sub
    End Class

    Private Sub ToggleLightDarkMode_Button_Click(sender As Object, e As EventArgs) Handles ToggleLightDarkMode_Button.Click
        If ThemeManager.CurrentMode = "light" Then
            ThemeManager.CurrentMode = "dark"
            lightDarkMode = "dark"
        Else
            ThemeManager.CurrentMode = "light"
            lightDarkMode = "light"
        End If
        Dim tempString1 As String = "current_hd2_data_directory: " & Hd2DataPathPreview_TextBox.Text & vbCrLf &
                    "last_installed_profile: " & ProfilesList_ComboBox.SelectedItem & vbCrLf &
                    "toggle_light_dark_mode: " & lightDarkMode
        My.Computer.FileSystem.WriteAllText(settingsTextFilePath, tempString1, False)
        ' Reapply the theme to the current form
        ThemeManager.ApplyTheme(Me)
        ' Optionally, you can also apply the theme to other open forms
        For Each f As Form In Application.OpenForms
            ThemeManager.ApplyTheme(f)
        Next
    End Sub

    Private Sub UsedMods_ListBox_MouseDown(sender As Object, e As MouseEventArgs) Handles UsedMods_ListBox.MouseDown
        If e.Button = MouseButtons.Left Then
            If UsedMods_ListBox.SelectedIndex >= 0 Then
                UsedMods_ListBox.DoDragDrop(UsedMods_ListBox.SelectedItem, DragDropEffects.Move)
            End If
        End If

        If e.Button = MouseButtons.Right Then
            Dim index As Integer = UsedMods_ListBox.IndexFromPoint(e.Location)
            If index >= 0 Then
                UsedMods_ListBox.SelectedIndex = index
            End If
            If e.Clicks = 2 Then
                If index >= 0 Then
                    UnusedMods_ListBox.Items.Add(UsedMods_ListBox.SelectedItem)
                    UsedMods_ListBox.Items.Remove(UsedMods_ListBox.SelectedItem)
                End If
            End If
        End If
    End Sub

    Private Sub UsedMods_ListBox_MouseUp(sender As Object, e As MouseEventArgs) Handles UsedMods_ListBox.MouseUp
        If e.Button = MouseButtons.Left Then
            Dim index As Integer = UsedMods_ListBox.IndexFromPoint(e.Location)
            If index >= 0 Then
                UsedMods_ListBox.SelectedIndex = index
            End If
        End If
    End Sub

    Private Sub UsedMods_ListBox_DragEnter(sender As Object, e As DragEventArgs) Handles UsedMods_ListBox.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        End If
    End Sub

    Private Sub UsedMods_ListBox_DragDrop(sender As Object, e As DragEventArgs) Handles UsedMods_ListBox.DragDrop
        Dim draggedItem As String = CType(e.Data.GetData(DataFormats.Text), String)
        Dim point As Point = UsedMods_ListBox.PointToClient(New Point(e.X, e.Y))
        Dim index As Integer = UsedMods_ListBox.IndexFromPoint(point)
        If index = -1 Then
            Return
        Else
            Dim originalIndex As Integer = UsedMods_ListBox.SelectedIndex
            If originalIndex >= 0 Then
                UsedMods_ListBox.Items.RemoveAt(originalIndex)
            End If
            If index = UsedMods_ListBox.Items.Count Then
                UsedMods_ListBox.Items.Add(draggedItem)
            Else
                UsedMods_ListBox.Items.Insert(index, draggedItem)
            End If
        End If
    End Sub

End Class
