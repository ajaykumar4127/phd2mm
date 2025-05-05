using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                "Way of the Bandolier", "Other"
            }},
            {"Illuminate_Skin_And_Audio", new List<string> {
                "Voteless", "Watcher", "Overseer", "Elevated Overseer", "Harvester",
                "Warp Ship", "Other"
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
                "TED-63 Dynamite", "Other"
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

    }
}
