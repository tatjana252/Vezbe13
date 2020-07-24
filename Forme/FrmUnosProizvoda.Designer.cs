namespace Forme
{
    partial class FrmUnosProizvoda
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.cmbProizvodjac = new System.Windows.Forms.ComboBox();
            this.txtCena = new System.Windows.Forms.TextBox();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSacuvaj);
            this.panel1.Controls.Add(this.cmbProizvodjac);
            this.panel1.Controls.Add(this.txtCena);
            this.panel1.Controls.Add(this.txtNaziv);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 293);
            this.panel1.TabIndex = 1;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(140, 240);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(157, 31);
            this.btnSacuvaj.TabIndex = 8;
            this.btnSacuvaj.Text = "Sacuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // cmbProizvodjac
            // 
            this.cmbProizvodjac.FormattingEnabled = true;
            this.cmbProizvodjac.Location = new System.Drawing.Point(118, 187);
            this.cmbProizvodjac.Name = "cmbProizvodjac";
            this.cmbProizvodjac.Size = new System.Drawing.Size(200, 28);
            this.cmbProizvodjac.TabIndex = 7;
            // 
            // txtCena
            // 
            this.txtCena.Location = new System.Drawing.Point(119, 134);
            this.txtCena.Name = "txtCena";
            this.txtCena.Size = new System.Drawing.Size(200, 26);
            this.txtCena.TabIndex = 6;
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(119, 84);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(200, 26);
            this.txtNaziv.TabIndex = 5;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(119, 37);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(200, 26);
            this.txtId.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Proizvodjac:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = " Cena:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = " Naziv:";
            // 
            // FrmUnosProizvoda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 327);
            this.Controls.Add(this.panel1);
            this.Name = "FrmUnosProizvoda";
            this.Text = "FrmUnosProizvoda";
            this.Load += new System.EventHandler(this.FrmUnosProizvoda_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.ComboBox cmbProizvodjac;
        private System.Windows.Forms.TextBox txtCena;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}