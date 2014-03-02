namespace PRUI.Forms
{
    partial class ApartmentSelectForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ApartmentSelectButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(554, 353);
            this.dataGridView1.TabIndex = 0;
            // 
            // ApartmentSelectButton
            // 
            this.ApartmentSelectButton.Location = new System.Drawing.Point(12, 377);
            this.ApartmentSelectButton.Name = "ApartmentSelectButton";
            this.ApartmentSelectButton.Size = new System.Drawing.Size(75, 23);
            this.ApartmentSelectButton.TabIndex = 1;
            this.ApartmentSelectButton.Text = "Выбрать";
            this.ApartmentSelectButton.UseVisualStyleBackColor = true;
            this.ApartmentSelectButton.Click += new System.EventHandler(this.ApartmentSelectButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(491, 377);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Закрыть";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ApartmentSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 412);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ApartmentSelectButton);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApartmentSelectForm";
            this.ShowIcon = false;
            this.Text = "Выбор объекта";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ApartmentSelectButton;
        private System.Windows.Forms.Button button2;
    }
}