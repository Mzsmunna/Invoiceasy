namespace Invoiceasy.WinForms
{
    partial class ChallanControl
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
            this.LCC_NO = new System.Windows.Forms.Label();
            this.LCC_TO = new System.Windows.Forms.Label();
            this.LCC_Address = new System.Windows.Forms.Label();
            this.LCC_Contact = new System.Windows.Forms.Label();
            this.TBCC_NO = new System.Windows.Forms.TextBox();
            this.TBCC_TO = new System.Windows.Forms.TextBox();
            this.TBCC_Address = new System.Windows.Forms.TextBox();
            this.TBCC_Contact = new System.Windows.Forms.TextBox();
            this.DTP_CC_Date = new System.Windows.Forms.DateTimePicker();
            this.LCC_Date = new System.Windows.Forms.Label();
            this.LCC_Code = new System.Windows.Forms.Label();
            this.CBCC_Code = new System.Windows.Forms.ComboBox();
            this.DGV_CC_PageItems = new System.Windows.Forms.DataGridView();
            this.LCC_Note = new System.Windows.Forms.Label();
            this.LCC_TotalQ = new System.Windows.Forms.Label();
            this.TBCC_Note = new System.Windows.Forms.TextBox();
            this.TBCC_TotalQ = new System.Windows.Forms.TextBox();
            this.BCC_Save = new System.Windows.Forms.Button();
            this.BCC_Cancel = new System.Windows.Forms.Button();
            this.LCC_Title = new System.Windows.Forms.Label();
            this.CC_ProgressPanel = new System.Windows.Forms.Panel();
            this.LCC_InProgress = new System.Windows.Forms.Label();
            this.ChallanProgressBar = new System.Windows.Forms.ProgressBar();
            this.ChallanBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_CC_PageItems)).BeginInit();
            this.CC_ProgressPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LCC_NO
            // 
            this.LCC_NO.AutoSize = true;
            this.LCC_NO.Location = new System.Drawing.Point(26, 43);
            this.LCC_NO.Name = "LCC_NO";
            this.LCC_NO.Size = new System.Drawing.Size(32, 13);
            this.LCC_NO.TabIndex = 0;
            this.LCC_NO.Text = "NO : ";
            // 
            // LCC_TO
            // 
            this.LCC_TO.AutoSize = true;
            this.LCC_TO.Location = new System.Drawing.Point(26, 76);
            this.LCC_TO.Name = "LCC_TO";
            this.LCC_TO.Size = new System.Drawing.Size(31, 13);
            this.LCC_TO.TabIndex = 1;
            this.LCC_TO.Text = "TO : ";
            // 
            // LCC_Address
            // 
            this.LCC_Address.AutoSize = true;
            this.LCC_Address.Location = new System.Drawing.Point(26, 113);
            this.LCC_Address.Name = "LCC_Address";
            this.LCC_Address.Size = new System.Drawing.Size(54, 13);
            this.LCC_Address.TabIndex = 2;
            this.LCC_Address.Text = "Address : ";
            // 
            // LCC_Contact
            // 
            this.LCC_Contact.AutoSize = true;
            this.LCC_Contact.Location = new System.Drawing.Point(26, 144);
            this.LCC_Contact.Name = "LCC_Contact";
            this.LCC_Contact.Size = new System.Drawing.Size(53, 13);
            this.LCC_Contact.TabIndex = 3;
            this.LCC_Contact.Text = "Contact : ";
            // 
            // TBCC_NO
            // 
            this.TBCC_NO.Location = new System.Drawing.Point(90, 43);
            this.TBCC_NO.Name = "TBCC_NO";
            this.TBCC_NO.Size = new System.Drawing.Size(198, 20);
            this.TBCC_NO.TabIndex = 4;
            // 
            // TBCC_TO
            // 
            this.TBCC_TO.Location = new System.Drawing.Point(90, 76);
            this.TBCC_TO.Name = "TBCC_TO";
            this.TBCC_TO.Size = new System.Drawing.Size(198, 20);
            this.TBCC_TO.TabIndex = 5;
            // 
            // TBCC_Address
            // 
            this.TBCC_Address.Location = new System.Drawing.Point(90, 106);
            this.TBCC_Address.Name = "TBCC_Address";
            this.TBCC_Address.Size = new System.Drawing.Size(425, 20);
            this.TBCC_Address.TabIndex = 6;
            // 
            // TBCC_Contact
            // 
            this.TBCC_Contact.Location = new System.Drawing.Point(90, 141);
            this.TBCC_Contact.Name = "TBCC_Contact";
            this.TBCC_Contact.Size = new System.Drawing.Size(423, 20);
            this.TBCC_Contact.TabIndex = 7;
            // 
            // DTP_CC_Date
            // 
            this.DTP_CC_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_CC_Date.Location = new System.Drawing.Point(519, 40);
            this.DTP_CC_Date.Name = "DTP_CC_Date";
            this.DTP_CC_Date.Size = new System.Drawing.Size(200, 20);
            this.DTP_CC_Date.TabIndex = 8;
            // 
            // LCC_Date
            // 
            this.LCC_Date.AutoSize = true;
            this.LCC_Date.Location = new System.Drawing.Point(474, 43);
            this.LCC_Date.Name = "LCC_Date";
            this.LCC_Date.Size = new System.Drawing.Size(39, 13);
            this.LCC_Date.TabIndex = 9;
            this.LCC_Date.Text = "Date : ";
            // 
            // LCC_Code
            // 
            this.LCC_Code.AutoSize = true;
            this.LCC_Code.Location = new System.Drawing.Point(474, 76);
            this.LCC_Code.Name = "LCC_Code";
            this.LCC_Code.Size = new System.Drawing.Size(41, 13);
            this.LCC_Code.TabIndex = 10;
            this.LCC_Code.Text = "Code : ";
            // 
            // CBCC_Code
            // 
            this.CBCC_Code.FormattingEnabled = true;
            this.CBCC_Code.Location = new System.Drawing.Point(519, 76);
            this.CBCC_Code.Name = "CBCC_Code";
            this.CBCC_Code.Size = new System.Drawing.Size(200, 21);
            this.CBCC_Code.TabIndex = 11;
            // 
            // DGV_CC_PageItems
            // 
            this.DGV_CC_PageItems.AllowUserToOrderColumns = true;
            this.DGV_CC_PageItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_CC_PageItems.Location = new System.Drawing.Point(29, 182);
            this.DGV_CC_PageItems.Name = "DGV_CC_PageItems";
            this.DGV_CC_PageItems.Size = new System.Drawing.Size(710, 316);
            this.DGV_CC_PageItems.TabIndex = 12;
            this.DGV_CC_PageItems.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DGV_CC_PageItems_CellValidating);
            this.DGV_CC_PageItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CC_PageItems_CellValueChanged);
            // 
            // LCC_Note
            // 
            this.LCC_Note.AutoSize = true;
            this.LCC_Note.Location = new System.Drawing.Point(26, 515);
            this.LCC_Note.Name = "LCC_Note";
            this.LCC_Note.Size = new System.Drawing.Size(39, 13);
            this.LCC_Note.TabIndex = 13;
            this.LCC_Note.Text = "Note : ";
            // 
            // LCC_TotalQ
            // 
            this.LCC_TotalQ.AutoSize = true;
            this.LCC_TotalQ.Location = new System.Drawing.Point(531, 515);
            this.LCC_TotalQ.Name = "LCC_TotalQ";
            this.LCC_TotalQ.Size = new System.Drawing.Size(82, 13);
            this.LCC_TotalQ.TabIndex = 14;
            this.LCC_TotalQ.Text = "Total Quantity : ";
            // 
            // TBCC_Note
            // 
            this.TBCC_Note.Location = new System.Drawing.Point(71, 515);
            this.TBCC_Note.Multiline = true;
            this.TBCC_Note.Name = "TBCC_Note";
            this.TBCC_Note.Size = new System.Drawing.Size(442, 64);
            this.TBCC_Note.TabIndex = 15;
            // 
            // TBCC_TotalQ
            // 
            this.TBCC_TotalQ.Location = new System.Drawing.Point(639, 515);
            this.TBCC_TotalQ.Name = "TBCC_TotalQ";
            this.TBCC_TotalQ.ReadOnly = true;
            this.TBCC_TotalQ.Size = new System.Drawing.Size(100, 20);
            this.TBCC_TotalQ.TabIndex = 16;
            // 
            // BCC_Save
            // 
            this.BCC_Save.Location = new System.Drawing.Point(664, 585);
            this.BCC_Save.Name = "BCC_Save";
            this.BCC_Save.Size = new System.Drawing.Size(75, 23);
            this.BCC_Save.TabIndex = 17;
            this.BCC_Save.Text = "Save";
            this.BCC_Save.UseVisualStyleBackColor = true;
            this.BCC_Save.Click += new System.EventHandler(this.BCC_Save_Click);
            // 
            // BCC_Cancel
            // 
            this.BCC_Cancel.Location = new System.Drawing.Point(18, 585);
            this.BCC_Cancel.Name = "BCC_Cancel";
            this.BCC_Cancel.Size = new System.Drawing.Size(75, 23);
            this.BCC_Cancel.TabIndex = 18;
            this.BCC_Cancel.Text = "Cancel";
            this.BCC_Cancel.UseVisualStyleBackColor = true;
            // 
            // LCC_Title
            // 
            this.LCC_Title.AutoSize = true;
            this.LCC_Title.Font = new System.Drawing.Font("Microsoft New Tai Lue", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCC_Title.Location = new System.Drawing.Point(335, 17);
            this.LCC_Title.Name = "LCC_Title";
            this.LCC_Title.Size = new System.Drawing.Size(77, 25);
            this.LCC_Title.TabIndex = 19;
            this.LCC_Title.Text = "Challan";
            // 
            // CC_ProgressPanel
            // 
            this.CC_ProgressPanel.Controls.Add(this.LCC_InProgress);
            this.CC_ProgressPanel.Controls.Add(this.ChallanProgressBar);
            this.CC_ProgressPanel.Location = new System.Drawing.Point(220, 182);
            this.CC_ProgressPanel.Name = "CC_ProgressPanel";
            this.CC_ProgressPanel.Size = new System.Drawing.Size(329, 93);
            this.CC_ProgressPanel.TabIndex = 20;
            this.CC_ProgressPanel.Visible = false;
            // 
            // LCC_InProgress
            // 
            this.LCC_InProgress.AutoSize = true;
            this.LCC_InProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCC_InProgress.Location = new System.Drawing.Point(60, 24);
            this.LCC_InProgress.Name = "LCC_InProgress";
            this.LCC_InProgress.Size = new System.Drawing.Size(226, 20);
            this.LCC_InProgress.TabIndex = 1;
            this.LCC_InProgress.Text = "In Progress... Please Wait!!";
            // 
            // ChallanProgressBar
            // 
            this.ChallanProgressBar.Location = new System.Drawing.Point(3, 67);
            this.ChallanProgressBar.Name = "ChallanProgressBar";
            this.ChallanProgressBar.Size = new System.Drawing.Size(323, 23);
            this.ChallanProgressBar.TabIndex = 0;
            // 
            // ChallanControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CC_ProgressPanel);
            this.Controls.Add(this.LCC_Title);
            this.Controls.Add(this.BCC_Cancel);
            this.Controls.Add(this.BCC_Save);
            this.Controls.Add(this.TBCC_TotalQ);
            this.Controls.Add(this.TBCC_Note);
            this.Controls.Add(this.LCC_TotalQ);
            this.Controls.Add(this.LCC_Note);
            this.Controls.Add(this.DGV_CC_PageItems);
            this.Controls.Add(this.CBCC_Code);
            this.Controls.Add(this.LCC_Code);
            this.Controls.Add(this.LCC_Date);
            this.Controls.Add(this.DTP_CC_Date);
            this.Controls.Add(this.TBCC_Contact);
            this.Controls.Add(this.TBCC_Address);
            this.Controls.Add(this.TBCC_TO);
            this.Controls.Add(this.TBCC_NO);
            this.Controls.Add(this.LCC_Contact);
            this.Controls.Add(this.LCC_Address);
            this.Controls.Add(this.LCC_TO);
            this.Controls.Add(this.LCC_NO);
            this.Name = "ChallanControl";
            this.Size = new System.Drawing.Size(770, 630);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_CC_PageItems)).EndInit();
            this.CC_ProgressPanel.ResumeLayout(false);
            this.CC_ProgressPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LCC_NO;
        private System.Windows.Forms.Label LCC_TO;
        private System.Windows.Forms.Label LCC_Address;
        private System.Windows.Forms.Label LCC_Contact;
        private System.Windows.Forms.TextBox TBCC_NO;
        private System.Windows.Forms.TextBox TBCC_TO;
        private System.Windows.Forms.TextBox TBCC_Address;
        private System.Windows.Forms.TextBox TBCC_Contact;
        private System.Windows.Forms.DateTimePicker DTP_CC_Date;
        private System.Windows.Forms.Label LCC_Date;
        private System.Windows.Forms.Label LCC_Code;
        private System.Windows.Forms.ComboBox CBCC_Code;
        private System.Windows.Forms.DataGridView DGV_CC_PageItems;
        private System.Windows.Forms.Label LCC_Note;
        private System.Windows.Forms.Label LCC_TotalQ;
        private System.Windows.Forms.TextBox TBCC_Note;
        private System.Windows.Forms.TextBox TBCC_TotalQ;
        private System.Windows.Forms.Button BCC_Save;
        private System.Windows.Forms.Button BCC_Cancel;
        private System.Windows.Forms.Label LCC_Title;
        private System.Windows.Forms.Panel CC_ProgressPanel;
        private System.Windows.Forms.ProgressBar ChallanProgressBar;
        private System.ComponentModel.BackgroundWorker ChallanBackgroundWorker;
        private System.Windows.Forms.Label LCC_InProgress;
    }
}
