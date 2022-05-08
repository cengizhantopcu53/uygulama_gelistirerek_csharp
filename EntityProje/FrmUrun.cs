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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBL_URUN
                                        select new
                                        {
                                            x.URUNID,
                                            x.URUNAD,
                                            x.MARKA,
                                            x.STOK,
                                            x.TBL_KATEGORI.AD,
                                            x.FİYAT,
                                            x.DURUM,
                                        }).ToList();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TBL_URUN t = new TBL_URUN();
            t.URUNAD = TxtUrunAD.Text;
            t.MARKA = TxtMarka.Text;
            t.STOK = short.Parse(TxtStok.Text);
            t.FİYAT = decimal.Parse(TxtFiyat.Text);
            t.DURUM = true;
            t.KATEGORI = int.Parse(CmbKategori.SelectedValue.ToString());
            db.TBL_URUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Sisteme Kaydedildi");
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtID.Text);
            var urun = db.TBL_URUN.Find(x);
            db.TBL_URUN.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtID.Text);
            var urun = db.TBL_URUN.Find(x);
            urun.URUNAD = TxtUrunAD.Text;
            urun.MARKA = TxtMarka.Text;
            urun.STOK = short.Parse(TxtStok.Text);
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi");
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.TBL_KATEGORI
                               select new
                               {
                                   x.ID,
                                   x.AD
                               }
                             ).ToList();
            CmbKategori.ValueMember = "ID";
            CmbKategori.DisplayMember = "AD";
            CmbKategori.DataSource = kategoriler;
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {

        }
    }
}
