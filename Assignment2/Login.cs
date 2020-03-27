using EAD_BAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text == "")
            {
                MessageBox.Show("Please fill the name field");
                return;
            }
            if (passwordTxt.Text == "")
            {
                MessageBox.Show("Please fill the email field");
                return;
            }
            bool result = UserBO.IsValidUser(nameTxt.Text, passwordTxt.Text);
            if (result == true)
            {
                MessageBox.Show("logged In");
                var dto = new EAD_Entities.UserDTO();
                dto = EAD_BAL.UserBO.GetUserDataByLogin(nameTxt.Text);
                this.Hide();
                UserHome obj = new UserHome(dto.UserID, dto.Name);
                obj.Show();
            }
            else
            {
                MessageBox.Show("Invalid username/password");

            }

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainScreen mScreen = new MainScreen();
            mScreen.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (emailTxt.Text == "")
            {
                MessageBox.Show("Please fill the email field");
                return;
            }
            if (nameTxt.Text == "")
            {
                MessageBox.Show("Please fill the username field");
                return;

            }
            else
            {
                bool result = UserBO.IsValidLogin(nameTxt.Text);
                if (result == false)
                {                    
                    MessageBox.Show("Invalid username");
                    return;

                }
                try
                {
                    MailAddress mailAdd = new MailAddress(emailTxt.Text);
                    
                }
                catch
                {
                    MessageBox.Show("Invalid email address");
                    return;
                }
                this.Hide();
                sendEmail m = new sendEmail(emailTxt.Text, nameTxt.Text);
                m.Show();

            }
        }

        private void nameTxt_TextChanged(object sender, EventArgs e)
        {
            

        }
    }
}
