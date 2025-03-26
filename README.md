# Personal Helldivers 2 Mod Manager (phd2mm)
Hello! Welcome to Personal_HD2ModManager v1.2!
As the name says, I mainly made this mod manager for myself.
Any updates to this program, if there will be any, will be infrequent.
Feel free to copy and edit this app!
The information below are also included in "More Info" inside the phd2mm app.

# Table of Contents
1. Introduction
2. Adding your Mods to the Mod Manager
3. Browsing your Helldivers 2 Data Directory
4. Profile Creation
5. Mod and Profile Management
6. Mod Installation
7. Changelogs


# 1. Introduction
Thank you for downloading Personal Helldivers 2 Mod Manager! Please be aware that this is
simple, buggy, experimental mod manager that can inconvenience any user. Meaning you
may also have to debug or fix problems yourself because I only did very little
testing on this program. This program will always do a fresh reinstall of mods,
meaning your old mods in the Helldivers 2 data folder will be deleted and only then
will new mods be added to it. This program expects you to adjust to the mod manager,
rather than the other way around. But if it works, it works well.
Again, I only did very little testing on this program.


# 2. Adding your Mods to the Mod Manager
First, run then exit program. When you run the program, the following folders and
files will be created: <br/>
phd2mm_mods folder <br/>
phd2mm_profiles folder (has default.txt inside upon fresh download and start) <br/>
phd2mm_settings.txt <br/>
Once you run and exit the program, put your mods in the phd2mm_mods folder.
The format should be: <br/>
Each mod should have its own folder. <br/>
Only files, no subfolders/subdirectories. <br/>
No duplicate names and patches, for example, if a mod folder has
9ba626afa44a3aa3.patch_0 and 9ba626afa44a3aa3.patch_1, then it will not be correctly installed.
If it has 9ba626afa44a3aa3.patch_0 and 9ba626afa44a3aa3.patch_0.gpu_resources, then
it will be correctly installed. <br/>
Different names will work, assuming it is a valid mod file, for example,
22749a294788af66.patch_0 and e72d3e9b05c3db0b.patch_0 in the same folder will be installed.


# 3. Browsing your Helldivers 2 Data Directory
Find and select your Helldivers 2 data directory by clicking the "Browse" button.
It will check if the path to said directory has "Helldivers 2\data" in it.


# 4. Profile Creation
Each profile contains mods that are used together. It is similar to a mod list.
If you do not have any profile, a profile named "default" will automatically
be created for you.
Otherwise, create or choose a profile by clicking the "Create Profile" button.
The profile data will be saved in phd2mm_profiles\<your_profile_name_here>.txt.
This text file contains the mod list saved in the profile.

However, you cannot create a profile with the following characters: \/:*?"<>| <br/>
That is because when creating a profile, it also creates the file name the same
as the profile name. In Windows at least, these characters cannot be used as file names. <br/>
You also cannot create a profile that are named the following:
CON, PRN, AUX, NUL, COM1, COM2, COM3, COM4, COM5, COM6, COM7, COM8,
COM9, LPT1, LPT2, LPT3, LPT4, LPT5, LPT6, LPT7, LPT8, LPT9 <br/>
That is because these are reserved names for Windows files. However, you can still use,
for example, CON1 or afdsPRNadsf. The important thing is its not just CON or the like
as your profile name.


# 5. Mod and Profile Management
You can now choose any mod you want to save in the profile by selecting a mod in the left
side of the screen under "Mods not used in the profile" then clicking the "Add Selected
Mod" button or simply double-left-mouse-button-click the mod. Doing that will transfer
the mod from the left side to the right side, the "Mods used in the profile".

However, due to bugs, to remove mods from the profile, which are located under "Mods used
in the profile", either select a mod by left-mouse-button-clicking twice then
click the "Remove Selected Mod" button or double-right-mouse-button-clicking a mod.
You can rearrange the mod list order by selecting a mod in the right side then click the 
"Move Up Selected Mod" or "Move Down Selected Mod" buttons or by dragging the mod and put
or drop them wherever in the mod list.

Remember to save your profile by clicking the "Save Profile" button or else the mod list will
not be saved.
You can also delete your currently selected profile by clicking "Delete Profile" button.

As of v1.2, you can now click "Enable Mod Randomization Option" to allow the
"Randomly Add and Remove Mods" button to be clicked. Clicking the "Randomly Add and
Remove Mods" button will randomly add mods. To disable the mod randomization option,
click "Disable Mod Randomization Option".
As of this time, this simple mod randomization does not take mod conflicts into account,
so be warned.


# 6. Mod Installation
When you're done with choosing your mods and saving the profile, click the Install All
Mods from Current Profile button.
If you changed the contents and order of the mod list but you did not save it,
it is possible to install the modified-yet-unsaved mod list anyway. However,
it is recommended to save the profile first before installing.

WARNING: This will delete all the mods you have installed in the Helldivers 2 data folder.
After that, it will put the mods there. Basically, this button will always do a clean
reinstall of mods to make it easier to install mods.

7. Changelogs
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
-First release. Didn't have drag and drop then.