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

namespace sinema_otomasyon
{
    public partial class Form3 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;
        
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            // Film Ekleme İşlemi
            SqlConnection baglan = new SqlConnection("server=DESKTOP-EOMOPV6\\SQLEXPRESS; Initial Catalog=sinema_otomasyon;Integrated Security=SSPI");
            baglan.Open();
            SqlCommand cmd = new SqlCommand("insert into filmler(film_adi,film_turu,film_yonetmen,film_oyuncu,film_imdb)values" +"(@film_adi,@film_turu,@film_yonetmen,@film_oyuncu,@film_imdb)", baglan);
            cmd.Parameters.AddWithValue("@film_adi", textBox1.Text);
            cmd.Parameters.AddWithValue("@film_turu", comboBox1.Text);
            cmd.Parameters.AddWithValue("@film_yonetmen", textBox3.Text);
            cmd.Parameters.AddWithValue("@film_oyuncu", textBox4.Text);
            cmd.Parameters.AddWithValue("@film_imdb", textBox5.Text);
            cmd.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Başarıyla Eklendi", "Bilgi");
           

        }

        

        private void Form3_Load(object sender, EventArgs e)
        {
            // Kategori Listeleme
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["tur_adi"]);
            }
            con.Close();

        }
        /* Data Grid View kontrolü
        void MusteriGetir()
        {
            // 
            con = new SqlConnection("server=DESKTOP-EOMOPV6\\SQLEXPRESS;Initial Catalog=sinema_otomasyon;Integrated Security=SSPI");
            con.Open();
            da = new SqlDataAdapter("Select *From filmler", con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            con.Close();
        }
        */
        
        // datagridview güncelleme butonu yazdık ama buton yokkkk
        private void button2_Click(object sender, EventArgs e)
        {
            da.Update(ds, "filmler");
        }
    }
}
