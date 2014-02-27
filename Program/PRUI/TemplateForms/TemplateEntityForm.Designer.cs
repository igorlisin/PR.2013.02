namespace PRUI.TemplateForms
{
    partial class TemplateEntityForm
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
            this.saveButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.idInfoGroup = new System.Windows.Forms.GroupBox();
            this.descriptionInfoGroup = new System.Windows.Forms.GroupBox();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.noteInfoGroup = new System.Windows.Forms.GroupBox();
            this.idInfoGroup.SuspendLayout();
            this.descriptionInfoGroup.SuspendLayout();
            this.noteInfoGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(512, 447);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(93, 447);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 447);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // idTextBox
            // 
            this.idTextBox.Enabled = false;
            this.idTextBox.Location = new System.Drawing.Point(6, 19);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(281, 20);
            this.idTextBox.TabIndex = 4;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(9, 19);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(278, 245);
            this.descriptionTextBox.TabIndex = 6;
            // 
            // idInfoGroup
            // 
            this.idInfoGroup.Controls.Add(this.idTextBox);
            this.idInfoGroup.Location = new System.Drawing.Point(293, 12);
            this.idInfoGroup.Name = "idInfoGroup";
            this.idInfoGroup.Size = new System.Drawing.Size(293, 47);
            this.idInfoGroup.TabIndex = 7;
            this.idInfoGroup.TabStop = false;
            this.idInfoGroup.Text = "Идентификатор";
            // 
            // descriptionInfoGroup
            // 
            this.descriptionInfoGroup.Controls.Add(this.descriptionTextBox);
            this.descriptionInfoGroup.Location = new System.Drawing.Point(293, 65);
            this.descriptionInfoGroup.Name = "descriptionInfoGroup";
            this.descriptionInfoGroup.Size = new System.Drawing.Size(293, 270);
            this.descriptionInfoGroup.TabIndex = 8;
            this.descriptionInfoGroup.TabStop = false;
            this.descriptionInfoGroup.Text = "Описание";
            // 
            // noteTextBox
            // 
            this.noteTextBox.Enabled = false;
            this.noteTextBox.Location = new System.Drawing.Point(9, 19);
            this.noteTextBox.Multiline = true;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(278, 75);
            this.noteTextBox.TabIndex = 0;
            // 
            // noteInfoGroup
            // 
            this.noteInfoGroup.Controls.Add(this.noteTextBox);
            this.noteInfoGroup.Location = new System.Drawing.Point(293, 341);
            this.noteInfoGroup.Name = "noteInfoGroup";
            this.noteInfoGroup.Size = new System.Drawing.Size(293, 100);
            this.noteInfoGroup.TabIndex = 9;
            this.noteInfoGroup.TabStop = false;
            this.noteInfoGroup.Text = "Примечание";
            // 
            // TemplateEntityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 478);
            this.Controls.Add(this.noteInfoGroup);
            this.Controls.Add(this.descriptionInfoGroup);
            this.Controls.Add(this.idInfoGroup);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.saveButton);
            this.Name = "TemplateEntityForm";
            this.Text = "TemplateEntityDialogForm";
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
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button saveButton;
        protected System.Windows.Forms.Button okButton;
        protected System.Windows.Forms.TextBox idTextBox;
        protected System.Windows.Forms.TextBox descriptionTextBox;
        protected System.Windows.Forms.GroupBox idInfoGroup;
        protected System.Windows.Forms.GroupBox descriptionInfoGroup;
        protected System.Windows.Forms.TextBox noteTextBox;
        protected System.Windows.Forms.GroupBox noteInfoGroup;
    }
}