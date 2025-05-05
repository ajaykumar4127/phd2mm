using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace phd2mm_wpf
{
    public class Class3
    {
        public class ThemeInfo
        {
            public string ThemeName { get; set; }
            public string GGC_Grid_BackgroundColor { get; set; }
            public string GGC_TabControl_BackgroundColor { get; set; }
            public string GGC_TabControl_BorderColor { get; set; }
            public string GGC_TabItem_BackgroundColor { get; set; }
            public string GGC_TabItem_TextColor { get; set; }
            public string GGC_TabItem_BorderColor { get; set; }
            public string GGC_ComboBox_BackgroundColor { get; set; }
            public string GGC_ComboBox_TextColor { get; set; }
            public string GGC_ComboBox_BorderColor { get; set; }
            public string GGC_ListBox_BackgroundColor { get; set; }
            public string GGC_ListBox_TextColor { get; set; }
            public string GGC_ListBox_BorderColor { get; set; }
            public string GGC_GroupBox_BackgroundColor { get; set; }
            public string GGC_GroupBox_BorderColor { get; set; }
            public string GGC_StackPanel_BackgroundColor { get; set; }
            public string GGC_RadioButton_BackgroundColor { get; set; }
            public string GGC_RadioButton_TextColor { get; set; }
            public string GGC_Button_BackgroundColor { get; set; }
            public string GGC_Button_TextColor { get; set; }
            public string GGC_Button_BorderColor { get; set; }
            public string GGC_TextBox_BackgroundColor { get; set; }
            public string GGC_TextBox_TextColor { get; set; }
            public string GGC_TextBox_BorderColor { get; set; }
            public string GGC_Label_BackgroundColor { get; set; }
            public string GGC_Label_TextColor { get; set; }
            public string GTC_DG_DataGrid_BackgroundColor { get; set; }
            public string GTC_DG_DataGrid_TextColor { get; set; }
            public string GTC_DG_DataGrid_BorderColor { get; set; }
            public string GTC_DG_Row_BackgroundColor { get; set; }
            public string GTC_DG_Row_BorderColor { get; set; }
            public string GTC_DG_AlternateRow_BackgroundColor { get; set; }
            public string GTC_DG_SelectedRow_BackgroundColor { get; set; }
            public string GTC_DG_SelectedRow_TextColor { get; set; }
            public string GTC_DG_ColumnHeader_BackgroundColor { get; set; }
            public string GTC_DG_ColumnHeader_BorderColor { get; set; }
            public string GTC_DG_SortArrow_TextColor { get; set; }
            public string MMGC_ModManagerBackgroundImage { get; set; }
            public string MMGC_ModManagerIconImage { get; set; }
            public string MMGC_UnusedModsTableBackgroundImage { get; set; }
            public string MMGC_UsedModsTableBackgroundImage { get; set; }
            public string MMGC_ComboBox_BackgroundColor { get; set; }
            public string MMGC_ComboBox_TextColor { get; set; }
            public string MMGC_ComboBox_BorderColor { get; set; }
            public string MMGC_Button_BackgroundColor { get; set; }
            public string MMGC_Button_TextColor { get; set; }
            public string MMGC_Button_BorderColor { get; set; }
            public string MMGC_TextBox_BackgroundColor { get; set; }
            public string MMGC_TextBox_TextColor { get; set; }
            public string MMGC_TextBox_BorderColor { get; set; }
            public string MMGC_Label_BackgroundColor { get; set; }
            public string MMGC_Label_TextColor { get; set; }
            public string MMTC_UnusedModsTable_DG_DataGrid_BackgroundColor { get; set; }
            public string MMTC_UnusedModsTable_DG_DataGrid_TextColor { get; set; }
            public string MMTC_UnusedModsTable_DG_DataGrid_BorderColor { get; set; }
            public string MMTC_UnusedModsTable_DG_Row_BackgroundColor { get; set; }
            public string MMTC_UnusedModsTable_DG_Row_BorderColor { get; set; }
            public string MMTC_UnusedModsTable_DG_AlternateRow_BackgroundColor { get; set; }
            public string MMTC_UnusedModsTable_DG_SelectedRow_BackgroundColor { get; set; }
            public string MMTC_UnusedModsTable_DG_SelectedRow_TextColor { get; set; }
            public string MMTC_UnusedModsTable_DG_ColumnHeader_BackgroundColor { get; set; }
            public string MMTC_UnusedModsTable_DG_ColumnHeader_BorderColor { get; set; }
            public string MMTC_UnusedModsTable_DG_SortArrow_TextColor { get; set; }
            public string MMTC_UsedModsTable_DG_DataGrid_BackgroundColor { get; set; }
            public string MMTC_UsedModsTable_DG_DataGrid_TextColor { get; set; }
            public string MMTC_UsedModsTable_DG_DataGrid_BorderColor { get; set; }
            public string MMTC_UsedModsTable_DG_Row_BackgroundColor { get; set; }
            public string MMTC_UsedModsTable_DG_Row_BorderColor { get; set; }
            public string MMTC_UsedModsTable_DG_AlternateRow_BackgroundColor { get; set; }
            public string MMTC_UsedModsTable_DG_SelectedRow_BackgroundColor { get; set; }
            public string MMTC_UsedModsTable_DG_SelectedRow_TextColor { get; set; }
            public string MMTC_UsedModsTable_DG_ColumnHeader_BackgroundColor { get; set; }
            public string MMTC_UsedModsTable_DG_ColumnHeader_BorderColor { get; set; }
            public string MMTC_UsedModsTable_DG_SortArrow_TextColor { get; set; }
            public string MMTC_VerticalScrollBarVisibility { get; set; }

            // Optional parameterless constructor
            public ThemeInfo() { }

            public ThemeInfo(string themename,
                string ggcGridBackgroundColor, string ggcTabControlBackgroundColor, string ggcTabControlBorderColor,
                string ggcTabItemBackgroundColor, string ggcTabItemTextColor, string ggcTabItemBorderColor,
                string ggcComboBoxBackgroundColor, string ggcComboBoxTextColor, string ggcComboBoxBorderColor,
                string ggcListBoxBackgroundColor, string ggcListBoxTextColor, string ggcListBoxBorderColor,
                string ggcGroupBoxBackgroundColor, string ggcGroupBoxBorderColor, string ggcStackPanelBackgroundColor,
                string ggcRadioButtonBackgroundColor, string ggcRadioButtonTextColor, string ggcButtonBackgroundColor,
                string ggcButtonTextColor, string ggcButtonBorderColor, string ggcTextBoxBackgroundColor,
                string ggcTextBoxTextColor, string ggcTextBoxBorderColor, string ggcLabelBackgroundColor,
                string ggcLabelTextColor, string gtcDGDataGridBackgroundColor, string gtcDGDataGridTextColor, string gtcDGDataGridBorderColor,
                string gtcDGRowBackgroundColor, string gtcDGRowBorderColor, string gtcDGAlternateRowBackgroundColor, string gtcDGSelectedRowBackgroundColor,
                string gtcDGSelectedRowTextColor, string gtcDGColumnHeaderBackgroundColor, string gtcDGColumnHeaderBorderColor,
                string gtcDGSortArrowTextColor, string mmgcModManagerBackgroundImage, string mmgcModManagerIconImage,
                string mmgcUnusedModsTableBackgroundImage, string mmgcUsedModsTableBackgroundImage,
                string mmgcComboBoxBackgroundColor, string mmgcComboBoxTextColor, string mmgcComboBoxBorderColor,
                string mmgcButtonBackgroundColor, string mmgcButtonTextColor, string mmgcButtonBorderColor,
                string mmgcTextBoxBackgroundColor, string mmgcTextBoxTextColor, string mmgcTextBoxBorderColor,
                string mmgcLabelBackgroundColor, string mmgcLabelTextColor, string mmtcUnusedModsTableDGDataGridBackgroundColor, string mmtcUnusedModsTableDGDataGridTextColor,
                string mmtcUnusedModsTableDGDataGridBorderColor, string mmtcUnusedModsTableDGRowBackgroundColor, string mmtcUnusedModsTableDGRowBorderColor,
                string mmtcUnusedModsTableDGAlternateRowBackgroundColor, string mmtcUnusedModsTableDGSelectedRowBackgroundColor,
                string mmtcUnusedModsTableDGSelectedRowTextColor, string mmtcUnusedModsTableDGColumnHeaderBackgroundColor,
                string mmtcUnusedModsTableDGColumnHeaderBorderColor, string mmtcUnusedModsTableDGSortArrowTextColor,
                string mmtcUsedModsTableDGDataGridBackgroundColor, string mmtcUsedModsTableDGDataGridTextColor, string mmtcUsedModsTableDGDataGridBorderColor,
                string mmtcUsedModsTableDGRowBackgroundColor, string mmtcUsedModsTableDGRowBorderColor, string mmtcUsedModsTableDGAlternateRowBackgroundColor,
                string mmtcUsedModsTableDGSelectedRowBackgroundColor, string mmtcUsedModsTableDGSelectedRowTextColor,
                string mmtcUsedModsTableDGColumnHeaderBackgroundColor, string mmtcUsedModsTableDGColumnHeaderBorderColor,
                string mmtcUsedModsTableDGSortArrowTextColor, string mmtcVerticalScrollBarVisibility)
            {
                ThemeName = themename;
                GGC_Grid_BackgroundColor = ggcGridBackgroundColor;
                GGC_TabControl_BackgroundColor = ggcTabControlBackgroundColor;
                GGC_TabControl_BorderColor = ggcTabControlBorderColor;
                GGC_TabItem_BackgroundColor = ggcTabItemBackgroundColor;
                GGC_TabItem_TextColor = ggcTabItemTextColor;
                GGC_TabItem_BorderColor = ggcTabItemBorderColor;
                GGC_ComboBox_BackgroundColor = ggcComboBoxBackgroundColor;
                GGC_ComboBox_TextColor = ggcComboBoxTextColor;
                GGC_ComboBox_BorderColor = ggcComboBoxBorderColor;
                GGC_ListBox_BackgroundColor = ggcListBoxBackgroundColor;
                GGC_ListBox_TextColor = ggcListBoxTextColor;
                GGC_ListBox_BorderColor = ggcListBoxBorderColor;
                GGC_GroupBox_BackgroundColor = ggcGroupBoxBackgroundColor;
                GGC_GroupBox_BorderColor = ggcGroupBoxBorderColor;
                GGC_StackPanel_BackgroundColor = ggcStackPanelBackgroundColor;
                GGC_RadioButton_BackgroundColor = ggcRadioButtonBackgroundColor;
                GGC_RadioButton_TextColor = ggcRadioButtonTextColor;
                GGC_Button_BackgroundColor = ggcButtonBackgroundColor;
                GGC_Button_TextColor = ggcButtonTextColor;
                GGC_Button_BorderColor = ggcButtonBorderColor;
                GGC_TextBox_BackgroundColor = ggcTextBoxBackgroundColor;
                GGC_TextBox_TextColor = ggcTextBoxTextColor;
                GGC_TextBox_BorderColor = ggcTextBoxBorderColor;
                GGC_Label_BackgroundColor = ggcLabelBackgroundColor;
                GGC_Label_TextColor = ggcLabelTextColor;
                GTC_DG_DataGrid_BackgroundColor = gtcDGDataGridBackgroundColor;
                GTC_DG_DataGrid_TextColor = gtcDGDataGridTextColor;
                GTC_DG_DataGrid_BorderColor = gtcDGDataGridBorderColor;
                GTC_DG_Row_BorderColor = gtcDGRowBorderColor;
                GTC_DG_Row_BackgroundColor = gtcDGRowBackgroundColor;
                GTC_DG_AlternateRow_BackgroundColor = gtcDGAlternateRowBackgroundColor;
                GTC_DG_SelectedRow_BackgroundColor = gtcDGSelectedRowBackgroundColor;
                GTC_DG_SelectedRow_TextColor = gtcDGSelectedRowTextColor;
                GTC_DG_ColumnHeader_BackgroundColor = gtcDGColumnHeaderBackgroundColor;
                GTC_DG_ColumnHeader_BorderColor = gtcDGColumnHeaderBorderColor;
                GTC_DG_SortArrow_TextColor = gtcDGSortArrowTextColor;
                MMGC_ModManagerBackgroundImage = mmgcModManagerBackgroundImage;
                MMGC_ModManagerIconImage = mmgcModManagerIconImage;
                MMGC_UnusedModsTableBackgroundImage = mmgcUnusedModsTableBackgroundImage;
                MMGC_UsedModsTableBackgroundImage = mmgcUsedModsTableBackgroundImage;
                MMGC_ComboBox_BackgroundColor = mmgcComboBoxBackgroundColor;
                MMGC_ComboBox_TextColor = mmgcComboBoxTextColor;
                MMGC_ComboBox_BorderColor = mmgcComboBoxBorderColor;
                MMGC_Button_BackgroundColor = mmgcButtonBackgroundColor;
                MMGC_Button_TextColor = mmgcButtonTextColor;
                MMGC_Button_BorderColor = mmgcButtonBorderColor;
                MMGC_TextBox_BackgroundColor = mmgcTextBoxBackgroundColor;
                MMGC_TextBox_TextColor = mmgcTextBoxTextColor;
                MMGC_TextBox_BorderColor = mmgcTextBoxBorderColor;
                MMGC_Label_BackgroundColor = mmgcLabelBackgroundColor;
                MMGC_Label_TextColor = mmgcLabelTextColor;
                MMTC_UnusedModsTable_DG_DataGrid_BackgroundColor = mmtcUnusedModsTableDGDataGridBackgroundColor;
                MMTC_UnusedModsTable_DG_DataGrid_TextColor = mmtcUnusedModsTableDGDataGridTextColor;
                MMTC_UnusedModsTable_DG_DataGrid_BorderColor = mmtcUnusedModsTableDGDataGridBorderColor;
                MMTC_UnusedModsTable_DG_Row_BackgroundColor = mmtcUnusedModsTableDGRowBackgroundColor;
                MMTC_UnusedModsTable_DG_Row_BorderColor = mmtcUnusedModsTableDGRowBorderColor;
                MMTC_UnusedModsTable_DG_AlternateRow_BackgroundColor = mmtcUnusedModsTableDGAlternateRowBackgroundColor;
                MMTC_UnusedModsTable_DG_SelectedRow_BackgroundColor = mmtcUnusedModsTableDGSelectedRowBackgroundColor;
                MMTC_UnusedModsTable_DG_SelectedRow_TextColor = mmtcUnusedModsTableDGSelectedRowTextColor;
                MMTC_UnusedModsTable_DG_ColumnHeader_BackgroundColor = mmtcUnusedModsTableDGColumnHeaderBackgroundColor;
                MMTC_UnusedModsTable_DG_ColumnHeader_BorderColor = mmtcUnusedModsTableDGColumnHeaderBorderColor;
                MMTC_UnusedModsTable_DG_SortArrow_TextColor = mmtcUnusedModsTableDGSortArrowTextColor;
                MMTC_UsedModsTable_DG_DataGrid_BackgroundColor = mmtcUsedModsTableDGDataGridBackgroundColor;
                MMTC_UsedModsTable_DG_DataGrid_TextColor = mmtcUsedModsTableDGDataGridTextColor;
                MMTC_UsedModsTable_DG_DataGrid_BorderColor = mmtcUsedModsTableDGDataGridBorderColor;
                MMTC_UsedModsTable_DG_Row_BackgroundColor = mmtcUsedModsTableDGRowBackgroundColor;
                MMTC_UsedModsTable_DG_Row_BorderColor = mmtcUsedModsTableDGRowBorderColor;
                MMTC_UsedModsTable_DG_AlternateRow_BackgroundColor = mmtcUsedModsTableDGAlternateRowBackgroundColor;
                MMTC_UsedModsTable_DG_SelectedRow_BackgroundColor = mmtcUsedModsTableDGSelectedRowBackgroundColor;
                MMTC_UsedModsTable_DG_SelectedRow_TextColor = mmtcUsedModsTableDGSelectedRowTextColor;
                MMTC_UsedModsTable_DG_ColumnHeader_BackgroundColor = mmtcUsedModsTableDGColumnHeaderBackgroundColor;
                MMTC_UsedModsTable_DG_ColumnHeader_BorderColor = mmtcUsedModsTableDGColumnHeaderBorderColor;
                MMTC_UsedModsTable_DG_SortArrow_TextColor = mmtcUsedModsTableDGSortArrowTextColor;
                MMTC_VerticalScrollBarVisibility = mmtcVerticalScrollBarVisibility;
            }
        }

        public class ProfileSpecificThemeInfo : INotifyPropertyChanged
        {
            private string _profileName;
            private string _themeName;

            public string ProfileName
            {
                get { return _profileName; }
                set
                {
                    if (_profileName != value)
                    {
                        _profileName = value;
                        OnPropertyChanged(nameof(ProfileName));
                    }
                }
            }

            public string ThemeName
            {
                get { return _themeName; }
                set
                {
                    if (_themeName != value)
                    {
                        _themeName = value;
                        OnPropertyChanged(nameof(ThemeName));
                    }
                }
            }
            public ProfileSpecificThemeInfo(string profileName, string themeName)
            {
                ProfileName = profileName;
                ThemeName = themeName;
            }

            // Event to notify listeners about property changes
            public event PropertyChangedEventHandler PropertyChanged;

            // Method to raise the PropertyChanged event
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public class ThemesFilesEditor
        {
            public static void ReadThemes(Dictionary<string, Class3.ThemeInfo> themesDictionary, string themesDirectoryPath)
            {
                // Get all JSON files in the directory
                string[] themeFiles = Directory.GetFiles(themesDirectoryPath, "*.json");
                // Step 2: Loop through each file
                foreach (string filePath in themeFiles)
                {
                    Class3.ThemesFilesEditor.ReadThemesFile(themesDictionary, filePath);
                }
            }

            public static void ReadThemesFile(Dictionary<string, Class3.ThemeInfo> themesDictionary, string filePath)
            {
                string jsonContent = File.ReadAllText(filePath);
                if (string.IsNullOrWhiteSpace(jsonContent))
                {
                    MessageBox.Show($"The file {filePath} is empty or invalid.");
                    return;
                }
                try
                {
                    // Deserialize into a ThemeInfo object using System.Text.Json
                    Class3.ThemeInfo theme = JsonSerializer.Deserialize<Class3.ThemeInfo>(jsonContent);
                    if (theme == null || string.IsNullOrWhiteSpace(theme.ThemeName))
                    {
                        MessageBox.Show($"Theme in file {filePath} is invalid or missing ThemeName.");
                        return;
                    }
                    // Add to dictionary
                    themesDictionary[theme.ThemeName] = theme;
                }
                catch (JsonException ex)
                {
                    MessageBox.Show($"Error parsing file {filePath}: {ex.Message}");
                }
            }

            public static void WriteAllThemesToFile(Dictionary<string, Class3.ThemeInfo> themesDictionary, string themesDirectoryPath)
            {
                // Loop through the dictionary and write each theme to a file
                foreach (var entry in themesDictionary)
                {
                    if (entry.Key != "phd2mm_light" || entry.Key != "phd2mm_dark")
                    {
                        // Skip the default themes
                        continue;
                    }
                    string filePath = Path.Combine(themesDirectoryPath, entry.Key + ".json");
                    WriteThemeToFile(entry, filePath);
                }
            }
            public static void WriteThemeToFile(KeyValuePair<string, ThemeInfo> entry, string filePath)
            {
                // Step 3: Serialize the ThemeInfo object and write to file
                string jsonContent = JsonSerializer.Serialize(entry.Value, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, jsonContent);
            }
        }

        public class ThemesManager
        {
            public static void InitializeDefaultThemes(Dictionary<string, Class3.ThemeInfo> themesDictionary)
            {
                themesDictionary.Add("phd2mm_light", new Class3.ThemeInfo
                (
                    "phd2mm_light", // ThemeName
                    "#F0F0F0FF", // GGC_Grid_BackgroundColor
                    "#F0F0F0FF", // GGC_TabControl_BackgroundColor
                    "#000000FF", // GGC_TabControl_BorderColor
                    "#FFFFFFFF", // GGC_TabItem_BackgroundColor
                    "#000000FF", // GGC_TabItem_TextColor
                    "#000000FF", // GGC_TabItem_BorderColor
                    "#F0F0F0FF", // GGC_ComboBox_BackgroundColor
                    "#000000FF", // GGC_ComboBox_TextColor
                    "#000000FF", // GGC_ComboBox_BorderColor
                    "#F0F0F0FF", // GGC_ListBox_BackgroundColor
                    "#000000FF", // GGC_ListBox_TextColor
                    "#000000FF", // GGC_ListBox_BorderColor
                    "#F0F0F0FF", // GGC_GroupBox_BackgroundColor
                    "#000000FF", // GGC_GroupBox_BorderColor
                    "#FFFFFFFF", // GGC_StackPanel_BackgroundColor
                    "#FFFFFFFF", // GGC_RadioButton_BackgroundColor
                    "#000000FF", // GGC_RadioButton_TextColor
                    "#F0F0F0FF", // GGC_Button_BackgroundColor
                    "#000000FF", // GGC_Button_TextColor
                    "#000000FF", // GGC_Button_BorderColor
                    "#FFFFFFFF", // GGC_TextBox_BackgroundColor
                    "#000000FF", // GGC_TextBox_TextColor
                    "#000000FF", // GGC_TextBox_BorderColor
                    "#FFFFFFFF", // GGC_Label_BackgroundColor
                    "#000000FF", // GGC_Label_TextColor
                    "#F0F0F0FF", // GTC_DG_DataGrid_BackgroundColor
                    "#000000FF", // GTC_DG_DataGrid_TextColor
                    "#000000FF", // GTC_DG_DataGrid_BorderColor
                    "#FFFFFFFF", // GTC_DG_Row_BackgroundColor
                    "#000000FF", // GTC_DG_Row_BorderColor
                    "#E6E6E6FF", // GTC_DG_AlternateRow_BackgroundColor
                    "#F0F0F0FF", // GTC_DG_SelectedRow_BackgroundColor
                    "#000000FF", // GTC_DG_SelectedRow_TextColor
                    "#FFFFFFFF", // GTC_DG_ColumnHeader_BackgroundColor
                    "#000000FF", // GTC_DG_ColumnHeader_BorderColor
                    "#000000FF", // GTC_DG_SortArrow_TextColor
                    "",          // MMGC_ModManagerBackgroundImage
                    "",          // MMGC_ModManagerIconImage
                    "",          // MMGC_UnusedModsTableBackgroundImage
                    "",          // MMGC_UsedModsTableBackgroundImage
                    "#F0F0F0FF", // MMGC_ComboBox_BackgroundColor
                    "#000000FF", // MMGC_ComboBox_TextColor
                    "#000000FF", // MMGC_ComboBox_BorderColor
                    "#F0F0F0FF", // MMGC_Button_BackgroundColor
                    "#000000FF", // MMGC_Button_TextColor
                    "#000000FF", // MMGC_Button_BorderColor
                    "#FFFFFFFF", // MMGC_TextBox_BackgroundColor
                    "#000000FF", // MMGC_TextBox_TextColor
                    "#000000FF", // MMGC_TextBox_BorderColor
                    "#FFFFFFFF", // MMGC_Label_BackgroundColor
                    "#000000FF", // MMGC_Label_TextColor
                    "#F0F0F0FF", // MMTC_UnusedModsTable_DG_DataGrid_BackgroundColor
                    "#000000FF", // MMTC_UnusedModsTable_DG_DataGrid_TextColor
                    "#000000FF", // MMTC_UnusedModsTable_DG_DataGrid_BorderColor
                    "#FFFFFFFF", // MMTC_UnusedModsTable_DG_Row_BackgroundColor
                    "#000000FF", // MMTC_UnusedModsTable_DG_Row_BorderColor
                    "#E6E6E6FF", // MMTC_UnusedModsTable_DG_AlternateRow_BackgroundColor
                    "#F0F0F0FF", // MMTC_UnusedModsTable_DG_SelectedRow_BackgroundColor
                    "#000000FF", // MMTC_UnusedModsTable_DG_SelectedRow_TextColor
                    "#FFFFFFFF", // MMTC_UnusedModsTable_DG_ColumnHeader_BackgroundColor
                    "#000000FF", // MMTC_UnusedModsTable_DG_ColumnHeader_BorderColor
                    "#000000FF", // MMTC_UnusedModsTable_DG_SortArrow_TextColor
                    "#F0F0F0FF", // MMTC_UsedModsTable_DG_DataGrid_BackgroundColor
                    "#000000FF", // MMTC_UsedModsTable_DG_DataGrid_TextColor
                    "#000000FF", // MMTC_UsedModsTable_DG_DataGrid_BorderColor
                    "#FFFFFFFF", // MMTC_UsedModsTable_DG_Row_BackgroundColor
                    "#000000FF", // MMTC_UsedModsTable_DG_Row_BorderColor
                    "#E6E6E6FF", // MMTC_UsedModsTable_DG_AlternateRow_BackgroundColor
                    "#F0F0F0FF", // MMTC_UsedModsTable_DG_SelectedRow_BackgroundColor
                    "#000000FF", // MMTC_UsedModsTable_DG_SelectedRow_TextColor
                    "#FFFFFFFF", // MMTC_UsedModsTable_DG_ColumnHeader_BackgroundColor
                    "#000000FF", // MMTC_UsedModsTable_DG_ColumnHeader_BorderColor
                    "#000000FF", // MMTC_UsedModsTable_DG_SortArrow_TextColor
                    "Auto"        // MMTC_VerticalScrollBarVisibility
                ));

                // Dark Theme (phd2mm_dark)
                themesDictionary.Add("phd2mm_dark", new Class3.ThemeInfo
                (
                    "phd2mm_dark", // ThemeName
                    "#2A2A2AFF", // GGC_Grid_BackgroundColor
                    "#2A2A2AFF", // GGC_TabControl_BackgroundColor
                    "#FFFFFFFF", // GGC_TabControl_BorderColor
                    "#333333FF", // GGC_TabItem_BackgroundColor
                    "#FFFFFFFF", // GGC_TabItem_TextColor
                    "#FFFFFFFF", // GGC_TabItem_BorderColor
                    "#333333FF", // GGC_ComboBox_BackgroundColor
                    "#FFFFFFFF", // GGC_ComboBox_TextColor
                    "#FFFFFFFF", // GGC_ComboBox_BorderColor
                    "#333333FF", // GGC_ListBox_BackgroundColor
                    "#FFFFFFFF", // GGC_ListBox_TextColor
                    "#FFFFFFFF", // GGC_ListBox_BorderColor
                    "#333333FF", // GGC_GroupBox_BackgroundColor
                    "#FFFFFFFF", // GGC_GroupBox_BorderColor
                    "#2A2A2AFF", // GGC_StackPanel_BackgroundColor
                    "#333333FF", // GGC_RadioButton_BackgroundColor
                    "#FFFFFFFF", // GGC_RadioButton_TextColor
                    "#2A2A2AFF", // GGC_Button_BackgroundColor
                    "#FFFFFFFF", // GGC_Button_TextColor
                    "#FFFFFFFF", // GGC_Button_BorderColor
                    "#2A2A2AFF", // GGC_TextBox_BackgroundColor
                    "#FFFFFFFF", // GGC_TextBox_TextColor
                    "#FFFFFFFF", // GGC_TextBox_BorderColor
                    "#333333FF", // GGC_Label_BackgroundColor
                    "#FFFFFFFF", // GGC_Label_TextColor
                    "#2A2A2AFF", // GTC_DG_DataGrid_BackgroundColor
                    "#FFFFFFFF", // GTC_DG_DataGrid_TextColor
                    "#FFFFFFFF", // GTC_DG_DataGrid_BorderColor
                    "#2A2A2AFF", // GTC_DG_Row_BackgroundColor
                    "#FFFFFFFF", // GTC_DG_Row_BorderColor
                    "#3C3C3CFF", // GTC_DG_AlternateRow_BackgroundColor
                    "#3C3C3CFF", // GTC_DG_SelectedRow_BackgroundColor
                    "#FFFFFFFF", // GTC_DG_SelectedRow_TextColor
                    "#333333FF", // GTC_DG_ColumnHeader_BackgroundColor
                    "#FFFFFFFF", // GTC_DG_ColumnHeader_BorderColor
                    "#FFFFFFFF", // GTC_DG_SortArrow_TextColor
                    "", // MMGC_ModManagerBackgroundImage
                    "", // MMGC_ModManagerIconImage
                    "", // MMGC_UnusedModsTableBackgroundImage
                    "", // MMGC_UsedModsTableBackgroundImage
                    "#333333FF", // MMGC_ComboBox_BackgroundColor
                    "#FFFFFFFF", // MMGC_ComboBox_TextColor
                    "#FFFFFFFF", // MMGC_ComboBox_BorderColor
                    "#2A2A2AFF", // MMGC_Button_BackgroundColor
                    "#FFFFFFFF", // MMGC_Button_TextColor
                    "#FFFFFFFF", // MMGC_Button_BorderColor
                    "#2A2A2AFF", // MMGC_TextBox_BackgroundColor
                    "#FFFFFFFF", // MMGC_TextBox_TextColor
                    "#FFFFFFFF", // MMGC_TextBox_BorderColor
                    "#333333FF", // MMGC_Label_BackgroundColor
                    "#FFFFFFFF", // MMGC_Label_TextColor
                    "#2A2A2AFF", // MMTC_UnusedModsTable_DG_DataGrid_BackgroundColor
                    "#FFFFFFFF", // MMTC_UnusedModsTable_DG_DataGrid_TextColor
                    "#FFFFFFFF", // MMTC_UnusedModsTable_DG_DataGrid_BorderColor
                    "#2A2A2AFF", // MMTC_UnusedModsTable_DG_Row_BackgroundColor
                    "#FFFFFFFF", // MMTC_UnusedModsTable_DG_Row_BorderColor
                    "#3C3C3CFF", // MMTC_UnusedModsTable_DG_AlternateRow_BackgroundColor
                    "#3C3C3CFF", // MMTC_UnusedModsTable_DG_SelectedRow_BackgroundColor
                    "#FFFFFFFF", // MMTC_UnusedModsTable_DG_SelectedRow_TextColor
                    "#333333FF", // MMTC_UnusedModsTable_DG_ColumnHeader_BackgroundColor
                    "#FFFFFFFF", // MMTC_UnusedModsTable_DG_ColumnHeader_BorderColor
                    "#FFFFFFFF", // MMTC_UnusedModsTable_DG_SortArrow_TextColor
                    "#2A2A2AFF", // MMTC_UsedModsTable_DG_DataGrid_BackgroundColor
                    "#FFFFFFFF", // MMTC_UsedModsTable_DG_DataGrid_TextColor
                    "#FFFFFFFF", // MMTC_UsedModsTable_DG_DataGrid_BorderColor
                    "#2A2A2AFF", // MMTC_UsedModsTable_DG_Row_BackgroundColor
                    "#FFFFFFFF", // MMTC_UsedModsTable_DG_Row_BorderColor
                    "#3C3C3CFF", // MMTC_UsedModsTable_DG_AlternateRow_BackgroundColor
                    "#3C3C3CFF", // MMTC_UsedModsTable_DG_SelectedRow_BackgroundColor
                    "#FFFFFFFF", // MMTC_UsedModsTable_DG_SelectedRow_TextColor
                    "#333333FF", // MMTC_UsedModsTable_DG_ColumnHeader_BackgroundColor
                    "#FFFFFFFF", // MMTC_UsedModsTable_DG_ColumnHeader_BorderColor
                    "#FFFFFFFF", // MMTC_UsedModsTable_DG_SortArrow_TextColor
                    "Auto" // MMTC_VerticalScrollBarVisibility
                ));
            }


            public static void InitializeAllThemes(Dictionary<string, Class3.ThemeInfo> themesDictionary,
                Dictionary<string, Class3.ProfileSpecificThemeInfo> profileSpecificThemesDictionary,
                ObservableCollection<string> ProfilesList_ProfileNames,
                ObservableCollection<Class3.ProfileSpecificThemeInfo> Themes_ProfileSpecificThemes_DataGrid_ObservableCollection,
                ObservableCollection<string> Themes_ProfileSpecificThemes_DataGrid_ThemeNames_ObservableCollection,
                ObservableCollection<string> Themes_ThemeNames_NoEmptyString_ObservableCollection
                )
            {
                // Sort theme names, then add them to the ObservableCollections.
                // I'll copy paste the explanation from MainWindow.xaml.cs.
                // // Themes_ProfileSpecificThemes_DataGrid_ThemeNames_ObservableCollection is for the associated DataGrid, it has empty string that user can select.
                // Empty string in this case means don't use any profile-specific theme for a profile.
                // Themes_ThemeNames_NoEmptyString_ObservableCollection is for the associated ListBox and ComboBox, it doesn't have empty string that user can select.
                var sortedThemeNames = themesDictionary.Keys.OrderBy(themeName => themeName).ToList();
                //sortedThemeNames.Insert(0, ""); // Add empty string at top
                Themes_ProfileSpecificThemes_DataGrid_ThemeNames_ObservableCollection.Add("");
                foreach (var theme in sortedThemeNames)
                {
                    //MessageBox.Show(theme);
                    Themes_ProfileSpecificThemes_DataGrid_ThemeNames_ObservableCollection.Add(theme);
                    //MessageBox.Show(Themes_ProfileSpecificThemes_DataGrid_ThemeNames_ObservableCollection);
                    Themes_ThemeNames_NoEmptyString_ObservableCollection.Add(theme);
                }
                // Create entries for each profile
                foreach (var profileName in ProfilesList_ProfileNames)
                {
                    var profileSpecificThemeInfo = new Class3.ProfileSpecificThemeInfo(profileName, "");
                    //MessageBox.Show(profileSpecificThemeInfo.ProfileName);
                    profileSpecificThemesDictionary[profileName] = profileSpecificThemeInfo;
                }
                // Populate DataGrid source
                foreach (var entry in profileSpecificThemesDictionary.Values)
                {
                    Themes_ProfileSpecificThemes_DataGrid_ObservableCollection.Add(entry);
                }
            }

            public static void InitializeThemesInThemes_ThemeNames_ListBox(Dictionary<string, Class3.ThemeInfo> themesDictionary, ListBox Themes_ThemeNames_ListBox, ComboBox Themes_GlobalTheme_ComboBox)
            {
                // Loop through the dictionary and insert theme names into the ListBox.
                foreach (var entry in themesDictionary)
                {
                    Themes_ThemeNames_ListBox.Items.Add(entry.Key);
                    Themes_GlobalTheme_ComboBox.Items.Add(entry.Key);
                }
            }

            public static void ApplyThemesToControls(Dictionary<string, Class3.ThemeInfo> themesDictionary, string selectedThemeName,
                Image ProfileImage_Background_Image, Image ProfileImage_Icon_Image,
                Image ProfileImage_UnusedMods_DataGrid_Image, Image ProfileImage_UsedMods_DataGrid_Image)
            {
                if (themesDictionary.TryGetValue(selectedThemeName, out Class3.ThemeInfo selectedTheme))
                {
                    // Use reflection to loop through the properties of the selected theme
                    var properties = selectedTheme.GetType().GetProperties();
                    foreach (var property in properties)
                    {
                        // Get the property name and value
                        string propertyName = property.Name;
                        var propertyValue = property.GetValue(selectedTheme)?.ToString();
                        //MessageBox.Show(propertyName + " " + propertyValue);
                        // Handle ScrollBarVisibility separately for the exception
                        if (propertyName == "MMTC_VerticalScrollBarVisibility")
                        {
                            continue;
                        }
                        if (propertyName == "MMGC_ModManagerBackgroundImage" || propertyName == "MMGC_ModManagerIconImage" ||
                            propertyName == "MMGC_UnusedModsTableBackgroundImage" || propertyName == "MMGC_UsedModsTableBackgroundImage")
                        {
                            // MessageBox.Show(propertyName + " " + propertyValue);
                            // Handle image paths
                            string themesDirectoryPath = Class1.GetThemesDirectoryPath();
                            string fullPath = Path.Combine(Class1.GetThemesDirectoryPath(), propertyValue);
                            switch (propertyName)
                            {
                                case "MMGC_ModManagerBackgroundImage":
                                    SetImageOrClear(ProfileImage_Background_Image, fullPath, propertyValue);
                                    break;
                                case "MMGC_ModManagerIconImage":
                                    SetImageOrClear(ProfileImage_Icon_Image, fullPath, propertyValue);
                                    break;
                                case "MMGC_UnusedModsTableBackgroundImage":
                                    SetImageOrClear(ProfileImage_UnusedMods_DataGrid_Image, fullPath, propertyValue);
                                    break;
                                case "MMGC_UsedModsTableBackgroundImage":
                                    SetImageOrClear(ProfileImage_UsedMods_DataGrid_Image, fullPath, propertyValue);
                                    break;
                                default:
                                    // Handle cases where no match is found (if needed)
                                    break;
                            }
                        }
                        // Check if the resource key exists in App.xaml
                        if (Application.Current.Resources.Contains(propertyName) && !string.IsNullOrEmpty(propertyValue))
                        {
                            try
                            {
                                    // Try to apply it as an RGBA hex color
                                    try
                                    {
                                        // Check if it's in RGBA format (e.g., #RRGGBBAA)
                                        if (propertyValue.StartsWith("#") && propertyValue.Length == 9)
                                        {
                                            // Parse the RGBA hex color
                                            byte r = Convert.ToByte(propertyValue.Substring(1, 2), 16);
                                            byte g = Convert.ToByte(propertyValue.Substring(3, 2), 16);
                                            byte b = Convert.ToByte(propertyValue.Substring(5, 2), 16);
                                            byte a = Convert.ToByte(propertyValue.Substring(7, 2), 16);
                                            Color color = Color.FromArgb(a, r, g, b);
                                            Application.Current.Resources[propertyName] = new SolidColorBrush(color);
                                        }
                                        else
                                        {
                                            // If it's not RGBA, try the regular color format (#RRGGBB)
                                            var color = (Color)ColorConverter.ConvertFromString(propertyValue);
                                            Application.Current.Resources[propertyName] = new SolidColorBrush(color);
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        // If it's not a valid color, just assign the value directly
                                        Application.Current.Resources[propertyName] = propertyValue;
                                    }
                            }
                            catch (Exception ex)
                            {
                                // Optionally log the error or handle it
                                Console.WriteLine($"Error applying theme property {propertyName}: {ex.Message}");
                            }
                        }
                    }
                }
            }

            public static void SetImageOrClear(Image imageControl, string fullPath, string propertyValue)
            {
                if (string.IsNullOrWhiteSpace(propertyValue))
                {
                    imageControl.Source = null; // Clear image if no path provided
                    return;
                }
                if (File.Exists(fullPath))
                {
                    try
                    {
                        var uri = new Uri(fullPath);
                        var bitmap = new BitmapImage(uri);
                        imageControl.Source = bitmap;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image from {propertyValue}: {ex.Message}");
                    }
                }
                else
                {
                    imageControl.Source = null; // Optional: Clear the image if file doesn't exist
                                                // Optionally show a warning
                                                // MessageBox.Show($"Image file not found: {fullPath}");
                }
            }

        }

        public class ThemesValidator
        {
            // Method to validate image path
            public static bool ValidateImageType(string path)
            {
                // Supported image extensions
                string[] supportedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
                // Check if file exists
                if (File.Exists(path) == false)
                {
                    MessageBox.Show("The specified file does not exist.");
                    return false;
                }
                // Get the file extension
                string extension = Path.GetExtension(path).ToLower();
                // Check if the extension is in the list of supported types
                if (supportedExtensions.Contains(extension) == false)
                {
                    MessageBox.Show("The image file format is not supported.");
                    return false;
                }
                return true;
            }

            public static bool TryValidateAndNormalizeHex(ref string hex)
            {
                if (string.IsNullOrWhiteSpace(hex) || !hex.StartsWith("#"))
                    return false;
                string hexDigits = hex.Substring(1);
                if (hexDigits.Length == 6)
                {
                    // Add full opacity if only RGB is provided
                    hex += "FF";
                    return Class3.ThemesValidator.IsValidHex(hex.Substring(1));
                }
                else if (hexDigits.Length == 8)
                {
                    return Class3.ThemesValidator.IsValidHex(hexDigits);
                }
                return false;
            }

            public static bool IsValidHex(string hex)
            {
                return hex.All(c => "0123456789ABCDEFabcdef".Contains(c));
            }
        }



















    }
}
