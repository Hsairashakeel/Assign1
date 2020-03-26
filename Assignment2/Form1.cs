using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void newUserBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            newUserScreen obj = new newUserScreen(0, "");
            obj.Show();
        }

        private void ExistingUseBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login obj = new Login();
            obj.Show();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin obj = new AdminLogin();
            obj.Show();

        }
    }
}
