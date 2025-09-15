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
    public partial class CustomerOrder : Form
    {
        public CustomerOrder()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");


            con.Open();

            SqlCommand cnn = new SqlCommand("insert into orders Values(@customername,@itemname,@quantity,@orderdate)", con);

            cnn.Parameters.AddWithValue("@customername", textBox1.Text);
            cnn.Parameters.AddWithValue("@itemname", textBox2.Text);

            cnn.Parameters.AddWithValue("@quantity", int.Parse(textBox3.Text));
            cnn.Parameters.AddWithValue("@orderdate", dateTimePicker1.Value.Date);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Order Successful!");

        }
    }
}
