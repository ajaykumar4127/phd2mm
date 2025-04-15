Imports System.Data.Common
Imports System.Diagnostics.Tracing
Imports System.Globalization
Imports System.IO
Imports System.Reflection.Emit
Imports System.Text.Json
Imports System.Text.Json.Nodes
Imports phd2mm.Class3
Public Class Class1

    Public Class DirectoryInitializer
        Public Shared Sub InitializeDirectory(directoryPath As String)
            If Not Directory.Exists(directoryPath) Then
                My.Computer.FileSystem.CreateDirectory(directoryPath)
            End If
        End Sub

        Public Shared Sub InitializeFiles(filePath As String)
            If Not File.Exists(filePath) Then
                Using fs As FileStream = File.Create(filePath)
                    ' Optionally write some initial content to the file
                End Using
            End If
        End Sub
    End Class

    Public Class DirectoryValidator
        Public Shared Function ValidateDirectory(directoryPath As String) As Boolean
            If String.IsNullOrEmpty(directoryPath) OrElse String.IsNullOrWhiteSpace(directoryPath) Then
                MessageBox.Show("Invalid directory! Please locate your Helldivers 2 data folder." & vbCrLf &
                             "If it's bought on Steam, the path is usually: " & vbCrLf &
                             "YourSteamPath\Steam\steamapps\common\Helldivers 2\data")
                Return False
            Else
                ' Normalize directory path to use consistent forward slashes
                directoryPath = directoryPath.Replace("\", "/")

                ' Check if the directory ends with either "Helldivers 2/data"
                If directoryPath.EndsWith("Helldivers 2/data") Then
                    Return True
                Else
                    MessageBox.Show("Invalid directory! Please locate your Helldivers 2 data folder." & vbCrLf &
                                 "If it's bought on Steam, the path is usually: " & vbCrLf &
                                 "YourSteamPath\Steam\steamapps\common\Helldivers 2/data")
                    Return False
                End If
            End If
        End Function
    End Class

    Public Class ModUninstaller
        Public Shared Sub DeleteModsInThisDirectory(Hd2DirectoryPath As String)
            Dim modPatchString As String = ".patch_"
            For Each oldModFile As String In Directory.GetFiles(Hd2DirectoryPath)
                If Path.GetFileName(oldModFile).Contains(modPatchString) Then
                    My.Computer.FileSystem.DeleteFile(oldModFile)
                End If
            Next
        End Sub
    End Class

    Public Class ModInfo
        Public Property Modfolderpathname As String
        Public Property ModName As String
        Public Property Item As String
        Public Property Category As String
        Public Property Description As String
        Public Property ImagePath As String
        Public Property DateAdded As String
        Public Property ModVersion As String
        Public Property ModLink As String
        Public Sub New(col1 As String, col2 As String, col3 As String, col4 As String,
                       col5 As String, col6 As String, col7 As String, col8 As String,
                       col9 As String)
            Modfolderpathname = col1
            ModName = col2
            Item = col3
            Category = col4
            Description = col5
            ImagePath = col6
            DateAdded = col7
            ModVersion = col8
            ModLink = col9
        End Sub
    End Class

    Public Class RegistryEditor
        Public Shared Sub ReadRegistry(modsRegistryDictionary As Dictionary(Of String, ModInfo), registryTextFilePath As String)
            Dim jsonString As String = File.ReadAllText(registryTextFilePath)

            ' Parse JSON array using JsonDocument for safe property access
            Using document As JsonDocument = JsonDocument.Parse(jsonString)
                For Each element As JsonElement In document.RootElement.EnumerateArray()
                    ' Required fields (old and new formats should have these)
                    Dim tempModFolderPathName As String = element.GetProperty("Modfolderpathname").GetString()
                    Dim tempItem As String = element.GetProperty("Item").GetString()
                    Dim tempCategory As String = element.GetProperty("Category").GetString()
                    Dim tempDescription As String = If(element.TryGetProperty("Description", Nothing), element.GetProperty("Description").GetString(), "")

                    ' Optional fields with fallback values
                    Dim tempModName As String = If(element.TryGetProperty("ModName", Nothing), element.GetProperty("ModName").GetString(), Path.GetFileName(tempModFolderPathName))
                    Dim tempImagePath As String = If(element.TryGetProperty("ImagePath", Nothing), element.GetProperty("ImagePath").GetString(), "")
                    Dim tempDateAdded As String = If(element.TryGetProperty("DateAdded", Nothing), element.GetProperty("DateAdded").GetString(), DateTime.Now.ToString("yyyy-MM-dd"))
                    Dim tempModVersion As String = If(element.TryGetProperty("ModVersion", Nothing), element.GetProperty("ModVersion").GetString(), "")
                    Dim tempModLink As String = If(element.TryGetProperty("ModLink", Nothing), element.GetProperty("ModLink").GetString(), "")

                    Dim tempModInfo As New ModInfo(tempModFolderPathName, tempModName, tempItem, tempCategory, tempDescription,
                                           tempImagePath, tempDateAdded, tempModVersion, tempModLink)

                    modsRegistryDictionary(tempModFolderPathName) = tempModInfo
                Next
            End Using
        End Sub

        Public Shared Sub UpdateRegistry(allModsOriginalDictionary As Dictionary(Of String, Class1.ModInfo), modsRegistryDictionary As Dictionary(Of String, ModInfo))
            For Each newModInfo As ModInfo In allModsOriginalDictionary.Values
                If modsRegistryDictionary.ContainsKey(newModInfo.Modfolderpathname) Then
                    Dim oldModInfo As ModInfo = modsRegistryDictionary(newModInfo.Modfolderpathname)
                    If Not oldModInfo.Equals(newModInfo) Then
                        oldModInfo.ModName = newModInfo.ModName
                        oldModInfo.Item = newModInfo.Item
                        oldModInfo.Category = newModInfo.Category
                        oldModInfo.Description = newModInfo.Description
                        oldModInfo.ImagePath = newModInfo.ImagePath
                        oldModInfo.DateAdded = newModInfo.DateAdded
                        oldModInfo.ModVersion = newModInfo.ModVersion
                        oldModInfo.ModLink = newModInfo.ModLink
                    End If
                End If
            Next
        End Sub

        Public Shared Sub OverwriteRegistry(modsRegistryDictionary As Dictionary(Of String, ModInfo), registryTextFilePath As String)
            If modsRegistryDictionary IsNot Nothing AndAlso modsRegistryDictionary.Count > 0 Then
                Using writer As New StreamWriter(registryTextFilePath)
                    ' Start the JSON array
                    writer.WriteLine("[")
                    ' JsonSerializerOptions to prevent escape sequences like \u0027
                    Dim options As New JsonSerializerOptions()
                    options.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    Dim firstMod As Boolean = True
                    For Each modRegistryEntry As KeyValuePair(Of String, ModInfo) In modsRegistryDictionary
                        Dim modInfo As ModInfo = modRegistryEntry.Value
                        ' Replace backslashes with forward slashes in the Modfolderpathname
                        modInfo.Modfolderpathname = modInfo.Modfolderpathname.Replace("\", "/")
                        ' Create a new anonymous object representing the mod info
                        Dim modInfoJson = New With {
                        Key .Modfolderpathname = modInfo.Modfolderpathname,
                        Key .ModName = modInfo.ModName,
                        Key .Item = modInfo.Item,
                        Key .Category = modInfo.Category,
                        Key .Description = modInfo.Description,
                        Key .ImagePath = modInfo.ImagePath,
                        Key .DateAdded = modInfo.DateAdded,
                        Key .ModVersion = modInfo.ModVersion,
                        Key .ModLink = modInfo.ModLink
                        }
                        ' Serialize the mod info to JSON format (compact, one line)
                        Dim json As String = JsonSerializer.Serialize(modInfoJson, options)
                        ' Write a comma before each mod except the first one
                        If Not firstMod Then
                            writer.WriteLine(",")
                        End If
                        ' Write the serialized JSON for the current mod
                        writer.Write(json)
                        ' After the first mod, set firstMod to False
                        firstMod = False
                    Next
                    ' End the JSON array
                    writer.WriteLine()
                    writer.WriteLine("]")
                End Using
            End If
        End Sub
    End Class


    Public Class ModFinder
        Public Shared Sub ScanModFoldersForPatchFiles(modDirectoryPath As String, allModsOriginalDictionary As Dictionary(Of String, Class1.ModInfo), modsRegistryDictionary As Dictionary(Of String, Class1.ModInfo))
            For Each modFolder As String In Directory.GetDirectories(modDirectoryPath, "*", SearchOption.AllDirectories)
                If Directory.GetFiles(modFolder).Length = 0 AndAlso Directory.GetDirectories(modFolder).Length = 0 Then
                    Continue For
                End If
                If Directory.GetFiles(modFolder, "*.patch_*").Any() Then
                    Dim relativeModFolderPath As String = Path.GetRelativePath(modDirectoryPath, modFolder).Replace("\", "/")
                    If modsRegistryDictionary.ContainsKey(relativeModFolderPath) Then
                        Dim tempModInfo As Class1.ModInfo = modsRegistryDictionary(relativeModFolderPath)
                        allModsOriginalDictionary(relativeModFolderPath) = tempModInfo
                    Else
                        Dim tempModInfo As New Class1.ModInfo(relativeModFolderPath, Path.GetFileName(relativeModFolderPath), "Other", "Other", "",
                                                                "", DateTime.Now.ToString("yyyy-MM-dd"), "", "")
                        modsRegistryDictionary.Add(relativeModFolderPath, tempModInfo)
                        allModsOriginalDictionary(relativeModFolderPath) = tempModInfo
                    End If
                End If
            Next
        End Sub
    End Class

    Public Class UpdateModsOriginalDictionary
        Public Shared Sub UpdateModsOriginalDictionary(modRow As ModInfo, modList As Dictionary(Of String, Class1.ModInfo))
            modList(modRow.Modfolderpathname) = modRow
        End Sub
    End Class

    Public Class Mods_DataGridView_Editor
        Public Shared Sub AddModInfoToDataGridView(tempModInfo As ModInfo, Mods_DataGridView As DataGridView)
            If Mods_DataGridView.Name = "UnusedMods_DataGridView" Then
                Mods_DataGridView.Rows.Add(tempModInfo.Modfolderpathname, tempModInfo.ModName,
                                           tempModInfo.Item, tempModInfo.Category, tempModInfo.Description,
                                            tempModInfo.ImagePath, tempModInfo.DateAdded, tempModInfo.ModVersion, tempModInfo.ModLink)
            ElseIf Mods_DataGridView.Name = "UsedMods_DataGridView" Then
                Mods_DataGridView.Rows.Add(Mods_DataGridView.RowCount, tempModInfo.Modfolderpathname, tempModInfo.ModName,
                               tempModInfo.Item, tempModInfo.Category, tempModInfo.Description,
                                tempModInfo.ImagePath, tempModInfo.DateAdded, tempModInfo.ModVersion, tempModInfo.ModLink)
            End If
        End Sub
    End Class

    Public Class SettingsEditor

        Public Shared Sub CreateSettings(settingsTextFilePath As String)

        End Sub

        Public Shared Sub ReadSettings(settingsTextFilePath As String, UsedMods_DataGridView As DataGridView, UnusedMods_DataGridView As DataGridView,
                                              Themes_ProfileSpecificThemes_DataGridView As DataGridView, Themes_GlobalTheme_ComboBox As ComboBox,
                                              Hd2DataPathPreview_TextBox As TextBox,
                                              LastInstalledProfile_Label As System.Windows.Forms.Label,
                                              themesDictionary As Dictionary(Of String, Class3.ThemeInfo),
                                              currentGlobalTheme As ThemeInfo,
                                              profileSpecificThemesDictionary As Dictionary(Of String, Class3.ProfileSpecificTheme))
            ' Read the JSON file content into a string
            Dim jsonString As String = File.ReadAllText(settingsTextFilePath)

            ' Deserialize the JSON string into a JsonNode object
            Dim settings As JsonNode = JsonNode.Parse(jsonString)

            ' Set Hd2DataPathPreview_TextBox and LastInstalledProfile_Label text from JSON settings
            If settings("Hd2DataPath") IsNot Nothing Then
                Hd2DataPathPreview_TextBox.Text = settings("Hd2DataPath").ToString()
            End If

            If settings("LastInstalledProfile") IsNot Nothing Then
                LastInstalledProfile_Label.Text = settings("LastInstalledProfile").ToString()
            End If

            ' Deserialize profileSpecificThemes into the dictionary
            Dim profileSpecificThemes As JsonArray = CType(settings("profileSpecificThemes"), JsonArray)
            For Each profileTheme As JsonNode In profileSpecificThemes
                Dim profileName As String = profileTheme("ProfileName").ToString()
                Dim themeName As String = profileTheme("ThemeName").ToString()
                If Not themesDictionary.ContainsKey(themeName) Then
                    themeName = "" ' Set to empty string if the theme does not exist
                End If
                profileSpecificThemesDictionary(profileName) = New Class3.ProfileSpecificTheme(profileName, themeName)
                For Each row As DataGridViewRow In Themes_ProfileSpecificThemes_DataGridView.Rows
                    If row.Cells(0).Value IsNot Nothing AndAlso row.Cells(0).Value.ToString() = profileName Then
                        ' Update the existing row (set the themeName in the second column)
                        row.Cells(1).Value = themeName
                        Exit For
                    End If
                Next
            Next

            ' Deserialize columnsVisibleOrHidden dictionary and apply to DataGridViews
            Dim columnsVisibleOrHiddenJson As JsonObject = CType(settings("columnsVisibleOrHidden"), JsonObject)
            For Each kvp As KeyValuePair(Of String, JsonNode) In columnsVisibleOrHiddenJson
                Dim columnName As String = kvp.Key
                Dim isVisible As Boolean = Boolean.Parse(kvp.Value.ToString())

                ' Apply visibility to both DataGrids (assuming columns exist)
                SetColumnVisibility(UsedMods_DataGridView, columnName, isVisible)
                SetColumnVisibility(UnusedMods_DataGridView, columnName, isVisible)
            Next

            If settings("currentGlobalTheme") IsNot Nothing Then
                Dim themeName As String = settings("currentGlobalTheme").ToString()
                If Themes_GlobalTheme_ComboBox.Items.Contains(themeName) Then
                    currentGlobalTheme = themesDictionary(themeName)
                    Themes_GlobalTheme_ComboBox.SelectedItem = themeName
                End If
            End If
        End Sub


        ' Helper method to set column visibility
        Private Shared Sub SetColumnVisibility(dataGridView As DataGridView, columnName As String, isVisible As Boolean)
            For Each column As DataGridViewColumn In dataGridView.Columns
                If column.Name = columnName Then
                    column.Visible = isVisible
                    Exit Sub
                End If
            Next
        End Sub

        Public Shared Sub OverwriteSettings(Hd2DataPathPreview As String, LastInstalledProfile As String,
                                    columnsVisibleOrHiddenDictionary As Dictionary(Of String, Boolean),
                                    currentGlobalTheme As String, profileSpecificThemesDictionary As Dictionary(Of String, Class3.ProfileSpecificTheme),
                                    settingsTextFilePath As String)
            Using writer As New StreamWriter(settingsTextFilePath)
                ' Start the JSON object
                writer.WriteLine("{")
                ' Serialize Hd2DataPathPreview and LastInstalledProfile
                writer.WriteLine($"  ""Hd2DataPath"": ""{Hd2DataPathPreview.Replace("\", "/")}"",")
                writer.WriteLine($"  ""LastInstalledProfile"": ""{LastInstalledProfile}"",")

                ' Serialize columnsVisibleOrHidden dictionary without trailing commas
                writer.WriteLine("  ""columnsVisibleOrHidden"": {")
                Dim lastColumn As String = columnsVisibleOrHiddenDictionary.Keys.Last()
                For Each kvp As KeyValuePair(Of String, Boolean) In columnsVisibleOrHiddenDictionary

                    If kvp.Key IsNot lastColumn Then
                        writer.WriteLine($"    ""{kvp.Key}"": {kvp.Value.ToString().ToLower()},")
                    Else
                        writer.WriteLine($"    ""{kvp.Key}"": {kvp.Value.ToString().ToLower()}")
                    End If
                Next
                writer.WriteLine("  },")

                ' Serialize currentGlobalTheme
                writer.WriteLine($"  ""currentGlobalTheme"": ""{currentGlobalTheme}"",")

                ' Serialize profileSpecificThemes without trailing commas
                writer.WriteLine("  ""profileSpecificThemes"": [")
                Dim lastTheme As String = profileSpecificThemesDictionary.Keys.Last()
                For Each profileThemeEntry As KeyValuePair(Of String, Class3.ProfileSpecificTheme) In profileSpecificThemesDictionary
                    Dim profileTheme As Class3.ProfileSpecificTheme = profileThemeEntry.Value

                    ' Write the theme data
                    writer.WriteLine("    {")
                    writer.WriteLine($"      ""ProfileName"": ""{profileTheme.ProfileName}"",")
                    writer.WriteLine($"      ""ThemeName"": ""{profileTheme.ThemeName}""")
                    writer.Write("    }")

                    ' Check if it's the last item and if so, don't write a comma
                    If profileThemeEntry.Key IsNot lastTheme Then
                        writer.WriteLine(",")  ' Add comma if not the last theme
                    Else
                        writer.WriteLine()   ' If it's the last theme, don't add a comma
                    End If
                Next
                writer.WriteLine("  ]")

                ' End the JSON object
                writer.WriteLine("}")
            End Using
        End Sub
    End Class
End Class
