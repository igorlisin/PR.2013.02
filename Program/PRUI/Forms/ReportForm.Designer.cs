namespace PRUI.Forms
{
    partial class ReportForm
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
            this.clientInfoGroup = new System.Windows.Forms.GroupBox();
            this.relinkClientButton = new System.Windows.Forms.Button();
            this.unlinkClientButton = new System.Windows.Forms.Button();
            this.clientNameLabel = new System.Windows.Forms.Label();
            this.clientPatronymicTextBox = new System.Windows.Forms.TextBox();
            this.clientNameTextBox = new System.Windows.Forms.TextBox();
            this.clientSurnameLabel = new System.Windows.Forms.Label();
            this.clientPatronymicLabel = new System.Windows.Forms.Label();
            this.clientSurnameTextBox = new System.Windows.Forms.TextBox();
            this.employeeInfoGroup = new System.Windows.Forms.GroupBox();
            this.relinkEmployeeButton = new System.Windows.Forms.Button();
            this.unlinkEmployeeButton = new System.Windows.Forms.Button();
            this.employeeNameLabel = new System.Windows.Forms.Label();
            this.employeePatronymicTextBox = new System.Windows.Forms.TextBox();
            this.employeeNameText = new System.Windows.Forms.TextBox();
            this.employeeSurnameLabel = new System.Windows.Forms.Label();
            this.employeePatronymicLabel = new System.Windows.Forms.Label();
            this.employeeSurnameTextBox = new System.Windows.Forms.TextBox();
            this.reportInfoGroup = new System.Windows.Forms.GroupBox();
            this.reportDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.reportDateLabel = new System.Windows.Forms.Label();
            this.evaluationDateLabel = new System.Windows.Forms.Label();
            this.evaluationDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.reportNumberTextBox = new System.Windows.Forms.TextBox();
            this.reportNumberLabel = new System.Windows.Forms.Label();
            this.idInfoGroup.SuspendLayout();
            this.descriptionInfoGroup.SuspendLayout();
            this.noteInfoGroup.SuspendLayout();
            this.clientInfoGroup.SuspendLayout();
            this.employeeInfoGroup.SuspendLayout();
            this.reportInfoGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(93, 583);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 583);
            // 
            // idInfoGroup
            // 
            this.idInfoGroup.Location = new System.Drawing.Point(995, 12);
            // 
            // descriptionInfoGroup
            // 
            this.descriptionInfoGroup.Location = new System.Drawing.Point(995, 65);
            // 
            // noteInfoGroup
            // 
            this.noteInfoGroup.Location = new System.Drawing.Point(995, 341);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(1214, 447);
            // 
            // clientInfoGroup
            // 
            this.clientInfoGroup.Controls.Add(this.relinkClientButton);
            this.clientInfoGroup.Controls.Add(this.unlinkClientButton);
            this.clientInfoGroup.Controls.Add(this.clientNameLabel);
            this.clientInfoGroup.Controls.Add(this.clientPatronymicTextBox);
            this.clientInfoGroup.Controls.Add(this.clientNameTextBox);
            this.clientInfoGroup.Controls.Add(this.clientSurnameLabel);
            this.clientInfoGroup.Controls.Add(this.clientPatronymicLabel);
            this.clientInfoGroup.Controls.Add(this.clientSurnameTextBox);
            this.clientInfoGroup.Location = new System.Drawing.Point(498, 208);
            this.clientInfoGroup.Name = "clientInfoGroup";
            this.clientInfoGroup.Size = new System.Drawing.Size(276, 107);
            this.clientInfoGroup.TabIndex = 32;
            this.clientInfoGroup.TabStop = false;
            this.clientInfoGroup.Text = "Клиент";
            // 
            // relinkClientButton
            // 
            this.relinkClientButton.Image = global::PRUI.Properties.Resources.linkButton;
            this.relinkClientButton.Location = new System.Drawing.Point(204, 32);
            this.relinkClientButton.Name = "relinkClientButton";
            this.relinkClientButton.Size = new System.Drawing.Size(30, 20);
            this.relinkClientButton.TabIndex = 61;
            this.relinkClientButton.UseVisualStyleBackColor = true;
            this.relinkClientButton.Click += new System.EventHandler(this.relinkClientButton_Click);
            // 
            // unlinkClientButton
            // 
            this.unlinkClientButton.Image = global::PRUI.Properties.Resources.unlinkButton;
            this.unlinkClientButton.Location = new System.Drawing.Point(240, 32);
            this.unlinkClientButton.Name = "unlinkClientButton";
            this.unlinkClientButton.Size = new System.Drawing.Size(30, 20);
            this.unlinkClientButton.TabIndex = 62;
            this.unlinkClientButton.UseVisualStyleBackColor = true;
            this.unlinkClientButton.Click += new System.EventHandler(this.unlinkClientButton_Click);
            // 
            // clientNameLabel
            // 
            this.clientNameLabel.AutoSize = true;
            this.clientNameLabel.Location = new System.Drawing.Point(6, 16);
            this.clientNameLabel.Name = "clientNameLabel";
            this.clientNameLabel.Size = new System.Drawing.Size(29, 13);
            this.clientNameLabel.TabIndex = 6;
            this.clientNameLabel.Text = "Имя";
            // 
            // clientPatronymicTextBox
            // 
            this.clientPatronymicTextBox.Enabled = false;
            this.clientPatronymicTextBox.Location = new System.Drawing.Point(9, 71);
            this.clientPatronymicTextBox.Name = "clientPatronymicTextBox";
            this.clientPatronymicTextBox.Size = new System.Drawing.Size(261, 20);
            this.clientPatronymicTextBox.TabIndex = 10;
            // 
            // clientNameTextBox
            // 
            this.clientNameTextBox.Enabled = false;
            this.clientNameTextBox.Location = new System.Drawing.Point(9, 32);
            this.clientNameTextBox.Name = "clientNameTextBox";
            this.clientNameTextBox.Size = new System.Drawing.Size(76, 20);
            this.clientNameTextBox.TabIndex = 5;
            // 
            // clientSurnameLabel
            // 
            this.clientSurnameLabel.AutoSize = true;
            this.clientSurnameLabel.Location = new System.Drawing.Point(90, 16);
            this.clientSurnameLabel.Name = "clientSurnameLabel";
            this.clientSurnameLabel.Size = new System.Drawing.Size(56, 13);
            this.clientSurnameLabel.TabIndex = 8;
            this.clientSurnameLabel.Text = "Фамилия";
            // 
            // clientPatronymicLabel
            // 
            this.clientPatronymicLabel.AutoSize = true;
            this.clientPatronymicLabel.Location = new System.Drawing.Point(6, 55);
            this.clientPatronymicLabel.Name = "clientPatronymicLabel";
            this.clientPatronymicLabel.Size = new System.Drawing.Size(54, 13);
            this.clientPatronymicLabel.TabIndex = 9;
            this.clientPatronymicLabel.Text = "Отчество";
            // 
            // clientSurnameTextBox
            // 
            this.clientSurnameTextBox.Enabled = false;
            this.clientSurnameTextBox.Location = new System.Drawing.Point(93, 32);
            this.clientSurnameTextBox.Name = "clientSurnameTextBox";
            this.clientSurnameTextBox.Size = new System.Drawing.Size(105, 20);
            this.clientSurnameTextBox.TabIndex = 7;
            // 
            // employeeInfoGroup
            // 
            this.employeeInfoGroup.Controls.Add(this.relinkEmployeeButton);
            this.employeeInfoGroup.Controls.Add(this.unlinkEmployeeButton);
            this.employeeInfoGroup.Controls.Add(this.employeeNameLabel);
            this.employeeInfoGroup.Controls.Add(this.employeePatronymicTextBox);
            this.employeeInfoGroup.Controls.Add(this.employeeNameText);
            this.employeeInfoGroup.Controls.Add(this.employeeSurnameLabel);
            this.employeeInfoGroup.Controls.Add(this.employeePatronymicLabel);
            this.employeeInfoGroup.Controls.Add(this.employeeSurnameTextBox);
            this.employeeInfoGroup.Location = new System.Drawing.Point(498, 321);
            this.employeeInfoGroup.Name = "employeeInfoGroup";
            this.employeeInfoGroup.Size = new System.Drawing.Size(276, 98);
            this.employeeInfoGroup.TabIndex = 33;
            this.employeeInfoGroup.TabStop = false;
            this.employeeInfoGroup.Text = "Сотрудник";
            // 
            // relinkEmployeeButton
            // 
            this.relinkEmployeeButton.Image = global::PRUI.Properties.Resources.linkButton;
            this.relinkEmployeeButton.Location = new System.Drawing.Point(204, 32);
            this.relinkEmployeeButton.Name = "relinkEmployeeButton";
            this.relinkEmployeeButton.Size = new System.Drawing.Size(30, 20);
            this.relinkEmployeeButton.TabIndex = 61;
            this.relinkEmployeeButton.UseVisualStyleBackColor = true;
            // 
            // unlinkEmployeeButton
            // 
            this.unlinkEmployeeButton.Image = global::PRUI.Properties.Resources.unlinkButton;
            this.unlinkEmployeeButton.Location = new System.Drawing.Point(240, 32);
            this.unlinkEmployeeButton.Name = "unlinkEmployeeButton";
            this.unlinkEmployeeButton.Size = new System.Drawing.Size(30, 20);
            this.unlinkEmployeeButton.TabIndex = 62;
            this.unlinkEmployeeButton.UseVisualStyleBackColor = true;
            // 
            // employeeNameLabel
            // 
            this.employeeNameLabel.AutoSize = true;
            this.employeeNameLabel.Location = new System.Drawing.Point(6, 16);
            this.employeeNameLabel.Name = "employeeNameLabel";
            this.employeeNameLabel.Size = new System.Drawing.Size(29, 13);
            this.employeeNameLabel.TabIndex = 6;
            this.employeeNameLabel.Text = "Имя";
            // 
            // employeePatronymicTextBox
            // 
            this.employeePatronymicTextBox.Enabled = false;
            this.employeePatronymicTextBox.Location = new System.Drawing.Point(9, 71);
            this.employeePatronymicTextBox.Name = "employeePatronymicTextBox";
            this.employeePatronymicTextBox.Size = new System.Drawing.Size(261, 20);
            this.employeePatronymicTextBox.TabIndex = 10;
            // 
            // employeeNameText
            // 
            this.employeeNameText.Enabled = false;
            this.employeeNameText.Location = new System.Drawing.Point(9, 32);
            this.employeeNameText.Name = "employeeNameText";
            this.employeeNameText.Size = new System.Drawing.Size(76, 20);
            this.employeeNameText.TabIndex = 5;
            // 
            // employeeSurnameLabel
            // 
            this.employeeSurnameLabel.AutoSize = true;
            this.employeeSurnameLabel.Location = new System.Drawing.Point(90, 16);
            this.employeeSurnameLabel.Name = "employeeSurnameLabel";
            this.employeeSurnameLabel.Size = new System.Drawing.Size(56, 13);
            this.employeeSurnameLabel.TabIndex = 8;
            this.employeeSurnameLabel.Text = "Фамилия";
            // 
            // employeePatronymicLabel
            // 
            this.employeePatronymicLabel.AutoSize = true;
            this.employeePatronymicLabel.Location = new System.Drawing.Point(6, 55);
            this.employeePatronymicLabel.Name = "employeePatronymicLabel";
            this.employeePatronymicLabel.Size = new System.Drawing.Size(54, 13);
            this.employeePatronymicLabel.TabIndex = 9;
            this.employeePatronymicLabel.Text = "Отчество";
            // 
            // employeeSurnameTextBox
            // 
            this.employeeSurnameTextBox.Enabled = false;
            this.employeeSurnameTextBox.Location = new System.Drawing.Point(93, 32);
            this.employeeSurnameTextBox.Name = "employeeSurnameTextBox";
            this.employeeSurnameTextBox.Size = new System.Drawing.Size(105, 20);
            this.employeeSurnameTextBox.TabIndex = 7;
            // 
            // reportInfoGroup
            // 
            this.reportInfoGroup.Controls.Add(this.reportDateDateTimePicker);
            this.reportInfoGroup.Controls.Add(this.reportDateLabel);
            this.reportInfoGroup.Controls.Add(this.evaluationDateLabel);
            this.reportInfoGroup.Controls.Add(this.evaluationDateDateTimePicker);
            this.reportInfoGroup.Controls.Add(this.reportNumberTextBox);
            this.reportInfoGroup.Controls.Add(this.reportNumberLabel);
            this.reportInfoGroup.Location = new System.Drawing.Point(10, 12);
            this.reportInfoGroup.Name = "reportInfoGroup";
            this.reportInfoGroup.Size = new System.Drawing.Size(206, 142);
            this.reportInfoGroup.TabIndex = 34;
            this.reportInfoGroup.TabStop = false;
            this.reportInfoGroup.Text = "Отчет";
            // 
            // reportDateDateTimePicker
            // 
            this.reportDateDateTimePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.reportDateDateTimePicker.Location = new System.Drawing.Point(9, 110);
            this.reportDateDateTimePicker.Name = "reportDateDateTimePicker";
            this.reportDateDateTimePicker.Size = new System.Drawing.Size(190, 20);
            this.reportDateDateTimePicker.TabIndex = 37;
            // 
            // reportDateLabel
            // 
            this.reportDateLabel.AutoSize = true;
            this.reportDateLabel.Location = new System.Drawing.Point(6, 94);
            this.reportDateLabel.Name = "reportDateLabel";
            this.reportDateLabel.Size = new System.Drawing.Size(137, 13);
            this.reportDateLabel.TabIndex = 36;
            this.reportDateLabel.Text = "Дата составления отчета";
            // 
            // evaluationDateLabel
            // 
            this.evaluationDateLabel.AutoSize = true;
            this.evaluationDateLabel.Location = new System.Drawing.Point(6, 55);
            this.evaluationDateLabel.Name = "evaluationDateLabel";
            this.evaluationDateLabel.Size = new System.Drawing.Size(72, 13);
            this.evaluationDateLabel.TabIndex = 35;
            this.evaluationDateLabel.Text = "Дата оценки";
            // 
            // evaluationDateDateTimePicker
            // 
            this.evaluationDateDateTimePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.evaluationDateDateTimePicker.Location = new System.Drawing.Point(9, 71);
            this.evaluationDateDateTimePicker.Name = "evaluationDateDateTimePicker";
            this.evaluationDateDateTimePicker.Size = new System.Drawing.Size(190, 20);
            this.evaluationDateDateTimePicker.TabIndex = 35;
            // 
            // reportNumberTextBox
            // 
            this.reportNumberTextBox.Location = new System.Drawing.Point(9, 32);
            this.reportNumberTextBox.Name = "reportNumberTextBox";
            this.reportNumberTextBox.Size = new System.Drawing.Size(190, 20);
            this.reportNumberTextBox.TabIndex = 35;
            // 
            // reportNumberLabel
            // 
            this.reportNumberLabel.AutoSize = true;
            this.reportNumberLabel.Location = new System.Drawing.Point(6, 16);
            this.reportNumberLabel.Name = "reportNumberLabel";
            this.reportNumberLabel.Size = new System.Drawing.Size(41, 13);
            this.reportNumberLabel.TabIndex = 35;
            this.reportNumberLabel.Text = "Номер";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 618);
            this.Controls.Add(this.reportInfoGroup);
            this.Controls.Add(this.employeeInfoGroup);
            this.Controls.Add(this.clientInfoGroup);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.idInfoGroup, 0);
            this.Controls.SetChildIndex(this.descriptionInfoGroup, 0);
            this.Controls.SetChildIndex(this.noteInfoGroup, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.clientInfoGroup, 0);
            this.Controls.SetChildIndex(this.employeeInfoGroup, 0);
            this.Controls.SetChildIndex(this.reportInfoGroup, 0);
            this.idInfoGroup.ResumeLayout(false);
            this.idInfoGroup.PerformLayout();
            this.descriptionInfoGroup.ResumeLayout(false);
            this.descriptionInfoGroup.PerformLayout();
            this.noteInfoGroup.ResumeLayout(false);
            this.noteInfoGroup.PerformLayout();
            this.clientInfoGroup.ResumeLayout(false);
            this.clientInfoGroup.PerformLayout();
            this.employeeInfoGroup.ResumeLayout(false);
            this.employeeInfoGroup.PerformLayout();
            this.reportInfoGroup.ResumeLayout(false);
            this.reportInfoGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox clientInfoGroup;
        protected System.Windows.Forms.Button relinkClientButton;
        protected System.Windows.Forms.Button unlinkClientButton;
        protected System.Windows.Forms.Label clientNameLabel;
        protected System.Windows.Forms.TextBox clientPatronymicTextBox;
        protected System.Windows.Forms.TextBox clientNameTextBox;
        protected System.Windows.Forms.Label clientSurnameLabel;
        protected System.Windows.Forms.Label clientPatronymicLabel;
        protected System.Windows.Forms.TextBox clientSurnameTextBox;
        protected System.Windows.Forms.GroupBox employeeInfoGroup;
        protected System.Windows.Forms.Button relinkEmployeeButton;
        protected System.Windows.Forms.Button unlinkEmployeeButton;
        protected System.Windows.Forms.Label employeeNameLabel;
        protected System.Windows.Forms.TextBox employeePatronymicTextBox;
        protected System.Windows.Forms.TextBox employeeNameText;
        protected System.Windows.Forms.Label employeeSurnameLabel;
        protected System.Windows.Forms.Label employeePatronymicLabel;
        protected System.Windows.Forms.TextBox employeeSurnameTextBox;
        private System.Windows.Forms.GroupBox reportInfoGroup;
        private System.Windows.Forms.Label reportNumberLabel;
        private System.Windows.Forms.TextBox reportNumberTextBox;
        private System.Windows.Forms.DateTimePicker evaluationDateDateTimePicker;
        private System.Windows.Forms.Label reportDateLabel;
        private System.Windows.Forms.Label evaluationDateLabel;
        private System.Windows.Forms.DateTimePicker reportDateDateTimePicker;
    }
}