namespace YakıtTakip
{
    partial class Raporlama
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
            this.caract = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.caracp = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 99);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(658, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // caract
            // 
            this.caract.FormattingEnabled = true;
            this.caract.Location = new System.Drawing.Point(144, 21);
            this.caract.Name = "caract";
            this.caract.Size = new System.Drawing.Size(130, 21);
            this.caract.TabIndex = 11;
            this.caract.SelectedIndexChanged += new System.EventHandler(this.caract_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Araç Plakası  :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Araç Türü  :";
            // 
            // caracp
            // 
            this.caracp.FormattingEnabled = true;
            this.caracp.Location = new System.Drawing.Point(144, 47);
            this.caracp.Name = "caracp";
            this.caracp.Size = new System.Drawing.Size(130, 21);
            this.caracp.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(300, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 61);
            this.button1.TabIndex = 13;
            this.button1.Text = "Göster";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Raporlama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 537);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.caracp);
            this.Controls.Add(this.caract);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Raporlama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Raporlama";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox caract;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox caracp;
        private System.Windows.Forms.Button button1;
    }
}