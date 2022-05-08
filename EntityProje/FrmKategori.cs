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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void BtnListele_Click(object sender, EventArgs e)
        {
            var kategoriler = db.TBL_KATEGORI.ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TBL_KATEGORI t = new TBL_KATEGORI();
            t.AD = TxtAD.Text;
            db.TBL_KATEGORI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kayıt Eklendi");
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtID.Text);
            var ktgr = db.TBL_KATEGORI.Find(x);
            db.TBL_KATEGORI.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Kayıt Silindi");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtID.Text);
            var ktgr = db.TBL_KATEGORI.Find(x);
            ktgr.AD = TxtAD.Text;
            db.SaveChanges();
            MessageBox.Show("Kayıt Güncellendi");
        }
    }
}
