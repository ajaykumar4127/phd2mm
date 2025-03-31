<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1_phd2mm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Label2 = New Label()
        Hd2DataPathPreview_TextBox = New TextBox()
        BrowseHd2DataPath_Button = New Button()
        Hd2DataPath_FolderBrowserDialogue = New FolderBrowserDialog()
        Label3 = New Label()
        ProfilesList_ComboBox = New ComboBox()
        Label4 = New Label()
        LastInstalledProfile_Label = New Label()
        Label6 = New Label()
        Label7 = New Label()
        CreateProfile_Button = New Button()
        AddSelectedMod_Button = New Button()
        RemoveSelectedMod_Button = New Button()
        SaveProfile_Button = New Button()
        DeleteProfile_Button = New Button()
        MoveModUp_Button = New Button()
        MoveModDown_Button = New Button()
        InstallMods_Button = New Button()
        ToggleLightDarkMode_Button = New Button()
        MoreInfo_Button = New Button()
        Label5 = New Label()
        SearchMod_TextBox = New TextBox()
        EnableModRandomization_Button = New Button()
        RandomizeMods_Button = New Button()
        DeleteAllInstalledMods_Button = New Button()
        UnusedMods_DataGridView = New DataGridView()
        UsedMods_DataGridView = New DataGridView()
        ModRandomizationOptions_Button = New Button()
        UnusedMods_DataGridView_ContextMenuStrip = New ContextMenuStrip(components)
        UsedMods_DataGridView_ContextMenuStrip = New ContextMenuStrip(components)
        UnusedMods_DataGridView_ModFolderPathName_Column = New DataGridViewTextBoxColumn()
        UnusedMods_DataGridView_Category_Column = New DataGridViewComboBoxColumn()
        UnusedMods_DataGridView_Item_Column = New DataGridViewComboBoxColumn()
        UnusedMods_DataGridView_Description_Column = New DataGridViewTextBoxColumn()
        UsedMods_DataGridView_ModOrderNumber_Column = New DataGridViewTextBoxColumn()
        UsedMods_DataGridView_ModFolderPathName_Column = New DataGridViewTextBoxColumn()
        UsedMods_DataGridView_Category_Column = New DataGridViewComboBoxColumn()
        UsedMods_DataGridView_Item_Column = New DataGridViewComboBoxColumn()
        UsedMods_DataGridView_Description_Column = New DataGridViewTextBoxColumn()
        CType(UnusedMods_DataGridView, ComponentModel.ISupportInitialize).BeginInit()
        CType(UsedMods_DataGridView, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(12, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(322, 21)
        Label2.TabIndex = 1
        Label2.Text = "Please select your Helldivers 2 data directory:"
        ' 
        ' Hd2DataPathPreview_TextBox
        ' 
        Hd2DataPathPreview_TextBox.Location = New Point(411, 7)
        Hd2DataPathPreview_TextBox.Name = "Hd2DataPathPreview_TextBox"
        Hd2DataPathPreview_TextBox.ReadOnly = True
        Hd2DataPathPreview_TextBox.Size = New Size(742, 23)
        Hd2DataPathPreview_TextBox.TabIndex = 3
        ' 
        ' BrowseHd2DataPath_Button
        ' 
        BrowseHd2DataPath_Button.Location = New Point(340, 6)
        BrowseHd2DataPath_Button.Name = "BrowseHd2DataPath_Button"
        BrowseHd2DataPath_Button.Size = New Size(65, 24)
        BrowseHd2DataPath_Button.TabIndex = 2
        BrowseHd2DataPath_Button.Text = "Browse"
        BrowseHd2DataPath_Button.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.Location = New Point(12, 33)
        Label3.Name = "Label3"
        Label3.Size = New Size(161, 21)
        Label3.TabIndex = 4
        Label3.Text = "Please select a profile:"
        ' 
        ' ProfilesList_ComboBox
        ' 
        ProfilesList_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ProfilesList_ComboBox.FlatStyle = FlatStyle.Flat
        ProfilesList_ComboBox.FormattingEnabled = True
        ProfilesList_ComboBox.Location = New Point(179, 33)
        ProfilesList_ComboBox.Name = "ProfilesList_ComboBox"
        ProfilesList_ComboBox.Size = New Size(455, 23)
        ProfilesList_ComboBox.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.Location = New Point(824, 33)
        Label4.Name = "Label4"
        Label4.Size = New Size(152, 21)
        Label4.TabIndex = 6
        Label4.Text = "Last installed profile:"
        ' 
        ' LastInstalledProfile_Label
        ' 
        LastInstalledProfile_Label.Font = New Font("Segoe UI", 12F)
        LastInstalledProfile_Label.Location = New Point(973, 33)
        LastInstalledProfile_Label.Name = "LastInstalledProfile_Label"
        LastInstalledProfile_Label.Size = New Size(287, 49)
        LastInstalledProfile_Label.TabIndex = 7
        LastInstalledProfile_Label.Text = "N/A"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.Location = New Point(12, 87)
        Label6.Name = "Label6"
        Label6.Size = New Size(211, 21)
        Label6.TabIndex = 8
        Label6.Text = "Mods not used in this profile:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12F)
        Label7.Location = New Point(878, 87)
        Label7.Name = "Label7"
        Label7.Size = New Size(184, 21)
        Label7.TabIndex = 9
        Label7.Text = "Mods used in this profile:"
        ' 
        ' CreateProfile_Button
        ' 
        CreateProfile_Button.Location = New Point(640, 31)
        CreateProfile_Button.Name = "CreateProfile_Button"
        CreateProfile_Button.Size = New Size(86, 26)
        CreateProfile_Button.TabIndex = 12
        CreateProfile_Button.Text = "Create Profile"
        CreateProfile_Button.UseVisualStyleBackColor = True
        ' 
        ' AddSelectedMod_Button
        ' 
        AddSelectedMod_Button.Location = New Point(12, 111)
        AddSelectedMod_Button.Name = "AddSelectedMod_Button"
        AddSelectedMod_Button.Size = New Size(112, 26)
        AddSelectedMod_Button.TabIndex = 13
        AddSelectedMod_Button.Text = "Add Selected Mod"
        AddSelectedMod_Button.UseVisualStyleBackColor = True
        ' 
        ' RemoveSelectedMod_Button
        ' 
        RemoveSelectedMod_Button.Location = New Point(878, 111)
        RemoveSelectedMod_Button.Name = "RemoveSelectedMod_Button"
        RemoveSelectedMod_Button.Size = New Size(134, 26)
        RemoveSelectedMod_Button.TabIndex = 14
        RemoveSelectedMod_Button.Text = "Remove Selected Mod"
        RemoveSelectedMod_Button.UseVisualStyleBackColor = True
        ' 
        ' SaveProfile_Button
        ' 
        SaveProfile_Button.Location = New Point(640, 59)
        SaveProfile_Button.Name = "SaveProfile_Button"
        SaveProfile_Button.Size = New Size(86, 26)
        SaveProfile_Button.TabIndex = 15
        SaveProfile_Button.Text = "Save Profile"
        SaveProfile_Button.UseVisualStyleBackColor = True
        ' 
        ' DeleteProfile_Button
        ' 
        DeleteProfile_Button.Location = New Point(732, 32)
        DeleteProfile_Button.Name = "DeleteProfile_Button"
        DeleteProfile_Button.Size = New Size(86, 26)
        DeleteProfile_Button.TabIndex = 16
        DeleteProfile_Button.Text = "Delete Profile"
        DeleteProfile_Button.UseVisualStyleBackColor = True
        ' 
        ' MoveModUp_Button
        ' 
        MoveModUp_Button.Location = New Point(1068, 98)
        MoveModUp_Button.Name = "MoveModUp_Button"
        MoveModUp_Button.Size = New Size(93, 39)
        MoveModUp_Button.TabIndex = 19
        MoveModUp_Button.Text = "Move Up Selected Mod"
        MoveModUp_Button.UseVisualStyleBackColor = True
        ' 
        ' MoveModDown_Button
        ' 
        MoveModDown_Button.Location = New Point(1167, 98)
        MoveModDown_Button.Name = "MoveModDown_Button"
        MoveModDown_Button.Size = New Size(93, 39)
        MoveModDown_Button.TabIndex = 20
        MoveModDown_Button.Text = "Move Down  Selected Mod"
        MoveModDown_Button.UseVisualStyleBackColor = True
        ' 
        ' InstallMods_Button
        ' 
        InstallMods_Button.Location = New Point(1634, 59)
        InstallMods_Button.Name = "InstallMods_Button"
        InstallMods_Button.Size = New Size(97, 61)
        InstallMods_Button.TabIndex = 21
        InstallMods_Button.Text = "Install All Mods from Current Profile"
        InstallMods_Button.UseVisualStyleBackColor = True
        ' 
        ' ToggleLightDarkMode_Button
        ' 
        ToggleLightDarkMode_Button.Location = New Point(1586, 6)
        ToggleLightDarkMode_Button.Name = "ToggleLightDarkMode_Button"
        ToggleLightDarkMode_Button.Size = New Size(145, 27)
        ToggleLightDarkMode_Button.TabIndex = 22
        ToggleLightDarkMode_Button.Text = "Toggle Light/Dark Mode"
        ToggleLightDarkMode_Button.UseVisualStyleBackColor = True
        ' 
        ' MoreInfo_Button
        ' 
        MoreInfo_Button.Location = New Point(1494, 6)
        MoreInfo_Button.Name = "MoreInfo_Button"
        MoreInfo_Button.Size = New Size(75, 27)
        MoreInfo_Button.TabIndex = 23
        MoreInfo_Button.Text = "More Info"
        MoreInfo_Button.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F)
        Label5.Location = New Point(12, 61)
        Label5.Name = "Label5"
        Label5.Size = New Size(96, 21)
        Label5.TabIndex = 24
        Label5.Text = "Search mod:"
        ' 
        ' SearchMod_TextBox
        ' 
        SearchMod_TextBox.Location = New Point(114, 61)
        SearchMod_TextBox.Name = "SearchMod_TextBox"
        SearchMod_TextBox.Size = New Size(520, 23)
        SearchMod_TextBox.TabIndex = 25
        ' 
        ' EnableModRandomization_Button
        ' 
        EnableModRandomization_Button.Location = New Point(1407, 59)
        EnableModRandomization_Button.Name = "EnableModRandomization_Button"
        EnableModRandomization_Button.Size = New Size(97, 61)
        EnableModRandomization_Button.TabIndex = 27
        EnableModRandomization_Button.Text = "Enable Mod Randomization"
        EnableModRandomization_Button.UseVisualStyleBackColor = True
        ' 
        ' RandomizeMods_Button
        ' 
        RandomizeMods_Button.Enabled = False
        RandomizeMods_Button.Location = New Point(1275, 33)
        RandomizeMods_Button.Name = "RandomizeMods_Button"
        RandomizeMods_Button.Size = New Size(126, 40)
        RandomizeMods_Button.TabIndex = 29
        RandomizeMods_Button.Text = "Randomize Mods"
        RandomizeMods_Button.UseVisualStyleBackColor = True
        ' 
        ' DeleteAllInstalledMods_Button
        ' 
        DeleteAllInstalledMods_Button.Location = New Point(1522, 59)
        DeleteAllInstalledMods_Button.Name = "DeleteAllInstalledMods_Button"
        DeleteAllInstalledMods_Button.Size = New Size(97, 61)
        DeleteAllInstalledMods_Button.TabIndex = 30
        DeleteAllInstalledMods_Button.Text = "Delete All Installed Mods"
        DeleteAllInstalledMods_Button.UseVisualStyleBackColor = True
        ' 
        ' UnusedMods_DataGridView
        ' 
        UnusedMods_DataGridView.AllowUserToAddRows = False
        UnusedMods_DataGridView.AllowUserToDeleteRows = False
        UnusedMods_DataGridView.AllowUserToOrderColumns = True
        UnusedMods_DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        UnusedMods_DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        UnusedMods_DataGridView.Columns.AddRange(New DataGridViewColumn() {UnusedMods_DataGridView_ModFolderPathName_Column, UnusedMods_DataGridView_Category_Column, UnusedMods_DataGridView_Item_Column, UnusedMods_DataGridView_Description_Column})
        UnusedMods_DataGridView.EnableHeadersVisualStyles = False
        UnusedMods_DataGridView.Location = New Point(12, 143)
        UnusedMods_DataGridView.MultiSelect = False
        UnusedMods_DataGridView.Name = "UnusedMods_DataGridView"
        UnusedMods_DataGridView.Size = New Size(853, 734)
        UnusedMods_DataGridView.TabIndex = 31
        ' 
        ' UsedMods_DataGridView
        ' 
        UsedMods_DataGridView.AllowDrop = True
        UsedMods_DataGridView.AllowUserToAddRows = False
        UsedMods_DataGridView.AllowUserToDeleteRows = False
        UsedMods_DataGridView.AllowUserToOrderColumns = True
        UsedMods_DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        UsedMods_DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        UsedMods_DataGridView.Columns.AddRange(New DataGridViewColumn() {UsedMods_DataGridView_ModOrderNumber_Column, UsedMods_DataGridView_ModFolderPathName_Column, UsedMods_DataGridView_Category_Column, UsedMods_DataGridView_Item_Column, UsedMods_DataGridView_Description_Column})
        UsedMods_DataGridView.EnableHeadersVisualStyles = False
        UsedMods_DataGridView.Location = New Point(878, 143)
        UsedMods_DataGridView.MultiSelect = False
        UsedMods_DataGridView.Name = "UsedMods_DataGridView"
        UsedMods_DataGridView.Size = New Size(853, 734)
        UsedMods_DataGridView.TabIndex = 32
        ' 
        ' ModRandomizationOptions_Button
        ' 
        ModRandomizationOptions_Button.Enabled = False
        ModRandomizationOptions_Button.Location = New Point(1275, 79)
        ModRandomizationOptions_Button.Name = "ModRandomizationOptions_Button"
        ModRandomizationOptions_Button.Size = New Size(126, 40)
        ModRandomizationOptions_Button.TabIndex = 33
        ModRandomizationOptions_Button.Text = "Mod Randomization Options"
        ModRandomizationOptions_Button.UseVisualStyleBackColor = True
        ' 
        ' UnusedMods_DataGridView_ContextMenuStrip
        ' 
        UnusedMods_DataGridView_ContextMenuStrip.Name = "ContextMenuStrip1"
        UnusedMods_DataGridView_ContextMenuStrip.Size = New Size(61, 4)
        ' 
        ' UsedMods_DataGridView_ContextMenuStrip
        ' 
        UsedMods_DataGridView_ContextMenuStrip.Name = "UsedMods_DataGridView_ContextMenuStrip"
        UsedMods_DataGridView_ContextMenuStrip.Size = New Size(61, 4)
        ' 
        ' UnusedMods_DataGridView_ModFolderPathName_Column
        ' 
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        UnusedMods_DataGridView_ModFolderPathName_Column.DefaultCellStyle = DataGridViewCellStyle1
        UnusedMods_DataGridView_ModFolderPathName_Column.HeaderText = "Mod Folder Path + Name"
        UnusedMods_DataGridView_ModFolderPathName_Column.MinimumWidth = 50
        UnusedMods_DataGridView_ModFolderPathName_Column.Name = "UnusedMods_DataGridView_ModFolderPathName_Column"
        UnusedMods_DataGridView_ModFolderPathName_Column.ReadOnly = True
        UnusedMods_DataGridView_ModFolderPathName_Column.Width = 350
        ' 
        ' UnusedMods_DataGridView_Category_Column
        ' 
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        UnusedMods_DataGridView_Category_Column.DefaultCellStyle = DataGridViewCellStyle2
        UnusedMods_DataGridView_Category_Column.FlatStyle = FlatStyle.Flat
        UnusedMods_DataGridView_Category_Column.HeaderText = "Category"
        UnusedMods_DataGridView_Category_Column.Items.AddRange(New Object() {"Armor", "Audio", "Automaton Audio", "Automaton Skin", "Cape", "Helmet", "Illuminate Audio", "Illuminate Skin", "Other", "Player Card", "Stratagem Audio", "Stratagem Skin", "Terminid Audio", "Terminid Skin", "Visual", "Weapon Audio", "Weapon Skin"})
        UnusedMods_DataGridView_Category_Column.Name = "UnusedMods_DataGridView_Category_Column"
        UnusedMods_DataGridView_Category_Column.Sorted = True
        UnusedMods_DataGridView_Category_Column.SortMode = DataGridViewColumnSortMode.Automatic
        UnusedMods_DataGridView_Category_Column.Width = 130
        ' 
        ' UnusedMods_DataGridView_Item_Column
        ' 
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        UnusedMods_DataGridView_Item_Column.DefaultCellStyle = DataGridViewCellStyle3
        UnusedMods_DataGridView_Item_Column.FlatStyle = FlatStyle.Flat
        UnusedMods_DataGridView_Item_Column.HeaderText = "Item"
        UnusedMods_DataGridView_Item_Column.Items.AddRange(New Object() {"A/AC-8 Autocannon Sentry", "A/ARC-3 Tesla Tower", "A/FLAM-40 Flame Sentry", "A/G-16 Gatling Sentry", "A/M-12 Mortar Sentry", "A/M-23 EMS Mortar Sentry", "A/MG-43 Machine Gun Sentry", "A/MLS-4X Rocket Sentry", "AC-1 Dutiful", "AC-2 Obedient", "AF-02 Haz-Master", "AF-50 Noxious Ranger", "AF-52 Lockdown", "AF-91 Field Chemist", "Agent of Oblivion", "Alpha Commander", "Alpha Warrior", "Annihilator Tank", "AR-23 Liberator", "AR-23A Liberator Carbine", "AR-23C Liberator Concussive", "AR-23P Liberator Penetrator", "AR-61 Tenderizer", "ARC-12 Blitzer", "ARC-3 Arc Thrower", "Automaton Music", "AX/AR-23 'Guard Dog'", "AX/LAS-5 'Guard Dog' Rover", "AX/TX-13 'Guard Dog' Dog Breath", "B-01 Tactical v1", "B-01 Tactical v2", "B-01 Tactical v3", "B-01 Tactical v4", "B-08 Light Gunner", "B-1 Supply Pack", "B-100 Portable Hellbomb", "B-22 Model Citizen", "B-24 Enforcer", "B-27 Fortified Commando", "Barrager Tank", "Bastion of Integrity", "Berserker", "Bile Spewer", "Bile Spitter", "Bile Titan", "Bile Warrior", "Blazing Samaritan", "Botslayer", "BR-14 Adjudicator", "Brawler", "Brood Commander", "Bunker Turret", "Cannon Turret", "CB-9 Exploding Crossbow", "CE-07 Demolition Specialist", "CE-101 Guerilla Gorilla", "CE-27 Ground Breaker", "CE-35 Trench Engineer", "CE-64 Grenadier", "CE-67 Titan", "CE-74 Breaker", "CE-81 Juggernaut", "Charger", "Charger Behemoth", "Cloak of Posterity's Gratitude", "CM-09 Bonesnapper", "CM-10 Clinician", "CM-14 Physician", "CM-17 Butcher", "CM-21 Trench Paramedic", "Commissar", "Cover of Darkness", "CQC-19 Stun Lance", "CQC-30 Stun Baton", "CQC-5 Combat Hatchet", "Cresting Honor", "CW-22 Kodiak", "CW-36 Winter Warrior", "CW-4 Arctic Ranger", "CW-9 White Wolf", "Death - Team", "Death - Yours", "Defender of Our Dream", "Democracy Officer", "Descent", "Devastator", "Dissident's Nightmare", "DP-00 Tactical", "DP-11 Champion of the People", "DP-40 Hero of the Federation", "DP-53 Savior of the Free", "Drape of Glory", "Dropship", "E/AT-12 Anti-Tank Emplacement", "E/GL-21 Grenadier Battlement", "E/MG-101 HMG Emplacement", "Eagle 110mm Rocket Pods", "Eagle 500kg Bomb", "Eagle Airstrike", "Eagle Cluster Bomb", "Eagle Napalm Airstrike", "Eagle Smoke Strike", "Eagle Strafing Run", "Eagle-1", "Eagle's Fury", "Elevated Overseer", "Emblem of Freedom", "EX-00 Prototype X", "EX-03 Prototype 3", "EX-16 Prototype 16", "Executioner's Canopy", "EXO-45 Patriot Exosuit", "EXO-49 Emancipator Exosuit", "Experimental Infusion", "Extraction", "Eye of Freedom", "Factory Strider", "Fallen Hero's Vengeance", "Flag Raise", "FLAM-66 Torcher", "Foesmasher", "Fre Liberam", "Freedom's Tapestry", "FS-05 Marksman", "FS-11 Executioner", "FS-23 Battle Master", "FS-34 Exterminator", "FS-37 Ravager", "FS-38 Eradicator", "FS-55 Devastator", "FS-61 Dreadnought", "FX-12 Shield Generator Relay", "G-10 Incendiary", "G-12 High Explosive", "G-123 Thermite", "G-13 Incendiary Impact", "G-16 Impact", "G-23 Stun", "G-3 Smoke", "G-4 Gas", "G-50 Seeker", "G-6 Frag", "GL-21 Grenade Launcher", "GP-31 Grenade Pistol", "GP-31 Ultimatum", "Greatcloak of Rebar Resolve", "GS-11 Democracy's Deputy", "GS-17 Frontier Marshall", "GS-66 Lawmaker", "Gunship", "Harbinger of True Equality", "Harvester", "Heavy Devastator", "Hellbomb", "Helldiver Voice 1", "Helldiver Voice 2", "Helldiver Voice 3", "Helldiver Voice 4", "Hive Guard", "Holder of the Yellow Line", "Hulk", "Hunter", "I-09 Heatseeker", "I-102 Draconaught", "I-44 Salamander", "I-92 Fire Fighter", "ICBM", "Icons", "IE-12 Righteous", "IE-3 Martyr", "IE-57 Hell-Bent", "Illuminate Music", "Impaler", "Independence Bringer", "JAR-5 Dominator", "Judgment Day", "K-2 Throwing Knife", "LAS-16 Sickle", "LAS-17 Double-Edge Sickle", "LAS-5 Scythe", "LAS-58 Talon", "LAS-7 Dagger", "LAS-98 Laser Cannon", "LAS-99 Quasar Cannon", "Liberty's Herald", "LIFT-850 Jump Pack", "LIFT-860 Hover Pack", "Light of Eternal Liberty", "Loading Screen", "M-102 Fast Recon Vehicle", "Mantle of True Citizenship", "Map", "Marauder", "Mark of the Crimson Fang", "Martyris Rex", "MD-17 Anti-Tank Mines", "MD-6 Anti-Personnel Minefield", "MD-8 Gas Mines", "MD-I4 Incendiary Mines", "MG Raider", "Mission Control", "MP-98 Knight", "Nursing Spewer", "Orbital 120mm HE Barrage", "Orbital 380mm HE Barrage", "Orbital Airburst Strike", "Orbital EMS Strike", "Orbital Gas Strike", "Orbital Gatling Barrage", "Orbital Laser", "Orbital Napalm Barrage", "Orbital Precision Strike", "Orbital Railcannon Strike", "Orbital Smoke Strike", "Orbital Walking Barrage", "Order of the Venerated Ballot", "Other", "Overseer", "P-11 Stim Pistol", "P-113 Verdict", "P-19 Redeemer", "P-2 Peacemaker", "P-4 Senator", "P-72 Crisper", "PA System", "Patient Zero's Remembrance", "Pelican-1", "Per Democrasum", "PH-202 Twigsnapper", "PH-56 Jaguar", "PH-9 Predator", "Pinions of Everlasting Glory", "PLAS-1 Scorcher", "PLAS-101 Purifier", "PLAS-15 Loyalist", "PLAS-39 Accelerator Rifle", "Pouncer", "Predator Hunter", "Predator Stalker", "Pride of the Whistleblower", "Proof of Faultless Virtue", "Purifying Eclipse", "R-2124 Constitution", "R-36 Eruptor", "R-6 Deadeye", "R-63 Diligence", "R-63CS Diligence Counter Sniper", "Reaper of Bounties", "Rebar Resolve", "Reinforced Scout Strider", "Rocket Devastator", "Rocket Raider", "SA-04 Combat Technician", "SA-12 Servo Assisted", "SA-25 Steel Trooper", "SA-32 Dynamo", "SC-15 Drone Master", "SC-30 Trailblazer Scout", "SC-34 Infiltrator", "SC-37 Legionnaire", "Scavenger", "Scout Strider", "SG-20 Halt", "SG-22 Bushwhacker", "SG-225 Breaker", "SG-225IE Breaker Incendiary", "SG-225SP Breaker Spray & Pray", "SG-451 Cookout", "SG-8 Punisher", "SG-8P Punisher Plasma", "SG-8S Slugger", "SH-20 Ballistic Shield Backpack", "SH-32 Shield Generator Pack", "SH-51 Directional Shield", "Ship", "Ship Map Music", "Ship Music", "Ship TV", "Shredder Tank", "Shrieker", "SMG-32 Reprimand", "SMG-37 Defender", "SMG-72 Pummeler", "Solid Black", "Spore Burst Hunter", "Spore Burst Scavenger", "Spore Burst Warrior", "Spore Charger", "SR-18 Roadblock", "SR-24 Street Scout", "SR-64 Cinderblock", "StA-11 SMG", "StA-52 Assault Rifle", "Stalker", "Standard of Safe Distance", "Stars and Suffrage", "Stim", "Stone-Wrought Perseverance", "Stratagem Input", "Strength in Our Arms", "Terminals", "Terminid Music", "The Breach", "The Cape of Stars and Suffrage", "Tideturner", "Title", "TR-117 Alpha Commander", "TR-40 Gold Eagle", "TR-62 Knight", "TR-7 Ambassador of the Brand", "TR-9 Cavalier of Democracy", "Trooper", "TX-41 Sterilizer", "Tyrant Hunter", "UF-16 Inspector", "UF-50 Bloodhound", "UF-84 Doubt Killer", "Unblemished Allegiance", "Veil of the Valorous Vagabond", "Vision of Freedom", "Voteless", "Warp Ship", "Warrior", "Watcher", "Way of the Bandolier", "Will of the People"})
        UnusedMods_DataGridView_Item_Column.MinimumWidth = 50
        UnusedMods_DataGridView_Item_Column.Name = "UnusedMods_DataGridView_Item_Column"
        UnusedMods_DataGridView_Item_Column.Resizable = DataGridViewTriState.True
        UnusedMods_DataGridView_Item_Column.Sorted = True
        UnusedMods_DataGridView_Item_Column.SortMode = DataGridViewColumnSortMode.Automatic
        UnusedMods_DataGridView_Item_Column.Width = 160
        ' 
        ' UnusedMods_DataGridView_Description_Column
        ' 
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True
        UnusedMods_DataGridView_Description_Column.DefaultCellStyle = DataGridViewCellStyle4
        UnusedMods_DataGridView_Description_Column.HeaderText = "Description"
        UnusedMods_DataGridView_Description_Column.MinimumWidth = 50
        UnusedMods_DataGridView_Description_Column.Name = "UnusedMods_DataGridView_Description_Column"
        UnusedMods_DataGridView_Description_Column.Width = 150
        ' 
        ' UsedMods_DataGridView_ModOrderNumber_Column
        ' 
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.True
        UsedMods_DataGridView_ModOrderNumber_Column.DefaultCellStyle = DataGridViewCellStyle5
        UsedMods_DataGridView_ModOrderNumber_Column.HeaderText = "#"
        UsedMods_DataGridView_ModOrderNumber_Column.MinimumWidth = 40
        UsedMods_DataGridView_ModOrderNumber_Column.Name = "UsedMods_DataGridView_ModOrderNumber_Column"
        UsedMods_DataGridView_ModOrderNumber_Column.SortMode = DataGridViewColumnSortMode.NotSortable
        UsedMods_DataGridView_ModOrderNumber_Column.Width = 40
        ' 
        ' UsedMods_DataGridView_ModFolderPathName_Column
        ' 
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.True
        UsedMods_DataGridView_ModFolderPathName_Column.DefaultCellStyle = DataGridViewCellStyle6
        UsedMods_DataGridView_ModFolderPathName_Column.HeaderText = "Mod Folder Path + Name"
        UsedMods_DataGridView_ModFolderPathName_Column.MinimumWidth = 50
        UsedMods_DataGridView_ModFolderPathName_Column.Name = "UsedMods_DataGridView_ModFolderPathName_Column"
        UsedMods_DataGridView_ModFolderPathName_Column.ReadOnly = True
        UsedMods_DataGridView_ModFolderPathName_Column.Width = 350
        ' 
        ' UsedMods_DataGridView_Category_Column
        ' 
        DataGridViewCellStyle7.WrapMode = DataGridViewTriState.True
        UsedMods_DataGridView_Category_Column.DefaultCellStyle = DataGridViewCellStyle7
        UsedMods_DataGridView_Category_Column.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        UsedMods_DataGridView_Category_Column.FlatStyle = FlatStyle.Flat
        UsedMods_DataGridView_Category_Column.HeaderText = "Category"
        UsedMods_DataGridView_Category_Column.Items.AddRange(New Object() {"Armor", "Audio", "Automaton Audio", "Automaton Skin", "Cape", "Helmet", "Illuminate Audio", "Illuminate Skin", "Other", "Player Card", "Stratagem Audio", "Stratagem Skin", "Terminid Audio", "Terminid Skin", "Visual", "Weapon Audio", "Weapon Skin"})
        UsedMods_DataGridView_Category_Column.MinimumWidth = 50
        UsedMods_DataGridView_Category_Column.Name = "UsedMods_DataGridView_Category_Column"
        UsedMods_DataGridView_Category_Column.Resizable = DataGridViewTriState.True
        UsedMods_DataGridView_Category_Column.Sorted = True
        UsedMods_DataGridView_Category_Column.SortMode = DataGridViewColumnSortMode.Automatic
        UsedMods_DataGridView_Category_Column.Width = 130
        ' 
        ' UsedMods_DataGridView_Item_Column
        ' 
        DataGridViewCellStyle8.WrapMode = DataGridViewTriState.True
        UsedMods_DataGridView_Item_Column.DefaultCellStyle = DataGridViewCellStyle8
        UsedMods_DataGridView_Item_Column.FlatStyle = FlatStyle.Flat
        UsedMods_DataGridView_Item_Column.HeaderText = "Item"
        UsedMods_DataGridView_Item_Column.Items.AddRange(New Object() {"A/AC-8 Autocannon Sentry", "A/ARC-3 Tesla Tower", "A/FLAM-40 Flame Sentry", "A/G-16 Gatling Sentry", "A/M-12 Mortar Sentry", "A/M-23 EMS Mortar Sentry", "A/MG-43 Machine Gun Sentry", "A/MLS-4X Rocket Sentry", "AC-1 Dutiful", "AC-2 Obedient", "AF-02 Haz-Master", "AF-50 Noxious Ranger", "AF-52 Lockdown", "AF-91 Field Chemist", "Agent of Oblivion", "Alpha Commander", "Alpha Warrior", "Annihilator Tank", "AR-23 Liberator", "AR-23A Liberator Carbine", "AR-23C Liberator Concussive", "AR-23P Liberator Penetrator", "AR-61 Tenderizer", "ARC-12 Blitzer", "ARC-3 Arc Thrower", "Automaton Music", "AX/AR-23 'Guard Dog'", "AX/LAS-5 'Guard Dog' Rover", "AX/TX-13 'Guard Dog' Dog Breath", "B-01 Tactical v1", "B-01 Tactical v2", "B-01 Tactical v3", "B-01 Tactical v4", "B-08 Light Gunner", "B-1 Supply Pack", "B-100 Portable Hellbomb", "B-22 Model Citizen", "B-24 Enforcer", "B-27 Fortified Commando", "Barrager Tank", "Bastion of Integrity", "Berserker", "Bile Spewer", "Bile Spitter", "Bile Titan", "Bile Warrior", "Blazing Samaritan", "Botslayer", "BR-14 Adjudicator", "Brawler", "Brood Commander", "Bunker Turret", "Cannon Turret", "CB-9 Exploding Crossbow", "CE-07 Demolition Specialist", "CE-101 Guerilla Gorilla", "CE-27 Ground Breaker", "CE-35 Trench Engineer", "CE-64 Grenadier", "CE-67 Titan", "CE-74 Breaker", "CE-81 Juggernaut", "Charger", "Charger Behemoth", "Cloak of Posterity's Gratitude", "CM-09 Bonesnapper", "CM-10 Clinician", "CM-14 Physician", "CM-17 Butcher", "CM-21 Trench Paramedic", "Commissar", "Cover of Darkness", "CQC-19 Stun Lance", "CQC-30 Stun Baton", "CQC-5 Combat Hatchet", "Cresting Honor", "CW-22 Kodiak", "CW-36 Winter Warrior", "CW-4 Arctic Ranger", "CW-9 White Wolf", "Death - Team", "Death - Yours", "Defender of Our Dream", "Democracy Officer", "Descent", "Devastator", "Dissident's Nightmare", "DP-00 Tactical", "DP-11 Champion of the People", "DP-40 Hero of the Federation", "DP-53 Savior of the Free", "Drape of Glory", "Dropship", "E/AT-12 Anti-Tank Emplacement", "E/GL-21 Grenadier Battlement", "E/MG-101 HMG Emplacement", "Eagle 110mm Rocket Pods", "Eagle 500kg Bomb", "Eagle Airstrike", "Eagle Cluster Bomb", "Eagle Napalm Airstrike", "Eagle Smoke Strike", "Eagle Strafing Run", "Eagle-1", "Eagle's Fury", "Elevated Overseer", "Emblem of Freedom", "EX-00 Prototype X", "EX-03 Prototype 3", "EX-16 Prototype 16", "Executioner's Canopy", "EXO-45 Patriot Exosuit", "EXO-49 Emancipator Exosuit", "Experimental Infusion", "Extraction", "Eye of Freedom", "Factory Strider", "Fallen Hero's Vengeance", "Flag Raise", "FLAM-66 Torcher", "Foesmasher", "Fre Liberam", "Freedom's Tapestry", "FS-05 Marksman", "FS-11 Executioner", "FS-23 Battle Master", "FS-34 Exterminator", "FS-37 Ravager", "FS-38 Eradicator", "FS-55 Devastator", "FS-61 Dreadnought", "FX-12 Shield Generator Relay", "G-10 Incendiary", "G-12 High Explosive", "G-123 Thermite", "G-13 Incendiary Impact", "G-16 Impact", "G-23 Stun", "G-3 Smoke", "G-4 Gas", "G-50 Seeker", "G-6 Frag", "GL-21 Grenade Launcher", "GP-31 Grenade Pistol", "GP-31 Ultimatum", "Greatcloak of Rebar Resolve", "GS-11 Democracy's Deputy", "GS-17 Frontier Marshall", "GS-66 Lawmaker", "Gunship", "Harbinger of True Equality", "Harvester", "Heavy Devastator", "Hellbomb", "Helldiver Voice 1", "Helldiver Voice 2", "Helldiver Voice 3", "Helldiver Voice 4", "Hive Guard", "Holder of the Yellow Line", "Hulk", "Hunter", "I-09 Heatseeker", "I-102 Draconaught", "I-44 Salamander", "I-92 Fire Fighter", "ICBM", "Icons", "IE-12 Righteous", "IE-3 Martyr", "IE-57 Hell-Bent", "Illuminate Music", "Impaler", "Independence Bringer", "JAR-5 Dominator", "Judgment Day", "K-2 Throwing Knife", "LAS-16 Sickle", "LAS-17 Double-Edge Sickle", "LAS-5 Scythe", "LAS-58 Talon", "LAS-7 Dagger", "LAS-98 Laser Cannon", "LAS-99 Quasar Cannon", "Liberty's Herald", "LIFT-850 Jump Pack", "LIFT-860 Hover Pack", "Light of Eternal Liberty", "Loading Screen", "M-102 Fast Recon Vehicle", "Mantle of True Citizenship", "Map", "Marauder", "Mark of the Crimson Fang", "Martyris Rex", "MD-17 Anti-Tank Mines", "MD-6 Anti-Personnel Minefield", "MD-8 Gas Mines", "MD-I4 Incendiary Mines", "MG Raider", "Mission Control", "MP-98 Knight", "Nursing Spewer", "Orbital 120mm HE Barrage", "Orbital 380mm HE Barrage", "Orbital Airburst Strike", "Orbital EMS Strike", "Orbital Gas Strike", "Orbital Gatling Barrage", "Orbital Laser", "Orbital Napalm Barrage", "Orbital Precision Strike", "Orbital Railcannon Strike", "Orbital Smoke Strike", "Orbital Walking Barrage", "Order of the Venerated Ballot", "Other", "Overseer", "P-11 Stim Pistol", "P-113 Verdict", "P-19 Redeemer", "P-2 Peacemaker", "P-4 Senator", "P-72 Crisper", "PA System", "Patient Zero's Remembrance", "Pelican-1", "Per Democrasum", "PH-202 Twigsnapper", "PH-56 Jaguar", "PH-9 Predator", "Pinions of Everlasting Glory", "PLAS-1 Scorcher", "PLAS-101 Purifier", "PLAS-15 Loyalist", "PLAS-39 Accelerator Rifle", "Pouncer", "Predator Hunter", "Predator Stalker", "Pride of the Whistleblower", "Proof of Faultless Virtue", "Purifying Eclipse", "R-2124 Constitution", "R-36 Eruptor", "R-6 Deadeye", "R-63 Diligence", "R-63CS Diligence Counter Sniper", "Reaper of Bounties", "Rebar Resolve", "Reinforced Scout Strider", "Rocket Devastator", "Rocket Raider", "SA-04 Combat Technician", "SA-12 Servo Assisted", "SA-25 Steel Trooper", "SA-32 Dynamo", "SC-15 Drone Master", "SC-30 Trailblazer Scout", "SC-34 Infiltrator", "SC-37 Legionnaire", "Scavenger", "Scout Strider", "SG-20 Halt", "SG-22 Bushwhacker", "SG-225 Breaker", "SG-225IE Breaker Incendiary", "SG-225SP Breaker Spray & Pray", "SG-451 Cookout", "SG-8 Punisher", "SG-8P Punisher Plasma", "SG-8S Slugger", "SH-20 Ballistic Shield Backpack", "SH-32 Shield Generator Pack", "SH-51 Directional Shield", "Ship", "Ship Map Music", "Ship Music", "Ship TV", "Shredder Tank", "Shrieker", "SMG-32 Reprimand", "SMG-37 Defender", "SMG-72 Pummeler", "Solid Black", "Spore Burst Hunter", "Spore Burst Scavenger", "Spore Burst Warrior", "Spore Charger", "SR-18 Roadblock", "SR-24 Street Scout", "SR-64 Cinderblock", "StA-11 SMG", "StA-52 Assault Rifle", "Stalker", "Standard of Safe Distance", "Stars and Suffrage", "Stim", "Stone-Wrought Perseverance", "Stratagem Input", "Strength in Our Arms", "Terminals", "Terminid Music", "The Breach", "The Cape of Stars and Suffrage", "Tideturner", "Title", "TR-117 Alpha Commander", "TR-40 Gold Eagle", "TR-62 Knight", "TR-7 Ambassador of the Brand", "TR-9 Cavalier of Democracy", "Trooper", "TX-41 Sterilizer", "Tyrant Hunter", "UF-16 Inspector", "UF-50 Bloodhound", "UF-84 Doubt Killer", "Unblemished Allegiance", "Veil of the Valorous Vagabond", "Vision of Freedom", "Voteless", "Warp Ship", "Warrior", "Watcher", "Way of the Bandolier", "Will of the People"})
        UsedMods_DataGridView_Item_Column.MinimumWidth = 50
        UsedMods_DataGridView_Item_Column.Name = "UsedMods_DataGridView_Item_Column"
        UsedMods_DataGridView_Item_Column.Resizable = DataGridViewTriState.True
        UsedMods_DataGridView_Item_Column.Sorted = True
        UsedMods_DataGridView_Item_Column.SortMode = DataGridViewColumnSortMode.Automatic
        UsedMods_DataGridView_Item_Column.Width = 160
        ' 
        ' UsedMods_DataGridView_Description_Column
        ' 
        DataGridViewCellStyle9.WrapMode = DataGridViewTriState.True
        UsedMods_DataGridView_Description_Column.DefaultCellStyle = DataGridViewCellStyle9
        UsedMods_DataGridView_Description_Column.HeaderText = "Description"
        UsedMods_DataGridView_Description_Column.MinimumWidth = 50
        UsedMods_DataGridView_Description_Column.Name = "UsedMods_DataGridView_Description_Column"
        UsedMods_DataGridView_Description_Column.Width = 150
        ' 
        ' Form1_phd2mm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1743, 889)
        Controls.Add(ModRandomizationOptions_Button)
        Controls.Add(UsedMods_DataGridView)
        Controls.Add(UnusedMods_DataGridView)
        Controls.Add(DeleteAllInstalledMods_Button)
        Controls.Add(RandomizeMods_Button)
        Controls.Add(EnableModRandomization_Button)
        Controls.Add(SearchMod_TextBox)
        Controls.Add(Label5)
        Controls.Add(MoreInfo_Button)
        Controls.Add(ToggleLightDarkMode_Button)
        Controls.Add(InstallMods_Button)
        Controls.Add(MoveModDown_Button)
        Controls.Add(MoveModUp_Button)
        Controls.Add(DeleteProfile_Button)
        Controls.Add(SaveProfile_Button)
        Controls.Add(RemoveSelectedMod_Button)
        Controls.Add(AddSelectedMod_Button)
        Controls.Add(CreateProfile_Button)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(LastInstalledProfile_Label)
        Controls.Add(Label4)
        Controls.Add(ProfilesList_ComboBox)
        Controls.Add(Label3)
        Controls.Add(Hd2DataPathPreview_TextBox)
        Controls.Add(BrowseHd2DataPath_Button)
        Controls.Add(Label2)
        Name = "Form1_phd2mm"
        Text = "Personal Helldivers 2 Mod Manager (phd2mm) v1.3"
        CType(UnusedMods_DataGridView, ComponentModel.ISupportInitialize).EndInit()
        CType(UsedMods_DataGridView, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Hd2DataPathPreview_TextBox As TextBox
    Friend WithEvents BrowseHd2DataPath_Button As Button
    Friend WithEvents Hd2DataPath_FolderBrowserDialogue As FolderBrowserDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents ProfilesList_ComboBox As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents LastInstalledProfile_Label As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CreateProfile_Button As Button
    Friend WithEvents AddSelectedMod_Button As Button
    Friend WithEvents RemoveSelectedMod_Button As Button
    Friend WithEvents SaveProfile_Button As Button
    Friend WithEvents DeleteProfile_Button As Button
    Friend WithEvents MoveModUp_Button As Button
    Friend WithEvents MoveModDown_Button As Button
    Friend WithEvents InstallMods_Button As Button
    Friend WithEvents ToggleLightDarkMode_Button As Button
    Friend WithEvents MoreInfo_Button As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents SearchMod_TextBox As TextBox
    Friend WithEvents EnableModRandomization_Button As Button
    Friend WithEvents RandomizeMods_Button As Button
    Friend WithEvents DeleteAllInstalledMods_Button As Button
    Friend WithEvents UnusedMods_DataGridView As DataGridView
    Friend WithEvents UsedMods_DataGridView As DataGridView
    Friend WithEvents ModRandomizationOptions_Button As Button
    Friend WithEvents UnusedMods_DataGridView_ContextMenuStrip As ContextMenuStrip
    Friend WithEvents UsedMods_DataGridView_ContextMenuStrip As ContextMenuStrip
    Friend WithEvents UnusedMods_DataGridView_ModFolderPathName_Column As DataGridViewTextBoxColumn
    Friend WithEvents UnusedMods_DataGridView_Category_Column As DataGridViewComboBoxColumn
    Friend WithEvents UnusedMods_DataGridView_Item_Column As DataGridViewComboBoxColumn
    Friend WithEvents UnusedMods_DataGridView_Description_Column As DataGridViewTextBoxColumn
    Friend WithEvents UsedMods_DataGridView_ModOrderNumber_Column As DataGridViewTextBoxColumn
    Friend WithEvents UsedMods_DataGridView_ModFolderPathName_Column As DataGridViewTextBoxColumn
    Friend WithEvents UsedMods_DataGridView_Category_Column As DataGridViewComboBoxColumn
    Friend WithEvents UsedMods_DataGridView_Item_Column As DataGridViewComboBoxColumn
    Friend WithEvents UsedMods_DataGridView_Description_Column As DataGridViewTextBoxColumn

End Class
