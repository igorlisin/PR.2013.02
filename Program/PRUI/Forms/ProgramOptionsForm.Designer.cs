namespace PRUI.Forms
{
    partial class ProgramOptionsForm
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
            this.browseImagesFolderPathButton = new System.Windows.Forms.Button();
            this.imagesFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.imagesFolderPathLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.reportTemplatesFolderPathLabel = new System.Windows.Forms.Label();
            this.reportTemplatesFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.browseReportTemplatesFolderPathButton = new System.Windows.Forms.Button();
            this.reportsFolderPathLabel = new System.Windows.Forms.Label();
            this.reportsFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.browseReportsFolderPathButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(609, 454);
            // 
            // browseImagesFolderPathButton
            // 
            this.browseImagesFolderPathButton.Location = new System.Drawing.Point(609, 24);
            this.browseImagesFolderPathButton.Name = "browseImagesFolderPathButton";
            this.browseImagesFolderPathButton.Size = new System.Drawing.Size(75, 22);
            this.browseImagesFolderPathButton.TabIndex = 7;
            this.browseImagesFolderPathButton.Text = "Обзор";
            this.browseImagesFolderPathButton.UseVisualStyleBackColor = true;
            this.browseImagesFolderPathButton.Click += new System.EventHandler(this.browseImagesFolderPathButton_Click);
            // 
            // imagesFolderPathTextBox
            // 
            this.imagesFolderPathTextBox.Enabled = false;
            this.imagesFolderPathTextBox.Location = new System.Drawing.Point(15, 25);
            this.imagesFolderPathTextBox.Name = "imagesFolderPathTextBox";
            this.imagesFolderPathTextBox.Size = new System.Drawing.Size(588, 20);
            this.imagesFolderPathTextBox.TabIndex = 6;
            // 
            // imagesFolderPathLabel
            // 
            this.imagesFolderPathLabel.AutoSize = true;
            this.imagesFolderPathLabel.Location = new System.Drawing.Point(12, 9);
            this.imagesFolderPathLabel.Name = "imagesFolderPathLabel";
            this.imagesFolderPathLabel.Size = new System.Drawing.Size(77, 13);
            this.imagesFolderPathLabel.TabIndex = 5;
            this.imagesFolderPathLabel.Text = "Изображения";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 454);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(93, 454);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // reportTemplatesFolderPathLabel
            // 
            this.reportTemplatesFolderPathLabel.AutoSize = true;
            this.reportTemplatesFolderPathLabel.Location = new System.Drawing.Point(12, 48);
            this.reportTemplatesFolderPathLabel.Name = "reportTemplatesFolderPathLabel";
            this.reportTemplatesFolderPathLabel.Size = new System.Drawing.Size(96, 13);
            this.reportTemplatesFolderPathLabel.TabIndex = 8;
            this.reportTemplatesFolderPathLabel.Text = "Шаблоны отчетов";
            // 
            // reportTemplatesFolderPathTextBox
            // 
            this.reportTemplatesFolderPathTextBox.Enabled = false;
            this.reportTemplatesFolderPathTextBox.Location = new System.Drawing.Point(15, 64);
            this.reportTemplatesFolderPathTextBox.Name = "reportTemplatesFolderPathTextBox";
            this.reportTemplatesFolderPathTextBox.Size = new System.Drawing.Size(588, 20);
            this.reportTemplatesFolderPathTextBox.TabIndex = 9;
            // 
            // browseReportTemplatesFolderPathButton
            // 
            this.browseReportTemplatesFolderPathButton.Location = new System.Drawing.Point(609, 63);
            this.browseReportTemplatesFolderPathButton.Name = "browseReportTemplatesFolderPathButton";
            this.browseReportTemplatesFolderPathButton.Size = new System.Drawing.Size(75, 22);
            this.browseReportTemplatesFolderPathButton.TabIndex = 10;
            this.browseReportTemplatesFolderPathButton.Text = "Обзор";
            this.browseReportTemplatesFolderPathButton.UseVisualStyleBackColor = true;
            this.browseReportTemplatesFolderPathButton.Click += new System.EventHandler(this.browseReportTemplatesFolderPathButton_Click);
            // 
            // reportsFolderPathLabel
            // 
            this.reportsFolderPathLabel.AutoSize = true;
            this.reportsFolderPathLabel.Location = new System.Drawing.Point(12, 87);
            this.reportsFolderPathLabel.Name = "reportsFolderPathLabel";
            this.reportsFolderPathLabel.Size = new System.Drawing.Size(44, 13);
            this.reportsFolderPathLabel.TabIndex = 11;
            this.reportsFolderPathLabel.Text = "Отчеты";
            // 
            // reportsFolderPathTextBox
            // 
            this.reportsFolderPathTextBox.Enabled = false;
            this.reportsFolderPathTextBox.Location = new System.Drawing.Point(15, 103);
            this.reportsFolderPathTextBox.Name = "reportsFolderPathTextBox";
            this.reportsFolderPathTextBox.Size = new System.Drawing.Size(588, 20);
            this.reportsFolderPathTextBox.TabIndex = 12;
            // 
            // browseReportsFolderPathButton
            // 
            this.browseReportsFolderPathButton.Location = new System.Drawing.Point(609, 102);
            this.browseReportsFolderPathButton.Name = "browseReportsFolderPathButton";
            this.browseReportsFolderPathButton.Size = new System.Drawing.Size(75, 22);
            this.browseReportsFolderPathButton.TabIndex = 13;
            this.browseReportsFolderPathButton.Text = "Обзор";
            this.browseReportsFolderPathButton.UseVisualStyleBackColor = true;
            this.browseReportsFolderPathButton.Click += new System.EventHandler(this.browseReportsFolderPathButton_Click);
            // 
            // ProgramOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 489);
            this.Controls.Add(this.browseReportsFolderPathButton);
            this.Controls.Add(this.reportsFolderPathTextBox);
            this.Controls.Add(this.reportsFolderPathLabel);
            this.Controls.Add(this.browseReportTemplatesFolderPathButton);
            this.Controls.Add(this.reportTemplatesFolderPathTextBox);
            this.Controls.Add(this.reportTemplatesFolderPathLabel);
            this.Controls.Add(this.browseImagesFolderPathButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.imagesFolderPathTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.imagesFolderPathLabel);
            this.Name = "ProgramOptionsForm";
            this.Text = "Настройки программы";
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.imagesFolderPathLabel, 0);
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.imagesFolderPathTextBox, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.browseImagesFolderPathButton, 0);
            this.Controls.SetChildIndex(this.reportTemplatesFolderPathLabel, 0);
            this.Controls.SetChildIndex(this.reportTemplatesFolderPathTextBox, 0);
            this.Controls.SetChildIndex(this.browseReportTemplatesFolderPathButton, 0);
            this.Controls.SetChildIndex(this.reportsFolderPathLabel, 0);
            this.Controls.SetChildIndex(this.reportsFolderPathTextBox, 0);
            this.Controls.SetChildIndex(this.browseReportsFolderPathButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox imagesFolderPathTextBox;
        private System.Windows.Forms.Label imagesFolderPathLabel;
        protected System.Windows.Forms.Button okButton;
        protected System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button browseImagesFolderPathButton;
        private System.Windows.Forms.Label reportTemplatesFolderPathLabel;
        private System.Windows.Forms.TextBox reportTemplatesFolderPathTextBox;
        private System.Windows.Forms.Button browseReportTemplatesFolderPathButton;
        private System.Windows.Forms.Label reportsFolderPathLabel;
        private System.Windows.Forms.TextBox reportsFolderPathTextBox;
        private System.Windows.Forms.Button browseReportsFolderPathButton;
    }
}