using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RezSwap
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        bool loading = false;

        public void loadItems(List<String> resolutions)
        {
            try
            {
                loading = true;

                clbResolutions.Items.Clear();
                foreach (String resolution in resolutions)
                {
                    if (Properties.Settings.Default.HideResolutionList == null)
                        clbResolutions.Items.Add(resolution, true);
                    else
                        clbResolutions.Items.Add(resolution, !Properties.Settings.Default.HideResolutionList.Contains(resolution));
                }

                chkConfirmChange.Checked = Properties.Settings.Default.ConfirmChange;
                chkLaunchStartup.Checked = Properties.Settings.Default.LaunchStartup;
            }
            finally
            {
                loading = false;
            }
            
        }

        private void clbResolutions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!loading)
            {
                if (Properties.Settings.Default.HideResolutionList == null)
                    Properties.Settings.Default.HideResolutionList = new System.Collections.Specialized.StringCollection();
                
                var resolution = clbResolutions.Items[e.Index].ToString();
                if (e.NewValue == CheckState.Unchecked)
                {
                    if (!Properties.Settings.Default.HideResolutionList.Contains(resolution))
                        Properties.Settings.Default.HideResolutionList.Add(resolution);
                }
                else
                {
                    if (Properties.Settings.Default.HideResolutionList.Contains(resolution))
                        Properties.Settings.Default.HideResolutionList.Remove(resolution);
                }
                Properties.Settings.Default.Save();
            }
        }

        private void chkLaunchStartup_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LaunchStartup = chkLaunchStartup.Checked;
            Properties.Settings.Default.Save();

            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            var AppName = "RezSwap";
            if (chkLaunchStartup.Checked)
                rk.SetValue(AppName, Application.ExecutablePath);
            else
                rk.DeleteValue(AppName, false);
        }

        private void chkConfirmChange_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ConfirmChange = chkConfirmChange.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
