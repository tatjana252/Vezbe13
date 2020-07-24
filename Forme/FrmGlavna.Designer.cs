namespace Forme
{
    partial class FrmGlavna
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.proizvodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unosProizvodaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaProizvodaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.racunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unosRacunaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblKorisnik = new System.Windows.Forms.Label();
            this.dobavljacToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unosDobavljanjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proizvodToolStripMenuItem,
            this.racunToolStripMenuItem,
            this.dobavljacToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(533, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // proizvodToolStripMenuItem
            // 
            this.proizvodToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unosProizvodaToolStripMenuItem,
            this.pretragaProizvodaToolStripMenuItem});
            this.proizvodToolStripMenuItem.Name = "proizvodToolStripMenuItem";
            this.proizvodToolStripMenuItem.Size = new System.Drawing.Size(65, 22);
            this.proizvodToolStripMenuItem.Text = "Proizvod";
            // 
            // unosProizvodaToolStripMenuItem
            // 
            this.unosProizvodaToolStripMenuItem.Name = "unosProizvodaToolStripMenuItem";
            this.unosProizvodaToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.unosProizvodaToolStripMenuItem.Text = "Unos proizvoda";
            this.unosProizvodaToolStripMenuItem.Click += new System.EventHandler(this.unosProizvodaToolStripMenuItem_Click);
            // 
            // pretragaProizvodaToolStripMenuItem
            // 
            this.pretragaProizvodaToolStripMenuItem.Name = "pretragaProizvodaToolStripMenuItem";
            this.pretragaProizvodaToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.pretragaProizvodaToolStripMenuItem.Text = "Pretraga proizvoda";
            this.pretragaProizvodaToolStripMenuItem.Click += new System.EventHandler(this.pretragaProizvodaToolStripMenuItem_Click);
            // 
            // racunToolStripMenuItem
            // 
            this.racunToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unosRacunaToolStripMenuItem});
            this.racunToolStripMenuItem.Name = "racunToolStripMenuItem";
            this.racunToolStripMenuItem.Size = new System.Drawing.Size(52, 22);
            this.racunToolStripMenuItem.Text = "Racun";
            // 
            // unosRacunaToolStripMenuItem
            // 
            this.unosRacunaToolStripMenuItem.Name = "unosRacunaToolStripMenuItem";
            this.unosRacunaToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.unosRacunaToolStripMenuItem.Text = "Unos racuna";
            this.unosRacunaToolStripMenuItem.Click += new System.EventHandler(this.UnosRacunaToolStripMenuItem_Click);
            // 
            // lblKorisnik
            // 
            this.lblKorisnik.AutoSize = true;
            this.lblKorisnik.Location = new System.Drawing.Point(455, 258);
            this.lblKorisnik.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKorisnik.Name = "lblKorisnik";
            this.lblKorisnik.Size = new System.Drawing.Size(35, 13);
            this.lblKorisnik.TabIndex = 1;
            this.lblKorisnik.Text = "label1";
            // 
            // dobavljacToolStripMenuItem
            // 
            this.dobavljacToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unosDobavljanjaToolStripMenuItem});
            this.dobavljacToolStripMenuItem.Name = "dobavljacToolStripMenuItem";
            this.dobavljacToolStripMenuItem.Size = new System.Drawing.Size(71, 22);
            this.dobavljacToolStripMenuItem.Text = "Dobavljac";
            // 
            // unosDobavljanjaToolStripMenuItem
            // 
            this.unosDobavljanjaToolStripMenuItem.Name = "unosDobavljanjaToolStripMenuItem";
            this.unosDobavljanjaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.unosDobavljanjaToolStripMenuItem.Text = "Unos dobavljanja";
            this.unosDobavljanjaToolStripMenuItem.Click += new System.EventHandler(this.UnosDobavljanjaToolStripMenuItem_Click);
            // 
            // FrmGlavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.lblKorisnik);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmGlavna";
            this.Text = "GlavnaForma";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem proizvodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unosProizvodaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaProizvodaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem racunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unosRacunaToolStripMenuItem;
        private System.Windows.Forms.Label lblKorisnik;
        private System.Windows.Forms.ToolStripMenuItem dobavljacToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unosDobavljanjaToolStripMenuItem;
    }
}