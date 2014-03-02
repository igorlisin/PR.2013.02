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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ObjectKomplexTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ObjectFlatTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ObjectHouseTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ObjectStreetTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.relinkObjectButton = new System.Windows.Forms.Button();
            this.unlinkObjectButton = new System.Windows.Forms.Button();
            this.ObjectCityTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AddObjectButton = new System.Windows.Forms.Button();
            this.AddClientButton = new System.Windows.Forms.Button();
            this.AddEmployeeButton = new System.Windows.Forms.Button();
            this.ObjectTypeTextBox = new System.Windows.Forms.TextBox();
            this.idInfoGroup.SuspendLayout();
            this.descriptionInfoGroup.SuspendLayout();
            this.noteInfoGroup.SuspendLayout();
            this.clientInfoGroup.SuspendLayout();
            this.employeeInfoGroup.SuspendLayout();
            this.reportInfoGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.noteInfoGroup.Location = new System.Drawing.Point(995, 353);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(1213, 583);
            // 
            // clientInfoGroup
            // 
            this.clientInfoGroup.Controls.Add(this.AddClientButton);
            this.clientInfoGroup.Controls.Add(this.relinkClientButton);
            this.clientInfoGroup.Controls.Add(this.unlinkClientButton);
            this.clientInfoGroup.Controls.Add(this.clientNameLabel);
            this.clientInfoGroup.Controls.Add(this.clientPatronymicTextBox);
            this.clientInfoGroup.Controls.Add(this.clientNameTextBox);
            this.clientInfoGroup.Controls.Add(this.clientSurnameLabel);
            this.clientInfoGroup.Controls.Add(this.clientPatronymicLabel);
            this.clientInfoGroup.Controls.Add(this.clientSurnameTextBox);
            this.clientInfoGroup.Location = new System.Drawing.Point(619, 12);
            this.clientInfoGroup.Name = "clientInfoGroup";
            this.clientInfoGroup.Size = new System.Drawing.Size(276, 142);
            this.clientInfoGroup.TabIndex = 32;
            this.clientInfoGroup.TabStop = false;
            this.clientInfoGroup.Text = "Клиент";
            // 
            // relinkClientButton
            // 
            this.relinkClientButton.Image = global::PRUI.Properties.Resources.linkButton;
            this.relinkClientButton.Location = new System.Drawing.Point(9, 108);
            this.relinkClientButton.Name = "relinkClientButton";
            this.relinkClientButton.Size = new System.Drawing.Size(30, 20);
            this.relinkClientButton.TabIndex = 61;
            this.relinkClientButton.UseVisualStyleBackColor = true;
            this.relinkClientButton.Click += new System.EventHandler(this.relinkClientButton_Click);
            // 
            // unlinkClientButton
            // 
            this.unlinkClientButton.Image = global::PRUI.Properties.Resources.unlinkButton;
            this.unlinkClientButton.Location = new System.Drawing.Point(93, 108);
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
            this.clientPatronymicTextBox.TextChanged += new System.EventHandler(this.clientPatronymicTextBox_TextChanged);
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
            this.employeeInfoGroup.Controls.Add(this.AddEmployeeButton);
            this.employeeInfoGroup.Controls.Add(this.relinkEmployeeButton);
            this.employeeInfoGroup.Controls.Add(this.unlinkEmployeeButton);
            this.employeeInfoGroup.Controls.Add(this.employeeNameLabel);
            this.employeeInfoGroup.Controls.Add(this.employeePatronymicTextBox);
            this.employeeInfoGroup.Controls.Add(this.employeeNameText);
            this.employeeInfoGroup.Controls.Add(this.employeeSurnameLabel);
            this.employeeInfoGroup.Controls.Add(this.employeePatronymicLabel);
            this.employeeInfoGroup.Controls.Add(this.employeeSurnameTextBox);
            this.employeeInfoGroup.Location = new System.Drawing.Point(619, 184);
            this.employeeInfoGroup.Name = "employeeInfoGroup";
            this.employeeInfoGroup.Size = new System.Drawing.Size(276, 145);
            this.employeeInfoGroup.TabIndex = 33;
            this.employeeInfoGroup.TabStop = false;
            this.employeeInfoGroup.Text = "Сотрудник";
            // 
            // relinkEmployeeButton
            // 
            this.relinkEmployeeButton.Image = global::PRUI.Properties.Resources.linkButton;
            this.relinkEmployeeButton.Location = new System.Drawing.Point(9, 106);
            this.relinkEmployeeButton.Name = "relinkEmployeeButton";
            this.relinkEmployeeButton.Size = new System.Drawing.Size(30, 20);
            this.relinkEmployeeButton.TabIndex = 61;
            this.relinkEmployeeButton.UseVisualStyleBackColor = true;
            this.relinkEmployeeButton.Click += new System.EventHandler(this.relinkEmployeeButton_Click);
            // 
            // unlinkEmployeeButton
            // 
            this.unlinkEmployeeButton.Image = global::PRUI.Properties.Resources.unlinkButton;
            this.unlinkEmployeeButton.Location = new System.Drawing.Point(93, 106);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ObjectTypeTextBox);
            this.groupBox1.Controls.Add(this.AddObjectButton);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ObjectKomplexTextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ObjectFlatTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ObjectHouseTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ObjectStreetTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.relinkObjectButton);
            this.groupBox1.Controls.Add(this.unlinkObjectButton);
            this.groupBox1.Controls.Add(this.ObjectCityTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(304, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 331);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Объект оценки";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 73;
            this.label8.Text = "По комплексу";
            // 
            // ObjectKomplexTextBox
            // 
            this.ObjectKomplexTextBox.Enabled = false;
            this.ObjectKomplexTextBox.Location = new System.Drawing.Point(9, 218);
            this.ObjectKomplexTextBox.Name = "ObjectKomplexTextBox";
            this.ObjectKomplexTextBox.Size = new System.Drawing.Size(73, 20);
            this.ObjectKomplexTextBox.TabIndex = 72;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(192, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 71;
            this.label7.Text = "Квартира";
            // 
            // ObjectFlatTextBox
            // 
            this.ObjectFlatTextBox.Enabled = false;
            this.ObjectFlatTextBox.Location = new System.Drawing.Point(195, 172);
            this.ObjectFlatTextBox.Name = "ObjectFlatTextBox";
            this.ObjectFlatTextBox.Size = new System.Drawing.Size(75, 20);
            this.ObjectFlatTextBox.TabIndex = 70;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 69;
            this.label6.Text = "Дом";
            // 
            // ObjectHouseTextBox
            // 
            this.ObjectHouseTextBox.Enabled = false;
            this.ObjectHouseTextBox.Location = new System.Drawing.Point(9, 172);
            this.ObjectHouseTextBox.Name = "ObjectHouseTextBox";
            this.ObjectHouseTextBox.Size = new System.Drawing.Size(73, 20);
            this.ObjectHouseTextBox.TabIndex = 68;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 67;
            this.label5.Text = "Улица";
            // 
            // ObjectStreetTextBox
            // 
            this.ObjectStreetTextBox.Enabled = false;
            this.ObjectStreetTextBox.Location = new System.Drawing.Point(9, 129);
            this.ObjectStreetTextBox.Name = "ObjectStreetTextBox";
            this.ObjectStreetTextBox.Size = new System.Drawing.Size(261, 20);
            this.ObjectStreetTextBox.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Город";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // relinkObjectButton
            // 
            this.relinkObjectButton.Image = global::PRUI.Properties.Resources.linkButton;
            this.relinkObjectButton.Location = new System.Drawing.Point(9, 257);
            this.relinkObjectButton.Name = "relinkObjectButton";
            this.relinkObjectButton.Size = new System.Drawing.Size(30, 20);
            this.relinkObjectButton.TabIndex = 61;
            this.relinkObjectButton.UseVisualStyleBackColor = true;
            this.relinkObjectButton.Click += new System.EventHandler(this.relinkObjectButton_Click);
            // 
            // unlinkObjectButton
            // 
            this.unlinkObjectButton.Image = global::PRUI.Properties.Resources.unlinkButton;
            this.unlinkObjectButton.Location = new System.Drawing.Point(90, 257);
            this.unlinkObjectButton.Name = "unlinkObjectButton";
            this.unlinkObjectButton.Size = new System.Drawing.Size(30, 20);
            this.unlinkObjectButton.TabIndex = 62;
            this.unlinkObjectButton.UseVisualStyleBackColor = true;
            // 
            // ObjectCityTextBox
            // 
            this.ObjectCityTextBox.Enabled = false;
            this.ObjectCityTextBox.Location = new System.Drawing.Point(9, 88);
            this.ObjectCityTextBox.Name = "ObjectCityTextBox";
            this.ObjectCityTextBox.Size = new System.Drawing.Size(261, 20);
            this.ObjectCityTextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Тип";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Адрес";
            // 
            // AddObjectButton
            // 
            this.AddObjectButton.Location = new System.Drawing.Point(47, 257);
            this.AddObjectButton.Name = "AddObjectButton";
            this.AddObjectButton.Size = new System.Drawing.Size(37, 20);
            this.AddObjectButton.TabIndex = 36;
            this.AddObjectButton.Text = "+";
            this.AddObjectButton.UseVisualStyleBackColor = true;
            this.AddObjectButton.Click += new System.EventHandler(this.AddObjectButton_Click);
            // 
            // AddClientButton
            // 
            this.AddClientButton.Location = new System.Drawing.Point(48, 108);
            this.AddClientButton.Name = "AddClientButton";
            this.AddClientButton.Size = new System.Drawing.Size(37, 20);
            this.AddClientButton.TabIndex = 74;
            this.AddClientButton.Text = "+";
            this.AddClientButton.UseVisualStyleBackColor = true;
            this.AddClientButton.Click += new System.EventHandler(this.AddClientButton_Click);
            // 
            // AddEmployeeButton
            // 
            this.AddEmployeeButton.Location = new System.Drawing.Point(48, 106);
            this.AddEmployeeButton.Name = "AddEmployeeButton";
            this.AddEmployeeButton.Size = new System.Drawing.Size(37, 20);
            this.AddEmployeeButton.TabIndex = 63;
            this.AddEmployeeButton.Text = "+";
            this.AddEmployeeButton.UseVisualStyleBackColor = true;
            this.AddEmployeeButton.Click += new System.EventHandler(this.AddEmployeeButton_Click);
            // 
            // ObjectTypeTextBox
            // 
            this.ObjectTypeTextBox.Enabled = false;
            this.ObjectTypeTextBox.Location = new System.Drawing.Point(8, 32);
            this.ObjectTypeTextBox.Name = "ObjectTypeTextBox";
            this.ObjectTypeTextBox.Size = new System.Drawing.Size(261, 20);
            this.ObjectTypeTextBox.TabIndex = 74;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 618);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reportInfoGroup);
            this.Controls.Add(this.employeeInfoGroup);
            this.Controls.Add(this.clientInfoGroup);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.Controls.SetChildIndex(this.clientInfoGroup, 0);
            this.Controls.SetChildIndex(this.employeeInfoGroup, 0);
            this.Controls.SetChildIndex(this.reportInfoGroup, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.idInfoGroup, 0);
            this.Controls.SetChildIndex(this.descriptionInfoGroup, 0);
            this.Controls.SetChildIndex(this.noteInfoGroup, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.Button relinkObjectButton;
        protected System.Windows.Forms.Button unlinkObjectButton;
        protected System.Windows.Forms.TextBox ObjectCityTextBox;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.TextBox ObjectKomplexTextBox;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.TextBox ObjectFlatTextBox;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.TextBox ObjectHouseTextBox;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.TextBox ObjectStreetTextBox;
        private System.Windows.Forms.Button AddObjectButton;
        private System.Windows.Forms.Button AddClientButton;
        private System.Windows.Forms.Button AddEmployeeButton;
        protected System.Windows.Forms.TextBox ObjectTypeTextBox;
    }
}