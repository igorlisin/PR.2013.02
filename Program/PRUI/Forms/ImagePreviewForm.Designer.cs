namespace PRUI.Forms
{
    partial class ImagePreviewForm
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
            this.imageToPriviewPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageToPriviewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(576, 498);
            // 
            // imageToPriviewPictureBox
            // 
            this.imageToPriviewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageToPriviewPictureBox.Location = new System.Drawing.Point(12, 12);
            this.imageToPriviewPictureBox.Name = "imageToPriviewPictureBox";
            this.imageToPriviewPictureBox.Size = new System.Drawing.Size(640, 480);
            this.imageToPriviewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imageToPriviewPictureBox.TabIndex = 4;
            this.imageToPriviewPictureBox.TabStop = false;
            // 
            // ImagePreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 528);
            this.Controls.Add(this.imageToPriviewPictureBox);
            this.Name = "ImagePreviewForm";
            this.Text = "Предварительный просмотр изображения";
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.imageToPriviewPictureBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.imageToPriviewPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imageToPriviewPictureBox;
    }
}