namespace PRUI.Forms
{
    partial class HomesForm
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
            this.addByStreetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addByComplexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.closeButton.Location = new System.Drawing.Point(1388, 406);
            // 
            // addContextMenuStrip
            // 
            this.addContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.addByStreetToolStripMenuItem,
            this.addByComplexToolStripMenuItem});
            this.addContextMenuStrip.Name = "contextMenuStrip1";
            this.addContextMenuStrip.Size = new System.Drawing.Size(195, 70);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Enabled = false;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.addToolStripMenuItem.Text = "Новый";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // addByStreetToolStripMenuItem
            // 
            this.addByStreetToolStripMenuItem.Name = "addByStreetToolStripMenuItem";
            this.addByStreetToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.addByStreetToolStripMenuItem.Text = "На основе улицы";
            this.addByStreetToolStripMenuItem.Click += new System.EventHandler(this.addByStreetToolStripMenuItem_Click);
            // 
            // addByComplexToolStripMenuItem
            // 
            this.addByComplexToolStripMenuItem.Enabled = false;
            this.addByComplexToolStripMenuItem.Name = "addByComplexToolStripMenuItem";
            this.addByComplexToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.addByComplexToolStripMenuItem.Text = "На основе комплекса";
            this.addByComplexToolStripMenuItem.Click += new System.EventHandler(this.addByComplexToolStripMenuItem_Click);
            // 
            // HomesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 437);
            this.Name = "HomesForm";
            this.Text = "Список домов";
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
        private System.Windows.Forms.ToolStripMenuItem addByStreetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addByComplexToolStripMenuItem;
    }
}