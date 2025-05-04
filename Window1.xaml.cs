using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1_CreateOrDuplicateProfile : Window
    {
        public string createOrDuplicateOption;
        public string profileToDuplicate;
        public string newProfileName;
        public ObservableCollection<string> ProfilesList_ProfileNames { get; set; } = new ObservableCollection<string>();
        public string invalidCharsPattern = @"[\\/:*?""<>|]";
        public string[] reservedNames =
        {
            "CON", "PRN", "AUX", "NUL", "COM1", "COM2", "COM3", "COM4", "COM5",
            "COM6", "COM7", "COM8", "COM9", "LPT1", "LPT2", "LPT3", "LPT4",
            "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
        };

        public Window1_CreateOrDuplicateProfile()
        {
            InitializeComponent();
        }

        private void Window1_CreateOrDuplicateProfile_Loaded(object sender, RoutedEventArgs e)
        {
            if (createOrDuplicateOption == "CreateProfile")
            {
                this.Title = "Create Profile";
                Label1.Content = "Creating a new profile:";
                Label2.Content = "";
                Label2.Visibility = Visibility.Hidden;
            }
            else if (createOrDuplicateOption == "DuplicateProfile")
            { 
                this.Title = "Duplicating profile:";
                Label1.Content = "Duplicating profile:";
                Label2.Content = profileToDuplicate;
                Label2.Visibility = Visibility.Visible;
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreateNewProfile_Button_Click(object sender, RoutedEventArgs e)
        {
            // Check if the text box is empty or contains only white spaces
            if (string.IsNullOrEmpty(NewProfileName_TextBox.Text) || string.IsNullOrWhiteSpace(NewProfileName_TextBox.Text))
            {
                MessageBox.Show("Profile name cannot be empty!\nPlease enter a valid profile name.",
                     "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // Check if the name contains invalid characters
            else if (Regex.IsMatch(NewProfileName_TextBox.Text, invalidCharsPattern))
            {
                MessageBox.Show("Profile name cannot include the following characters: \\/:*?\"<>|\nPlease enter a profile theme name.",
                     "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // Check if the name matches any reserved names
            else if (reservedNames.Contains(NewProfileName_TextBox.Text.ToUpper()))
            {
                MessageBox.Show("Profile name cannot be Windows reserved file names!\nThese include: CON, PRN, AUX, NUL, COM1, COM2, COM3, COM4, COM5, COM6, COM7, COM8, COM9, LPT1, LPT2, LPT3, LPT4, LPT5, LPT6, LPT7, LPT8, LPT9\nPlease enter a valid profile name.",
                     "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // Check if the name already exists (case-insensitive)
            else if (ProfilesList_ProfileNames.Any(profile => profile.ToLower() == NewProfileName_TextBox.Text.ToLower()) == true)
            {
                MessageBox.Show("A profile with the name you entered already exists!",
                     "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Proceed with the valid theme name
                newProfileName = NewProfileName_TextBox.Text;
                Close(); // Close the window
            }
        }

    }
}
