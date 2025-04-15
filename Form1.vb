Imports System.ComponentModel
Imports System.Diagnostics.Tracing
Imports System.Globalization
Imports System.IO
Imports System.Reflection.Emit
Imports System.Security.Cryptography.X509Certificates
Imports System.Text.Json
Imports System.Text.Json.Nodes
Imports phd2mm.Class1
Imports phd2mm.Class2
Imports phd2mm.Class3

Public Class Form1_phd2mm

    Public currentDirectoryPath As String = Directory.GetCurrentDirectory()
    Public profileDirectoryPath As String = currentDirectoryPath & "\phd2mm_profiles"
    Public modDirectoryPath As String = currentDirectoryPath & "\phd2mm_mods"
    Public settingsDirectoryPath As String = currentDirectoryPath & "\phd2mm_settings"
    Public themesDirectoryPath As String = currentDirectoryPath & "\phd2mm_themes"
    Public settingsTextFilePath As String = settingsDirectoryPath & "\phd2mm_settings.json"
    Public registryTextFilePath As String = settingsDirectoryPath & "\phd2mm_registry.json"
    Public modsRegistryDictionary As New Dictionary(Of String, Class1.ModInfo)()
    Public usedModsOriginalDictionary As New Dictionary(Of String, Class1.ModInfo)()
    Public allModsOriginalDictionary As New Dictionary(Of String, Class1.ModInfo)()
    Public themesDictionary As New Dictionary(Of String, Class3.ThemeInfo)()
    Public profileSpecificThemesDictionary As New Dictionary(Of String, Class3.ProfileSpecificTheme)()
    Public randomizationMode As String = "OnlyAddHasGuarantee"
    Public currentGlobalTheme As ThemeInfo

    ' Makes scrolling smoother by enabling double buffering for the DataGridViews
    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        MyBase.OnHandleCreated(e)
        ' Enable double buffering for both DataGridViews
        EnableDoubleBuffering(UnusedMods_DataGridView)
        EnableDoubleBuffering(UsedMods_DataGridView)
    End Sub

    Private Sub EnableDoubleBuffering(dataGridView As DataGridView)
        ' Enable double buffering for DataGridView
        dataGridView.GetType().InvokeMember("DoubleBuffered",
        System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty,
        Nothing, dataGridView, New Object() {True})
    End Sub

    Private Sub Form1_phd2mm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Class1.DirectoryInitializer.InitializeDirectory(modDirectoryPath)
        Class1.DirectoryInitializer.InitializeDirectory(settingsDirectoryPath)
        Class1.DirectoryInitializer.InitializeDirectory(profileDirectoryPath)
        Class1.DirectoryInitializer.InitializeDirectory(themesDirectoryPath)

        Class3.ThemeManager.InitializeDefaultThemes(themesDictionary)
        Class3.ThemeManager.ReadThemes(themesDictionary, themesDirectoryPath)
        Class3.ThemeManager.PutThemesInThemes_ListboxAndComboBox(themesDictionary, Themes_ListBox, Themes_GlobalTheme_ComboBox)
        Themes_ListBox.SelectedIndex = 0
        Themes_GlobalTheme_ComboBox.SelectedIndex = 0
        Themes_ListBox.HorizontalScrollbar = True
        ' Add all keys (theme names) from the themesDictionary into the ComboBox column
        Themes_ProfileSpecificThemes_DataGridView_Theme_Column.Items.Add("")
        Themes_ProfileSpecificThemes_DataGridView_Theme_Column.Items.AddRange(themesDictionary.Keys.ToArray())


        If File.Exists(registryTextFilePath) Then
            Class1.RegistryEditor.ReadRegistry(modsRegistryDictionary, registryTextFilePath)
        Else
            ' If the file doesn't exist, create an empty JSON array
            My.Computer.FileSystem.WriteAllText(registryTextFilePath, "[]", False)
        End If

        ' If profile directory is empty, create a default profile, default.txt
        Dim profileTextFiles As String() = Directory.GetFiles(profileDirectoryPath, "*.txt")
        If profileTextFiles.Length = 0 Then
            Dim defaultProfilePath As String = profileDirectoryPath & "\default.txt"
            Dim defaultProfileTextFile As FileStream = File.Create(defaultProfilePath)
            defaultProfileTextFile.Close()
        End If

        For Each profileFile As String In My.Computer.FileSystem.GetFiles(profileDirectoryPath)
            Dim profileFile2 As String = Path.GetFileName(profileFile)
            profileFile2 = profileFile2.Substring(0, profileFile2.Length - 4)
            Dim profileFile3 As String = Path.GetFileName(profileFile2)
            ProfilesList_ComboBox.Items.Add(profileFile3)
            Themes_ProfileSpecificThemes_DataGridView.Rows.Add(profileFile3, "")
            Dim tempProfileTheme As New Class3.ProfileSpecificTheme(profileFile3, "")
            profileSpecificThemesDictionary.Add(profileFile3, tempProfileTheme)
        Next

        If Not File.Exists(settingsTextFilePath) Then
        Else
            Class1.SettingsEditor.ReadSettings(settingsTextFilePath, UsedMods_DataGridView, UnusedMods_DataGridView, Themes_ProfileSpecificThemes_DataGridView,
                                        Themes_GlobalTheme_ComboBox,
                                        Hd2DataPathPreview_TextBox, LastInstalledProfile_Label, themesDictionary, currentGlobalTheme,
                                        profileSpecificThemesDictionary)
        End If

        ProfilesList_ComboBox.SelectedIndex = 0

        Class1.ModFinder.ScanModFoldersForPatchFiles(modDirectoryPath, allModsOriginalDictionary, modsRegistryDictionary)
    End Sub

    Private Sub Form1_phd2mm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim usedModsInProfile As New Dictionary(Of String, Class1.ModInfo)()
        Dim currentProfileTextFilePath As String = profileDirectoryPath & "\" & ProfilesList_ComboBox.SelectedItem & ".txt"
        If File.Exists(currentProfileTextFilePath) Then
            UsedMods_DataGridView.Rows.Clear()
            UnusedMods_DataGridView.Rows.Clear()
            For Each modFolderPathName As String In File.ReadLines(currentProfileTextFilePath)
                Dim tempModInfo As ModInfo = modsRegistryDictionary(modFolderPathName)
                Class1.Mods_DataGridView_Editor.AddModInfoToDataGridView(tempModInfo, UsedMods_DataGridView)
                usedModsInProfile.Add(tempModInfo.Modfolderpathname, tempModInfo)
            Next
        End If
        For Each modFolderPathName As String In allModsOriginalDictionary.Keys
            If Not usedModsInProfile.ContainsKey(modFolderPathName) Then
                Dim tempModInfo As ModInfo = allModsOriginalDictionary(modFolderPathName)
                Class1.Mods_DataGridView_Editor.AddModInfoToDataGridView(tempModInfo, UnusedMods_DataGridView)
            End If
        Next
        UnusedMods_DataGridView.Sort(UnusedMods_DataGridView.Columns("UnusedMods_DataGridView_ModFolderPathName_Column"), System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Private Sub Form1_phd2mm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim tempString1 As String = "current_hd2_data_directory: " & Hd2DataPathPreview_TextBox.Text & vbCrLf &
        "last_installed_profile: " & LastInstalledProfile_Label.Text
        My.Computer.FileSystem.WriteAllText(settingsTextFilePath, tempString1, False)

        Class3.ThemeManager.OverwriteThemes(themesDictionary, themesDirectoryPath)

        Class1.RegistryEditor.OverwriteRegistry(modsRegistryDictionary, registryTextFilePath)

        Dim columnsVisibleOrHiddenDictionary As New Dictionary(Of String, Boolean)()
        ' Check column visibility when the form is closing
        For Each column As DataGridViewColumn In UnusedMods_DataGridView.Columns
            ' Skip exempted columns
            If column.Name = "UnusedMods_DataGridView_ModFolderPathName_Column" OrElse
           column.Name = "UsedMods_DataGridView_ModOrderNumber_Column" OrElse
           column.Name = "UsedMods_DataGridView_ModFolderPathName_Column" Then
                Continue For
            End If

            ' Log or handle information about visible or hidden columns
            If Not column.Visible Then
                ' Column is hidden
                columnsVisibleOrHiddenDictionary.Add(column.Name, False)
            Else
                ' Column is visible
                columnsVisibleOrHiddenDictionary.Add(column.Name, True)
            End If
        Next
        For Each column As DataGridViewColumn In UsedMods_DataGridView.Columns
            ' Skip exempted columns
            If column.Name = "UnusedMods_DataGridView_ModFolderPathName_Column" OrElse
           column.Name = "UsedMods_DataGridView_ModOrderNumber_Column" OrElse
           column.Name = "UsedMods_DataGridView_ModFolderPathName_Column" Then
                Continue For
            End If

            ' Log or handle information about visible or hidden columns
            If Not column.Visible Then
                ' Column is hidden
                columnsVisibleOrHiddenDictionary.Add(column.Name, False)
            Else
                ' Column is visible
                columnsVisibleOrHiddenDictionary.Add(column.Name, True)
            End If
        Next
        Class1.SettingsEditor.OverwriteSettings(Hd2DataPathPreview_TextBox.Text, LastInstalledProfile_Label.Text, columnsVisibleOrHiddenDictionary,
                                                currentGlobalTheme.ThemeName, profileSpecificThemesDictionary, settingsTextFilePath)
    End Sub


    Private Sub BrowseHd2DataPath_Button_Click(sender As Object, e As EventArgs) Handles BrowseHd2DataPath_Button.Click
        If Hd2DataPath_FolderBrowserDialogue.ShowDialog() = DialogResult.OK Then
            Dim hd2DirectoryPath As String = Hd2DataPath_FolderBrowserDialogue.SelectedPath
            If Class1.DirectoryValidator.ValidateDirectory(hd2DirectoryPath) Then
                hd2DirectoryPath = hd2DirectoryPath.Replace("\", "/")
                Hd2DataPathPreview_TextBox.Text = hd2DirectoryPath
                MessageBox.Show("Helldivers 2 data folder found! Please continue.")
            End If
        End If
    End Sub

    Private Sub ProfilesList_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProfilesList_ComboBox.SelectedIndexChanged
        Class1.RegistryEditor.UpdateRegistry(allModsOriginalDictionary, modsRegistryDictionary)
        Dim usedModsInProfile As New Dictionary(Of String, Class1.ModInfo)()
        Dim currentProfileTextFilePath As String = profileDirectoryPath & "\" & ProfilesList_ComboBox.SelectedItem & ".txt"
        If File.Exists(currentProfileTextFilePath) Then
            UsedMods_DataGridView.Rows.Clear()
            UnusedMods_DataGridView.Rows.Clear()
            For Each modFolderPathNameLine As String In File.ReadLines(currentProfileTextFilePath)
                Dim tempModInfo As New Class1.ModInfo(modFolderPathNameLine, Path.GetFileName(modFolderPathNameLine), "Other", "Other", "",
                                                       "", DateTime.Now.ToString("yyyy-MM-dd"), "", "")
                If modsRegistryDictionary.ContainsKey(modFolderPathNameLine) Then
                    tempModInfo = modsRegistryDictionary(modFolderPathNameLine)
                End If
                Class1.Mods_DataGridView_Editor.AddModInfoToDataGridView(tempModInfo, UsedMods_DataGridView)
                usedModsInProfile.Add(tempModInfo.Modfolderpathname, tempModInfo)
            Next
        End If
        For Each modFolderPathName As String In allModsOriginalDictionary.Keys
            If Not usedModsInProfile.ContainsKey(modFolderPathName) Then
                Dim tempModInfo As New Class1.ModInfo(modFolderPathName, Path.GetFileName(modFolderPathName), "Other", "Other", "",
                                                       "", DateTime.Now.ToString("yyyy-MM-dd"), "", "")
                If modsRegistryDictionary.ContainsKey(modFolderPathName) Then
                    tempModInfo = modsRegistryDictionary(modFolderPathName)
                End If
                Class1.Mods_DataGridView_Editor.AddModInfoToDataGridView(tempModInfo, UnusedMods_DataGridView)
            End If
        Next
        UnusedMods_DataGridView.Sort(UnusedMods_DataGridView.Columns("UnusedMods_DataGridView_ModFolderPathName_Column"), System.ComponentModel.ListSortDirection.Ascending)
        If ProfilesList_ComboBox.SelectedItem IsNot Nothing Then
            Dim profileTheme As ProfileSpecificTheme = profileSpecificThemesDictionary(ProfilesList_ComboBox.SelectedItem)
            If ProfilesList_ComboBox.SelectedItem = profileTheme.ProfileName Then
                If String.IsNullOrEmpty(profileTheme.ThemeName) Then
                    Class3.ThemeManager.ApplyThemeToForm(Me, currentGlobalTheme)
                    Class3.ThemeManager.ApplyImageToPictureBox(ProfileImage_PictureBox, currentGlobalTheme)
                Else
                    Class3.ThemeManager.ApplyThemeToForm(Me, themesDictionary(profileTheme.ThemeName))
                    Class3.ThemeManager.ApplyImageToPictureBox(ProfileImage_PictureBox, themesDictionary(profileTheme.ThemeName))
                End If
            End If
        End If


    End Sub

    ' Drag and drop functionality for reordering rows in the DataGridView.
    ' Only works with the UsedMods_DataGridView and not with the UnusedMods_DataGridView
    ' and it only works on the row header (first column). This conflicts with
    ' double-clicking the row header to remove the mod from UsedMods to UnusedMods.
    ' Meaning drag and drop will work , but double-clicking the row header will not.
    Private Sub UsedMods_DataGridView_MouseDown(sender As Object, e As MouseEventArgs) Handles UsedMods_DataGridView.MouseDown
        ' Detect if the mouse was clicked on the row header (first column)
        If e.Button = MouseButtons.Left Then
            Dim hitTest As DataGridView.HitTestInfo = UsedMods_DataGridView.HitTest(e.X, e.Y)
            If hitTest.Type = DataGridViewHitTestType.RowHeader Then
                ' Start the drag operation only if the user clicks on a row header
                UsedMods_DataGridView.DoDragDrop(UsedMods_DataGridView.Rows(hitTest.RowIndex), DragDropEffects.Move)
            End If
        End If
    End Sub

    ' Allow the drop operation only if the data is coming from a row header
    Private Sub UsedMods_DataGridView_DragEnter(sender As Object, e As DragEventArgs) Handles UsedMods_DataGridView.DragEnter
        If e.Data.GetDataPresent(GetType(DataGridViewRow)) Then
            e.Effect = DragDropEffects.Move
        End If
    End Sub

    ' Handle drop operation to move the row in UsedMods_DataGridView.
    Private Sub UsedMods_DataGridView_DragDrop(sender As Object, e As DragEventArgs) Handles UsedMods_DataGridView.DragDrop
        Dim clientPoint As Point = UsedMods_DataGridView.PointToClient(New Point(e.X, e.Y))
        Dim hitTest As DataGridView.HitTestInfo = UsedMods_DataGridView.HitTest(clientPoint.X, clientPoint.Y)

        If hitTest.Type = DataGridViewHitTestType.Cell Or hitTest.Type = DataGridViewHitTestType.RowHeader Then
            ' Get the dragged row and remove it from the current position
            Dim draggedRow As DataGridViewRow = CType(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)
            UsedMods_DataGridView.Rows.Remove(draggedRow)
            ' Insert the row at the new position
            If hitTest.RowIndex >= 0 AndAlso hitTest.RowIndex < UsedMods_DataGridView.Rows.Count Then
                UsedMods_DataGridView.Rows.Insert(hitTest.RowIndex, draggedRow)
            Else
                UsedMods_DataGridView.Rows.Add(draggedRow)
            End If
            ' Update the order numbers after the drop
            UpdateModOrderNumberColumn()
        End If
    End Sub

    Private Sub MoveModUp_Button_Click(sender As Object, e As EventArgs) Handles MoveModUp_Button.Click
        If UsedMods_DataGridView.SelectedCells.Count > 0 Then
            Dim selectedRowIndex As Integer = UsedMods_DataGridView.SelectedCells(0).RowIndex
            If selectedRowIndex > 0 Then
                Dim selectedRow As DataGridViewRow = UsedMods_DataGridView.Rows(selectedRowIndex)
                Dim rowAbove As DataGridViewRow = UsedMods_DataGridView.Rows(selectedRowIndex - 1)
                UsedMods_DataGridView.Rows.RemoveAt(selectedRowIndex)
                UsedMods_DataGridView.Rows.Insert(selectedRowIndex - 1, selectedRow)
                UsedMods_DataGridView.ClearSelection()
                UsedMods_DataGridView.Rows(selectedRowIndex - 1).Selected = True
            End If
        End If
    End Sub

    Private Sub MoveModDown_Button_Click(sender As Object, e As EventArgs) Handles MoveModDown_Button.Click
        If UsedMods_DataGridView.SelectedCells.Count > 0 Then
            Dim selectedRowIndex As Integer = UsedMods_DataGridView.SelectedCells(0).RowIndex
            If selectedRowIndex < UsedMods_DataGridView.Rows.Count - 1 Then
                Dim selectedRow As DataGridViewRow = UsedMods_DataGridView.Rows(selectedRowIndex)
                Dim rowBelow As DataGridViewRow = UsedMods_DataGridView.Rows(selectedRowIndex + 1)
                UsedMods_DataGridView.Rows.RemoveAt(selectedRowIndex)
                UsedMods_DataGridView.Rows.Insert(selectedRowIndex + 1, selectedRow)
                UsedMods_DataGridView.ClearSelection()
                UsedMods_DataGridView.Rows(selectedRowIndex + 1).Selected = True
            End If
        End If
    End Sub

    Private Sub UsedMods_DataGridView_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles UsedMods_DataGridView.RowsAdded
        UpdateModOrderNumberColumn()
    End Sub
    Private Sub UsedMods_DataGridView_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles UsedMods_DataGridView.RowsRemoved
        UpdateModOrderNumberColumn()
    End Sub
    Private Sub UsedMods_DataGridView_Sorted(sender As Object, e As EventArgs) Handles UsedMods_DataGridView.Sorted
        UpdateModOrderNumberColumn()
    End Sub
    Private Sub UpdateModOrderNumberColumn()
        ' Update the ModOrderNumber_Column to reflect the current row index
        For i As Integer = 0 To UsedMods_DataGridView.Rows.Count - 1
            If Not UsedMods_DataGridView.Rows(i).IsNewRow Then
                UsedMods_DataGridView.Rows(i).Cells("UsedMods_DataGridView_ModOrderNumber_Column").Value = i
            End If
        Next
    End Sub

    ' Add a mod from UnusedMods to UsedMods by double-clicking a cell in the DataGridView
    ' Done either by double-clicking a cell that belongs to the Mod Folder Path + Name column
    ' or by clicking the row header once then clicking the AddSelectedMod_Button.
    ' Double-clicking the row header (or the leftmost cell in the row) only works with
    ' UnusedMods_DataGridView and not with UsedMods_DataGridView due to conflict
    ' with drag and drop.
    Private Sub UnusedMods_DataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles UnusedMods_DataGridView.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < UnusedMods_DataGridView.Rows.Count Then
            Dim modFolderPathColumnIndex As Integer = UnusedMods_DataGridView.Columns.IndexOf(UnusedMods_DataGridView.Columns("UnusedMods_DataGridView_ModFolderPathName_Column"))
            If e.ColumnIndex = -1 Or e.ColumnIndex = modFolderPathColumnIndex Then
                Dim selectedRow As DataGridViewRow = UnusedMods_DataGridView.Rows(e.RowIndex)
                UsedMods_DataGridView.Rows.Add(UsedMods_DataGridView.RowCount,
                    selectedRow.Cells("UnusedMods_DataGridView_ModFolderPathName_Column").Value,
                    selectedRow.Cells("UnusedMods_DataGridView_ModName_Column").Value,
                    selectedRow.Cells("UnusedMods_DataGridView_Item_Column").Value,
                    selectedRow.Cells("UnusedMods_DataGridView_Category_Column").Value,
                    selectedRow.Cells("UnusedMods_DataGridView_Description_Column").Value,
                    selectedRow.Cells("UnusedMods_DataGridView_ImagePath_Column").Value,
                    selectedRow.Cells("UnusedMods_DataGridView_DateAdded_Column").Value,
                    selectedRow.Cells("UnusedMods_DataGridView_ModVersion_Column").Value,
                    selectedRow.Cells("UnusedMods_DataGridView_ModLink_Column").Value)
                UnusedMods_DataGridView.Rows.RemoveAt(e.RowIndex)
            End If
        End If

    End Sub
    Private Sub AddSelectedMod_Button_Click(sender As Object, e As EventArgs) Handles AddSelectedMod_Button.Click
        If UnusedMods_DataGridView.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = UnusedMods_DataGridView.SelectedRows(0)
            UsedMods_DataGridView.Rows.Add(UsedMods_DataGridView.RowCount,
                    selectedRow.Cells("UnusedMods_DataGridView_ModFolderPathName_Column").Value,
                    selectedRow.Cells("UnusedMods_DataGridView_ModName_Column").Value,
                    selectedRow.Cells("UnusedMods_DataGridView_Item_Column").Value,
                    selectedRow.Cells("UnusedMods_DataGridView_Category_Column").Value,
                    selectedRow.Cells("UnusedMods_DataGridView_Description_Column").Value,
                    selectedRow.Cells("UnusedMods_DataGridView_ImagePath_Column").Value,
                    selectedRow.Cells("UnusedMods_DataGridView_DateAdded_Column").Value,
                    selectedRow.Cells("UnusedMods_DataGridView_ModVersion_Column").Value,
                    selectedRow.Cells("UnusedMods_DataGridView_ModLink_Column").Value)
            UnusedMods_DataGridView.Rows.Remove(selectedRow)
        End If
    End Sub

    ' Remove a mod from UsedMods to UnusedMods by double-clicking a cell in the DataGridView
    ' -Double-clicking a cell that belongs to the Mod Folder Path + Name column
    ' -Double-clicking the row header (or the leftmost cell in the row)
    ' -Clicking the row header once then clicking the RemoveSelectedMod_Button
    Private Sub UsedMods_DataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles UsedMods_DataGridView.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < UsedMods_DataGridView.Rows.Count Then
            Dim modFolderPathColumnIndex As Integer = UsedMods_DataGridView.Columns.IndexOf(UsedMods_DataGridView.Columns("UsedMods_DataGridView_ModFolderPathName_Column"))
            If e.ColumnIndex = -1 Or e.ColumnIndex = modFolderPathColumnIndex Then
                Dim selectedRow As DataGridViewRow = UsedMods_DataGridView.Rows(e.RowIndex)
                UnusedMods_DataGridView.Rows.Add(
                selectedRow.Cells("UsedMods_DataGridView_ModFolderPathName_Column").Value,
                selectedRow.Cells("UsedMods_DataGridView_ModName_Column").Value,
                selectedRow.Cells("UsedMods_DataGridView_Item_Column").Value,
                selectedRow.Cells("UsedMods_DataGridView_Category_Column").Value,
                selectedRow.Cells("UsedMods_DataGridView_Description_Column").Value,
                selectedRow.Cells("UsedMods_DataGridView_ImagePath_Column").Value,
                selectedRow.Cells("UsedMods_DataGridView_DateAdded_Column").Value,
                selectedRow.Cells("UsedMods_DataGridView_ModVersion_Column").Value,
                selectedRow.Cells("UsedMods_DataGridView_ModLink_Column").Value)
                UsedMods_DataGridView.Rows.RemoveAt(e.RowIndex)
            End If
        End If
    End Sub
    Private Sub RemoveSelectedMod_Button_Click(sender As Object, e As EventArgs) Handles RemoveSelectedMod_Button.Click
        If UsedMods_DataGridView.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = UsedMods_DataGridView.SelectedRows(0)
            UnusedMods_DataGridView.Rows.Add(
                selectedRow.Cells("UsedMods_DataGridView_ModFolderPathName_Column").Value,
                selectedRow.Cells("UsedMods_DataGridView_ModName_Column").Value,
                selectedRow.Cells("UsedMods_DataGridView_Item_Column").Value,
                selectedRow.Cells("UsedMods_DataGridView_Category_Column").Value,
                selectedRow.Cells("UsedMods_DataGridView_Description_Column").Value,
                selectedRow.Cells("UsedMods_DataGridView_ImagePath_Column").Value,
                selectedRow.Cells("UsedMods_DataGridView_DateAdded_Column").Value,
                selectedRow.Cells("UsedMods_DataGridView_ModVersion_Column").Value,
                selectedRow.Cells("UsedMods_DataGridView_ModLink_Column").Value)
            UsedMods_DataGridView.Rows.Remove(selectedRow)
        End If
    End Sub

    ' Saves all data inside the DataGridViews to the dictionaries as soon as the user finishes editing a cell
    Private Sub UsedMods_DataGridView_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles UsedMods_DataGridView.CellEndEdit
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' Ensure the edited row exists and has values
            Dim modfolderPathname As String = If(UsedMods_DataGridView.Rows(e.RowIndex).Cells("UsedMods_DataGridView_ModFolderPathName_Column").Value, "").ToString()
            Dim modName As String = If(UsedMods_DataGridView.Rows(e.RowIndex).Cells("UsedMods_DataGridView_ModName_Column").Value, "").ToString()
            Dim item As String = If(UsedMods_DataGridView.Rows(e.RowIndex).Cells("UsedMods_DataGridView_Item_Column").Value, "").ToString()
            Dim category As String = If(UsedMods_DataGridView.Rows(e.RowIndex).Cells("UsedMods_DataGridView_Category_Column").Value, "").ToString()
            Dim description As String = If(UsedMods_DataGridView.Rows(e.RowIndex).Cells("UsedMods_DataGridView_Description_Column").Value, "").ToString()
            Dim imagePath As String = If(UsedMods_DataGridView.Rows(e.RowIndex).Cells("UsedMods_DataGridView_ImagePath_Column").Value, "").ToString()
            Dim dateAdded As String = If(UsedMods_DataGridView.Rows(e.RowIndex).Cells("UsedMods_DataGridView_DateAdded_Column").Value, "").ToString()
            Dim modVersion As String = If(UsedMods_DataGridView.Rows(e.RowIndex).Cells("UsedMods_DataGridView_ModVersion_Column").Value, "").ToString()
            Dim modLink As String = If(UsedMods_DataGridView.Rows(e.RowIndex).Cells("UsedMods_DataGridView_ModLink_Column").Value, "").ToString()

            If Not String.IsNullOrEmpty(modfolderPathname) AndAlso
           Not String.IsNullOrEmpty(category) AndAlso
           Not String.IsNullOrEmpty(item) Then

                Dim tempModInfo As New ModInfo(modfolderPathname, modName, item, category, description,
                                                imagePath, dateAdded, modVersion, modLink)
                Class1.UpdateModsOriginalDictionary.UpdateModsOriginalDictionary(tempModInfo, allModsOriginalDictionary)
                Class1.RegistryEditor.UpdateRegistry(allModsOriginalDictionary, modsRegistryDictionary)
            End If
        End If
        If e.ColumnIndex = UsedMods_DataGridView.Columns("UsedMods_DataGridView_ModOrderNumber_Column").Index Then
            Dim newIndex As Integer
            If Integer.TryParse(UsedMods_DataGridView.Rows(e.RowIndex).Cells("UsedMods_DataGridView_ModOrderNumber_Column").Value.ToString(), newIndex) Then
                If newIndex >= 0 AndAlso newIndex < UsedMods_DataGridView.Rows.Count Then
                    MoveRowToIndex(e.RowIndex, newIndex)
                ElseIf newIndex < 0 Then
                    MoveRowToIndex(e.RowIndex, 0)
                ElseIf newIndex >= UsedMods_DataGridView.Rows.Count Then
                    MoveRowToIndex(e.RowIndex, UsedMods_DataGridView.Rows.Count + 1)
                End If
            Else
                MessageBox.Show("Invalid input. Please enter a valid integer for the row number.")
            End If
        End If
    End Sub

    ' Move a row to a specific index in the DataGridView (UsedMods_DataGridView) using BeginInvoke
    ' This method is used to move a row to a new index after editing the ModOrderNumber column
    Private Sub MoveRowToIndex(currentIndex As Integer, newIndex As Integer)
        ' Temporarily disable EditOnEnter mode
        Dim originalEditMode As DataGridViewEditMode = UsedMods_DataGridView.EditMode
        UsedMods_DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically
        ' Use BeginInvoke to defer the row movement operation
        UsedMods_DataGridView.BeginInvoke(New Action(Sub()
                                                         Try
                                                             ' Get the row to move
                                                             Dim row As DataGridViewRow = UsedMods_DataGridView.Rows(currentIndex)
                                                             ' Clone the row and remove it from its current position
                                                             Dim clonedRow As DataGridViewRow = CType(row.Clone(), DataGridViewRow)
                                                             For i As Integer = 0 To row.Cells.Count - 1
                                                                 clonedRow.Cells(i).Value = row.Cells(i).Value
                                                             Next
                                                             UsedMods_DataGridView.Rows.RemoveAt(currentIndex)
                                                             ' Adjust the newIndex if necessary
                                                             If newIndex > currentIndex Then
                                                                 newIndex -= 1
                                                             End If
                                                             ' Insert the cloned row at the new index
                                                             If newIndex >= UsedMods_DataGridView.Rows.Count Then
                                                                 UsedMods_DataGridView.Rows.Add(clonedRow) ' If the new index is out of bounds, add to the end
                                                             Else
                                                                 UsedMods_DataGridView.Rows.Insert(newIndex, clonedRow)
                                                             End If
                                                             ' Optionally, update the order number column after moving
                                                             UpdateModOrderNumberColumn()
                                                         Finally
                                                             ' Re-enable the original EditOnEnter mode
                                                             UsedMods_DataGridView.EditMode = originalEditMode
                                                         End Try
                                                     End Sub))
    End Sub

    Private Sub UnusedMods_DataGridView_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles UnusedMods_DataGridView.CellEndEdit
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim modfolderPathname As String = If(UnusedMods_DataGridView.Rows(e.RowIndex).Cells("UnusedMods_DataGridView_ModFolderPathName_Column").Value, "").ToString()
            Dim modName As String = If(UnusedMods_DataGridView.Rows(e.RowIndex).Cells("UnusedMods_DataGridView_ModName_Column").Value, "").ToString()
            Dim item As String = If(UnusedMods_DataGridView.Rows(e.RowIndex).Cells("UnusedMods_DataGridView_Item_Column").Value, "").ToString()
            Dim category As String = If(UnusedMods_DataGridView.Rows(e.RowIndex).Cells("UnusedMods_DataGridView_Category_Column").Value, "").ToString()
            Dim description As String = If(UnusedMods_DataGridView.Rows(e.RowIndex).Cells("UnusedMods_DataGridView_Description_Column").Value, "").ToString()
            Dim imagePath As String = If(UnusedMods_DataGridView.Rows(e.RowIndex).Cells("UnusedMods_DataGridView_ImagePath_Column").Value, "").ToString()
            Dim dateAdded As String = If(UnusedMods_DataGridView.Rows(e.RowIndex).Cells("UnusedMods_DataGridView_DateAdded_Column").Value, "").ToString()
            Dim modVersion As String = If(UnusedMods_DataGridView.Rows(e.RowIndex).Cells("UnusedMods_DataGridView_ModVersion_Column").Value, "").ToString()
            Dim modLink As String = If(UnusedMods_DataGridView.Rows(e.RowIndex).Cells("UnusedMods_DataGridView_ModLink_Column").Value, "").ToString()

            If Not String.IsNullOrEmpty(modfolderPathname) AndAlso
           Not String.IsNullOrEmpty(category) AndAlso
           Not String.IsNullOrEmpty(item) Then

                Dim tempModInfo As New ModInfo(modfolderPathname, modName, item, category, description,
                                                imagePath, dateAdded, modVersion, modLink)
                Class1.UpdateModsOriginalDictionary.UpdateModsOriginalDictionary(tempModInfo, allModsOriginalDictionary)
                Class1.RegistryEditor.UpdateRegistry(allModsOriginalDictionary, modsRegistryDictionary)
            End If
        End If

    End Sub

    Private Sub SearchMod_TextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchMod_TextBox.TextChanged
        ' Convert search text to lowercase for case-insensitive search
        Dim search = SearchMod_TextBox.Text.ToLower()
        For Each row As DataGridViewRow In UnusedMods_DataGridView.Rows
            ' Check if any column in the row contains the search text
            If row.Cells.Cast(Of DataGridViewCell).Any(Function(cell) cell.Value.ToString().ToLower().Contains(search)) Then
                row.Visible = True
            Else
                row.Visible = False
            End If
        Next
        For Each row As DataGridViewRow In UsedMods_DataGridView.Rows
            ' Check if any column in the row contains the search text
            If row.Cells.Cast(Of DataGridViewCell).Any(Function(cell) cell.Value.ToString().ToLower().Contains(search)) Then
                row.Visible = True
            Else
                row.Visible = False
            End If
        Next
    End Sub

    Private Sub CreateProfile_Button_Click(sender As Object, e As EventArgs) Handles CreateProfile_Button.Click
        Dim form2 As New Form2_CreateNewProfile()
        form2.currentGlobalTheme = currentGlobalTheme
        form2.ShowDialog()
        If Not String.IsNullOrEmpty(form2.newProfileName) Then
            If Not ProfilesList_ComboBox.Items.Contains(form2.newProfileName) Then
                ProfilesList_ComboBox.Items.Add(form2.newProfileName)
                My.Computer.FileSystem.CreateDirectory(profileDirectoryPath)
                Dim newProfilePath As String = profileDirectoryPath & "\" & form2.newProfileName & ".txt"
                Dim newProfileTextFile As FileStream = File.Create(newProfilePath)
                newProfileTextFile.Close()
                Themes_ProfileSpecificThemes_DataGridView.Rows.Add(form2.newProfileName, "")
                Dim tempProfileTheme As New Class3.ProfileSpecificTheme(form2.newProfileName, "")
                profileSpecificThemesDictionary.Add(form2.newProfileName, tempProfileTheme)
            Else
                MessageBox.Show("A profile with the name you entered already exists!")
            End If
        End If
    End Sub

    Private Sub SaveProfile_Button_Click(sender As Object, e As EventArgs) Handles SaveProfile_Button.Click
        Dim tempString1 As String = "Are you sure you want to save the current mod list to the selected profile?" & vbCrLf & ProfilesList_ComboBox.SelectedItem
        Dim confirmSaveProfile As DialogResult = MessageBox.Show(tempString1, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmSaveProfile = DialogResult.Yes Then
            Dim savedProfileDirectoryPathFile = profileDirectoryPath & "\" & ProfilesList_ComboBox.SelectedItem & ".txt"
            Using writer As New System.IO.StreamWriter(savedProfileDirectoryPathFile, False)
                For Each modRow As DataGridViewRow In UsedMods_DataGridView.Rows
                    writer.WriteLine(modRow.Cells("UsedMods_DataGridView_ModFolderPathName_Column").Value)
                Next
            End Using
            MessageBox.Show("Mod list order saved in: phd2mm_profiles\" & ProfilesList_ComboBox.SelectedItem & ".txt")
        End If
    End Sub

    Private Sub DeleteProfile_Button_Click(sender As Object, e As EventArgs) Handles DeleteProfile_Button.Click
        If ProfilesList_ComboBox.Items.Count > 1 Then
            If ProfilesList_ComboBox.SelectedItem IsNot Nothing Then
                Dim tempString1 As String = "Are you sure you want to delete current profile? Once deleted, it cannot be undone: " & vbCrLf & ProfilesList_ComboBox.SelectedItem
                Dim confirmDeleteProfile As DialogResult = MessageBox.Show(tempString1, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmDeleteProfile = DialogResult.Yes Then
                    Dim currentProfileDirectoryPathFile = profileDirectoryPath & "\" & ProfilesList_ComboBox.SelectedItem & ".txt"
                    My.Computer.FileSystem.DeleteFile(currentProfileDirectoryPathFile)
                    If Themes_ProfileSpecificThemes_DataGridView.Rows.Cast(Of DataGridViewRow)().Any(Function(row) row.Cells("Themes_ProfileSpecificThemes_DataGridView_Profile_Column").Value.ToString() = ProfilesList_ComboBox.SelectedItem) Then
                        For Each row As DataGridViewRow In Themes_ProfileSpecificThemes_DataGridView.Rows
                            If row.Cells("Themes_ProfileSpecificThemes_DataGridView_Profile_Column").Value.ToString() = ProfilesList_ComboBox.SelectedItem Then
                                Themes_ProfileSpecificThemes_DataGridView.Rows.Remove(row)
                                Exit For
                            End If
                        Next
                    End If
                    If profileSpecificThemesDictionary.ContainsKey(ProfilesList_ComboBox.SelectedItem) Then
                        profileSpecificThemesDictionary.Remove(ProfilesList_ComboBox.SelectedItem)
                    End If
                    MessageBox.Show("Deleted profile: " & ProfilesList_ComboBox.SelectedItem)
                    ProfilesList_ComboBox.Items.Remove(ProfilesList_ComboBox.SelectedItem)
                    If ProfilesList_ComboBox.Items.Count >= 1 Then
                        ProfilesList_ComboBox.SelectedIndex = 0
                    End If
                End If
            End If
        Else
            Dim tempString1 As String = "Cannot delete profile: " & ProfilesList_ComboBox.SelectedItem & " because it is the only profile left! Please create another profile first."
            MessageBox.Show(tempString1)
        End If
    End Sub

    Private Sub DeleteAllInstalledMods_Button_Click(sender As Object, e As EventArgs) Handles DeleteAllInstalledMods_Button.Click
        Dim tempString1 As String = "Are you sure you want to delete all currently installed mods? This action cannot be reversed."
        Dim confirmRemoveAllInstalledMods As DialogResult = MessageBox.Show(tempString1, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmRemoveAllInstalledMods = DialogResult.Yes Then
            Dim hd2DirectoryPath As String = Hd2DataPathPreview_TextBox.Text
            If Class1.DirectoryValidator.ValidateDirectory(hd2DirectoryPath) Then
                Class1.ModUninstaller.DeleteModsInThisDirectory(hd2DirectoryPath)
            End If
            MessageBox.Show("Deleted all currently installed mods.")
        End If
    End Sub

    Private Sub InstallMods_Button_Click(sender As Object, e As EventArgs) Handles InstallMods_Button.Click
        Dim tempString1 As String = "Are you sure you want to install all mods from current profile? This will delete all your currently installed Helldivers 2 mods." & vbCrLf &
    "Current profile: " & ProfilesList_ComboBox.SelectedItem
        Dim confirmInstallMods As DialogResult = MessageBox.Show(tempString1, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmInstallMods = DialogResult.Yes Then
            Dim hd2DirectoryPath As String = Hd2DataPathPreview_TextBox.Text
            If Class1.DirectoryValidator.ValidateDirectory(hd2DirectoryPath) Then
                Dim modList As New List(Of String)()
                For Each row As DataGridViewRow In UsedMods_DataGridView.Rows
                    Dim modFolderPath As String = row.Cells(UsedMods_DataGridView_ModFolderPathName_Column.Index).Value.ToString()
                    modList.Add(modFolderPath)
                Next
                Dim form3 As New Form3_InstallMods()
                form3.currentGlobalTheme = currentGlobalTheme
                form3.hd2DirectoryPath = Hd2DataPathPreview_TextBox.Text
                form3.modDirectoryPath = modDirectoryPath
                form3.profileName = ProfilesList_ComboBox.SelectedItem
                form3.selectedModsList = modList
                LastInstalledProfile_Label.Text = ProfilesList_ComboBox.SelectedItem
                Dim tempString2 As String = "current_hd2_data_directory: " & Hd2DataPathPreview_TextBox.Text & vbCrLf &
                    "last_installed_profile: " & ProfilesList_ComboBox.SelectedItem
                My.Computer.FileSystem.WriteAllText(settingsTextFilePath, tempString2, False)
                form3.ShowDialog()
            End If
        End If
    End Sub

    ' Mod Randomizer related code.
    Private Sub EnableModRandomization_Button_Click(sender As Object, e As EventArgs) Handles EnableModRandomization_Button.Click
        If EnableModRandomization_Button.Text = "Enable Mod Randomization" Then
            Dim tempString1 As String = "Are you sure you want to enable mod randomization?"
            Dim confirmModRandomizationOption As DialogResult = MessageBox.Show(tempString1, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirmModRandomizationOption = DialogResult.Yes Then
                RandomizeMods_Button.Enabled = True
                EnableModRandomization_Button.Text = "Disable Mod Randomization"
            End If
        Else
            RandomizeMods_Button.Enabled = False
            EnableModRandomization_Button.Text = "Enable Mod Randomization"
        End If
    End Sub

    Private Sub ModRandomizationOptions_RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles ModRandomizationOAHG_RadioButton.CheckedChanged, ModRandomizationOANG_RadioButton.CheckedChanged,
        ModRandomizationARHG_RadioButton.CheckedChanged, ModRandomizationARNG_RadioButton.CheckedChanged
        If ModRandomizationOAHG_RadioButton.Checked Then
            randomizationMode = "OnlyAddGuaranteeOne"
        ElseIf ModRandomizationOANG_RadioButton.Checked Then
            randomizationMode = "OnlyAddNoGuarantee"
        ElseIf ModRandomizationARHG_RadioButton.Checked Then
            randomizationMode = "AddRemoveGuaranteeOne"
        ElseIf ModRandomizationARNG_RadioButton.Checked Then
            randomizationMode = "AddRemoveNoGuarantee"
        End If
    End Sub

    Private Sub RandomizeMods_Button_Click(sender As Object, e As EventArgs) Handles RandomizeMods_Button.Click
        Dim tempString1 As String = "Are you sure you want to randomize the mods?" & vbCrLf & "Currently mod randomization option:"
        Dim tempString2 As String
        Select Case randomizationMode
            Case "OnlyAddGuaranteeOne"
                tempString2 = ModRandomizationOAHG_RadioButton.Text
            Case "OnlyAddNoGuarantee"
                tempString2 = ModRandomizationOANG_RadioButton.Text
            Case "AddRemoveGuaranteeOne"
                tempString2 = ModRandomizationARHG_RadioButton.Text
            Case "AddRemoveNoGuarantee"
                tempString2 = ModRandomizationARNG_RadioButton.Text
        End Select
        Dim tempString3 As String = tempString1 & vbCrLf & tempString2
        Dim confirmModRandomization As DialogResult = MessageBox.Show(tempString3, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmModRandomization = DialogResult.Yes Then
            Class2.ModRandomizer.RandomizeMods(randomizationMode, allModsOriginalDictionary, UnusedMods_DataGridView, UsedMods_DataGridView)
        End If
    End Sub

    ' Add event handler to show the popup menu when the right mouse button is clicked
    Private Sub UnusedMods_DataGridView_MouseUp(sender As Object, e As MouseEventArgs) Handles UnusedMods_DataGridView.MouseUp
        If e.Button = MouseButtons.Right Then
            ' Check if the right-click was on a column header
            Dim hitTest As DataGridView.HitTestInfo = UnusedMods_DataGridView.HitTest(e.X, e.Y)
            If hitTest.Type = DataGridViewHitTestType.ColumnHeader Then
                ' Clear previous menu items
                UnusedMods_DataGridView_ContextMenuStrip.Items.Clear()

                ' For each column in DataGridView, add a toggle item to the context menu
                For Each column As DataGridViewColumn In UnusedMods_DataGridView.Columns
                    If column.Name = "UnusedMods_DataGridView_ModFolderPathName_Column" Then
                        Continue For  ' Skip adding this column to the context menu
                    End If
                    ' Create a menu item for the column with a checkbox
                    Dim menuItem As New ToolStripMenuItem(column.HeaderText)
                    menuItem.Checked = column.Visible  ' Set initial checked state based on visibility
                    ' Toggle the visibility of the column when clicked
                    AddHandler menuItem.Click, Sub(sender2, e2)
                                                   column.Visible = Not column.Visible
                                                   menuItem.Checked = column.Visible  ' Update checkbox state
                                               End Sub
                    ' Add the menu item to the context menu
                    UnusedMods_DataGridView_ContextMenuStrip.Items.Add(menuItem)
                Next

                ' Show the context menu at the mouse position
                UnusedMods_DataGridView_ContextMenuStrip.Show(UnusedMods_DataGridView, e.Location)
            End If
        End If
    End Sub
    Private Sub UsedMods_DataGridView_MouseUp(sender As Object, e As MouseEventArgs) Handles UsedMods_DataGridView.MouseUp
        If e.Button = MouseButtons.Right Then
            Dim hitTest As DataGridView.HitTestInfo = UsedMods_DataGridView.HitTest(e.X, e.Y)
            If hitTest.Type = DataGridViewHitTestType.ColumnHeader Then
                UsedMods_DataGridView_ContextMenuStrip.Items.Clear()
                For Each column As DataGridViewColumn In UsedMods_DataGridView.Columns
                    If column.Name = "UsedMods_DataGridView_ModFolderPathName_Column" Or column.Name = "UsedMods_DataGridView_ModOrderNumber_Column" Then
                        Continue For
                    End If
                    Dim menuItem As New ToolStripMenuItem(column.HeaderText)
                    menuItem.Checked = column.Visible
                    AddHandler menuItem.Click, Sub(sender2, e2)
                                                   column.Visible = Not column.Visible
                                                   menuItem.Checked = column.Visible
                                               End Sub
                    UsedMods_DataGridView_ContextMenuStrip.Items.Add(menuItem)
                Next
                UsedMods_DataGridView_ContextMenuStrip.Show(UsedMods_DataGridView, e.Location)
            End If
        End If
    End Sub

    ' Code below allows the values/options of Category Column to be linked to the current value of Item Column.
    ' The changes are done per row, rather than the entire Category Column. For example, if the user
    ' selects "JAR-5 Dominator" in the Item Column, the Category Column options will be reduced to
    ' "Weapon Audio" and "Weapon Skin" only for that row, unless the Item is changed again.
    ' Only the "Other" Item can have all Category options available.
    ' Add event handlers
    Private formResizer As FormResizer
    Public Sub New()
        InitializeComponent()

        ' Add event handlers after the form is initialized
        AddHandler UnusedMods_DataGridView.CellValueChanged, AddressOf UnusedMods_DataGridView_CellValueChanged
        AddHandler UnusedMods_DataGridView.CurrentCellDirtyStateChanged, AddressOf UnusedMods_DataGridView_CurrentCellDirtyStateChanged
        AddHandler UnusedMods_DataGridView.EditingControlShowing, AddressOf UnusedMods_DataGridView_EditingControlShowing
        AddHandler UsedMods_DataGridView.CellValueChanged, AddressOf UsedMods_DataGridView_CellValueChanged
        AddHandler UsedMods_DataGridView.CurrentCellDirtyStateChanged, AddressOf UsedMods_DataGridView_CurrentCellDirtyStateChanged
        AddHandler UsedMods_DataGridView.EditingControlShowing, AddressOf UsedMods_DataGridView_EditingControlShowing

        ' Initialize the FormResizer
        formResizer = New FormResizer(Me)

        ' Set AutoScroll to true for resizing
        Me.AutoScroll = True
    End Sub

    Private Sub UnusedMods_DataGridView_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs)
        If UnusedMods_DataGridView.IsCurrentCellDirty Then
            UnusedMods_DataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    ' CellValueChanged handler to handle item value changes
    Private Sub UnusedMods_DataGridView_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
        If e.ColumnIndex = UnusedMods_DataGridView.Columns("UnusedMods_DataGridView_Item_Column").Index Then
            Dim itemValue As String = UnusedMods_DataGridView.Rows(e.RowIndex).Cells("UnusedMods_DataGridView_Item_Column").Value?.ToString()
            Dim validCategories As List(Of String) = CategoryAndItemsManager.GetCategoryForItem(itemValue)

            ' Get the Category ComboBox cell
            Dim categoryCell As DataGridViewComboBoxCell = CType(UnusedMods_DataGridView.Rows(e.RowIndex).Cells("UnusedMods_DataGridView_Category_Column"), DataGridViewComboBoxCell)

            ' Clear and add unique categories (remove duplicates)
            categoryCell.Items.Clear()
            categoryCell.Items.AddRange(validCategories.Distinct().ToArray())

            ' Optionally set the first valid category as the default
            If validCategories.Count > 0 Then
                categoryCell.Value = validCategories.First()
            End If
        End If
    End Sub

    ' Handling the EditingControlShowing event to adjust the combo box options when editing the category
    Private Sub UnusedMods_DataGridView_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
        If UnusedMods_DataGridView.CurrentCell.ColumnIndex = UnusedMods_DataGridView.Columns("UnusedMods_DataGridView_Category_Column").Index Then
            Dim comboBox As ComboBox = TryCast(e.Control, ComboBox)
            If comboBox IsNot Nothing Then
                Dim itemValue As String = UnusedMods_DataGridView.Rows(UnusedMods_DataGridView.CurrentCell.RowIndex).Cells("UnusedMods_DataGridView_Item_Column").Value?.ToString()
                Dim validCategories As List(Of String) = CategoryAndItemsManager.GetCategoryForItem(itemValue)

                ' Ensure categories are populated
                If validCategories IsNot Nothing AndAlso validCategories.Count > 0 Then
                    ' Clear items first, then add new ones
                    comboBox.Items.Clear()
                    comboBox.Items.AddRange(validCategories.Distinct().ToArray())

                    ' Set the selected value if available
                    Dim currentCategory As String = UnusedMods_DataGridView.Rows(UnusedMods_DataGridView.CurrentCell.RowIndex).Cells("UnusedMods_DataGridView_Category_Column").Value?.ToString()
                    If Not String.IsNullOrEmpty(currentCategory) AndAlso validCategories.Contains(currentCategory) Then
                        comboBox.SelectedItem = currentCategory
                    Else
                        ' If no valid match, set to the first valid category
                        comboBox.SelectedItem = validCategories.First()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub UnusedMods_DataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles UnusedMods_DataGridView.DataError
        e.Cancel = True
    End Sub

    Private Sub UsedMods_DataGridView_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs)
        If UsedMods_DataGridView.IsCurrentCellDirty Then
            UsedMods_DataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    ' CellValueChanged handler to handle item value changes
    Private Sub UsedMods_DataGridView_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
        If e.ColumnIndex = UsedMods_DataGridView.Columns("UsedMods_DataGridView_Item_Column").Index Then
            Dim itemValue As String = UsedMods_DataGridView.Rows(e.RowIndex).Cells("UsedMods_DataGridView_Item_Column").Value?.ToString()
            Dim validCategories As List(Of String) = CategoryAndItemsManager.GetCategoryForItem(itemValue)

            ' Get the Category ComboBox cell
            Dim categoryCell As DataGridViewComboBoxCell = CType(UsedMods_DataGridView.Rows(e.RowIndex).Cells("UsedMods_DataGridView_Category_Column"), DataGridViewComboBoxCell)

            ' Clear and add unique categories (remove duplicates)
            categoryCell.Items.Clear()
            categoryCell.Items.AddRange(validCategories.Distinct().ToArray())

            ' Optionally set the first valid category as the default
            If validCategories.Count > 0 Then
                categoryCell.Value = validCategories.First()
            End If
        End If
    End Sub

    ' Handling the EditingControlShowing event to adjust the combo box options when editing the category
    Private Sub UsedMods_DataGridView_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
        If UsedMods_DataGridView.CurrentCell.ColumnIndex = UsedMods_DataGridView.Columns("UsedMods_DataGridView_Category_Column").Index Then
            Dim comboBox As ComboBox = TryCast(e.Control, ComboBox)
            If comboBox IsNot Nothing Then
                Dim itemValue As String = UsedMods_DataGridView.Rows(UsedMods_DataGridView.CurrentCell.RowIndex).Cells("UsedMods_DataGridView_Item_Column").Value?.ToString()
                Dim validCategories As List(Of String) = CategoryAndItemsManager.GetCategoryForItem(itemValue)

                ' Ensure categories are populated
                If validCategories IsNot Nothing AndAlso validCategories.Count > 0 Then
                    ' Clear items first, then add new ones
                    comboBox.Items.Clear()
                    comboBox.Items.AddRange(validCategories.Distinct().ToArray())

                    ' Set the selected value if available
                    Dim currentCategory As String = UsedMods_DataGridView.Rows(UsedMods_DataGridView.CurrentCell.RowIndex).Cells("UsedMods_DataGridView_Category_Column").Value?.ToString()
                    If Not String.IsNullOrEmpty(currentCategory) AndAlso validCategories.Contains(currentCategory) Then
                        comboBox.SelectedItem = currentCategory
                    Else
                        ' If no valid match, set to the first valid category
                        comboBox.SelectedItem = validCategories.First()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub UsedMods_DataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles UsedMods_DataGridView.DataError
        e.Cancel = True
    End Sub


    Private Sub Themes_CreateTheme_Button_Click(sender As Object, e As EventArgs) Handles Themes_CreateTheme_Button.Click
        Dim createOrDuplicateOption As String = "createTheme"
        Dim form4 As New Form4_CreateOrDuplicateTheme()
        form4.currentGlobalTheme = currentGlobalTheme
        form4.createOrDuplicateOption = createOrDuplicateOption
        form4.ShowDialog()
        If Not String.IsNullOrEmpty(form4.newThemeName) Then
            If Not Themes_ListBox.Items.Contains(form4.newThemeName) Then
                Class3.ThemeManager.CreateTheme(form4.newThemeName, createOrDuplicateOption, "", themesDictionary, Themes_ListBox,
                                                Themes_GlobalTheme_ComboBox, Themes_ProfileSpecificThemes_DataGridView)
            Else
                MessageBox.Show("A theme with the name you entered already exists!")
            End If
        Else
        End If
    End Sub

    Private Sub Themes_DuplicateTheme_Button_Click(sender As Object, e As EventArgs) Handles Themes_DuplicateTheme_Button.Click
        Dim createOrDuplicateOption As String = "duplicateTheme"
        Dim themeToDuplicate As String = Themes_ListBox.SelectedItem.ToString()
        Dim form4 As New Form4_CreateOrDuplicateTheme()
        form4.currentGlobalTheme = currentGlobalTheme
        form4.createOrDuplicateOption = createOrDuplicateOption
        form4.themeToDuplicate = themeToDuplicate
        form4.ShowDialog()
        If Not String.IsNullOrEmpty(form4.newThemeName) Then
            If Not Themes_ListBox.Items.Contains(form4.newThemeName) Then
                Class3.ThemeManager.CreateTheme(form4.newThemeName, createOrDuplicateOption, themeToDuplicate, themesDictionary, Themes_ListBox,
                                                Themes_GlobalTheme_ComboBox, Themes_ProfileSpecificThemes_DataGridView)
            Else
                MessageBox.Show("A theme with the name you entered already exists!")
            End If
        End If
    End Sub

    Private Sub Themes_DeleteTheme_Button_Click(sender As Object, e As EventArgs) Handles Themes_DeleteTheme_Button.Click
        Dim currentlySelectedTheme As String = Themes_ListBox.SelectedItem.ToString()
        Dim tempString1 As String = "Are you sure you want to delete current theme? Once deleted, it cannot be undone: " & vbCrLf & currentlySelectedTheme
        Dim confirmDeleteTheme As DialogResult = MessageBox.Show(tempString1, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmDeleteTheme = DialogResult.Yes Then
            Dim currentThemeDirectoryPathFile = themesDirectoryPath & "\" & currentlySelectedTheme & ".json"
            If File.Exists(currentThemeDirectoryPathFile) Then
                My.Computer.FileSystem.DeleteFile(currentThemeDirectoryPathFile)
            End If
            MessageBox.Show("Deleted theme: " & Themes_ListBox.SelectedItem)
            If themesDictionary.ContainsKey(currentlySelectedTheme) Then
                themesDictionary.Remove(currentlySelectedTheme)
            End If
            Themes_ListBox.Items.Remove(Themes_ListBox.SelectedItem)
            Themes_GlobalTheme_ComboBox.Items.Remove(currentlySelectedTheme)
            'If Themes_GlobalTheme_ComboBox.SelectedItem = currentlySelectedTheme Then
            'Themes_GlobalTheme_ComboBox.SelectedIndex = 0
            'End If
            If Themes_GlobalTheme_ComboBox.SelectedItem Is Nothing Then
                Themes_GlobalTheme_ComboBox.SelectedItem = "phd2mm_light"
            End If
            If Themes_ListBox.Items.Count > 0 Then
                Themes_ListBox.SelectedIndex = 0
            End If


            ' Now, replace the deleted theme with an empty string in the DataGridView ComboBox column
            For Each row As DataGridViewRow In Themes_ProfileSpecificThemes_DataGridView.Rows
                Dim comboBoxCell As DataGridViewComboBoxCell = CType(row.Cells("Themes_ProfileSpecificThemes_DataGridView_Theme_Column"), DataGridViewComboBoxCell)

                ' Check if the theme in the ComboBox cell matches the selected theme to delete
                If comboBoxCell.Value IsNot Nothing AndAlso comboBoxCell.Value.ToString() = currentlySelectedTheme Then
                    ' Replace the value with an empty string
                    comboBoxCell.Value = ""
                End If
            Next
            Dim themeDataGridViewComboBoxColumn As DataGridViewComboBoxColumn = Themes_ProfileSpecificThemes_DataGridView.Columns("Themes_ProfileSpecificThemes_DataGridView_Theme_Column")
            themeDataGridViewComboBoxColumn.Items.Remove(currentlySelectedTheme)
        End If
    End Sub

    Private Sub Themes_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Themes_ListBox.SelectedIndexChanged
        If Themes_ListBox.SelectedItem IsNot Nothing Then
            Dim selectedThemeName As String = Themes_ListBox.SelectedItem.ToString()
            Dim selectedTheme As Class3.ThemeInfo = themesDictionary(selectedThemeName)
            Themes_ThemeName_Label.Text = selectedTheme.ThemeName
            Themes_ThemeImage_TextBox.Text = selectedTheme.ThemeImagePath
            Themes_Form_BackColor_TextBox.Text = selectedTheme.Form_BackColor
            Themes_Form_ForeColor_TextBox.Text = selectedTheme.Form_ForeColor
            Themes_TabControl_BackColor_TextBox.Text = selectedTheme.TabControl_BackColor
            Themes_TabControl_ForeColor_TextBox.Text = selectedTheme.TabControl_ForeColor
            Themes_TabPage_BackColor_TextBox.Text = selectedTheme.TabPage_BackColor
            Themes_TabPage_ForeColor_TextBox.Text = selectedTheme.TabPage_ForeColor
            Themes_Label_BackColor_TextBox.Text = selectedTheme.Label_BackColor
            Themes_Label_ForeColor_TextBox.Text = selectedTheme.Label_ForeColor
            Themes_TextBox_BackColor_TextBox.Text = selectedTheme.TextBox_BackColor
            Themes_TextBox_ForeColor_TextBox.Text = selectedTheme.TextBox_ForeColor
            Themes_ComboBox_BackColor_TextBox.Text = selectedTheme.ComboBox_BackColor
            Themes_ComboBox_ForeColor_TextBox.Text = selectedTheme.ComboBox_ForeColor
            Themes_Button_BackColor_TextBox.Text = selectedTheme.Button_BackColor
            Themes_Button_ForeColor_TextBox.Text = selectedTheme.Button_ForeColor
            Themes_ListBox_BackColor_TextBox.Text = selectedTheme.ListBox_BackColor
            Themes_ListBox_ForeColor_TextBox.Text = selectedTheme.ListBox_ForeColor
            Themes_GroupBox_BackColor_TextBox.Text = selectedTheme.GroupBox_BackColor
            Themes_GroupBox_ForeColor_TextBox.Text = selectedTheme.GroupBox_ForeColor
            Themes_DataGridView_BackColor_TextBox.Text = selectedTheme.DataGridView_BackColor
            Themes_DataGridView_ForeColor_TextBox.Text = selectedTheme.DataGridView_ForeColor
            Themes_DGVGrid_Color_TextBox.Text = selectedTheme.DGVGrid_Color
            Themes_DGVColumnHeader_BackColor_TextBox.Text = selectedTheme.DGVColumnHeader_BackColor
            Themes_DGVColumnHeader_ForeColor_TextBox.Text = selectedTheme.DGVColumnHeader_ForeColor
            Themes_DGVRowHeader_BackColor_TextBox.Text = selectedTheme.DGVRowHeader_BackColor
            Themes_DGVRowHeader_ForeColor_TextBox.Text = selectedTheme.DGVRowHeader_ForeColor
            Themes_DGVDefaultCell_BackColor_TextBox.Text = selectedTheme.DGVDefaultCell_BackColor
            Themes_DGVDefaultCell_ForeColor_TextBox.Text = selectedTheme.DGVDefaultCell_ForeColor
            Themes_DGVAlternatingRows_BackColor_TextBox.Text = selectedTheme.DGVAlternatingRows_BackColor
            Themes_DGVAlternatingRows_ForeColor_TextBox.Text = selectedTheme.DGVAlternatingRows_ForeColor

            ' Update PictureBox colors (BackColor)
            Themes_Form_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.Form_BackColor)
            Themes_Form_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.Form_ForeColor)
            Themes_TabControl_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.TabControl_BackColor)
            Themes_TabControl_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.TabControl_ForeColor)
            Themes_TabPage_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.TabPage_BackColor)
            Themes_TabPage_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.TabPage_ForeColor)
            Themes_Label_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.Label_BackColor)
            Themes_Label_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.Label_ForeColor)
            Themes_TextBox_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.TextBox_BackColor)
            Themes_TextBox_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.TextBox_ForeColor)
            Themes_ComboBox_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.ComboBox_BackColor)
            Themes_ComboBox_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.ComboBox_ForeColor)
            Themes_Button_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.Button_BackColor)
            Themes_Button_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.Button_ForeColor)
            Themes_ListBox_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.ListBox_BackColor)
            Themes_ListBox_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.ListBox_ForeColor)
            Themes_GroupBox_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.GroupBox_BackColor)
            Themes_GroupBox_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.GroupBox_ForeColor)
            Themes_DataGridView_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DataGridView_BackColor)
            Themes_DataGridView_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DataGridView_ForeColor)
            Themes_DGVGrid_Color_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DGVGrid_Color)
            Themes_DGVColumnHeader_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DGVColumnHeader_BackColor)
            Themes_DGVColumnHeader_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DGVColumnHeader_ForeColor)
            Themes_DGVRowHeader_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DGVRowHeader_BackColor)
            Themes_DGVRowHeader_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DGVRowHeader_ForeColor)
            Themes_DGVDefaultCell_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DGVDefaultCell_BackColor)
            Themes_DGVDefaultCell_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DGVDefaultCell_ForeColor)
            Themes_DGVAlternatingRows_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DGVAlternatingRows_BackColor)
            Themes_DGVAlternatingRows_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DGVAlternatingRows_ForeColor)
        End If
        DisableControlsInTabPage()
    End Sub
    Private Sub DisableControlsInTabPage()
        ' Check if an item is selected in the ListBox
        If Themes_ListBox.SelectedItem IsNot Nothing Then
            ' Check if the selected value in the ListBox is "phd2mm_light" or "phd2mm_dark"
            If Themes_ListBox.SelectedItem.ToString() = "phd2mm_light" OrElse
                Themes_ListBox.SelectedItem.ToString() = "phd2mm_dark" Then
                ' Loop through all controls in the TabPage
                For Each ctrl As Control In Themes_TabPage.Controls
                    ' Check if the control is a TextBox and disable it
                    If TypeOf ctrl Is TextBox Then
                        CType(ctrl, TextBox).Enabled = False
                    ElseIf TypeOf ctrl Is Button Then
                        ' Exclude "Themes_CreateTheme_Button" and "Themes_DuplicateTheme_Button" from being disabled
                        If Not (ctrl.Name = "Themes_CreateTheme_Button" Or ctrl.Name = "Themes_DuplicateTheme_Button") Then
                            CType(ctrl, Button).Enabled = False
                        End If
                    ElseIf TypeOf ctrl Is PictureBox Then
                        CType(ctrl, PictureBox).Enabled = False
                    End If
                Next
            Else
                ' Optionally, re-enable the controls if the condition is not met
                For Each ctrl As Control In Themes_TabPage.Controls
                    If TypeOf ctrl Is TextBox Then
                        CType(ctrl, TextBox).Enabled = True
                    ElseIf TypeOf ctrl Is Button Then
                        ' Re-enable the excluded buttons (Create and Duplicate)
                        CType(ctrl, Button).Enabled = True
                    ElseIf TypeOf ctrl Is PictureBox Then
                        CType(ctrl, PictureBox).Enabled = True
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub Themes_TabPage_Enter(sender As Object, e As EventArgs) Handles Themes_TabPage.Enter
        ' Loop through all PictureBox controls in the TabPage
        For Each ctrl As Control In Themes_TabPage.Controls
            If TypeOf ctrl Is PictureBox Then
                ' Remove the event handler if it already exists
                RemoveHandler CType(ctrl, PictureBox).Click, AddressOf PickColorPictureBox_Click

                ' Add handler for PictureBox click event
                AddHandler CType(ctrl, PictureBox).Click, AddressOf PickColorPictureBox_Click
            End If
        Next
    End Sub
    Private Sub PickColorPictureBox_Click(sender As Object, e As EventArgs)
        ' Get the clicked PictureBox
        Dim clickedPictureBox As PictureBox = CType(sender, PictureBox)

        ' Set the ColorDialog's initial color to the current PictureBox color
        ColorDialog1.Color = clickedPictureBox.BackColor

        ' Show the ColorDialog to pick a color
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            ' Set the selected color as the background color of the PictureBox
            clickedPictureBox.BackColor = ColorDialog1.Color

            ' Find the corresponding TextBox by replacing "_PictureBox" with "_TextBox" in the PictureBox's name
            Dim textBox As TextBox = CType(Themes_TabPage.Controls(clickedPictureBox.Name.Replace("_PictureBox", "_TextBox")), TextBox)

            ' Set the hex code of the selected color into the TextBox
            textBox.Text = "#" & ColorDialog1.Color.ToArgb().ToString("X8").Substring(2)
        End If
    End Sub



    Private Sub Themes_SaveChanges_Button_Click(sender As Object, e As EventArgs) Handles Themes_SaveChanges_Button.Click
        ' Check for valid hex codes
        If Not IsValidHexColor(Themes_Form_BackColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_Form_ForeColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_TabControl_BackColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_TabControl_ForeColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_TabPage_BackColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_TabPage_ForeColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_Label_BackColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_Label_ForeColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_TextBox_BackColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_TextBox_ForeColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_ComboBox_BackColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_ComboBox_ForeColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_Button_BackColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_Button_ForeColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_ListBox_BackColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_ListBox_ForeColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_GroupBox_BackColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_GroupBox_ForeColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_DataGridView_BackColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_DataGridView_ForeColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_DGVGrid_Color_TextBox.Text) Or
       Not IsValidHexColor(Themes_DGVColumnHeader_BackColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_DGVColumnHeader_ForeColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_DGVRowHeader_BackColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_DGVRowHeader_ForeColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_DGVDefaultCell_BackColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_DGVDefaultCell_ForeColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_DGVAlternatingRows_BackColor_TextBox.Text) Or
       Not IsValidHexColor(Themes_DGVAlternatingRows_ForeColor_TextBox.Text) Then
            MessageBox.Show("One or more hex color codes are invalid." & vbCrLf &
                "Only 6-digit hex color codes are allowed in the format '#RRGGBB'." & vbCrLf &
                "Valid examples: #000000 (black), #FFFFFF (white), or #FF5733 (a shade of red)." & vbCrLf &
                "Please ensure your color inputs follow the correct format and try again.",
                "Invalid Hex Color Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim tempString1 As String = "Are you sure you want to save the changes to the current theme?" & vbCrLf & Themes_ListBox.SelectedItem
        Dim confirmSaveTheme As DialogResult = MessageBox.Show(tempString1, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmSaveTheme = DialogResult.Yes Then
            Dim selectedThemeName As String = Themes_ListBox.SelectedItem.ToString()
            Dim selectedTheme As Class3.ThemeInfo = themesDictionary(selectedThemeName)
            Dim tempThemeImage = Themes_ThemeImage_TextBox.Text.Replace("\", "/")
            Themes_ThemeImage_TextBox.Text = tempThemeImage
            selectedTheme.ThemeName = Themes_ThemeName_Label.Text
            selectedTheme.ThemeImagePath = Themes_ThemeImage_TextBox.Text
            selectedTheme.Form_BackColor = Themes_Form_BackColor_TextBox.Text
            selectedTheme.Form_ForeColor = Themes_Form_ForeColor_TextBox.Text
            selectedTheme.TabControl_BackColor = Themes_TabControl_BackColor_TextBox.Text
            selectedTheme.TabControl_ForeColor = Themes_TabControl_ForeColor_TextBox.Text
            selectedTheme.TabPage_BackColor = Themes_TabPage_BackColor_TextBox.Text
            selectedTheme.TabPage_ForeColor = Themes_TabPage_ForeColor_TextBox.Text
            selectedTheme.Label_BackColor = Themes_Label_BackColor_TextBox.Text
            selectedTheme.Label_ForeColor = Themes_Label_ForeColor_TextBox.Text
            selectedTheme.TextBox_BackColor = Themes_TextBox_BackColor_TextBox.Text
            selectedTheme.TextBox_ForeColor = Themes_TextBox_ForeColor_TextBox.Text
            selectedTheme.ComboBox_BackColor = Themes_ComboBox_BackColor_TextBox.Text
            selectedTheme.ComboBox_ForeColor = Themes_ComboBox_ForeColor_TextBox.Text
            selectedTheme.Button_BackColor = Themes_Button_BackColor_TextBox.Text
            selectedTheme.Button_ForeColor = Themes_Button_ForeColor_TextBox.Text
            selectedTheme.ListBox_BackColor = Themes_ListBox_BackColor_TextBox.Text
            selectedTheme.ListBox_ForeColor = Themes_ListBox_ForeColor_TextBox.Text
            selectedTheme.GroupBox_BackColor = Themes_GroupBox_BackColor_TextBox.Text
            selectedTheme.GroupBox_ForeColor = Themes_GroupBox_ForeColor_TextBox.Text
            selectedTheme.DataGridView_BackColor = Themes_DataGridView_BackColor_TextBox.Text
            selectedTheme.DataGridView_ForeColor = Themes_DataGridView_ForeColor_TextBox.Text
            selectedTheme.DGVGrid_Color = Themes_DGVGrid_Color_TextBox.Text
            selectedTheme.DGVColumnHeader_BackColor = Themes_DGVColumnHeader_BackColor_TextBox.Text
            selectedTheme.DGVColumnHeader_ForeColor = Themes_DGVColumnHeader_ForeColor_TextBox.Text
            selectedTheme.DGVRowHeader_BackColor = Themes_DGVRowHeader_BackColor_TextBox.Text
            selectedTheme.DGVRowHeader_ForeColor = Themes_DGVRowHeader_ForeColor_TextBox.Text
            selectedTheme.DGVDefaultCell_BackColor = Themes_DGVDefaultCell_BackColor_TextBox.Text
            selectedTheme.DGVDefaultCell_ForeColor = Themes_DGVDefaultCell_ForeColor_TextBox.Text
            selectedTheme.DGVAlternatingRows_BackColor = Themes_DGVAlternatingRows_BackColor_TextBox.Text
            selectedTheme.DGVAlternatingRows_ForeColor = Themes_DGVAlternatingRows_ForeColor_TextBox.Text

            themesDictionary(selectedThemeName) = selectedTheme

            If currentGlobalTheme.ThemeName = selectedThemeName Then
                currentGlobalTheme = selectedTheme
            End If
            Dim currenProfileThemeName As String = ProfilesList_ComboBox.SelectedItem.ToString()
            Dim currentProfileSpecificTheme As Class3.ProfileSpecificTheme = profileSpecificThemesDictionary(currenProfileThemeName)
            If String.IsNullOrEmpty(currentProfileSpecificTheme.ThemeName) Then
                Class3.ThemeManager.ApplyThemeToForm(Me, currentGlobalTheme)
                Class3.ThemeManager.ApplyImageToPictureBox(ProfileImage_PictureBox, currentGlobalTheme)
            Else
                Class3.ThemeManager.ApplyThemeToForm(Me, themesDictionary(currentProfileSpecificTheme.ThemeName))
                Class3.ThemeManager.ApplyImageToPictureBox(ProfileImage_PictureBox, themesDictionary(currentProfileSpecificTheme.ThemeName))
            End If
            Class3.ThemeManager.OverwriteSingleThemeFile(selectedTheme, themesDirectoryPath)

            ' Update PictureBox colors (BackColor)
            Themes_Form_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.Form_BackColor)
            Themes_Form_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.Form_ForeColor)
            Themes_TabControl_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.TabControl_BackColor)
            Themes_TabControl_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.TabControl_ForeColor)
            Themes_TabPage_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.TabPage_BackColor)
            Themes_TabPage_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.TabPage_ForeColor)
            Themes_Label_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.Label_BackColor)
            Themes_Label_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.Label_ForeColor)
            Themes_TextBox_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.TextBox_BackColor)
            Themes_TextBox_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.TextBox_ForeColor)
            Themes_ComboBox_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.ComboBox_BackColor)
            Themes_ComboBox_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.ComboBox_ForeColor)
            Themes_Button_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.Button_BackColor)
            Themes_Button_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.Button_ForeColor)
            Themes_ListBox_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.ListBox_BackColor)
            Themes_ListBox_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.ListBox_ForeColor)
            Themes_GroupBox_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.GroupBox_BackColor)
            Themes_GroupBox_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.GroupBox_ForeColor)
            Themes_DataGridView_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DataGridView_BackColor)
            Themes_DataGridView_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DataGridView_ForeColor)
            Themes_DGVGrid_Color_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DGVGrid_Color)
            Themes_DGVColumnHeader_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DGVColumnHeader_BackColor)
            Themes_DGVColumnHeader_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DGVColumnHeader_ForeColor)
            Themes_DGVRowHeader_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DGVRowHeader_BackColor)
            Themes_DGVRowHeader_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DGVRowHeader_ForeColor)
            Themes_DGVDefaultCell_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DGVDefaultCell_BackColor)
            Themes_DGVDefaultCell_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DGVDefaultCell_ForeColor)
            Themes_DGVAlternatingRows_BackColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DGVAlternatingRows_BackColor)
            Themes_DGVAlternatingRows_ForeColor_PictureBox.BackColor = ColorTranslator.FromHtml(selectedTheme.DGVAlternatingRows_ForeColor)
        End If
    End Sub

    Private Function IsValidHexColor(hex As String) As Boolean
        Try
            ' Ensure the hex code starts with "#" and is followed by exactly 6 hex digits
            If hex.StartsWith("#") Then
                ' Remove "#" and check if it's a valid 6-digit hex code
                hex = hex.Substring(1)
                If hex.Length = 6 AndAlso hex.All(Function(c) Char.IsDigit(c) OrElse (c >= "A"c AndAlso c <= "F"c) OrElse (c >= "a"c AndAlso c <= "f"c)) Then
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub Themes_GlobalTheme_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Themes_GlobalTheme_ComboBox.SelectedIndexChanged
        ' Ensure that an item is selected in the Global Theme ComboBox
        If Themes_GlobalTheme_ComboBox.SelectedItem IsNot Nothing Then
            Dim selectedThemeName As String = Themes_GlobalTheme_ComboBox.SelectedItem.ToString()

            ' Check if the selected theme exists in the themesDictionary
            If themesDictionary.ContainsKey(selectedThemeName) Then
                currentGlobalTheme = themesDictionary(selectedThemeName)
            Else
                ' Optionally, handle the case where the theme doesn't exist in the dictionary
                ' For example, you could set to a default theme
                currentGlobalTheme = themesDictionary("defaultTheme") ' Set to a default theme, if needed
            End If
        End If

        ' Ensure that an item is selected in the Profile List ComboBox
        If ProfilesList_ComboBox.SelectedItem IsNot Nothing Then
            Dim currenProfileThemeName As String = ProfilesList_ComboBox.SelectedItem.ToString()

            ' Ensure the profile exists in the dictionary
            If profileSpecificThemesDictionary.ContainsKey(currenProfileThemeName) Then
                Dim currentProfileSpecificTheme As Class3.ProfileSpecificTheme = profileSpecificThemesDictionary(currenProfileThemeName)

                ' Apply the correct theme based on the profile's theme or the global theme
                If String.IsNullOrEmpty(currentProfileSpecificTheme.ThemeName) Then
                    Class3.ThemeManager.ApplyThemeToForm(Me, currentGlobalTheme)
                    Class3.ThemeManager.ApplyImageToPictureBox(ProfileImage_PictureBox, currentGlobalTheme)
                Else
                    ' Check if the profile's specific theme exists in the themesDictionary
                    If themesDictionary.ContainsKey(currentProfileSpecificTheme.ThemeName) Then
                        Class3.ThemeManager.ApplyThemeToForm(Me, themesDictionary(currentProfileSpecificTheme.ThemeName))
                        Class3.ThemeManager.ApplyImageToPictureBox(ProfileImage_PictureBox, themesDictionary(currentProfileSpecificTheme.ThemeName))
                    Else
                        ' If the profile's theme doesn't exist, apply the global theme
                        Class3.ThemeManager.ApplyThemeToForm(Me, currentGlobalTheme)
                        Class3.ThemeManager.ApplyImageToPictureBox(ProfileImage_PictureBox, currentGlobalTheme)
                    End If
                End If
            Else
                ' Optionally handle the case where the profile doesn't exist in the dictionary
                Class3.ThemeManager.ApplyThemeToForm(Me, currentGlobalTheme)
                Class3.ThemeManager.ApplyImageToPictureBox(ProfileImage_PictureBox, currentGlobalTheme)
            End If
        Else
            ' Optionally handle the case where no profile is selected in the ProfilesList_ComboBox
            Class3.ThemeManager.ApplyThemeToForm(Me, currentGlobalTheme)
            Class3.ThemeManager.ApplyImageToPictureBox(ProfileImage_PictureBox, currentGlobalTheme)
        End If
    End Sub



    Private Sub Themes_ProfileSpecificThemes_DataGridView_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles Themes_ProfileSpecificThemes_DataGridView.CurrentCellDirtyStateChanged
        ' Check if the current cell is a ComboBox cell (where user selected a theme)
        If Themes_ProfileSpecificThemes_DataGridView.IsCurrentCellDirty Then
            ' Commit the edit to trigger the CellValueChanged event
            Themes_ProfileSpecificThemes_DataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub Themes_ProfileSpecificThemes_DataGridView_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Themes_ProfileSpecificThemes_DataGridView.CellValueChanged
        ' Check if the row index and column index are valid
        If e.RowIndex >= 0 AndAlso e.RowIndex < Themes_ProfileSpecificThemes_DataGridView.Rows.Count AndAlso e.ColumnIndex >= 0 Then
            ' Check if the edited column is the theme column (ComboBox column)
            If e.ColumnIndex = Themes_ProfileSpecificThemes_DataGridView_Theme_Column.Index Then
                ' Ensure the cell value is not null or DBNull
                Dim selectedThemeName As String = Themes_ProfileSpecificThemes_DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value?.ToString()
                ' Get the profile name from the current row (ensure this column index is correct)
                Dim profileName As String = Themes_ProfileSpecificThemes_DataGridView.Rows(e.RowIndex).Cells("Themes_ProfileSpecificThemes_DataGridView_Profile_Column").Value?.ToString()

                ' Make sure the profile name is valid
                If Not String.IsNullOrEmpty(profileName) AndAlso profileSpecificThemesDictionary.ContainsKey(profileName) Then
                    ' Create a new ProfileSpecificTheme object with the profile name and selected theme
                    Dim updatedProfileSpecificTheme As New Class3.ProfileSpecificTheme(profileName, selectedThemeName)

                    ' Update the profileSpecificThemesDictionary with the new theme for the profile
                    profileSpecificThemesDictionary(profileName) = updatedProfileSpecificTheme

                    ' If the profile selected in ProfilesList_ComboBox matches, apply the theme
                    If profileName = ProfilesList_ComboBox.SelectedItem?.ToString() Then
                        If String.IsNullOrEmpty(selectedThemeName) Then
                            Class3.ThemeManager.ApplyThemeToForm(Me, currentGlobalTheme)
                            Class3.ThemeManager.ApplyImageToPictureBox(ProfileImage_PictureBox, currentGlobalTheme)
                        Else
                            ' Make sure the theme exists in the dictionary before applying
                            If themesDictionary.ContainsKey(selectedThemeName) Then
                                Class3.ThemeManager.ApplyThemeToForm(Me, themesDictionary(selectedThemeName))
                                Class3.ThemeManager.ApplyImageToPictureBox(ProfileImage_PictureBox, themesDictionary(selectedThemeName))
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Themes_ThemeImage_Browse_Button_Click(sender As Object, e As EventArgs) Handles Themes_ThemeImage_Browse_Button.Click
        If Themes_ThemeImage_OpenFileDialog.ShowDialog() = DialogResult.OK Then
            Dim themeImagePath As String = Themes_ThemeImage_OpenFileDialog.FileName
            themeImagePath = themeImagePath.Replace("\", "/")
            Themes_ThemeImage_TextBox.Text = themeImagePath
        End If
    End Sub
End Class
