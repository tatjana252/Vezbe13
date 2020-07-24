using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class FrmUnosProizvoda : Form
    {

        private KontrolerKorisnickogInterfejsa kki = new KontrolerKorisnickogInterfejsa();
        public FrmUnosProizvoda()
        {
            InitializeComponent();
            cmbProizvodjac.DataSource = Kontroler.Kontroler.Instance.VratiSveProizvodjace();
        }

        public FrmUnosProizvoda(Proizvod odabraniProizvod)
        {
            InitializeComponent();
            cmbProizvodjac.DataSource = Kontroler.Kontroler.Instance.VratiSveProizvodjace();
            prikaziProizvod(odabraniProizvod);
        }

        private void prikaziProizvod(Proizvod odabraniProizvod)
        {
            txtId.Text = odabraniProizvod.ID.ToString();
            txtNaziv.Text = odabraniProizvod.Naziv;
            txtCena.Text = odabraniProizvod.Cena.ToString();
            cmbProizvodjac.SelectedItem = odabraniProizvod.Proizvodjac;
            btnSacuvaj.Visible = false;
        }

        private void FrmUnosProizvoda_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    cmbProizvodjac.DataSource = Kontroler.Kontroler.Instance.VratiSveProizvodjace();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            kki.SacuvajProizvod(txtId, txtNaziv, txtCena, cmbProizvodjac);

        }

       
    }
}
