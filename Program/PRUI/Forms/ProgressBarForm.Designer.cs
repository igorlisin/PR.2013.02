namespace PRUI.Forms
{
    partial class ProgressBarForm
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
            this.progressProgressBar = new System.Windows.Forms.ProgressBar();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(12, 54);
            this.closeButton.Visible = false;
            // 
            // progressProgressBar
            // 
            this.progressProgressBar.Location = new System.Drawing.Point(12, 25);
            this.progressProgressBar.Name = "progressProgressBar";
            this.progressProgressBar.Size = new System.Drawing.Size(464, 23);
            this.progressProgressBar.TabIndex = 4;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(9, 9);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(22, 13);
            this.descriptionLabel.TabIndex = 5;
            this.descriptionLabel.Text = "-----";
            // 
            // progressLabel
            // 
            this.progressLabel.Location = new System.Drawing.Point(376, 51);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(100, 13);
            this.progressLabel.TabIndex = 6;
            this.progressLabel.Text = "--";
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ProgressBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 83);
            this.ControlBox = false;
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.progressProgressBar);
            this.Name = "ProgressBarForm";
            this.Text = "Прогресс выполнения операции";
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.progressProgressBar, 0);
            this.Controls.SetChildIndex(this.descriptionLabel, 0);
            this.Controls.SetChildIndex(this.progressLabel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressProgressBar;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label progressLabel;
    }
}