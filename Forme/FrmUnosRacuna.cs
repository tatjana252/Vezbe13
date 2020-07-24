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
    public partial class FrmUnosRacuna : Form
    {
        private BindingList<StavkaRacuna> stavkeBinding = new BindingList<StavkaRacuna>();

        public FrmUnosRacuna()
        {
            InitializeComponent();
            SrediFormu();
        }

        private void SrediFormu()
        {
            if(Sesija.Instance.Korisnik != null) {
                lblImePrezime.Text = $"{Sesija.Instance.Korisnik.Ime} {Sesija.Instance.Korisnik.Prezime}";
                cmbProizvod.DataSource = Kontroler.Kontroler.Instance.VratiSveProizvode();
                cmbProizvod.DisplayMember = "Naziv";
                dgvStavke.DataSource = stavkeBinding;
            }
            else
            {
                MessageBox.Show("Niste prijavljeni!");
            }
        }

        private void BtnDodaj_Click(object sender, EventArgs e)
        {
            StavkaRacuna stavka = VratiStavkuRacuna();
            if(stavka != null)
            {
                StavkaRacuna stavkaIzListe = stavkeBinding.SingleOrDefault(s => s.Proizvod == stavka.Proizvod);
                if(stavkaIzListe != null)
                {
                    stavkaIzListe.Kolicina += stavka.Kolicina;
                    stavkaIzListe.UkupanIznos = stavkaIzListe.Kolicina* stavkaIzListe.Proizvod.Cena;
                    dgvStavke.Refresh();
                }
                else
                {
                    stavka.RBr = stavkeBinding.Count + 1;
                    stavkeBinding.Add(stavka);
                }
            }
        }

        private StavkaRacuna VratiStavkuRacuna()
        {
            bool validacija = true;
            StavkaRacuna stavka = new StavkaRacuna();
            if(!int.TryParse(txtKolicina.Text, out int rez) || rez < 0)
            {
                MessageBox.Show("Niste uneli kolicinu dobro!");
                validacija = false;
            }
            else
            {
                stavka.Kolicina = rez;
            }
            if(cmbProizvod.SelectedItem is Proizvod p)
            {
                stavka.Proizvod = p;
                stavka.UkupanIznos = stavka.Kolicina + stavka.Proizvod.Cena;
            }
            else
            {
                validacija = false;
            }
            if (validacija)
            {
                return stavka;
            }
            else
            {
                return null;
            }
        }

        private void CmbProizvod_SelectedIndexChanged(object sender, EventArgs e)
        {
            PostaviUkupnuCenu();
        }

        private void TxtKolicina_TextChanged(object sender, EventArgs e)
        {
            PostaviUkupnuCenu();
        }

        private void PostaviUkupnuCenu()
        {
            if (cmbProizvod.SelectedItem != null)
            {
                double cena = ((Proizvod)cmbProizvod.SelectedItem).Cena;
                txtCena.Text = ((Proizvod)cmbProizvod.SelectedItem).Cena.ToString();
                if (int.TryParse(txtKolicina.Text, out int kolicina))
                {
                    txtUkupnaCena.Text = (kolicina * cena).ToString();
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(dgvStavke.SelectedRows.Count > 0)
            {
                stavkeBinding.Remove((StavkaRacuna)dgvStavke.SelectedRows[0].DataBoundItem);
                var broj = 1;
                stavkeBinding.ToList().ForEach(st => st.RBr = broj++);
            }
        }

        private void BtnSacuvaj_Click(object sender, EventArgs e)
        {
            Racun racun = new Racun();
            if (!DateTime.TryParseExact(txtDatum.Text, "dd.MM.yyyy.", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
            {
                MessageBox.Show("Niste uneli dobro datum!");
                return;
            }
            racun.Datum = dateTime;
            racun.Korisnik = Sesija.Instance.Korisnik;
            racun.StavkeRacuna = stavkeBinding.ToList();

            bool uspesno = Kontroler.Kontroler.Instance.SacuvajRacun(racun);
            if (uspesno)
            {
                MessageBox.Show("Racun je sacuvan!");
            }
            else
            {
                MessageBox.Show("Racun nije sacuvan!");
            }
        }

    }
}
