using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domen;

namespace Forme
{
    public partial class FrmUnosDobavljanjaDialog : Form
    {
        public FrmUnosDobavljanjaDialog()
        {
            InitializeComponent();
            cmbDobavljac.DataSource = Kontroler.Kontroler.Instance.VratiSveDobavljace();
            cmbProizvod.DataSource = Kontroler.Kontroler.Instance.VratiSveProizvode();
                 
        }

        public Dobavljanje Dobavljanje { get; set; }

        private void Button1_Click(object sender, EventArgs e)
        {
            Dobavljanje dobavljanje = new Dobavljanje {
                Dobavljac = (Dobavljac) cmbDobavljac.SelectedItem,
                Proizvod = (Proizvod) cmbProizvod.SelectedItem,
                Datum = DateTime.ParseExact(txtDatum.Text, "dd.MM.yyyy.", null),
                Opis = txtOpis.Text
            };
            Dobavljanje = dobavljanje;
            Close();
        }
    }
}
