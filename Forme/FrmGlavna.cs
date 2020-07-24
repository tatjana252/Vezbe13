using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class FrmGlavna : Form
    {
        public FrmGlavna()
        {
            InitializeComponent();
        }

        public FrmGlavna(Korisnik k)
        {
            InitializeComponent();
            lblKorisnik.Text = $"Dobrodosli, {k.Ime} {k.Prezime}";
        }

        private void unosProizvodaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUnosProizvoda frmUnosProizvoda = new FrmUnosProizvoda();
            frmUnosProizvoda.ShowDialog();
        }

        private void pretragaProizvodaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPretragaProizvoda frmPretragaProizvoda = new FrmPretragaProizvoda();
            frmPretragaProizvoda.ShowDialog();
        }

        private void UnosRacunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUnosRacuna frmUnosRacuna = new FrmUnosRacuna();
            frmUnosRacuna.ShowDialog();
        }

        private void UnosDobavljanjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUnosDobavljanja unos = new FrmUnosDobavljanja();
            unos.ShowDialog();
        }
    }
}
