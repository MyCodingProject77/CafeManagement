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
    public partial class UserLogin : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public UserLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != string.Empty || txtUsername.Text != string.Empty)
            {
                cmd = new SqlCommand("select * from usertab where Username='" + txtUsername.Text + "' and Password='" + txtPassword.Text + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    CustomerOrder mn = new CustomerOrder();
                    mn.Show();

                }

                else
                {
                    dr.Close();
                    MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-DASLLN7;Initial Catalog=CafeDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register rr = new Register();
            rr.Show();
        }
    }
}
