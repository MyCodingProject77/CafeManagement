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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("insert into customers Values(@customerid,@customername,@email,@phone)", con);

            cnn.Parameters.AddWithValue("@customerid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@customername", textBox2.Text);

            cnn.Parameters.AddWithValue("@email", textBox3.Text);
            cnn.Parameters.AddWithValue("@phone", textBox4.Text);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from customers", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("update customers set customername=@customername,email=@email,phone=@phone where customerid=@customerid", con);

            cnn.Parameters.AddWithValue("@customerid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@customername", textBox2.Text);

            cnn.Parameters.AddWithValue("@email", textBox3.Text);
            cnn.Parameters.AddWithValue("@phone", textBox4.Text);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("delete from customers where customerid=@customerid", con);

            cnn.Parameters.AddWithValue("@customerid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@customername", textBox2.Text);

            cnn.Parameters.AddWithValue("@email", textBox3.Text);
            cnn.Parameters.AddWithValue("@phone", textBox4.Text);

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

        private void Customer_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from customers", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }
    }
}
