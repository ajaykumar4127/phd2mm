using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3_CreateOrDuplicateTheme : Window
    {
        // Window3.xaml.cs
        // This window is responsible for creating or duplicating a theme.
        public string createOrDuplicateOption;
        public string themeToDuplicate;
        public string newThemeName;
        public List<string> themeNamesList;
        public string invalidCharsPattern = @"[\\/:*?""<>|]";
        public string[] reservedNames =
        {
            "CON", "PRN", "AUX", "NUL", "COM1", "COM2", "COM3", "COM4", "COM5",
            "COM6", "COM7", "COM8", "COM9", "LPT1", "LPT2", "LPT3", "LPT4",
            "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
        };

        public Window3_CreateOrDuplicateTheme()
        {
            InitializeComponent();
        }

        private void Window3_CreateOrDuplicateTheme_Loaded(object sender, RoutedEventArgs e)
        {
            if (createOrDuplicateOption == "CreateTheme")
            {
                this.Title = "Create Theme";
                Label1.Content = "Creating a new theme:";
                Label2.Content = "";
                Label2.Visibility = Visibility.Hidden;
            }
            else if (createOrDuplicateOption == "DuplicateTheme")
            {
                this.Title = "Duplicate Theme";
                Label1.Content = "Duplicating theme:";
                Label2.Content = themeToDuplicate;
                Label2.Visibility = Visibility.Visible;
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreateNewTheme_Button_Click(object sender, RoutedEventArgs e)
        {
            // Check if the text box is empty or contains only white spaces
            if (string.IsNullOrEmpty(NewThemeName_TextBox.Text) || string.IsNullOrWhiteSpace(NewThemeName_TextBox.Text))
            {
                MessageBox.Show("Theme name cannot be empty!\nPlease enter a valid theme name.",
                     "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // Check if the name contains invalid characters
            else if (Regex.IsMatch(NewThemeName_TextBox.Text, invalidCharsPattern))
            {
                MessageBox.Show("Theme name cannot include the following characters: \\/:*?\"<>|\nPlease enter a profile theme name.",
                     "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // Check if the name matches any reserved names
            else if (reservedNames.Contains(NewThemeName_TextBox.Text.ToUpper()))
            {
                MessageBox.Show("Theme name cannot be Windows reserved file names!\nThese include: CON, PRN, AUX, NUL, COM1, COM2, COM3, COM4, COM5, COM6, COM7, COM8, COM9, LPT1, LPT2, LPT3, LPT4, LPT5, LPT6, LPT7, LPT8, LPT9\nPlease enter a valid theme name.",
                     "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (themeNamesList.Any(theme => theme.ToLower() == NewThemeName_TextBox.Text.ToLower()))
            {
                MessageBox.Show("A theme with the name you entered already exists!",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Proceed with the valid theme name
                newThemeName = NewThemeName_TextBox.Text;
                Close(); // Close the window
            }
        }

    }
}
