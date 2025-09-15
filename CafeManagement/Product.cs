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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into products Values(@productid,@productname,@category,@price)", con);
            cnn.Parameters.AddWithValue("@productid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@productname", textBox2.Text);
            cnn.Parameters.AddWithValue("@category", textBox3.Text);
            cnn.Parameters.AddWithValue("@price", int.Parse(textBox4.Text));
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("Select * from products", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("update products set productname=@productname,category=@category,price=@price where productid=@productid", con);
            cnn.Parameters.AddWithValue("@productid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@productname", textBox2.Text);
            cnn.Parameters.AddWithValue("@category", textBox3.Text);
            cnn.Parameters.AddWithValue("@price", int.Parse(textBox4.Text));
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("delete from products where productid=@productid", con);

            cnn.Parameters.AddWithValue("@productid", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted");
        }

        private void Product_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from products", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
