namespace PRUI.Forms
{
    partial class ImageSelectForm
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
            this.previewImageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectButton
            // 
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(682, 406);
            // 
            // previewImageButton
            // 
            this.previewImageButton.Location = new System.Drawing.Point(94, 406);
            this.previewImageButton.Name = "previewImageButton";
            this.previewImageButton.Size = new System.Drawing.Size(75, 23);
            this.previewImageButton.TabIndex = 6;
            this.previewImageButton.Text = "Просмотр";
            this.previewImageButton.UseVisualStyleBackColor = true;
            this.previewImageButton.Click += new System.EventHandler(this.previewImageButton_Click);
            // 
            // ImageSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 441);
            this.Controls.Add(this.previewImageButton);
            this.Name = "ImageSelectForm";
            this.Text = "Форма выбора изображения";
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.selectButton, 0);
            this.Controls.SetChildIndex(this.previewImageButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button previewImageButton;
    }
}