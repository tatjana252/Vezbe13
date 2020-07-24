using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {
        private Server s;
        private Thread nit;
        public FrmServer()
        {
            InitializeComponent();
            btnPokreni.Enabled = true;
            btnZaustavi.Enabled = false;
        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            s = new Server();
            s.PrijavljenNov += S_PrijavljenNov;
            if (s.PokreniServer())
            {
                nit = new Thread(s.Osluskuj);
                nit.IsBackground = true;
                nit.Start();
                MessageBox.Show("Server je pokrenut!");
                btnPokreni.Enabled = false;
                btnZaustavi.Enabled = true;
            }
            else
            {
                MessageBox.Show("Server nije pokrenut!");
            }
        }

        private void S_PrijavljenNov()
        {
            this.Invoke(new Action(() =>
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = s.Klijenti;
            }));

        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            nit.Interrupt();
        }
    }
}
