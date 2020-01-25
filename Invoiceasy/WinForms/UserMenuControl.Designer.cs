namespace Invoiceasy.WinForms
{
    partial class UserMenuControl
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
            this.PBUC_ProfilePic = new System.Windows.Forms.PictureBox();
            this.BUC_NewInvoice = new System.Windows.Forms.Button();
            this.BUC_Logout = new System.Windows.Forms.Button();
            this.LUC_Username = new System.Windows.Forms.Label();
            this.BUC_Products = new System.Windows.Forms.Button();
            this.BUC_Dealers = new System.Windows.Forms.Button();
            this.BUC_Home = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PBUC_ProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // PBUC_ProfilePic
            // 
            this.PBUC_ProfilePic.Location = new System.Drawing.Point(3, 32);
            this.PBUC_ProfilePic.Name = "PBUC_ProfilePic";
            this.PBUC_ProfilePic.Size = new System.Drawing.Size(205, 146);
            this.PBUC_ProfilePic.TabIndex = 0;
            this.PBUC_ProfilePic.TabStop = false;
            // 
            // BUC_NewInvoice
            // 
            this.BUC_NewInvoice.Location = new System.Drawing.Point(22, 338);
            this.BUC_NewInvoice.Name = "BUC_NewInvoice";
            this.BUC_NewInvoice.Size = new System.Drawing.Size(157, 41);
            this.BUC_NewInvoice.TabIndex = 1;
            this.BUC_NewInvoice.Text = "New Invoice";
            this.BUC_NewInvoice.UseVisualStyleBackColor = true;
            this.BUC_NewInvoice.Click += new System.EventHandler(this.BUC_NewInvoice_Click);
            // 
            // BUC_Logout
            // 
            this.BUC_Logout.Location = new System.Drawing.Point(133, 3);
            this.BUC_Logout.Name = "BUC_Logout";
            this.BUC_Logout.Size = new System.Drawing.Size(75, 23);
            this.BUC_Logout.TabIndex = 2;
            this.BUC_Logout.Text = "Logout";
            this.BUC_Logout.UseVisualStyleBackColor = true;
            // 
            // LUC_Username
            // 
            this.LUC_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LUC_Username.Location = new System.Drawing.Point(54, 181);
            this.LUC_Username.Name = "LUC_Username";
            this.LUC_Username.Size = new System.Drawing.Size(100, 23);
            this.LUC_Username.TabIndex = 3;
            this.LUC_Username.Text = "@Username";
            // 
            // BUC_Products
            // 
            this.BUC_Products.Location = new System.Drawing.Point(22, 290);
            this.BUC_Products.Name = "BUC_Products";
            this.BUC_Products.Size = new System.Drawing.Size(157, 42);
            this.BUC_Products.TabIndex = 4;
            this.BUC_Products.Text = "Product List";
            this.BUC_Products.UseVisualStyleBackColor = true;
            this.BUC_Products.Click += new System.EventHandler(this.BUC_Products_Click);
            // 
            // BUC_Dealers
            // 
            this.BUC_Dealers.Location = new System.Drawing.Point(22, 247);
            this.BUC_Dealers.Name = "BUC_Dealers";
            this.BUC_Dealers.Size = new System.Drawing.Size(157, 37);
            this.BUC_Dealers.TabIndex = 5;
            this.BUC_Dealers.Text = "Dealer List";
            this.BUC_Dealers.UseVisualStyleBackColor = true;
            this.BUC_Dealers.Click += new System.EventHandler(this.BUC_Dealers_Click);
            // 
            // BUC_Home
            // 
            this.BUC_Home.Location = new System.Drawing.Point(22, 385);
            this.BUC_Home.Name = "BUC_Home";
            this.BUC_Home.Size = new System.Drawing.Size(157, 33);
            this.BUC_Home.TabIndex = 6;
            this.BUC_Home.Text = "Home";
            this.BUC_Home.UseVisualStyleBackColor = true;
            this.BUC_Home.Click += new System.EventHandler(this.BUC_Home_Click);
            // 
            // UserMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BUC_Home);
            this.Controls.Add(this.BUC_Dealers);
            this.Controls.Add(this.BUC_Products);
            this.Controls.Add(this.LUC_Username);
            this.Controls.Add(this.BUC_Logout);
            this.Controls.Add(this.BUC_NewInvoice);
            this.Controls.Add(this.PBUC_ProfilePic);
            this.Name = "UserMenuControl";
            this.Size = new System.Drawing.Size(211, 451);
            ((System.ComponentModel.ISupportInitialize)(this.PBUC_ProfilePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBUC_ProfilePic;
        private System.Windows.Forms.Button BUC_NewInvoice;
        private System.Windows.Forms.Button BUC_Logout;
        private System.Windows.Forms.Label LUC_Username;
        private System.Windows.Forms.Button BUC_Products;
        private System.Windows.Forms.Button BUC_Dealers;
        private System.Windows.Forms.Button BUC_Home;
    }
}
