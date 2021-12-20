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
    public partial class Frm_Anasayfa : Form
    {
        public Frm_Anasayfa()
        {
            InitializeComponent();

        }

        NpgsqlConnection connection = new NpgsqlConnection("server=localHost; port=5432; Database=kuafor_randevu_sistemi; user Id=postgres; password=NsC-282125");


        public int userId;
        List<string> serviceIds = new List<string>();
        List<string> employeeIds = new List<string>();

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Frm_Anasayfa_Load(object sender, EventArgs e)
        {
            GetSaloons();
            _getCustomerOfMonth();
            _getEmployeeOfMonth();
            _getSaloonOfMonth();
            _getCurrentbalance();
        }

        private void cmbkuafor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbservis.Items.Clear();
            cmbpersonel.Items.Clear();
            serviceIds.Clear();
            employeeIds.Clear();
            GetServices();
            GetEmployees();
            _mostPreferredService();
        }

        void GetSaloons()
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from saloons", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbkuafor.ValueMember = "id";
            cmbkuafor.DisplayMember = "saloon_name";
            cmbkuafor.DataSource = dt;
        }

        void GetServices()
        {

            connection.Open();
            NpgsqlCommand da = new NpgsqlCommand("select * from services where saloon_id=@p1", connection);
            da.Parameters.AddWithValue("@p1", int.Parse(cmbkuafor.SelectedValue.ToString()));
            NpgsqlDataReader getServices = da.ExecuteReader();

            while (getServices.Read())
            {

                cmbservis.Items.Add(getServices["service_name"].ToString());
                serviceIds.Add(getServices["id"].ToString());
            }

            connection.Close();
        }

        void GetEmployees()
        {
            string saloon_id = cmbkuafor.SelectedValue.ToString();

            connection.Open();
            NpgsqlCommand da = new NpgsqlCommand("select * from employee_details where saloon_id=@p1", connection);
            da.Parameters.AddWithValue("@p1", int.Parse(saloon_id));
            NpgsqlDataReader getEmployees = da.ExecuteReader();

            while (getEmployees.Read())
            {
                cmbpersonel.Items.Add(getEmployees["first_name"].ToString() + getEmployees["last_name"].ToString());
                employeeIds.Add(getEmployees["id"].ToString());
            }

            connection.Close();
        }

        void _getCustomerOfMonth()
        {
            connection.Open();
            NpgsqlCommand komut = new NpgsqlCommand("select customerofmonth()", connection);
            NpgsqlDataReader read = komut.ExecuteReader();

            if (read.Read())
            {
                txtayinmusteri.Text = read["customerofmonth"].ToString();
            }

            connection.Close();

        }

        void _getEmployeeOfMonth()
        {
            connection.Open();
            NpgsqlCommand komut = new NpgsqlCommand("select employeeofmonth()", connection);
            NpgsqlDataReader read = komut.ExecuteReader();

            if (read.Read())
            {
                txtayincalisan.Text = read["employeeofmonth"].ToString();
            }

            connection.Close();

        }

        void _getSaloonOfMonth()
        {
            connection.Open();
            NpgsqlCommand komut = new NpgsqlCommand("select saloonofmonth()", connection);
            NpgsqlDataReader read = komut.ExecuteReader();

            if (read.Read())
            {
                txtayinkuafor.Text = read["saloonofmonth"].ToString();
            }

            connection.Close();

        }

        void _getCurrentbalance()
        {
            int customerId;

            connection.Open();
            NpgsqlCommand komut = new NpgsqlCommand("select customers.id from customers inner join users on customers.user_id=users.id where user_id=@p1", connection);
            komut.Parameters.AddWithValue("@p1",  userId);
            NpgsqlDataReader reader = komut.ExecuteReader();

            if (reader.Read())
            {
                customerId = int.Parse(reader["id"].ToString());
            }
            else
            {
                customerId = 1;
            }

            connection.Close();

            connection.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("select customer_balance from customers where id=@p1", connection);
            komut2.Parameters.AddWithValue("@p1", customerId);
            NpgsqlDataReader reader2 = komut2.ExecuteReader();

            if (reader2.Read())
            {
                txtbakiye.Text = reader2["customer_balance"].ToString();
            }

            connection.Close();
        }

        void _mostPreferredService()
        {
            int saloonId = int.Parse(cmbkuafor.SelectedValue.ToString());

            connection.Open();
            NpgsqlCommand komut = new NpgsqlCommand("select mostpreferred(@p1)", connection);
            komut.Parameters.AddWithValue("@p1", saloonId);
            NpgsqlDataReader reader = komut.ExecuteReader();

            if (reader.Read())
            {
                txtsencokservis.Text = reader["mostpreferred"].ToString();
            }

            connection.Close();

        }

        private void cmbfiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbpersonel.Items.Clear();
            cmbpersonel.Text = "";

            string saloon_id = cmbkuafor.SelectedValue.ToString();
            int seciliIndex = int.Parse(cmbfiltre.SelectedIndex.ToString());
            string sorgu = (seciliIndex + 1).ToString();


            if (seciliIndex == 4)
            {
                connection.Open();

                NpgsqlCommand da = new NpgsqlCommand("select * from employee_details where saloon_id=@p1 and rating <=@p2 and rating>=@p3", connection);
                da.Parameters.AddWithValue("@p1", int.Parse(saloon_id));
                da.Parameters.AddWithValue("@p2", double.Parse(sorgu));
                da.Parameters.AddWithValue("@p3", int.Parse(cmbfiltre.SelectedIndex.ToString()));
                NpgsqlDataReader get = da.ExecuteReader();

                while (get.Read())
                {
                    cmbpersonel.Items.Add(get["first_name"].ToString() + get["last_name"].ToString());
                }
                connection.Close();
            }
            else if (seciliIndex == 5)
            {
                GetEmployees();
            }
            else
            {
                connection.Open();
                NpgsqlCommand da = new NpgsqlCommand("select * from employee_details where saloon_id=@p1 and rating <@p2 and rating>=@p3", connection);
                da.Parameters.AddWithValue("@p1", int.Parse(saloon_id));
                da.Parameters.AddWithValue("@p2", double.Parse(sorgu));
                da.Parameters.AddWithValue("@p3", int.Parse(cmbfiltre.SelectedIndex.ToString()));
                NpgsqlDataReader get = da.ExecuteReader();

                while (get.Read())
                {
                    cmbpersonel.Items.Add(get["first_name"].ToString() + get["last_name"].ToString());
                }
                connection.Close();
            }

            

        }

        private void btnrandevual_Click(object sender, EventArgs e)
        {
            int saloonId = int.Parse(cmbkuafor.SelectedValue.ToString());
            int employeeId = int.Parse(employeeIds[cmbpersonel.SelectedIndex]);
            int serviceId = int.Parse(serviceIds[cmbservis.SelectedIndex]);
            int customerId = _getCustomerId();
            double startHour = double.Parse(txtbaslangıcsaat.Text);
            double endHour = double.Parse(txtbitissaat.Text);
            DateTime appointmentDate = datebelirle.Value;

            connection.Open();

            NpgsqlCommand komut = new NpgsqlCommand("insert into appointments (saloon_id, employee_id, customer_id, service_id, appointment_date, start_hour, end_hour) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", connection);
            komut.Parameters.AddWithValue("@p1", saloonId);
            komut.Parameters.AddWithValue("@p2", employeeId);
            komut.Parameters.AddWithValue("@p3", customerId);
            komut.Parameters.AddWithValue("@p4", serviceId);
            komut.Parameters.AddWithValue("@p5", appointmentDate);
            komut.Parameters.AddWithValue("@p6", startHour);
            komut.Parameters.AddWithValue("@p7", endHour);
            komut.ExecuteNonQuery();

            connection.Close();
            _getCurrentbalance();

            MessageBox.Show("Randevu kaydı başarıyla oluşturuldu.");

        }

        private void cmbservis_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        int _getCustomerId()
        {
            string currentEmployee = cmbpersonel.Text;
            connection.Open();

            NpgsqlCommand komut = new NpgsqlCommand("select id from customers where user_id=@p1",connection);
            komut.Parameters.AddWithValue("@p1", userId);
            NpgsqlDataReader getCustomerId = komut.ExecuteReader();

            if (getCustomerId.Read())
            {
                int id = int.Parse(getCustomerId["id"].ToString());
                connection.Close();
                return id;
            }
            else
            {
                connection.Close();
                return 0;
            }
            
        }

        private void cmbpersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        Frm_Guncelle frm = new Frm_Guncelle();
        private void btnrandevuguncelle_Click(object sender, EventArgs e)
        {
            frm.customerId = _getCustomerId();
            frm.Show();
        }
    }
}

