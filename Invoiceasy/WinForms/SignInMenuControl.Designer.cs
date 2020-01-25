namespace Invoiceasy.WinForms
{
    partial class SignInMenuControl
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TB_SIC_Username = new System.Windows.Forms.TextBox();
            this.LSIC_Username = new System.Windows.Forms.Label();
            this.LSIC_Password = new System.Windows.Forms.Label();
            this.TB_SIC_Password = new System.Windows.Forms.TextBox();
            this.BSIC_Login = new System.Windows.Forms.Button();
            this.BSIC_SignUp = new System.Windows.Forms.Button();
            this.BSIC_Guest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 134);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TB_SIC_Username
            // 
            this.TB_SIC_Username.Location = new System.Drawing.Point(23, 213);
            this.TB_SIC_Username.Name = "TB_SIC_Username";
            this.TB_SIC_Username.Size = new System.Drawing.Size(166, 20);
            this.TB_SIC_Username.TabIndex = 1;
            // 
            // LSIC_Username
            // 
            this.LSIC_Username.AutoSize = true;
            this.LSIC_Username.Location = new System.Drawing.Point(20, 197);
            this.LSIC_Username.Name = "LSIC_Username";
            this.LSIC_Username.Size = new System.Drawing.Size(100, 13);
            this.LSIC_Username.TabIndex = 2;
            this.LSIC_Username.Text = "Username / Email : ";
            // 
            // LSIC_Password
            // 
            this.LSIC_Password.AutoSize = true;
            this.LSIC_Password.Location = new System.Drawing.Point(20, 250);
            this.LSIC_Password.Name = "LSIC_Password";
            this.LSIC_Password.Size = new System.Drawing.Size(62, 13);
            this.LSIC_Password.TabIndex = 3;
            this.LSIC_Password.Text = "Password : ";
            // 
            // TB_SIC_Password
            // 
            this.TB_SIC_Password.Location = new System.Drawing.Point(23, 266);
            this.TB_SIC_Password.Name = "TB_SIC_Password";
            this.TB_SIC_Password.Size = new System.Drawing.Size(166, 20);
            this.TB_SIC_Password.TabIndex = 4;
            // 
            // BSIC_Login
            // 
            this.BSIC_Login.Location = new System.Drawing.Point(114, 292);
            this.BSIC_Login.Name = "BSIC_Login";
            this.BSIC_Login.Size = new System.Drawing.Size(75, 23);
            this.BSIC_Login.TabIndex = 5;
            this.BSIC_Login.Text = "Login";
            this.BSIC_Login.UseVisualStyleBackColor = true;
            // 
            // BSIC_SignUp
            // 
            this.BSIC_SignUp.Location = new System.Drawing.Point(23, 292);
            this.BSIC_SignUp.Name = "BSIC_SignUp";
            this.BSIC_SignUp.Size = new System.Drawing.Size(85, 23);
            this.BSIC_SignUp.TabIndex = 6;
            this.BSIC_SignUp.Text = "Sign Up";
            this.BSIC_SignUp.UseVisualStyleBackColor = true;
            // 
            // BSIC_Guest
            // 
            this.BSIC_Guest.Location = new System.Drawing.Point(45, 143);
            this.BSIC_Guest.Name = "BSIC_Guest";
            this.BSIC_Guest.Size = new System.Drawing.Size(103, 23);
            this.BSIC_Guest.TabIndex = 7;
            this.BSIC_Guest.Text = "Login as Guest";
            this.BSIC_Guest.UseVisualStyleBackColor = true;
            this.BSIC_Guest.Click += new System.EventHandler(this.BSIC_Guest_Click);
            // 
            // SignInMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BSIC_Guest);
            this.Controls.Add(this.BSIC_SignUp);
            this.Controls.Add(this.BSIC_Login);
            this.Controls.Add(this.TB_SIC_Password);
            this.Controls.Add(this.LSIC_Password);
            this.Controls.Add(this.LSIC_Username);
            this.Controls.Add(this.TB_SIC_Username);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SignInMenuControl";
            this.Size = new System.Drawing.Size(192, 447);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox TB_SIC_Username;
        private System.Windows.Forms.Label LSIC_Username;
        private System.Windows.Forms.Label LSIC_Password;
        private System.Windows.Forms.TextBox TB_SIC_Password;
        private System.Windows.Forms.Button BSIC_Login;
        private System.Windows.Forms.Button BSIC_SignUp;
        private System.Windows.Forms.Button BSIC_Guest;
    }
}
