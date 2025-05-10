using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using static phd2mm_wpf.Class1;
using System.Text.Json;
using System.Security.Policy;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows;
using System.ComponentModel;
using System.Text.Json.Nodes;

namespace phd2mm_wpf
{
    public class Class1
    {
        // Paths
        private static readonly string currentDirectoryPath = Directory.GetCurrentDirectory();
        private static readonly string modDirectoryPath = System.IO.Path.Combine(currentDirectoryPath, "phd2mm_mods");
        private static readonly string profileDirectoryPath = System.IO.Path.Combine(currentDirectoryPath, "phd2mm_profiles");
        private static readonly string themesDirectoryPath = System.IO.Path.Combine(currentDirectoryPath, "phd2mm_themes");
        private static readonly string settingsDirectoryPath = System.IO.Path.Combine(currentDirectoryPath, "phd2mm_settings");
        private static readonly string settingsTextFilePath = System.IO.Path.Combine(settingsDirectoryPath, "phd2mm_settings.json");
        private static readonly string registryTextFilePath = System.IO.Path.Combine(settingsDirectoryPath, "phd2mm_registry.json");

        public static string GetModDirectoryPath()
        {
            return modDirectoryPath;
        }

        public static string GetProfileDirectoryPath()
        {
            return profileDirectoryPath;
        }

        public static string GetSettingsTextFilePath()
        {
            return settingsTextFilePath;
        }

        public static string GetThemesDirectoryPath()
        {
            return themesDirectoryPath;
        }

        public class DirectoryAndFileInitializer
        {
            public static void InitializeDirectoriesAndFiles()
            {
                Class1.DirectoryAndFileInitializer.InitializeDirectory(profileDirectoryPath);
                Class1.DirectoryAndFileInitializer.InitializeDirectory(modDirectoryPath);
                Class1.DirectoryAndFileInitializer.InitializeDirectory(themesDirectoryPath);
                Class1.DirectoryAndFileInitializer.InitializeDirectory(settingsDirectoryPath);
                Class1.DirectoryAndFileInitializer.InitializeFiles(registryTextFilePath);
                Class1.DirectoryAndFileInitializer.InitializeFiles(settingsTextFilePath);
                Class1.DirectoryAndFileInitializer.InitializeDefaultProfile(profileDirectoryPath);
            }

            public static void InitializeDirectory(string directoryPath)
            {
                if (Directory.Exists(directoryPath) == false)
                {
                    Directory.CreateDirectory(directoryPath);
                }
            }

            public static void InitializeFiles(string filePath)
            {
                if (File.Exists(filePath) == false)
                {
                    File.Create(filePath).Close();
                    if (filePath == registryTextFilePath)
                    {
                        File.WriteAllText(registryTextFilePath, "[]");
                    }
                }
            }

            public static void InitializeDefaultProfile(string profileDirectoryPath)
            {
                // Get all .txt files in the profile directory
                string[] profileTextFiles = Directory.GetFiles(profileDirectoryPath, "*.txt");
                // If there are no text files in the directory, create a default profile
                if (profileTextFiles.Length == 0)
                {
                    string defaultProfileTextFile = Path.Combine(profileDirectoryPath, "default.txt");
                    // Create the default profile file
                    File.WriteAllText(defaultProfileTextFile, "");
                }

            }

            public static void InitializeProfilesList_ComboBox(ObservableCollection<string> ProfilesList_ProfileNames)
            {
                foreach (string profileFile in Directory.GetFiles(profileDirectoryPath))
                {
                    // Extract the file name without the extension
                    string profileFileName = Path.GetFileNameWithoutExtension(profileFile);
                    // Add the profile name to the ComboBox
                    ProfilesList_ProfileNames.Add(profileFileName);
                }
            }
        }

        public class DirectoryValidator
        {
            public static bool ValidateDirectory(string directoryPath)
            {
                if (string.IsNullOrEmpty(directoryPath) || string.IsNullOrWhiteSpace(directoryPath))
                {
                    MessageBox.Show("Invalid directory! Please locate your Helldivers 2 data folder." + Environment.NewLine +
                                     "If it's bought on Steam, the path is usually: " + Environment.NewLine +
                                     "YourSteamPath\\Steam\\steamapps\\common\\Helldivers 2\\data",
                                     "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    // Normalize directory path to use consistent forward slashes
                    directoryPath = directoryPath.Replace("\\", "/");
                    if (directoryPath.EndsWith("Helldivers 2/data"))
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid directory! Please locate your Helldivers 2 data folder." + Environment.NewLine +
                                         "If it's bought on Steam, the path is usually: " + Environment.NewLine +
                                         "YourSteamPath\\Steam\\steamapps\\common\\Helldivers 2\\data",
                                         "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
            }
        }

        public class FilesDeleter
        {
            public static void DeleteModsInThisDirectory(string hd2DirectoryPath)
            {
                string modPatchString = ".patch_";
                foreach (string oldModFile in Directory.GetFiles(hd2DirectoryPath))
                {
                    if (Path.GetFileName(oldModFile).Contains(modPatchString))
                    {
                        File.Delete(oldModFile);
                    }
                }
            }

            public static void DeleteProfile(string profileName)
            {
                string profileTextFilePath = Path.Combine(profileDirectoryPath, profileName + ".txt");
                if (File.Exists(profileTextFilePath))
                {
                    File.Delete(profileTextFilePath);
                }
            }
        }

        public class FilesSaver
        {
            public static void SaveProfile(string profileName, ObservableCollection<Class1.ModInfo> UsedMods_DataGrid_ObservableCollection)
            {
                string profileTextFilePath = Path.Combine(profileDirectoryPath, profileName + ".txt");
                // Open the file for writing
                using (StreamWriter writer = new StreamWriter(profileTextFilePath))
                {
                    // Loop through each ModInfo in the ObservableCollection
                    foreach (var modInfo in UsedMods_DataGrid_ObservableCollection)
                    {
                        // Write the ModFolderPathName to the file followed by a newline
                        writer.WriteLine(modInfo.ModFolderPathName);
                    }
                }
            }
        }

        public class ModInfo : INotifyPropertyChanged
        {
            private string _modFolderPathName;
            private string _modName;
            private string _item;
            private string _category;
            private string _description;
            private string _imagePath;
            private string _dateAdded;
            private string _modVersion;
            private string _modLink;
            private int _modOrderNumber;

            // List of valid categories based on the selected item
            private ObservableCollection<string> _validCategories;

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            // Properties
            public string ModFolderPathName
            {
                get => _modFolderPathName;
                set
                {
                    if (_modFolderPathName != value)
                    {
                        _modFolderPathName = value;
                        OnPropertyChanged(nameof(ModFolderPathName));
                    }
                }
            }

            public string ModName
            {
                get => _modName;
                set
                {
                    if (_modName != value)
                    {
                        _modName = value;
                        OnPropertyChanged(nameof(ModName));
                    }
                }
            }

            public string Item
            {
                get => _item;
                set
                {
                    if (_item != value)
                    {
                        _item = value;
                        OnPropertyChanged(nameof(Item));
                        UpdateCategories(); // Update valid categories when item changes
                        // Works together with private void ItemComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
                        // in MainWindow.xaml.cs, to update the Category ComboBox when Item column cell value changes.
                    }
                }
            }

            public string Category
            {
                get => _category;
                set
                {
                    if (_category != value)
                    {
                        _category = value;
                        OnPropertyChanged(nameof(Category));
                    }
                }
            }

            public ObservableCollection<string> ValidCategories
            {
                get => _validCategories;
                private set
                {
                    _validCategories = value;
                    OnPropertyChanged(nameof(ValidCategories));
                }
            }

            public string Description
            {
                get => _description;
                set
                {
                    if (_description != value)
                    {
                        _description = value;
                        OnPropertyChanged(nameof(Description));
                    }
                }
            }

            public string ImagePath
            {
                get => _imagePath;
                set
                {
                    if (_imagePath != value)
                    {
                        _imagePath = value;
                        OnPropertyChanged(nameof(ImagePath));
                    }
                }
            }

            public string DateAdded
            {
                get => _dateAdded;
                set
                {
                    if (_dateAdded != value)
                    {
                        _dateAdded = value;
                        OnPropertyChanged(nameof(DateAdded));
                    }
                }
            }

            public string ModVersion
            {
                get => _modVersion;
                set
                {
                    if (_modVersion != value)
                    {
                        _modVersion = value;
                        OnPropertyChanged(nameof(ModVersion));
                    }
                }
            }

            public string ModLink
            {
                get => _modLink;
                set
                {
                    if (_modLink != value)
                    {
                        _modLink = value;
                        OnPropertyChanged(nameof(ModLink));
                    }
                }
            }

            public int ModOrderNumber
            {
                get => _modOrderNumber;
                set
                {
                    if (_modOrderNumber != value)
                    {
                        _modOrderNumber = value;
                        OnPropertyChanged(nameof(ModOrderNumber));
                    }
                }
            }

            // Method to update valid categories based on the selected item
            public void UpdateCategories()
            {
                var validCategories = Class2.CategoryAndItemsManager.GetCategoryForItem(Item);
                ValidCategories = new ObservableCollection<string>(validCategories);
                // This is important: update the Category only if it's invalid
                if (!ValidCategories.Contains(Category) && ValidCategories.Any())
                {
                    Category = ValidCategories.First();
                }
            }

            // Constructor
            public ModInfo(string col1, string col2, string col3, string col4,
                           string col5, string col6, string col7, string col8,
                           string col9, int col10)
            {
                ModFolderPathName = col1;
                ModName = col2;
                Item = col3;
                Category = col4;
                Description = col5;
                ImagePath = col6;
                DateAdded = col7;
                ModVersion = col8;
                ModLink = col9;
                ModOrderNumber = col10;

                // Initialize the valid categories based on the initial item
                UpdateCategories();
            }
        }

        public class LastInstalledProfile_LabelEditor
        {
            public static string GetLastInstalledProfile(Label LastInstalledProfile_Label)
            {
                // Access the TextBlock inside the Label
                var lastInstalledProfile_LabelTextBlock = LastInstalledProfile_Label.Content as TextBlock;
                string lastInstalledProfile_LabelTextBlockText = "NA";
                if (lastInstalledProfile_LabelTextBlock != null)
                {
                    // Get the text from the TextBlock
                    lastInstalledProfile_LabelTextBlockText = lastInstalledProfile_LabelTextBlock.Text;
                }
                return lastInstalledProfile_LabelTextBlockText;
            }
            public static void SetLastInstalledProfile(Label LastInstalledProfile_Label, string newlyInstalledProfile)
            {
                // Access the TextBlock inside the Label
                var lastInstalledProfile_LabelTextBlock = LastInstalledProfile_Label.Content as TextBlock;
                string lastInstalledProfile_LabelTextBlockText = "NA";
                if (lastInstalledProfile_LabelTextBlock != null)
                {
                    // Get the text from the TextBlock
                    lastInstalledProfile_LabelTextBlock.Text = newlyInstalledProfile ?? "NA";
                }
            }
        }

        public class SettingsEditor
        {
            public static void ReadSettings(TextBox Hd2DataPathPreview_TextBox, Label LastInstalledProfile,
                DataGrid UnusedMods_DataGrid, DataGrid UsedMods_DataGrid,
                ComboBox Themes_GlobalTheme_ComboBox,
                ObservableCollection<string> ProfilesList_ProfileNames,
                ObservableCollection<string> Themes_ProfileSpecificThemes_DataGrid_ThemeNames_ObservableCollection,
                Dictionary<string, Class3.ProfileSpecificThemeInfo> profileSpecificThemesDictionary,
                ObservableCollection<Class3.ProfileSpecificThemeInfo> Themes_ProfileSpecificThemes_DataGrid_ObservableCollection
                )
            {
                // Read the JSON content from the file
                string jsonContent = File.ReadAllText(Class1.GetSettingsTextFilePath());
                // Check if the content is empty or just whitespace
                if (string.IsNullOrWhiteSpace(jsonContent))
                {
                    //MessageBox.Show("The settings file is empty or invalid.");
                    return; // Skip parsing if the content is invalid or empty
                }
                JsonObject settings = JsonNode.Parse(jsonContent).AsObject();
                // Access and apply settings dynamically
                // Set Hd2DataPathPreview TextBox from JSON settings
                // Having the question mark (?) prevents NullReferenceException
                // Having 2 question marks (??) prevents NullReferenceException and sets the value to "" if null
                if (settings["Hd2DataPath"] != null)
                {
                    Hd2DataPathPreview_TextBox.Text = settings["Hd2DataPath"]?.ToString() ?? "";
                }
                // Set LastInstalledProfile Label from JSON settings
                if (settings["LastInstalledProfile"] != null)
                {
                    var textBlock = LastInstalledProfile.Content as TextBlock;
                    if (textBlock != null)
                    {
                        textBlock.Text = settings["LastInstalledProfile"]?.ToString() ?? "NA";
                    }
                }
                // Deserialize columns visibility settings for both DataGrids
                if (settings["ColumnsVisibleOrHidden"] != null)
                {
                    JsonObject columnsVisibleOrHiddenJson = settings["ColumnsVisibleOrHidden"].AsObject();
                    Class1.SettingsEditor.SetColumnVisibility(UnusedMods_DataGrid, columnsVisibleOrHiddenJson, "UnusedMods_DataGrid");
                    Class1.SettingsEditor.SetColumnVisibility(UsedMods_DataGrid, columnsVisibleOrHiddenJson, "UsedMods_DataGrid");
                }
                if (settings["GlobalTheme"] != null)
                {
                    string globalTheme = settings["GlobalTheme"]?.ToString() ?? "";
                    // Check if the global theme exists in the ObservableCollection
                    if (Themes_ProfileSpecificThemes_DataGrid_ThemeNames_ObservableCollection.Contains(globalTheme))
                    {
                        Themes_GlobalTheme_ComboBox.SelectedItem = globalTheme;
                    }
                    else
                    {
                        Themes_GlobalTheme_ComboBox.SelectedItem = "phd2mm_light";
                    }
                }

                if (settings["ProfileSpecificThemes"] != null)
                {
                    JsonObject profileSpecificThemesJson = settings["ProfileSpecificThemes"].AsObject();

                    // Iterate over each profile in the ProfileSpecificThemes
                    foreach (var profile in profileSpecificThemesJson)
                    {
                        string profileName = profile.Key; // The profile name (e.g., "default", "Profile1")
                        string themeName = profile.Value.ToString(); // The theme name (e.g., "")

                        // Check if the profile exists in ProfilesList_ProfileNames
                        if (ProfilesList_ProfileNames.Contains(profileName))
                        {
                            // Check if the theme exists in Themes_ProfileSpecificThemes_DataGrid_ThemeNames_ObservableCollection
                            if (Themes_ProfileSpecificThemes_DataGrid_ThemeNames_ObservableCollection.Contains(themeName))
                            {
                                // Find the item in the collection (e.g., "Profile1")
                                var themeInfoToUpdate = Themes_ProfileSpecificThemes_DataGrid_ObservableCollection
                                    .FirstOrDefault(theme => theme.ProfileName == profileName);
                                if (themeInfoToUpdate != null)
                                {
                                    // Modify the properties
                                    themeInfoToUpdate.ThemeName = themeName;  // This will trigger OnPropertyChanged and update the UI
                                }
                            }
                        }
                    }
                }

            }

            public static void GetColumnVisibility(DataGrid dataGrid, Dictionary<string, string> columnsVisibleOrHiddenDictionary, string dataGridName)
            {
                // Iterate through each column in the DataGrid
                foreach (var column in dataGrid.Columns)
                {
                    // Skip the exempted columns
                    if (column.Header.ToString() == "Order" || column.Header.ToString() == "Mod Folder Path + Name")
                    {
                        continue; // Skip this column
                    }
                    if (column.Header.ToString() == "Date Added")
                    {
                        column.Header = "Date_Added";
                    }
                    // Store the column's visibility as a string
                    string columnHeaderName = dataGridName + "_" + column.Header.ToString() + "_Column";
                    string visibility = column.Visibility.ToString();  // Convert to string
                    columnsVisibleOrHiddenDictionary[columnHeaderName] = visibility;
                }
            }

            // Helper method to apply column visibility to a DataGrid
            private static void SetColumnVisibility(DataGrid dataGrid, JsonObject columnsVisibilitySettings, string dataGridName)
            {
                foreach (var kvp in columnsVisibilitySettings)
                {
                    string columnName = kvp.Key;
                    // Check if the column is prefixed with the correct DataGrid name (UnusedMods_DataGrid or UsedMods_DataGrid)
                    if (columnName.StartsWith(dataGridName))
                    {
                        // Remove the appropriate prefix and "_Column" suffix from the JSON column name
                        columnName = columnName.Replace(dataGridName + "_", "").Replace("_Column", "");
                        if (columnName == "Date_Added")
                        {
                            columnName = "Date Added";
                        }
                        bool isVisible = kvp.Value.ToString().ToLower() == "visible";
                        // Apply visibility to the DataGrid based on column header matching
                        var column = dataGrid.Columns.FirstOrDefault(c => c.Header.ToString() == columnName);
                        if (column != null)
                        {
                            // Set the column visibility based on the JSON setting
                            // If isVisible is true, set to Visible; otherwise, set to Collapsed
                            column.Visibility = isVisible ? Visibility.Visible : Visibility.Collapsed;
                        }
                    }
                }
            }

            public static void OverwriteSettings(string hd2DataPath, string lastInstalledProfile,
                Dictionary<string, string> columnsVisibleOrHiddenDictionary,
                string globalTheme, Dictionary<string, Class3.ProfileSpecificThemeInfo> profileSpecificThemesDictionary)
            {
                // Create a simplified dictionary for profile-specific themes
                var simplifiedProfileSpecificThemes = profileSpecificThemesDictionary.ToDictionary(
                    kvp => kvp.Key,  // Profile name
                    kvp => kvp.Value.ThemeName  // Theme name (string) or empty string
                );

                var settings = new
                {
                    Hd2DataPath = hd2DataPath,
                    LastInstalledProfile = lastInstalledProfile,
                    ColumnsVisibleOrHidden = columnsVisibleOrHiddenDictionary,
                    GlobalTheme = globalTheme,
                    ProfileSpecificThemes = simplifiedProfileSpecificThemes
                };

                // Serialize the settings object to a JSON string
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true // Makes the JSON output readable (pretty print)
                };
                string json = JsonSerializer.Serialize(settings, options);

                // Write the JSON to the settings file
                try
                {
                    File.WriteAllText(Class1.GetSettingsTextFilePath(), json);
                }
                catch (Exception ex)
                {
                    // Handle any potential errors (e.g., file access issues)
                    MessageBox.Show("Error writing settings: " + ex.Message);
                }
            }

        }

        public class RegistryEditor
        {
            public static void ReadRegistry(Dictionary<string, ModInfo> modsRegistryDictionary)
            {
                // Read JSON content from the file
                string jsonString = File.ReadAllText(registryTextFilePath);
                // Parse the JSON array using JsonDocument for safe property access
                using (JsonDocument document = JsonDocument.Parse(jsonString))
                {
                    foreach (JsonElement element in document.RootElement.EnumerateArray())
                    {
                        // Required fields (old and new formats should have these)
                        string tempModFolderPathName = element.GetProperty("ModFolderPathName").GetString();
                        string tempItem = element.GetProperty("Item").GetString();
                        string tempCategory = element.GetProperty("Category").GetString();
                        string tempDescription = element.TryGetProperty("Description", out JsonElement descriptionElement) ? descriptionElement.GetString() : "";
                        // Optional fields with fallback values
                        string tempModName = element.TryGetProperty("ModName", out JsonElement modNameElement) ? modNameElement.GetString() : Path.GetFileName(tempModFolderPathName);
                        string tempImagePath = element.TryGetProperty("ImagePath", out JsonElement imagePathElement) ? imagePathElement.GetString() : "";
                        string tempDateAdded = element.TryGetProperty("DateAdded", out JsonElement dateAddedElement) ? dateAddedElement.GetString() : DateTime.Now.ToString("yyyy-MM-dd");
                        string tempModVersion = element.TryGetProperty("ModVersion", out JsonElement modVersionElement) ? modVersionElement.GetString() : "";
                        string tempModLink = element.TryGetProperty("ModLink", out JsonElement modLinkElement) ? modLinkElement.GetString() : "";
                        // Create ModInfo object with parsed data
                        ModInfo tempModInfo = new ModInfo(tempModFolderPathName, tempModName, tempItem, tempCategory, tempDescription,
                            tempImagePath, tempDateAdded, tempModVersion, tempModLink, -1);
                        // Add or update the dictionary with the ModInfo object
                        modsRegistryDictionary[tempModFolderPathName] = tempModInfo;
                    }
                }
            }

            public static void OverwriteRegistry(Dictionary<string, ModInfo> modsRegistryDictionary)
            {
                if (modsRegistryDictionary != null && modsRegistryDictionary.Count > 0)
                {
                    using (StreamWriter writer = new StreamWriter(registryTextFilePath))
                    {
                        // Start the JSON array
                        writer.WriteLine("[");
                        // JsonSerializerOptions to prevent escape sequences like \u0027
                        var options = new JsonSerializerOptions
                        {
                            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                        };
                        bool firstMod = true;
                        foreach (var modRegistryEntry in modsRegistryDictionary)
                        {
                            ModInfo modInfo = modRegistryEntry.Value;
                            // Replace backslashes with forward slashes in the Modfolderpathname
                            modInfo.ModFolderPathName = modInfo.ModFolderPathName.Replace("\\", "/");
                            // Create a new anonymous object representing the mod info
                            var modInfoJson = new
                            {
                                ModFolderPathName = modInfo.ModFolderPathName,
                                ModName = modInfo.ModName,
                                Item = modInfo.Item,
                                Category = modInfo.Category,
                                Description = modInfo.Description,
                                ImagePath = modInfo.ImagePath,
                                DateAdded = modInfo.DateAdded,
                                ModVersion = modInfo.ModVersion,
                                ModLink = modInfo.ModLink
                            };
                            // Serialize the mod info to JSON format (compact, one line)
                            string json = JsonSerializer.Serialize(modInfoJson, options);
                            // Write a comma before each mod except the first one
                            if (firstMod == false)
                            {
                                writer.WriteLine(",");
                            }
                            // Write the serialized JSON for the current mod
                            writer.Write(json);
                            // After the first mod, set firstMod to false
                            firstMod = false;
                        }
                        // End the JSON array
                        writer.WriteLine();
                        writer.WriteLine("]");
                    }
                }
            }
        }

        public class ModFinder
        {
            private static readonly string[] ValidImageExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            public static void ScanModFoldersForPatchFiles(Dictionary<string, Class1.ModInfo> allModsOriginalDictionary,
                Dictionary<string, Class1.ModInfo> modsRegistryDictionary)
            {
                foreach (string modFolder in Directory.GetDirectories(modDirectoryPath, "*", SearchOption.AllDirectories))
                {
                    if (Directory.GetFiles(modFolder).Length == 0 && Directory.GetDirectories(modFolder).Length == 0)
                    {
                        continue;
                    }
                    // Check for any *.patch_* files in the directory
                    if (Directory.GetFiles(modFolder, "*.patch_*").Any())
                    {
                        string relativeModFolderPath = Path.GetRelativePath(modDirectoryPath, modFolder).Replace("\\", "/");
                        if (modsRegistryDictionary.ContainsKey(relativeModFolderPath))
                        {
                            // If the folder is already in the registry dictionary, update it in allModsOriginalDictionary
                            Class1.ModInfo tempModInfo = modsRegistryDictionary[relativeModFolderPath];
                            allModsOriginalDictionary[relativeModFolderPath] = tempModInfo;
                        }
                        else
                        {
                            // Now, check for image files with valid extensions
                            var imageFiles = Directory.GetFiles(modFolder)
                                                      .Where(file => ValidImageExtensions.Contains(Path.GetExtension(file).ToLower()))
                                                      .OrderBy(file => file)  // Sort alphabetically
                                                      .ToList();
                            // Check if there's at least one valid image file
                            string firstImageFile = "";
                            if (imageFiles.Any())
                            {
                                // If there are valid image files, get the first one (alphabetically)
                                firstImageFile = imageFiles.First();
                                firstImageFile = System.IO.Path.Combine(relativeModFolderPath, firstImageFile);
                                // Find the index of "phd2mm_mods" and remove everything before it, including the folder itself.
                                int phd2mmModsIndex = firstImageFile.IndexOf("phd2mm_mods", StringComparison.OrdinalIgnoreCase);
                                if (phd2mmModsIndex >= 0)
                                {
                                    // Remove everything up to and including "phd2mm_mods"
                                    firstImageFile = firstImageFile.Substring(phd2mmModsIndex + "phd2mm_mods".Length + 1);
                                }
                                firstImageFile = firstImageFile.Replace("\\", "/");
                            }

                            // If the folder is not in the registry, create a new ModInfo and add it
                            Class1.ModInfo tempModInfo = new Class1.ModInfo(
                                relativeModFolderPath,
                                Path.GetFileName(relativeModFolderPath),
                                "Other",
                                "Other",
                                "",
                                firstImageFile,
                                DateTime.Now.ToString("yyyy-MM-dd"),
                                "",
                                "",
                                -1);
                            modsRegistryDictionary.Add(relativeModFolderPath, tempModInfo);
                            allModsOriginalDictionary[relativeModFolderPath] = tempModInfo;
                        }
                    }
                }
            }
        }

        public class Mods_DataGrid_Editor
        {
            // WALL OF TEXT INCOMING, mostly applies to InitializeModsDataGridData method, may also apply to other methods:
            // Ok, apparently from my understanding, when you pass a ModInfo from the Dictionary to the ObservableCollection,
            // it passes a reference to the ModInfo object (the memory address), not a standalone object or a copy of the object.
            // Meaning, when the ModInfo is edited through a DataGrid cell or ObservableCollection,
            // it also edits the same ModInfo object in the Dictionary.
            // Which is why I don't need to explicitly create and call Class1.RegistryEditor.UpdateRegistry method
            // like I had to in the WinForms version of this app, the version 1.3 series updates/releases and below.
            // The data is inherently shared and linked through the object reference itself.
            // If you delete a ModInfo from the ObservableCollection, it will only delete the reference to the object in the ObservableCollection,
            // but not the object itself in the Dictionary or the memory address.
            // Feel free to correct me on this, I don't completely understand this part.
            // WinForms gave its life to me on a silver platter. After dealing with WPF, I wish the Lord would take me now.
            public static void InitializeModsDataGridData(string currentlySelectedProfile, ObservableCollection<string> ProfilesList_ProfileNames,
                ObservableCollection<Class1.ModInfo> UnusedMods_DataGrid_ObservableCollection, ObservableCollection<Class1.ModInfo> UsedMods_DataGrid_ObservableCollection,
                Dictionary<string, Class1.ModInfo> allModsOriginalDictionary, Dictionary<string, Class1.ModInfo> modsRegistryDictionary)
            {
                // Create a dictionary to store used mods in profile
                Dictionary<string, Class1.ModInfo> usedModsInProfile = new Dictionary<string, Class1.ModInfo>();
                // Construct the file path
                string currentProfileTextFilePath = Path.Combine(profileDirectoryPath, currentlySelectedProfile + ".txt");
                if (File.Exists(currentProfileTextFilePath))
                {
                    UnusedMods_DataGrid_ObservableCollection.Clear();
                    UsedMods_DataGrid_ObservableCollection.Clear();
                    // Read the lines from the profile text file
                    foreach (string modFolderPathName in File.ReadLines(currentProfileTextFilePath))
                    {
                        // Get the corresponding ModInfo object from the modsRegistryDictionary
                        if (modsRegistryDictionary.ContainsKey(modFolderPathName))
                        {
                            Class1.ModInfo tempModInfo = modsRegistryDictionary[modFolderPathName];
                            // Add the ModInfo to the DataGrid (You need to bind the DataGrid to ObservableCollection)
                            Class1.Mods_DataGrid_Editor.AddModInfoToUsedModsDataGrid(tempModInfo, UsedMods_DataGrid_ObservableCollection);
                            // Also, add the ModInfo to the dictionary to keep track
                            usedModsInProfile.Add(tempModInfo.ModFolderPathName, tempModInfo);
                        }
                    }
                    // Loop through all mods in the allModsOriginalDictionary
                    foreach (string modFolderPathName in allModsOriginalDictionary.Keys)
                    {
                        // Check if the mod is not already in the usedModsInProfile dictionary
                        if (usedModsInProfile.ContainsKey(modFolderPathName) == false)
                        {
                            // Get the corresponding ModInfo object from the allModsOriginalDictionary
                            Class1.ModInfo tempModInfo = allModsOriginalDictionary[modFolderPathName];
                            // Add the ModInfo to the UnusedMods_DataGrid_ObservableCollection
                            Class1.Mods_DataGrid_Editor.AddModInfoToUnusedModsDataGrid(tempModInfo, UnusedMods_DataGrid_ObservableCollection);
                        }
                    }
                }
            }

            public static void AddModInfoToUnusedModsDataGrid(Class1.ModInfo tempModInfo, ObservableCollection<Class1.ModInfo> UnusedMods_DataGrid_ObservableCollection)
            {
                tempModInfo.ModOrderNumber = -1;
                UnusedMods_DataGrid_ObservableCollection.Add(tempModInfo);
            }

            public static void AddModInfoToUsedModsDataGrid(Class1.ModInfo tempModInfo, ObservableCollection<Class1.ModInfo> UsedMods_DataGrid_ObservableCollection)
            {
                tempModInfo.ModOrderNumber = UsedMods_DataGrid_ObservableCollection.Count;
                UsedMods_DataGrid_ObservableCollection.Add(tempModInfo);
            }

            public static void TransferModInfoFrom_UnusedModsDataGrid_To_UsedModsDataGrid(Class1.ModInfo tempModInfo,
                ObservableCollection<Class1.ModInfo> UnusedMods_DataGrid_ObservableCollection, ObservableCollection<Class1.ModInfo> UsedMods_DataGrid_ObservableCollection)
            {
                Class1.Mods_DataGrid_Editor.AddModInfoToUsedModsDataGrid(tempModInfo, UsedMods_DataGrid_ObservableCollection);
                UnusedMods_DataGrid_ObservableCollection.Remove(tempModInfo);
            }

            public static void TransferModInfoFrom_UsedModsDataGrid_To_UnusedModsDataGrid(Class1.ModInfo tempModInfo,
                ObservableCollection<Class1.ModInfo> UnusedMods_DataGrid_ObservableCollection, ObservableCollection<Class1.ModInfo> UsedMods_DataGrid_ObservableCollection)
            {
                Class1.Mods_DataGrid_Editor.AddModInfoToUnusedModsDataGrid(tempModInfo, UnusedMods_DataGrid_ObservableCollection);
                UsedMods_DataGrid_ObservableCollection.Remove(tempModInfo);
                Class1.Mods_DataGrid_Editor.UpdateModOrderNumberColumn(UsedMods_DataGrid_ObservableCollection);
            }

            public static void UpdateModOrderNumberColumn(ObservableCollection<Class1.ModInfo> UsedMods_DataGrid_ObservableCollection)
            {
                for (int i = 0; i < UsedMods_DataGrid_ObservableCollection.Count; i++)
                {
                    var modInfo = UsedMods_DataGrid_ObservableCollection[i];
                    // If you are tracking ModOrderNumber as a property, set it here
                    modInfo.ModOrderNumber = i; // Or update another way depending on your data model
                }
            }

            public static void SortUnusedModsDataGridBy_ModFolderPathNameAlphabetically(ObservableCollection<Class1.ModInfo> UnusedMods_DataGrid_ObservableCollection)
            {
                var sortedMods = UnusedMods_DataGrid_ObservableCollection
                .OrderBy(mod => mod.ModFolderPathName)
                .ToList();
                // Clear the original collection and add the sorted items back
                UnusedMods_DataGrid_ObservableCollection.Clear();
                foreach (var mod in sortedMods)
                {
                    UnusedMods_DataGrid_ObservableCollection.Add(mod);
                }
            }
        }

    }
}