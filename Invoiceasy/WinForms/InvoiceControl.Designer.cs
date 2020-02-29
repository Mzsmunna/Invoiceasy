namespace Invoiceasy.WinForms
{
    partial class InvoiceControl
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
            this.LIC_Title = new System.Windows.Forms.Label();
            this.LIC_NO = new System.Windows.Forms.Label();
            this.LIC_TO = new System.Windows.Forms.Label();
            this.LIC_Date = new System.Windows.Forms.Label();
            this.LIC_Code = new System.Windows.Forms.Label();
            this.LIC_Address = new System.Windows.Forms.Label();
            this.DGV_PageItems = new System.Windows.Forms.DataGridView();
            this.LIC_Note = new System.Windows.Forms.Label();
            this.LIC_TotalAmount = new System.Windows.Forms.Label();
            this.LIC_SpecialDiscount = new System.Windows.Forms.Label();
            this.LIC_PayableAmount = new System.Windows.Forms.Label();
            this.LIC_InWord = new System.Windows.Forms.Label();
            this.TBIC_No = new System.Windows.Forms.TextBox();
            this.TBIC_To = new System.Windows.Forms.TextBox();
            this.TBIC_Address = new System.Windows.Forms.TextBox();
            this.TBIC_Contact = new System.Windows.Forms.TextBox();
            this.LIC_Contact = new System.Windows.Forms.Label();
            this.DTP_IC_Date = new System.Windows.Forms.DateTimePicker();
            this.CBIC_Code = new System.Windows.Forms.ComboBox();
            this.TBIC_Note = new System.Windows.Forms.TextBox();
            this.TBIC_InWord = new System.Windows.Forms.TextBox();
            this.TBIC_TotalAmount = new System.Windows.Forms.TextBox();
            this.TBIC_SpecialDiscount = new System.Windows.Forms.TextBox();
            this.TBIC_PayableAmount = new System.Windows.Forms.TextBox();
            this.TBIC_Discount = new System.Windows.Forms.TextBox();
            this.BIC_Save = new System.Windows.Forms.Button();
            this.BIC_Cancel = new System.Windows.Forms.Button();
            this.InvoiceBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.InvoiceProgressBar = new System.Windows.Forms.ProgressBar();
            this.IC_ProgressPanel = new System.Windows.Forms.Panel();
            this.LICPP_InProgress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PageItems)).BeginInit();
            this.IC_ProgressPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LIC_Title
            // 
            this.LIC_Title.AutoSize = true;
            this.LIC_Title.Font = new System.Drawing.Font("Microsoft New Tai Lue", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LIC_Title.Location = new System.Drawing.Point(340, 14);
            this.LIC_Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LIC_Title.Name = "LIC_Title";
            this.LIC_Title.Size = new System.Drawing.Size(76, 25);
            this.LIC_Title.TabIndex = 0;
            this.LIC_Title.Text = "Invoice";
            // 
            // LIC_NO
            // 
            this.LIC_NO.AutoSize = true;
            this.LIC_NO.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LIC_NO.Location = new System.Drawing.Point(43, 52);
            this.LIC_NO.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LIC_NO.Name = "LIC_NO";
            this.LIC_NO.Size = new System.Drawing.Size(39, 17);
            this.LIC_NO.TabIndex = 1;
            this.LIC_NO.Text = "NO : ";
            // 
            // LIC_TO
            // 
            this.LIC_TO.AutoSize = true;
            this.LIC_TO.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LIC_TO.Location = new System.Drawing.Point(41, 91);
            this.LIC_TO.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LIC_TO.Name = "LIC_TO";
            this.LIC_TO.Size = new System.Drawing.Size(36, 17);
            this.LIC_TO.TabIndex = 2;
            this.LIC_TO.Text = "TO : ";
            // 
            // LIC_Date
            // 
            this.LIC_Date.AutoSize = true;
            this.LIC_Date.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LIC_Date.Location = new System.Drawing.Point(560, 55);
            this.LIC_Date.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LIC_Date.Name = "LIC_Date";
            this.LIC_Date.Size = new System.Drawing.Size(46, 17);
            this.LIC_Date.TabIndex = 3;
            this.LIC_Date.Text = "Date : ";
            // 
            // LIC_Code
            // 
            this.LIC_Code.AutoSize = true;
            this.LIC_Code.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LIC_Code.Location = new System.Drawing.Point(560, 91);
            this.LIC_Code.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LIC_Code.Name = "LIC_Code";
            this.LIC_Code.Size = new System.Drawing.Size(50, 17);
            this.LIC_Code.TabIndex = 4;
            this.LIC_Code.Text = "Code : ";
            // 
            // LIC_Address
            // 
            this.LIC_Address.AutoSize = true;
            this.LIC_Address.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LIC_Address.Location = new System.Drawing.Point(15, 130);
            this.LIC_Address.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LIC_Address.Name = "LIC_Address";
            this.LIC_Address.Size = new System.Drawing.Size(67, 17);
            this.LIC_Address.TabIndex = 5;
            this.LIC_Address.Text = "Address : ";
            // 
            // DGV_PageItems
            // 
            this.DGV_PageItems.AllowDrop = true;
            this.DGV_PageItems.AllowUserToOrderColumns = true;
            this.DGV_PageItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_PageItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_PageItems.Location = new System.Drawing.Point(13, 206);
            this.DGV_PageItems.Margin = new System.Windows.Forms.Padding(2);
            this.DGV_PageItems.MultiSelect = false;
            this.DGV_PageItems.Name = "DGV_PageItems";
            this.DGV_PageItems.Size = new System.Drawing.Size(743, 231);
            this.DGV_PageItems.TabIndex = 6;
            this.DGV_PageItems.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DGV_PageItems_CellValidating);
            this.DGV_PageItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_PageItems_CellValueChanged);
            this.DGV_PageItems.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DGV_PageItems_RowValidating);
            // 
            // LIC_Note
            // 
            this.LIC_Note.AutoSize = true;
            this.LIC_Note.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LIC_Note.Location = new System.Drawing.Point(11, 452);
            this.LIC_Note.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LIC_Note.Name = "LIC_Note";
            this.LIC_Note.Size = new System.Drawing.Size(48, 17);
            this.LIC_Note.TabIndex = 7;
            this.LIC_Note.Text = "Note : ";
            // 
            // LIC_TotalAmount
            // 
            this.LIC_TotalAmount.AutoSize = true;
            this.LIC_TotalAmount.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LIC_TotalAmount.Location = new System.Drawing.Point(560, 452);
            this.LIC_TotalAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LIC_TotalAmount.Name = "LIC_TotalAmount";
            this.LIC_TotalAmount.Size = new System.Drawing.Size(97, 17);
            this.LIC_TotalAmount.TabIndex = 8;
            this.LIC_TotalAmount.Text = "Total Amount : ";
            // 
            // LIC_SpecialDiscount
            // 
            this.LIC_SpecialDiscount.AutoSize = true;
            this.LIC_SpecialDiscount.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LIC_SpecialDiscount.Location = new System.Drawing.Point(489, 489);
            this.LIC_SpecialDiscount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LIC_SpecialDiscount.Name = "LIC_SpecialDiscount";
            this.LIC_SpecialDiscount.Size = new System.Drawing.Size(114, 17);
            this.LIC_SpecialDiscount.TabIndex = 9;
            this.LIC_SpecialDiscount.Text = "Special Discount : ";
            // 
            // LIC_PayableAmount
            // 
            this.LIC_PayableAmount.AutoSize = true;
            this.LIC_PayableAmount.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LIC_PayableAmount.Location = new System.Drawing.Point(487, 535);
            this.LIC_PayableAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LIC_PayableAmount.Name = "LIC_PayableAmount";
            this.LIC_PayableAmount.Size = new System.Drawing.Size(170, 17);
            this.LIC_PayableAmount.TabIndex = 10;
            this.LIC_PayableAmount.Text = "Net Payable Amount in TK. :";
            // 
            // LIC_InWord
            // 
            this.LIC_InWord.AutoSize = true;
            this.LIC_InWord.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LIC_InWord.Location = new System.Drawing.Point(11, 536);
            this.LIC_InWord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LIC_InWord.Name = "LIC_InWord";
            this.LIC_InWord.Size = new System.Drawing.Size(66, 17);
            this.LIC_InWord.TabIndex = 11;
            this.LIC_InWord.Text = "In Word:  ";
            // 
            // TBIC_No
            // 
            this.TBIC_No.Location = new System.Drawing.Point(86, 49);
            this.TBIC_No.Margin = new System.Windows.Forms.Padding(2);
            this.TBIC_No.Name = "TBIC_No";
            this.TBIC_No.Size = new System.Drawing.Size(108, 25);
            this.TBIC_No.TabIndex = 12;
            // 
            // TBIC_To
            // 
            this.TBIC_To.Location = new System.Drawing.Point(86, 88);
            this.TBIC_To.Margin = new System.Windows.Forms.Padding(2);
            this.TBIC_To.Name = "TBIC_To";
            this.TBIC_To.Size = new System.Drawing.Size(316, 25);
            this.TBIC_To.TabIndex = 13;
            // 
            // TBIC_Address
            // 
            this.TBIC_Address.Location = new System.Drawing.Point(86, 127);
            this.TBIC_Address.Margin = new System.Windows.Forms.Padding(2);
            this.TBIC_Address.Name = "TBIC_Address";
            this.TBIC_Address.Size = new System.Drawing.Size(520, 25);
            this.TBIC_Address.TabIndex = 14;
            // 
            // TBIC_Contact
            // 
            this.TBIC_Contact.Location = new System.Drawing.Point(86, 167);
            this.TBIC_Contact.Margin = new System.Windows.Forms.Padding(2);
            this.TBIC_Contact.Name = "TBIC_Contact";
            this.TBIC_Contact.Size = new System.Drawing.Size(316, 25);
            this.TBIC_Contact.TabIndex = 15;
            // 
            // LIC_Contact
            // 
            this.LIC_Contact.AutoSize = true;
            this.LIC_Contact.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LIC_Contact.Location = new System.Drawing.Point(19, 170);
            this.LIC_Contact.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LIC_Contact.Name = "LIC_Contact";
            this.LIC_Contact.Size = new System.Drawing.Size(63, 17);
            this.LIC_Contact.TabIndex = 16;
            this.LIC_Contact.Text = "Contact : ";
            // 
            // DTP_IC_Date
            // 
            this.DTP_IC_Date.CalendarFont = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_IC_Date.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_IC_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_IC_Date.Location = new System.Drawing.Point(630, 49);
            this.DTP_IC_Date.Margin = new System.Windows.Forms.Padding(2);
            this.DTP_IC_Date.Name = "DTP_IC_Date";
            this.DTP_IC_Date.Size = new System.Drawing.Size(126, 25);
            this.DTP_IC_Date.TabIndex = 17;
            // 
            // CBIC_Code
            // 
            this.CBIC_Code.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBIC_Code.FormattingEnabled = true;
            this.CBIC_Code.Location = new System.Drawing.Point(630, 83);
            this.CBIC_Code.Margin = new System.Windows.Forms.Padding(2);
            this.CBIC_Code.Name = "CBIC_Code";
            this.CBIC_Code.Size = new System.Drawing.Size(126, 25);
            this.CBIC_Code.TabIndex = 18;
            this.CBIC_Code.SelectedIndexChanged += new System.EventHandler(this.CBIC_Code_SelectedIndexChanged);
            // 
            // TBIC_Note
            // 
            this.TBIC_Note.Location = new System.Drawing.Point(80, 449);
            this.TBIC_Note.Margin = new System.Windows.Forms.Padding(2);
            this.TBIC_Note.Multiline = true;
            this.TBIC_Note.Name = "TBIC_Note";
            this.TBIC_Note.Size = new System.Drawing.Size(389, 57);
            this.TBIC_Note.TabIndex = 19;
            // 
            // TBIC_InWord
            // 
            this.TBIC_InWord.Font = new System.Drawing.Font("Microsoft New Tai Lue", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBIC_InWord.Location = new System.Drawing.Point(80, 533);
            this.TBIC_InWord.Margin = new System.Windows.Forms.Padding(2);
            this.TBIC_InWord.Name = "TBIC_InWord";
            this.TBIC_InWord.ReadOnly = true;
            this.TBIC_InWord.Size = new System.Drawing.Size(389, 22);
            this.TBIC_InWord.TabIndex = 20;
            // 
            // TBIC_TotalAmount
            // 
            this.TBIC_TotalAmount.Location = new System.Drawing.Point(667, 444);
            this.TBIC_TotalAmount.Margin = new System.Windows.Forms.Padding(2);
            this.TBIC_TotalAmount.Name = "TBIC_TotalAmount";
            this.TBIC_TotalAmount.ReadOnly = true;
            this.TBIC_TotalAmount.Size = new System.Drawing.Size(89, 25);
            this.TBIC_TotalAmount.TabIndex = 21;
            // 
            // TBIC_SpecialDiscount
            // 
            this.TBIC_SpecialDiscount.Location = new System.Drawing.Point(667, 485);
            this.TBIC_SpecialDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.TBIC_SpecialDiscount.Name = "TBIC_SpecialDiscount";
            this.TBIC_SpecialDiscount.ReadOnly = true;
            this.TBIC_SpecialDiscount.Size = new System.Drawing.Size(89, 25);
            this.TBIC_SpecialDiscount.TabIndex = 22;
            // 
            // TBIC_PayableAmount
            // 
            this.TBIC_PayableAmount.Location = new System.Drawing.Point(667, 532);
            this.TBIC_PayableAmount.Margin = new System.Windows.Forms.Padding(2);
            this.TBIC_PayableAmount.Name = "TBIC_PayableAmount";
            this.TBIC_PayableAmount.ReadOnly = true;
            this.TBIC_PayableAmount.Size = new System.Drawing.Size(89, 25);
            this.TBIC_PayableAmount.TabIndex = 23;
            // 
            // TBIC_Discount
            // 
            this.TBIC_Discount.Location = new System.Drawing.Point(607, 485);
            this.TBIC_Discount.Margin = new System.Windows.Forms.Padding(2);
            this.TBIC_Discount.Name = "TBIC_Discount";
            this.TBIC_Discount.Size = new System.Drawing.Size(56, 25);
            this.TBIC_Discount.TabIndex = 24;
            this.TBIC_Discount.TextChanged += new System.EventHandler(this.TBIC_Discount_TextChanged);
            this.TBIC_Discount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBIC_Discount_KeyPress);
            // 
            // BIC_Save
            // 
            this.BIC_Save.Location = new System.Drawing.Point(667, 578);
            this.BIC_Save.Name = "BIC_Save";
            this.BIC_Save.Size = new System.Drawing.Size(89, 23);
            this.BIC_Save.TabIndex = 25;
            this.BIC_Save.Text = "Save";
            this.BIC_Save.UseVisualStyleBackColor = true;
            this.BIC_Save.Click += new System.EventHandler(this.BIC_Save_Click);
            // 
            // BIC_Cancel
            // 
            this.BIC_Cancel.Location = new System.Drawing.Point(13, 578);
            this.BIC_Cancel.Name = "BIC_Cancel";
            this.BIC_Cancel.Size = new System.Drawing.Size(75, 23);
            this.BIC_Cancel.TabIndex = 26;
            this.BIC_Cancel.Text = "Cancel";
            this.BIC_Cancel.UseVisualStyleBackColor = true;
            this.BIC_Cancel.Click += new System.EventHandler(this.BIC_Cancel_Click);
            // 
            // InvoiceProgressBar
            // 
            this.InvoiceProgressBar.Location = new System.Drawing.Point(3, 65);
            this.InvoiceProgressBar.Name = "InvoiceProgressBar";
            this.InvoiceProgressBar.Size = new System.Drawing.Size(331, 32);
            this.InvoiceProgressBar.TabIndex = 27;
            this.InvoiceProgressBar.Visible = false;
            // 
            // IC_ProgressPanel
            // 
            this.IC_ProgressPanel.Controls.Add(this.LICPP_InProgress);
            this.IC_ProgressPanel.Controls.Add(this.InvoiceProgressBar);
            this.IC_ProgressPanel.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IC_ProgressPanel.Location = new System.Drawing.Point(227, 206);
            this.IC_ProgressPanel.Name = "IC_ProgressPanel";
            this.IC_ProgressPanel.Size = new System.Drawing.Size(337, 100);
            this.IC_ProgressPanel.TabIndex = 28;
            this.IC_ProgressPanel.Visible = false;
            // 
            // LICPP_InProgress
            // 
            this.LICPP_InProgress.AutoSize = true;
            this.LICPP_InProgress.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LICPP_InProgress.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LICPP_InProgress.Location = new System.Drawing.Point(71, 23);
            this.LICPP_InProgress.Name = "LICPP_InProgress";
            this.LICPP_InProgress.Size = new System.Drawing.Size(199, 20);
            this.LICPP_InProgress.TabIndex = 28;
            this.LICPP_InProgress.Text = "In Progress!! Please Wait....";
            // 
            // InvoiceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.IC_ProgressPanel);
            this.Controls.Add(this.BIC_Cancel);
            this.Controls.Add(this.BIC_Save);
            this.Controls.Add(this.TBIC_Discount);
            this.Controls.Add(this.TBIC_PayableAmount);
            this.Controls.Add(this.TBIC_SpecialDiscount);
            this.Controls.Add(this.TBIC_TotalAmount);
            this.Controls.Add(this.TBIC_InWord);
            this.Controls.Add(this.TBIC_Note);
            this.Controls.Add(this.CBIC_Code);
            this.Controls.Add(this.DTP_IC_Date);
            this.Controls.Add(this.LIC_Contact);
            this.Controls.Add(this.TBIC_Contact);
            this.Controls.Add(this.TBIC_Address);
            this.Controls.Add(this.TBIC_To);
            this.Controls.Add(this.TBIC_No);
            this.Controls.Add(this.LIC_InWord);
            this.Controls.Add(this.LIC_PayableAmount);
            this.Controls.Add(this.LIC_SpecialDiscount);
            this.Controls.Add(this.LIC_TotalAmount);
            this.Controls.Add(this.LIC_Note);
            this.Controls.Add(this.DGV_PageItems);
            this.Controls.Add(this.LIC_Address);
            this.Controls.Add(this.LIC_Code);
            this.Controls.Add(this.LIC_Date);
            this.Controls.Add(this.LIC_TO);
            this.Controls.Add(this.LIC_NO);
            this.Controls.Add(this.LIC_Title);
            this.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InvoiceControl";
            this.Size = new System.Drawing.Size(770, 630);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PageItems)).EndInit();
            this.IC_ProgressPanel.ResumeLayout(false);
            this.IC_ProgressPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LIC_Title;
        private System.Windows.Forms.Label LIC_NO;
        private System.Windows.Forms.Label LIC_TO;
        private System.Windows.Forms.Label LIC_Date;
        private System.Windows.Forms.Label LIC_Code;
        private System.Windows.Forms.Label LIC_Address;
        private System.Windows.Forms.DataGridView DGV_PageItems;
        private System.Windows.Forms.Label LIC_Note;
        private System.Windows.Forms.Label LIC_TotalAmount;
        private System.Windows.Forms.Label LIC_SpecialDiscount;
        private System.Windows.Forms.Label LIC_PayableAmount;
        private System.Windows.Forms.Label LIC_InWord;
        private System.Windows.Forms.TextBox TBIC_No;
        private System.Windows.Forms.TextBox TBIC_To;
        private System.Windows.Forms.TextBox TBIC_Address;
        private System.Windows.Forms.TextBox TBIC_Contact;
        private System.Windows.Forms.Label LIC_Contact;
        private System.Windows.Forms.DateTimePicker DTP_IC_Date;
        private System.Windows.Forms.ComboBox CBIC_Code;
        private System.Windows.Forms.TextBox TBIC_Note;
        private System.Windows.Forms.TextBox TBIC_InWord;
        private System.Windows.Forms.TextBox TBIC_TotalAmount;
        private System.Windows.Forms.TextBox TBIC_SpecialDiscount;
        private System.Windows.Forms.TextBox TBIC_PayableAmount;
        private System.Windows.Forms.TextBox TBIC_Discount;
        private System.Windows.Forms.Button BIC_Save;
        private System.Windows.Forms.Button BIC_Cancel;
        private System.ComponentModel.BackgroundWorker InvoiceBackgroundWorker;
        private System.Windows.Forms.ProgressBar InvoiceProgressBar;
        private System.Windows.Forms.Panel IC_ProgressPanel;
        private System.Windows.Forms.Label LICPP_InProgress;
    }
}
