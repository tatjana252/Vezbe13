using Domen;
using Kontroler;
using Storage;
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
    public partial class FrmLogin : Form
    {

        public FrmLogin()
        {
            InitializeComponent();
        }


        private void btnPrijaviSe_Click(object sender, EventArgs e)
        {
            if (Komunikacija.Instance.PoveziSe())
            {
                string korIme = txtKorisnickoIme.Text;
                string pass = txtPassword.Text;
                Korisnik k = Komunikacija.Instance.Prijava(korIme, pass);
                if (k != null)
                {
                    MessageBox.Show($"Uspesno prijavljen {k.Ime}!");
                    Sesija.Instance.Korisnik = k;
                    FrmGlavna forma = new FrmGlavna();
                    forma.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Pogresno kor. ime ili pass!");
                }
            }
            else
            {
                MessageBox.Show("Nije moguce povezati se sa serverom!");
            }
        }

        private void txtKorisnickoIme_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //if (!Komunikacija.Instance.PoveziSe())
            //{
            //    btnPrijaviSe.Enabled = false;
            //}
        }
    }
}
