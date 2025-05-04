using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace phd2mm_wpf
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2_InstallMods : Window
    {
        //public ThemeInfo currentGlobalTheme;
        public string hd2DirectoryPath;
        public string modDirectoryPath;
        public string profileName;
        public List<string> selectedModsList;

        public Window2_InstallMods()
        {
            InitializeComponent();
        }

        private void Window2_InstallMods_Loaded(object sender, RoutedEventArgs e)
        {
            // Set the profile name label text
            CurrentlyInstalledProfileName_Label.Content = profileName;
            // Initialize text to be appended
            string appendTextString = "Deleting old mods in Helldivers 2 data folder...\n";
            InstallationStatus_TextBox.AppendText(appendTextString);
            // Reset mod counters
            AmountOfModsFinishedIntalling_Label.Content = 0;
            TotalAmountOfModsToBeInstalled_Label.Content = selectedModsList.Count;
            ProgressBar1.Maximum = selectedModsList.Count;
            // Define mod patch string
            string modPatchString = ".patch_";
            // Delete old mods
            Class1.FilesDeleter.DeleteModsInThisDirectory(hd2DirectoryPath);
            appendTextString = "Deleted old mods in Helldivers 2 data folder.\n";
            InstallationStatus_TextBox.AppendText(appendTextString);
            // Start installing new mods
            appendTextString = "Installing new mods from profile: " + profileName + "\n";
            InstallationStatus_TextBox.AppendText(appendTextString);
            var modNameDict = new Dictionary<string, int>();
            foreach (string modName in selectedModsList)
            {
                string modFilesPath = System.IO.Path.Combine(modDirectoryPath, modName);
                if (Directory.Exists(modFilesPath))
                {
                    string[] filesInDirectory = Directory.GetFiles(modFilesPath);
                    var uniqueFileNamesInFolder = new List<string>();
                    if (filesInDirectory.Length > 0)
                    {
                        foreach (string modFile in filesInDirectory)
                        {
                            string modFileName = System.IO.Path.GetFileName(modFile);
                            bool checkIfModFileNameContainsPatchKeyword = modFileName.Contains(".patch_");
                            if (checkIfModFileNameContainsPatchKeyword)
                            {
                                string baseName = modFileName.Split(new[] { ".patch_" }, StringSplitOptions.None)[0];
                                if (!modNameDict.ContainsKey(baseName))
                                {
                                    modNameDict.Add(baseName, 0);
                                    uniqueFileNamesInFolder.Add(baseName);
                                }
                                if (!uniqueFileNamesInFolder.Contains(baseName))
                                {
                                    modNameDict[baseName]++;
                                    uniqueFileNamesInFolder.Add(baseName);
                                }
                                string[] tempNameSplit = modFileName.Split('.');
                                tempNameSplit[1] = "patch_" + modNameDict[baseName].ToString();
                                string renamedFile = string.Join(".", tempNameSplit);
                                string renamedFilePath = System.IO.Path.Combine(modFilesPath, renamedFile);
                                string renamedFileInHd2DataPath = System.IO.Path.Combine(hd2DirectoryPath, renamedFile);

                                File.Copy(modFile, renamedFileInHd2DataPath);
                                appendTextString = $"{modName}: From {modFileName} to {renamedFile}\n";
                                InstallationStatus_TextBox.AppendText(appendTextString);
                            }
                        }
                        AmountOfModsFinishedIntalling_Label.Content = (int)AmountOfModsFinishedIntalling_Label.Content + 1;
                    }
                    else
                    {
                        appendTextString = "ERROR: " + modName + " doesn't have patch files in its folder! Skipping mod...\n";
                        InstallationStatus_TextBox.AppendText(appendTextString);
                    }
                }
                else
                {
                    appendTextString = "ERROR: " + modName + " folder doesn't exist! Skipping mod...\n";
                    InstallationStatus_TextBox.AppendText(appendTextString);
                }
                ProgressBar1.Value++;
            }
            InstallationStatus_TextBox.AppendText("Finished installing mods from profile: " + profileName);
            InstallationStatus_TextBox.ScrollToEnd();
        }

        private void Finish_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
