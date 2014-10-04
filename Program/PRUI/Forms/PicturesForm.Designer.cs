namespace PRUI.Forms
{
    partial class PicturesForm
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
            this.btnChoiseApart = new System.Windows.Forms.Button();
            this.labelApart = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // removeButton
            // 
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(762, 406);
            // 
            // previewImageButton
            // 
            this.previewImageButton.Location = new System.Drawing.Point(256, 406);
            this.previewImageButton.Name = "previewImageButton";
            this.previewImageButton.Size = new System.Drawing.Size(75, 23);
            this.previewImageButton.TabIndex = 4;
            this.previewImageButton.Text = "Просмотр";
            this.previewImageButton.UseVisualStyleBackColor = true;
            this.previewImageButton.Click += new System.EventHandler(this.previewImageButton_Click);
            // 
            // btnChoiseApart
            // 
            this.btnChoiseApart.Location = new System.Drawing.Point(352, 406);
            this.btnChoiseApart.Name = "btnChoiseApart";
            this.btnChoiseApart.Size = new System.Drawing.Size(110, 23);
            this.btnChoiseApart.TabIndex = 5;
            this.btnChoiseApart.Text = "Выбрать квартиру";
            this.btnChoiseApart.UseVisualStyleBackColor = true;
            this.btnChoiseApart.Click += new System.EventHandler(this.btnChoiseApart_Click);
            // 
            // labelApart
            // 
            this.labelApart.AutoSize = true;
            this.labelApart.Location = new System.Drawing.Point(521, 411);
            this.labelApart.Name = "labelApart";
            this.labelApart.Size = new System.Drawing.Size(0, 13);
            this.labelApart.TabIndex = 6;
            // 
            // PicturesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 440);
            this.Controls.Add(this.labelApart);
            this.Controls.Add(this.btnChoiseApart);
            this.Controls.Add(this.previewImageButton);
            this.Name = "PicturesForm";
            this.Text = "Список картинок";
            this.Controls.SetChildIndex(this.removeButton, 0);
            this.Controls.SetChildIndex(this.addButton, 0);
            this.Controls.SetChildIndex(this.editButton, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.previewImageButton, 0);
            this.Controls.SetChildIndex(this.btnChoiseApart, 0);
            this.Controls.SetChildIndex(this.labelApart, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button previewImageButton;
        private System.Windows.Forms.Button btnChoiseApart;
        private System.Windows.Forms.Label labelApart;
    }
}