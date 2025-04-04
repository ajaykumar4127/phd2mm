Imports System.Data.Common
Imports System.Diagnostics.Tracing
Imports System.Globalization
Imports System.IO
Imports System.Reflection.Emit
Imports System.Text.Json
Imports System.Text.Json.Nodes
Public Class Class1

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
                    ElseIf TypeOf ctrl Is DataGridView Then
                        Dim dgv As DataGridView = CType(ctrl, DataGridView)
                        dgv.BackgroundColor = Color.FromArgb(40, 40, 40)
                        dgv.ForeColor = Color.White
                        dgv.GridColor = Color.FromArgb(60, 60, 60)
                        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60)
                        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                        dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60)
                        dgv.RowHeadersDefaultCellStyle.ForeColor = Color.White
                        dgv.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50)
                        dgv.DefaultCellStyle.ForeColor = Color.White
                        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45)
                    ElseIf TypeOf ctrl Is GroupBox Then
                        ctrl.BackColor = Color.FromArgb(40, 40, 40)
                        ctrl.ForeColor = Color.White
                        CType(ctrl, GroupBox).FlatStyle = FlatStyle.Flat
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
                    ElseIf TypeOf ctrl Is DataGridView Then
                        Dim dgv As DataGridView = CType(ctrl, DataGridView)
                        dgv.BackgroundColor = Color.White
                        dgv.ForeColor = Color.Black
                        dgv.GridColor = Color.FromArgb(200, 200, 200)
                        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230)
                        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
                        dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230)
                        dgv.RowHeadersDefaultCellStyle.ForeColor = Color.Black
                        dgv.DefaultCellStyle.BackColor = Color.White
                        dgv.DefaultCellStyle.ForeColor = Color.Black
                        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
                    ElseIf TypeOf ctrl Is GroupBox Then
                        ctrl.BackColor = Color.FromArgb(240, 240, 240)
                        ctrl.ForeColor = Color.FromArgb(0, 0, 0)
                        CType(ctrl, GroupBox).FlatStyle = FlatStyle.Flat
                    End If
                Next
            End If
        End Sub
    End Class

    Public Class DirectoryValidator
        Public Shared Function ValidateDirectory(directoryPath As String) As Boolean
            If Not Directory.Exists(directoryPath) OrElse String.IsNullOrEmpty(directoryPath) OrElse String.IsNullOrWhiteSpace(directoryPath) OrElse Not directoryPath.EndsWith("Helldivers 2\data") Then
                MessageBox.Show("Invalid directory! Please locate your Helldivers 2 data folder." & vbCrLf &
                                 "If it's bought on Steam, the path is usually: " & vbCrLf &
                                 "YourSteamPath\Steam\steamapps\common\Helldivers 2\data")
                Return False
            Else
                Return True
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
        Public Property Category As String
        Public Property Item As String
        Public Property Description As String
        Public Sub New(col1 As String, col2 As String, col3 As String, col4 As String)
            Modfolderpathname = col1
            Item = col2
            Category = col3
            Description = col4
        End Sub
    End Class

    Public Class RegistryEditor
        Public Shared Sub ReadRegistry(modsRegistryDictionary As Dictionary(Of String, ModInfo), registryTextFilePath As String)
            ' Read the entire JSON file content
            Dim jsonString As String = File.ReadAllText(registryTextFilePath)
            ' Deserialize the JSON string into a List of JsonObject
            Dim modList As List(Of JsonObject) = JsonSerializer.Deserialize(Of List(Of JsonObject))(jsonString)
            ' Loop through each mod in the list
            For Each modInfoJson As JsonObject In modList
                ' Extract the values from the JSON object using GetProperty
                Dim tempModFolderPathName As String = modInfoJson("Modfolderpathname").ToString()
                Dim tempItem As String = modInfoJson("Item").ToString()
                Dim tempCategory As String = modInfoJson("Category").ToString()
                Dim tempDescription As String = modInfoJson("Description").ToString()
                ' Create a new ModInfo object
                Dim tempModInfo As New ModInfo(tempModFolderPathName, tempItem, tempCategory, tempDescription)
                ' Add the ModInfo to the dictionary
                modsRegistryDictionary.Add(tempModFolderPathName, tempModInfo)
            Next
        End Sub

        Public Shared Sub UpdateRegistry(allModsOriginalDictionary As Dictionary(Of String, Class1.ModInfo), modsRegistryDictionary As Dictionary(Of String, ModInfo))
            For Each newModInfo As ModInfo In allModsOriginalDictionary.Values
                If modsRegistryDictionary.ContainsKey(newModInfo.Modfolderpathname) Then
                    Dim oldModInfo As ModInfo = modsRegistryDictionary(newModInfo.Modfolderpathname)
                    If Not oldModInfo.Equals(newModInfo) Then
                        oldModInfo.Category = newModInfo.Category
                        oldModInfo.Item = newModInfo.Item
                        oldModInfo.Description = newModInfo.Description
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
                        Key .Item = modInfo.Item,
                        Key .Category = modInfo.Category,
                        Key .Description = modInfo.Description
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
                        Dim tempModInfo As New Class1.ModInfo(relativeModFolderPath, "Other", "Other", "none")
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

End Class
