using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProje
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           FrmKategori ktgr = new FrmKategori();
           ktgr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmUrun urn = new FrmUrun();
            urn.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmIstatistik ıst = new FrmIstatistik();
            ıst.Show();
        }
    }
}
