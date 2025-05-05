using ColorPicker;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static phd2mm_wpf.Class1;
using static phd2mm_wpf.Class2;
using static phd2mm_wpf.Class3;

namespace phd2mm_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    // The ImagePathToFullPathConverter class is used to convert a relative image path to a valid image.
    // If the relative image path is empty or invalid, it returns null, which prevents displaying an image.
    // 
    // Important:
    // This converter should be placed above the MainWindow class declaration in the XAML file's <Window.Resources> section.
    // Placing it below the MainWindow constructor or other XAML content may lead to runtime errors or resource not found issues,
    // as InitializeComponent() will attempt to load resources before they are declared in the XAML.
    // In short, the ImagePathToFullPathConverter class needs to be placed above the MainWindow constructor in the XAML to avoid compilation errors.

    public class ImagePathToFullPathConverter : IValueConverter
    {
        private static readonly string[] ValidExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Ensure the value is a string (your relative image path)
            string relativePath = value as string;

            if (string.IsNullOrEmpty(relativePath))
                return null;

            // Get the base directory path
            string modDirectoryPath = Class1.GetModDirectoryPath();

            // Combine the directory path with the relative image path
            string fullPath = System.IO.Path.Combine(modDirectoryPath, relativePath);

            // Check if the file exists
            if (!System.IO.File.Exists(fullPath))
                return null; // Invalid file, return null

            // Check if the file has a valid image extension
            string extension = System.IO.Path.GetExtension(fullPath)?.ToLower();
            if (Array.IndexOf(ValidExtensions, extension) == -1)
                return null; // Invalid file type, return null

            // Return the full image path
            return new Uri(fullPath, UriKind.Absolute); // Assuming you're working with file URIs
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // No need to implement ConvertBack for this use case.
            throw new NotImplementedException();
        }
    }


    public partial class MainWindow : Window
    {
        // Dictionaries
        private static Dictionary<string, Class1.ModInfo> modsRegistryDictionary = new Dictionary<string, Class1.ModInfo>();
        // private static Dictionary<string, Class1.ModInfo> usedModsOriginalDictionary = new Dictionary<string, Class1.ModInfo>();
        private static Dictionary<string, Class1.ModInfo> allModsOriginalDictionary = new Dictionary<string, Class1.ModInfo>();
        private static Dictionary<string, Class3.ThemeInfo> themesDictionary = new Dictionary<string, Class3.ThemeInfo>();
        private static Dictionary<string, Class3.ProfileSpecificThemeInfo> profileSpecificThemesDictionary = new Dictionary<string, Class3.ProfileSpecificThemeInfo>();
        // Other variables
        private static string RandomizationMode = "OnlyAddGuaranteeOne";
        public ObservableCollection<Class1.ModInfo> UnusedMods_DataGrid_ObservableCollection { get; set; } = new ObservableCollection<Class1.ModInfo>();
        public ObservableCollection<Class1.ModInfo> UsedMods_DataGrid_ObservableCollection { get; set; } = new ObservableCollection<Class1.ModInfo>();
        public ObservableCollection<Class3.ProfileSpecificThemeInfo> Themes_ProfileSpecificThemes_DataGrid_ObservableCollection { get; set; } = new ObservableCollection<Class3.ProfileSpecificThemeInfo>();
        // Themes_ProfileSpecificThemes_DataGrid_ThemeNames_ObservableCollection is for the associated DataGrid, it has empty string that user can select.
        // Empty string in this case means don't use any profile-specific theme for a profile.
        // Themes_ThemeNames_NoEmptyString_ObservableCollection is for the associated ListBox and ComboBox, it doesn't have empty string that user can select.
        public ObservableCollection<string> Themes_ProfileSpecificThemes_DataGrid_ThemeNames_ObservableCollection { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Themes_ThemeNames_NoEmptyString_ObservableCollection { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> ProfilesList_ProfileNames { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> CategoriesAndItemsSorted { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            UnusedMods_DataGrid.PreviewMouseRightButtonDown += DataGrid_PreviewMouseRightButtonDown;
            UsedMods_DataGrid.PreviewMouseRightButtonDown += DataGrid_PreviewMouseRightButtonDown;
            // Get the sorted list of items
            var uniqueSortedItems = Class2.CategoryAndItemsManager.GetCategoriesAndItemsUniqueAndSortedItems();
            // Bind the ComboBox directly
            CategoriesAndItemsSorted = new ObservableCollection<string>(uniqueSortedItems);
            // Create the directories if they do not exist
            Class1.DirectoryAndFileInitializer.InitializeDirectoriesAndFiles();
            Class1.DirectoryAndFileInitializer.InitializeProfilesList_ComboBox(ProfilesList_ProfileNames);
            Class3.ThemesManager.InitializeDefaultThemes(themesDictionary);
            Class3.ThemesFilesEditor.ReadThemes(themesDictionary, Class1.GetThemesDirectoryPath());
            Class3.ThemesManager.InitializeAllThemes(themesDictionary, profileSpecificThemesDictionary, ProfilesList_ProfileNames,
                Themes_ProfileSpecificThemes_DataGrid_ObservableCollection,
                Themes_ProfileSpecificThemes_DataGrid_ThemeNames_ObservableCollection, Themes_ThemeNames_NoEmptyString_ObservableCollection);
            Themes_ThemeNames_ListBox.SelectedIndex = 0;
            Themes_GlobalTheme_ComboBox.SelectedItem = "phd2mm_light";
            Class1.RegistryEditor.ReadRegistry(modsRegistryDictionary);
            Class1.SettingsEditor.ReadSettings(Hd2DataPathPreview_TextBox, LastInstalledProfile_Label,
                UnusedMods_DataGrid, UsedMods_DataGrid,
                Themes_GlobalTheme_ComboBox, ProfilesList_ProfileNames,
                Themes_ProfileSpecificThemes_DataGrid_ThemeNames_ObservableCollection, profileSpecificThemesDictionary,
                Themes_ProfileSpecificThemes_DataGrid_ObservableCollection);
            Class1.ModFinder.ScanModFoldersForPatchFiles(allModsOriginalDictionary, modsRegistryDictionary);
            ProfilesList_ComboBox.SelectedIndex = 0;
            Class2.MoreInfoTexts.SetMoreInfoTexts(MoreInfo_Changelogs_TextBox, MoreInfo_Credits_TextBox);
            // Keep the commented code below that delays selecting the first item in the ProfilesList_ComboBox in case it is needed in the future.
            // Because before, I had to use this workaround so that app won't crash when setting the SelectedIndex of ProfilesList_ComboBox.
            // Something about selecting the first item in the ProfilesList_ComboBox before it is fully loaded crashes the app, despite it being near
            // the end of this constructor. Also something about race conditions and timing issues where it is possible that
            // setting the SelectedIndex of ProfilesList_ComboBox here may come first before UI is fully loaded, crashing the app.
            // The Dispatcher.BeginInvoke is used to queue the code inside it, and combined with DispatcherPriority.Background, which I think delays
            // the execution of the code inside it until the UI is fully loaded and other more important tasks are done.
            // This way, we make sure that ProfilesList_ComboBox is fully loaded before setting its index, preventing the app to crash.
            // 
            //ProfilesList_ComboBox.SelectedIndex = 0;
            //Dispatcher.BeginInvoke(new Action(() =>
            //{
            //    if (ProfilesList_ProfileNames.Count > 0)
            //    {
            //        ProfilesList_ComboBox.SelectedIndex = 0;
            //    }
            //}), DispatcherPriority.Background);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Class1.RegistryEditor.OverwriteRegistry(modsRegistryDictionary);

            string hd2DataPath = Hd2DataPathPreview_TextBox.Text.Replace("\\", "/");
            string lastInstalledProfile = Class1.LastInstalledProfile_LabelEditor.GetLastInstalledProfile(LastInstalledProfile_Label);
            Class3.ThemesFilesEditor.WriteAllThemesToFile(themesDictionary, Class1.GetThemesDirectoryPath());
            // Create a dictionary to hold the visibility status of the columns
            var columnsVisibleOrHiddenDictionary = new Dictionary<string, string>();
            // Handle the first DataGrid (UnusedMods_DataGrid)
            Class1.SettingsEditor.GetColumnVisibility(UnusedMods_DataGrid, columnsVisibleOrHiddenDictionary, "UnusedMods_DataGrid");
            // Handle the second DataGrid (UsedMods_DataGrid)
            Class1.SettingsEditor.GetColumnVisibility(UsedMods_DataGrid, columnsVisibleOrHiddenDictionary, "UsedMods_DataGrid");
            Class1.SettingsEditor.OverwriteSettings(hd2DataPath, lastInstalledProfile,
                columnsVisibleOrHiddenDictionary, Themes_GlobalTheme_ComboBox.SelectedItem.ToString(), profileSpecificThemesDictionary);
        }

        private void BrowseHd2DataPath_Button_Click(object sender, RoutedEventArgs e)
        {
            var folderDialog = new OpenFolderDialog
            {
                // Set options here
            };
            // Show the dialog and check if the user selected a folder
            if (folderDialog.ShowDialog() == true)
            {
                var hd2DirectoryPath = folderDialog.FolderName; // Get the selected folder path
                // Assuming ValidateDirectory is a method in Class1 that you want to use for validation
                if (Class1.DirectoryValidator.ValidateDirectory(hd2DirectoryPath))
                {
                    // Replace backslashes with forward slashes
                    hd2DirectoryPath = hd2DirectoryPath.Replace("\\", "/");
                    // Set the path to the TextBox for preview
                    Hd2DataPathPreview_TextBox.Text = hd2DirectoryPath;
                    // Show success message
                    MessageBox.Show("Helldivers 2 data folder found! Please continue.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void ProfilesList_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProfilesList_ComboBox.SelectedItem != null)
            {
                string currentlySelectedProfile = ProfilesList_ComboBox.SelectedItem.ToString();
                Class1.Mods_DataGrid_Editor.InitializeModsDataGridData(currentlySelectedProfile, ProfilesList_ProfileNames,
                    UnusedMods_DataGrid_ObservableCollection, UsedMods_DataGrid_ObservableCollection,
                    allModsOriginalDictionary, modsRegistryDictionary);
                Class1.Mods_DataGrid_Editor.SortUnusedModsDataGridBy_ModFolderPathNameAlphabetically(UnusedMods_DataGrid_ObservableCollection);
                CheckThemeBeforeApplyingTheme(currentlySelectedProfile);
            }
        }

        private void UsedMods_DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            // Prevent the default sorting behavior
            e.Handled = true;
            // Get the current sort direction (ascending or descending)
            var currentSortDirection = e.Column.SortDirection;
            // Toggle the sort direction
            ListSortDirection newSortDirection = currentSortDirection == ListSortDirection.Ascending
                ? ListSortDirection.Descending
                : ListSortDirection.Ascending;
            // Set the new sort direction for the column
            e.Column.SortDirection = newSortDirection;
            // Sort the ObservableCollection based on the clicked column and new sort direction
            SortObservableCollection(UsedMods_DataGrid_ObservableCollection, e.Column.SortMemberPath, newSortDirection);
            // After sorting, update the ModOrderNumber based on the new order of the ObservableCollection
            Class1.Mods_DataGrid_Editor.UpdateModOrderNumberColumn(UsedMods_DataGrid_ObservableCollection);
        }

        private void SortObservableCollection(ObservableCollection<Class1.ModInfo> collection, string sortBy, ListSortDirection sortDirection)
        {
            List<Class1.ModInfo> sortedList = sortBy switch
            {
                "ModFolderPathName" => sortDirection == ListSortDirection.Ascending
                    ? collection.OrderBy(mod => mod.ModFolderPathName).ToList()
                    : collection.OrderByDescending(mod => mod.ModFolderPathName).ToList(),
                "ModName" => sortDirection == ListSortDirection.Ascending
                    ? collection.OrderBy(mod => mod.ModName).ToList()
                    : collection.OrderByDescending(mod => mod.ModName).ToList(),
                "Item" => sortDirection == ListSortDirection.Ascending
                    ? collection.OrderBy(mod => mod.Item).ToList()
                    : collection.OrderByDescending(mod => mod.Item).ToList(),
                "Category" => sortDirection == ListSortDirection.Ascending
                    ? collection.OrderBy(mod => mod.Category).ToList()
                    : collection.OrderByDescending(mod => mod.Category).ToList(),
                "Description" => sortDirection == ListSortDirection.Ascending
                    ? collection.OrderBy(mod => mod.Description).ToList()
                    : collection.OrderByDescending(mod => mod.Description).ToList(),
                "ImagePath" => sortDirection == ListSortDirection.Ascending
                    ? collection.OrderBy(mod => mod.ImagePath).ToList()
                    : collection.OrderByDescending(mod => mod.ImagePath).ToList(),
                "DateAdded" => sortDirection == ListSortDirection.Ascending
                    ? collection.OrderBy(mod => mod.DateAdded).ToList()
                    : collection.OrderByDescending(mod => mod.DateAdded).ToList(),
                "ModVersion" => sortDirection == ListSortDirection.Ascending
                    ? collection.OrderBy(mod => mod.ModVersion).ToList()
                    : collection.OrderByDescending(mod => mod.ModVersion).ToList(),
                "ModLink" => sortDirection == ListSortDirection.Ascending
                    ? collection.OrderBy(mod => mod.ModLink).ToList()
                    : collection.OrderByDescending(mod => mod.ModLink).ToList(),
                _ => collection.OrderBy(mod => mod.ModOrderNumber).ToList(), // Default sorting by ModOrderNumber
            };
            // Clear and repopulate the ObservableCollection with the sorted data
            collection.Clear();
            foreach (var item in sortedList)
            {
                collection.Add(item);
            }
        }

        private void SearchMod_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Convert search text to lowercase for case-insensitive search
            string search = SearchMod_TextBox.Text.ToLower();

            // Apply filter to the UnusedMods_DataGrid_ObservableCollection using a CollectionView
            var unusedModsCollectionView = CollectionViewSource.GetDefaultView(UnusedMods_DataGrid_ObservableCollection);
            unusedModsCollectionView.Filter = item =>
            {
                var modInfo = item as Class1.ModInfo;
                return modInfo != null && modInfo.GetType()
                    .GetProperties()
                    .Any(prop => prop.GetValue(modInfo)?.ToString().ToLower().Contains(search) == true);
            };
            // Apply filter to the UsedMods_DataGrid_ObservableCollection using a CollectionView
            var usedModsCollectionView = CollectionViewSource.GetDefaultView(UsedMods_DataGrid_ObservableCollection);
            usedModsCollectionView.Filter = item =>
            {
                var modInfo = item as Class1.ModInfo;
                return modInfo != null && modInfo.GetType()
                    .GetProperties()
                    .Any(prop => prop.GetValue(modInfo)?.ToString().ToLower().Contains(search) == true);
            };
        }

        private void CreateProfile_Button_Click(object sender, RoutedEventArgs e)
        {
            string createOrDuplicateOption = "CreateProfile";
            // Create and show the new profile form
            Window1_CreateOrDuplicateProfile window1 = new Window1_CreateOrDuplicateProfile();
            window1.createOrDuplicateOption = createOrDuplicateOption;
            window1.ProfilesList_ProfileNames = ProfilesList_ProfileNames;
            window1.ShowDialog();
            if (string.IsNullOrEmpty(window1.newProfileName) == false)
            {
                // Add the new profile to the ComboBox
                ProfilesList_ProfileNames.Add(window1.newProfileName);
                // Get the directory for the profile
                string profileDirectoryPath = Class1.GetProfileDirectoryPath(); // Define your path here
                // Create the profile text file
                string newProfilePath = System.IO.Path.Combine(profileDirectoryPath, window1.newProfileName + ".txt");
                Class1.DirectoryAndFileInitializer.InitializeFiles(newProfilePath);
            }
        }

        private void DuplicateProfile_Button_Click(object sender, RoutedEventArgs e)
        {
            string createOrDuplicateOption = "DuplicateProfile";
            string currentlySelectedProfile = ProfilesList_ComboBox.SelectedItem.ToString();
            // Create and show the new profile form
            Window1_CreateOrDuplicateProfile window1 = new Window1_CreateOrDuplicateProfile();
            window1.createOrDuplicateOption = createOrDuplicateOption;
            window1.ProfilesList_ProfileNames = ProfilesList_ProfileNames;
            window1.profileToDuplicate = currentlySelectedProfile;
            window1.ShowDialog();
            if (string.IsNullOrEmpty(window1.newProfileName) == false)
            {
                // Add the new profile to the ComboBox
                ProfilesList_ProfileNames.Add(window1.newProfileName);
                // Get the directory for the profile
                string profileDirectoryPath = Class1.GetProfileDirectoryPath(); // Define your path here
                // Duplicate the profile text file
                string oldProfilePath = System.IO.Path.Combine(profileDirectoryPath, window1.profileToDuplicate + ".txt");
                string newProfilePath = System.IO.Path.Combine(profileDirectoryPath, window1.newProfileName + ".txt");
                File.Copy(oldProfilePath, newProfilePath, overwrite: true);
            }
        }

        private void SaveProfile_Button_Click(object sender, RoutedEventArgs e)
        {
            string tempString1 = $"Are you sure you want to save the current mod list to the selected profile?\n{ProfilesList_ComboBox.SelectedItem}";
            MessageBoxResult confirmSaveCurrentProfile = MessageBox.Show(tempString1, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirmSaveCurrentProfile == MessageBoxResult.Yes)
            {
                string currentlySelectedProfile = ProfilesList_ComboBox.SelectedItem.ToString();
                Class1.FilesSaver.SaveProfile(currentlySelectedProfile, UsedMods_DataGrid_ObservableCollection);
                MessageBox.Show($"Mod list order saved in: phd2mm_profiles\\{currentlySelectedProfile}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteProfile_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ProfilesList_ProfileNames.Count > 1)
            {
                if (ProfilesList_ComboBox.SelectedItem != null)
                {
                    string tempString1 = $"Are you sure you want to delete the current profile?\nProfile: {ProfilesList_ComboBox.SelectedItem}\nThis action cannot be reversed.";
                    MessageBoxResult confirmDeleteCurrentProfile = MessageBox.Show(tempString1, "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (confirmDeleteCurrentProfile == MessageBoxResult.Yes)
                    {
                        string profileToDelete = ProfilesList_ComboBox.SelectedItem.ToString();
                        ProfilesList_ProfileNames.Remove(profileToDelete);
                        ProfilesList_ComboBox.SelectedIndex = 0;
                        Class1.FilesDeleter.DeleteProfile(profileToDelete);
                    }
                }
            }
            else
            {
                string tempString1 = $"Cannot delete profile:\n{ProfilesList_ComboBox.SelectedItem}\nbecause it is the only profile left!\nPlease create another profile first.";
                MessageBox.Show(tempString1, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteAllInstalledMods_Button_Click(object sender, RoutedEventArgs e)
        {
            string tempString1 = "Are you sure you want to delete all currently installed mods? This action cannot be reversed.";
            MessageBoxResult confirmDeleteAllInstalledMods = MessageBox.Show(tempString1, "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (confirmDeleteAllInstalledMods == MessageBoxResult.Yes)
            {
                string hd2DirectoryPath = Hd2DataPathPreview_TextBox.Text;
                // Validate the directory
                if (Class1.DirectoryValidator.ValidateDirectory(hd2DirectoryPath))
                {
                    // Perform the mod uninstallation
                    Class1.FilesDeleter.DeleteModsInThisDirectory(hd2DirectoryPath);
                    hd2DirectoryPath = hd2DirectoryPath.Replace("\\", "/");
                    Hd2DataPathPreview_TextBox.Text = hd2DirectoryPath;
                    MessageBox.Show("Deleted all currently installed mods.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void InstallMods_Button_Click(object sender, RoutedEventArgs e)
        {
            string tempString1 = $"Are you sure you want to install all mods from current profile? This will delete all your currently installed Helldivers 2 mods.\n" +
                         $"Current profile: {ProfilesList_ComboBox.SelectedItem}";
            MessageBoxResult confirmInstallMods = MessageBox.Show(tempString1, "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (confirmInstallMods == MessageBoxResult.Yes)
            {
                string hd2DirectoryPath = Hd2DataPathPreview_TextBox.Text;
                if (Class1.DirectoryValidator.ValidateDirectory(hd2DirectoryPath))
                {
                    List<string> modList = new List<string>();
                    // Loop through each DataGrid row to get mod folder paths
                    foreach (var modRow in UsedMods_DataGrid.Items)
                    {
                        var modInfo = modRow as Class1.ModInfo; // Assuming each row is of type ModInfo
                        if (modInfo != null)
                        {
                            modList.Add(modInfo.ModFolderPathName); // Assuming ModFolderPathName is the property name
                        }
                    }
                    Window2_InstallMods window2 = new Window2_InstallMods
                    {
                        //currentGlobalTheme = currentGlobalTheme,
                        hd2DirectoryPath = Hd2DataPathPreview_TextBox.Text,
                        modDirectoryPath = Class1.GetModDirectoryPath(), // Assuming modDirectoryPath is defined elsewhere
                        profileName = ProfilesList_ComboBox.SelectedItem.ToString(),
                        selectedModsList = modList
                    };
                    Class1.LastInstalledProfile_LabelEditor.SetLastInstalledProfile(LastInstalledProfile_Label, ProfilesList_ComboBox.SelectedItem.ToString());
                    hd2DirectoryPath = hd2DirectoryPath.Replace("\\", "/");
                    Hd2DataPathPreview_TextBox.Text = hd2DirectoryPath;
                    window2.ShowDialog();
                }
            }
        }

        private void AddSelectedMod_Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected item in UnusedMods_DataGrid
            var selectedMod = UnusedMods_DataGrid.SelectedItem as Class1.ModInfo;
            if (selectedMod != null)
            {
                Class1.Mods_DataGrid_Editor.TransferModInfoFrom_UnusedModsDataGrid_To_UsedModsDataGrid(selectedMod,
                    UnusedMods_DataGrid_ObservableCollection, UsedMods_DataGrid_ObservableCollection);
            }
        }

        private void RemoveSelectedMod_Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected item in UsedMods_DataGrid
            var selectedMod = UsedMods_DataGrid.SelectedItem as Class1.ModInfo;
            if (selectedMod != null)
            {
                Class1.Mods_DataGrid_Editor.TransferModInfoFrom_UsedModsDataGrid_To_UnusedModsDataGrid(selectedMod,
                    UnusedMods_DataGrid_ObservableCollection, UsedMods_DataGrid_ObservableCollection);
            }
        }

        private void UnusedMods_DataGrid_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            // Perform hit test to determine where the user double-clicked
            var hit = e.OriginalSource as DependencyObject;
            // Check if the double-clicked item is a row header
            var rowHeader = FindParent<DataGridRowHeader>(hit);
            if (rowHeader != null)
            {
                var row = rowHeader.DataContext as Class1.ModInfo;
                if (row != null)
                {
                    // Transfer logic when double-clicking the row header
                    Class1.Mods_DataGrid_Editor.TransferModInfoFrom_UnusedModsDataGrid_To_UsedModsDataGrid(row,
                        UnusedMods_DataGrid_ObservableCollection, UsedMods_DataGrid_ObservableCollection);
                }
                return;
            }
            // Check if the double-clicked item is a cell in the "Mod Folder Path + Name" column
            var cell = FindParent<DataGridCell>(hit);
            if (cell != null && cell.Column.Header.ToString() == "Mod Folder Path + Name")
            {
                var selectedMod = cell.DataContext as Class1.ModInfo;
                if (selectedMod != null)
                {
                    // Transfer logic when double-clicking the specific column
                    Class1.Mods_DataGrid_Editor.TransferModInfoFrom_UnusedModsDataGrid_To_UsedModsDataGrid(selectedMod,
                        UnusedMods_DataGrid_ObservableCollection, UsedMods_DataGrid_ObservableCollection);
                }
            }
        }

        private void UsedMods_DataGrid_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            // Perform hit test to determine where the user double-clicked
            var hit = e.OriginalSource as DependencyObject;
            // Check if the double-clicked item is a row header
            var rowHeader = FindParent<DataGridRowHeader>(hit);
            if (rowHeader != null)
            {
                var row = rowHeader.DataContext as Class1.ModInfo;
                if (row != null)
                {
                    // Transfer logic when double-clicking the row header
                    Class1.Mods_DataGrid_Editor.TransferModInfoFrom_UsedModsDataGrid_To_UnusedModsDataGrid(row,
                        UnusedMods_DataGrid_ObservableCollection, UsedMods_DataGrid_ObservableCollection);
                }
                return;
            }
            // Check if the double-clicked item is a cell in the "Mod Folder Path + Name" column
            var cell = FindParent<DataGridCell>(hit);
            if (cell != null && cell.Column.Header.ToString() == "Mod Folder Path + Name")
            {
                var selectedMod = cell.DataContext as Class1.ModInfo;
                if (selectedMod != null)
                {
                    // Transfer logic when double-clicking the specific column
                    Class1.Mods_DataGrid_Editor.TransferModInfoFrom_UsedModsDataGrid_To_UnusedModsDataGrid(selectedMod,
                        UnusedMods_DataGrid_ObservableCollection, UsedMods_DataGrid_ObservableCollection);
                }
            }
        }

        private T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parent = child;
            while (parent != null && !(parent is T))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return parent as T;
        }

        
        private void MoveModUp_Button_Click(object sender, RoutedEventArgs e)
        {
            // Check if any cell is selected
            if (UsedMods_DataGrid.SelectedCells.Count > 0)
            {
                // Get the first selected cell's row index
                var selectedCell = UsedMods_DataGrid.SelectedCells[0];
                var row = selectedCell.Item as Class1.ModInfo;
                if (row != null)
                {
                    // Find the index of the selected mod in the ObservableCollection
                    int selectedIndex = UsedMods_DataGrid_ObservableCollection.IndexOf(row);
                    // If the selected row is not the first one, move it up
                    if (selectedIndex > 0)
                    {
                        // Get the mod at the previous index
                        var modAbove = UsedMods_DataGrid_ObservableCollection[selectedIndex - 1];
                        // Update ModOrderNumber for both rows
                        row.ModOrderNumber = selectedIndex - 1; // Set the ModOrderNumber of the moved row
                        modAbove.ModOrderNumber = selectedIndex; // Set the ModOrderNumber of the row above
                        // Swap the selected item with the item above it
                        UsedMods_DataGrid_ObservableCollection.Move(selectedIndex, selectedIndex - 1);
                        // Optionally, reselect the moved row
                        UsedMods_DataGrid.SelectedItem = UsedMods_DataGrid_ObservableCollection[selectedIndex - 1];
                    }
                }
            }
        }

        private void MoveModDown_Button_Click(object sender, RoutedEventArgs e)
        {
            // Check if any cell is selected
            if (UsedMods_DataGrid.SelectedCells.Count > 0)
            {
                // Get the first selected cell's row index
                var selectedCell = UsedMods_DataGrid.SelectedCells[0];
                var row = selectedCell.Item as Class1.ModInfo;
                if (row != null)
                {
                    // Find the index of the selected mod in the ObservableCollection
                    int selectedIndex = UsedMods_DataGrid_ObservableCollection.IndexOf(row);
                    // If the selected row is not the last one, move it down
                    if (selectedIndex < UsedMods_DataGrid_ObservableCollection.Count - 1)
                    {
                        // Get the mod at the next index
                        var modBelow = UsedMods_DataGrid_ObservableCollection[selectedIndex + 1];
                        // Update ModOrderNumber for both rows
                        row.ModOrderNumber = selectedIndex + 1; // Set the ModOrderNumber of the moved row
                        modBelow.ModOrderNumber = selectedIndex; // Set the ModOrderNumber of the row below
                        // Swap the selected item with the item below it
                        UsedMods_DataGrid_ObservableCollection.Move(selectedIndex, selectedIndex + 1);
                        // Optionally, reselect the moved row
                        UsedMods_DataGrid.SelectedItem = UsedMods_DataGrid_ObservableCollection[selectedIndex + 1];
                    }
                }
            }
        }

        // DRAG AND DROP RELATED CODE FOR UsedMods_DataGrid --- START
        // Field to store the ModFolderPathName of the dragged row
        private string draggedModFolderPathName;

        // Check this code later, may have a bug related to UpdateModOrderNumberColumn
        private void UsedMods_DataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid.SelectionMode == DataGridSelectionMode.Single && (Keyboard.Modifiers & ModifierKeys.Control) != 0)
            {
                // Prevent the action if Ctrl is held down and SelectionMode is Single
                e.Handled = true;
            }
            var hit = e.OriginalSource as DependencyObject;
            // Check if the clicked element is a DataGridRow or DataGridCell
            var rowHeader = FindParent<DataGridRowHeader>(hit);
            var cell = FindParent<DataGridCell>(hit);
            // If the clicked element is a row header or a specific cell (Mod Folder Path + Name)
            if (rowHeader != null || (cell != null && cell.Column.Header.ToString() == "Mod Folder Path + Name"))
            {
                // Get the mod info from the row's data context
                var row = ItemsControl.ContainerFromElement(dataGrid, hit) as DataGridRow;
                if (row != null)
                {
                    var selectedMod = row.DataContext as Class1.ModInfo;
                    if (selectedMod != null)
                    {
                        // Record the ModFolderPathName before initiating the drag
                        draggedModFolderPathName = selectedMod.ModFolderPathName;
                        // Ensure the row is selected before starting the drag
                        if (!row.IsSelected)
                        {
                            row.IsSelected = true;
                            dataGrid.SelectedItem = selectedMod; // Ensure the row is selected in the DataGrid as well
                        }
                        // Initiate the drag operation for the selected row
                        DataObject data = new DataObject("ModInfo", selectedMod);
                        DragDrop.DoDragDrop(row, data, DragDropEffects.Move);
                    }
                }
            }
        }

        private void UsedMods_DataGrid_Drop(object sender, DragEventArgs e)
        {
            // Ensure the dragged data is of type ModInfo
            if (e.Data.GetDataPresent("ModInfo"))
            {
                var draggedMod = e.Data.GetData("ModInfo") as Class1.ModInfo;
                var dataGrid = sender as DataGrid;
                // Get the target row (the row where the user drops the dragged row)
                var hit = e.OriginalSource as DependencyObject;
                var targetRow = ItemsControl.ContainerFromElement(dataGrid, hit) as DataGridRow;
                if (targetRow != null)
                {
                    // Get the index of the target row
                    int targetIndex = dataGrid.Items.IndexOf(targetRow.DataContext);
                    // Get the current index of the dragged row
                    int draggedIndex = dataGrid.Items.IndexOf(draggedMod);
                    // If the dragged row is not already in the target position
                    if (draggedIndex != targetIndex)
                    {
                        // Remove the dragged item and insert it at the new position within the same collection
                        UsedMods_DataGrid_ObservableCollection.Remove(draggedMod);
                        UsedMods_DataGrid_ObservableCollection.Insert(targetIndex, draggedMod);
                        Class1.Mods_DataGrid_Editor.UpdateModOrderNumberColumn(UsedMods_DataGrid_ObservableCollection);
                    }
                    // After the drop, find and select the dropped row based on the recorded ModFolderPathName
                    var droppedMod = UsedMods_DataGrid_ObservableCollection.FirstOrDefault(mod => mod.ModFolderPathName == draggedModFolderPathName);
                    if (droppedMod != null)
                    {
                        dataGrid.SelectedItem = droppedMod; // Select the item based on ModFolderPathName
                    }
                }
            }
        }

        private void UsedMods_DataGrid_DragOver(object sender, DragEventArgs e)
        {
            // Allow the drop only if the dragged data is of type ModInfo
            if (!e.Data.GetDataPresent("ModInfo"))
            {
                e.Effects = DragDropEffects.None;
            }
            else
            {
                e.Effects = DragDropEffects.Move;
            }
        }
        // DRAG AND DROP RELATED CODE FOR UsedMods_DataGrid --- END

        // WALL OF TEXT INCOMING FOR ItemComboBox_SelectionChanged method:
        // Works together with Class1.ModInfo.UpdateCategories() method
        // to update the Category ComboBox column cell selection choices based on the selected Item column cell value in the ComboBox.
        // If the value of the Category ComboBox column does not exist in the new Category ComboBox column
        // selection choices, then it will be set to the first item in the new Category ComboBox column selection choices.
        // However, if the Category ComboBox column cell selection choices are the same as the previous Category ComboBox column cell selection choices,
        // then the Category ComboBox column cell value will not be changed. I don't know how to reset it to the first Category selection choice.
        // This means, for example:
        // "AR-23 Liberator" and "AR-61 Tenderizer" items have both Category selection choices: "Weapon Audio" and "Weapon Skin".
        // If the old Item value was "AR-23 Liberator" and the old Category value was "Weapon Skin",
        // then changing to a new Item value "AR-61 Tenderizer" will keep the old Category value "Weapon Skin",
        // instead of resetting it to the first choice, which would be "Weapon Audio" in this case.
        private void ItemComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0 || e.RemovedItems.Count == 0)
                return;
            var comboBox = sender as ComboBox;
            if (comboBox == null || comboBox.SelectedItem == null)
                return;
            var newValue = comboBox.SelectedItem.ToString();
            var oldValue = e.RemovedItems[0]?.ToString();
            if (newValue == oldValue)
                return;
            var dataGrid = FindParent<DataGrid>(comboBox);
            Dispatcher.BeginInvoke(new Action(() =>
            {
                dataGrid.CommitEdit(DataGridEditingUnit.Cell, true);
                dataGrid.CommitEdit(DataGridEditingUnit.Row, true);
            }), DispatcherPriority.Background);
        }

        // WALL OF TEXT INCOMING:
        // The UnusedMods_DataGrid_CellEditEnding and UsedMods_DataGrid_CellEditEnding methods contain this code:
        // if (e.Column.Header.ToString() == "Category")
        // It does the following:
        // Check if the edited column is "Category". If yes, then use Dispatcher.BeginInvoke to delay the commit edit until the cell edit is finished.
        // This prevents the DataGrid from committing the edit before the new value is set, avoiding a loop that could lead to a crash.
        // Why do we even need this method?
        // Because this is important for the Category ComboBox column cell value.
        // Without this method, the user would have to lose focus on the currently selected row (e.g., by selecting another row or cell) before the changes are saved.
        // With this, the user can select any Category option in the ComboBox, and the changes will be saved immediately without having to lose focus on the
        // currently selected row.
        // The changes to Category value will also save when user wants
        // to immediately do anything else like transferring the mod row from one DataGrid to another DataGrid.
        private void UnusedMods_DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column.Header.ToString() == "Category")
            {
                var dataGrid = sender as DataGrid;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    dataGrid.CommitEdit(DataGridEditingUnit.Cell, true);
                    dataGrid.CommitEdit(DataGridEditingUnit.Row, true);
                }), DispatcherPriority.Background);
            }
        }

        private void UsedMods_DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column.Header.ToString() == "Category")
            {
                var dataGrid = sender as DataGrid;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    dataGrid.CommitEdit(DataGridEditingUnit.Cell, true);
                    dataGrid.CommitEdit(DataGridEditingUnit.Row, true);
                }), DispatcherPriority.Background);
            }
            // Check if the edited column is ModOrderNumber
            if (e.Column.Header.ToString() == "Order")
            {
                var modInfo = e.Row.Item as Class1.ModInfo;
                if (modInfo != null)
                {
                    // Get the edited value (the new order number)
                    var newOrderNumber = (e.EditingElement as TextBox)?.Text;
                    if (int.TryParse(newOrderNumber, out int orderNumber))
                    {
                        // Check if the order number is within a valid range
                        if (orderNumber >= 0 && orderNumber < UsedMods_DataGrid.Items.Count)
                        {
                            // Move the row to the new index
                            MoveRowToNewIndex(modInfo, orderNumber);
                            //Class1.Mods_DataGrid_Editor.UpdateModOrderNumberColumn(UsedMods_DataGrid_ObservableCollection);
                        }
                        else
                        {
                            // Display a message or revert the value if invalid
                            MessageBox.Show("Invalid order number. It must be between 0 and " + (UsedMods_DataGrid.Items.Count - 1),
                                 "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        Class1.Mods_DataGrid_Editor.UpdateModOrderNumberColumn(UsedMods_DataGrid_ObservableCollection);
                        // Use Dispatcher to delay the selection logic until the DataGrid updates its state
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            // Select the moved row
                            UsedMods_DataGrid.SelectedItem = modInfo;
                            // Focus the ModOrderNumber cell
                            var cellInfo = new DataGridCellInfo(modInfo, e.Column);
                            UsedMods_DataGrid.CurrentCell = cellInfo;
                        }));
                    }
                    else
                    {
                        // Handle invalid number input
                        //MessageBox.Show("Please enter a valid number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

        }

        private void MoveRowToNewIndex(ModInfo modInfo, int newOrderNumber)
        {
            // Find the current index of the row in the correct ObservableCollection
            int currentIndex = UsedMods_DataGrid_ObservableCollection.IndexOf(modInfo);

            if (currentIndex == -1)
            {
                return; // Item not found in the collection
            }
            // Remove the item from the collection
            UsedMods_DataGrid_ObservableCollection.Remove(modInfo);
            // Insert the item at the new index
            UsedMods_DataGrid_ObservableCollection.Insert(newOrderNumber, modInfo);
            // Optionally, you may need to update the ModOrderNumber property
            modInfo.ModOrderNumber = newOrderNumber;
            // Refresh the DataGrid (if needed, though ObservableCollection should handle this)
            //UsedMods_DataGrid.Items.Refresh();
        }

        // Code to for right-clicking any column header then showing a context menu which allows
        // user to show or hide columns except for the row header, Order/ModOrderNumber, and ModFolderPathName/Mod Folder Path + Name columns.
        private void UsedMods_DataGrid_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allow only numeric input
            e.Handled = !IsTextNumeric(e.Text);
        }

        // Helper method to check if the input is numeric
        private bool IsTextNumeric(string text)
        {
            return int.TryParse(text, out _);
        }

        private void DataGrid_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Get the DataGrid
            var dataGrid = sender as DataGrid;
            // Hit test to check if we clicked on a column header
            var hit = e.OriginalSource as DependencyObject;
            var columnHeader = FindParent<DataGridColumnHeader>(hit);
            if (columnHeader != null)
            {
                // Create a context menu
                var contextMenu = new ContextMenu();
                // Loop through all columns in the DataGrid
                foreach (var column in dataGrid.Columns)
                {
                    // Skip RowHeader, "Mod Folder Path Name", and Order or ModOrderNumber column.
                    if (column.Header.ToString() == "Row Header" || column.Header.ToString() == "Order" || column.Header.ToString() == "Mod Folder Path + Name")
                    {
                        continue;
                    }
                    // Create a MenuItem for each column
                    var menuItem = new MenuItem
                    {
                        Header = column.Header.ToString(),
                        IsCheckable = true,
                        IsChecked = column.Visibility == Visibility.Visible
                    };
                    // Add event handler to toggle visibility when the menu item is clicked
                    menuItem.Click += (s, args) =>
                    {
                        column.Visibility = column.Visibility == Visibility.Visible
                            ? Visibility.Collapsed
                            : Visibility.Visible;
                        menuItem.IsChecked = column.Visibility == Visibility.Visible;
                    };
                    // Add the MenuItem to the context menu
                    contextMenu.Items.Add(menuItem);
                }
                // Show the context menu at the mouse position
                contextMenu.IsOpen = true;
            }
        }

        private void DataGrid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Get the DataGrid
            var dataGrid = sender as DataGrid;

            // Hit test to check if we clicked on a column header
            var hit = e.OriginalSource as DependencyObject;
            var columnHeader = FindParent<DataGridColumnHeader>(hit);

            // Check if the right-click was on a DataGridCell
            var cell = FindParent<DataGridCell>(hit);
            if (cell != null)
            {
                dataGrid.SelectedItem = cell.DataContext; // Select the item in the DataGrid
                // Create the context menu dynamically
                ContextMenu contextMenu = new ContextMenu();
                // Add the "Show Mod Folder" menu item
                MenuItem showFolderItem = new MenuItem { Header = "Open Mod Folder" };
                showFolderItem.Click += ShowFolderMenuItem_Click;
                contextMenu.Items.Add(showFolderItem);
                // Add the "Open this link" menu item
                MenuItem openLinkItem = new MenuItem { Header = "Open Mod Link in your Default Browser" };
                openLinkItem.Click += OpenLinkMenuItem_Click;
                contextMenu.Items.Add(openLinkItem);
                // Get the row and mod info from the clicked cell's data context
                var row = ItemsControl.ContainerFromElement(dataGrid, hit) as DataGridRow;
                if (row != null)
                {
                    var selectedMod = row.DataContext as Class1.ModInfo;
                    if (selectedMod != null)
                    {
                        // Store the ModFolderPathName for the "Show Mod Folder" menu item
                        showFolderItem.Tag = System.IO.Path.Combine(Class1.GetModDirectoryPath(), selectedMod.ModFolderPathName.Replace("/", "\\"));

                        // Store the ModLink for the "Open this link" menu item
                        string modLink = selectedMod.ModLink?.Trim(); // Clean up the link
                        openLinkItem.Tag = modLink; // Store the link in the tag
                    }
                }
                // Show the context menu at the mouse position
                contextMenu.PlacementTarget = dataGrid;
                contextMenu.IsOpen = true;
            }
        }


        // Show folder when menu item is clicked
        private void ShowFolderMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                // Retrieve the ModFolderPathName from the Tag property
                string folderPath = menuItem.Tag as string;
                if (!string.IsNullOrEmpty(folderPath) && Directory.Exists(folderPath))
                {
                    // Ensure the folder path is properly quoted before passing to explorer.exe
                    // This is important for paths with spaces and some special characters, otherwise it won't work.
                    string quotedFolderPath = "\"" + folderPath + "\"";
                    // Open the folder using the system's file explorer
                    System.Diagnostics.Process.Start("explorer.exe", quotedFolderPath);
                }
                else
                {
                    MessageBox.Show("Folder not found or invalid path.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void OpenLinkMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            var link = menuItem?.Tag as string;
            // Trim any leading or trailing whitespace from the link
            link = link?.Trim();
            // Check if the link is not null or empty and is a valid URI
            if (!string.IsNullOrEmpty(link))
            {
                Uri uriResult;
                bool isValidUri = Uri.TryCreate(link, UriKind.Absolute, out uriResult)
                                  && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                if (isValidUri)
                {
                    // Open the link in the default browser
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = link,
                        UseShellExecute = true
                    });
                }
                else
                {
                    // If it's an invalid URL, show an error message
                    MessageBox.Show($"Invalid mod link. Please provide a valid URL starting with http:// or https://.\nMod link: {link}",
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                // Optionally, you can still show a message if the link is empty
                MessageBox.Show("No mod link provided.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton checkedRadioButton = sender as RadioButton;

            if (checkedRadioButton != null)
            {
                switch (checkedRadioButton.Name)
                {
                    case "ModRandomizationOAHG_RadioButton":
                        RandomizationMode = "OnlyAddGuaranteeOne";
                        break;
                    case "ModRandomizationOANG_RadioButton":
                        RandomizationMode = "OnlyAddNoGuarantee";
                        break;
                    case "ModRandomizationARHG_RadioButton":
                        RandomizationMode = "AddRemoveGuaranteeOne";
                        break;
                    case "ModRandomizationARNG_RadioButton":
                        RandomizationMode = "AddRemoveNoGuarantee";
                        break;
                }
            }
        }

        private void RandomizeMods_Button_Click(object sender, RoutedEventArgs e)
        {
            string tempString1 = "Are you sure you want to randomize the mods?\nCurrent mod randomization option:";
            string tempString2 = "";
            // Switch statement based on the randomizationMode
            switch (RandomizationMode)
            {
                case "OnlyAddGuaranteeOne":
                    tempString2 = ModRandomizationOAHG_RadioButton.Content.ToString();
                    break;
                case "OnlyAddNoGuarantee":
                    tempString2 = ModRandomizationOANG_RadioButton.Content.ToString();
                    break;
                case "AddRemoveGuaranteeOne":
                    tempString2 = ModRandomizationARHG_RadioButton.Content.ToString();
                    break;
                case "AddRemoveNoGuarantee":
                    tempString2 = ModRandomizationARNG_RadioButton.Content.ToString();
                    break;
            }
            string tempString3 = tempString1 + "\n" + tempString2;
            // MessageBox for confirmation
            MessageBoxResult confirmModRandomization = MessageBox.Show(tempString3, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirmModRandomization == MessageBoxResult.Yes)
            {
                // Call your randomizer method
                Class2.ModRandomizer.RandomizeMods(RandomizationMode, allModsOriginalDictionary, UnusedMods_DataGrid_ObservableCollection, UsedMods_DataGrid_ObservableCollection);
                Class1.Mods_DataGrid_Editor.UpdateModOrderNumberColumn(UsedMods_DataGrid_ObservableCollection);
            }
        }

        private void Themes_CreateTheme_Button_Click(object sender, RoutedEventArgs e)
        {
            string createOrDuplicateOption = "CreateTheme";
            // Create and show the new profile form
            Window3_CreateOrDuplicateTheme window3 = new Window3_CreateOrDuplicateTheme();
            window3.createOrDuplicateOption = createOrDuplicateOption;
            List<string> themeNamesList = Themes_ThemeNames_ListBox.Items.Cast<string>().ToList();
            window3.themeNamesList = themeNamesList;
            window3.ShowDialog();
            if (string.IsNullOrEmpty(window3.newThemeName) == false)
            {
                // Get the directory for the theme
                string themeDirectoryPath = Class1.GetThemesDirectoryPath();
                // Create the theme text file
                string newThemePath = System.IO.Path.Combine(themeDirectoryPath, window3.newThemeName + ".json");
                // Assuming the new theme name is added to the dictionary, and you want to save it:
                // Write the theme to the file, and read it.
                var baseTheme = themesDictionary["phd2mm_light"];
                var serialized = JsonSerializer.Serialize(baseTheme);
                var phd2mm_lightThemeInfoForNewTheme = JsonSerializer.Deserialize<Class3.ThemeInfo>(serialized);
                phd2mm_lightThemeInfoForNewTheme.ThemeName = window3.newThemeName;
                Class3.ThemesFilesEditor.WriteThemeToFile(
                    new KeyValuePair<string, ThemeInfo>(window3.newThemeName, phd2mm_lightThemeInfoForNewTheme),
                    newThemePath
                );
                Class3.ThemesFilesEditor.ReadThemesFile(themesDictionary, newThemePath);
                Themes_ProfileSpecificThemes_DataGrid_ThemeNames_ObservableCollection.Add(window3.newThemeName);
                Themes_ThemeNames_NoEmptyString_ObservableCollection.Add(window3.newThemeName);
                // Sort both ObservableCollections
                SortThemeOptionsObservableCollection(Themes_ProfileSpecificThemes_DataGrid_ThemeNames_ObservableCollection);
                SortThemeOptionsObservableCollection(Themes_ThemeNames_NoEmptyString_ObservableCollection);
            }
        }

        private void Themes_DuplicateTheme_Button_Click(object sender, RoutedEventArgs e)
        {
            string createOrDuplicateOption = "DuplicateTheme";
            string currentlySelectedTheme = Themes_ThemeNames_ListBox.SelectedItem.ToString();
            // Create and show the new profile form
            Window3_CreateOrDuplicateTheme window3 = new Window3_CreateOrDuplicateTheme();
            window3.createOrDuplicateOption = createOrDuplicateOption;
            List<string> themeNamesList = Themes_ThemeNames_ListBox.Items.Cast<string>().ToList();
            window3.themeNamesList = themeNamesList;
            window3.themeToDuplicate = currentlySelectedTheme;
            window3.ShowDialog();
            if (string.IsNullOrEmpty(window3.newThemeName) == false)
            {
                // Get the directory for the theme
                string themeDirectoryPath = Class1.GetThemesDirectoryPath(); // Define your path here
                // Duplicate the theme text file
                string newThemePath = System.IO.Path.Combine(themeDirectoryPath, window3.newThemeName + ".json");
                // Write the theme to the file, and read it.
                var baseTheme = themesDictionary[window3.themeToDuplicate];
                var serialized = JsonSerializer.Serialize(baseTheme);
                var phd2mm_lightThemeInfoForNewTheme = JsonSerializer.Deserialize<Class3.ThemeInfo>(serialized);
                phd2mm_lightThemeInfoForNewTheme.ThemeName = window3.newThemeName;
                Class3.ThemesFilesEditor.WriteThemeToFile(
                    new KeyValuePair<string, ThemeInfo>(window3.newThemeName, phd2mm_lightThemeInfoForNewTheme),
                    newThemePath
                );
                Class3.ThemesFilesEditor.ReadThemesFile(themesDictionary, newThemePath);
                Themes_ProfileSpecificThemes_DataGrid_ThemeNames_ObservableCollection.Add(window3.newThemeName);
                Themes_ThemeNames_NoEmptyString_ObservableCollection.Add(window3.newThemeName);
                // Sort both ObservableCollections
                SortThemeOptionsObservableCollection(Themes_ProfileSpecificThemes_DataGrid_ThemeNames_ObservableCollection);
                SortThemeOptionsObservableCollection(Themes_ThemeNames_NoEmptyString_ObservableCollection);
            }
        }

        // Helper method to sort an ObservableCollection
        private void SortThemeOptionsObservableCollection(ObservableCollection<string> collection)
        {
            var collectionView = (CollectionView)CollectionViewSource.GetDefaultView(collection);
            collectionView.SortDescriptions.Clear();
            collectionView.SortDescriptions.Add(new SortDescription("ThemeName", ListSortDirection.Ascending));
        }

        private void Themes_DeleteTheme_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Themes_ThemeNames_ListBox.Items.Count > 1)
            {
                if (Themes_ThemeNames_ListBox.SelectedItem != null)
                {
                    string themeToDelete = Themes_ThemeNames_ListBox.SelectedItem.ToString();
                    string tempString1 = $"Are you sure you want to delete the current theme?\nTheme: {themeToDelete}\nThis action cannot be reversed.";
                    MessageBoxResult confirmDeleteCurrentTheme = MessageBox.Show(tempString1, "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (confirmDeleteCurrentTheme == MessageBoxResult.Yes)
                    {
                        Themes_ProfileSpecificThemes_DataGrid_ThemeNames_ObservableCollection.Remove(themeToDelete);
                        Themes_ThemeNames_NoEmptyString_ObservableCollection.Remove(themeToDelete);
                        // Check if the selected item is null or invalid, then reset the index
                        // Update profileSpecificThemesDictionary to change themeName to empty string
                        foreach (var entry in profileSpecificThemesDictionary.Values)
                        {
                            if (entry.ThemeName == themeToDelete)
                            {
                                entry.ThemeName = "";  // Set to empty string
                            }
                        }
                        if (Themes_ThemeNames_ListBox.SelectedItem == null)
                        {
                            Themes_ThemeNames_ListBox.SelectedIndex = 0;
                        }
                        if (Themes_GlobalTheme_ComboBox.SelectedItem == null)
                        {
                            Themes_GlobalTheme_ComboBox.SelectedItem = "phd2mm_light";
                        }
                        if (themesDictionary.ContainsKey(themeToDelete))
                        {
                            themesDictionary.Remove(themeToDelete);
                            string themeFilePath = System.IO.Path.Combine(Class1.GetThemesDirectoryPath(), $"{themeToDelete}.json");
                            if (File.Exists(themeFilePath))
                            {
                                File.Delete(themeFilePath);
                            }
                        }
                    }
                }
            }
            else
            {
                string tempString1 = $"Cannot delete theme:\n{ProfilesList_ComboBox.SelectedItem}\nbecause it is the only theme left!\nPlease create another theme first.";
                MessageBox.Show(tempString1, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Themes_ThemeNames_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected theme name from the ListBox
            string selectedThemeName = (string)Themes_ThemeNames_ListBox.SelectedItem;
            TextBlock textBlock = Themes_CurrentThemeName_Label.Content as TextBlock;
            if (textBlock != null)
            {
                textBlock.Text = selectedThemeName;
            }
            if (!string.IsNullOrEmpty(selectedThemeName) && themesDictionary.ContainsKey(selectedThemeName))
            {
                // Get the selected theme from the dictionary
                Class3.ThemeInfo selectedTheme = themesDictionary[selectedThemeName];
                // Update the TextBoxes based on the selected theme's properties
                GetThemeInfoFromThemesDictionary_UpdateTextBoxes(selectedTheme);
                // Disable or enable the entire TabControl based on theme name
                if (selectedThemeName == "phd2mm_light" || selectedThemeName == "phd2mm_dark")
                {
                    Themes_ControlsCustomization_TabControl.IsEnabled = false;
                    Themes_DeleteTheme_Button.IsEnabled = false;
                }
                else
                {
                    Themes_ControlsCustomization_TabControl.IsEnabled = true;
                    Themes_DeleteTheme_Button.IsEnabled = true;
                }
            }
        }

        public System.Windows.Media.Color ConvertRgbaToArgb(string rgba)
        {
            if (rgba.StartsWith("#") && rgba.Length == 9) // Valid RGBA format
            {
                // Extract the components
                byte r = Convert.ToByte(rgba.Substring(1, 2), 16);
                byte g = Convert.ToByte(rgba.Substring(3, 2), 16);
                byte b = Convert.ToByte(rgba.Substring(5, 2), 16);
                byte a = Convert.ToByte(rgba.Substring(7, 2), 16);

                // Swap the letters to convert to ARGB format
                return System.Windows.Media.Color.FromArgb(a, r, g, b); // ARGB format
            }
            throw new ArgumentException("Invalid RGBA color string");
        }

        private void GetThemeInfoFromThemesDictionary_UpdateTextBoxes(Class3.ThemeInfo theme)
        {
            // Get the TabControl that contains the controls (TextBoxes, ColorPickers, etc.)
            var tabControl = Themes_ControlsCustomization_TabControl; // Make sure this is the correct name of your TabControl
            // Loop through all the properties of the ThemeInfo object
            foreach (var property in theme.GetType().GetProperties())
            {
                // Get the name and value of the property (e.g., GGC_Grid_BackgroundColor)
                string propertyName = property.Name;
                var propertyValue = property.GetValue(theme) as string;
                // Special case: handle RadioButtons for MMTC_VerticalScrollBarVisibility
                if (propertyName == "MMTC_VerticalScrollBarVisibility")
                {
                    if (propertyValue == "Auto")
                        Themes_MMTC_VerticalScrollBarVisibility_Auto_RadioButton.IsChecked = true;
                    else if (propertyValue == "Hidden")
                        Themes_MMTC_VerticalScrollBarVisibility_Hidden_RadioButton.IsChecked = true;
                    continue; // Skip the rest of the logic for this property
                }
                // Handle color picker properties (using ColorPickers instead of TextBoxes)
                string colorPickerName = "Themes_" + propertyName + "_ColorPickerButton";
                PortableColorPicker correspondingColorPicker = tabControl.FindName(colorPickerName) as PortableColorPicker;
                if (correspondingColorPicker != null && propertyValue != null)
                {
                    try
                    {
                        // Convert the color value (hex string in RGBA format) to System.Windows.Media.Color
                        System.Windows.Media.Color wpfColor = ConvertRgbaToArgb(propertyValue);
                        // Set the color of the color picker (for manual color setting)
                        correspondingColorPicker.SelectedColor = wpfColor;
                    }
                    catch (Exception ex)
                    {
                        // Handle invalid color format
                        MessageBox.Show($"Invalid color value for '{propertyName}': {propertyValue}. Error: {ex.Message}");
                    }
                }
                else
                {
                    // Handle TextBox properties (for all non-color properties)
                    string textBoxName = "Themes_" + propertyName + "_TextBox";
                    TextBox correspondingTextBox = tabControl.FindName(textBoxName) as TextBox;

                    if (correspondingTextBox != null && propertyValue != null)
                    {
                        correspondingTextBox.Text = propertyValue;
                    }
                }
            }
        }


        private void Themes_SaveThemeSettings_Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected theme name from the ListBox
            string selectedThemeName = (string)Themes_ThemeNames_ListBox.SelectedItem;
            if (!string.IsNullOrEmpty(selectedThemeName) && themesDictionary.ContainsKey(selectedThemeName))
            {
                Class3.ThemeInfo selectedTheme = themesDictionary[selectedThemeName];
                var tabControl = Themes_ControlsCustomization_TabControl;

                // Define image-related textbox names to skip strict hex validation
                var imageTextBoxNames = new HashSet<string>
                {
                    "Themes_MMGC_ModManagerBackgroundImage_TextBox",
                    "Themes_MMGC_ModManagerIconImage_TextBox",
                    "Themes_MMGC_UnusedModsTableBackgroundImage_TextBox",
                    "Themes_MMGC_UsedModsTableBackgroundImage_TextBox"
                };

                foreach (var property in selectedTheme.GetType().GetProperties())
                {
                    string propertyName = property.Name;
                    if (propertyName == "MMTC_VerticalScrollBarVisibility")
                    {
                        if (Themes_MMTC_VerticalScrollBarVisibility_Auto_RadioButton.IsChecked == true)
                            property.SetValue(selectedTheme, "Auto");
                        else if (Themes_MMTC_VerticalScrollBarVisibility_Hidden_RadioButton.IsChecked == true)
                            property.SetValue(selectedTheme, "Hidden");
                        continue;
                    }
                    else if (imageTextBoxNames.Contains(propertyName))
                    {
                        string textBoxName = "Themes_" + propertyName + "_TextBox";
                        TextBox textBox = tabControl.FindName(textBoxName) as TextBox;
                        if (textBox != null)
                        {
                            string value = textBox.Text.Trim();
                            value = value.Replace('\\', '/'); // Normalize path
                            property.SetValue(selectedTheme, value);
                        }
                    }
                    else
                    {
                        // Handle color-related properties (using color picker)
                        string colorPickerName = "Themes_" + propertyName + "_ColorPickerButton";
                        PortableColorPicker colorPicker = tabControl.FindName(colorPickerName) as PortableColorPicker;
                        if (colorPicker != null)
                        {
                            // Get the selected color value (in ARGB format)
                            string colorValue = colorPicker.SelectedColor.ToString(); // e.g., #AARRGGBB
                            // If needed, convert ARGB to RGBA format
                            if (colorValue.Length == 9 && colorValue.StartsWith("#"))
                            {
                                // Extract ARGB components
                                string alpha = colorValue.Substring(1, 2);
                                string red = colorValue.Substring(3, 2);
                                string green = colorValue.Substring(5, 2);
                                string blue = colorValue.Substring(7, 2);
                                // Create RGBA format
                                colorValue = "#" + red + green + blue + alpha; // Swap red and alpha
                                // Optionally, validate the color if needed
                                if (!Class3.ThemesValidator.TryValidateAndNormalizeHex(ref colorValue))
                                {
                                    MessageBox.Show($"Invalid color hex code in '{propertyName}'");
                                    return;
                                }
                            }
                            // Set the color property in the theme
                            property.SetValue(selectedTheme, colorValue);
                        }
                    }
                }
                // Save the updated theme
                string themeFilePath = System.IO.Path.Combine(Class1.GetThemesDirectoryPath(), $"{selectedThemeName}.json");
                var themeEntry = new KeyValuePair<string, Class3.ThemeInfo>(selectedThemeName, selectedTheme);
                Class3.ThemesFilesEditor.WriteThemeToFile(themeEntry, themeFilePath);
                CheckThemeBeforeApplyingTheme(ProfilesList_ComboBox.SelectedItem.ToString());
                MessageBox.Show($"Theme '{selectedThemeName}' settings have been saved.");
            }
        }


        private void Themes_GlobalTheme_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check if the selected item is not null
            if (Themes_GlobalTheme_ComboBox.SelectedItem != null)
            {
                // Proceed with handling the selection
                // Handle profile-specific theme (ensure profile is selected)
                if (ProfilesList_ComboBox.SelectedItem != null)
                {
                    string selectedProfileName = ProfilesList_ComboBox.SelectedItem.ToString();
                    CheckThemeBeforeApplyingTheme(selectedProfileName);
                }
            }
            else
            {
                // Handle the case when no item is selected (if needed)
            }
        }

        private void Themes_ProfileSpecificThemes_DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column.Header.ToString() == "Theme")
            {
                var dataGrid = sender as DataGrid;

                // Temporarily remove the event handler to prevent recursion
                dataGrid.CellEditEnding -= Themes_ProfileSpecificThemes_DataGrid_CellEditEnding;

                // Commit the cell edit to ensure the new value is available
                dataGrid.CommitEdit(DataGridEditingUnit.Cell, true);  // Commit cell edit
                dataGrid.CommitEdit(DataGridEditingUnit.Row, true);   // Commit row edit

                // Now that the edit is committed, access the updated value
                if (e.EditingElement is ComboBox comboBox && comboBox.SelectedItem != null)
                {
                    string selectedProfileName = ProfilesList_ComboBox.SelectedItem.ToString();
                    CheckThemeBeforeApplyingTheme(selectedProfileName);
                }

                // Reattach the event handler
                dataGrid.CellEditEnding += Themes_ProfileSpecificThemes_DataGrid_CellEditEnding;
            }
        }

        private void CheckThemeBeforeApplyingTheme(string selectedProfileName)
        {
            // Check if the selected profile exists in the dictionary and the theme matches
            if (profileSpecificThemesDictionary.TryGetValue(selectedProfileName, out var profileSpecificThemeInfo))
            {
                string themeToApply = profileSpecificThemesDictionary[selectedProfileName].ThemeName;
                //MessageBox.Show("HERE2: " + themeToApply);
                // If the profile-specific theme name is not empty, use it
                if (string.IsNullOrEmpty(themeToApply) == false)
                {
                    TextBlock textBlock = Themes_CurrentAppliedThemeName_Label.Content as TextBlock;
                    textBlock.Text = themeToApply;
                    // Apply the theme (whether profile-specific)
                    Class3.ThemesManager.ApplyThemesToControls(
                        themesDictionary,
                        themeToApply,  // The selected theme (profile-specific)
                        ProfileImage_Background_Image,
                        ProfileImage_Icon_Image,
                        ProfileImage_UnusedMods_DataGrid_Image,
                        ProfileImage_UsedMods_DataGrid_Image
                    );

                    if (themesDictionary.TryGetValue(themeToApply, out var theme))
                    {
                        if (theme.MMTC_VerticalScrollBarVisibility == "Hidden")
                        {
                            UnusedMods_DataGrid.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                            UsedMods_DataGrid.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                        }
                        else
                        {
                            UnusedMods_DataGrid.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                            UsedMods_DataGrid.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                        }
                    }
                }
                else
                {
                    if (Themes_GlobalTheme_ComboBox.SelectedItem != null)
                    {
                        string currentlySelectedGlobalTheme = Themes_GlobalTheme_ComboBox.SelectedItem.ToString();
                        TextBlock textBlock = Themes_CurrentAppliedThemeName_Label.Content as TextBlock;
                        textBlock.Text = currentlySelectedGlobalTheme;
                        Class3.ThemesManager.ApplyThemesToControls(
                            themesDictionary,
                            currentlySelectedGlobalTheme,  // The selected theme (profile-specific or global)
                            ProfileImage_Background_Image,
                            ProfileImage_Icon_Image,
                            ProfileImage_UnusedMods_DataGrid_Image,
                            ProfileImage_UsedMods_DataGrid_Image
                        );
                        if (themesDictionary.TryGetValue(currentlySelectedGlobalTheme, out var theme))
                        {
                            if (theme.MMTC_VerticalScrollBarVisibility == "Hidden")
                            {
                                UnusedMods_DataGrid.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                                UsedMods_DataGrid.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                            }
                            else
                            {
                                UnusedMods_DataGrid.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                                UsedMods_DataGrid.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                            }
                        }
                    }
                    
                }
            }
        }


        private void Themes_MMGC_ModManagerBackgroundImage_Button_Click(object sender, RoutedEventArgs e)
        {
            // Open a file dialog to select an image
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp", // Filter for image files
                Title = "Select an Image"
            };
            // Show the file dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                // Validate the image type
                if (Class3.ThemesValidator.ValidateImageType(selectedFilePath))
                {
                    // Image is valid, you can proceed with whatever action you need (e.g., assigning the image path)
                    selectedFilePath = selectedFilePath.Replace('\\', '/');
                    if (selectedFilePath.Contains("phd2mm_themes"))
                    {
                        selectedFilePath = System.IO.Path.GetFileName(selectedFilePath);
                        Themes_MMGC_ModManagerBackgroundImage_TextBox.Text = selectedFilePath;
                    }
                    else
                    {
                        string tempString1 = "Invalid image path.\nPlease select an image from the 'phd2mm_themes' folder.";
                        MessageBox.Show(tempString1, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    // Invalid image type, this has already been handled in ValidateImageType method
                }
            }
        }

        private void Themes_MMGC_ModManagerIconImage_Button_Click(object sender, RoutedEventArgs e)
        {
            // Open a file dialog to select an image
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp", // Filter for image files
                Title = "Select an Image"
            };
            // Show the file dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                // Validate the image type
                if (Class3.ThemesValidator.ValidateImageType(selectedFilePath))
                {
                    // Image is valid, you can proceed with whatever action you need (e.g., assigning the image path)
                    selectedFilePath = selectedFilePath.Replace('\\', '/');
                    if (selectedFilePath.Contains("phd2mm_themes"))
                    {
                        selectedFilePath = System.IO.Path.GetFileName(selectedFilePath);
                        Themes_MMGC_ModManagerIconImage_TextBox.Text = selectedFilePath;
                    }
                    else
                    {
                        string tempString1 = "Invalid image path.\nPlease select an image from the 'phd2mm_themes' folder.";
                        MessageBox.Show(tempString1, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    // Invalid image type, this has already been handled in ValidateImageType method
                }
            }
        }

        private void Themes_MMGC_UnusedModsTableBackgroundImage_Button_Click(object sender, RoutedEventArgs e)
        {
            // Open a file dialog to select an image
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp", // Filter for image files
                Title = "Select an Image"
            };
            // Show the file dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                // Validate the image type
                if (Class3.ThemesValidator.ValidateImageType(selectedFilePath))
                {
                    // Image is valid, you can proceed with whatever action you need (e.g., assigning the image path)
                    selectedFilePath = selectedFilePath.Replace('\\', '/');
                    if (selectedFilePath.Contains("phd2mm_themes"))
                    {
                        selectedFilePath = System.IO.Path.GetFileName(selectedFilePath);
                        Themes_MMGC_UnusedModsTableBackgroundImage_TextBox.Text = selectedFilePath;
                    }
                    else
                    {
                        string tempString1 = "Invalid image path.\nPlease select an image from the 'phd2mm_themes' folder.";
                        MessageBox.Show(tempString1, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    // Invalid image type, this has already been handled in ValidateImageType method
                }
            }
        }

        private void Themes_MMGC_UsedModsTableBackgroundImage_Button_Click(object sender, RoutedEventArgs e)
        {
            // Open a file dialog to select an image
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp", // Filter for image files
                Title = "Select an Image"
            };
            // Show the file dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                // Validate the image type
                if (Class3.ThemesValidator.ValidateImageType(selectedFilePath))
                {
                    // Image is valid, you can proceed with whatever action you need (e.g., assigning the image path)
                    selectedFilePath = selectedFilePath.Replace('\\', '/');
                    if (selectedFilePath.Contains("phd2mm_themes"))
                    {
                        selectedFilePath = System.IO.Path.GetFileName(selectedFilePath);
                        Themes_MMGC_UsedModsTableBackgroundImage_TextBox.Text = selectedFilePath;
                    }
                    else
                    {
                        string tempString1 = "Invalid image path.\nPlease select an image from the 'phd2mm_themes' folder.";
                        MessageBox.Show(tempString1, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    // Invalid image type, this has already been handled in ValidateImageType method
                }
            }
        }

        void CopyColorSetting(string sourceControl, string targetControl, string controlName, string property)
        {
            // Construct the names of the color picker controls
            string sourceColorPickerName = $"Themes_{sourceControl}_{controlName}_{property}_ColorPickerButton";
            string targetColorPickerName = $"Themes_{targetControl}_{controlName}_{property}_ColorPickerButton";

            // Find the ColorPicker controls
            var sourceColorPicker = FindName(sourceColorPickerName) as PortableColorPicker;
            var targetColorPicker = FindName(targetColorPickerName) as PortableColorPicker;

            // If both are ColorPickers, copy the selected color
            if (sourceColorPicker != null && targetColorPicker != null)
            {
                targetColorPicker.SelectedColor = sourceColorPicker.SelectedColor;
            }
        }

        private void Themes_MMGC_CopyGGCThemeSettings_Button_Click(object sender, RoutedEventArgs e)
        {
            string tempString1 = "Are you sure you want to copy the theme settings from the Global General Controls Table to the Mod Manager General Controls?\nThis action will overwrite the current theme settings in the Unused Mods Table.";
            MessageBoxResult confirmCopyThemeSettings = MessageBox.Show(tempString1, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirmCopyThemeSettings == MessageBoxResult.Yes)
            {
                CopyColorSetting("GGC", "MMGC", "ComboBox", "BackgroundColor");
                CopyColorSetting("GGC", "MMGC", "ComboBox", "TextColor");
                CopyColorSetting("GGC", "MMGC", "ComboBox", "BorderColor");
                CopyColorSetting("GGC", "MMGC", "Button", "BackgroundColor");
                CopyColorSetting("GGC", "MMGC", "Button", "TextColor");
                CopyColorSetting("GGC", "MMGC", "Button", "BorderColor");
                CopyColorSetting("GGC", "MMGC", "TextBox", "BackgroundColor");
                CopyColorSetting("GGC", "MMGC", "TextBox", "TextColor");
                CopyColorSetting("GGC", "MMGC", "TextBox", "BorderColor");
                CopyColorSetting("GGC", "MMGC", "Label", "BackgroundColor");
                CopyColorSetting("GGC", "MMGC", "Label", "TextColor");
            }
        }

        private void Themes_MMTC_UnusedModsTable_CopyUsedModsTableThemeSettings_Button_Click(object sender, RoutedEventArgs e)
        {
            string tempString1 = "Are you sure you want to copy the theme settings from the Used Mods Table to the Unused Mods Table?\nThis action will overwrite the current theme settings in the Unused Mods Table.";
            MessageBoxResult confirmCopyThemeSettings = MessageBox.Show(tempString1, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirmCopyThemeSettings == MessageBoxResult.Yes)
            {
                CopyColorSetting("MMTC_UsedModsTable", "MMTC_UnusedModsTable", "DG_DataGrid", "BackgroundColor");
                CopyColorSetting("MMTC_UsedModsTable", "MMTC_UnusedModsTable", "DG_DataGrid", "TextColor");
                CopyColorSetting("MMTC_UsedModsTable", "MMTC_UnusedModsTable", "DG_DataGrid", "BorderColor");
                CopyColorSetting("MMTC_UsedModsTable", "MMTC_UnusedModsTable", "DG_Row", "BackgroundColor");
                CopyColorSetting("MMTC_UsedModsTable", "MMTC_UnusedModsTable", "DG_Row", "BorderColor");
                CopyColorSetting("MMTC_UsedModsTable", "MMTC_UnusedModsTable", "DG_AlternateRow", "BackgroundColor");
                CopyColorSetting("MMTC_UsedModsTable", "MMTC_UnusedModsTable", "DG_SelectedRow", "BackgroundColor");
                CopyColorSetting("MMTC_UsedModsTable", "MMTC_UnusedModsTable", "DG_SelectedRow", "TextColor");
                CopyColorSetting("MMTC_UsedModsTable", "MMTC_UnusedModsTable", "DG_ColumnHeader", "BackgroundColor");
                CopyColorSetting("MMTC_UsedModsTable", "MMTC_UnusedModsTable", "DG_ColumnHeader", "BorderColor");
                CopyColorSetting("MMTC_UsedModsTable", "MMTC_UnusedModsTable", "DG_SortArrow", "TextColor");
            }
        }

        private void Themes_MMTC_UnusedModsTable_CopyGTCThemeSettings_Button_Click(object sender, RoutedEventArgs e)
        {
            string tempString1 = "Are you sure you want to copy the theme settings from the Global Table Controls to the Unused Mods Table?\nThis action will overwrite the current theme settings in the Unused Mods Table.";
            MessageBoxResult confirmCopyThemeSettings = MessageBox.Show(tempString1, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirmCopyThemeSettings == MessageBoxResult.Yes)
            {
                CopyColorSetting("GTC", "MMTC_UnusedModsTable", "DG_DataGrid", "BackgroundColor");
                CopyColorSetting("GTC", "MMTC_UnusedModsTable", "DG_DataGrid", "TextColor");
                CopyColorSetting("GTC", "MMTC_UnusedModsTable", "DG_DataGrid", "BorderColor");
                CopyColorSetting("GTC", "MMTC_UnusedModsTable", "DG_Row", "BackgroundColor");
                CopyColorSetting("GTC", "MMTC_UnusedModsTable", "DG_Row", "BorderColor");
                CopyColorSetting("GTC", "MMTC_UnusedModsTable", "DG_AlternateRow", "BackgroundColor");
                CopyColorSetting("GTC", "MMTC_UnusedModsTable", "DG_SelectedRow", "BackgroundColor");
                CopyColorSetting("GTC", "MMTC_UnusedModsTable", "DG_SelectedRow", "TextColor");
                CopyColorSetting("GTC", "MMTC_UnusedModsTable", "DG_ColumnHeader", "BackgroundColor");
                CopyColorSetting("GTC", "MMTC_UnusedModsTable", "DG_ColumnHeader", "BorderColor");
                CopyColorSetting("GTC", "MMTC_UnusedModsTable", "DG_SortArrow", "TextColor");
            }
        }

        private void Themes_MMTC_UnusedModsTable_CopyUnusedModsTableThemeSettings_Button_Click(object sender, RoutedEventArgs e)
        {
            string tempString1 = "Are you sure you want to copy the theme settings from the Unused Mods Table to the Used Mods Table?\nThis action will overwrite the current theme settings in the Used Mods Table.";
            MessageBoxResult confirmCopyThemeSettings = MessageBox.Show(tempString1, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirmCopyThemeSettings == MessageBoxResult.Yes)
            {
                CopyColorSetting("MMTC_UnusedModsTable", "MMTC_UsedModsTable", "DG_DataGrid", "BackgroundColor");
                CopyColorSetting("MMTC_UnusedModsTable", "MMTC_UsedModsTable", "DG_DataGrid", "TextColor");
                CopyColorSetting("MMTC_UnusedModsTable", "MMTC_UsedModsTable", "DG_DataGrid", "BorderColor");
                CopyColorSetting("MMTC_UnusedModsTable", "MMTC_UsedModsTable", "DG_Row", "BackgroundColor");
                CopyColorSetting("MMTC_UnusedModsTable", "MMTC_UsedModsTable", "DG_Row", "BorderColor");
                CopyColorSetting("MMTC_UnusedModsTable", "MMTC_UsedModsTable", "DG_AlternateRow", "BackgroundColor");
                CopyColorSetting("MMTC_UnusedModsTable", "MMTC_UsedModsTable", "DG_SelectedRow", "BackgroundColor");
                CopyColorSetting("MMTC_UnusedModsTable", "MMTC_UsedModsTable", "DG_SelectedRow", "TextColor");
                CopyColorSetting("MMTC_UnusedModsTable", "MMTC_UsedModsTable", "DG_ColumnHeader", "BackgroundColor");
                CopyColorSetting("MMTC_UnusedModsTable", "MMTC_UsedModsTable", "DG_ColumnHeader", "BorderColor");
                CopyColorSetting("MMTC_UnusedModsTable", "MMTC_UsedModsTable", "DG_SortArrow", "TextColor");
            }
        }

        private void Themes_MMTC_UsedModsTable_CopyGTCThemeSettings_Button_Click(object sender, RoutedEventArgs e)
        {
            string tempString1 = "Are you sure you want to copy the theme settings from the Global Table Controls to the Used Mods Table?\nThis action will overwrite the current theme settings in the Used Mods Table.";
            MessageBoxResult confirmCopyThemeSettings = MessageBox.Show(tempString1, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirmCopyThemeSettings == MessageBoxResult.Yes)
            {
                CopyColorSetting("GTC", "MMTC_UsedModsTable", "DG_DataGrid", "BackgroundColor");
                CopyColorSetting("GTC", "MMTC_UsedModsTable", "DG_DataGrid", "TextColor");
                CopyColorSetting("GTC", "MMTC_UsedModsTable", "DG_DataGrid", "BorderColor");
                CopyColorSetting("GTC", "MMTC_UsedModsTable", "DG_Row", "BackgroundColor");
                CopyColorSetting("GTC", "MMTC_UsedModsTable", "DG_Row", "BorderColor");
                CopyColorSetting("GTC", "MMTC_UsedModsTable", "DG_AlternateRow", "BackgroundColor");
                CopyColorSetting("GTC", "MMTC_UsedModsTable", "DG_SelectedRow", "BackgroundColor");
                CopyColorSetting("GTC", "MMTC_UsedModsTable", "DG_SelectedRow", "TextColor");
                CopyColorSetting("GTC", "MMTC_UsedModsTable", "DG_ColumnHeader", "BackgroundColor");
                CopyColorSetting("GTC", "MMTC_UsedModsTable", "DG_ColumnHeader", "BorderColor");
                CopyColorSetting("GTC", "MMTC_UsedModsTable", "DG_SortArrow", "TextColor");
            }
        }


        
    }
}