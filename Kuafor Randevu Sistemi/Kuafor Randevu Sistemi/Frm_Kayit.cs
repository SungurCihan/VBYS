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
    public partial class Frm_Kayit : Form
    {
        public Frm_Kayit()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection = new NpgsqlConnection("server=localHost; port=5432; Database=kuafor_randevu_sistemi; user Id=postgres; password=NsC-282125");

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtisim.Text;
            string surname = txtsoyisim.Text;
            string email = txtemail.Text;
            string phoneNumber = txttelefon.Text;
            string password = txtsifre.Text;

            if(name != "" && surname != "" && email != "" && password != "" && phoneNumber != "")
            {
                connection.Open();

                NpgsqlCommand add = new NpgsqlCommand("insert into users (first_name, last_name, email, phone_number, password) values (@p1, @p2,@p3,@p4,@p5)", connection);

                add.Parameters.AddWithValue("@p1", name);
                add.Parameters.AddWithValue("@p2", surname);
                add.Parameters.AddWithValue("@p3", email);
                add.Parameters.AddWithValue("@p4", phoneNumber);
                add.Parameters.AddWithValue("@p5", password);

                add.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Kayıt oluşturuldu.");

                Frm_Giris frm = new Frm_Giris();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen bütün alanları doldurunz.");
            }
        }
    }
}
