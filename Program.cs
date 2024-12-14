using RezSwap.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RezSwap
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new MyCustomApplicationContext());
            
        }

        public class MyCustomApplicationContext : ApplicationContext
        {
            private NotifyIcon trayIcon;
            private frmSettings frmSettings1 = new frmSettings();
            List<string> resList = new List<string>();

            public MyCustomApplicationContext()
            {
                // Initialize Tray Icon
                trayIcon = new NotifyIcon()
                {
                    Icon = frmSettings1.Icon,                    
                    Visible = true
                };

                IEnumerator<DisplaySettings> enumerator = DisplayManager.GetModesEnumerator();
                DisplaySettings set;
                while (enumerator.MoveNext())
                {
                    set = enumerator.Current;
                    var res = set.Width + "x" + set.Height;
                    if (!resList.Contains(res))
                    {
                        resList.Add(res);
                    }
                }
                
                //if (Properties.Settings.Default.HideResolutionList == null)
                //{
                //    Properties.Settings.Default.HideResolutionList = new System.Collections.Specialized.StringCollection();
                //    Properties.Settings.Default.Save();
                //}

                buildMenu();
            }

            void buildMenu()
            {
                try
                {
                    var menu = new ContextMenu();

                    DisplaySettings cur = DisplayManager.GetCurrentSettings();
                    var curRes = cur.Width + "x" + cur.Height;

                    menu.MenuItems.Add("Available Resolutions", SettingsForm).Enabled = false;
                    menu.MenuItems.Add("-");

                    foreach (var res in resList)
                    {
                        if (Properties.Settings.Default.HideResolutionList == null)
                            menu.MenuItems.Add(res, Switch).Checked = (res == curRes);
                        else
                        {
                            if (!Properties.Settings.Default.HideResolutionList.Contains(res))
                                menu.MenuItems.Add(res, Switch).Checked = (res == curRes);
                        }
                    }

                    menu.MenuItems.Add("-");
                    menu.MenuItems.Add("Settings", SettingsForm);
                    menu.MenuItems.Add("Exit", Exit);

                    trayIcon.ContextMenu = menu;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            void Switch(object sender, EventArgs e)
            {
                var selRes = ((MenuItem)sender).Text;

                IEnumerator<DisplaySettings> enumerator = DisplayManager.GetModesEnumerator();
                DisplaySettings set;
                while (enumerator.MoveNext())
                {
                    set = enumerator.Current;
                    if ((set.Width + "x" + set.Height) == selRes)
                    {
                        DialogResult res = DialogResult.Yes;
                        if (Properties.Settings.Default.ConfirmChange)
                            res = MessageBox.Show("Do you want to change resolutions to: " + selRes + "?", "Change Screen Resolutions", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        
                        if (res == DialogResult.Yes)
                        {
                            DisplayManager.SetDisplaySettings(set);
                            buildMenu();
                        }
                        break;
                    }
                }
            }

            void SettingsForm(object sender, EventArgs e)
            {
                frmSettings1 = new frmSettings();
                frmSettings1.FormClosed += FrmSettings1_FormClosed;
                frmSettings1.loadItems(resList);
                frmSettings1.Show();
            }

            private void FrmSettings1_FormClosed(object sender, FormClosedEventArgs e)
            {
                buildMenu();
            }

            void Exit(object sender, EventArgs e)
            {
                // Hide tray icon, otherwise it will remain shown until user mouses over it
                trayIcon.Visible = false;

                Application.Exit();
            }
        }
    }
}
