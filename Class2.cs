using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Documents;

namespace phd2mm_wpf
{
    class Class2
    {
        public class CategoryAndItemsManager
        {
            // Dictionary holding categories and their respective items
            public static Dictionary<string, List<string>> CategoriesAndItemsDictionary = new Dictionary<string, List<string>>()
            {
            {"Armor_And_Helmet", new List<string> {
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
                "RE-1861 Parade Commander", "RE-2310 Honorary Guard", "RE-824 Bearer of the Standard",
                "Other"
            }},
            {"Audio", new List<string> {
                "Flag Raise", "Descent", "Terminal", "Extraction", "Hellbomb", "Eagle-1",
                "Pelican-1", "ICBM", "Mission Control", "Helldiver Voice 1", "Helldiver Voice 2",
                "Helldiver Voice 3", "Helldiver Voice 4", "Ship Map Music", "Death - Team", "Death - Yours",
                "Ambient", "Ship PA System", "Democracy Officer", "Stim", "Experimental Infusion",
                "Automaton Chant", "Automaton Music", "Illuminate Music", "Ship Music", "Ship",
                "Stratagem Input", "Terminid Music", "Music Pack", "Democracy Space Station", "Other"
            }},
            {"Automaton_Skin_And_Audio", new List<string> {
                "Trooper", "Brawler", "Marauder", "MG Raider", "Rocket Raider", "Commissar",
                "Scout Strider", "Reinforced Scout Strider", "Berserker", "Devastator",
                "Rocket Devastator", "Heavy Devastator", "Hulk", "Gunship", "Bunker Turret",
                "Cannon Turret", "Annihilator Tank", "Shredder Tank", "Barrager Tank",
                "Factory Strider", "Dropship", "Assault Raider", "Conflagration Devastator",
                "Hulk Firebomber", "Incendiary MG Devastator", "Incendiary Rocket Devastator",
                "Pyro Trooper", "Other"
            }},
            {"Cape", new List<string> {
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
                "Way of the Bandolier", "Humble Regalia", "Federation's Embrace",
                "Seal of the General Consensus",
                "Other"
            }},
            {"Illuminate_Skin_And_Audio", new List<string> {
                "Voteless", "Watcher", "Overseer", "Elevated Overseer", "Harvester",
                "Warp Ship", "Stingray", "Crescent Overseer", "Fleshmob",
                "Other"
            }},
            {"Other", new List<string> {
                "Other"
            }},
            {"Player_Card", new List<string> {
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
                "Humble Regalia", "Federation's Embrace", "Seal of the General Consensus",
                "Other"
            }},
            {"Stratagem_Skin_And_Audio", new List<string> {
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
                "CQC-1 One True Flag",
                "Other"
            }},
            {"Terminid_Skin_And_Audio", new List<string> {
                "Scavenger", "Spore Burst Scavenger", "Bile Spitter", "Pouncer", "Hunter",
                "Predator Hunter", "Spore Burst Hunter", "Warrior", "Bile Warrior", "Alpha Warrior",
                "Spore Burst Warrior", "Hive Guard", "Brood Commander", "Alpha Commander", "Stalker",
                "Predator Stalker", "Shrieker", "Bile Spewer", "Nursing Spewer", "Charger",
                "Charger Behemoth", "Spore Charger", "Impaler", "Bile Titan", "Other"
            }},
            {"Skin", new List<string> {
                "Ship", "Title", "Icons", "Loading Screen", "Democracy Officer", "Eagle-1", "Pelican-1",
                "Ship Interior", "Democracy Space Station", "Other"
            }},
            {"Weapon_Skin_And_Audio", new List<string> {
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
                "TED-63 Dynamite", "R-2 Amendment", "CQC-2 Sabre", "G-142 Pyrotech",
                "Other"
            }}
            };

            // Function to return a sorted dictionary of categories and items
            public static Dictionary<string, List<string>> GetCategoriesAndItemsDictionarySorted()
            {
                // Sorting the dictionary by key and sorting the items list within each category
                var sortedDict = CategoriesAndItemsDictionary
                    .OrderBy(entry => entry.Key)
                    .ToDictionary(
                        entry => entry.Key,
                        entry => entry.Value.OrderBy(item => item).ToList()
                    );
                return sortedDict;
            }

            // Use this function for filling the Item ComboBox Column in both UnusedMods_DataGrid and UsedMods_DataGrid
            public static ObservableCollection<string> GetCategoriesAndItemsUniqueAndSortedItems()
            {
                // Flatten the dictionary, get all items, ensure uniqueness, and sort them alphabetically
                var uniqueSortedItems = CategoriesAndItemsDictionary
                    .SelectMany(entry => entry.Value)  // Flatten the list of items from all categories
                    .Distinct()                        // Ensure uniqueness
                    .OrderBy(item => item)             // Sort the items alphabetically
                    .ToList();                         // Convert to a list
                return new ObservableCollection<string>(uniqueSortedItems);
            }

            public static List<string> GetCategoryForItem(string selectedItem)
            {
                var matchingCategories = new List<string>();

                // Iterate through the dictionary to find categories that match the item
                foreach (var category in Class2.CategoryAndItemsManager.GetCategoriesAndItemsDictionarySorted())
                {
                    if (category.Value.Contains(selectedItem))
                    {
                        // Switch case to handle different categories, similar to your VB code
                        switch (category.Key)
                        {
                            case "Armor_And_Helmet":
                                matchingCategories.AddRange(new string[]
                                {"Armor Both Bodies", "Armor Brawny Body", "Armor Lean Body", "Helmet"
                                });
                                break;
                            case "Audio":
                                matchingCategories.Add("Audio");
                                break;
                            case "Automaton_Skin_And_Audio":
                                matchingCategories.AddRange(new string[] { "Automaton Audio", "Automaton Skin" });
                                break;
                            case "Cape":
                                matchingCategories.Add("Cape");
                                break;
                            case "Illuminate_Skin_And_Audio":
                                matchingCategories.AddRange(new string[] { "Illuminate Audio", "Illuminate Skin" });
                                break;
                            case "Player_Card":
                                matchingCategories.Add("Player Card");
                                break;
                            case "Stratagem_Skin_And_Audio":
                                matchingCategories.AddRange(new string[] { "Stratagem Audio", "Stratagem Skin" });
                                break;
                            case "Terminid_Skin_And_Audio":
                                matchingCategories.AddRange(new string[] { "Terminid Audio", "Terminid Skin" });
                                break;
                            case "Skin":
                                matchingCategories.Add("Skin");
                                break;
                            case "Weapon_Skin_And_Audio":
                                matchingCategories.AddRange(new string[] { "Weapon Audio", "Weapon Skin" });
                                break;
                            default:
                                matchingCategories.Add(category.Key); // Default to category name if no specific case matches
                                break;
                        }
                    }
                }
                // If no matches are found, default to "Other"
                if (matchingCategories.Count == 0)
                {
                    matchingCategories.Add("Other");
                }
                // Sort the matching categories alphabetically in case of multiple matches like Item value "Other".
                matchingCategories.Sort();
                return matchingCategories;
            }
        }

        public class ModRandomizer
        {
            public static void RandomizeMods(string randomizationMode, Dictionary<string, Class1.ModInfo> allModsOriginalDictionary,
                                              ObservableCollection<Class1.ModInfo> UnusedMods_DataGrid_ObservableCollection,
                                              ObservableCollection<Class1.ModInfo> UsedMods_DataGrid_ObservableCollection)
            {
                var random = new Random();
                switch (randomizationMode)
                {
                    case "OnlyAddNoGuarantee":
                        var unusedModsInProfileDictionary = new Dictionary<string, Class1.ModInfo>();
                        foreach (var modInfo in UnusedMods_DataGrid_ObservableCollection)
                        {
                            unusedModsInProfileDictionary.Add(modInfo.ModFolderPathName, modInfo);
                        }
                        UnusedMods_DataGrid_ObservableCollection.Clear();
                        var totalUnusedModsCount = unusedModsInProfileDictionary.Count;
                        var usedModsCount = random.Next(0, totalUnusedModsCount + 1);
                        var modKeys = unusedModsInProfileDictionary.Keys.ToList();
                        modKeys = modKeys.OrderBy(x => random.Next()).ToList();
                        for (int i = 0; i < usedModsCount; i++)
                        {
                            var modFolderPathName = modKeys[i];
                            var tempModInfo = unusedModsInProfileDictionary[modFolderPathName];
                            UsedMods_DataGrid_ObservableCollection.Add(tempModInfo);
                        }
                        for (int i = usedModsCount; i < totalUnusedModsCount; i++)
                        {
                            var modFolderPathName = modKeys[i];
                            var tempModInfo = unusedModsInProfileDictionary[modFolderPathName];
                            UnusedMods_DataGrid_ObservableCollection.Add(tempModInfo);
                        }
                        break;

                    case "OnlyAddGuaranteeOne":
                        var uniqueMods = SelectUniqueMods(allModsOriginalDictionary);
                        var existingCombinations = new HashSet<string>();
                        foreach (var modInfo in UsedMods_DataGrid_ObservableCollection)
                        {
                            var combinationKey = $"{modInfo.Item}_{modInfo.Category}";
                            existingCombinations.Add(combinationKey);
                        }
                        foreach (var modInfo in uniqueMods)
                        {
                            var combinationKey = $"{modInfo.Item}_{modInfo.Category}";
                            if (!existingCombinations.Contains(combinationKey))
                            {
                                UsedMods_DataGrid_ObservableCollection.Add(modInfo);
                                existingCombinations.Add(combinationKey);
                                var modToRemove = UnusedMods_DataGrid_ObservableCollection
                                    .FirstOrDefault(u => u.Item == modInfo.Item && u.Category == modInfo.Category);
                                if (modToRemove != null)
                                {
                                    UnusedMods_DataGrid_ObservableCollection.Remove(modToRemove);
                                }
                            }
                        }
                        foreach (var modInfo in allModsOriginalDictionary.Values)
                        {
                            var combinationKey = $"{modInfo.Item}_{modInfo.Category}";
                            if (!existingCombinations.Contains(combinationKey))
                            {
                                UnusedMods_DataGrid_ObservableCollection.Add(modInfo);
                                existingCombinations.Add(combinationKey);
                            }
                        }
                        break;

                    case "AddRemoveNoGuarantee":
                        UnusedMods_DataGrid_ObservableCollection.Clear();
                        UsedMods_DataGrid_ObservableCollection.Clear();
                        var totalModsCount = allModsOriginalDictionary.Count;
                        var usedModsCount2 = random.Next(0, totalModsCount + 1);
                        var unusedModsCount = totalModsCount - usedModsCount2;
                        var modKeysAll = allModsOriginalDictionary.Keys.ToList();
                        modKeysAll = modKeysAll.OrderBy(x => random.Next()).ToList();
                        for (int i = 0; i < usedModsCount2; i++)
                        {
                            var modFolderPathName = modKeysAll[i];
                            var tempModInfo = allModsOriginalDictionary[modFolderPathName];
                            UsedMods_DataGrid_ObservableCollection.Add(tempModInfo);
                        }
                        for (int i = usedModsCount2; i < totalModsCount; i++)
                        {
                            var modFolderPathName = modKeysAll[i];
                            var tempModInfo = allModsOriginalDictionary[modFolderPathName];
                            UnusedMods_DataGrid_ObservableCollection.Add(tempModInfo);
                        }
                        break;
                    case "AddRemoveGuaranteeOne":
                        UnusedMods_DataGrid_ObservableCollection.Clear();
                        UsedMods_DataGrid_ObservableCollection.Clear();
                        var uniqueModsForGuaranteeOne = SelectUniqueMods(allModsOriginalDictionary);
                        foreach (var modInfo in uniqueModsForGuaranteeOne)
                        {
                            UsedMods_DataGrid_ObservableCollection.Add(modInfo);
                        }
                        foreach (var modInfo in allModsOriginalDictionary.Values)
                        {
                            if (!uniqueModsForGuaranteeOne.Contains(modInfo))
                            {
                                UnusedMods_DataGrid_ObservableCollection.Add(modInfo);
                            }
                        }
                        break;
                }
            }
            public static List<Class1.ModInfo> SelectUniqueMods(Dictionary<string, Class1.ModInfo> allModsOriginalDictionary)
            {
                var uniqueMods = new List<Class1.ModInfo>();
                var groupedMods = allModsOriginalDictionary.Values
                    .GroupBy(modInfo => new { modInfo.Item, modInfo.Category });
                foreach (var group in groupedMods)
                {
                    if (group.Count() == 1)
                    {
                        uniqueMods.Add(group.First());
                    }
                    else
                    {
                        var random = new Random();
                        var randomMod = group.ElementAt(random.Next(group.Count()));
                        uniqueMods.Add(randomMod);
                    }
                }
                return uniqueMods;
            }
        }

        public static class MoreInfoTexts
        {
            public static void SetMoreInfoTexts(TextBox MoreInfo_AppInfo_TextBox, TextBox MoreInfo_ThemeManagerInfo_TextBox,
                TextBox MoreInfo_Changelogs_TextBox, TextBox MoreInfo_Credits_TextBox)
            {
                MoreInfo_AppInfo_TextBox.Text = MoreInfo_AppInfo;
                MoreInfo_ThemeManagerInfo_TextBox.Text = MoreInfo_ThemeManagerInfo;
                MoreInfo_Changelogs_TextBox.Text = MoreInfo_Changelogs_AllVersions;
                MoreInfo_Credits_TextBox.Text = MoreInfo_Credits;
            }

            public static string MoreInfo_AppInfo =
                "Table of Contents\n" +
                "1. Introduction\n" +
                "2. Adding your Mods to the Mod Manager\n" +
                "3. Browsing your Helldivers 2 Data Directory\n" +
                "4. Profile Management\n" +
                "5. Mod and Profile Management\n" +
                "6. Mod Installation\n" +
                "7. Other Features\n" +
                "\n" +
                "1. Introduction\n" +
                "Thank you for downloading Personal Helldivers 2 Mod Manager (phd2mm)!\n" +
                "Please be aware that this is a simple, experimental mod manager.\n"+
                "You may also have to debug or fix problems yourself because I only did little testing on this program.\n" +
                "Depending on the problem, you may have to edit phd2mm_registry.json, phd2mm_settings.json, or any of the theme.json files.\n" +
                "Worst case scenario, you may have to delete 1 or more of these files to allow fresh files to be created.\n" +
                "Always make sure to back up your files before attempting any fixes.\n" +
                "This program will always do a fresh reinstall of mods, meaning your old mods in the Helldivers 2 data folder will be deleted " +
                "and only then will new mods be added to it.\n" +
                "This is to ensure that the mods are installed correctly and to avoid any conflicts with old mods.\n" +
                "\n" +
                "2. Adding your Mods to the Mod Manager\n" +
                "First, run then exit program. When you run the program, the following folders and files will be created:\n" +
                "1. phd2mm_mods folder (empty upon fresh download and start)\n" +
                "2. phd2mm_mods_profiles folder (has default.txt inside upon fresh download and start)\n" +
                "3. phd2mm_themes.json (empty upon fresh download and start)\n" +
                "4. phd2mm_settings folder (has phd2mm_registry.json and phd2mm_settings.json inside upon fresh download and start)\n" +
                "Once you run and exit the program, put your mods in the phd2mm_mods folder.\n" +
                "The format of the mods should be:\n" +
                "1. Each mod should have its own folder.\n" +
                "2. No duplicate names and patches, for example, if a mod folder has 9ba626afa44a3aa3.patch_0 and 9ba626afa44a3aa3.patch_1, " +
                "then it will not be correctly installed. If it has 9ba626afa44a3aa3.patch_0 and 9ba626afa44a3aa3.patch_0.gpu_resources, then it will be correctly installed.\n" +
                "3. Different names will work, assuming it is a valid mod file, for example, 22749a294788af66.patch_0 and e72d3e9b05c3db0b.patch_0 in the same folder " +
                "will be correctly installed.\n" +
                "The app will then find the folders that contain .patch_ files. Any images included in those folders will be displayed in the app.\n" +
                "However, the app will only get the first valid image in alphabetical order.\n" +
                "The supported image file types are: *.jpg, *.jpeg, *.png, *.bmp, and *.gif.\n" +
                "The app will prioritize data from phd2mm_mods\\phd2mm_registry.json file, so that means for example, if you added an image after " +
                "the app already added the mod folder to the phd2mm_registry.json file, then the app won't detect the newly added image.\n" +
                "Either manually add the image path to the phd2mm_registry.json file, delete the entire entry for that mod in the phd2mm_registry.json file, " +
                "or delete the entire phd2mm_registry.json file. Backup your phd2mm_registry.json file before attempting any fixes.\n" +
                "\n" +
                "3. Browsing your Helldivers 2 Data Directory\n" +
                "Find and select your Helldivers 2 data folder by clicking the \"Settings\" tab near the top of the screen.\n" +
                "Then either click the \"Browse\" button and go to your Helldivers 2 data folder or manually enter the Helldivers 2 data folder path " +
                "in the text box next to the \"Browse\" button.\n" +
                "The app will check if the path to said directory has \"Helldivers 2\\data\" in it.\n" +
                "If Helldivers 2 was bought from Steam, then the path should be: \"YourSteamPath\\Steam\\steamapps\\common\\Helldivers 2\\data\"\n" +
                "\n" +
                "4. Profile Management\n" +
                "Each profile contains mods that are used together. It is similar to a mod list.\n" +
                "If you do not have any profile, a profile named \"default\" will automatically be created for you. " +
                "Otherwise, create or choose a profile by clicking the \"Create Profile\" button.\n" +
                "The profile data will be saved in phd2mm_profiles\\ <your_profile_name_here>.txt. This text file contains the mod list saved in the profile.\n" +
                "However, you cannot create a profile with the following characters: \\/:*?\"<>|\n" +
                "That is because when creating a profile, it also creates the file name the same as the profile name. In Windows at least, " +
                "these characters cannot be used as file names.\n" +
                "You also cannot create a profile that are named the following:\n" +
                "CON, PRN, AUX, NUL, COM1, COM2, COM3, COM4, COM5, COM6, COM7, COM8, COM9, LPT1, LPT2, LPT3, LPT4, LPT5, LPT6, LPT7, LPT8, LPT9\n" +
                "That is because these are reserved names for Windows files. However, you can still use, for example, CON1 or afdsPRNadsf. " +
                "The important thing is its not just CON or the like as your profile name.\n" +
                "\n" +
                "5. Mod and Profile Management\n" +
                "You can now add any mod to the profile by:\n" +
                "1. Selecting any row or mod in the \"Mods not used in the profile\" then clicking the \"Add Selected Mod\" button or;\n" +
                "2. Simply double left mouse button click the Mod Folder Path + Name of a mod.\n" +
                "Doing either of these options will transfer the mod from the left table to the right table, the \"Mods used in the profile\", " +
                "meaning the mod is now currently in use.\n" +
                "To remove a mod from the profile:\n" +
                "1. Selecting any row or mod in the \"Mods used in the profile\" then clicking the \"Remove Selected Mod\" button or;\n" +
                "2. Simply double left mouse button click the Mod Folder Path + Name of a mod.\n" +
                "Doing either of these options will transfer the mod from the right table to the left table, the \"Mods not used in the profile\", " +
                "meaning the mod is no longer in use.\n" +

                "You can rearrange the mod list order under \"Mods used in this profile\" by:\n" +
                "1. Selecting a mod in the right side then click the \"Move Up Selected Mod\" or \"Move Down Selected Mod\" buttons;\n" +
                "2. By dragging the leftmost box of a mod in the right side then drop them wherever in the mod list, or;\n" +
                "3. By editing the \"#\" or Mod Order Number column.\n" +
                "No matter the selection or sort, the mod list will be rearranged accordingly. Meaning it will always be sorted from top to bottom.\n" +
                "\n" +
                "Remember to save your profile by clicking the \"Save Profile\" button or else the mod list will not be saved.\n" +
                "You can duplicate your currently selected profile by clicking the \"Duplicate Profile\" button.\n" +
                "You can also delete your currently selected profile by clicking \"Delete Profile\" button.\n" +
                "However, you cannot delete a profile if there's only 1 profile left.\n" +
                "\n" +
                "6. Mod Installation\n" +
                "When you're done with choosing your mods and saving the profile, click the \"Install All Mods from Current Profile\" button.\n" +
                "If you changed the contents and order of the mod list but you did not save it, it is possible to install the modified-yet-unsaved mod list anyway. " +
                "However, it is recommended to save the profile first before installing.\n" +
                "WARNING: This will delete all the mods you have installed in the Helldivers 2 data folder.\n" +
                "After that, it will put the mods there. Basically, this button will always do a clean reinstall of mods to make it easier to install mods.\n" +
                "To be extra sure, you can also click the \"Delete All Installed Mods\" button to uninstall all old mods before installing the new mods.\n" +
                "\n" +
                "7. Other Features\n" +
                "7.1 Columns: There are 10 columns in total. These are:\n" +
                "7.1.1. Order: The mod order number of the mod. This is the order in which the mod will be installed.\n" +
                "Can be edited inside the app.\n" +
                "7.1.2. Mod Folder Path + Name: This is the path to the mod folder and the name of the mod.\n" +
                "Cannot be edited inside the app, but you can change it by editing the phd2mm_registry.txt file.\n" +
                "7.1.3. Name: The name of the mod. \n" +
                "Placeholder, can be edited.\n" +
                "7.1.4. Item: The in-game item that the mod replaces.\n" +
                "Can be edited.\n" +
                "7.1.5. Category: The category of the in-game item.\n" +
                "Can be edited.\n" +
                "7.1.6. Description: The description of the mod.\n" +
                "Placeholder, can be edited.\n" +
                "7.1.7. Image: The image of the mod. The displayed image is located inside the Mod Folder Path + Name folder. " +
                "The app will automatically use the first valid image file in alphabetical order from that folder. " +
                "The supported image file types are: *.jpg, *.jpeg, *.png, *.bmp, and *.gif.\n" +
                "Cannot be edited.\n" +
                "7.1.8 Date Added: The date the mod was added to the mod manager.\n" +
                "Cannot be edited.\n" +
                "7.1.9. Version: The version of the mod.\n" +
                "Placeholder, can be edited.\n" +
                "7.1.10. Link: The link to the mod's website page.\n" +
                "Placeholder, can be edited.\n" +
                "7.2. Search Mod: You can search for mods by typing in the search bar. It will filter the mods in both sides.\n" +
                "7.3. Delete All Installed Mods: You can delete all installed mods in the Helldivers 2 data folder by clicking " +
                "the \"Delete All Installed Mods\" button.\n" +
                "7.4. Resize Columns: You can resize the columns by dragging the column headers.\n" +
                "7.5. Rearrange Columns: You can rearrange the columns by dragging the column headers.\n" +
                "7.6. Edit Values of Certain Columns: You can edit the Item, Category, Description, Version, and Link columns by double-clicking the cell you want to edit, " +
                "choosing from a list of options or typing in the new text, then pressing Enter.\n" +
                "The changes will be saved in phd2mm_settings\\phd2mm_registry.json file.\n" +
                "If not, try exiting the app first to see if the changes are saved in the phd2mm_registry.json.\n" +
                "7.7. Show or Hide Certain Columns: You can right-click any of the column headers (except for the Mod Folder Path + Name column " +
                "and the Order / Mod Order Number column) to show or hide the columns.\n" +
                "7.8. Image Hover: You can hover over an image in the Image column to see a larger preview (around 512x512 resolution) of the mod.\n" +
                "7.9. Open Mod Folder: Right-click any mod to open a menu then click the \"Open Mod Folder\" option. This will open the folder " +
                "of the selected mod.\n" +
                "7.10. Open Mod Link in your Default Browser: Right-click any mod to open a menu then click the \"Open Mod Link in your Default Browser\" option. " +
                "This will open the selected mod's link in your default browser.\n" +
                "7.11. Mod Randomization: The mod randomization options are located in the \"Settings\" tab. You can activate this feature by clicking the " +
                "\"Randomize Mods\" button.\n" +
                "WARNING: This simple mod randomization does not take mod conflicts into account.\n" +
                "7.12. Theme Manager: Located in the \"Theme Manager\" tab. To know more, please visit the \"Themes Info\" tab."
                ;

            public static string MoreInfo_ThemeManagerInfo =
                "Table of Contents\n" +
                "1. Theme Management\n" +
                "2. Profile Specific Themes\n" +
                "3. Theme Editing\n" +
                "4. Images\n" +
                "5. Controls\n" +
                "\n" +
                "1. Theme Management\n" +
                "You can create, duplicate, edit, or delete custom themes.\n" +
                "You cannot edit or delete default themes, \"phd2mm_light\" and \"phd2mm_dark\".\n" +
                "If you created a new theme rather than duplicate, then the newly created theme will be based upon the \"phd2mm_light\" theme.\n" +
                "By default, the app starts with the \"phd2mm_light\" theme. You can change this by changing the Global Theme dropdown on the top right or " +
                "by setting a Profile-Specific Theme in the table to the right.\n" +
                "You can see the currently applied theme on the top right, above the Global Theme dropdown.\n" +
                "\n" +
                "2. Profile Specific Themes\n" +
                "The Profile-Specific Theme table contains of 2 columns: Profile and Theme.\n" +
                "The Profile column contains the profile names and the Theme column contains the theme names.\n" +
                "To set a Profile-Specific Theme, simply select a theme from the dropdown next to a profile name.\n" +
                "The Profile-Specific Theme will override the Global Theme.\n" +
                "To remove the Profile-Specific Theme, simply select the blank option in the dropdown.\n" +
                "\n" +
                "3. Theme Editing\n" +
                "To edit a theme, select the theme you want to edit on the left side of the screen.\n" +
                "There are up to 3 colors you can set for each control: Background Color, Text Color, and Border Color.\n" +
                "To set their color, simply click on the color box and a color picker will pop up. You can then set the color through the color picker.\n" +
                "Note: Only the RGBA hex code value (#RRGGBBAA) is saved and used by the app. The color picker is just a tool to help you select a valid hex color.\n" +
                "\n" +
                "4. Images\n" +
                "You can set images in the Mod Manager Tab by going to the Mod Manager General Controls Tab.\n" +
                "The images must be in the phd2mm_themes folder before you can set them, as the app only accepts images from that folder.\n" +
                "There are 4 images you can set: Mod Manager Background Image, Mod Manager Icon Image, Unused Mods Table Background Image, and Used Mods Table Background Image.\n" +
                "1. Mod Manager Background Image is shown behind the entire Mod Manager Tab. " +
                "The default resolution is approximately 1753x884.08.\n" +
                "2. Mod Manager Icon Image is shown in the top right of the Mod Manager Tab. " +
                "The default resolution is approximately 207x109.\n" +
                "3. Unused Mods Table Background Image is shown behind the Unused Mods Table. " +
                "The default resolution is approximately 861x754.42.\n" +
                "4. Used Mods Table Background Image is shown behind the Used Mods Table. " +
                "The default resolution is approximately 861x754.42.\n" +
                "All the images except Icon Image are stretched to fill the available space based on the specified default resolution, which may cause image distortion if " +
                "the uploaded image does not match the the specified default resolution.\n" +
                "Icon Image is stretched to Uniform, meaning it will still fill available space and won't cause distortion, but may leave empty space.\n" +
                "The supported image file types are: *.jpg, *.jpeg, *.png, *.bmp, and *.gif.\n" +
                "To remove the images, you can click the \"Clear\" button or just remove the text in the textbox to the right side of the \"Clear\" button.\n" +
                "\n" +
                "There are 4 tabs: Global General Controls, Global Table Controls, Mod Manager General Controls, and Mod Manager Table Controls\n" +
                "Global General Controls and Global Table Controls are the 2 main tabs. If you want to have a separate color scheme for just the " +
                "Mod Manager Tab, then you can edit the Mod Manager General Controls and Mod Manager Table Controls Tab.\n" +
                "However, if you don't want to edit them separately, just set the colors in Global General Controls and Global Table Controls and then " +
                "do the following:\n" + 
                "Go to the Mod Manager General Controls and click the \"Copy Global General Controls Customization\" button.\n" +
                "Go to the Mod Manager Table Controls and click the \"Copy Global Table Controls\" button for both Unused Mods Table and Used Mods Table.\n" +
                "Doing these will copy the colors from the Global General Controls and Global Table Controls to the Mod Manager General Controls and Mod Manager Table Controls.\n" +
                "\n" +
                "5. Controls\n" +
                "There are many controls whose colors can be customized. Below is a list of these controls and their descriptions.\n" +
                "5.1. Grid: The main area behind everything on the page.\n" +
                "5.2. TabControl: The box containing all the tabs and their contents.\n" +
                "5.3. TabItem: The clickable tabs at the top of the tab area.\nExamples: Mod Manager, Theme Manager, Settings, More Info tabs.\n" +
                "5.4. ComboBox: A box that opens a dropdown list when clicked.\nExamples: Switching Profiles and Global Themes.\n" +
                "5.5. ListBox: A box showing a list of items that you can select.\nExample: In the Theme Manager tab, the theme list in the left side showing all the themes.\n" +
                "5.6. GroupBox: A box containing the StackPanel and RadioButtons.\nExample: In the Settings tab, you can see the box with outline under Mod Randomization Options " +
                "containing the radiobuttons/mod randomization options. The box with the outline is part of GroupBox.\n" +
                "5.7. StackPanel: The box usually inside the GroupBox containing the RadioButtons.\n" +
                "5.8. RadioButton: The text with a round button in the left side, where you can only select one option at a time.\n Example: the 4 choices " +
                "in the Mod Randomization Options that have circles in the left side of the text.\n" +
                "5.9. Button: The clickable button that does something when you click it.\nExamples: Create Profile, Add Selected Mod, Install All Mods from Current Profile, " +
                "Browse, and Save Theme Settings.\n" +
                "5.10. TextBox: The box where you can enter or view text. Usually, the text inside a box. \n Examples: Search mod text box and Theme Manager Info text box.\n" +
                "5.11. Label: The standalone text, usually not inside a box.\nExamples: \"Please select a profile:\", \"Search mod:\", \"Last Installed Profile\", and " +
                "the boldened text \"Theme Manager Info\".\n" +
                "5.12. Hover: The color that changes when you hover over your mouse cursor to anything. Currently, it only applies to a few controls: " +
                "TabItems, ComboBox, List, and Buttons.\n" +
                "5.13. Selected: The color that changes when you select anything. Currently, it only applies to a few controls: " +
                "TabItems, ComboBox, List, and Buttons.\n" +
                "5.14. DataGrid (DG): The table that shows the mods and their information.\n" +
                "5.15. DG Row: A row in the table that shows the mod information. Editing this will change the color of the even-numbered rows.\n" +
                "5.16. DG Alternate Row: Same as DG Row, but editing this will change the color of the odd-numbered rows.\n" +
                "5.17. DG Selected Row: The highlighted row when selected in the table. Similar to Selected, but for rows in the table.\n" +
                "5.18. DG Column Header: The header of the column in the table. Contains texts like Mod Folder Path + Name, Category, and Date Added.\n" +
                "5.19. DG Sort Arrow: The arrow that shows the sorting direction of the column. Usually appears when you sort a column alphabetically by ascending or descending order.\n"
                ;

            public static string MoreInfo_Changelogs_v1_5 =
                "v1.5\n" +
                "-Migrated app framework from WinForms to WPF.\n" +
                "Mod Manager and More Info tabs now resize depending on the window size. Note: may not properly work on resolutions below 1770x950.\n" +
                "-Replaced \"Visual\" Category with \"Skin\" Category for consistency.\n" +
                "WARNING: app may not work properly if your phd2mm_registry.json contains \"Visual\" Category, " +
                "please replace them with \"Skin\" first before launching the app.\n" +
                "-Removed \"Ship TV\" Item from Category \"Audio\".\n" +
                "-Added \"Ship\", \"Music Pack\" and \"Democracy Space Station\" Items in Category \"Audio\".\n" +
                "-Added \"Ship Interior\" and \"Democracy Space Station\" Item in Category \"Visual\".\n" +
                "-Removed row header (the leftmost cell in the row, which is just a square without text) from both DataGrids/Tables.\n" +
                "You can now just double-click the cell that belongs to the Mod Folder Path + Name column to add or remove mods. " +
                "To rearrange mod load order in Used Mods Table using drag and drop, you can just drag and drop the cell that belongs to " +
                "the Mod Folder Path + Name column.\n" +
                "Added feature: Image column now works. \n" +
                "The app will now get the first valid image found in alphabetical order from a mod's folder.\n" +
                "Assuming the mod image path is valid and the image file type is supported, " +
                "the image column will show a small image preview (48x48 size resolution) of the mod. " +
                "You can also hover your mouse cursor over the image to see a larger preview of the image (512x512 size resolution or close to it). " +
                "The supported image file types are: *.jpg, *.jpeg, *.png, *.bmp, and *.gif.\n" +
                "Added feature: Right-click on a mod to open its folder or visit its link using your default browser.\n" +
                "Removed feature: \"Enable Mod Randomization button\". Now, you simply click the \"Randomly Add and Remove Mods\" button to randomize your mods. " +
                "A warning message will pop up to confirm if you want to randomize your mods or not.\n" +
                "-Drag and drop feature now selects the entire row upon dragging and dropping the mod in Used Tables.\n" +
                "-Added more customization options for Themes, including more images, alpha/transparency options, and color picker feature. " +
                "Please see Themes Info tab for more details.\n" +
                "-Added Prism Launcher Team, PixiEditor ColorPicker Team, and WPF to Credits.\n" +
                "-Added MIT License for PixiEditor ColorPicker.\n" +
                "-Added Items from Warbond \"Masters of Ceremony\".\n" +
                "-Added new Illuminate enemies to Items.\n"
                ;

            public static string MoreInfo_Changelogs_v1_4 =
                "v1.4\n" +
                "-Redesigned UI.\n" +
                "-Added columns: Name, Version, Image, Date Added, and Link.\n" +
                "Previously, it was just Mod Folder Path + Name, Item, Category, and Description columns.\n" +
                "Now, the columns in order, are Mod Folder Path + Name, Name, Item, Category, Description, Image, Date Added, Version, and Link.\n" +
                "However, image display in the Image column is not implemented, so it's hidden by default.\n" +
                "-Clarified mod randomization options.\n" +
                "-Added tab pages to the mod. As a result, 2 windows have been relocated into tabs.\n" +
                "1. The \"More Info\" button has been removed, its contents are now found in the \"More Info\" tab.\n" +
                "2. The \"Mod Randomization Option\" button has been removed, its contents are now found in the \"Settings\" tab.\n" +
                "-Browsing your Helldivers 2 data folder path is now in the \"Settings\" tab.\n" +
                "-Changed settings.txt file with settings.json file.\n" +
                "WARNING: You will need to set your Helldivers 2 data folder path again.\n" +
                "-Column visibility is now saved between sessions.\n" +
                "For example, if you hide the Image column and close the app, it will remain hidden next time you open it.\n" +
                "Previously, hidden columns would reset and become visible again.\n" +
                "-App will now also create phd2mm_themes folder.\n" +
                "-Replaced \"Toggle Light/Dark Mode\" with a theme manager, found in the \"Themes\" tab.\n" +
                "You can now create, duplicate, edit, and delete custom themes. You cannot edit and delete default themes, \"phd2mm_light\" and \"phd2mm_dark\".\n" +
                "NOTE: Due to WinForms limitations, some parts like borders and tabs cannot be colored.\n" +
                "You can now set a global theme or assign profile-specific themes. Profile-specific theme will be prioritized over global theme.\n" +
                "You can also set an image to be displayed in the top right of the \"Mod Manager\" tab.\n" +
                "NOTE: Only image files in the following formats are accepted: *.png, *.jpg, *.jpeg, *.bmp, *.gif.\n" +
                "Don't forget to click the \"Save Changes\" button to save your changes.\n" +
                "Custom themes are saved in the phd2mm_themes folder. If they are not there or changes aren't saved, try exiting the app first.\n" +
                "-Added GNU General Public License (GPL) version 3 license.\n"
                ;

            public static string MoreInfo_Changelogs_v1_3_1 =
                "v1.3.1\n" +
                "-Fixed UnusedMods_DataGridView not sorting by name by default even when adding new mods when it should have.\n" +
                "-Replaced \"Armor\" in Category selection with \"Armor Both Bodies\", \"Armor Brawny Body\", and \"Armor Lean Body\".\n" +
                "-Added \"Automaton Chant\", \"Ship Screen\", and \"Ship TV\" to Item column selection.\n" +
                "-Replaced \"PA System\" to \"Ship PA System\" in Item column selection for clarity.\n" +
                "-Fixed UnusedMods_DataGridView Category column having minimum width of 5 instead of 50.\n" +
                "-Swapped around Category column and Item column.\n" +
                "-Linked the Category column options to the Item column options. This means, for example, you chose \"JAR-5 Dominator\" as Item, " +
                "then the Category column options will be limited to \"Weapon Audio\" and \"Weapon Skin\" only, rather than all of the Category column options. " +
                "Now, only Item \"Other\" can show the entire Category column options.\n" +
                "-Replaced \"phd2mm_registry.txt\" with \"phd2mm_registry.json\".\n" +
                "-Resizing the app beyond its original resolution will actually make all the things in it " +
                "bigger rather than just the app itself. However, the act of resizing them may create lag.\n"
                ;

            public static string MoreInfo_Changelogs_v1_3 =
                "v1.3\n" +
                "-Redesigned UI.\n" +
                "-Increased size of the main app, \"Form1_phd2mm\", from 1181x890 resolution to 1759x928 resolution to fit new UI redesign.\n" +
                "-Changed the two ListBoxes to DataGridViews to enable categorization and easier sorting of mods.\n" +
                "-Added \"Category\" and \"Item\" ComboBox columns to both of the DataGridViews.\n" +
                "-Added \"#\" or Mod Order Number column to the DataGridView on the right side, \"Mods used in this profile:\". " +
                "User can directly change the mod order by editing the number in this column.\n" +
                "-Allowed scrolling when resizing the main app, \"Form1_phd2mm\".\n" +
                "-Removed Label1 \"Hello! Welcome to Personal Helldivers 2 Mod Manager (phd2mm)\"\n" +
                "-Capitalized the letter M/m of the second word \"Search mod:\" so now it looks like \"Search Mod:\" for consistency.\n" +
                "-Enabled WrapMode to allow text to wrap in both of the DataGridViews, making the row bigger rather than cutting off the text.\n" +
                "-Drag and drop now only works with the DataGridView on the right side, \"Mods used in this profile:\".\n" +
                "To start drag and dropping, click the row header cell (or the leftmost cell in the row) then drag and drop.\n" +
                "Due to this, it conflicts with double-clicking the row header cell to add or remove mods. Drag and drop " +
                "is prioritized over double-clicking in this case. Double clicking row header cell still works with the " +
                "DataGridView on the left side, \"Mods not used in the profile:\".\n" +
                "-Changed the way the adding and removing mod works. Now, you can add and remove mods by double-clicking the " +
                "cell that belongs to the Mod Folder Path + Name column or by clicking the row header cell once then click the " +
                "\"Add Selected Mod\" or \"Remove Selected Mod\" buttons. \n" +
                "Double-clicking the row header (or the leftmost cell in the row) only works with " +
                "UnusedMods_DataGridView and not with UsedMods_DataGridView due to conflict with drag and drop.\n" +
                "-App will now create \"phd2mm_settings\" folder, which includes \"phd2mm_settings.txt\" (previously in the same directory as the phd2mm app) " +
                "and a new text file \"phd2mm_registry\" which contains the details of each mod " +
                "(mod folder path + name, category, item, and description, each separated by tab whitespace).\n" +
                "-Added check when deleting last remaining profile, not allowing user to delete the last profile unless they create\r\nanother profile.\n" +
                "-App will now traverse through subfolders, only getting folders that have files with \".patch_\" in their names.\n" +
                "-Added \"Delete All Installed Mods\" button.\n" +
                "-More mod randomization options by clicking \"Mod Randomization Options\".\n" +
                "-Added an context menu option to right-click the \"Category\", \"Item\", and \"Description\" columns to toggle their visibility.\n" +
                "\n" +
                "Form3_InstallMods Installing Helldivers 2 Mods Page:\n" +
                "-Slightly increased the size of \"Form3_InstalledMods\" form from 836x521 resolution to 906x576 resolution.\n" +
                "-Added the text \"Deleted old mods in Helldivers 2 data folder.\" after deleting old mods in the Helldivers 2 data folder.\n" +
                "\n" +
                "Form4_MoreInfo More Info Page:\n" +
                "-Slightly increased the size of \"Form4_MoreInfo\" form from 723x638 resolution to 789x677 resolution.\n" +
                "-Added credits.\n" +
                "-Updated the text in the \"More Info\" form.\n"
                ;

            public static string MoreInfo_Changelogs_v1_2 =
                "v1.2\n" +
                "-Added search bar to easily find mods.\n" +
                "-Added a simple mod randomization function. You can enable this by clicking \"Enable Mod Randomization Option\" to allow the \"Randomly Add and Remove Mods\" " +
                "button to be clicked. To disable this, click the \"Disable Mod Randomization Option\".\n" +
                "The reason for this is for user safety in case they wanted to move the mod up or down or to install the mods. This way, users will not accidentally randomize " +
                "their chosen mods.\n" +
                "As of this time, this simple randomization does not take mod conflicts into account, so be warned.\n" +
                "-Changed text in Form4_MoreInfo from \"Form4\" to \"More Info\".\n" +
                "-Capitalized text initials of Form2_CreateNewProfile from \"Creating new profile\" to \"Creating New Profile\" for consistency.\n"
                ;

            public static string MoreInfo_Changelogs_v1_1 =
                "v1.1\n" +
                "-Added drag and drop feature to the TextBox under \"Mods used in this profile:\", allowing users to an easier way to rearrange their mod list order.\n"
                ;

            public static string MoreInfo_Changelogs_v1 =
               "v1.0\n" +
               "-First release.\n"
               ;

            public static string MoreInfo_Changelogs_AllVersions =
                MoreInfo_Changelogs_v1_5 + "\n" +
                MoreInfo_Changelogs_v1_4 + "\n" + MoreInfo_Changelogs_v1_3_1 + "\n" + MoreInfo_Changelogs_v1_3 + "\n" +
                MoreInfo_Changelogs_v1_2 + "\n" + MoreInfo_Changelogs_v1_1 + "\n" + MoreInfo_Changelogs_v1
                ;

            public static string MoreInfo_Credits =
                "1. teutinsa, their team, and their project HD2ModManager for the inspiration to create this app.\n" +
                "https://www.nexusmods.com/helldivers2/mods/109\n" +
                "\n"+
                "2. Helldivers Wiki Team and their contributors for easy lookup of all things in the game to easily allow me to create categories and items for this app.\n" +
                "https://helldivers.wiki.gg/\n" +
                "\n" +
                "3. ModOrganizer Team, their contributors, and their project Mod Organizer 2 for the UI inspiration related to the mod window, categories, and styling.\n" +
                "https://www.nexusmods.com/skyrimspecialedition/mods/6194\n" +
                "\n" +
                "4. Prism Launcher Team, their contributors, and their project Prism Launcher for similar UI inspiration. \n" +
                "https://prismlauncher.org/\n" +
                "\n" +
                "5. PixiEditor ColorPicker Team, their contributors, and their Color Picker functionality used in this app.\n" +
                "https://github.com/PixiEditor/ColorPicker/tree/master - MIT License.\n" +
                "\n" +
                "6. Microsoft for Visual Studio 2022 and .NET 9, allowing me to create phd2mm in the first place.\n" +
                "https://visualstudio.microsoft.com/vs/ - Visual Studio License Agreement.\n" +
                "https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9/overview - .NET 9 MIT License.\n" +
                "https://github.com/dotnet/wpf - WPF MIT License.\n" +
                "\n" +
                "7. This app is licensed under the GNU General Public License (GPL) version 3.\n" +
                "For more information, visit the GNU GPL License Page at https://www.gnu.org/licenses/gpl-3.0.en.html.\n"
                ;
        }

    }
}
