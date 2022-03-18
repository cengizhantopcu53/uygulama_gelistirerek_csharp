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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.TBL_KATEGORI.Count().ToString();
            label3.Text = db.TBL_URUN.Count().ToString();
            label5.Text = db.TBL_MUSTERI.Count(x => x.DURUM == true).ToString();
            label7.Text = db.TBL_MUSTERI.Count(x => x.DURUM == false).ToString();
            label11.Text = db.TBL_URUN.Sum(y => y.STOK).ToString();
            label19.Text = db.TBL_SATIS.Sum(z => z.FİYAT).ToString() + " TL";
            label13.Text = (from x in db.TBL_URUN orderby x.FİYAT descending select x.URUNAD).FirstOrDefault();
            label15.Text = (from x in db.TBL_URUN orderby x.FİYAT ascending select x.URUNAD).FirstOrDefault();
            label9.Text = db.TBL_URUN.Count(x => x.KATEGORI == 1).ToString();
            label23.Text= db.TBL_URUN.Count(x => x.URUNAD == "BUZDOLABI").ToString();
            label17.Text = (from x in db.TBL_MUSTERI select x.SEHIR).Distinct().Count().ToString();
            label21.Text = db.MARKAGETIR().FirstOrDefault();
        }
    }
}
