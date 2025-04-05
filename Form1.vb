Imports System.ComponentModel
Imports System.Diagnostics.Tracing
Imports System.Globalization
Imports System.IO
Imports System.Reflection.Emit
Imports System.Text.Json
Imports System.Text.Json.Nodes
Imports phd2mm.Class1
Imports phd2mm.Class2

Public Class Form1_phd2mm

    Public currentDirectoryPath As String = Directory.GetCurrentDirectory()
    Public profileDirectoryPath As String = currentDirectoryPath & "\phd2mm_profiles"
    Public modDirectoryPath As String = currentDirectoryPath & "\phd2mm_mods"
    Public settingsDirectoryPath As String = currentDirectoryPath & "\phd2mm_settings"
    Public settingsTextFilePath As String = settingsDirectoryPath & "\phd2mm_settings.txt"
    Public registryTextFilePath As String = settingsDirectoryPath & "\phd2mm_registry.json"
    Public modsRegistryDictionary As New Dictionary(Of String, Class1.ModInfo)()
    Public usedModsOriginalDictionary As New Dictionary(Of String, Class1.ModInfo)()
    Public allModsOriginalDictionary As New Dictionary(Of String, Class1.ModInfo)()
    Public randomizationMode As String = "OnlyAddNoGuarantee"
    Public checkIfOptionOpened As Boolean = False

    Private Sub ToggleLightDarkMode_Button_Click(sender As Object, e As EventArgs) Handles ToggleLightDarkMode_Button.Click
        If Class1.ThemeManager.CurrentMode = "light" Then
            Class1.ThemeManager.CurrentMode = "dark"
        Else
            Class1.ThemeManager.CurrentMode = "light"
        End If
        ' Reapply the theme to the current form
        ThemeManager.ApplyTheme(Me)
        ' Optionally, you can also apply the theme to other open forms
        For Each f As Form In Application.OpenForms
            ThemeManager.ApplyTheme(f)
        Next
    End Sub



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
        If Not Directory.Exists(modDirectoryPath) Then
            My.Computer.FileSystem.CreateDirectory(modDirectoryPath)
        End If
        If Not Directory.Exists(settingsDirectoryPath) Then
            My.Computer.FileSystem.CreateDirectory(settingsDirectoryPath)
        End If

        Dim tempString1 As String = "current_hd2_data_directory: " & vbCrLf & "last_installed_profile: " & vbCrLf & "toggle_light_dark_mode: " & "light"
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
                    Class1.ThemeManager.CurrentMode = savedLightDarkMode
                    If Class1.ThemeManager.CurrentMode = "dark" Then
                        Class1.ThemeManager.CurrentMode = "dark"
                    Else
                        Class1.ThemeManager.CurrentMode = "light"
                    End If
                    Class1.ThemeManager.ApplyTheme(Me)
                Else
                    My.Computer.FileSystem.WriteAllText(settingsTextFilePath, tempString1, False)
                    Exit For
                End If
            Next
        Else
            My.Computer.FileSystem.WriteAllText(settingsTextFilePath, tempString1, False)
        End If

        If File.Exists(registryTextFilePath) Then
            Class1.RegistryEditor.ReadRegistry(modsRegistryDictionary, registryTextFilePath)
        Else
            ' If the file doesn't exist, create an empty JSON array
            My.Computer.FileSystem.WriteAllText(registryTextFilePath, "[]", False)
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
                Dim tempModFolderPathName As String = tempModInfo.Modfolderpathname
                Dim tempCategory As String = tempModInfo.Category
                Dim tempItem As String = tempModInfo.Item
                Dim tempDescription As String = tempModInfo.Description
                Dim tempRowIndex As Integer = UsedMods_DataGridView.RowCount
                UsedMods_DataGridView.Rows.Add(tempRowIndex, tempModFolderPathName, tempItem, tempCategory, tempDescription)
                usedModsInProfile.Add(tempModFolderPathName, tempModInfo)
            Next
        End If
        For Each modFolderPathName As String In allModsOriginalDictionary.Keys
            If Not usedModsInProfile.ContainsKey(modFolderPathName) Then
                Dim tempModInfo As ModInfo = allModsOriginalDictionary(modFolderPathName)
                Dim tempModFolderPathName As String = tempModInfo.Modfolderpathname
                Dim tempCategory As String = tempModInfo.Category
                Dim tempItem As String = tempModInfo.Item
                Dim tempDescription As String = tempModInfo.Description
                Dim tempRowIndex As Integer = UnusedMods_DataGridView.RowCount
                UnusedMods_DataGridView.Rows.Add(tempModFolderPathName, tempItem, tempCategory, tempDescription)
            End If
        Next
        UnusedMods_DataGridView.Sort(UnusedMods_DataGridView.Columns("UnusedMods_DataGridView_ModFolderPathName_Column"), System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Private Sub Form1_phd2mm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim tempString1 As String = "current_hd2_data_directory: " & Hd2DataPathPreview_TextBox.Text & vbCrLf &
        "last_installed_profile: " & LastInstalledProfile_Label.Text & vbCrLf &
        "toggle_light_dark_mode: " & ThemeManager.CurrentMode
        My.Computer.FileSystem.WriteAllText(settingsTextFilePath, tempString1, False)

        Class1.RegistryEditor.OverwriteRegistry(modsRegistryDictionary, registryTextFilePath)
    End Sub


    Private Sub BrowseHd2DataPath_Button_Click(sender As Object, e As EventArgs) Handles BrowseHd2DataPath_Button.Click
        If Hd2DataPath_FolderBrowserDialogue.ShowDialog() = DialogResult.OK Then
            Dim hd2DirectoryPath As String = Hd2DataPath_FolderBrowserDialogue.SelectedPath
            If Class1.DirectoryValidator.ValidateDirectory(hd2DirectoryPath) Then
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
                Dim tempModInfo As New Class1.ModInfo(modFolderPathNameLine, "Other", "Other", "none")
                If modsRegistryDictionary.ContainsKey(modFolderPathNameLine) Then
                    tempModInfo = modsRegistryDictionary(modFolderPathNameLine)
                    tempModInfo.Category = tempModInfo.Category
                    tempModInfo.Item = tempModInfo.Item
                    tempModInfo.Description = tempModInfo.Description
                End If
                Dim tempRowIndex As Integer = UsedMods_DataGridView.RowCount
                UsedMods_DataGridView.Rows.Add(UsedMods_DataGridView.RowCount, tempModInfo.Modfolderpathname, tempModInfo.Item, tempModInfo.Category, tempModInfo.Description)
                usedModsInProfile.Add(tempModInfo.Modfolderpathname, tempModInfo)
            Next
        End If
        For Each modFolderPathName As String In allModsOriginalDictionary.Keys
            If Not usedModsInProfile.ContainsKey(modFolderPathName) Then
                Dim tempModInfo As New Class1.ModInfo(modFolderPathName, "Other", "Other", "none")
                If modsRegistryDictionary.ContainsKey(modFolderPathName) Then
                    tempModInfo = modsRegistryDictionary(modFolderPathName)
                    tempModInfo.Category = tempModInfo.Category
                    tempModInfo.Item = tempModInfo.Item
                    tempModInfo.Description = tempModInfo.Description
                End If
                UnusedMods_DataGridView.Rows.Add(tempModInfo.Modfolderpathname, tempModInfo.Item, tempModInfo.Category, tempModInfo.Description)
            End If
        Next
        UnusedMods_DataGridView.Sort(UnusedMods_DataGridView.Columns("UnusedMods_DataGridView_ModFolderPathName_Column"), System.ComponentModel.ListSortDirection.Ascending)
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
                    selectedRow.Cells("UnusedMods_DataGridView_Item_Column").Value,
                    selectedRow.Cells("UnusedMods_DataGridView_Category_Column").Value,
                    selectedRow.Cells("UnusedMods_DataGridView_Description_Column").Value)
                UnusedMods_DataGridView.Rows.RemoveAt(e.RowIndex)
            End If
        End If

    End Sub
    Private Sub AddSelectedMod_Button_Click(sender As Object, e As EventArgs) Handles AddSelectedMod_Button.Click
        If UnusedMods_DataGridView.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = UnusedMods_DataGridView.SelectedRows(0)
            UsedMods_DataGridView.Rows.Add(UsedMods_DataGridView.RowCount,
                selectedRow.Cells("UnusedMods_DataGridView_ModFolderPathName_Column").Value,
                selectedRow.Cells("UnusedMods_DataGridView_Item_Column").Value,
                selectedRow.Cells("UnusedMods_DataGridView_Category_Column").Value,
                selectedRow.Cells("UnusedMods_DataGridView_Description_Column").Value)
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
                UnusedMods_DataGridView.Rows.Add(selectedRow.Cells("UsedMods_DataGridView_ModFolderPathName_Column").Value,
             selectedRow.Cells("UsedMods_DataGridView_Item_Column").Value,
              selectedRow.Cells("UsedMods_DataGridView_Category_Column").Value,
            selectedRow.Cells("UsedMods_DataGridView_Description_Column").Value)
                UsedMods_DataGridView.Rows.RemoveAt(e.RowIndex)
            End If
        End If
    End Sub
    Private Sub RemoveSelectedMod_Button_Click(sender As Object, e As EventArgs) Handles RemoveSelectedMod_Button.Click
        If UsedMods_DataGridView.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = UsedMods_DataGridView.SelectedRows(0)
            UnusedMods_DataGridView.Rows.Add(selectedRow.Cells("UsedMods_DataGridView_ModFolderPathName_Column").Value,
                selectedRow.Cells("UsedMods_DataGridView_Item_Column").Value,
                selectedRow.Cells("UsedMods_DataGridView_Category_Column").Value,
                selectedRow.Cells("UsedMods_DataGridView_Description_Column").Value)
            UsedMods_DataGridView.Rows.Remove(selectedRow)
        End If
    End Sub

    ' Saves all data inside the DataGridViews to the dictionaries as soon as the user finishes editing a cell
    Private Sub UsedMods_DataGridView_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles UsedMods_DataGridView.CellEndEdit
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' Ensure the edited row exists and has values
            Dim modfolderPathname As String = If(UsedMods_DataGridView.Rows(e.RowIndex).Cells("UsedMods_DataGridView_ModFolderPathName_Column").Value, "").ToString()
            Dim item As String = If(UsedMods_DataGridView.Rows(e.RowIndex).Cells("UsedMods_DataGridView_Item_Column").Value, "").ToString()
            Dim category As String = If(UsedMods_DataGridView.Rows(e.RowIndex).Cells("UsedMods_DataGridView_Category_Column").Value, "").ToString()
            Dim description As String = If(UsedMods_DataGridView.Rows(e.RowIndex).Cells("UsedMods_DataGridView_Description_Column").Value, "").ToString()

            If Not String.IsNullOrEmpty(modfolderPathname) AndAlso
           Not String.IsNullOrEmpty(category) AndAlso
           Not String.IsNullOrEmpty(item) AndAlso
           Not String.IsNullOrEmpty(description) Then

                Dim tempModInfo As New ModInfo(modfolderPathname, item, category, description)
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
            Dim category As String = If(UnusedMods_DataGridView.Rows(e.RowIndex).Cells("UnusedMods_DataGridView_Category_Column").Value, "").ToString()
            Dim item As String = If(UnusedMods_DataGridView.Rows(e.RowIndex).Cells("UnusedMods_DataGridView_Item_Column").Value, "").ToString()
            Dim description As String = If(UnusedMods_DataGridView.Rows(e.RowIndex).Cells("UnusedMods_DataGridView_Description_Column").Value, "").ToString()

            If Not String.IsNullOrEmpty(modfolderPathname) AndAlso
           Not String.IsNullOrEmpty(category) AndAlso
           Not String.IsNullOrEmpty(item) AndAlso
           Not String.IsNullOrEmpty(description) Then

                Dim tempModInfo As New ModInfo(modfolderPathname, item, category, description)
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
                form3.hd2DirectoryPath = Hd2DataPathPreview_TextBox.Text
                form3.modDirectoryPath = modDirectoryPath
                form3.profileName = ProfilesList_ComboBox.SelectedItem
                form3.selectedModsList = modList
                LastInstalledProfile_Label.Text = ProfilesList_ComboBox.SelectedItem
                Dim tempString2 As String = "current_hd2_data_directory: " & Hd2DataPathPreview_TextBox.Text & vbCrLf &
                    "last_installed_profile: " & ProfilesList_ComboBox.SelectedItem & vbCrLf &
                    "toggle_light_dark_mode: " & Class1.ThemeManager.CurrentMode
                My.Computer.FileSystem.WriteAllText(settingsTextFilePath, tempString2, False)
                form3.ShowDialog()
            End If
        End If
    End Sub

    Private Sub MoreInfo_Button_Click(sender As Object, e As EventArgs) Handles MoreInfo_Button.Click
        Dim form4 As New Form4_MoreInfo()
        form4.ShowDialog()
    End Sub


    Private Sub EnableModRandomization_Button_Click(sender As Object, e As EventArgs) Handles EnableModRandomization_Button.Click
        If EnableModRandomization_Button.Text = "Enable Mod Randomization" Then
            Dim tempString1 As String = "Are you sure you want to enable mod randomization?"
            Dim confirmModRandomizationOption As DialogResult = MessageBox.Show(tempString1, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirmModRandomizationOption = DialogResult.Yes Then
                ModRandomizationOptions_Button.Enabled = True
                RandomizeMods_Button.Enabled = True
                EnableModRandomization_Button.Text = "Disable Mod Randomization"
            End If
        Else
            ModRandomizationOptions_Button.Enabled = False
            RandomizeMods_Button.Enabled = False
            EnableModRandomization_Button.Text = "Enable Mod Randomization"
        End If
    End Sub

    Private Sub ModRandomizationOptions_Button_Click(sender As Object, e As EventArgs) Handles ModRandomizationOptions_Button.Click
        Dim form5 As New Form5_ModRandomizationOptions()
        form5.randomizationMode = randomizationMode
        form5.ShowDialog()
        If form5.confirm Then
            randomizationMode = form5.randomizationMode
            checkIfOptionOpened = True
        End If
    End Sub

    Private Sub RandomizeMods_Button_Click(sender As Object, e As EventArgs) Handles RandomizeMods_Button.Click
        If checkIfOptionOpened Then
            Class2.ModRandomizer.RandomizeMods(randomizationMode, allModsOriginalDictionary, UnusedMods_DataGridView, UsedMods_DataGridView)
        Else
            MessageBox.Show("Please select a mod randomization option first!")
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

        FormResizer = New FormResizer(Me)
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
End Class
