Imports System.IO
Imports phd2mm.Class1
Imports phd2mm.Form1_phd2mm

Public Class Form3_InstallMods

    Public hd2DirectoryPath As String
    Public modDirectoryPath As String
    Public profileName As String
    Public selectedModsList As List(Of String)

    Private Sub Form3_installMods_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Class1.ThemeManager.ApplyTheme(Me)
        CurrentlyInstalledProfileName_Label.Text = profileName
        Dim appendTextString As String
        appendTextString = "Deleting old mods in Helldivers 2 data folder..." & vbCrLf
        InstallationStatus_TextBox.AppendText(appendTextString)
        AmountOfModsFinishedIntalling_Label.Text = 0
        TotalAmountOfModsToBeInstalled_Label.Text = selectedModsList.Count
        ProgressBar1.Maximum = selectedModsList.Count
        Dim modPatchString As String = ".patch_"

        Class1.ModUninstaller.DeleteModsInThisDirectory(hd2DirectoryPath)
        appendTextString = "Deleted old mods in Helldivers 2 data folder." & vbCrLf
        InstallationStatus_TextBox.AppendText(appendTextString)

        appendTextString = "Installing new mods from profile: " & profileName & vbCrLf
        InstallationStatus_TextBox.AppendText(appendTextString)
        Dim modNameDict As New Dictionary(Of String, Integer)()
        For Each modName As String In selectedModsList
            Dim modFilesPath As String = modDirectoryPath + "\" + modName
            If Directory.Exists(modFilesPath) Then
                Dim filesInDirectory As String() = Directory.GetFiles(modFilesPath)
                Dim uniqueFileNamesInFolder As New List(Of String)()
                If filesInDirectory.Length > 0 Then
                    For Each modFile As String In filesInDirectory
                        Dim modFileName As String = Path.GetFileName(modFile)
                        Dim checkIfModFileNameContainsPatchKeyword = modFileName.Contains(".patch_")
                        If checkIfModFileNameContainsPatchKeyword Then
                            Dim baseName As String = modFileName.Split(".patch_")(0)
                            If Not modNameDict.ContainsKey(baseName) Then
                                modNameDict.Add(baseName, 0)
                                uniqueFileNamesInFolder.Add(baseName)
                            End If
                            If checkIfModFileNameContainsPatchKeyword Then
                                If Not uniqueFileNamesInFolder.Contains(baseName) And Not uniqueFileNamesInFolder.Contains(baseName) Then
                                    modNameDict(baseName) += 1
                                    uniqueFileNamesInFolder.Add(baseName)
                                End If
                                Dim tempNameSplit As String() = modFileName.Split(".")
                                tempNameSplit(1) = "patch_" + modNameDict(baseName).ToString()
                                Dim renamedFile = String.Join(".", tempNameSplit)
                                Dim renamedFilePath = modFilesPath + "\" + renamedFile
                                Dim renamedFileInHd2DataPath = hd2DirectoryPath + "\" + renamedFile
                                My.Computer.FileSystem.CopyFile(modFile, renamedFileInHd2DataPath)
                                appendTextString = modName & ": From " & modFileName & " to " & renamedFile & vbCrLf
                                InstallationStatus_TextBox.AppendText(appendTextString)
                            End If
                        End If
                    Next
                    AmountOfModsFinishedIntalling_Label.Text += 1
                Else
                    appendTextString = "ERROR: " & modName & " doesn't have patch files in its folder! Skipping mod..." & vbCrLf
                    InstallationStatus_TextBox.AppendText(appendTextString)
                End If
            Else
                appendTextString = "ERROR: " & modName & " folder doesn't exist! Skipping mod..." & vbCrLf
                InstallationStatus_TextBox.AppendText(appendTextString)
            End If
            ProgressBar1.Value += 1
        Next

        InstallationStatus_TextBox.AppendText("Finished installing mods from profile: " & profileName)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Finish_Button.Click
        Close()
    End Sub
End Class