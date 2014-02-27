namespace PRUI.Forms
{
    partial class EntityForm
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
            this.idInfoGroup.SuspendLayout();
            this.descriptionInfoGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // idTextBox
            // 
            this.idTextBox.Size = new System.Drawing.Size(278, 20);
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Size = new System.Drawing.Size(278, 123);
            // 
            // baseInfoGroup
            // 
            this.idInfoGroup.Size = new System.Drawing.Size(293, 63);
            // 
            // additionalInfoGroup
            // 
            this.descriptionInfoGroup.Location = new System.Drawing.Point(12, 81);
            this.descriptionInfoGroup.Size = new System.Drawing.Size(293, 161);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(174, 248);
            // 
            // EntityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 277);
            this.Name = "EntityForm";
            this.Text = "Сущность";
            this.idInfoGroup.ResumeLayout(false);
            this.idInfoGroup.PerformLayout();
            this.descriptionInfoGroup.ResumeLayout(false);
            this.descriptionInfoGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}