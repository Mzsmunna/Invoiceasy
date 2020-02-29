namespace Invoiceasy.WinForms
{
    partial class LandingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LandingForm));
            this.HPanel = new System.Windows.Forms.Panel();
            this.VPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // HPanel
            // 
            this.HPanel.Location = new System.Drawing.Point(0, 0);
            this.HPanel.Name = "HPanel";
            this.HPanel.Size = new System.Drawing.Size(771, 631);
            this.HPanel.TabIndex = 6;
            // 
            // VPanel
            // 
            this.VPanel.Location = new System.Drawing.Point(777, 0);
            this.VPanel.Name = "VPanel";
            this.VPanel.Size = new System.Drawing.Size(214, 631);
            this.VPanel.TabIndex = 7;
            // 
            // LandingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 643);
            this.Controls.Add(this.VPanel);
            this.Controls.Add(this.HPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LandingForm";
            this.Text = "Invoiceasy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LandingForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel HPanel;
        private System.Windows.Forms.Panel VPanel;
    }
}