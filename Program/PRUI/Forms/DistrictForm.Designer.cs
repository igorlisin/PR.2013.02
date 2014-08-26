namespace PRUI.Forms
{
    partial class DistrictForm
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
            this.DistrictNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PrestigeComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.regionInfoGroup.SuspendLayout();
            this.countryInfoGroup.SuspendLayout();
            this.homeInfoGroupBox.SuspendLayout();
            this.complexInfoGroupBox.SuspendLayout();
            this.streetInfoGroupBox.SuspendLayout();
            this.cityInfoGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.idInfoGroup.SuspendLayout();
            this.descriptionInfoGroup.SuspendLayout();
            this.noteInfoGroup.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // regionNameTextBox
            // 
            this.regionNameTextBox.Enabled = false;
            // 
            // countryNameTextBox
            // 
            this.countryNameTextBox.Enabled = false;
            // 
            // homeInfoGroupBox
            // 
            this.homeInfoGroupBox.Visible = false;
            // 
            // complexInfoGroupBox
            // 
            this.complexInfoGroupBox.Visible = false;
            // 
            // streetInfoGroupBox
            // 
            this.streetInfoGroupBox.Visible = false;
            // 
            // cityNameTextBox
            // 
            this.cityNameTextBox.Enabled = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.SetChildIndex(this.tabPage2, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPage1, 0);
            // 
            // DistrictNameTextBox
            // 
            this.DistrictNameTextBox.Location = new System.Drawing.Point(19, 31);
            this.DistrictNameTextBox.Name = "DistrictNameTextBox";
            this.DistrictNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.DistrictNameTextBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Название";
            // 
            // PrestigeComboBox
            // 
            this.PrestigeComboBox.FormattingEnabled = true;
            this.PrestigeComboBox.Location = new System.Drawing.Point(24, 367);
            this.PrestigeComboBox.Name = "PrestigeComboBox";
            this.PrestigeComboBox.Size = new System.Drawing.Size(121, 21);
            this.PrestigeComboBox.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 348);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Престижность";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PrestigeComboBox);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.DistrictNameTextBox);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(379, 428);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Особенности района";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DistrictForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 515);
            this.Name = "DistrictForm";
            this.Text = "Район";
            this.regionInfoGroup.ResumeLayout(false);
            this.regionInfoGroup.PerformLayout();
            this.countryInfoGroup.ResumeLayout(false);
            this.countryInfoGroup.PerformLayout();
            this.homeInfoGroupBox.ResumeLayout(false);
            this.homeInfoGroupBox.PerformLayout();
            this.complexInfoGroupBox.ResumeLayout(false);
            this.complexInfoGroupBox.PerformLayout();
            this.streetInfoGroupBox.ResumeLayout(false);
            this.streetInfoGroupBox.PerformLayout();
            this.cityInfoGroupBox.ResumeLayout(false);
            this.cityInfoGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.idInfoGroup.ResumeLayout(false);
            this.idInfoGroup.PerformLayout();
            this.descriptionInfoGroup.ResumeLayout(false);
            this.descriptionInfoGroup.PerformLayout();
            this.noteInfoGroup.ResumeLayout(false);
            this.noteInfoGroup.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox DistrictNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PrestigeComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage2;
    }
}