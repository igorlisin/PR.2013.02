namespace PRUI.TemplateForms
{
    partial class TemplateEntityLocationForm
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
            this.homeInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.homeComplexNumberTextBox = new System.Windows.Forms.TextBox();
            this.homeComplexNumberLabel = new System.Windows.Forms.Label();
            this.homeNumberLabel = new System.Windows.Forms.Label();
            this.homeNumberTextBox = new System.Windows.Forms.TextBox();
            this.complexInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.complexNumberTextBox = new System.Windows.Forms.TextBox();
            this.unlinkComplexButton = new System.Windows.Forms.Button();
            this.relinkComplexButton = new System.Windows.Forms.Button();
            this.streetInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.streetNameTextBox = new System.Windows.Forms.TextBox();
            this.unlinkStreetButton = new System.Windows.Forms.Button();
            this.relinkStreetButton = new System.Windows.Forms.Button();
            this.cityInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.cityNameTextBox = new System.Windows.Forms.TextBox();
            this.unlinkCityButton = new System.Windows.Forms.Button();
            this.relinkCityButton = new System.Windows.Forms.Button();
            this.regionInfoGroup = new System.Windows.Forms.GroupBox();
            this.regionNameTextBox = new System.Windows.Forms.TextBox();
            this.unlinkRegionButton = new System.Windows.Forms.Button();
            this.relinkRegionButton = new System.Windows.Forms.Button();
            this.countryInfoGroup = new System.Windows.Forms.GroupBox();
            this.countryNameTextBox = new System.Windows.Forms.TextBox();
            this.unlinkCountryButton = new System.Windows.Forms.Button();
            this.relinkCountryButton = new System.Windows.Forms.Button();
            this.idInfoGroup.SuspendLayout();
            this.descriptionInfoGroup.SuspendLayout();
            this.noteInfoGroup.SuspendLayout();
            this.homeInfoGroupBox.SuspendLayout();
            this.complexInfoGroupBox.SuspendLayout();
            this.streetInfoGroupBox.SuspendLayout();
            this.cityInfoGroupBox.SuspendLayout();
            this.regionInfoGroup.SuspendLayout();
            this.countryInfoGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // homeInfoGroupBox
            // 
            this.homeInfoGroupBox.Controls.Add(this.homeComplexNumberTextBox);
            this.homeInfoGroupBox.Controls.Add(this.homeComplexNumberLabel);
            this.homeInfoGroupBox.Controls.Add(this.homeNumberLabel);
            this.homeInfoGroupBox.Controls.Add(this.homeNumberTextBox);
            this.homeInfoGroupBox.Location = new System.Drawing.Point(11, 274);
            this.homeInfoGroupBox.Name = "homeInfoGroupBox";
            this.homeInfoGroupBox.Size = new System.Drawing.Size(276, 61);
            this.homeInfoGroupBox.TabIndex = 56;
            this.homeInfoGroupBox.TabStop = false;
            this.homeInfoGroupBox.Text = "Дом";
            // 
            // homeComplexNumberTextBox
            // 
            this.homeComplexNumberTextBox.Location = new System.Drawing.Point(132, 32);
            this.homeComplexNumberTextBox.Name = "homeComplexNumberTextBox";
            this.homeComplexNumberTextBox.Size = new System.Drawing.Size(120, 20);
            this.homeComplexNumberTextBox.TabIndex = 51;
            this.homeComplexNumberTextBox.Enter += new System.EventHandler(this.homeComplexNumberTextBox_Enter);
            this.homeComplexNumberTextBox.Leave += new System.EventHandler(this.homeComplexNumberTextBox_Leave);
            // 
            // homeComplexNumberLabel
            // 
            this.homeComplexNumberLabel.AutoSize = true;
            this.homeComplexNumberLabel.Location = new System.Drawing.Point(129, 16);
            this.homeComplexNumberLabel.Name = "homeComplexNumberLabel";
            this.homeComplexNumberLabel.Size = new System.Drawing.Size(114, 13);
            this.homeComplexNumberLabel.TabIndex = 14;
            this.homeComplexNumberLabel.Text = "Номер по комплексу";
            // 
            // homeNumberLabel
            // 
            this.homeNumberLabel.AutoSize = true;
            this.homeNumberLabel.Location = new System.Drawing.Point(3, 16);
            this.homeNumberLabel.Name = "homeNumberLabel";
            this.homeNumberLabel.Size = new System.Drawing.Size(41, 13);
            this.homeNumberLabel.TabIndex = 12;
            this.homeNumberLabel.Text = "Номер";
            // 
            // homeNumberTextBox
            // 
            this.homeNumberTextBox.Location = new System.Drawing.Point(6, 32);
            this.homeNumberTextBox.Name = "homeNumberTextBox";
            this.homeNumberTextBox.Size = new System.Drawing.Size(120, 20);
            this.homeNumberTextBox.TabIndex = 11;
            this.homeNumberTextBox.Click += new System.EventHandler(this.homeNumberTextBox_Enter);
            this.homeNumberTextBox.Leave += new System.EventHandler(this.homeNumberTextBox_Leave);
            // 
            // complexInfoGroupBox
            // 
            this.complexInfoGroupBox.Controls.Add(this.complexNumberTextBox);
            this.complexInfoGroupBox.Controls.Add(this.unlinkComplexButton);
            this.complexInfoGroupBox.Controls.Add(this.relinkComplexButton);
            this.complexInfoGroupBox.Location = new System.Drawing.Point(11, 224);
            this.complexInfoGroupBox.Name = "complexInfoGroupBox";
            this.complexInfoGroupBox.Size = new System.Drawing.Size(276, 47);
            this.complexInfoGroupBox.TabIndex = 55;
            this.complexInfoGroupBox.TabStop = false;
            this.complexInfoGroupBox.Text = "Комплекс";
            // 
            // complexNumberTextBox
            // 
            this.complexNumberTextBox.Location = new System.Drawing.Point(6, 19);
            this.complexNumberTextBox.Name = "complexNumberTextBox";
            this.complexNumberTextBox.Size = new System.Drawing.Size(189, 20);
            this.complexNumberTextBox.TabIndex = 11;
            this.complexNumberTextBox.Enter += new System.EventHandler(this.complexNumberTextBox_Enter);
            this.complexNumberTextBox.Leave += new System.EventHandler(this.complexNumberTextBox_Leave);
            // 
            // unlinkComplexButton
            // 
            this.unlinkComplexButton.Image = global::PRUI.Properties.Resources.unlinkButton;
            this.unlinkComplexButton.Location = new System.Drawing.Point(237, 19);
            this.unlinkComplexButton.Name = "unlinkComplexButton";
            this.unlinkComplexButton.Size = new System.Drawing.Size(30, 20);
            this.unlinkComplexButton.TabIndex = 51;
            this.unlinkComplexButton.UseVisualStyleBackColor = true;
            this.unlinkComplexButton.Click += new System.EventHandler(this.unlinkComplexButton_Click);
            // 
            // relinkComplexButton
            // 
            this.relinkComplexButton.Image = global::PRUI.Properties.Resources.linkButton;
            this.relinkComplexButton.Location = new System.Drawing.Point(201, 19);
            this.relinkComplexButton.Name = "relinkComplexButton";
            this.relinkComplexButton.Size = new System.Drawing.Size(30, 20);
            this.relinkComplexButton.TabIndex = 47;
            this.relinkComplexButton.UseVisualStyleBackColor = true;
            this.relinkComplexButton.Click += new System.EventHandler(this.relinkComplexButton_Click);
            // 
            // streetInfoGroupBox
            // 
            this.streetInfoGroupBox.Controls.Add(this.streetNameTextBox);
            this.streetInfoGroupBox.Controls.Add(this.unlinkStreetButton);
            this.streetInfoGroupBox.Controls.Add(this.relinkStreetButton);
            this.streetInfoGroupBox.Location = new System.Drawing.Point(11, 171);
            this.streetInfoGroupBox.Name = "streetInfoGroupBox";
            this.streetInfoGroupBox.Size = new System.Drawing.Size(276, 47);
            this.streetInfoGroupBox.TabIndex = 54;
            this.streetInfoGroupBox.TabStop = false;
            this.streetInfoGroupBox.Text = "Улица";
            // 
            // streetNameTextBox
            // 
            this.streetNameTextBox.Location = new System.Drawing.Point(6, 19);
            this.streetNameTextBox.Name = "streetNameTextBox";
            this.streetNameTextBox.Size = new System.Drawing.Size(189, 20);
            this.streetNameTextBox.TabIndex = 11;
            this.streetNameTextBox.Enter += new System.EventHandler(this.streetNameTextBox_Enter);
            this.streetNameTextBox.Leave += new System.EventHandler(this.streetNameTextBox_Leave);
            // 
            // unlinkStreetButton
            // 
            this.unlinkStreetButton.Image = global::PRUI.Properties.Resources.unlinkButton;
            this.unlinkStreetButton.Location = new System.Drawing.Point(237, 19);
            this.unlinkStreetButton.Name = "unlinkStreetButton";
            this.unlinkStreetButton.Size = new System.Drawing.Size(30, 20);
            this.unlinkStreetButton.TabIndex = 52;
            this.unlinkStreetButton.UseVisualStyleBackColor = true;
            this.unlinkStreetButton.Click += new System.EventHandler(this.unlinkStreetButton_Click);
            // 
            // relinkStreetButton
            // 
            this.relinkStreetButton.Image = global::PRUI.Properties.Resources.linkButton;
            this.relinkStreetButton.Location = new System.Drawing.Point(201, 19);
            this.relinkStreetButton.Name = "relinkStreetButton";
            this.relinkStreetButton.Size = new System.Drawing.Size(30, 20);
            this.relinkStreetButton.TabIndex = 46;
            this.relinkStreetButton.UseVisualStyleBackColor = true;
            this.relinkStreetButton.Click += new System.EventHandler(this.relinkStreetButton_Click);
            // 
            // cityInfoGroupBox
            // 
            this.cityInfoGroupBox.Controls.Add(this.cityNameTextBox);
            this.cityInfoGroupBox.Controls.Add(this.unlinkCityButton);
            this.cityInfoGroupBox.Controls.Add(this.relinkCityButton);
            this.cityInfoGroupBox.Location = new System.Drawing.Point(11, 118);
            this.cityInfoGroupBox.Name = "cityInfoGroupBox";
            this.cityInfoGroupBox.Size = new System.Drawing.Size(276, 47);
            this.cityInfoGroupBox.TabIndex = 53;
            this.cityInfoGroupBox.TabStop = false;
            this.cityInfoGroupBox.Text = "Город";
            // 
            // cityNameTextBox
            // 
            this.cityNameTextBox.Location = new System.Drawing.Point(6, 19);
            this.cityNameTextBox.Name = "cityNameTextBox";
            this.cityNameTextBox.Size = new System.Drawing.Size(189, 20);
            this.cityNameTextBox.TabIndex = 11;
            // 
            // unlinkCityButton
            // 
            this.unlinkCityButton.Image = global::PRUI.Properties.Resources.unlinkButton;
            this.unlinkCityButton.Location = new System.Drawing.Point(237, 19);
            this.unlinkCityButton.Name = "unlinkCityButton";
            this.unlinkCityButton.Size = new System.Drawing.Size(30, 20);
            this.unlinkCityButton.TabIndex = 54;
            this.unlinkCityButton.UseVisualStyleBackColor = true;
            this.unlinkCityButton.Click += new System.EventHandler(this.unlinkCityButton_Click);
            // 
            // relinkCityButton
            // 
            this.relinkCityButton.Image = global::PRUI.Properties.Resources.linkButton;
            this.relinkCityButton.Location = new System.Drawing.Point(201, 19);
            this.relinkCityButton.Name = "relinkCityButton";
            this.relinkCityButton.Size = new System.Drawing.Size(30, 20);
            this.relinkCityButton.TabIndex = 53;
            this.relinkCityButton.UseVisualStyleBackColor = true;
            this.relinkCityButton.Click += new System.EventHandler(this.relinkCityButton_Click);
            // 
            // regionInfoGroup
            // 
            this.regionInfoGroup.Controls.Add(this.regionNameTextBox);
            this.regionInfoGroup.Controls.Add(this.unlinkRegionButton);
            this.regionInfoGroup.Controls.Add(this.relinkRegionButton);
            this.regionInfoGroup.Location = new System.Drawing.Point(11, 65);
            this.regionInfoGroup.Name = "regionInfoGroup";
            this.regionInfoGroup.Size = new System.Drawing.Size(276, 47);
            this.regionInfoGroup.TabIndex = 52;
            this.regionInfoGroup.TabStop = false;
            this.regionInfoGroup.Text = "Регион";
            // 
            // regionNameTextBox
            // 
            this.regionNameTextBox.Location = new System.Drawing.Point(6, 19);
            this.regionNameTextBox.Name = "regionNameTextBox";
            this.regionNameTextBox.Size = new System.Drawing.Size(189, 20);
            this.regionNameTextBox.TabIndex = 11;
            this.regionNameTextBox.Enter += new System.EventHandler(this.regionNameTextBox_Enter);
            this.regionNameTextBox.Leave += new System.EventHandler(this.regionNameTextBox_Leave);
            // 
            // unlinkRegionButton
            // 
            this.unlinkRegionButton.Image = global::PRUI.Properties.Resources.unlinkButton;
            this.unlinkRegionButton.Location = new System.Drawing.Point(237, 19);
            this.unlinkRegionButton.Name = "unlinkRegionButton";
            this.unlinkRegionButton.Size = new System.Drawing.Size(30, 20);
            this.unlinkRegionButton.TabIndex = 58;
            this.unlinkRegionButton.UseVisualStyleBackColor = true;
            this.unlinkRegionButton.Click += new System.EventHandler(this.unlinkRegionButton_Click);
            // 
            // relinkRegionButton
            // 
            this.relinkRegionButton.Image = global::PRUI.Properties.Resources.linkButton;
            this.relinkRegionButton.Location = new System.Drawing.Point(201, 19);
            this.relinkRegionButton.Name = "relinkRegionButton";
            this.relinkRegionButton.Size = new System.Drawing.Size(30, 20);
            this.relinkRegionButton.TabIndex = 57;
            this.relinkRegionButton.UseVisualStyleBackColor = true;
            this.relinkRegionButton.Click += new System.EventHandler(this.relinkRegionButton_Click);
            // 
            // countryInfoGroup
            // 
            this.countryInfoGroup.Controls.Add(this.countryNameTextBox);
            this.countryInfoGroup.Controls.Add(this.unlinkCountryButton);
            this.countryInfoGroup.Controls.Add(this.relinkCountryButton);
            this.countryInfoGroup.Location = new System.Drawing.Point(11, 12);
            this.countryInfoGroup.Name = "countryInfoGroup";
            this.countryInfoGroup.Size = new System.Drawing.Size(276, 47);
            this.countryInfoGroup.TabIndex = 51;
            this.countryInfoGroup.TabStop = false;
            this.countryInfoGroup.Text = "Страна";
            // 
            // countryNameTextBox
            // 
            this.countryNameTextBox.Location = new System.Drawing.Point(6, 19);
            this.countryNameTextBox.Name = "countryNameTextBox";
            this.countryNameTextBox.Size = new System.Drawing.Size(189, 20);
            this.countryNameTextBox.TabIndex = 11;
            this.countryNameTextBox.Enter += new System.EventHandler(this.countryNameTextBox_Enter);
            this.countryNameTextBox.Leave += new System.EventHandler(this.regionNameTextBox_Leave);
            // 
            // unlinkCountryButton
            // 
            this.unlinkCountryButton.Image = global::PRUI.Properties.Resources.unlinkButton;
            this.unlinkCountryButton.Location = new System.Drawing.Point(237, 19);
            this.unlinkCountryButton.Name = "unlinkCountryButton";
            this.unlinkCountryButton.Size = new System.Drawing.Size(30, 20);
            this.unlinkCountryButton.TabIndex = 58;
            this.unlinkCountryButton.UseVisualStyleBackColor = true;
            this.unlinkCountryButton.Click += new System.EventHandler(this.unlinkCountryButton_Click);
            // 
            // relinkCountryButton
            // 
            this.relinkCountryButton.Image = global::PRUI.Properties.Resources.linkButton;
            this.relinkCountryButton.Location = new System.Drawing.Point(201, 19);
            this.relinkCountryButton.Name = "relinkCountryButton";
            this.relinkCountryButton.Size = new System.Drawing.Size(30, 20);
            this.relinkCountryButton.TabIndex = 57;
            this.relinkCountryButton.UseVisualStyleBackColor = true;
            this.relinkCountryButton.Click += new System.EventHandler(this.relinkCountryButton_Click);
            // 
            // TemplateEntityLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 478);
            this.Controls.Add(this.homeInfoGroupBox);
            this.Controls.Add(this.complexInfoGroupBox);
            this.Controls.Add(this.streetInfoGroupBox);
            this.Controls.Add(this.cityInfoGroupBox);
            this.Controls.Add(this.regionInfoGroup);
            this.Controls.Add(this.countryInfoGroup);
            this.Name = "TemplateEntityLocationForm";
            this.Text = "TemplateEntityLocationForm";
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.idInfoGroup, 0);
            this.Controls.SetChildIndex(this.descriptionInfoGroup, 0);
            this.Controls.SetChildIndex(this.noteInfoGroup, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.countryInfoGroup, 0);
            this.Controls.SetChildIndex(this.regionInfoGroup, 0);
            this.Controls.SetChildIndex(this.cityInfoGroupBox, 0);
            this.Controls.SetChildIndex(this.streetInfoGroupBox, 0);
            this.Controls.SetChildIndex(this.complexInfoGroupBox, 0);
            this.Controls.SetChildIndex(this.homeInfoGroupBox, 0);
            this.idInfoGroup.ResumeLayout(false);
            this.idInfoGroup.PerformLayout();
            this.descriptionInfoGroup.ResumeLayout(false);
            this.descriptionInfoGroup.PerformLayout();
            this.noteInfoGroup.ResumeLayout(false);
            this.noteInfoGroup.PerformLayout();
            this.homeInfoGroupBox.ResumeLayout(false);
            this.homeInfoGroupBox.PerformLayout();
            this.complexInfoGroupBox.ResumeLayout(false);
            this.complexInfoGroupBox.PerformLayout();
            this.streetInfoGroupBox.ResumeLayout(false);
            this.streetInfoGroupBox.PerformLayout();
            this.cityInfoGroupBox.ResumeLayout(false);
            this.cityInfoGroupBox.PerformLayout();
            this.regionInfoGroup.ResumeLayout(false);
            this.regionInfoGroup.PerformLayout();
            this.countryInfoGroup.ResumeLayout(false);
            this.countryInfoGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox regionInfoGroup;
        protected System.Windows.Forms.TextBox regionNameTextBox;
        protected System.Windows.Forms.GroupBox countryInfoGroup;
        protected System.Windows.Forms.TextBox countryNameTextBox;
        protected System.Windows.Forms.Button unlinkRegionButton;
        protected System.Windows.Forms.Button relinkRegionButton;
        protected System.Windows.Forms.Button unlinkCountryButton;
        protected System.Windows.Forms.Button relinkCountryButton;
        protected System.Windows.Forms.GroupBox homeInfoGroupBox;
        protected System.Windows.Forms.TextBox homeComplexNumberTextBox;
        protected System.Windows.Forms.Label homeComplexNumberLabel;
        protected System.Windows.Forms.Label homeNumberLabel;
        protected System.Windows.Forms.TextBox homeNumberTextBox;
        protected System.Windows.Forms.GroupBox complexInfoGroupBox;
        protected System.Windows.Forms.TextBox complexNumberTextBox;
        protected System.Windows.Forms.GroupBox streetInfoGroupBox;
        protected System.Windows.Forms.TextBox streetNameTextBox;
        protected System.Windows.Forms.GroupBox cityInfoGroupBox;
        protected System.Windows.Forms.TextBox cityNameTextBox;
        protected System.Windows.Forms.Button relinkStreetButton;
        protected System.Windows.Forms.Button unlinkComplexButton;
        protected System.Windows.Forms.Button relinkComplexButton;
        protected System.Windows.Forms.Button unlinkStreetButton;
        protected System.Windows.Forms.Button unlinkCityButton;
        protected System.Windows.Forms.Button relinkCityButton;
    }
}