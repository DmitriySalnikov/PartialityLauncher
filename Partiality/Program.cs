using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PartialityLauncher
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			HashSet<string> hashArgs = new HashSet<string>(args);

			if (hashArgs.Contains("-quicklaunch"))
			{
#if !DEBUG
				try
				{
#endif
					GameManager.LoadLastGame();
					//GameManager.ClearMetas();
					GameManager.LoadModMetas();
					foreach (ModMetadata md in GameManager.modMetas)
					{
						if (md.isPatch)
							md.isDirty = true;
					}
					GameManager.PatchGame();
					GameManager.StartGame();
#if !DEBUG
				}
				catch (System.Exception e)
				{
					DebugLogger.Log(e);
				}
#endif
				DebugLogger.WriteToFile();
			}
			else
			{
#if !DEBUG
				try
				{
#endif
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					using (LauncherForm form = new LauncherForm())
					{
						Application.Run(form);
					}

#if !DEBUG
				}
				catch (System.Exception e)
				{
					DebugLogger.Log(e);
				}
#endif
				DebugLogger.WriteToFile();
				GameManager.SaveAllMetadata();
			}
		}
	}
}