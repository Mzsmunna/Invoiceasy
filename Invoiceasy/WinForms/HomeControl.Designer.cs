namespace Invoiceasy.WinForms
{
    partial class HomeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LHomeControl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LHomeControl
            // 
            this.LHomeControl.AutoSize = true;
            this.LHomeControl.Location = new System.Drawing.Point(206, 60);
            this.LHomeControl.Name = "LHomeControl";
            this.LHomeControl.Size = new System.Drawing.Size(71, 13);
            this.LHomeControl.TabIndex = 0;
            this.LHomeControl.Text = "Home Control";
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LHomeControl);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(527, 352);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LHomeControl;
    }
}
