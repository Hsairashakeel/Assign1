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
    public partial class resetPassword : Form
    {
        String login = "";

        public resetPassword(String login_)
        {
            InitializeComponent();
            login = login_;

        }

        private void resetPassword_Load(object sender, EventArgs e)
        {

        }

        private void reset_Click(object sender, EventArgs e)
        {
            if(passTxt.Text=="")
            {
                MessageBox.Show("Plesae Enter a Password");
                return;
            }

            int count = EAD_BAL.UserBO.resetPassword(passTxt.Text, login);
            if (count > 0)
            {
                MessageBox.Show("Password has been Updated Successfully");
            }
            var userObj = new EAD_Entities.UserDTO();
            userObj = EAD_BAL.UserBO.GetUserDataByLogin(login);
            this.Hide();
            UserHome obj = new UserHome(userObj.UserID, userObj.Name);
            obj.Show();
        }
    }
}
