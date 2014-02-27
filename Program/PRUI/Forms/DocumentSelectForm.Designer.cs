namespace PRUI.Forms
{
    partial class DocumentSelectForm
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
            this.SuspendLayout();
            // 
            // selectButton
            // 
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(523, 406);
            // 
            // DocumentSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 441);
            this.Name = "DocumentSelectForm";
            this.Text = "Выбор документа";
            this.ResumeLayout(false);

        }

        #endregion
    }
}