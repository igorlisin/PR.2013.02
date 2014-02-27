namespace PRUI.Forms
{
    partial class DocumentForm
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
            this.documentDateOfIssueMonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.documentInfoGroup.SuspendLayout();
            this.manInfoGroup.SuspendLayout();
            this.idInfoGroup.SuspendLayout();
            this.descriptionInfoGroup.SuspendLayout();
            this.noteInfoGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // documentInfoGroup
            // 
            this.documentInfoGroup.Controls.Add(this.documentDateOfIssueMonthCalendar);
            this.documentInfoGroup.Size = new System.Drawing.Size(276, 386);
            this.documentInfoGroup.Controls.SetChildIndex(this.documentDateOfIssueMonthCalendar, 0);
            this.documentInfoGroup.Controls.SetChildIndex(this.documentSeriesTextBox, 0);
            this.documentInfoGroup.Controls.SetChildIndex(this.documentNumberTextBox, 0);
            this.documentInfoGroup.Controls.SetChildIndex(this.documentDateOfIssueLabel, 0);
            this.documentInfoGroup.Controls.SetChildIndex(this.documentDateOfIssueTextBox, 0);
            this.documentInfoGroup.Controls.SetChildIndex(this.documentPlaceOfIssueLabel, 0);
            this.documentInfoGroup.Controls.SetChildIndex(this.documentPlaceOfIssueTextBox, 0);
            this.documentInfoGroup.Controls.SetChildIndex(this.documentSeriesNumberLabel, 0);
            this.documentInfoGroup.Controls.SetChildIndex(this.documentTypeLabel, 0);
            this.documentInfoGroup.Controls.SetChildIndex(this.unlinkDocumentButton, 0);
            this.documentInfoGroup.Controls.SetChildIndex(this.relinkDocumentButton, 0);
            this.documentInfoGroup.Controls.SetChildIndex(this.documentTypeComboBox, 0);
            // 
            // documentTypeComboBox
            // 
            this.documentTypeComboBox.Size = new System.Drawing.Size(261, 21);
            // 
            // documentPlaceOfIssueTextBox
            // 
            this.documentPlaceOfIssueTextBox.Location = new System.Drawing.Point(9, 296);
            // 
            // documentPlaceOfIssueLabel
            // 
            this.documentPlaceOfIssueLabel.Location = new System.Drawing.Point(6, 280);
            // 
            // documentDateOfIssueTextBox
            // 
            this.documentDateOfIssueTextBox.Enter += new System.EventHandler(this.documentDateOfIssueTextBox_Enter);
            this.documentDateOfIssueTextBox.Leave += new System.EventHandler(this.documentDateOfIssueTextBox_Leave);
            // 
            // manInfoGroup
            // 
            this.manInfoGroup.Location = new System.Drawing.Point(592, 12);
            this.manInfoGroup.Visible = false;
            // 
            // relinkDocumentButton
            // 
            this.relinkDocumentButton.Visible = false;
            // 
            // unlinkDocumentButton
            // 
            this.unlinkDocumentButton.Visible = false;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(92, 453);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(11, 453);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(511, 453);
            // 
            // documentDateOfIssueMonthCalendar
            // 
            this.documentDateOfIssueMonthCalendar.Location = new System.Drawing.Point(8, 123);
            this.documentDateOfIssueMonthCalendar.MaxSelectionCount = 1;
            this.documentDateOfIssueMonthCalendar.Name = "documentDateOfIssueMonthCalendar";
            this.documentDateOfIssueMonthCalendar.ShowToday = false;
            this.documentDateOfIssueMonthCalendar.ShowWeekNumbers = true;
            this.documentDateOfIssueMonthCalendar.TabIndex = 8;
            this.documentDateOfIssueMonthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendarMonthCalendar_DateChanged);
            // 
            // DocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 485);
            this.Name = "DocumentForm";
            this.Text = "Документ";
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

        private System.Windows.Forms.MonthCalendar documentDateOfIssueMonthCalendar;
    }
}