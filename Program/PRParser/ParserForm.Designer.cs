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
            this.button1 = new System.Windows.Forms.Button();
            this.apartmentDataGridView = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.AddToReportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.apartmentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(892, 665);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Получить данные";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.apartmentDataGridView.Size = new System.Drawing.Size(1000, 647);
            this.apartmentDataGridView.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(730, 665);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Отобразить в браузере";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddToReportButton
            // 
            this.AddToReportButton.Location = new System.Drawing.Point(12, 665);
            this.AddToReportButton.Name = "AddToReportButton";
            this.AddToReportButton.Size = new System.Drawing.Size(127, 23);
            this.AddToReportButton.TabIndex = 3;
            this.AddToReportButton.Text = "Добавить в отчет";
            this.AddToReportButton.UseVisualStyleBackColor = true;
            // 
            // ParserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 700);
            this.Controls.Add(this.AddToReportButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.apartmentDataGridView);
            this.Controls.Add(this.button1);
            this.Name = "ParserForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.apartmentDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView apartmentDataGridView;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button AddToReportButton;
    }
}

