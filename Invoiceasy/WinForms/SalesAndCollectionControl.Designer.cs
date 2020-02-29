namespace Invoiceasy.WinForms
{
    partial class SalesAndCollectionControl
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
            this.LSAC_Title = new System.Windows.Forms.Label();
            this.DGV_SAC_SalesAndCollectionList = new System.Windows.Forms.DataGridView();
            this.CB_SAC_TimePeriod = new System.Windows.Forms.ComboBox();
            this.LSAC_Search = new System.Windows.Forms.Label();
            this.TB_SAC_Search = new System.Windows.Forms.TextBox();
            this.LSAC_TimePeriod = new System.Windows.Forms.Label();
            this.BSAC_AddNewCollection = new System.Windows.Forms.Button();
            this.CB_SAC_DealerCode = new System.Windows.Forms.ComboBox();
            this.LSAC_DealerCode = new System.Windows.Forms.Label();
            this.CKB_GroupBy = new System.Windows.Forms.CheckBox();
            this.DTP_SAC_FromDate = new System.Windows.Forms.DateTimePicker();
            this.DTP_SAC_ToDate = new System.Windows.Forms.DateTimePicker();
            this.LSAC_FromDate = new System.Windows.Forms.Label();
            this.LSAC_ToDate = new System.Windows.Forms.Label();
            this.BSAC_SaveDaily = new System.Windows.Forms.Button();
            this.BSAC_SavePartyLedger = new System.Windows.Forms.Button();
            this.BSAC_DeleteSOC = new System.Windows.Forms.Button();
            this.SAC_ProgressPanel = new System.Windows.Forms.Panel();
            this.SACProgressBar = new System.Windows.Forms.ProgressBar();
            this.LSACP_InProgress = new System.Windows.Forms.Label();
            this.SACBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.LSAC_PartyName = new System.Windows.Forms.Label();
            this.LSAC_PartyAddress = new System.Windows.Forms.Label();
            this.TB_SAC_PartyName = new System.Windows.Forms.TextBox();
            this.TB_SAC_PartyAddress = new System.Windows.Forms.TextBox();
            this.LSAC_PartyContact = new System.Windows.Forms.Label();
            this.TB_SAC_PartyContact = new System.Windows.Forms.TextBox();
            this.CKB_Ascending = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SAC_SalesAndCollectionList)).BeginInit();
            this.SAC_ProgressPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LSAC_Title
            // 
            this.LSAC_Title.AutoSize = true;
            this.LSAC_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSAC_Title.Location = new System.Drawing.Point(313, 16);
            this.LSAC_Title.Name = "LSAC_Title";
            this.LSAC_Title.Size = new System.Drawing.Size(152, 16);
            this.LSAC_Title.TabIndex = 0;
            this.LSAC_Title.Text = "Sales And Collection";
            // 
            // DGV_SAC_SalesAndCollectionList
            // 
            this.DGV_SAC_SalesAndCollectionList.AllowUserToAddRows = false;
            this.DGV_SAC_SalesAndCollectionList.AllowUserToDeleteRows = false;
            this.DGV_SAC_SalesAndCollectionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_SAC_SalesAndCollectionList.Location = new System.Drawing.Point(12, 184);
            this.DGV_SAC_SalesAndCollectionList.Name = "DGV_SAC_SalesAndCollectionList";
            this.DGV_SAC_SalesAndCollectionList.ReadOnly = true;
            this.DGV_SAC_SalesAndCollectionList.Size = new System.Drawing.Size(745, 390);
            this.DGV_SAC_SalesAndCollectionList.TabIndex = 1;
            // 
            // CB_SAC_TimePeriod
            // 
            this.CB_SAC_TimePeriod.FormattingEnabled = true;
            this.CB_SAC_TimePeriod.Location = new System.Drawing.Point(677, 52);
            this.CB_SAC_TimePeriod.Name = "CB_SAC_TimePeriod";
            this.CB_SAC_TimePeriod.Size = new System.Drawing.Size(80, 21);
            this.CB_SAC_TimePeriod.TabIndex = 2;
            this.CB_SAC_TimePeriod.SelectedIndexChanged += new System.EventHandler(this.CB_SAC_TimePeriod_SelectedIndexChanged);
            // 
            // LSAC_Search
            // 
            this.LSAC_Search.AutoSize = true;
            this.LSAC_Search.Location = new System.Drawing.Point(9, 59);
            this.LSAC_Search.Name = "LSAC_Search";
            this.LSAC_Search.Size = new System.Drawing.Size(50, 13);
            this.LSAC_Search.TabIndex = 3;
            this.LSAC_Search.Text = "Search : ";
            // 
            // TB_SAC_Search
            // 
            this.TB_SAC_Search.Location = new System.Drawing.Point(65, 56);
            this.TB_SAC_Search.Name = "TB_SAC_Search";
            this.TB_SAC_Search.Size = new System.Drawing.Size(212, 20);
            this.TB_SAC_Search.TabIndex = 4;
            this.TB_SAC_Search.TextChanged += new System.EventHandler(this.TB_SAC_Search_TextChanged);
            // 
            // LSAC_TimePeriod
            // 
            this.LSAC_TimePeriod.AutoSize = true;
            this.LSAC_TimePeriod.Location = new System.Drawing.Point(599, 56);
            this.LSAC_TimePeriod.Name = "LSAC_TimePeriod";
            this.LSAC_TimePeriod.Size = new System.Drawing.Size(72, 13);
            this.LSAC_TimePeriod.TabIndex = 5;
            this.LSAC_TimePeriod.Text = "Time Period : ";
            // 
            // BSAC_AddNewCollection
            // 
            this.BSAC_AddNewCollection.Location = new System.Drawing.Point(602, 79);
            this.BSAC_AddNewCollection.Name = "BSAC_AddNewCollection";
            this.BSAC_AddNewCollection.Size = new System.Drawing.Size(155, 33);
            this.BSAC_AddNewCollection.TabIndex = 6;
            this.BSAC_AddNewCollection.Text = "Add New Collection";
            this.BSAC_AddNewCollection.UseVisualStyleBackColor = true;
            this.BSAC_AddNewCollection.Click += new System.EventHandler(this.BSAC_AddNewCollection_Click);
            // 
            // CB_SAC_DealerCode
            // 
            this.CB_SAC_DealerCode.FormattingEnabled = true;
            this.CB_SAC_DealerCode.Location = new System.Drawing.Point(125, 86);
            this.CB_SAC_DealerCode.Name = "CB_SAC_DealerCode";
            this.CB_SAC_DealerCode.Size = new System.Drawing.Size(152, 21);
            this.CB_SAC_DealerCode.TabIndex = 7;
            this.CB_SAC_DealerCode.SelectedIndexChanged += new System.EventHandler(this.CB_SAC_DealerCode_SelectedIndexChanged);
            // 
            // LSAC_DealerCode
            // 
            this.LSAC_DealerCode.AutoSize = true;
            this.LSAC_DealerCode.Location = new System.Drawing.Point(9, 89);
            this.LSAC_DealerCode.Name = "LSAC_DealerCode";
            this.LSAC_DealerCode.Size = new System.Drawing.Size(110, 13);
            this.LSAC_DealerCode.TabIndex = 8;
            this.LSAC_DealerCode.Text = "Dealer / Party Code : ";
            // 
            // CKB_GroupBy
            // 
            this.CKB_GroupBy.AutoSize = true;
            this.CKB_GroupBy.Location = new System.Drawing.Point(344, 113);
            this.CKB_GroupBy.Name = "CKB_GroupBy";
            this.CKB_GroupBy.Size = new System.Drawing.Size(96, 17);
            this.CKB_GroupBy.TabIndex = 9;
            this.CKB_GroupBy.Text = "Group By Date";
            this.CKB_GroupBy.UseVisualStyleBackColor = true;
            this.CKB_GroupBy.CheckedChanged += new System.EventHandler(this.CKB_GroupBy_CheckedChanged);
            // 
            // DTP_SAC_FromDate
            // 
            this.DTP_SAC_FromDate.Location = new System.Drawing.Point(344, 56);
            this.DTP_SAC_FromDate.Name = "DTP_SAC_FromDate";
            this.DTP_SAC_FromDate.Size = new System.Drawing.Size(200, 20);
            this.DTP_SAC_FromDate.TabIndex = 10;
            this.DTP_SAC_FromDate.ValueChanged += new System.EventHandler(this.DTP_SAC_FromDate_ValueChanged);
            // 
            // DTP_SAC_ToDate
            // 
            this.DTP_SAC_ToDate.Location = new System.Drawing.Point(344, 87);
            this.DTP_SAC_ToDate.Name = "DTP_SAC_ToDate";
            this.DTP_SAC_ToDate.Size = new System.Drawing.Size(200, 20);
            this.DTP_SAC_ToDate.TabIndex = 11;
            this.DTP_SAC_ToDate.ValueChanged += new System.EventHandler(this.DTP_SAC_ToDate_ValueChanged);
            // 
            // LSAC_FromDate
            // 
            this.LSAC_FromDate.AutoSize = true;
            this.LSAC_FromDate.Location = new System.Drawing.Point(299, 60);
            this.LSAC_FromDate.Name = "LSAC_FromDate";
            this.LSAC_FromDate.Size = new System.Drawing.Size(39, 13);
            this.LSAC_FromDate.TabIndex = 12;
            this.LSAC_FromDate.Text = "From : ";
            // 
            // LSAC_ToDate
            // 
            this.LSAC_ToDate.AutoSize = true;
            this.LSAC_ToDate.Location = new System.Drawing.Point(309, 93);
            this.LSAC_ToDate.Name = "LSAC_ToDate";
            this.LSAC_ToDate.Size = new System.Drawing.Size(29, 13);
            this.LSAC_ToDate.TabIndex = 13;
            this.LSAC_ToDate.Text = "To : ";
            // 
            // BSAC_SaveDaily
            // 
            this.BSAC_SaveDaily.Location = new System.Drawing.Point(578, 591);
            this.BSAC_SaveDaily.Name = "BSAC_SaveDaily";
            this.BSAC_SaveDaily.Size = new System.Drawing.Size(179, 23);
            this.BSAC_SaveDaily.TabIndex = 14;
            this.BSAC_SaveDaily.Text = "Save Daily Sales And Collections";
            this.BSAC_SaveDaily.UseVisualStyleBackColor = true;
            this.BSAC_SaveDaily.Click += new System.EventHandler(this.BSAC_SaveDaily_Click);
            // 
            // BSAC_SavePartyLedger
            // 
            this.BSAC_SavePartyLedger.Location = new System.Drawing.Point(462, 591);
            this.BSAC_SavePartyLedger.Name = "BSAC_SavePartyLedger";
            this.BSAC_SavePartyLedger.Size = new System.Drawing.Size(110, 23);
            this.BSAC_SavePartyLedger.TabIndex = 15;
            this.BSAC_SavePartyLedger.Text = "Save Party Ledger";
            this.BSAC_SavePartyLedger.UseVisualStyleBackColor = true;
            this.BSAC_SavePartyLedger.Click += new System.EventHandler(this.BSAC_SavePartyLedger_Click);
            // 
            // BSAC_DeleteSOC
            // 
            this.BSAC_DeleteSOC.Location = new System.Drawing.Point(316, 591);
            this.BSAC_DeleteSOC.Name = "BSAC_DeleteSOC";
            this.BSAC_DeleteSOC.Size = new System.Drawing.Size(136, 23);
            this.BSAC_DeleteSOC.TabIndex = 16;
            this.BSAC_DeleteSOC.Text = "Delete Sale / Collection";
            this.BSAC_DeleteSOC.UseVisualStyleBackColor = true;
            this.BSAC_DeleteSOC.Click += new System.EventHandler(this.BSAC_DeleteSOC_Click);
            // 
            // SAC_ProgressPanel
            // 
            this.SAC_ProgressPanel.Controls.Add(this.SACProgressBar);
            this.SAC_ProgressPanel.Controls.Add(this.LSACP_InProgress);
            this.SAC_ProgressPanel.Location = new System.Drawing.Point(221, 184);
            this.SAC_ProgressPanel.Name = "SAC_ProgressPanel";
            this.SAC_ProgressPanel.Size = new System.Drawing.Size(323, 100);
            this.SAC_ProgressPanel.TabIndex = 17;
            this.SAC_ProgressPanel.Visible = false;
            // 
            // SACProgressBar
            // 
            this.SACProgressBar.Location = new System.Drawing.Point(3, 62);
            this.SACProgressBar.Name = "SACProgressBar";
            this.SACProgressBar.Size = new System.Drawing.Size(316, 23);
            this.SACProgressBar.TabIndex = 1;
            this.SACProgressBar.Visible = false;
            // 
            // LSACP_InProgress
            // 
            this.LSACP_InProgress.AutoSize = true;
            this.LSACP_InProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSACP_InProgress.Location = new System.Drawing.Point(48, 23);
            this.LSACP_InProgress.Name = "LSACP_InProgress";
            this.LSACP_InProgress.Size = new System.Drawing.Size(226, 20);
            this.LSACP_InProgress.TabIndex = 0;
            this.LSACP_InProgress.Text = "In Progress... Please Wait!!";
            // 
            // LSAC_PartyName
            // 
            this.LSAC_PartyName.AutoSize = true;
            this.LSAC_PartyName.Location = new System.Drawing.Point(12, 142);
            this.LSAC_PartyName.Name = "LSAC_PartyName";
            this.LSAC_PartyName.Size = new System.Drawing.Size(71, 13);
            this.LSAC_PartyName.TabIndex = 18;
            this.LSAC_PartyName.Text = "Party Name : ";
            // 
            // LSAC_PartyAddress
            // 
            this.LSAC_PartyAddress.AutoSize = true;
            this.LSAC_PartyAddress.Location = new System.Drawing.Point(12, 166);
            this.LSAC_PartyAddress.Name = "LSAC_PartyAddress";
            this.LSAC_PartyAddress.Size = new System.Drawing.Size(54, 13);
            this.LSAC_PartyAddress.TabIndex = 19;
            this.LSAC_PartyAddress.Text = "Address : ";
            // 
            // TB_SAC_PartyName
            // 
            this.TB_SAC_PartyName.Location = new System.Drawing.Point(90, 134);
            this.TB_SAC_PartyName.Name = "TB_SAC_PartyName";
            this.TB_SAC_PartyName.Size = new System.Drawing.Size(187, 20);
            this.TB_SAC_PartyName.TabIndex = 21;
            // 
            // TB_SAC_PartyAddress
            // 
            this.TB_SAC_PartyAddress.Location = new System.Drawing.Point(90, 158);
            this.TB_SAC_PartyAddress.Name = "TB_SAC_PartyAddress";
            this.TB_SAC_PartyAddress.Size = new System.Drawing.Size(454, 20);
            this.TB_SAC_PartyAddress.TabIndex = 22;
            // 
            // LSAC_PartyContact
            // 
            this.LSAC_PartyContact.AutoSize = true;
            this.LSAC_PartyContact.Location = new System.Drawing.Point(285, 137);
            this.LSAC_PartyContact.Name = "LSAC_PartyContact";
            this.LSAC_PartyContact.Size = new System.Drawing.Size(53, 13);
            this.LSAC_PartyContact.TabIndex = 23;
            this.LSAC_PartyContact.Text = "Contact : ";
            // 
            // TB_SAC_PartyContact
            // 
            this.TB_SAC_PartyContact.Location = new System.Drawing.Point(344, 134);
            this.TB_SAC_PartyContact.Name = "TB_SAC_PartyContact";
            this.TB_SAC_PartyContact.Size = new System.Drawing.Size(413, 20);
            this.TB_SAC_PartyContact.TabIndex = 24;
            // 
            // CKB_Ascending
            // 
            this.CKB_Ascending.AutoSize = true;
            this.CKB_Ascending.Location = new System.Drawing.Point(468, 113);
            this.CKB_Ascending.Name = "CKB_Ascending";
            this.CKB_Ascending.Size = new System.Drawing.Size(76, 17);
            this.CKB_Ascending.TabIndex = 25;
            this.CKB_Ascending.Text = "Ascending";
            this.CKB_Ascending.UseVisualStyleBackColor = true;
            this.CKB_Ascending.CheckedChanged += new System.EventHandler(this.CKB_Ascending_CheckedChanged);
            // 
            // SalesAndCollectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CKB_Ascending);
            this.Controls.Add(this.TB_SAC_PartyContact);
            this.Controls.Add(this.LSAC_PartyContact);
            this.Controls.Add(this.TB_SAC_PartyAddress);
            this.Controls.Add(this.TB_SAC_PartyName);
            this.Controls.Add(this.LSAC_PartyAddress);
            this.Controls.Add(this.LSAC_PartyName);
            this.Controls.Add(this.SAC_ProgressPanel);
            this.Controls.Add(this.BSAC_DeleteSOC);
            this.Controls.Add(this.BSAC_SavePartyLedger);
            this.Controls.Add(this.BSAC_SaveDaily);
            this.Controls.Add(this.LSAC_ToDate);
            this.Controls.Add(this.LSAC_FromDate);
            this.Controls.Add(this.DTP_SAC_ToDate);
            this.Controls.Add(this.DTP_SAC_FromDate);
            this.Controls.Add(this.CKB_GroupBy);
            this.Controls.Add(this.LSAC_DealerCode);
            this.Controls.Add(this.CB_SAC_DealerCode);
            this.Controls.Add(this.BSAC_AddNewCollection);
            this.Controls.Add(this.LSAC_TimePeriod);
            this.Controls.Add(this.TB_SAC_Search);
            this.Controls.Add(this.LSAC_Search);
            this.Controls.Add(this.CB_SAC_TimePeriod);
            this.Controls.Add(this.DGV_SAC_SalesAndCollectionList);
            this.Controls.Add(this.LSAC_Title);
            this.Name = "SalesAndCollectionControl";
            this.Size = new System.Drawing.Size(770, 630);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SAC_SalesAndCollectionList)).EndInit();
            this.SAC_ProgressPanel.ResumeLayout(false);
            this.SAC_ProgressPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LSAC_Title;
        private System.Windows.Forms.DataGridView DGV_SAC_SalesAndCollectionList;
        private System.Windows.Forms.ComboBox CB_SAC_TimePeriod;
        private System.Windows.Forms.Label LSAC_Search;
        private System.Windows.Forms.TextBox TB_SAC_Search;
        private System.Windows.Forms.Label LSAC_TimePeriod;
        private System.Windows.Forms.Button BSAC_AddNewCollection;
        private System.Windows.Forms.ComboBox CB_SAC_DealerCode;
        private System.Windows.Forms.Label LSAC_DealerCode;
        private System.Windows.Forms.CheckBox CKB_GroupBy;
        private System.Windows.Forms.DateTimePicker DTP_SAC_FromDate;
        private System.Windows.Forms.DateTimePicker DTP_SAC_ToDate;
        private System.Windows.Forms.Label LSAC_FromDate;
        private System.Windows.Forms.Label LSAC_ToDate;
        private System.Windows.Forms.Button BSAC_SaveDaily;
        private System.Windows.Forms.Button BSAC_SavePartyLedger;
        private System.Windows.Forms.Button BSAC_DeleteSOC;
        private System.Windows.Forms.Panel SAC_ProgressPanel;
        private System.Windows.Forms.Label LSACP_InProgress;
        private System.Windows.Forms.ProgressBar SACProgressBar;
        private System.ComponentModel.BackgroundWorker SACBackgroundWorker;
        private System.Windows.Forms.Label LSAC_PartyName;
        private System.Windows.Forms.Label LSAC_PartyAddress;
        private System.Windows.Forms.TextBox TB_SAC_PartyName;
        private System.Windows.Forms.TextBox TB_SAC_PartyAddress;
        private System.Windows.Forms.Label LSAC_PartyContact;
        private System.Windows.Forms.TextBox TB_SAC_PartyContact;
        private System.Windows.Forms.CheckBox CKB_Ascending;
    }
}
