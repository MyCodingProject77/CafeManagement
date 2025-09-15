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
    public partial class OrderDetail : Form
    {
        public OrderDetail()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into orderdetails Values(@odid,@customername,@ordername,@quantity,@orderdate,@amount)", con);
            cnn.Parameters.AddWithValue("@odid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@customername", textBox2.Text);
            cnn.Parameters.AddWithValue("@ordername", textBox3.Text);
            cnn.Parameters.AddWithValue("@quantity", textBox4.Text);
            cnn.Parameters.AddWithValue("@orderdate", dateTimePicker1.Value.Date);
            cnn.Parameters.AddWithValue("@amount", int.Parse(textBox5.Text));
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("Select * from orderdetails", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("update orderdetails set customername=@customername,ordername=@ordername,quantity=@quantity,orderdate=@orderdate,amount=@amount where odid=@odid", con);
            cnn.Parameters.AddWithValue("@odid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@customername", textBox2.Text);
            cnn.Parameters.AddWithValue("@ordername", textBox3.Text);
            cnn.Parameters.AddWithValue("@quantity", textBox4.Text);
            cnn.Parameters.AddWithValue("@orderdate", dateTimePicker1.Value.Date);
            cnn.Parameters.AddWithValue("@amount", int.Parse(textBox5.Text));
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("delete from orderdetails where odid=@odid", con);
            cnn.Parameters.AddWithValue("@odid", int.Parse(textBox1.Text));
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
            textBox5.Text = "";
        }

        private void OrderDetail_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("Select * from orderdetails", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
