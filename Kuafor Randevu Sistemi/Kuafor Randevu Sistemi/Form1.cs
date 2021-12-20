using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuafor_Randevu_Sistemi
{
    public partial class Frm_Giris : Form
    {
        public Frm_Giris()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection = new NpgsqlConnection("server=localHost; port=5432; Database=kuafor_randevu_sistemi; user Id=postgres; password=NsC-282125");


        Frm_Kayit frm = new Frm_Kayit();
        private void btnkayit_Click(object sender, EventArgs e)
        {
            frm.Show();
            this.Hide();
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            string email = txtmail.Text;
            string passsword = txtsifre.Text;

            try
            {
                connection.Open();
                NpgsqlCommand giris = new NpgsqlCommand("select * from users where email=@p1 and password=@p2", connection);
                giris.Parameters.AddWithValue("@p1", email);
                giris.Parameters.AddWithValue("@p2", passsword);
                NpgsqlDataReader kontrol = giris.ExecuteReader();
                if (kontrol.Read())
                {
                    Frm_Anasayfa yonlendir = new Frm_Anasayfa();
                    yonlendir.userId = int.Parse(kontrol["id"].ToString());
                    yonlendir.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtmail.Clear();
                    txtsifre.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluştu,lütfen kullanıcı adı ve şifrenizi kontrol ediniz.\nHata Kodu:\n" + ex, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }
    }
}
