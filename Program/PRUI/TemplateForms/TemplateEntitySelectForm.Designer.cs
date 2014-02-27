namespace PRUI.TemplateForms
{
    partial class TemplateEntitySelectForm
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
            this.selectButton = new System.Windows.Forms.Button();
            this.entitiesDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.entitiesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(174, 406);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(12, 406);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(75, 23);
            this.selectButton.TabIndex = 4;
            this.selectButton.Text = "Выбрать";
            this.selectButton.UseVisualStyleBackColor = true;
            // 
            // entitiesDataGridView
            // 
            this.entitiesDataGridView.AllowUserToAddRows = false;
            this.entitiesDataGridView.AllowUserToDeleteRows = false;
            this.entitiesDataGridView.AllowUserToResizeColumns = false;
            this.entitiesDataGridView.AllowUserToResizeRows = false;
            this.entitiesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.entitiesDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.entitiesDataGridView.Location = new System.Drawing.Point(12, 12);
            this.entitiesDataGridView.MultiSelect = false;
            this.entitiesDataGridView.Name = "entitiesDataGridView";
            this.entitiesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.entitiesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.entitiesDataGridView.Size = new System.Drawing.Size(237, 388);
            this.entitiesDataGridView.TabIndex = 5;
            // 
            // TemplateEntitySelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 441);
            this.Controls.Add(this.entitiesDataGridView);
            this.Controls.Add(this.selectButton);
            this.Name = "TemplateEntitySelectForm";
            this.Text = "TemplateEntitySelectForm";
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.selectButton, 0);
            this.Controls.SetChildIndex(this.entitiesDataGridView, 0);
            ((System.ComponentModel.ISupportInitialize)(this.entitiesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.DataGridView entitiesDataGridView;
        protected System.Windows.Forms.Button selectButton;
    }
}