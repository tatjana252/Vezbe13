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
    public partial class FrmUnosDobavljanja : Form
    {
        private BindingList<Dobavljanje> listaDobavljanja = new BindingList<Dobavljanje>();
        public FrmUnosDobavljanja()
        {
            InitializeComponent();
            dgvDobavljanja.DataSource = listaDobavljanja;
            SrediFormu();
        }

        private void SrediFormu()
        {
            dgvDobavljanja.Columns["Dobavljac"].Visible = false;
            DataGridViewComboBoxColumn colDobavljac = new DataGridViewComboBoxColumn();
            colDobavljac.DataPropertyName = "Dobavljac";
            colDobavljac.DataSource = Kontroler.Kontroler.Instance.VratiSveDobavljace();
            colDobavljac.DisplayMember = "Naziv";
            colDobavljac.ValueMember = "Self";
            colDobavljac.HeaderText = "Izaberi dobavljaca";
            dgvDobavljanja.Columns.Add(colDobavljac);

            dgvDobavljanja.Columns["Proizvod"].Visible = false;
            DataGridViewComboBoxColumn colProizvod = new DataGridViewComboBoxColumn();
            colProizvod.DataPropertyName = "Proizvod";
            colProizvod.DataSource = Kontroler.Kontroler.Instance.VratiSveProizvode();
            colProizvod.DisplayMember = "Naziv";
            colProizvod.ValueMember = "Self";
            colProizvod.HeaderText = "Izaberi proizvod";
            dgvDobavljanja.Columns.Add(colProizvod);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            listaDobavljanja.Add(new Dobavljanje());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(dgvDobavljanja.SelectedRows.Count > 0)
            {
                Dobavljanje dobavljanjeZaBrisanje = (Dobavljanje)dgvDobavljanja.SelectedRows[0].DataBoundItem;
                listaDobavljanja.Remove(dobavljanjeZaBrisanje);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            bool rez = Kontroler.Kontroler.Instance.SacuvajSvaDobavljanja(listaDobavljanja);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            FrmUnosDobavljanjaDialog dialog = new FrmUnosDobavljanjaDialog();
            dialog.ShowDialog();
            if(dialog.Dobavljanje != null)
            {
                listaDobavljanja.Add(dialog.Dobavljanje);
            }
        }
    }
}
