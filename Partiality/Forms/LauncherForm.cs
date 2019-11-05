using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PartialityLauncher
{
	public partial class LauncherForm : Form
	{
		public const string HEADERURL = "http://cdn.akamai.steamstatic.com/steam/apps/{0}/header.jpg";

		public LauncherForm()
		{
			InitializeComponent();

			Icon = Properties.Resources.Icon;
			GameManager.OnAppIDLoaded += GameManager_OnAppIDLoaded;
			GameManager.OnAppNameLoaded += GameManager_OnAppNameLoaded;
			GameManager.OnGameLoaded += GameManager_OnGameLoaded;

			GameManager.LoadLastGame();
		}

		public void ToggleModEnabled(CustomDGVCheckBoxCell cb)
		{
			ModIncompatibilityWarning warningLevel = GameManager.CheckForModIncompatibilities(cb.ModMeta);
			string fileName = Path.GetFileName(cb.ModMeta.modPath);

			if (cb.ModMeta.isStandalone && !cb.ModMeta.isEnabled)
			{
				foreach (DataGridViewRow row in modList.Rows)
				{
					var ocb = (CustomDGVCheckBoxCell)row.Cells[1];
					if (ocb.ModMeta != cb.ModMeta && ocb.ModMeta.isStandalone)
					{
						ocb.ModMeta.isStandalone = false;
						CustomDGVCheckBoxCell.ToggleProgrammatically = true;
						ocb.Value = false;
						ocb.ModMeta.isEnabled = false;
						CustomDGVCheckBoxCell.ToggleProgrammatically = false;
					}
				}
			}

			if (cb.ModMeta.isEnabled == false)
			{
				if (warningLevel.warningLevel == 1)
				{
					MessageBox.Show(string.Format("The mod {0} might not work with the following mods:{1}{2}", fileName, Environment.NewLine, warningLevel.sameClassMods));
				}
				else if (warningLevel.warningLevel == 2)
				{
					string msg = string.Format("The mod {0} is incompatible with the following mods:{1}{2}{1}Don't expect them both to work together, but you can still launch the game.", fileName, Environment.NewLine, warningLevel.sameFunctionMods);
					if (warningLevel.sameClassMods.Length > 0)
					{
						msg += string.Format("It also might not work with these mods:{0}{1}", Environment.NewLine, warningLevel.sameClassMods);
					}
					MessageBox.Show(msg);
				}
			}

			CustomDGVCheckBoxCell.ToggleProgrammatically = true;
			cb.ModMeta.isEnabled = !cb.ModMeta.isEnabled;
			cb.Value = cb.ModMeta.isEnabled;
			CustomDGVCheckBoxCell.ToggleProgrammatically = false;
		}

		public void FillOutMods()
		{
			modList.Rows.Clear();

			if (GameManager.exePath == null || GameManager.exePath == "")
				return;

			GameManager.LoadModMetas();

			int i = 0;
			foreach (ModMetadata md in GameManager.modMetas)
			{
				var icon = md.isStandalone ? Properties.Resources.standaloneIcon_x16 : (md.isPatch ? Properties.Resources.patchIcon_x16 : Properties.Resources.modIcon_x16);

				var new_row = new DataGridViewRow();

				new_row.Cells.Add(new DataGridViewImageCell()
				{
					ToolTipText = md.isStandalone ? "Standalone Mod" : (md.isPatch ? "Patch" : "Mod"),
					Value = icon
				});

				var new_cb_cell = new CustomDGVCheckBoxCell() { Value = md.isEnabled, FalseValue = false, TrueValue = true, ModMeta = md, };
				new_cb_cell.OnValueChanged += (b) => { ToggleModEnabled(new_cb_cell); };
				new_row.Cells.Add(new_cb_cell);

				new_row.Cells.Add(new DataGridViewTextBoxCell()
				{
					ToolTipText = md.modPath,
					Value = Path.GetFileName(md.modPath)
				});

				modList.Rows.Add(new_row);
				i++;
			}
		}

		public void SetEnabledControlButtons(bool enabled)
		{
			btn_refresh.Enabled = enabled;
			btn_clear_metadata.Enabled = enabled;
			btn_uninstall.Enabled = enabled;

			btn_apply_mods.Enabled = true;
		}

		public void SetGameName(string name)
		{
			l_game_name.Text = name;
		}

		public void SetAppID(string appID)
		{
			tb_appid.Text = appID;
		}

		public void RunGame()
		{
			Dictionary<Control, bool> prev_states = new Dictionary<Control, bool>();
			foreach (Control c in Controls)
			{
				prev_states.Add(c, c.Enabled);
				c.Enabled = false;
			}

			GameManager.StartGame();

			foreach (var c in prev_states)
				c.Key.Enabled = c.Value;
		}

		private void GameManager_OnGameLoaded()
		{
			FillOutMods();
			SetEnabledControlButtons(GameManager.exePath != null && GameManager.exePath != "");
		}

		private void GameManager_OnAppNameLoaded(string appName)
		{
			SetGameName(appName);
		}

		private void GameManager_OnAppIDLoaded(string appID)
		{
			if (appID != GameManager.EMPTY_APPID)
			{
				pb_game_header.Load(string.Format(HEADERURL, appID));
			}

			SetAppID(appID);
		}

		private void btn_refresh_Click(object sender, EventArgs e)
		{
			GameManager.SaveAllMetadata();
			FillOutMods();
		}

		private void btn_clear_metadata_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("You're about to delete all mod hashes and metadata! This will reset all your mod settings and disable all mods. Are you sure you want to proceed?", "Confirm Clear Metadata", MessageBoxButtons.YesNo);

			if (dr == DialogResult.Yes)
			{
				GameManager.ClearMetas();
				FillOutMods();
			}
		}

		private void btn_uninstall_Click(object sender, EventArgs e)
		{
			try
			{
				GameManager.Uninstall();
				MessageBox.Show("Uninstalling completed!");
				FillOutMods();
			}
			catch (Exception ex)
			{
				DebugLogger.Log(ex);
				MessageBox.Show("Already uninstalled or an error occurred!");
			}
		}

		private void btn_apply_mods_Click(object sender, EventArgs e)
		{
			GameManager.SaveAllMetadata();
			GameManager.appID = tb_appid.Text;


			DebugLogger.Log("Run Game");
			GameManager.PatchGame();

			if (int.TryParse(tb_appid.Text, out int id) == false)
			{
				MessageBox.Show(this, "Mods applied! No/Incorrect APPID was entered, so the game can't be automatically launched. You can now launch the game yourself, as you normally would", "Mod Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				DialogResult result = MessageBox.Show(this, "Mods applied! Would you like to launch the game?", "Mod results", MessageBoxButtons.YesNo);

				if (result == DialogResult.Yes)
				{
					RunGame();
				}
			}

		}

		private void openGameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FileDialog exeDialogue = new OpenFileDialog();
			exeDialogue.ShowDialog(this.Parent);

			if (exeDialogue.FileName == string.Empty || !GameManager.IsValidGamePath(exeDialogue.FileName))
			{
				return;
			}

			GameManager.Reset();
			GameManager.LoadGameByExe(exeDialogue.FileName);
		}

		private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new AboutForm().ShowDialog();
		}

		private void modList_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			modList.EndEdit();
		}

		private void btn_open_game_folder_Click(object sender, EventArgs e)
		{
			if (GameManager.exePath != null && GameManager.exePath != "")
				System.Diagnostics.Process.Start(Path.GetDirectoryName(GameManager.exePath));
		}

		private void btn_run_game_Click(object sender, EventArgs e)
		{
			RunGame();
		}
	}

	public class CustomDGVCheckBoxCell : DataGridViewCheckBoxCell
	{
		public delegate void VoidBool(bool val);
		public event VoidBool OnValueChanged;

		public static bool ToggleProgrammatically = false;
		public ModMetadata ModMeta = null;

		protected override bool SetValue(int rowIndex, object value)
		{
			if (!ToggleProgrammatically)
				OnValueChanged?.Invoke((bool)value);

			return base.SetValue(rowIndex, value);
		}
	}
}
