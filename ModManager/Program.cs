using ModManager.Gui;
using ModManager.Logic.Configuration;
using ModManager.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;

            if (Settings.Default.UpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }


            if (System.IO.File.Exists(System.IO.Path.Combine(Settings.Default.InstallationPath, "Version.txt")) == false)
            {
                OpenFileDialog fileDialog = new OpenFileDialog()
                {
                    Filter = "RimWorld.exe (*.exe)|*.exe",
                    Title = "Select rimworld directory"
                };


                using (fileDialog)
                {
                    System.IO.FileInfo exeFile = null;
                    if (fileDialog.ShowDialog() == DialogResult.OK)
                        exeFile = new System.IO.FileInfo(fileDialog.FileName);



                    if (exeFile != null && exeFile.Exists)
                    {
                        Settings settings = Settings.Default;
                        settings.InstallationPath = exeFile.DirectoryName;

                        settings.ConfigPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Low", "Ludeon Studios", "RimWorld by Ludeon Studios", "Config");

                        System.IO.DirectoryInfo steamApps = System.IO.Directory.GetParent(settings.InstallationPath).Parent;
                        settings.WorkshopPath = System.IO.Path.Combine(steamApps.FullName, "workshop", "content", Resources.SteamId);
                        settings.LocalModsPath = System.IO.Path.Combine(settings.InstallationPath, "Mods");
                        settings.ExpansionsPath = System.IO.Path.Combine(settings.InstallationPath, "Data");


                        settings.Save();
                    }
                    else
                        return;
                }

            }


            if (System.IO.Directory.Exists(Settings.Default.ConfigPath) == false || System.IO.Directory.Exists(Settings.Default.ExpansionsPath) == false)
            {
                ConfigurationPresenter configPresenter = new ConfigurationPresenter();
                using (Configuration configDialog = new Configuration(configPresenter))
                {
                    if (configDialog.ShowDialog() == DialogResult.Cancel)
                    {
                        MessageBox.Show("The program cannot work without a valid path to the configuration file and core expansion, and will now close.");
                        return;
                    }
                }
            }

            var presenter = new Logic.Main.MainPresenter();

            Application.Run(new Gui.Main(presenter));
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception occurred: " + e.Exception.Message + " - " + e.Exception.StackTrace);

        }
    }
}
