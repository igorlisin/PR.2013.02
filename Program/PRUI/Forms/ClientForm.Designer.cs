namespace PRUI.Forms
{
    partial class ClientForm
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
            this.ClientAddressTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.documentInfoGroup.SuspendLayout();
            this.manInfoGroup.SuspendLayout();
            this.idInfoGroup.SuspendLayout();
            this.descriptionInfoGroup.SuspendLayout();
            this.noteInfoGroup.SuspendLayout();
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
            // ClientAddressTextBox
            // 
            this.ClientAddressTextBox.Location = new System.Drawing.Point(20, 376);
            this.ClientAddressTextBox.Multiline = true;
            this.ClientAddressTextBox.Name = "ClientAddressTextBox";
            this.ClientAddressTextBox.Size = new System.Drawing.Size(261, 43);
            this.ClientAddressTextBox.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Адрес";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 478);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClientAddressTextBox);
            this.Name = "ClientForm";
            this.Text = "Клиент";
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.idInfoGroup, 0);
            this.Controls.SetChildIndex(this.descriptionInfoGroup, 0);
            this.Controls.SetChildIndex(this.noteInfoGroup, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.documentInfoGroup, 0);
            this.Controls.SetChildIndex(this.manInfoGroup, 0);
            this.Controls.SetChildIndex(this.ClientAddressTextBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ClientAddressTextBox;
        private System.Windows.Forms.Label label1;
    }
}