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


            if (System.IO.File.Exists(System.IO.Path.Combine(Properties.Settings.Default.InstallationPath, "Version.txt")) == false)
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
                        Properties.Settings.Default.InstallationPath = exeFile.DirectoryName;
                        Properties.Settings.Default.Save();
                    }
                    else
                        return;
                }

            }

            var presenter = new Logic.Main.MainPresenter(Properties.Settings.Default.InstallationPath);

            Application.Run(new Gui.Main(presenter));
        }
    }
}
