namespace PRUI.TemplateForms
{
    partial class TemplateEntityListForm
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
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.entitiesDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.entitiesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(255, 406);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(174, 406);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Изменить";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 406);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(93, 406);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 0;
            this.removeButton.Text = "Удалить";
            this.removeButton.UseVisualStyleBackColor = true;
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
            this.entitiesDataGridView.TabIndex = 3;
            // 
            // TemplateEntityListDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 437);
            this.Controls.Add(this.entitiesDataGridView);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.removeButton);
            this.Name = "TemplateEntityListDialogForm";
            this.Text = "TemplateEntityListDialogForm";
            this.Controls.SetChildIndex(this.removeButton, 0);
            this.Controls.SetChildIndex(this.addButton, 0);
            this.Controls.SetChildIndex(this.editButton, 0);
            this.Controls.SetChildIndex(this.closeButton, 0);
            this.Controls.SetChildIndex(this.entitiesDataGridView, 0);
            ((System.ComponentModel.ISupportInitialize)(this.entitiesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button removeButton;
        protected System.Windows.Forms.Button addButton;
        protected System.Windows.Forms.Button editButton;
        protected System.Windows.Forms.DataGridView entitiesDataGridView;
    }
}