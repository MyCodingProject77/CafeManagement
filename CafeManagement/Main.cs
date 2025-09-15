using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagement
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer cr = new Customer();
            cr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product pt = new Product();
            pt.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OrderDetail od = new OrderDetail();
            od.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Waiter wr = new Waiter();
            wr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Payment pt = new Payment();
            pt.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dashboard dd = new Dashboard();
            dd.Show();
        }
    }
}
