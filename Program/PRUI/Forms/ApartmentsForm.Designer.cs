namespace PRUI.Forms
{
    partial class ApartmentsForm
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
            this.components = new System.ComponentModel.Container();
            this.addContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addByHomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addContextMenuStrip.SuspendLayout();
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
            this.closeButton.Location = new System.Drawing.Point(1215, 406);
            // 
            // addContextMenuStrip
            // 
            this.addContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.addByHomeToolStripMenuItem});
            this.addContextMenuStrip.Name = "contextMenuStrip1";
            this.addContextMenuStrip.Size = new System.Drawing.Size(163, 48);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Enabled = false;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.addToolStripMenuItem.Text = "Новый";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // addByHomeToolStripMenuItem
            // 
            this.addByHomeToolStripMenuItem.Name = "addByHomeToolStripMenuItem";
            this.addByHomeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.addByHomeToolStripMenuItem.Text = "На основе дома";
            this.addByHomeToolStripMenuItem.Click += new System.EventHandler(this.addByStreetToolStripMenuItem_Click);
            // 
            // ApartmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 437);
            this.Name = "ApartmentsForm";
            this.Text = "Список квартир";
            this.Controls.SetChildIndex(this.removeButton, 0);
            this.Controls.SetChildIndex(this.addButton, 0);
            this.Controls.SetChildIndex(this.editButton, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.addContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip addContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addByHomeToolStripMenuItem;
    }
}