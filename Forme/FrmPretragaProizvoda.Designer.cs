namespace Forme
{
    partial class FrmPretragaProizvoda
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrikaziProizvod = new System.Windows.Forms.Button();
            this.btnPretraga = new System.Windows.Forms.Button();
            this.dgvProizvodi = new System.Windows.Forms.DataGridView();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProizvodi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrikaziProizvod);
            this.panel1.Controls.Add(this.btnPretraga);
            this.panel1.Controls.Add(this.dgvProizvodi);
            this.panel1.Controls.Add(this.txtPretraga);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 277);
            this.panel1.TabIndex = 0;
            // 
            // btnPrikaziProizvod
            // 
            this.btnPrikaziProizvod.Location = new System.Drawing.Point(313, 14);
            this.btnPrikaziProizvod.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrikaziProizvod.Name = "btnPrikaziProizvod";
            this.btnPrikaziProizvod.Size = new System.Drawing.Size(113, 16);
            this.btnPrikaziProizvod.TabIndex = 4;
            this.btnPrikaziProizvod.Text = "Prikazi detalje";
            this.btnPrikaziProizvod.UseVisualStyleBackColor = true;
            this.btnPrikaziProizvod.Click += new System.EventHandler(this.btnPrikaziProizvod_Click);
            // 
            // btnPretraga
            // 
            this.btnPretraga.Location = new System.Drawing.Point(201, 14);
            this.btnPretraga.Margin = new System.Windows.Forms.Padding(2);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(72, 16);
            this.btnPretraga.TabIndex = 3;
            this.btnPretraga.Text = "Pretrazi";
            this.btnPretraga.UseVisualStyleBackColor = true;
            this.btnPretraga.Click += new System.EventHandler(this.btnPretraga_Click);
            // 
            // dgvProizvodi
            // 
            this.dgvProizvodi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProizvodi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProizvodi.Location = new System.Drawing.Point(12, 44);
            this.dgvProizvodi.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProizvodi.Name = "dgvProizvodi";
            this.dgvProizvodi.RowTemplate.Height = 28;
            this.dgvProizvodi.Size = new System.Drawing.Size(493, 222);
            this.dgvProizvodi.TabIndex = 2;
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(71, 12);
            this.txtPretraga.Margin = new System.Windows.Forms.Padding(2);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(117, 20);
            this.txtPretraga.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pretraga:";
            // 
            // FrmPretragaProizvoda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmPretragaProizvoda";
            this.Text = "FrmPretragaProizvoda";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProizvodi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvProizvodi;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrikaziProizvod;
        private System.Windows.Forms.Button btnPretraga;
    }
}