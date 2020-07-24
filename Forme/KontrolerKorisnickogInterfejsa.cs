using Domen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Forme
{
    internal class KontrolerKorisnickogInterfejsa
    {
        public KontrolerKorisnickogInterfejsa()
        {
        }

        internal void Pretraga(TextBox txtPretraga, DataGridView dgvProizvodi)
        {
            string criteria = txtPretraga.Text;
            Zahtev z = new Zahtev
            {
                Operacija = Operacija.PretraziProizvode,
                Objekat = criteria
            };
            Komunikacija.Instance.PosaljiZahtev(z);
            Odgovor o = Komunikacija.Instance.ProcitajOdgovor();
            dgvProizvodi.DataSource = (List<Proizvod>)o.Objekat;

        }

        public void SacuvajProizvod(TextBox txtId, TextBox txtNaziv, TextBox txtCena, ComboBox cmbProizvodjac)
        {
            try
            {
                if (Validacija(txtNaziv, txtCena, cmbProizvodjac))
                {
                    Proizvod proizvod = new Proizvod();
                    // proizvod.ID = Convert.ToInt32(txtId.Text);
                    //proizvod.ID = int.Parse(txtId.Text);
                    proizvod.Naziv = txtNaziv.Text;
                    proizvod.Cena = double.Parse(txtCena.Text, NumberStyles.AllowDecimalPoint);
                    proizvod.Proizvodjac = (Proizvodjac)cmbProizvodjac.SelectedItem;

                    Proizvod sacuvanProizvod = Kontroler.Kontroler.Instance.SacuvajProizvod(proizvod);
                    if (sacuvanProizvod != null)
                    {
                        MessageBox.Show($"Proizvod {sacuvanProizvod.Naziv} je uspesno sacuvan! ID: {sacuvanProizvod.ID}");
                        //txtId.Text = sacuvanProizvod.ID.ToString();
                        OcistiPolja(txtId, txtNaziv, txtCena, cmbProizvodjac);

                    }
                    else
                    {
                        MessageBox.Show("Proizvod nije uspesno sacuvan!");
                    }
                }
            }
            catch (FormatException)
            {
                //MessageBox.Show(fe.Message);
                MessageBox.Show("Pogresan unos!");
            }
        }

        private bool Validacija(TextBox txtNaziv, TextBox txtCena, ComboBox cmbProizvodjac)
        {
            bool pom = true;

            if (string.IsNullOrEmpty(txtNaziv.Text))
            {
                txtNaziv.BackColor = Color.LightCoral;
                pom = false;
            }
            else
            {
                txtNaziv.BackColor = Color.White;
            }

            if (string.IsNullOrEmpty(txtCena.Text))
            {
                txtCena.BackColor = Color.LightCoral;
                pom = false;
            }
            else
            {
                txtCena.BackColor = Color.White;
            }

            if (!double.TryParse(txtCena.Text, out double _))
            {
                txtCena.BackColor = Color.LightCoral;
                pom = false;
            }
            else
            {
                txtCena.BackColor = Color.White;
            }

            if (cmbProizvodjac.SelectedItem == null)
            {
                cmbProizvodjac.BackColor = Color.LightCoral;
                pom = false;
            }
            else
            {
                cmbProizvodjac.BackColor = Color.White;
            }

            return pom;

        }

        private void OcistiPolja(TextBox txtId, TextBox txtNaziv, TextBox txtCena, ComboBox cmbProizvodjac)
        {
            txtNaziv.Clear();
            txtCena.Text = String.Empty;
            txtId.Text = String.Empty;
            cmbProizvodjac.SelectedIndex = 0;
        }



    }
}