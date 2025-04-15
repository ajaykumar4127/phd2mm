Imports System.IO
Imports phd2mm.Class1

Public Class Class2
    Public Class CategoryAndItemsManager    ' Items are also included in UnusedMods_DataGridView and UsedMods_DataGridView via Designer view.
        Public Shared categoriesAndItemsDictionary As New Dictionary(Of String, List(Of String)) From {     ' Check the Items collection of
    {"Armor_And_Helmet", New List(Of String) From {                                                         ' their respective Item and Categ
        "SC-37 Legionnaire", "SC-34 Infiltrator", "SC-30 Trailblazer Scout",
        "CE-74 Breaker", "FS-38 Eradicator", "B-08 Light Gunner",
        "CM-21 Trench Paramedic", "CE-67 Titan", "EX-00 Prototype X",
        "CE-07 Demolition Specialist", "FS-37 Ravager", "CW-4 Arctic Ranger",
        "PH-9 Predator", "I-09 Heatseeker", "AF-50 Noxious Ranger",
        "UF-16 Inspector", "SR-24 Street Scout", "AC-2 Obedient",
        "IE-57 Hell-Bent", "GS-11 Democracy's Deputy", "GS-17 Frontier Marshall",
        "B-01 Tactical v1", "B-01 Tactical v2", "B-01 Tactical v3",
        "B-01 Tactical v4", "TR-7 Ambassador of the Brand", "TR-9 Cavalier of Democracy",
        "DP-53 Savior of the Free", "TR-117 Alpha Commander", "SC-15 Drone Master",
        "CE-35 Trench Engineer", "CM-09 Bonesnapper", "DP-40 Hero of the Federation",
        "SA-04 Combat Technician", "CM-14 Physician", "DP-11 Champion of the People",
        "SA-25 Steel Trooper", "SA-12 Servo Assisted", "B-24 Enforcer",
        "CE-81 Juggernaut", "FS-34 Exterminator", "EX-03 Prototype 3",
        "EX-16 Prototype 16", "CE-27 Ground Breaker", "CM-10 Clinician",
        "CW-9 White Wolf", "PH-56 Jaguar", "TR-40 Gold Eagle", "I-92 Fire Fighter",
        "I-102 Draconaught", "AF-91 Field Chemist", "AF-02 Haz-Master",
        "DP-00 Tactical", "UF-84 Doubt Killer", "UF-50 Bloodhound", "AC-1 Dutiful",
        "IE-3 Martyr", "IE-12 Righteous", "B-22 Model Citizen", "GS-66 Lawmaker",
        "TR-62 Knight", "FS-05 Marksman", "FS-23 Battle Master", "SA-32 Dynamo",
        "B-27 Fortified Commando", "FS-61 Dreadnought", "FS-11 Executioner",
        "CM-17 Butcher", "FS-55 Devastator", "CW-36 Winter Warrior", "CW-22 Kodiak",
        "CE-64 Grenadier", "CE-101 Guerilla Gorilla", "PH-202 Twigsnapper",
        "I-44 Salamander", "AF-52 Lockdown", "SR-64 Cinderblock", "SR-18 Roadblock",
        "Other"
            }},
    {"Audio", New List(Of String) From {
        "Flag Raise", "Descent", "Terminal", "Extraction", "Hellbomb", "Eagle-1",
        "Pelican-1", "ICBM", "Mission Control", "Helldiver Voice 1", "Helldiver Voice 2",
        "Helldiver Voice 3", "Helldiver Voice 4", "Ship Map Music", "Death - Team", "Death - Yours",
        "Ambient", "Ship PA System", "Democracy Officer", "Stim", "Experimental Infusion",
        "Automaton Chant", "Automaton Music", "Illuminate Music", "Ship Music", "Ship TV",
        "Stratagem Input", "Terminid Music", "Other"
            }},
    {"Automaton_Skin_And_Audio", New List(Of String) From {
        "Trooper", "Brawler", "Marauder", "MG Raider", "Rocket Raider", "Commissar",
        "Scout Strider", "Reinforced Scout Strider", "Berserker", "Devastator",
        "Rocket Devastator", "Heavy Devastator", "Hulk", "Gunship", "Bunker Turret",
        "Cannon Turret", "Annihilator Tank", "Shredder Tank", "Barrager Tank",
        "Factory Strider", "Dropship", "Assault Raider", "Conflagration Devastator",
        "Hulk Firebomber", "Incendiary MG Devastator", "Incendiary Rocket Devastator",
        "Pyro Trooper", "Other"
            }},
    {"Cape", New List(Of String) From {
            "Foesmasher", "Independence Bringer", "Liberty's Herald", "Tideturner",
        "The Cape of Stars and Suffrage", "Unblemished Allegiance", "Judgment Day",
        "Cresting Honor", "Mantle of True Citizenship", "Blazing Samaritan",
        "Light of Eternal Liberty", "Will of the People", "Tyrant Hunter",
        "Cloak of Posterity's Gratitude", "Drape of Glory", "Bastion of Integrity",
        "Botslayer", "Martyris Rex", "Agent of Oblivion", "Fallen Hero's Vengeance",
        "Harbinger of True Equality", "Eagle's Fury", "Freedom's Tapestry",
        "Dissident's Nightmare", "Pinions of Everlasting Glory",
        "Order of the Venerated Ballot", "Mark of the Crimson Fang",
        "Executioner's Canopy", "Purifying Eclipse", "The Breach",
        "Standard of Safe Distance", "Patient Zero's Remembrance", "Cover of Darkness",
        "Pride of the Whistleblower", "Proof of Faultless Virtue",
        "Stone-Wrought Perseverance", "Greatcloak of Rebar Resolve",
        "Holder of the Yellow Line", "Strength in Our Arms", "Defender of Our Dream",
        "Vision of Freedom", "Fre Liberam", "Per Democrasum", "Eye of Freedom",
        "Emblem of Freedom", "Veil of the Valorous Vagabond", "Reaper of Bounties",
        "Way of the Bandolier", "Other"
            }},
    {"Illuminate_Skin_And_Audio", New List(Of String) From {
        "Voteless", "Watcher", "Overseer", "Elevated Overseer", "Harvester",
        "Warp Ship", "Other"
            }},
    {"Other", New List(Of String) From {
    "Other"
            }},
    {"Player_Card", New List(Of String) From {
        "Solid Black", "Independence Bringer", "Liberty's Herald", "Tideturner",
        "Stars and Suffrage", "Unblemished Allegiance", "Judgment Day", "Cresting Honor",
        "Mantle of True Citizenship", "Blazing Samaritan", "Light of Eternal Liberty",
        "Tyrant Hunter", "Cloak of Posterity's Gratitude", "Bastion of Integrity", "Botslayer",
        "Martyris Rex", "Agent of Oblivion", "Harbinger of True Equality", "Eagle's Fury",
        "Freedom's Tapestry", "Dissident's Nightmare", "Pinions of Everlasting Glory",
        "Order of the Venerated Ballot", "Mark of the Crimson Fang", "Executioner's Canopy",
        "Purifying Eclipse", "The Breach", "Standard of Safe Distance",
        "Patient Zero's Remembrance", "Cover of Darkness", "Pride of the Whistleblower",
        "Proof of Faultless Virtue", "Stone-Wrought Perseverance", "Rebar Resolve",
        "Holder of the Yellow Line", "Strength in Our Arms", "Defender of Our Dream",
        "Vision of Freedom", "Fre Liberam", "Per Democrasum",
        "Veil of the Valorous Vagabond", "Reaper of Bounties", "Way of the Bandolier",
        "Other"
            }},
    {"Stratagem_Skin_And_Audio", New List(Of String) From {
        "Orbital Gatling Barrage", "Orbital Airburst Strike", "Orbital 120mm HE Barrage",
        "Orbital 380mm HE Barrage", "Orbital Walking Barrage", "Orbital Laser",
        "Orbital Napalm Barrage", "Orbital Railcannon Strike", "Eagle Strafing Run",
        "Eagle Airstrike", "Eagle Cluster Bomb", "Eagle Napalm Airstrike", "LIFT-850 Jump Pack",
        "Eagle Smoke Strike", "Eagle 110mm Rocket Pods", "Eagle 500kg Bomb", "M-102 Fast Recon Vehicle",
        "Orbital Precision Strike", "Orbital Gas Strike", "Orbital EMS Strike", "Orbital Smoke Strike",
        "E/MG-101 HMG Emplacement", "FX-12 Shield Generator Relay", "A/ARC-3 Tesla Tower",
        "MD-6 Anti-Personnel Minefield", "B-1 Supply Pack", "GL-21 Grenade Launcher", "LAS-98 Laser Cannon",
        "MD-I4 Incendiary Mines", "AX/LAS-5 'Guard Dog' Rover", "SH-20 Ballistic Shield Backpack",
        "ARC-3 Arc Thrower", "MD-17 Anti-Tank Mines", "LAS-99 Quasar Cannon", "SH-32 Shield Generator Pack",
        "MD-8 Gas Mines", "A/MG-43 Machine Gun Sentry", "A/G-16 Gatling Sentry", "A/M-12 Mortar Sentry",
        "AX/AR-23 'Guard Dog'", "A/AC-8 Autocannon Sentry", "A/MLS-4X Rocket Sentry", "A/M-23 EMS Mortar Sentry",
        "EXO-45 Patriot Exosuit", "EXO-49 Emancipator Exosuit", "TX-41 Sterilizer", "AX/TX-13 'Guard Dog' Dog Breath",
        "SH-51 Directional Shield", "E/AT-12 Anti-Tank Emplacement", "A/FLAM-40 Flame Sentry",
        "B-100 Portable Hellbomb", "LIFT-860 Hover Pack", "AC-8 Autocannon", "APW-1 Anti-Materiel Rifle",
        "E/GL-21 Grenadier Battlement", "EAT-17 Expendable Anti-Tank", "FAF-14 Spear", "FLAM-40 Flamethrower",
        "GR-8 Recoilless Rifle", "M-105 Stalwart", "MG-206 Heavy Machine Gun", "MG-43 Machine Gun",
        "MLS-4X Commando", "RL-77 Airburst Rocket Launcher", "RS-422 Railgun", "StA-X3 W.A.S.P. Launcher",
        "Other"
            }},
    {"Terminid_Skin_And_Audio", New List(Of String) From {
        "Scavenger", "Spore Burst Scavenger", "Bile Spitter", "Pouncer", "Hunter",
        "Predator Hunter", "Spore Burst Hunter", "Warrior", "Bile Warrior", "Alpha Warrior",
        "Spore Burst Warrior", "Hive Guard", "Brood Commander", "Alpha Commander", "Stalker",
        "Predator Stalker", "Shrieker", "Bile Spewer", "Nursing Spewer", "Charger",
        "Charger Behemoth", "Spore Charger", "Impaler", "Bile Titan", "Other"
            }},
    {"Visual", New List(Of String) From {
        "Ship", "Title", "Icons", "Loading Screen", "Democracy Officer", "Eagle-1", "Pelican-1",
        "Other"
            }},
    {"Weapon_Skin_And_Audio", New List(Of String) From {
        "AR-23 Liberator", "AR-23P Liberator Penetrator", "AR-23C Liberator Concussive",
        "AR-23A Liberator Carbine", "AR-61 Tenderizer", "BR-14 Adjudicator", "StA-52 Assault Rifle",
        "R-2124 Constitution", "R-6 Deadeye", "R-63 Diligence", "R-63CS Diligence Counter Sniper",
        "PLAS-39 Accelerator Rifle", "MP-98 Knight", "StA-11 SMG", "SMG-32 Reprimand", "SMG-37 Defender",
        "SMG-72 Pummeler", "SG-8 Punisher", "SG-8S Slugger", "SG-20 Halt", "SG-451 Cookout",
        "SG-225 Breaker", "SG-225SP Breaker Spray & Pray", "SG-225IE Breaker Incendiary",
        "CB-9 Exploding Crossbow", "R-36 Eruptor", "SG-8P Punisher Plasma", "ARC-12 Blitzer", "LAS-5 Scythe",
        "LAS-16 Sickle", "LAS-17 Double-Edge Sickle", "PLAS-1 Scorcher", "PLAS-101 Purifier", "FLAM-66 Torcher",
        "JAR-5 Dominator", "P-2 Peacemaker", "P-19 Redeemer", "P-113 Verdict", "P-4 Senator",
        "CQC-19 Stun Lance", "CQC-30 Stun Baton", "CQC-5 Combat Hatchet", "P-11 Stim Pistol",
        "SG-22 Bushwhacker", "P-72 Crisper", "GP-31 Grenade Pistol", "LAS-7 Dagger", "GP-31 Ultimatum",
        "PLAS-15 Loyalist", "LAS-58 Talon", "G-6 Frag", "G-12 High Explosive", "G-10 Incendiary",
        "G-16 Impact", "G-13 Incendiary Impact", "G-23 Stun", "G-4 Gas", "G-50 Seeker", "G-3 Smoke",
        "G-123 Thermite", "K-2 Throwing Knife", "Entrenchment Tool", "SG-88 Break-Action Shotgun",
        "TED-63 Dynamite", "Other"
            }}}
        Public Shared Function getCategoriesAndItemsDictionary_Sorted()
            Dim sortedDict = categoriesAndItemsDictionary.OrderBy(Function(entry) entry.Key).ToDictionary(Function(entry) entry.Key, Function(entry) entry.Value.OrderBy(Function(item) item).ToList())
            Return sortedDict
        End Function

        Public Shared Function GetCategoryForItem(selectedItem As String) As List(Of String)
            Dim matchingCategories As New List(Of String)
            ' Iterate through the categoriesAndItemsDictionary to find the selected item
            For Each category As KeyValuePair(Of String, List(Of String)) In categoriesAndItemsDictionary
                If category.Value.Contains(selectedItem) Then
                    Select Case category.Key
                        Case "Other"
                            matchingCategories.AddRange({"Armor Both Bodies", "Armor Brawny Body", "Armor Lean Body",
                                                         "Audio", "Automaton Audio", "Automaton Skin", "Cape", "Helmet",
                                                         "Illuminate Audio", "Illuminate Skin", "Player Card",
                                                         "Other", "Stratagem Audio", "Stratagem Skin", "Terminid Audio",
                                                         "Terminid Skin", "Visual", "Weapon Audio", "Weapon Skin"})
                        Case "Armor_And_Helmet"
                            matchingCategories.AddRange({"Armor Both Bodies", "Armor Brawny Body", "Armor Lean Body", "Helmet"})
                        Case "Audio"
                            matchingCategories.AddRange({"Audio"})
                        Case "Automaton_Skin_And_Audio"
                            matchingCategories.AddRange({"Automaton Audio", "Automaton Skin"})
                        Case "Cape"
                            matchingCategories.AddRange({"Cape"})
                        Case "Illuminate_Skin_And_Audio"
                            matchingCategories.AddRange({"Illuminate Audio", "Illuminate Skin"})
                        Case "Player_Card"
                            matchingCategories.AddRange({"Player Card"})
                        Case "Stratagem_Skin_And_Audio"
                            matchingCategories.AddRange({"Stratagem Audio", "Stratagem Skin"})
                        Case "Terminid_Skin_And_Audio"
                            matchingCategories.AddRange({"Terminid Audio", "Terminid Skin"})
                        Case "Visual"
                            matchingCategories.AddRange({"Visual"})
                        Case "Weapon_Skin_And_Audio"
                            matchingCategories.AddRange({"Weapon Audio", "Weapon Skin"})
                        Case Else
                            matchingCategories.Add(category.Key) ' Use the default category name if no specific case matches
                    End Select
                End If
            Next
            ' If no matches are found, default to "Other"
            If matchingCategories.Count = 0 Then
                matchingCategories.Add("Other")
            End If
            Return matchingCategories
        End Function
    End Class

    Public Class ModRandomizer
        Public Shared Sub RandomizeMods(randomizationMode As String, allModsOriginalDictionary As Dictionary(Of String, Class1.ModInfo),
                                        UnusedMods_DataGridView As DataGridView, UsedMods_DataGridView As DataGridView)
            Select Case randomizationMode
                Case "OnlyAddNoGuarantee"
                    Dim unusedModsInProfileDictionary As New Dictionary(Of String, Class1.ModInfo)()
                    For Each row As DataGridViewRow In UnusedMods_DataGridView.Rows
                        Dim tempModFolderPathName As String = row.Cells("UnusedMods_DataGridView_ModFolderPathName_Column").Value.ToString()
                        Dim tempModName As String = row.Cells("UnusedMods_DataGridView_ModName_Column").Value.ToString()
                        Dim tempItem As String = row.Cells("UnusedMods_DataGridView_Item_Column").Value.ToString()
                        Dim tempCategory As String = row.Cells("UnusedMods_DataGridView_Category_Column").Value.ToString()
                        Dim tempDescription As String = row.Cells("UnusedMods_DataGridView_Description_Column").Value.ToString()
                        Dim tempImagePath As String = row.Cells("UnusedMods_DataGridView_ImagePath_Column").Value.ToString()
                        Dim tempDateAdded As String = row.Cells("UnusedMods_DataGridView_DateAdded_Column").Value.ToString()
                        Dim tempModVersion As String = row.Cells("UnusedMods_DataGridView_ModVersion_Column").Value.ToString()
                        Dim tempModLink As String = row.Cells("UnusedMods_DataGridView_ModLink_Column").Value.ToString()
                        Dim tempModInfo As New Class1.ModInfo(tempModFolderPathName, tempModName, tempItem, tempCategory, tempDescription,
                                                                tempImagePath, tempDateAdded, tempModVersion, tempModLink)
                        unusedModsInProfileDictionary.Add(tempModFolderPathName, tempModInfo)
                    Next
                    UnusedMods_DataGridView.Rows.Clear()
                    Dim random As New Random()
                    Dim totalUnusedModsCount As Integer = unusedModsInProfileDictionary.Count
                    Dim usedModsCount As Integer = random.Next(0, totalUnusedModsCount + 1)
                    Dim modKeys As List(Of String) = unusedModsInProfileDictionary.Keys.ToList()
                    modKeys = modKeys.OrderBy(Function(x) random.Next()).ToList()
                    For i As Integer = 0 To usedModsCount - 1
                        Dim modFolderPathName As String = modKeys(i)
                        Dim tempModInfo As Class1.ModInfo = unusedModsInProfileDictionary(modFolderPathName)
                        Class1.Mods_DataGridView_Editor.AddModInfoToDataGridView(tempModInfo, UsedMods_DataGridView)
                    Next
                    For i As Integer = usedModsCount To totalUnusedModsCount - 1
                        Dim modFolderPathName As String = modKeys(i)
                        Dim tempModInfo As Class1.ModInfo = unusedModsInProfileDictionary(modFolderPathName)
                        Class1.Mods_DataGridView_Editor.AddModInfoToDataGridView(tempModInfo, UnusedMods_DataGridView)
                    Next

                Case "OnlyAddGuaranteeOne"
                    Dim random As New Random()
                    Dim uniqueMods As List(Of Class1.ModInfo) = ModRandomizer.SelectUniqueMods(allModsOriginalDictionary)
                    Dim existingCombinations As New HashSet(Of String)()
                    For Each row As DataGridViewRow In UsedMods_DataGridView.Rows
                        Dim item As String = row.Cells("UsedMods_DataGridView_Item_Column").Value.ToString()
                        Dim category As String = row.Cells("UsedMods_DataGridView_Category_Column").Value.ToString()
                        existingCombinations.Add($"{item}_{category}")
                    Next
                    For Each modInfo In uniqueMods
                        Dim combinationKey As String = $"{modInfo.Item}_{modInfo.Category}"
                        Dim isCombinationInUsed As Boolean = existingCombinations.Contains(combinationKey)
                        If Not isCombinationInUsed Then
                            Class1.Mods_DataGridView_Editor.AddModInfoToDataGridView(modInfo, UsedMods_DataGridView)
                            existingCombinations.Add(combinationKey)
                            For Each unusedRow As DataGridViewRow In UnusedMods_DataGridView.Rows
                                Dim unusedItem As String = unusedRow.Cells("UnusedMods_DataGridView_Item_Column").Value.ToString()
                                Dim unusedCategory As String = unusedRow.Cells("UnusedMods_DataGridView_Category_Column").Value.ToString()
                                If unusedItem = modInfo.Item AndAlso unusedCategory = modInfo.Category Then
                                    UnusedMods_DataGridView.Rows.Remove(unusedRow)
                                    Exit For
                                End If
                            Next
                        End If
                    Next
                    For Each modFolderPathName As String In allModsOriginalDictionary.Keys
                        Dim tempModInfo As ModInfo = allModsOriginalDictionary(modFolderPathName)
                        Dim combinationKey As String = $"{tempModInfo.Item}_{tempModInfo.Category}"
                        If Not existingCombinations.Contains(combinationKey) Then
                            Class1.Mods_DataGridView_Editor.AddModInfoToDataGridView(tempModInfo, UnusedMods_DataGridView)
                            existingCombinations.Add(combinationKey)
                        End If
                    Next

                Case "AddRemoveNoGuarantee"
                    UnusedMods_DataGridView.Rows.Clear()
                    UsedMods_DataGridView.Rows.Clear()

                    Dim random As New Random()
                    Dim totalModsCount As Integer = allModsOriginalDictionary.Count
                    Dim usedModsCount As Integer = random.Next(0, totalModsCount + 1)
                    Dim unusedModsCount As Integer = totalModsCount - usedModsCount
                    Dim modKeys As List(Of String) = allModsOriginalDictionary.Keys.ToList()
                    modKeys = modKeys.OrderBy(Function(x) random.Next()).ToList()
                    For i As Integer = 0 To usedModsCount - 1
                        Dim modFolderPathName As String = modKeys(i)
                        Dim tempModInfo As ModInfo = allModsOriginalDictionary(modFolderPathName)
                        Class1.Mods_DataGridView_Editor.AddModInfoToDataGridView(tempModInfo, UsedMods_DataGridView)
                    Next
                    For i As Integer = usedModsCount To totalModsCount - 1
                        Dim modFolderPathName As String = modKeys(i)
                        Dim tempModInfo As ModInfo = allModsOriginalDictionary(modFolderPathName)
                        Class1.Mods_DataGridView_Editor.AddModInfoToDataGridView(tempModInfo, UnusedMods_DataGridView)
                    Next

                Case "AddRemoveGuaranteeOne"
                    UnusedMods_DataGridView.Rows.Clear()
                    UsedMods_DataGridView.Rows.Clear()
                    Dim uniqueMods As List(Of Class1.ModInfo) = ModRandomizer.SelectUniqueMods(allModsOriginalDictionary)
                    Dim totalModsCount As Integer = allModsOriginalDictionary.Count
                    For i As Integer = 0 To uniqueMods.Count - 1
                        Dim tempModInfo As ModInfo = uniqueMods(i)
                        Class1.Mods_DataGridView_Editor.AddModInfoToDataGridView(tempModInfo, UsedMods_DataGridView)
                    Next
                    For i As Integer = 0 To totalModsCount - 1
                        Dim modFolderPathName As String = allModsOriginalDictionary.Keys(i)
                        Dim tempModInfo As ModInfo = allModsOriginalDictionary(modFolderPathName)
                        If Not uniqueMods.Any(Function(m) m.Modfolderpathname = tempModInfo.Modfolderpathname) Then
                            Class1.Mods_DataGridView_Editor.AddModInfoToDataGridView(tempModInfo, UnusedMods_DataGridView)
                        End If
                    Next
            End Select
        End Sub

        Public Shared Function SelectUniqueMods(allModsOriginalDictionary As Dictionary(Of String, Class1.ModInfo))
            Dim uniqueMods As New List(Of Class1.ModInfo)()
            Dim groupedMods = allModsOriginalDictionary.Values _
                                .GroupBy(Function(modInfo) New With {Key .Item = modInfo.Item, Key .Category = modInfo.Category})
            For Each group In groupedMods
                If group.Count() = 1 Then
                    uniqueMods.Add(group.First())
                Else
                    Dim random As New Random()
                    Dim randomMod = group(random.Next(group.Count()))
                    uniqueMods.Add(randomMod)
                End If
            Next
            Return uniqueMods
        End Function
    End Class
End Class
