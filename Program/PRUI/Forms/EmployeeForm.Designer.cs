namespace PRUI.Forms
{
    partial class EmployeeForm
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
            this.employeeInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.worktimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.worktimeLabel = new System.Windows.Forms.Label();
            this.insuranceTextBox = new System.Windows.Forms.TextBox();
            this.insuranceLabel = new System.Windows.Forms.Label();
            this.membershipTextBox = new System.Windows.Forms.TextBox();
            this.membershipLabel = new System.Windows.Forms.Label();
            this.furtherEducationTextBox = new System.Windows.Forms.TextBox();
            this.furtherEducationLabel = new System.Windows.Forms.Label();
            this.positionTextBox = new System.Windows.Forms.TextBox();
            this.positionLabel = new System.Windows.Forms.Label();
            this.documentInfoGroup.SuspendLayout();
            this.manInfoGroup.SuspendLayout();
            this.idInfoGroup.SuspendLayout();
            this.descriptionInfoGroup.SuspendLayout();
            this.noteInfoGroup.SuspendLayout();
            this.employeeInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.worktimeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // documentTypeComboBox
            // 
            this.documentTypeComboBox.Enabled = false;
            this.documentTypeComboBox.Size = new System.Drawing.Size(261, 21);
            // 
            // documentPlaceOfIssueTextBox
            // 
            this.documentPlaceOfIssueTextBox.Enabled = false;
            // 
            // documentDateOfIssueTextBox
            // 
            this.documentDateOfIssueTextBox.Enabled = false;
            // 
            // documentNumberTextBox
            // 
            this.documentNumberTextBox.Enabled = false;
            // 
            // documentSeriesTextBox
            // 
            this.documentSeriesTextBox.Enabled = false;
            // 
            // manPatronymicTextBox
            // 
            this.manPatronymicTextBox.Enabled = false;
            // 
            // manNameTextBox
            // 
            this.manNameTextBox.Enabled = false;
            // 
            // manSurnameTextBox
            // 
            this.manSurnameTextBox.Enabled = false;
            // 
            // relinkDocumentButton
            // 
            this.relinkDocumentButton.Visible = false;
            // 
            // unlinkDocumentButton
            // 
            this.unlinkDocumentButton.Visible = false;
            // 
            // idInfoGroup
            // 
            this.idInfoGroup.Location = new System.Drawing.Point(645, 12);
            // 
            // descriptionInfoGroup
            // 
            this.descriptionInfoGroup.Location = new System.Drawing.Point(645, 65);
            // 
            // noteInfoGroup
            // 
            this.noteInfoGroup.Location = new System.Drawing.Point(645, 341);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(863, 447);
            // 
            // employeeInfoGroupBox
            // 
            this.employeeInfoGroupBox.Controls.Add(this.worktimeNumericUpDown);
            this.employeeInfoGroupBox.Controls.Add(this.worktimeLabel);
            this.employeeInfoGroupBox.Controls.Add(this.insuranceTextBox);
            this.employeeInfoGroupBox.Controls.Add(this.insuranceLabel);
            this.employeeInfoGroupBox.Controls.Add(this.membershipTextBox);
            this.employeeInfoGroupBox.Controls.Add(this.membershipLabel);
            this.employeeInfoGroupBox.Controls.Add(this.furtherEducationTextBox);
            this.employeeInfoGroupBox.Controls.Add(this.furtherEducationLabel);
            this.employeeInfoGroupBox.Controls.Add(this.positionTextBox);
            this.employeeInfoGroupBox.Controls.Add(this.positionLabel);
            this.employeeInfoGroupBox.Location = new System.Drawing.Point(294, 12);
            this.employeeInfoGroupBox.Name = "employeeInfoGroupBox";
            this.employeeInfoGroupBox.Size = new System.Drawing.Size(345, 429);
            this.employeeInfoGroupBox.TabIndex = 34;
            this.employeeInfoGroupBox.TabStop = false;
            this.employeeInfoGroupBox.Text = "Информация о сотруднике";
            // 
            // worktimeNumericUpDown
            // 
            this.worktimeNumericUpDown.Location = new System.Drawing.Point(9, 363);
            this.worktimeNumericUpDown.Name = "worktimeNumericUpDown";
            this.worktimeNumericUpDown.Size = new System.Drawing.Size(62, 20);
            this.worktimeNumericUpDown.TabIndex = 35;
            // 
            // worktimeLabel
            // 
            this.worktimeLabel.AutoSize = true;
            this.worktimeLabel.Location = new System.Drawing.Point(6, 347);
            this.worktimeLabel.Name = "worktimeLabel";
            this.worktimeLabel.Size = new System.Drawing.Size(211, 13);
            this.worktimeLabel.TabIndex = 35;
            this.worktimeLabel.Text = "Стаж работы в оценочной деятельности";
            // 
            // insuranceTextBox
            // 
            this.insuranceTextBox.Location = new System.Drawing.Point(9, 285);
            this.insuranceTextBox.Multiline = true;
            this.insuranceTextBox.Name = "insuranceTextBox";
            this.insuranceTextBox.Size = new System.Drawing.Size(330, 59);
            this.insuranceTextBox.TabIndex = 7;
            // 
            // insuranceLabel
            // 
            this.insuranceLabel.Location = new System.Drawing.Point(6, 254);
            this.insuranceLabel.Name = "insuranceLabel";
            this.insuranceLabel.Size = new System.Drawing.Size(263, 28);
            this.insuranceLabel.TabIndex = 6;
            this.insuranceLabel.Text = "Сведения об обязательном страховании гражданской ответственности";
            // 
            // membershipTextBox
            // 
            this.membershipTextBox.Location = new System.Drawing.Point(9, 192);
            this.membershipTextBox.Multiline = true;
            this.membershipTextBox.Name = "membershipTextBox";
            this.membershipTextBox.Size = new System.Drawing.Size(330, 59);
            this.membershipTextBox.TabIndex = 5;
            // 
            // membershipLabel
            // 
            this.membershipLabel.Location = new System.Drawing.Point(6, 161);
            this.membershipLabel.Name = "membershipLabel";
            this.membershipLabel.Size = new System.Drawing.Size(263, 28);
            this.membershipLabel.TabIndex = 4;
            this.membershipLabel.Text = "Информация о членстве в саморегулируемой организации оценщиков";
            // 
            // furtherEducationTextBox
            // 
            this.furtherEducationTextBox.Location = new System.Drawing.Point(9, 99);
            this.furtherEducationTextBox.Multiline = true;
            this.furtherEducationTextBox.Name = "furtherEducationTextBox";
            this.furtherEducationTextBox.Size = new System.Drawing.Size(330, 59);
            this.furtherEducationTextBox.TabIndex = 3;
            // 
            // furtherEducationLabel
            // 
            this.furtherEducationLabel.Location = new System.Drawing.Point(6, 55);
            this.furtherEducationLabel.Name = "furtherEducationLabel";
            this.furtherEducationLabel.Size = new System.Drawing.Size(263, 41);
            this.furtherEducationLabel.TabIndex = 2;
            this.furtherEducationLabel.Text = "Сведения о документе, подтверждающем получение профессиональных знаний в области " +
    "оценочной деятельности";
            // 
            // positionTextBox
            // 
            this.positionTextBox.Location = new System.Drawing.Point(9, 32);
            this.positionTextBox.Name = "positionTextBox";
            this.positionTextBox.Size = new System.Drawing.Size(330, 20);
            this.positionTextBox.TabIndex = 1;
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Location = new System.Drawing.Point(6, 16);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(65, 13);
            this.positionLabel.TabIndex = 0;
            this.positionLabel.Text = "Должность";
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 475);
            this.Controls.Add(this.employeeInfoGroupBox);
            this.Name = "EmployeeForm";
            this.Text = "Сотрудник";
            this.Controls.SetChildIndex(this.documentInfoGroup, 0);
            this.Controls.SetChildIndex(this.manInfoGroup, 0);
            this.Controls.SetChildIndex(this.noteInfoGroup, 0);
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.idInfoGroup, 0);
            this.Controls.SetChildIndex(this.descriptionInfoGroup, 0);
            this.Controls.SetChildIndex(this.employeeInfoGroupBox, 0);
            this.documentInfoGroup.ResumeLayout(false);
            this.documentInfoGroup.PerformLayout();
            this.manInfoGroup.ResumeLayout(false);
            this.manInfoGroup.PerformLayout();
            this.idInfoGroup.ResumeLayout(false);
            this.idInfoGroup.PerformLayout();
            this.descriptionInfoGroup.ResumeLayout(false);
            this.descriptionInfoGroup.PerformLayout();
            this.noteInfoGroup.ResumeLayout(false);
            this.noteInfoGroup.PerformLayout();
            this.employeeInfoGroupBox.ResumeLayout(false);
            this.employeeInfoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.worktimeNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox employeeInfoGroupBox;
        private System.Windows.Forms.TextBox positionTextBox;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.Label furtherEducationLabel;
        private System.Windows.Forms.Label membershipLabel;
        private System.Windows.Forms.TextBox furtherEducationTextBox;
        private System.Windows.Forms.Label insuranceLabel;
        private System.Windows.Forms.TextBox membershipTextBox;
        private System.Windows.Forms.TextBox insuranceTextBox;
        private System.Windows.Forms.Label worktimeLabel;
        private System.Windows.Forms.NumericUpDown worktimeNumericUpDown;
    }
}