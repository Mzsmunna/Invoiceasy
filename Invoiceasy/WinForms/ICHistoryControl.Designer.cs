namespace Invoiceasy.WinForms
{
    partial class ICHistoryControl
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
            this.LV_ICHC_InvoiceLog = new System.Windows.Forms.ListView();
            this.LICHC_Title = new System.Windows.Forms.Label();
            this.BICHC_Delete = new System.Windows.Forms.Button();
            this.BICHC_ExcellOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LV_ICHC_InvoiceLog
            // 
            this.LV_ICHC_InvoiceLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LV_ICHC_InvoiceLog.HideSelection = false;
            this.LV_ICHC_InvoiceLog.Location = new System.Drawing.Point(16, 62);
            this.LV_ICHC_InvoiceLog.Name = "LV_ICHC_InvoiceLog";
            this.LV_ICHC_InvoiceLog.Size = new System.Drawing.Size(734, 528);
            this.LV_ICHC_InvoiceLog.TabIndex = 0;
            this.LV_ICHC_InvoiceLog.UseCompatibleStateImageBehavior = false;
            this.LV_ICHC_InvoiceLog.DoubleClick += new System.EventHandler(this.LV_IHC_InvoiceLog_DoubleClick);
            // 
            // LICHC_Title
            // 
            this.LICHC_Title.AutoSize = true;
            this.LICHC_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LICHC_Title.Location = new System.Drawing.Point(333, 18);
            this.LICHC_Title.Name = "LICHC_Title";
            this.LICHC_Title.Size = new System.Drawing.Size(100, 20);
            this.LICHC_Title.TabIndex = 1;
            this.LICHC_Title.Text = "All Invoices";
            // 
            // BICHC_Delete
            // 
            this.BICHC_Delete.Location = new System.Drawing.Point(562, 597);
            this.BICHC_Delete.Name = "BICHC_Delete";
            this.BICHC_Delete.Size = new System.Drawing.Size(86, 31);
            this.BICHC_Delete.TabIndex = 2;
            this.BICHC_Delete.Text = "Delete File";
            this.BICHC_Delete.UseVisualStyleBackColor = true;
            this.BICHC_Delete.Click += new System.EventHandler(this.BICHC_Delete_Click);
            // 
            // BICHC_ExcellOpen
            // 
            this.BICHC_ExcellOpen.Location = new System.Drawing.Point(654, 597);
            this.BICHC_ExcellOpen.Name = "BICHC_ExcellOpen";
            this.BICHC_ExcellOpen.Size = new System.Drawing.Size(96, 29);
            this.BICHC_ExcellOpen.TabIndex = 3;
            this.BICHC_ExcellOpen.Text = "Open in Excell";
            this.BICHC_ExcellOpen.UseVisualStyleBackColor = true;
            this.BICHC_ExcellOpen.Click += new System.EventHandler(this.BICHC_ExcellOpen_Click);
            // 
            // ICHistoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BICHC_ExcellOpen);
            this.Controls.Add(this.BICHC_Delete);
            this.Controls.Add(this.LICHC_Title);
            this.Controls.Add(this.LV_ICHC_InvoiceLog);
            this.Name = "ICHistoryControl";
            this.Size = new System.Drawing.Size(770, 630);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LV_ICHC_InvoiceLog;
        private System.Windows.Forms.Label LICHC_Title;
        private System.Windows.Forms.Button BICHC_Delete;
        private System.Windows.Forms.Button BICHC_ExcellOpen;
    }
}
