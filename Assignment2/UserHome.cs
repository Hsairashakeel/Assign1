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
   
    public partial class UserHome : Form
    {
        int id = 0;
        String name = "";
        public UserHome(int id_, String name_)
        {
            InitializeComponent();
            id = id_;
            name = name_;
        }

        private void UserHome_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome " + name;
            MessageBox.Show("uuserhome1");

            MessageBox.Show(id.ToString());


        }

        private void editProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("uuserhome2");

            MessageBox.Show(id.ToString());
            newUserScreen obj = new newUserScreen(id, "U");
            obj.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainScreen mainSc = new MainScreen();
            mainSc.Show();
        }
    }
}
