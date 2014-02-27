namespace PRUI.Forms
{
    partial class ReportsForm
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
            this.createReportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // removeButton
            // 
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(1176, 406);
            // 
            // createReportButton
            // 
            this.createReportButton.Location = new System.Drawing.Point(255, 406);
            this.createReportButton.Name = "createReportButton";
            this.createReportButton.Size = new System.Drawing.Size(100, 23);
            this.createReportButton.TabIndex = 4;
            this.createReportButton.Text = "Создать отчет";
            this.createReportButton.UseVisualStyleBackColor = true;
            this.createReportButton.Click += new System.EventHandler(this.createReportButton_Click);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 437);
            this.Controls.Add(this.createReportButton);
            this.Name = "ReportsForm";
            this.Text = "Список отчетов";
            this.Controls.SetChildIndex(this.removeButton, 0);
            this.Controls.SetChildIndex(this.addButton, 0);
            this.Controls.SetChildIndex(this.editButton, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.createReportButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createReportButton;
    }
}