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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("insert into payments Values(@pid,@customername,@paymentmethod,@amount)", con);

            cnn.Parameters.AddWithValue("@pid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@customername", textBox2.Text);

            cnn.Parameters.AddWithValue("@paymentmethod", textBox3.Text);
            cnn.Parameters.AddWithValue("@amount", int.Parse(textBox4.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from payments", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("update payments set customername=@customername,paymentmethod=@paymentmethod,amount=@amount where pid=@pid", con);

            cnn.Parameters.AddWithValue("@pid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@customername", textBox2.Text);

            cnn.Parameters.AddWithValue("@paymentmethod", textBox3.Text);
            cnn.Parameters.AddWithValue("@amount", int.Parse(textBox4.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("delete from payments where pid=@pid", con);

            cnn.Parameters.AddWithValue("@pid", int.Parse(textBox1.Text));

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

        private void Payment_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from payments", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }
    }
}
