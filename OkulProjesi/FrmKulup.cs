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
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-69LK30JQ\TEW_SQLEXPRESS;Initial Catalog=OkulVeriTabaani;Integrated Security=True");

        void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_KULUPLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void FrmKulup_Load_1(object sender, EventArgs e)
        {
            liste();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TBL_KULUPLER (KULUPAD) VALUES (@P1)", baglanti);
            komut.Parameters.AddWithValue("@P1", TxtKulupAD.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Listeye Eklendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKulupID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKulupAD.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("DELETE FROM TBL_KULUPLER WHERE KULUPID=@K1",baglanti);
            komutsil.Parameters.AddWithValue("@K1", TxtKulupID.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Silme Tamamlandı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("UPDATE TBL_KULUPLER SET KULUPAD=@G2 WHERE KULUPID=@G1", baglanti);
            komutguncelle.Parameters.AddWithValue("@G1", TxtKulupID.Text);
            komutguncelle.Parameters.AddWithValue("@G2", TxtKulupAD.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Güncelleme Tamamlandı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            FrmOgretmenDetay ogr = new FrmOgretmenDetay();
            ogr.Show();
            this.Hide();
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.Green;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.Transparent;
        }
    }
}
