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
    public partial class FrmPretragaProizvoda : Form
    {
        KontrolerKorisnickogInterfejsa kontroler = new KontrolerKorisnickogInterfejsa();
        public FrmPretragaProizvoda()
        {
            InitializeComponent();
            SrediFormu();
        }

        private void SrediFormu()
        {
            try
            {
                dgvProizvodi.DataSource = Komunikacija.Instance.VratiSveProizvode();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnPrikaziProizvod_Click(object sender, EventArgs e)
        {
            Proizvod odabraniProizvod = (Proizvod)dgvProizvodi.SelectedRows[0].DataBoundItem;
            FrmUnosProizvoda frmUnosProizvoda = new FrmUnosProizvoda(odabraniProizvod);
            frmUnosProizvoda.ShowDialog();
        }

        private void btnPretraga_Click(object sender, EventArgs e)
        {
            try
            {
                kontroler.Pretraga(txtPretraga, dgvProizvodi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
