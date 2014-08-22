namespace PRParser
{
    partial class ParserForm
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
            this.apartmentDataGridView = new System.Windows.Forms.DataGridView();
            this.AddToReportButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DeleteAnalogs = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // apartmentDataGridView
            // 
            this.apartmentDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.apartmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.apartmentDataGridView.Location = new System.Drawing.Point(12, 12);
            this.apartmentDataGridView.Name = "apartmentDataGridView";
            this.apartmentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.apartmentDataGridView.Size = new System.Drawing.Size(860, 408);
            this.apartmentDataGridView.TabIndex = 1;
            // 
            // AddToReportButton
            // 
            this.AddToReportButton.Location = new System.Drawing.Point(12, 443);
            this.AddToReportButton.Name = "AddToReportButton";
            this.AddToReportButton.Size = new System.Drawing.Size(139, 23);
            this.AddToReportButton.TabIndex = 6;
            this.AddToReportButton.Text = "Ввести коэффициенты";
            this.AddToReportButton.UseVisualStyleBackColor = true;
            this.AddToReportButton.Click += new System.EventHandler(this.AddToReportButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(284, 443);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Отобразить в браузере";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(752, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Получить данные";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(171, 443);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(98, 23);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DeleteAnalogs
            // 
            this.DeleteAnalogs.Location = new System.Drawing.Point(604, 443);
            this.DeleteAnalogs.Name = "DeleteAnalogs";
            this.DeleteAnalogs.Size = new System.Drawing.Size(108, 23);
            this.DeleteAnalogs.TabIndex = 8;
            this.DeleteAnalogs.Text = "Удалить аналоги";
            this.DeleteAnalogs.UseVisualStyleBackColor = true;
            this.DeleteAnalogs.Click += new System.EventHandler(this.DeleteAnalogs_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(472, 443);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Пересчитать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ParserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 478);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.DeleteAnalogs);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.AddToReportButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.apartmentDataGridView);
            this.Name = "ParserForm";
            this.Text = "Таксатор";
            ((System.ComponentModel.ISupportInitialize)(this.apartmentDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView apartmentDataGridView;
        private System.Windows.Forms.Button AddToReportButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button DeleteAnalogs;
        private System.Windows.Forms.Button button3;
    }
}

