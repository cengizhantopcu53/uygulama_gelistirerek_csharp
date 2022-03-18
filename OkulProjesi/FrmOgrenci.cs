using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OkulProjesi
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-69LK30JQ\TEW_SQLEXPRESS;Initial Catalog=OkulVeriTabaani;Integrated Security=True");

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FrmOgretmenDetay ogr = new FrmOgretmenDetay();
            ogr.Show();
            this.Hide();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.Transparent;
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.Green;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TBL_KULUPLER",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbKulup.DisplayMember = "KULUPAD";
            CmbKulup.ValueMember = "KULUPID";
            CmbKulup.DataSource = dt;
            baglanti.Close();
        }

        string c = "";
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            ds.OgrenciEkle(TxtOgrenciAd.Text, TxtOgrenciSoyad.Text, byte.Parse(CmbKulup.SelectedValue.ToString()),c);   
            MessageBox.Show("Öğrenci Listeye Eklendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtOgrenciID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtOgrenciAd.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtOgrenciSoyad.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbKulup.Text= dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            if (dataGridView1.CurrentRow.Cells[3].Value.Equals("KIZ"))
            {
                RdKız.Checked=true;
            }
            else
            {
                RdKız.Checked = false;
            }
            if (dataGridView1.CurrentRow.Cells[3].Value.Equals("ERKEK"))
            {
                RdErkek.Checked = true;
            }
            else
            {
                RdErkek.Checked = false;
            }
        }

        private void CmbKulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TxtOgrenciID.Text = CmbKulup.SelectedValue.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(TxtOgrenciID.Text));
            MessageBox.Show("Öğrenci Silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(TxtOgrenciAd.Text, TxtOgrenciSoyad.Text, byte.Parse(CmbKulup.SelectedValue.ToString()), c, int.Parse(TxtOgrenciID.Text));
            MessageBox.Show("Öğrenci Bilgileri güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RdKız_CheckedChanged(object sender, EventArgs e)
        {
            if (RdKız.Checked == true)
            {
                c = "KIZ";
            }
        }

        private void RdErkek_CheckedChanged(object sender, EventArgs e)
        {
            if (RdErkek.Checked == true)
            {
                c = "ERKEK";
            }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciGetir(TxtAra.Text);
        }
    }
}
