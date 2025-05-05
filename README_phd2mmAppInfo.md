# Personal Helldivers 2 Mod Manager (phd2mm)





============================================================================
### Theme Manager Info
Theme Management <br>
You can create, duplicate, edit, or delete custom themes. <br>
You cannot edit or delete default themes, "phd2mm_light" and "phd2mm_dark". <br>
If you created a new theme rather than duplicate, then the newly created theme will be based upon the "phd2mm_light" theme. <br>
By default, the app starts with the "phd2mm_light" theme. You can change this by changing the Global Theme dropdown on the top right or 
by setting a Profile-Specific Theme in the table to the right. <br>
You can see the currently applied theme on the top right, above the Global Theme dropdown. <br>
<br>
Profile Specific Themes <br>
The Profile-Specific Theme table contains of 2 columns: Profile and Theme. <br>
The Profile column contains the profile names and the Theme column contains the theme names. <br>
To set a Profile-Specific Theme, simply select a theme from the dropdown next to a profile name. <br>
The Profile-Specific Theme will override the Global Theme. <br>
To remove the Profile-Specific Theme, simply select the blank option in the dropdown. <br>
<br>
Theme Editing <br>
To edit a theme, select the theme you want to edit on the left side of the screen. <br>
There are up to 3 colors you can set for each control: Background Color, Text Color, and Border Color. <br>
To set their color, simply click on the color box and a color picker will pop up. You can then set the color through the color picker. <br>
Note: Only the RGBA hex code value (#RRGGBBAA) is saved and used by the app. The color picker is just a tool to help you select a valid hex color. <br>
<br>
Images <br>
You can set images in the Mod Manager Tab by going to the Mod Manager General Controls Tab. <br>
The images must be in the phd2mm_themes folder before you can set them, as the app only accepts images from that folder. <br>
There are 4 images you can set: Mod Manager Background Image, Mod Manager Icon Image, Unused Mods Table Background Image, and Used Mods Table Background Image. <br>
Mod Manager Background Image is shown behind the entire Mod Manager Tab. 
The default resolution is 201x109. <br>
Mod Manager Icon Image is shown in the top right of the Mod Manager Tab. 
The default resolution is 1753x884.08. <br>
Unused Mods Table Background Image is shown behind the Unused Mods Table. 
The default resolution is 861x754.42. <br>
Used Mods Table Background Image is shown behind the Used Mods Table. 
The default resolution is 861x754.42. <br>
All the images are stretched to fill the available space based on the specified default resolution, which may cause distortion if 
the uploaded image does not match the the specified default resolution. <br>
The supported image file types are: *.jpg, *.jpeg, *.png, *.bmp, and *.gif. <br>
To remove the images, you can click the "Clear" button or just remove the text in the textbox to the right side of the "Clear" button. <br>
<br>
There are 4 tabs: Global General Controls, Global Table Controls, Mod Manager General Controls, Mod Manager Table Controls <br>
Global General Controls and Global Table Controls are the 2 main tabs. If you want to have a separate color scheme for just the 
Mod Manager Tab, then you can edit the Mod Manager General Controls and Mod Manager Table Controls Tab. <br>
However, if you don't want to edit them separately, just set the colors in Global General Controls and Global Table Controls and then 
do the following: <br> 
Go to the Mod Manager General Controls and click the "Copy Global General Controls Customization" button. <br>
Go to the Mod Manager Table Controls and click the "Copy Global Table Controls" button for both Unused Mods Table and Used Mods Table. <br>
Doing these will copy the colors from the Global General Controls and Global Table Controls to the Mod Manager General Controls and Mod Manager Table Controls. <br>
<br>
Controls <br>
There are many controls whose colors can be customized. Below is a list of these controls and their descriptions. <br>
Grid: The main area behind everything on the page. <br>
TabControl: The box containing all the tabs and their contents. <br>
TabItem: The clickable tabs at the top of the tab area.\nExamples: Mod Manager, Theme Manager, Settings, More Info tabs. <br>
ComboBox: A box that opens a dropdown list when clicked.\nExamples: Switching Profiles and Global Themes. <br>
ListBox: A box showing a list of items that you can select.\nExample: In the Theme Manager tab, the theme list in the left side showing all the themes. <br>
GroupBox: A box containing the StackPanel and RadioButtons.\nExample: In the Settings tab, you can see the box with outline under Mod Randomization Options
containing the radiobuttons/mod randomization options. The box with the outline is part of GroupBox. <br>
"StackPanel: The box usually inside the GroupBox containing the RadioButtons. <br>
"RadioButton: The text with a round button in the left side, where you can only select one option at a time.\nExample: the 4 choices "
"in the Mod Randomization Options that have circles in the left side of the text. <br>
Button: The clickable button that does something when you click it.\nExamples: Create Profile, Add Selected Mod, Install All Mods from Current Profile,
Browse, and Save Theme Settings. <br>
TextBox: The box where you can enter or view text. Usually, the text inside a box. \nExamples: Search mod text box and Theme Manager Info text box. <br>
Label: The standalone text, usually not inside a box.\nExamples: "Please select a profile:", "Search mod:", "Last Installed Profile", and
the boldened text "Theme Manager Info". <br>
Hover: The color that changes when you hover over your mouse cursor to anything. Currently, it only applies to a few controls:
TabItems, ComboBox, List, and Buttons. <br>
Selected: The color that changes when you select anything. Currently, it only applies to a few controls:
TabItems, ComboBox, List, and Buttons. <br>
DataGrid (DG): The table that shows the mods and their information. <br>
DG Row: A row in the table that shows the mod information. Editing this will change the color of the even-numbered rows. <br>
DG Alternate Row: Same as DG Row, but editing this will change the color of the odd-numbered rows. <br>
DG Selected Row: The highlighted row when selected in the table. Similar to Selected, but for rows in the table. <br>
DG Column Header: The header of the column in the table. Contains texts like Mod Folder Path + Name, Category, and Date Added. <br>
DG Sort Arrow: The arrow that shows the sorting direction of the column. Usually appears when you sort a column alphabetically by ascending or descending order. <br>


============================================================================
### Changelogs
v1.5 <br>
-Migrated app framework from WinForms to WPF. <br>
-Removed "Ship TV" Item from Category "Audio". <br>
-Added "Ship", "Music Pack" and "Democracy Space Station" Items in Category "Audio". <br>
-Added "Ship Interior" and "Democracy Space Station" Item in Category "Visual". <br>
-Replaced "Visual" Category with "Skin" Category for consistency. <br>
WARNING: app may not work properly if your phd2mm_registry.json contains "Visual" Category, <br>
please replace them with "Skin" first before launching the app. <br>
-Removed row header (the leftmost cell in the row, which is just a square without text) from both DataGrids/Tables. <br>
You can now just double-click the cell that belongs to the Mod Folder Path + Name column to add or remove mods. <br>
To rearrange mod load order in Used Mods Table using drag and drop, you can just drag and drop the cell that belongs to <br>
the Mod Folder Path + Name column. <br>
Added feature: Image column now works. Assuming the mod image path is valid and the image file type is supported, <br>
the image column will show a small image preview (48x48 size resolution) of the mod. <br>
You can also hover your mouse cursor over the image to see a larger preview of the image (512x512 size resolution or close to it). <br>
To see which image file types are supported, please see the "Themes Info" tab for more details. <br>
Added feature: Right-click on a mod to open its folder or visit its link using your default browser. <br>
Removed feature: "Enable Mod Randomization button". Now, you simply click the "Randomly Add and Remove Mods" button to randomize your mods. <br>
A warning message will pop up to confirm if you want to randomize your mods or not. <br>
-Drag and drop feature now selects the entire row upon dragging and dropping the mod in Used Tables. However, it has some bugs. <br>
Please check "Known Bugs" section for more details. <br>
-Added more customization options for Themes, including more images, alpha/transparency options, and color picker feature. <br>
Please see Themes Info tab for more details. <br>
-Added Prism Launcher Team, PixiEditor ColorPicker Team, and WPF to Credits. <br>
-Added MIT License for PixiEditor ColorPicker. <br>

v1.4 <br>
-Redesigned UI. <br>
-Added columns: Name, Version, Image, Date Added, and Link. <br>
Previously, it was just Mod Folder Path + Name, Item, Category, and Description columns. <br>
Now, the columns in order, are Mod Folder Path + Name, Name, Item, Category, Description, Image, Date Added, Version, and Link. <br>
However, image display in the Image column is not implemented, so it's hidden by default. <br>
-Clarified mod randomization options. <br>
-Added tab pages to the mod. As a result, 2 windows have been relocated into tabs. <br>
1. The "More Info" button has been removed, its contents are now found in the "More Info" tab. <br>
2. The "Mod Randomization Option" button has been removed, its contents are now found in the "Settings" tab. <br>

-Browsing your Helldivers 2 data folder path is now in the "Settings" tab. <br>
-Changed settings.txt file with settings.json file. <br>
WARNING: You will need to set your Helldivers 2 data folder path again. <br>
-Column visibility is now saved between sessions. <br>
For example, if you hide the Image column and close the app, it will remain hidden next time you open it. <br>
Previously, hidden columns would reset and become visible again. <br>
-App will now also create phd2mm_themes folder. <br>
-Replaced "Toggle Light/Dark Mode" with a theme manager, found in the "Themes" tab. <br>
You can now create, duplicate, edit, and delete custom themes. You cannot edit and delete default themes, "phd2mm_light" and "phd2mm_dark". <br>
NOTE: Due to WinForms limitations, some parts like borders and tabs cannot be colored. <br>
You can now set a global theme or assign profile-specific themes. Profile-specific theme will be prioritized over global theme. <br>
You can also set an image to be displayed in the top right of the "Mod Manager" tab. <br>
NOTE: Only image files in the following formats are accepted: *.png, *.jpg, *.jpeg, *.bmp, *.gif. <br>
Don't forget to click the "Save Changes" button to save your changes. <br>
Custom themes are saved in the phd2mm_themes folder. If they are not there or changes aren't saved, try exiting the app first. <br>
-Added GNU General Public License (GPL) version 3 license. <br>


v1.3.1 <br>
-Fixed UnusedMods_DataGridView not sorting by name by default even when adding new mods
when it should have. <br>
-Replaced "Armor" in Category selection with "Armor Both Bodies", "Armor Brawny Body", and
"Armor Lean Body". <br>
-Added "Automaton Chant", "Ship Screen", and "Ship TV" to Item column selection. <br>
-Replaced "PA System" to "Ship PA System" in Item column selection for clarity. <br>
-Fixed UnusedMods_DataGridView Category column having minimum width of 5 instead of 50. <br>
-Swapped around Category column and Item column. <br>
-Linked the Category column options to the Item column options. This means, for example,
you chose "JAR-5 Dominator" as Item, then the Category column options will be limited
to "Weapon Audio" and "Weapon Skin" only, rather than all of the Category column options.
Now, only Item "Other" can show the entire Category column options. <br>
-Replaced "phd2mm_registry.txt" with "phd2mm_registry.json". <br>
-Resizing the app beyond its original resolution will actually make all the things in it
bigger rather than just the app itself. However, the act of resizing them may create lag. <br>

v1.3 <br>
Form1_phd2mm Personal Helldivers 2 Mod Manager (phd2mm) v1.3 Main Page: <br>
-Redesigned UI. <br>
-Increased size of the main app, "Form1_phd2mm", from 1181x890 resolution to 1759x928 resolution to fit new UI redesign. <br>
-Changed the two ListBoxes to DataGridViews to enable categorization and easier sorting of mods. <br>
-Added "Category" and "Item" ComboBox columns to both of the DataGridViews. <br>
-Added "#" or Mod Order Number column to the DataGridView on the right side, "Mods used in this profile:".
User can directly change the mod order by editing the number in this column.
-Allowed scrolling when resizing the main app, "Form1_phd2mm". <br>
-Removed Label1 "Hello! Welcome to Personal Helldivers 2 Mod Manager (phd2mm)" <br>
-Capitalized the letter M/m of the second word "Search mod:" so now it looks like "Search Mod:" for consistency. <br>
-Enabled WrapMode to allow text to wrap in both of the DataGridViews, making the row bigger rather than cutting off the text. <br>
-Drag and drop now only works with the DataGridView on the right side, "Mods used in this profile:". <br>
To start drag and dropping, click the row header cell (or the leftmost cell in the row) then drag and drop. <br>
Due to this, it conflicts with double-clicking the row header cell to add or remove mods. Drag and drop
is prioritized over double-clicking in this case. Double clicking row header cell still works with the
DataGridView on the left side, "Mods not used in the profile:". <br>
-Changed the way the adding and removing mod works. Now, you can add and remove mods by double-clicking the
cell that belongs to the Mod Folder Path + Name column or by clicking the row header cell once then click the
"Add Selected Mod" or "Remove Selected Mod" buttons. <br> Double-clicking the row header (or the leftmost cell
in the row) only works with UnusedMods_DataGridView and not with UsedMods_DataGridView due to conflict
with drag and drop. <br>
-App will now create "phd2mm_settings" folder, which includes "phd2mm_settings.txt" (previously in the same directory
as the phd2mm app) and a new text file "phd2mm_registry" which contains the details of each mod
(mod folder path + name, category, item, and description, each separated by tab whitespace). <br>
-Added check when deleting last remaining profile, not allowing user to delete the last profile unless they create
another profile. <br>
-App will now traverse through subfolders, only getting folders that have files with ".patch_" in their names. <br>
-Added "Delete All Installed Mods" button. <br>
-More mod randomization options by clicking "Mod Randomization Options". <br>
-Added an context menu option to right-click the "Category", "Item", and "Description" columns to toggle their visibility. <br>

Form3_InstallMods Installing Helldivers 2 Mods Page: <br>
-Slightly increased the size of "Form3_InstalledMods" form from 836x521 resolution to 906x576 resolution. <br>
-Added the text "Deleted old mods in Helldivers 2 data folder." after deleting old mods in the Helldivers 2 data folder.

Form4_MoreInfo More Info Page: <br>
-Slightly increased the size of "Form4_MoreInfo" form from 723x638 resolution to 789x677 resolution. <br>
-Added credits. <br>
-Updated the text in the "More Info" form. <br>

v1.2 <br>
-Added search bar to easily find mods. <br>
-Added a simple mod randomization function. You can enable this by clicking "Enable
Mod Randomization Option" to allow the "Randomly Add and Remove Mods" button to be
clicked. To disable this, click the "Disable Mod Randomization Option". <br>
The reason for this is for user safety in case they wanted to move the mod
up or down or to install the mods. This way, users will not accidentally randomize
their chosen mods. <br>
As of this time, this simple randomization does not take mod conflicts into account,
so be warned. <br>
-Changed text in Form4_MoreInfo from "Form4" to "More Info". <br>
-Capitalized text initials of Form2_CreateNewProfile from "Creating new profile"
to "Creating New Profile" for consistency.
 
v1.1 <br>
-Added drag and drop feature to the TextBox under "Mods used in this profile:",
allowing users to an easier way to rearrange their mod list order.

v1.0 <br>
-First release.


============================================================================
### Credits:
1. teutinsa, their team, and their project HD2ModManager for the inspiration to create this app. <br>
https://www.nexusmods.com/helldivers2/mods/109 <br>

2. Helldivers Wiki Team and their contributors for easy lookup of all things in the game
to easily allow me to create categories and items for this app. <br>
https://helldivers.wiki.gg/ <br>

3. ModOrganizerTeam, their contributors, and their project Mod Organizer 2
for the UI inspiration related to the mod window, categories, and styling. <br>
https://www.nexusmods.com/skyrimspecialedition/mods/6194 <br>

4. Prism Launcher Team, their contributors, and their project Prism Launcher for similar UI inspiration. <br>
https://prismlauncher.org/ <br>

5. PixiEditor ColorPicker Team, their contributors, and their Color Picker functionality used in this app. <br>
https://github.com/PixiEditor/ColorPicker/tree/master - MIT License. <br>

6. Microsoft for Visual Studio 2022 and .NET 9, allowing me to create phd2mm in the first place. <br>
https://visualstudio.microsoft.com/vs/ - Visual Studio License Agreement. <br>
https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9/overview - .NET 9 MIT License. <br>
https://github.com/dotnet/wpf - WPF MIT License. <br>

7. This app is licensed under the GNU General Public License (GPL) version 3. <br>
   For more information, visit the GNU GPL License Page at https://www.gnu.org/licenses/gpl-3.0.en.html. <br>
