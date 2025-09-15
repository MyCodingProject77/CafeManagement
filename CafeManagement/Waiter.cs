using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagement
{
    public partial class Waiter : Form
    {
        public Waiter()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("insert into waiters Values(@waiterid,@name,@age,@phone)", con);

            cnn.Parameters.AddWithValue("@waiterid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@name", textBox2.Text);

            cnn.Parameters.AddWithValue("@age", int.Parse(textBox3.Text));
            cnn.Parameters.AddWithValue("@phone", textBox4.Text);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from waiters", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("update waiters set name=@name,age=@age,phone=@phone where waiterid=@waiterid", con);

            cnn.Parameters.AddWithValue("@waiterid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@name", textBox2.Text);

            cnn.Parameters.AddWithValue("@age", int.Parse(textBox3.Text));
            cnn.Parameters.AddWithValue("@phone", textBox4.Text);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("delete from waiters where waiterid=@waiterid", con);

            cnn.Parameters.AddWithValue("@waiterid", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void Waiter_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from waiters", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }
    }
}
