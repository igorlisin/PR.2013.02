namespace PRUI.Forms
{
    partial class PictureForm
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
            this.pictureInfoGroup = new System.Windows.Forms.GroupBox();
            this.pictureCreationDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.pictureNameTextBox = new System.Windows.Forms.TextBox();
            this.pictureNameLabel = new System.Windows.Forms.Label();
            this.picturePictureBox = new System.Windows.Forms.PictureBox();
            this.selectImageButton = new System.Windows.Forms.Button();
            this.pictureTypeComboBox = new System.Windows.Forms.ComboBox();
            this.pictureTypeLabel = new System.Windows.Forms.Label();
            this.imageFileNameLabel = new System.Windows.Forms.Label();
            this.pictureCreationDateAndTimeLabel = new System.Windows.Forms.Label();
            this.imageFileNameTextBox = new System.Windows.Forms.TextBox();
            this.idInfoGroup.SuspendLayout();
            this.descriptionInfoGroup.SuspendLayout();
            this.noteInfoGroup.SuspendLayout();
            this.pictureInfoGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // idInfoGroup
            // 
            this.idInfoGroup.Location = new System.Drawing.Point(610, 12);
            // 
            // descriptionInfoGroup
            // 
            this.descriptionInfoGroup.Location = new System.Drawing.Point(610, 65);
            // 
            // noteInfoGroup
            // 
            this.noteInfoGroup.Location = new System.Drawing.Point(610, 341);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(828, 447);
            // 
            // pictureInfoGroup
            // 
            this.pictureInfoGroup.Controls.Add(this.pictureCreationDateDateTimePicker);
            this.pictureInfoGroup.Controls.Add(this.pictureNameTextBox);
            this.pictureInfoGroup.Controls.Add(this.pictureNameLabel);
            this.pictureInfoGroup.Controls.Add(this.picturePictureBox);
            this.pictureInfoGroup.Controls.Add(this.selectImageButton);
            this.pictureInfoGroup.Controls.Add(this.pictureTypeComboBox);
            this.pictureInfoGroup.Controls.Add(this.pictureTypeLabel);
            this.pictureInfoGroup.Controls.Add(this.imageFileNameLabel);
            this.pictureInfoGroup.Controls.Add(this.pictureCreationDateAndTimeLabel);
            this.pictureInfoGroup.Controls.Add(this.imageFileNameTextBox);
            this.pictureInfoGroup.Location = new System.Drawing.Point(12, 12);
            this.pictureInfoGroup.Name = "pictureInfoGroup";
            this.pictureInfoGroup.Size = new System.Drawing.Size(592, 379);
            this.pictureInfoGroup.TabIndex = 11;
            this.pictureInfoGroup.TabStop = false;
            this.pictureInfoGroup.Text = "Картинка";
            // 
            // pictureCreationDateDateTimePicker
            // 
            this.pictureCreationDateDateTimePicker.Location = new System.Drawing.Point(6, 179);
            this.pictureCreationDateDateTimePicker.Name = "pictureCreationDateDateTimePicker";
            this.pictureCreationDateDateTimePicker.Size = new System.Drawing.Size(185, 20);
            this.pictureCreationDateDateTimePicker.TabIndex = 12;
            // 
            // pictureNameTextBox
            // 
            this.pictureNameTextBox.Location = new System.Drawing.Point(6, 32);
            this.pictureNameTextBox.Name = "pictureNameTextBox";
            this.pictureNameTextBox.Size = new System.Drawing.Size(220, 20);
            this.pictureNameTextBox.TabIndex = 13;
            this.pictureNameTextBox.Enter += new System.EventHandler(this.nameTextBox_Enter);
            this.pictureNameTextBox.Leave += new System.EventHandler(this.nameTextBox_Leave);
            // 
            // pictureNameLabel
            // 
            this.pictureNameLabel.AutoSize = true;
            this.pictureNameLabel.Location = new System.Drawing.Point(3, 16);
            this.pictureNameLabel.Name = "pictureNameLabel";
            this.pictureNameLabel.Size = new System.Drawing.Size(57, 13);
            this.pictureNameLabel.TabIndex = 14;
            this.pictureNameLabel.Text = "Название";
            // 
            // picturePictureBox
            // 
            this.picturePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picturePictureBox.Location = new System.Drawing.Point(232, 16);
            this.picturePictureBox.Name = "picturePictureBox";
            this.picturePictureBox.Size = new System.Drawing.Size(354, 354);
            this.picturePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picturePictureBox.TabIndex = 17;
            this.picturePictureBox.TabStop = false;
            // 
            // selectImageButton
            // 
            this.selectImageButton.Location = new System.Drawing.Point(5, 97);
            this.selectImageButton.Name = "selectImageButton";
            this.selectImageButton.Size = new System.Drawing.Size(75, 23);
            this.selectImageButton.TabIndex = 16;
            this.selectImageButton.Text = "Выбрать";
            this.selectImageButton.UseVisualStyleBackColor = true;
            this.selectImageButton.Click += new System.EventHandler(this.selectImageButton_Click);
            // 
            // pictureTypeComboBox
            // 
            this.pictureTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pictureTypeComboBox.FormattingEnabled = true;
            this.pictureTypeComboBox.Location = new System.Drawing.Point(6, 139);
            this.pictureTypeComboBox.Name = "pictureTypeComboBox";
            this.pictureTypeComboBox.Size = new System.Drawing.Size(220, 21);
            this.pictureTypeComboBox.TabIndex = 15;
            // 
            // pictureTypeLabel
            // 
            this.pictureTypeLabel.AutoSize = true;
            this.pictureTypeLabel.Location = new System.Drawing.Point(3, 123);
            this.pictureTypeLabel.Name = "pictureTypeLabel";
            this.pictureTypeLabel.Size = new System.Drawing.Size(76, 13);
            this.pictureTypeLabel.TabIndex = 14;
            this.pictureTypeLabel.Text = "Тип картинки";
            // 
            // imageFileNameLabel
            // 
            this.imageFileNameLabel.AutoSize = true;
            this.imageFileNameLabel.Location = new System.Drawing.Point(3, 55);
            this.imageFileNameLabel.Name = "imageFileNameLabel";
            this.imageFileNameLabel.Size = new System.Drawing.Size(64, 13);
            this.imageFileNameLabel.TabIndex = 12;
            this.imageFileNameLabel.Text = "Имя файла";
            // 
            // pictureCreationDateAndTimeLabel
            // 
            this.pictureCreationDateAndTimeLabel.AutoSize = true;
            this.pictureCreationDateAndTimeLabel.Location = new System.Drawing.Point(3, 163);
            this.pictureCreationDateAndTimeLabel.Name = "pictureCreationDateAndTimeLabel";
            this.pictureCreationDateAndTimeLabel.Size = new System.Drawing.Size(84, 13);
            this.pictureCreationDateAndTimeLabel.TabIndex = 13;
            this.pictureCreationDateAndTimeLabel.Text = "Дата создания";
            // 
            // imageFileNameTextBox
            // 
            this.imageFileNameTextBox.Enabled = false;
            this.imageFileNameTextBox.Location = new System.Drawing.Point(6, 71);
            this.imageFileNameTextBox.Name = "imageFileNameTextBox";
            this.imageFileNameTextBox.Size = new System.Drawing.Size(220, 20);
            this.imageFileNameTextBox.TabIndex = 11;
            // 
            // PictureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 475);
            this.Controls.Add(this.pictureInfoGroup);
            this.Name = "PictureForm";
            this.Text = "Картинка";
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.idInfoGroup, 0);
            this.Controls.SetChildIndex(this.descriptionInfoGroup, 0);
            this.Controls.SetChildIndex(this.noteInfoGroup, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.pictureInfoGroup, 0);
            this.idInfoGroup.ResumeLayout(false);
            this.idInfoGroup.PerformLayout();
            this.descriptionInfoGroup.ResumeLayout(false);
            this.descriptionInfoGroup.PerformLayout();
            this.noteInfoGroup.ResumeLayout(false);
            this.noteInfoGroup.PerformLayout();
            this.pictureInfoGroup.ResumeLayout(false);
            this.pictureInfoGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox pictureInfoGroup;
        private System.Windows.Forms.TextBox imageFileNameTextBox;
        private System.Windows.Forms.Label imageFileNameLabel;
        private System.Windows.Forms.ComboBox pictureTypeComboBox;
        private System.Windows.Forms.Label pictureTypeLabel;
        private System.Windows.Forms.Button selectImageButton;
        private System.Windows.Forms.PictureBox picturePictureBox;
        private System.Windows.Forms.TextBox pictureNameTextBox;
        private System.Windows.Forms.Label pictureNameLabel;
        private System.Windows.Forms.DateTimePicker pictureCreationDateDateTimePicker;
        private System.Windows.Forms.Label pictureCreationDateAndTimeLabel;
    }
}