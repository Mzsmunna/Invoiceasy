namespace Invoiceasy.WinForms
{
    partial class PopupCollectionModelControl
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
            this.LPMC_Title = new System.Windows.Forms.Label();
            this.TB_PMC_MR_No = new System.Windows.Forms.TextBox();
            this.TB_PMC_IC_No = new System.Windows.Forms.TextBox();
            this.TB_PMC_CollectionAmount = new System.Windows.Forms.TextBox();
            this.LPMC_MR_No = new System.Windows.Forms.Label();
            this.LPMC_IC_No = new System.Windows.Forms.Label();
            this.LPMC_CollectionAmount = new System.Windows.Forms.Label();
            this.BPMC_Add = new System.Windows.Forms.Button();
            this.CB_PMC_SelectDealer = new System.Windows.Forms.ComboBox();
            this.LPMC_SelectDealer = new System.Windows.Forms.Label();
            this.DTP_PMC_Date = new System.Windows.Forms.DateTimePicker();
            this.LPMC_Date = new System.Windows.Forms.Label();
            this.LPMC_Remark = new System.Windows.Forms.Label();
            this.TB_PMC_Remark = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LPMC_Title
            // 
            this.LPMC_Title.AutoSize = true;
            this.LPMC_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPMC_Title.Location = new System.Drawing.Point(288, 19);
            this.LPMC_Title.Name = "LPMC_Title";
            this.LPMC_Title.Size = new System.Drawing.Size(173, 16);
            this.LPMC_Title.TabIndex = 0;
            this.LPMC_Title.Text = "Popup Collection Modal";
            // 
            // TB_PMC_MR_No
            // 
            this.TB_PMC_MR_No.Location = new System.Drawing.Point(128, 124);
            this.TB_PMC_MR_No.Name = "TB_PMC_MR_No";
            this.TB_PMC_MR_No.Size = new System.Drawing.Size(506, 20);
            this.TB_PMC_MR_No.TabIndex = 1;
            // 
            // TB_PMC_IC_No
            // 
            this.TB_PMC_IC_No.Location = new System.Drawing.Point(128, 161);
            this.TB_PMC_IC_No.Name = "TB_PMC_IC_No";
            this.TB_PMC_IC_No.Size = new System.Drawing.Size(506, 20);
            this.TB_PMC_IC_No.TabIndex = 2;
            // 
            // TB_PMC_CollectionAmount
            // 
            this.TB_PMC_CollectionAmount.Location = new System.Drawing.Point(128, 194);
            this.TB_PMC_CollectionAmount.Name = "TB_PMC_CollectionAmount";
            this.TB_PMC_CollectionAmount.Size = new System.Drawing.Size(506, 20);
            this.TB_PMC_CollectionAmount.TabIndex = 3;
            this.TB_PMC_CollectionAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_PMC_CollectionAmount_KeyPress);
            // 
            // LPMC_MR_No
            // 
            this.LPMC_MR_No.AutoSize = true;
            this.LPMC_MR_No.Location = new System.Drawing.Point(27, 131);
            this.LPMC_MR_No.Name = "LPMC_MR_No";
            this.LPMC_MR_No.Size = new System.Drawing.Size(50, 13);
            this.LPMC_MR_No.TabIndex = 5;
            this.LPMC_MR_No.Text = "MR No : ";
            // 
            // LPMC_IC_No
            // 
            this.LPMC_IC_No.AutoSize = true;
            this.LPMC_IC_No.Location = new System.Drawing.Point(27, 168);
            this.LPMC_IC_No.Name = "LPMC_IC_No";
            this.LPMC_IC_No.Size = new System.Drawing.Size(43, 13);
            this.LPMC_IC_No.TabIndex = 6;
            this.LPMC_IC_No.Text = "IC No : ";
            // 
            // LPMC_CollectionAmount
            // 
            this.LPMC_CollectionAmount.AutoSize = true;
            this.LPMC_CollectionAmount.Location = new System.Drawing.Point(27, 201);
            this.LPMC_CollectionAmount.Name = "LPMC_CollectionAmount";
            this.LPMC_CollectionAmount.Size = new System.Drawing.Size(98, 13);
            this.LPMC_CollectionAmount.TabIndex = 7;
            this.LPMC_CollectionAmount.Text = "Collection Amount :";
            // 
            // BPMC_Add
            // 
            this.BPMC_Add.Location = new System.Drawing.Point(540, 270);
            this.BPMC_Add.Name = "BPMC_Add";
            this.BPMC_Add.Size = new System.Drawing.Size(94, 23);
            this.BPMC_Add.TabIndex = 9;
            this.BPMC_Add.Text = "Add";
            this.BPMC_Add.UseVisualStyleBackColor = true;
            this.BPMC_Add.Click += new System.EventHandler(this.BPMC_AddOrUpdate_Click);
            // 
            // CB_PMC_SelectDealer
            // 
            this.CB_PMC_SelectDealer.FormattingEnabled = true;
            this.CB_PMC_SelectDealer.Location = new System.Drawing.Point(128, 78);
            this.CB_PMC_SelectDealer.Name = "CB_PMC_SelectDealer";
            this.CB_PMC_SelectDealer.Size = new System.Drawing.Size(145, 21);
            this.CB_PMC_SelectDealer.TabIndex = 10;
            this.CB_PMC_SelectDealer.SelectedIndexChanged += new System.EventHandler(this.CB_PMC_SelectDealer_SelectedIndexChanged);
            // 
            // LPMC_SelectDealer
            // 
            this.LPMC_SelectDealer.AutoSize = true;
            this.LPMC_SelectDealer.Location = new System.Drawing.Point(27, 83);
            this.LPMC_SelectDealer.Name = "LPMC_SelectDealer";
            this.LPMC_SelectDealer.Size = new System.Drawing.Size(80, 13);
            this.LPMC_SelectDealer.TabIndex = 11;
            this.LPMC_SelectDealer.Text = "Select Dealer : ";
            // 
            // DTP_PMC_Date
            // 
            this.DTP_PMC_Date.Location = new System.Drawing.Point(434, 79);
            this.DTP_PMC_Date.Name = "DTP_PMC_Date";
            this.DTP_PMC_Date.Size = new System.Drawing.Size(200, 20);
            this.DTP_PMC_Date.TabIndex = 12;
            // 
            // LPMC_Date
            // 
            this.LPMC_Date.AutoSize = true;
            this.LPMC_Date.Location = new System.Drawing.Point(340, 81);
            this.LPMC_Date.Name = "LPMC_Date";
            this.LPMC_Date.Size = new System.Drawing.Size(88, 13);
            this.LPMC_Date.TabIndex = 13;
            this.LPMC_Date.Text = "Collection Date : ";
            // 
            // LPMC_Remark
            // 
            this.LPMC_Remark.AutoSize = true;
            this.LPMC_Remark.Location = new System.Drawing.Point(27, 236);
            this.LPMC_Remark.Name = "LPMC_Remark";
            this.LPMC_Remark.Size = new System.Drawing.Size(58, 13);
            this.LPMC_Remark.TabIndex = 14;
            this.LPMC_Remark.Text = "Remarks : ";
            // 
            // TB_PMC_Remark
            // 
            this.TB_PMC_Remark.Location = new System.Drawing.Point(128, 229);
            this.TB_PMC_Remark.Name = "TB_PMC_Remark";
            this.TB_PMC_Remark.Size = new System.Drawing.Size(506, 20);
            this.TB_PMC_Remark.TabIndex = 15;
            // 
            // PopupCollectionModelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TB_PMC_Remark);
            this.Controls.Add(this.LPMC_Remark);
            this.Controls.Add(this.LPMC_Date);
            this.Controls.Add(this.DTP_PMC_Date);
            this.Controls.Add(this.LPMC_SelectDealer);
            this.Controls.Add(this.CB_PMC_SelectDealer);
            this.Controls.Add(this.BPMC_Add);
            this.Controls.Add(this.LPMC_CollectionAmount);
            this.Controls.Add(this.LPMC_IC_No);
            this.Controls.Add(this.LPMC_MR_No);
            this.Controls.Add(this.TB_PMC_CollectionAmount);
            this.Controls.Add(this.TB_PMC_IC_No);
            this.Controls.Add(this.TB_PMC_MR_No);
            this.Controls.Add(this.LPMC_Title);
            this.Name = "PopupCollectionModelControl";
            this.Size = new System.Drawing.Size(659, 314);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LPMC_Title;
        private System.Windows.Forms.TextBox TB_PMC_MR_No;
        private System.Windows.Forms.TextBox TB_PMC_IC_No;
        private System.Windows.Forms.TextBox TB_PMC_CollectionAmount;
        private System.Windows.Forms.Label LPMC_MR_No;
        private System.Windows.Forms.Label LPMC_IC_No;
        private System.Windows.Forms.Label LPMC_CollectionAmount;
        private System.Windows.Forms.Button BPMC_Add;
        private System.Windows.Forms.ComboBox CB_PMC_SelectDealer;
        private System.Windows.Forms.Label LPMC_SelectDealer;
        private System.Windows.Forms.DateTimePicker DTP_PMC_Date;
        private System.Windows.Forms.Label LPMC_Date;
        private System.Windows.Forms.Label LPMC_Remark;
        private System.Windows.Forms.TextBox TB_PMC_Remark;
    }
}
