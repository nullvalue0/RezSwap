namespace RezSwap
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.clbResolutions = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkLaunchStartup = new System.Windows.Forms.CheckBox();
            this.chkConfirmChange = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // clbResolutions
            // 
            this.clbResolutions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbResolutions.FormattingEnabled = true;
            this.clbResolutions.Location = new System.Drawing.Point(15, 53);
            this.clbResolutions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clbResolutions.Name = "clbResolutions";
            this.clbResolutions.Size = new System.Drawing.Size(351, 259);
            this.clbResolutions.TabIndex = 0;
            this.clbResolutions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbResolutions_ItemCheck);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "If you don\'t want to see a resolution in the icon menu, just uncheck it here!";
            // 
            // chkLaunchStartup
            // 
            this.chkLaunchStartup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkLaunchStartup.AutoSize = true;
            this.chkLaunchStartup.Checked = true;
            this.chkLaunchStartup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLaunchStartup.Location = new System.Drawing.Point(15, 330);
            this.chkLaunchStartup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkLaunchStartup.Name = "chkLaunchStartup";
            this.chkLaunchStartup.Size = new System.Drawing.Size(254, 20);
            this.chkLaunchStartup.TabIndex = 2;
            this.chkLaunchStartup.Text = "Launch RezSwap on Windows Startup";
            this.chkLaunchStartup.UseVisualStyleBackColor = true;
            this.chkLaunchStartup.CheckedChanged += new System.EventHandler(this.chkLaunchStartup_CheckedChanged);
            // 
            // chkConfirmChange
            // 
            this.chkConfirmChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkConfirmChange.AutoSize = true;
            this.chkConfirmChange.Checked = true;
            this.chkConfirmChange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConfirmChange.Location = new System.Drawing.Point(15, 355);
            this.chkConfirmChange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkConfirmChange.Name = "chkConfirmChange";
            this.chkConfirmChange.Size = new System.Drawing.Size(251, 20);
            this.chkConfirmChange.TabIndex = 3;
            this.chkConfirmChange.Text = "Confirm Before Changing Resolutions";
            this.chkConfirmChange.UseVisualStyleBackColor = true;
            this.chkConfirmChange.CheckedChanged += new System.EventHandler(this.chkConfirmChange_CheckedChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 382);
            this.Controls.Add(this.chkConfirmChange);
            this.Controls.Add(this.chkLaunchStartup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clbResolutions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.Text = "RezSwap Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbResolutions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkLaunchStartup;
        private System.Windows.Forms.CheckBox chkConfirmChange;
    }
}

