namespace PRUI.TemplateForms
{
    partial class TemplateEntityPersonForm
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
            this.documentInfoGroup = new System.Windows.Forms.GroupBox();
            this.relinkDocumentButton = new System.Windows.Forms.Button();
            this.unlinkDocumentButton = new System.Windows.Forms.Button();
            this.documentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.documentTypeLabel = new System.Windows.Forms.Label();
            this.documentSeriesNumberLabel = new System.Windows.Forms.Label();
            this.documentPlaceOfIssueTextBox = new System.Windows.Forms.TextBox();
            this.documentPlaceOfIssueLabel = new System.Windows.Forms.Label();
            this.documentDateOfIssueTextBox = new System.Windows.Forms.TextBox();
            this.documentDateOfIssueLabel = new System.Windows.Forms.Label();
            this.documentNumberTextBox = new System.Windows.Forms.TextBox();
            this.documentSeriesTextBox = new System.Windows.Forms.TextBox();
            this.manInfoGroup = new System.Windows.Forms.GroupBox();
            this.relinkManButton = new System.Windows.Forms.Button();
            this.unlinkManButton = new System.Windows.Forms.Button();
            this.manNameLabel = new System.Windows.Forms.Label();
            this.manPatronymicTextBox = new System.Windows.Forms.TextBox();
            this.manNameTextBox = new System.Windows.Forms.TextBox();
            this.manSurnameLabel = new System.Windows.Forms.Label();
            this.manPatronymicLabel = new System.Windows.Forms.Label();
            this.manSurnameTextBox = new System.Windows.Forms.TextBox();
            this.idInfoGroup.SuspendLayout();
            this.descriptionInfoGroup.SuspendLayout();
            this.noteInfoGroup.SuspendLayout();
            this.documentInfoGroup.SuspendLayout();
            this.manInfoGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // documentInfoGroup
            // 
            this.documentInfoGroup.Controls.Add(this.documentTypeComboBox);
            this.documentInfoGroup.Controls.Add(this.relinkDocumentButton);
            this.documentInfoGroup.Controls.Add(this.unlinkDocumentButton);
            this.documentInfoGroup.Controls.Add(this.documentTypeLabel);
            this.documentInfoGroup.Controls.Add(this.documentSeriesNumberLabel);
            this.documentInfoGroup.Controls.Add(this.documentPlaceOfIssueTextBox);
            this.documentInfoGroup.Controls.Add(this.documentPlaceOfIssueLabel);
            this.documentInfoGroup.Controls.Add(this.documentDateOfIssueTextBox);
            this.documentInfoGroup.Controls.Add(this.documentDateOfIssueLabel);
            this.documentInfoGroup.Controls.Add(this.documentNumberTextBox);
            this.documentInfoGroup.Controls.Add(this.documentSeriesTextBox);
            this.documentInfoGroup.Location = new System.Drawing.Point(11, 12);
            this.documentInfoGroup.Name = "documentInfoGroup";
            this.documentInfoGroup.Size = new System.Drawing.Size(276, 242);
            this.documentInfoGroup.TabIndex = 17;
            this.documentInfoGroup.TabStop = false;
            this.documentInfoGroup.Text = "Документ";
            // 
            // relinkDocumentButton
            // 
            this.relinkDocumentButton.Image = global::PRUI.Properties.Resources.linkButton;
            this.relinkDocumentButton.Location = new System.Drawing.Point(204, 32);
            this.relinkDocumentButton.Name = "relinkDocumentButton";
            this.relinkDocumentButton.Size = new System.Drawing.Size(30, 20);
            this.relinkDocumentButton.TabIndex = 59;
            this.relinkDocumentButton.UseVisualStyleBackColor = true;
            this.relinkDocumentButton.Click += new System.EventHandler(this.relinkDocumentButton_Click);
            // 
            // unlinkDocumentButton
            // 
            this.unlinkDocumentButton.Image = global::PRUI.Properties.Resources.unlinkButton;
            this.unlinkDocumentButton.Location = new System.Drawing.Point(240, 32);
            this.unlinkDocumentButton.Name = "unlinkDocumentButton";
            this.unlinkDocumentButton.Size = new System.Drawing.Size(30, 20);
            this.unlinkDocumentButton.TabIndex = 60;
            this.unlinkDocumentButton.UseVisualStyleBackColor = true;
            this.unlinkDocumentButton.Click += new System.EventHandler(this.unlinkDocumentButton_Click);
            // 
            // documentTypeComboBox
            // 
            this.documentTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.documentTypeComboBox.Location = new System.Drawing.Point(9, 32);
            this.documentTypeComboBox.Name = "documentTypeComboBox";
            this.documentTypeComboBox.Size = new System.Drawing.Size(189, 21);
            this.documentTypeComboBox.TabIndex = 14;
            // 
            // documentTypeLabel
            // 
            this.documentTypeLabel.AutoSize = true;
            this.documentTypeLabel.Location = new System.Drawing.Point(6, 16);
            this.documentTypeLabel.Name = "documentTypeLabel";
            this.documentTypeLabel.Size = new System.Drawing.Size(83, 13);
            this.documentTypeLabel.TabIndex = 15;
            this.documentTypeLabel.Text = "Тип документа";
            // 
            // documentSeriesNumberLabel
            // 
            this.documentSeriesNumberLabel.AutoSize = true;
            this.documentSeriesNumberLabel.Location = new System.Drawing.Point(6, 56);
            this.documentSeriesNumberLabel.Name = "documentSeriesNumberLabel";
            this.documentSeriesNumberLabel.Size = new System.Drawing.Size(82, 13);
            this.documentSeriesNumberLabel.TabIndex = 5;
            this.documentSeriesNumberLabel.Text = "Серия и номер";
            // 
            // documentPlaceOfIssueTextBox
            // 
            this.documentPlaceOfIssueTextBox.Location = new System.Drawing.Point(9, 150);
            this.documentPlaceOfIssueTextBox.Multiline = true;
            this.documentPlaceOfIssueTextBox.Name = "documentPlaceOfIssueTextBox";
            this.documentPlaceOfIssueTextBox.Size = new System.Drawing.Size(261, 84);
            this.documentPlaceOfIssueTextBox.TabIndex = 13;
            // 
            // documentPlaceOfIssueLabel
            // 
            this.documentPlaceOfIssueLabel.AutoSize = true;
            this.documentPlaceOfIssueLabel.Location = new System.Drawing.Point(6, 134);
            this.documentPlaceOfIssueLabel.Name = "documentPlaceOfIssueLabel";
            this.documentPlaceOfIssueLabel.Size = new System.Drawing.Size(79, 13);
            this.documentPlaceOfIssueLabel.TabIndex = 12;
            this.documentPlaceOfIssueLabel.Text = "Место выдачи";
            // 
            // documentDateOfIssueTextBox
            // 
            this.documentDateOfIssueTextBox.Location = new System.Drawing.Point(9, 111);
            this.documentDateOfIssueTextBox.Name = "documentDateOfIssueTextBox";
            this.documentDateOfIssueTextBox.Size = new System.Drawing.Size(100, 20);
            this.documentDateOfIssueTextBox.TabIndex = 10;
            // 
            // documentDateOfIssueLabel
            // 
            this.documentDateOfIssueLabel.AutoSize = true;
            this.documentDateOfIssueLabel.Location = new System.Drawing.Point(6, 95);
            this.documentDateOfIssueLabel.Name = "documentDateOfIssueLabel";
            this.documentDateOfIssueLabel.Size = new System.Drawing.Size(73, 13);
            this.documentDateOfIssueLabel.TabIndex = 9;
            this.documentDateOfIssueLabel.Text = "Дата выдачи";
            // 
            // documentNumberTextBox
            // 
            this.documentNumberTextBox.Location = new System.Drawing.Point(81, 72);
            this.documentNumberTextBox.Name = "documentNumberTextBox";
            this.documentNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.documentNumberTextBox.TabIndex = 7;
            this.documentNumberTextBox.Enter += new System.EventHandler(this.documentNumberTextBox_Enter);
            this.documentNumberTextBox.Leave += new System.EventHandler(this.documentNumberTextBox_Leave);
            // 
            // documentSeriesTextBox
            // 
            this.documentSeriesTextBox.Location = new System.Drawing.Point(9, 72);
            this.documentSeriesTextBox.Name = "documentSeriesTextBox";
            this.documentSeriesTextBox.Size = new System.Drawing.Size(66, 20);
            this.documentSeriesTextBox.TabIndex = 6;
            this.documentSeriesTextBox.Enter += new System.EventHandler(this.documentSeriesTextBox_Enter);
            this.documentSeriesTextBox.Leave += new System.EventHandler(this.documentSeriesTextBox_Leave);
            // 
            // manInfoGroup
            // 
            this.manInfoGroup.Controls.Add(this.relinkManButton);
            this.manInfoGroup.Controls.Add(this.unlinkManButton);
            this.manInfoGroup.Controls.Add(this.manNameLabel);
            this.manInfoGroup.Controls.Add(this.manPatronymicTextBox);
            this.manInfoGroup.Controls.Add(this.manNameTextBox);
            this.manInfoGroup.Controls.Add(this.manSurnameLabel);
            this.manInfoGroup.Controls.Add(this.manPatronymicLabel);
            this.manInfoGroup.Controls.Add(this.manSurnameTextBox);
            this.manInfoGroup.Location = new System.Drawing.Point(11, 260);
            this.manInfoGroup.Name = "manInfoGroup";
            this.manInfoGroup.Size = new System.Drawing.Size(276, 98);
            this.manInfoGroup.TabIndex = 31;
            this.manInfoGroup.TabStop = false;
            this.manInfoGroup.Text = "Человек";
            // 
            // relinkManButton
            // 
            this.relinkManButton.Image = global::PRUI.Properties.Resources.linkButton;
            this.relinkManButton.Location = new System.Drawing.Point(204, 32);
            this.relinkManButton.Name = "relinkManButton";
            this.relinkManButton.Size = new System.Drawing.Size(30, 20);
            this.relinkManButton.TabIndex = 61;
            this.relinkManButton.UseVisualStyleBackColor = true;
            this.relinkManButton.Click += new System.EventHandler(this.relinkManButton_Click);
            // 
            // unlinkManButton
            // 
            this.unlinkManButton.Image = global::PRUI.Properties.Resources.unlinkButton;
            this.unlinkManButton.Location = new System.Drawing.Point(240, 32);
            this.unlinkManButton.Name = "unlinkManButton";
            this.unlinkManButton.Size = new System.Drawing.Size(30, 20);
            this.unlinkManButton.TabIndex = 62;
            this.unlinkManButton.UseVisualStyleBackColor = true;
            this.unlinkManButton.Click += new System.EventHandler(this.unlinkManButton_Click);
            // 
            // manNameLabel
            // 
            this.manNameLabel.AutoSize = true;
            this.manNameLabel.Location = new System.Drawing.Point(6, 16);
            this.manNameLabel.Name = "manNameLabel";
            this.manNameLabel.Size = new System.Drawing.Size(29, 13);
            this.manNameLabel.TabIndex = 6;
            this.manNameLabel.Text = "Имя";
            // 
            // manPatronymicTextBox
            // 
            this.manPatronymicTextBox.Location = new System.Drawing.Point(9, 71);
            this.manPatronymicTextBox.Name = "manPatronymicTextBox";
            this.manPatronymicTextBox.Size = new System.Drawing.Size(261, 20);
            this.manPatronymicTextBox.TabIndex = 10;
            this.manPatronymicTextBox.Enter += new System.EventHandler(this.patronymicTextBox_Enter);
            this.manPatronymicTextBox.Leave += new System.EventHandler(this.patronymicTextBox_Leave);
            // 
            // manNameTextBox
            // 
            this.manNameTextBox.Location = new System.Drawing.Point(9, 32);
            this.manNameTextBox.Name = "manNameTextBox";
            this.manNameTextBox.Size = new System.Drawing.Size(76, 20);
            this.manNameTextBox.TabIndex = 5;
            this.manNameTextBox.Enter += new System.EventHandler(this.nameTextBox_Enter);
            this.manNameTextBox.Leave += new System.EventHandler(this.nameTextBox_Leave);
            // 
            // manSurnameLabel
            // 
            this.manSurnameLabel.AutoSize = true;
            this.manSurnameLabel.Location = new System.Drawing.Point(90, 16);
            this.manSurnameLabel.Name = "manSurnameLabel";
            this.manSurnameLabel.Size = new System.Drawing.Size(56, 13);
            this.manSurnameLabel.TabIndex = 8;
            this.manSurnameLabel.Text = "Фамилия";
            // 
            // manPatronymicLabel
            // 
            this.manPatronymicLabel.AutoSize = true;
            this.manPatronymicLabel.Location = new System.Drawing.Point(6, 55);
            this.manPatronymicLabel.Name = "manPatronymicLabel";
            this.manPatronymicLabel.Size = new System.Drawing.Size(54, 13);
            this.manPatronymicLabel.TabIndex = 9;
            this.manPatronymicLabel.Text = "Отчество";
            // 
            // manSurnameTextBox
            // 
            this.manSurnameTextBox.Location = new System.Drawing.Point(93, 32);
            this.manSurnameTextBox.Name = "manSurnameTextBox";
            this.manSurnameTextBox.Size = new System.Drawing.Size(105, 20);
            this.manSurnameTextBox.TabIndex = 7;
            this.manSurnameTextBox.Enter += new System.EventHandler(this.surnameTextBox_Enter);
            this.manSurnameTextBox.Leave += new System.EventHandler(this.surnameTextBox_Leave);
            // 
            // TemplateEntityPersonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 476);
            this.Controls.Add(this.manInfoGroup);
            this.Controls.Add(this.documentInfoGroup);
            this.Name = "TemplateEntityPersonForm";
            this.Text = "TemlateEntityPersonForm";
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.idInfoGroup, 0);
            this.Controls.SetChildIndex(this.descriptionInfoGroup, 0);
            this.Controls.SetChildIndex(this.noteInfoGroup, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.documentInfoGroup, 0);
            this.Controls.SetChildIndex(this.manInfoGroup, 0);
            this.idInfoGroup.ResumeLayout(false);
            this.idInfoGroup.PerformLayout();
            this.descriptionInfoGroup.ResumeLayout(false);
            this.descriptionInfoGroup.PerformLayout();
            this.noteInfoGroup.ResumeLayout(false);
            this.noteInfoGroup.PerformLayout();
            this.documentInfoGroup.ResumeLayout(false);
            this.documentInfoGroup.PerformLayout();
            this.manInfoGroup.ResumeLayout(false);
            this.manInfoGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox documentInfoGroup;
        protected System.Windows.Forms.Label documentTypeLabel;
        protected System.Windows.Forms.ComboBox documentTypeComboBox;
        protected System.Windows.Forms.Label documentSeriesNumberLabel;
        protected System.Windows.Forms.TextBox documentPlaceOfIssueTextBox;
        protected System.Windows.Forms.Label documentPlaceOfIssueLabel;
        protected System.Windows.Forms.TextBox documentDateOfIssueTextBox;
        protected System.Windows.Forms.Label documentDateOfIssueLabel;
        protected System.Windows.Forms.TextBox documentNumberTextBox;
        protected System.Windows.Forms.TextBox documentSeriesTextBox;
        protected System.Windows.Forms.GroupBox manInfoGroup;
        protected System.Windows.Forms.Label manNameLabel;
        protected System.Windows.Forms.TextBox manPatronymicTextBox;
        protected System.Windows.Forms.TextBox manNameTextBox;
        protected System.Windows.Forms.Label manSurnameLabel;
        protected System.Windows.Forms.Label manPatronymicLabel;
        protected System.Windows.Forms.TextBox manSurnameTextBox;
        protected System.Windows.Forms.Button relinkDocumentButton;
        protected System.Windows.Forms.Button unlinkDocumentButton;
        protected System.Windows.Forms.Button relinkManButton;
        protected System.Windows.Forms.Button unlinkManButton;

    }
}