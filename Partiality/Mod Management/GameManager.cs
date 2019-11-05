using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace PartialityLauncher
{
	public static class GameManager
	{
		public delegate void VoidString(string appID);
		public delegate void VoidVoid();
		public static event VoidString OnAppIDLoaded;
		public static event VoidString OnAppNameLoaded;
		public static event VoidVoid OnGameLoaded;

		public const string EMPTY_APPID = "PUT THE APPID HERE";

		public static string _exePath;
		public static string exePath
		{
			get => _exePath;
			set
			{
				_exePath = value;
				OnGameLoaded?.Invoke();
			}
		}
		private static string _appID = EMPTY_APPID;
		public static string appID
		{
			get => _appID;
			set
			{
				_appID = value;
				OnAppIDLoaded?.Invoke(value);
			}
		}
		private static string _appName = EMPTY_APPID;
		public static string appName
		{
			get => _appName;
			set
			{
				_appName = value;
				OnAppNameLoaded?.Invoke(value);
			}
		}
		public static List<ModMetadata> modMetas = new List<ModMetadata>();

		public static void LoadLastGame()
		{
			string executablePath = Assembly.GetEntryAssembly().Location;
			string executableDirectory = Directory.GetParent(executablePath).FullName;

			if (!File.Exists(Path.Combine(executableDirectory, "LASTGAMELOCATION.txt")))
				return;

			exePath = File.ReadAllText(Path.Combine(executableDirectory, "LASTGAMELOCATION.txt"));
			GetAppID();
			GetAppName();

			OnGameLoaded?.Invoke();
		}

		public static void LoadGameByExe(string path)
		{
			exePath = path;
			GetAppID();
			GetAppName();
		}

		public static void Reset()
		{
			exePath = string.Empty;
			modMetas.Clear();
			appID = EMPTY_APPID;
		}

		public static void CreatePartialityDirectories()
		{
			string gameDirectory = Directory.GetParent(exePath).FullName;

			//Load mods
			string modFolder = Path.Combine(gameDirectory, "Mods");
			string dependenciesFolder = Path.Combine(gameDirectory, "ModDependencies");
			string hashesFolder = Path.Combine(gameDirectory, "PartialityHashes");

			if (!Directory.Exists(modFolder))
				File.Create(Path.Combine(Directory.CreateDirectory(modFolder).FullName, "mods go here")).Dispose();
			if (!Directory.Exists(dependenciesFolder))
				File.Create(Path.Combine(Directory.CreateDirectory(dependenciesFolder).FullName, "mod dependencies go here")).Dispose();
			if (!Directory.Exists(hashesFolder))
				File.Create(Path.Combine(Directory.CreateDirectory(hashesFolder).FullName, "IGNORE THIS FOLDER! It's just data for Partiality!")).Dispose();
		}

		public static void LoadModMetas()
		{
			modMetas.Clear();
			string gameDirectory = Directory.GetParent(exePath).FullName;

			//Load mods
			string modFolder = Path.Combine(gameDirectory, "Mods");
			string oldMetaChecker = Path.Combine(gameDirectory, "PartialityHashes", "newMeta");

			CreatePartialityDirectories();

			if (!File.Exists(oldMetaChecker))
			{
				ClearMetas(true);
				File.Create(oldMetaChecker);
				DebugLogger.Log("Clearing old metadata files!");
			}

			string[] files = Directory.GetFiles(modFolder);
			foreach (string s in files)
			{
				DebugLogger.Log("Checking if file is mod " + s);
				if (Path.GetExtension(s) == ".dll")
				{
					try
					{
						ModMetadata md = ModMetadata.GetForMod(s);
						if (md.isStandalone)
							modMetas.Insert(0, md);
						else
							modMetas.Add(md);
					}
					catch (Exception e)
					{
						DebugLogger.Log(e);
					}
				}
			}

			DebugLogger.Log("Loaded metadata for " + modMetas.Count + " mods");
		}
		public static void ClearMetas(bool force = false)
		{
			string gameDirectory = Directory.GetParent(exePath).FullName;
			string modFolder = Path.Combine(gameDirectory, "Mods");
			string hashesFolder = Path.Combine(gameDirectory, "PartialityHashes");

			string[] modFiles = new string[] { };
			string[] hashesFiles = new string[] { };

			if (Directory.Exists(modFolder))
				modFiles = Directory.GetFiles(modFolder);

			if (Directory.Exists(hashesFolder))
				hashesFiles = Directory.GetFiles(hashesFolder);

			foreach (string s in modFiles)
			{
				string extension = Path.GetExtension(s);
				if (extension == ".modMeta")
				{

					if (force)
					{
						File.Delete(s);
					}
					else
					{
						ModMetadata md = ModMetadata.ReadRawFromFile(s);

						if (md.isStandalone == false)
							File.Delete(s);
					}
				}
				else if (extension == ".modHash")
				{
					File.Delete(s);
				}

			}

			foreach (string s in hashesFiles)
			{
				File.Delete(s);
			}
		}
		public static void Uninstall()
		{
			string gameDirectory = Directory.GetParent(exePath).FullName;
			string hashesFolder = Path.Combine(gameDirectory, "PartialityHashes");

			string[] hashesFiles = Directory.GetFiles(hashesFolder);

			foreach (string s in hashesFiles)
			{
				File.Delete(s);
			}
			Directory.Delete(hashesFolder, true);

			string dataDirectory = Path.Combine(gameDirectory, Path.GetFileNameWithoutExtension(GameManager.exePath) + "_Data");
			string managedFolder = Path.Combine(dataDirectory, "Managed");
			string backupFolder = managedFolder + "_backup";

			if (Directory.Exists(backupFolder))
			{
				//Delete original, the re-create it
				Directory.Delete(managedFolder, true);
				Directory.CreateDirectory(managedFolder);
				//Copy files from backup
				PatchManager.CopyFilesRecursively(backupFolder, managedFolder);
				//Delete backup
				Directory.Delete(backupFolder, true);
			}
		}
		public static bool IsValidGamePath(string exePath)
		{
			string mainPath = Directory.GetParent(exePath).FullName;
			string managedPath = Path.Combine(mainPath, Path.GetFileNameWithoutExtension(exePath) + "_Data", "Managed");

			return Directory.Exists(managedPath);
		}

		public static void PatchGame()
		{
			try
			{
				PatchManager.PatchGame();
			}
			catch (System.Exception e)
			{
				DebugLogger.Log(e);
			}
		}
		public static void StartGame()
		{
			string gameDirectory = Directory.GetParent(exePath).FullName;

			File.WriteAllText(Path.Combine(gameDirectory, "appid.txt"), appID);

			string executablePath = Assembly.GetEntryAssembly().Location;
			string executableDirectory = Directory.GetParent(executablePath).FullName;

			File.WriteAllText(Path.Combine(executableDirectory, "LASTGAMELOCATION.txt"), exePath);

			Process p = new Process();
			p.StartInfo.FileName = "steam://rungameid/" + appID;
			p.Start();
		}

		public static void SaveAllMetadata()
		{
			if (exePath != null && exePath != string.Empty)
			{
				string mainPath = Directory.GetParent(exePath).FullName;
				string modFolder = Path.Combine(mainPath, "Patches");
				foreach (ModMetadata md in modMetas)
				{
					ModMetadata.SaveMod(md);
				}
			}
		}
		public static void GetAppID()
		{
			string mainPath = Directory.GetParent(exePath).FullName;

			if (File.Exists(Path.Combine(mainPath, "appid.txt")))
			{
				appID = File.ReadAllText(Path.Combine(mainPath, "appid.txt"));
			}
			else if (File.Exists(Path.Combine(mainPath, "steam_appid.txt")))
			{
				appID = File.ReadAllText(Path.Combine(mainPath, "steam_appid.txt"));
			}
			else
			{
				MessageBox.Show("No APPID found! Make sure to get one! There's a tutorial in your game's folder.");
				File.WriteAllText(
					Path.Combine(mainPath, "HOW TO GET APPID.txt"),
					"1: Go to store.steampowered.com " +
					"2: Search for the game " +
					"3: The number after " + '"' + "app " + '"' + " in the URL for your game is the appID for the game. (For example, Slime Rancher's URL is " + '"' + "store.steampowered.com/app/433340/Slime_Rancher/" + '"' + ", the appid is, therefore, 433340.)"
				);
			}
		}

		public static void GetAppName()
		{
			appName = Path.GetFileNameWithoutExtension(exePath);
		}

		public static ModIncompatibilityWarning CheckForModIncompatibilities(ModMetadata checkMod)
		{
			ModIncompatibilityWarning warning = new ModIncompatibilityWarning();

			StringBuilder warningBuilder = new StringBuilder();
			StringBuilder incompatibleBuilder = new StringBuilder();

			//If the mod's not a patch, we don't have to care what it messes with.
			if (!checkMod.isPatch)
				return warning;

			int warnType = 0;

			//Compare the mod to all other mods
			for (int i = 0; i < modMetas.Count; i++)
			{
				//Get the other mod we're comparing to
				ModMetadata otherMod = modMetas[i];

				if (otherMod == checkMod)
					continue;

				if (!otherMod.isPatch || !otherMod.isEnabled)
					continue;

				//The warning type will be nothing by default

				//Check all the classes the other mod modifies
				foreach (KeyValuePair<string, HashSet<string>> otherModClass in otherMod.modifiedClasses)
				{
					//If the other mod modifies a class that this mod does
					if (checkMod.modifiedClasses.ContainsKey(otherModClass.Key))
					{
						//Store this mod's compares for later
						HashSet<string> classCompare = checkMod.modifiedClasses[otherModClass.Key];
						bool isHighWarning = false;
						//Set warning type to 1
						if (warnType == 0)
							warnType = 1;

						//Check all the functions the other mod changes
						foreach (string s in otherModClass.Value)
						{
							//If both mods change the same function, it as incompatible.
							if (classCompare.Contains(s))
							{
								warnType = 2;
								isHighWarning = true;
								break;
							}
						}

						if (isHighWarning)
						{
							incompatibleBuilder.AppendLine(Path.GetFileName(otherMod.modPath));
						}
						else
						{
							warningBuilder.AppendLine(Path.GetFileName(otherMod.modPath));
						}

						break;
					}
				}
			}

			warning.warningLevel = warnType;
			warning.sameClassMods = warningBuilder.ToString();
			warning.sameFunctionMods = incompatibleBuilder.ToString();

			return warning;
		}
	}

	public class ModIncompatibilityWarning
	{

		public int warningLevel;
		public string sameFunctionMods;
		public string sameClassMods;

	}
}