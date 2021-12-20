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
    public partial class Frm_Guncelle : Form
    {
        public Frm_Guncelle()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection = new NpgsqlConnection("server=localHost; port=5432; Database=kuafor_randevu_sistemi; user Id=postgres; password=NsC-282125");

        public int customerId;

        private void Frm_Guncelle_Load(object sender, EventArgs e)
        {
            _getAppointments();
            _getInfos();
        }

        void _getAppointments()
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from appointments where customer_id=" + customerId, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbrandevular.ValueMember = "id";
            cmbrandevular.DisplayMember = "id";
            cmbrandevular.DataSource = dt;
        }

        void _getInfos()
        {
            int appointmentId = int.Parse(cmbrandevular.SelectedValue.ToString());

            connection.Open();

            NpgsqlCommand komut = new NpgsqlCommand("select * from appointments_details where id=@p1", connection);
            komut.Parameters.AddWithValue("@p1", appointmentId);
            NpgsqlDataReader getDetails = komut.ExecuteReader();

            if (getDetails.Read())
            {
                txtkuafor.Text = getDetails["saloon_name"].ToString();
                txtpersonel.Text = getDetails["first_name"].ToString() + " " + getDetails["last_name"].ToString();
                txtservis.Text = getDetails["service_name"].ToString();
                txtbaslangic.Text = getDetails["start_hour"].ToString();
                txtbitis.Text = getDetails["end_hour"].ToString();
                dateupdate.Value = DateTime.Parse(getDetails["appointment_date"].ToString());
            }

            connection.Close();
        }

        void _update()
        {
            connection.Open();

            NpgsqlCommand komut = new NpgsqlCommand("update appointments set appointment_date=@p1, start_hour=@p2, end_hour=@p3 where id=@p4", connection);
            komut.Parameters.AddWithValue("@p1", DateTime.Parse(dateupdate.Value.ToString()));
            komut.Parameters.AddWithValue("@p2", double.Parse(txtbaslangic.Text));
            komut.Parameters.AddWithValue("@p3", double.Parse(txtbitis.Text));
            komut.Parameters.AddWithValue("@p4", int.Parse(cmbrandevular.SelectedValue.ToString()));
            komut.ExecuteNonQuery();
            MessageBox.Show("Randevu baraşrıyla güncellendi.", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            connection.Close();
        }

        void _delete()
        {
            connection.Open();

            NpgsqlCommand komut = new NpgsqlCommand("delete from appointments where id=@p1", connection);
            komut.Parameters.AddWithValue("@p1", int.Parse(cmbrandevular.SelectedValue.ToString()));
            komut.ExecuteNonQuery();

            MessageBox.Show("Randevu baraşrıyla silindi.", "Silme", MessageBoxButtons.OK, MessageBoxIcon.Error);

            connection.Close();
        }

        private void cmbrandevular_SelectedIndexChanged(object sender, EventArgs e)
        {
            _getInfos();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            _update();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            _delete();

            txtbaslangic.Text = "";
            txtbitis.Text = "";
            txtkuafor.Text = "";
            txtpersonel.Text = "";
            txtservis.Text = "";
        }
    }
}
