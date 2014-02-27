namespace PRUI.Forms
{
    partial class ManForm
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
            // relinkManButton
            // 
            this.relinkManButton.Visible = false;
            // 
            // unlinkManButton
            // 
            this.unlinkManButton.Visible = false;
            // 
            // ManForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 478);
            this.Name = "ManForm";
            this.Text = "Человек";
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

        }

        #endregion
    }
}