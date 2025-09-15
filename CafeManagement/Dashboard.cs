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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            display1();
            display2();
            display3();
            display4();
           
        }

        private void display1()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM customers", con);
            Int32 count = Convert.ToInt32(comm.ExecuteScalar());
            if (count > 0)
            {
                lblCount1.Text = Convert.ToString(count.ToString()); //For example a Label
            }
            else
            {
                lblCount1.Text = "0";
            }
            con.Close(); //Remember close the connection
        }

        private void display2()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM orders", con);
            Int32 count = Convert.ToInt32(comm.ExecuteScalar());
            if (count > 0)
            {
                lblCount2.Text = Convert.ToString(count.ToString()); //For example a Label
            }
            else
            {
                lblCount2.Text = "0";
            }
            con.Close(); //Remember close the connection
        }

        private void display3()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM products", con);
            Int32 count = Convert.ToInt32(comm.ExecuteScalar());
            if (count > 0)
            {
                lblCount3.Text = Convert.ToString(count.ToString()); //For example a Label
            }
            else
            {
                lblCount3.Text = "0";
            }
            con.Close(); //Remember close the connection
        }

        private void display4()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM waiters", con);
            Int32 count = Convert.ToInt32(comm.ExecuteScalar());
            if (count > 0)
            {
                lblCount4.Text = Convert.ToString(count.ToString()); //For example a Label
            }
            else
            {
                lblCount4.Text = "0";
            }
            con.Close(); //Remember close the connection
        }

    }


}
