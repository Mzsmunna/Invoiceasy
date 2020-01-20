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
            this.ProfilePic = new System.Windows.Forms.PictureBox();
            this.BDealers = new System.Windows.Forms.Button();
            this.BProducts = new System.Windows.Forms.Button();
            this.BHome = new System.Windows.Forms.Button();
            this.BInvoice = new System.Windows.Forms.Button();
            this.HPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // ProfilePic
            // 
            this.ProfilePic.Location = new System.Drawing.Point(659, 13);
            this.ProfilePic.Name = "ProfilePic";
            this.ProfilePic.Size = new System.Drawing.Size(129, 99);
            this.ProfilePic.TabIndex = 1;
            this.ProfilePic.TabStop = false;
            // 
            // BDealers
            // 
            this.BDealers.Location = new System.Drawing.Point(659, 172);
            this.BDealers.Name = "BDealers";
            this.BDealers.Size = new System.Drawing.Size(129, 32);
            this.BDealers.TabIndex = 2;
            this.BDealers.Text = "Dealers";
            this.BDealers.UseVisualStyleBackColor = true;
            this.BDealers.Click += new System.EventHandler(this.BDealers_Click);
            // 
            // BProducts
            // 
            this.BProducts.Location = new System.Drawing.Point(659, 229);
            this.BProducts.Name = "BProducts";
            this.BProducts.Size = new System.Drawing.Size(129, 30);
            this.BProducts.TabIndex = 3;
            this.BProducts.Text = "Products";
            this.BProducts.UseVisualStyleBackColor = true;
            this.BProducts.Click += new System.EventHandler(this.BProducts_Click);
            // 
            // BHome
            // 
            this.BHome.Location = new System.Drawing.Point(659, 283);
            this.BHome.Name = "BHome";
            this.BHome.Size = new System.Drawing.Size(129, 30);
            this.BHome.TabIndex = 4;
            this.BHome.Text = "Home";
            this.BHome.UseVisualStyleBackColor = true;
            this.BHome.Click += new System.EventHandler(this.BHome_Click);
            // 
            // BInvoice
            // 
            this.BInvoice.Location = new System.Drawing.Point(659, 332);
            this.BInvoice.Name = "BInvoice";
            this.BInvoice.Size = new System.Drawing.Size(129, 29);
            this.BInvoice.TabIndex = 5;
            this.BInvoice.Text = "New Invoice";
            this.BInvoice.UseVisualStyleBackColor = true;
            // 
            // HPanel
            // 
            this.HPanel.Location = new System.Drawing.Point(0, 0);
            this.HPanel.Name = "HPanel";
            this.HPanel.Size = new System.Drawing.Size(643, 449);
            this.HPanel.TabIndex = 6;
            // 
            // LandingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.HPanel);
            this.Controls.Add(this.BInvoice);
            this.Controls.Add(this.BHome);
            this.Controls.Add(this.BProducts);
            this.Controls.Add(this.BDealers);
            this.Controls.Add(this.ProfilePic);
            this.Name = "LandingForm";
            this.Text = "LandingForm";
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox ProfilePic;
        private System.Windows.Forms.Button BDealers;
        private System.Windows.Forms.Button BProducts;
        private System.Windows.Forms.Button BHome;
        private System.Windows.Forms.Button BInvoice;
        private System.Windows.Forms.Panel HPanel;
    }
}