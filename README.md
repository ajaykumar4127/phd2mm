# Personal Helldivers 2 Mod Manager (phd2mm)
Hello! Welcome to Personal_HD2ModManager v1.3!
This is NOT the famous teutinsa's HD2ModManager, which is in the link below:
https://www.nexusmods.com/helldivers2/mods/109
This is my own version of a mod manager.
As the name says, I mainly made this mod manager for myself.
Any updates to this program, if there will be any, will be infrequent.
Feel free to copy, edit, and make your own version of this app!
However, I do not allow selling this app or any of its parts.
If you must share this app, please share it for free.
Anyway, I hope you enjoy using this app!
The information below are also included in "More Info" inside the phd2mm app.

### Table of Contents
1. Introduction
2. Adding your Mods to the Mod Manager
3. Browsing your Helldivers 2 Data Directory
4. Profile Creation
5. Mod and Profile Management
6. Mod Installation
7. Other Features
8. Credits
9. Changelogs


============================================================================
### 1. Introduction

Thank you for downloading Personal Helldivers 2 Mod Manager (phd2mm)! Please be aware
that this is simple, buggy, experimental mod manager. You may also have to debug or fix
problems yourself because I only did little testing on this program.
This program will always do a fresh reinstall of mods, meaning your old mods in the
Helldivers 2 data folder will be deleted and only then will new mods be added to it.


============================================================================
### 2. Adding your Mods to the Mod Manager

First, run then exit program. When you run the program, the following folders and
files will be created:
phd2mm_mods folder
phd2mm_profiles folder (has default.txt inside upon fresh download and start)
phd2mm_settings folder (has phd2mm_registry.txt and phd2mm_settings.txt inside
upon fresh download and start)
Once you run and exit the program, put your mods in the phd2mm_mods folder.
The format should be:
Each mod should have its own folder.
No duplicate names and patches, for example, if a mod folder has
9ba626afa44a3aa3.patch_0 and 9ba626afa44a3aa3.patch_1, then it will not be correctly installed.
If it has 9ba626afa44a3aa3.patch_0 and 9ba626afa44a3aa3.patch_0.gpu_resources, then
it will be correctly installed.
Different names will work, assuming it is a valid mod file, for example,
22749a294788af66.patch_0 and e72d3e9b05c3db0b.patch_0 in the same folder will be installed.


============================================================================
### 3. Browsing your Helldivers 2 Data Directory

Find and select your Helldivers 2 data directory by clicking the "Browse" button.
It will check if the path to said directory has "Helldivers 2\data" in it.


============================================================================
### 4. Profile Management

Each profile contains mods that are used together. It is similar to a mod list.
If you do not have any profile, a profile named "default" will automatically
be created for you.
Otherwise, create or choose a profile by clicking the "Create Profile" button.
The profile data will be saved in phd2mm_profiles\<your_profile_name_here>.txt.
This text file contains the mod list saved in the profile.

However, you cannot create a profile with the following characters: \/:*?"<>|
That is because when creating a profile, it also creates the file name the same
as the profile name. In Windows at least, these characters cannot be used as file names.
You also cannot create a profile that are named the following:
CON, PRN, AUX, NUL, COM1, COM2, COM3, COM4, COM5, COM6, COM7, COM8,
COM9, LPT1, LPT2, LPT3, LPT4, LPT5, LPT6, LPT7, LPT8, LPT9
That is because these are reserved names for Windows files. However, you can still use,
for example, CON1 or afdsPRNadsf. The important thing is its not just CON or the like
as your profile name.


============================================================================
### 5. Mod and Profile Management

You can now choose any mod you want to save in the profile by:

-Selecting the leftmost box of a mod (if it selects or highlights the entire row,
then that is the one I'm talking about) in the left side of the screen under
"Mods not used in the profile" then clicking the "Add Selected Mod" button or;
-Simply double left mouse button click either the leftmost box or the mod name.
Doing either of these options will transfer the mod from the left side to the
right side, the "Mods used in the profile".

However, due to bugs, to remove mods from the profile, which are located under "Mods used
in the profile", either select a mod by:
-Selecting the leftmost box of a mod in the right side of the screen under
"Mods used in the profile" then clicking the "Remove Selected Mod" button or;
-Simply double left mouse button click either the leftmost box or the mod name.
Doing either of these options will transfer the mod from the right side to the
left side, the "Mods not used in the profile".

You can rearrange the mod list order under "Mods used in this profile" by:
-Selecting a mod in the right side then click the "Move Up Selected Mod" or
"Move Down Selected Mod" buttons;
-By dragging the leftmost box of a mod in the right side then drop them wherever in
the mod list, or;
-By editing the "#" or Mod Order Number column.
No matter the selection or sort, the mod list will be rearranged accordingly.
Meaning it will always be sorted from top to bottom.

Remember to save your profile by clicking the "Save Profile" button or else the mod list will
not be saved.
You can also delete your currently selected profile by clicking "Delete Profile" button.


============================================================================
### 6. Mod Installation
When you're done with choosing your mods and saving the profile, click the Install All
Mods from Current Profile button.
If you changed the contents and order of the mod list but you did not save it,
it is possible to install the modified-yet-unsaved mod list anyway. However,
it is recommended to save the profile first before installing.

WARNING: This will delete all the mods you have installed in the Helldivers 2 data folder.
After that, it will put the mods there. Basically, this button will always do a clean
reinstall of mods to make it easier to install mods.


============================================================================
### 7. Other Features
-Search Mod: You can search for mods by typing in the search bar. It will filter the mods in both sides.
-Delete All Installed Mods: You can delete all installed mods in the Helldivers 2 data folder by clicking
the "Delete All Installed Mods" button.
-Toggle Light and Dark Mode: You can toggle between light and dark mode by clicking the
"Toggle Light/Dark Mode" button. The app will remember your choice by saving it in
phd2mm_settings\phd2mm_settings.txt. If not, try exiting the app first.
-Resize Columns: You can resize the columns by dragging the column headers.
-Rearrange Columns: You can rearrange the columns by dragging the column headers except for the
leftmost column header.
-Edit Category, Item, and Description: You can edit the Category, Item, and Description columns by
double-clicking the cell you want to edit, typing in the new text, then pressing Enter.
The changes will be saved in phd2mm_settings\phd2mm_registry.txt file. If not, try exiting
the app first.
-Show or Hide Category, Item, and Description: You can right-click any of the column headers except
for the leftmost column header to show or hide the Category, Item, and Description columns.
-Mod Randomization: You can enable mod randomization by clicking "Enable Mod Randomization Option".
This will allow you to click the "Randomly Add and Remove Mods" and "Mod Randomization Options" buttons.
WARNING: This simple mod randomization does not take mod conflicts into account.


============================================================================
### 8. Credits:
teutinsa, their team, and their project HD2ModManager for the inspiration to create this app.
(https://www.nexusmods.com/helldivers2/mods/109)
Helldivers Wiki Team and their contributors for easy lookup of all things in the game
to easily allow me to create categories and items for this app.
(https://helldivers.wiki.gg/)
ModOrganizerTeam, their contributors, and their project Mod Organizer 2
for the UI inspiration related to the mod window, categories, and styling.
(https://www.nexusmods.com/skyrimspecialedition/mods/6194)
Microsoft for Visual Studio 2022 and .NET 9, allowing me to create phd2mm in the first place.
(https://visualstudio.microsoft.com/vs/) Has Visual Studio License Agreement.
(https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9/overview) Has MIT License.

============================================================================
### 9. Changelogs
v1.3
Form1_phd2mm Personal Helldivers 2 Mod Manager (phd2mm) v1.3 Main Page:
-Redesigned UI.
-Increased size of the main app, "Form1_phd2mm", from 1181x890 resolution to 1759x928 resolution to fit new UI redesign.
-Changed the two ListBoxes to DataGridViews to enable categorization and easier sorting of mods.
-Added "Category" and "Item" ComboBox columns to both of the DataGridViews.
-Added "#" or Mod Order Number column to the DataGridView on the right side, "Mods used in this profile:".
User can directly change the mod order by editing the number in this column.
-Allowed scrolling when resizing the main app, "Form1_phd2mm".
-Removed Label1 "Hello! Welcome to Personal Helldivers 2 Mod Manager (phd2mm)"
-Capitalized the letter M/m of the second word "Search mod:" so now it looks like "Search Mod:" for consistency.
-Enabled WrapMode to allow text to wrap in both of the DataGridViews, making the row bigger rather than cutting off the text.
-Drag and drop now only works with the DataGridView on the right side, "Mods used in this profile:".
To start drag and dropping, click the row header cell (or the leftmost cell in the row) then drag and drop.
Due to this, it conflicts with double-clicking the row header cell to add or remove mods. Drag and drop
is prioritized over double-clicking in this case. Double clicking row header cell still works with the
DataGridView on the left side, "Mods not used in the profile:".
-Changed the way the adding and removing mod works. Now, you can add and remove mods by double-clicking the
cell that belongs to the Mod Folder Path + Name column or by clicking the row header cell once then click the
"Add Selected Mod" or "Remove Selected Mod" buttons. Double-clicking the row header (or the leftmost cell
in the row) only works with UnusedMods_DataGridView and not with UsedMods_DataGridView due to conflict
with drag and drop.
-App will now create "phd2mm_settings" folder, which includes "phd2mm_settings.txt" (previously in the same directory
as the phd2mm app) and a new text file "phd2mm_registry" which contains the details of each mod
(mod folder path + name, category, item, and description, each separated by tab whitespace).
-Added check when deleting last remaining profile, not allowing user to delete the last profile unless they create
another profile.
-App will now traverse through subfolders, only getting folders that have files with ".patch_" in their names.
-Added "Delete All Installed Mods" button.
-More mod randomization options by clicking "Mod Randomization Options".
-Added an context menu option to right-click the "Category", "Item", and "Description" columns to toggle their visibility.

Form3_InstallMods Installing Helldivers 2 Mods Page:
-Slightly increased the size of "Form3_InstalledMods" form from 836x521 resolution to 906x576 resolution.
-Added the text "Deleted old mods in Helldivers 2 data folder." after deleting old mods in the Helldivers 2 data folder.

Form4_MoreInfo More Info Page:
-Slightly increased the size of "Form4_MoreInfo" form from 723x638 resolution to 789x677 resolution.
-Added credits.
-Updated the text in the "More Info" form.

v1.2
-Added search bar to easily find mods.
-Added a simple mod randomization function. You can enable this by clicking "Enable
Mod Randomization Option" to allow the "Randomly Add and Remove Mods" button to be
clicked. To disable this, click the "Disable Mod Randomization Option".
The reason for this is for user safety in case they wanted to move the mod
up or down or to install the mods. This way, users will not accidentally randomize
their chosen mods.
As of this time, this simple randomization does not take mod conflicts into account,
so be warned.
-Changed text in Form4_MoreInfo from "Form4" to "More Info".
-Capitalized text initials of Form2_CreateNewProfile from "Creating new profile"
to "Creating New Profile" for consistency.
 
v1.1
-Added drag and drop feature to the TextBox under "Mods used in this profile:",
allowing users to an easier way to rearrange their mod list order.

v1.0
-First release.