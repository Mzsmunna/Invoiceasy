namespace Invoiceasy.WinForms
{
    partial class PopupDealerModelControl
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
            this.TB_PMC_DealerName = new System.Windows.Forms.TextBox();
            this.TB_PMC_DealerCode = new System.Windows.Forms.TextBox();
            this.TB_PMC_DealerAddress = new System.Windows.Forms.TextBox();
            this.TB_PMC_DealerContact = new System.Windows.Forms.TextBox();
            this.LPMC_DealerName = new System.Windows.Forms.Label();
            this.LPMC_DealerCode = new System.Windows.Forms.Label();
            this.LPMC_DealerAddress = new System.Windows.Forms.Label();
            this.LPMC_DealerContact = new System.Windows.Forms.Label();
            this.BPMC_AddOrUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LPMC_Title
            // 
            this.LPMC_Title.AutoSize = true;
            this.LPMC_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPMC_Title.Location = new System.Drawing.Point(288, 19);
            this.LPMC_Title.Name = "LPMC_Title";
            this.LPMC_Title.Size = new System.Drawing.Size(151, 16);
            this.LPMC_Title.TabIndex = 0;
            this.LPMC_Title.Text = "Popup Dealer Modal";
            // 
            // TB_PMC_DealerName
            // 
            this.TB_PMC_DealerName.Location = new System.Drawing.Point(118, 77);
            this.TB_PMC_DealerName.Name = "TB_PMC_DealerName";
            this.TB_PMC_DealerName.Size = new System.Drawing.Size(516, 20);
            this.TB_PMC_DealerName.TabIndex = 1;
            // 
            // TB_PMC_DealerCode
            // 
            this.TB_PMC_DealerCode.Location = new System.Drawing.Point(118, 126);
            this.TB_PMC_DealerCode.Name = "TB_PMC_DealerCode";
            this.TB_PMC_DealerCode.Size = new System.Drawing.Size(516, 20);
            this.TB_PMC_DealerCode.TabIndex = 2;
            // 
            // TB_PMC_DealerAddress
            // 
            this.TB_PMC_DealerAddress.Location = new System.Drawing.Point(118, 173);
            this.TB_PMC_DealerAddress.Name = "TB_PMC_DealerAddress";
            this.TB_PMC_DealerAddress.Size = new System.Drawing.Size(516, 20);
            this.TB_PMC_DealerAddress.TabIndex = 3;
            // 
            // TB_PMC_DealerContact
            // 
            this.TB_PMC_DealerContact.Location = new System.Drawing.Point(118, 221);
            this.TB_PMC_DealerContact.Name = "TB_PMC_DealerContact";
            this.TB_PMC_DealerContact.Size = new System.Drawing.Size(516, 20);
            this.TB_PMC_DealerContact.TabIndex = 4;
            // 
            // LPMC_DealerName
            // 
            this.LPMC_DealerName.AutoSize = true;
            this.LPMC_DealerName.Location = new System.Drawing.Point(20, 80);
            this.LPMC_DealerName.Name = "LPMC_DealerName";
            this.LPMC_DealerName.Size = new System.Drawing.Size(78, 13);
            this.LPMC_DealerName.TabIndex = 5;
            this.LPMC_DealerName.Text = "Dealer Name : ";
            // 
            // LPMC_DealerCode
            // 
            this.LPMC_DealerCode.AutoSize = true;
            this.LPMC_DealerCode.Location = new System.Drawing.Point(20, 129);
            this.LPMC_DealerCode.Name = "LPMC_DealerCode";
            this.LPMC_DealerCode.Size = new System.Drawing.Size(75, 13);
            this.LPMC_DealerCode.TabIndex = 6;
            this.LPMC_DealerCode.Text = "Dealer Code : ";
            // 
            // LPMC_DealerAddress
            // 
            this.LPMC_DealerAddress.AutoSize = true;
            this.LPMC_DealerAddress.Location = new System.Drawing.Point(20, 176);
            this.LPMC_DealerAddress.Name = "LPMC_DealerAddress";
            this.LPMC_DealerAddress.Size = new System.Drawing.Size(88, 13);
            this.LPMC_DealerAddress.TabIndex = 7;
            this.LPMC_DealerAddress.Text = "Dealer Address : ";
            // 
            // LPMC_DealerContact
            // 
            this.LPMC_DealerContact.AutoSize = true;
            this.LPMC_DealerContact.Location = new System.Drawing.Point(20, 224);
            this.LPMC_DealerContact.Name = "LPMC_DealerContact";
            this.LPMC_DealerContact.Size = new System.Drawing.Size(87, 13);
            this.LPMC_DealerContact.TabIndex = 8;
            this.LPMC_DealerContact.Text = "Dealer Contact : ";
            // 
            // BPMC_AddOrUpdate
            // 
            this.BPMC_AddOrUpdate.Location = new System.Drawing.Point(540, 272);
            this.BPMC_AddOrUpdate.Name = "BPMC_AddOrUpdate";
            this.BPMC_AddOrUpdate.Size = new System.Drawing.Size(94, 23);
            this.BPMC_AddOrUpdate.TabIndex = 9;
            this.BPMC_AddOrUpdate.Text = "Add Or Update";
            this.BPMC_AddOrUpdate.UseVisualStyleBackColor = true;
            this.BPMC_AddOrUpdate.Click += new System.EventHandler(this.BPMC_AddOrUpdate_Click);
            // 
            // PopupDealerModelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BPMC_AddOrUpdate);
            this.Controls.Add(this.LPMC_DealerContact);
            this.Controls.Add(this.LPMC_DealerAddress);
            this.Controls.Add(this.LPMC_DealerCode);
            this.Controls.Add(this.LPMC_DealerName);
            this.Controls.Add(this.TB_PMC_DealerContact);
            this.Controls.Add(this.TB_PMC_DealerAddress);
            this.Controls.Add(this.TB_PMC_DealerCode);
            this.Controls.Add(this.TB_PMC_DealerName);
            this.Controls.Add(this.LPMC_Title);
            this.Name = "PopupDealerModelControl";
            this.Size = new System.Drawing.Size(659, 313);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LPMC_Title;
        private System.Windows.Forms.TextBox TB_PMC_DealerName;
        private System.Windows.Forms.TextBox TB_PMC_DealerCode;
        private System.Windows.Forms.TextBox TB_PMC_DealerAddress;
        private System.Windows.Forms.TextBox TB_PMC_DealerContact;
        private System.Windows.Forms.Label LPMC_DealerName;
        private System.Windows.Forms.Label LPMC_DealerCode;
        private System.Windows.Forms.Label LPMC_DealerAddress;
        private System.Windows.Forms.Label LPMC_DealerContact;
        private System.Windows.Forms.Button BPMC_AddOrUpdate;
    }
}
