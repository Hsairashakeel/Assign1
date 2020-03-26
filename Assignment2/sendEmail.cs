using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Assignment2
{
    public partial class sendEmail : Form
    {
        String email = "";
        String code;
        String login = "";
        public sendEmail(String email_, String login_)
        {
            InitializeComponent();
            email = email_;
            login = login_;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != code)
            {
                MessageBox.Show("Incorrect code!");

            }
            else
            {
                MessageBox.Show("correct code!");
                this.Hide();
                resetPassword resetPass = new resetPassword(login);
                resetPass.Show();
            }
        }

        private void sendEmail_Load(object sender, EventArgs e)
        {
            try
            {
                String fromDisplayEmail = "nayabmalik.my@gmail.com";
                String fromPassword = "sairashakeel";
                String fromDisplayNmae = "";
                MailAddress fromAdress = new MailAddress(fromDisplayEmail, fromDisplayNmae);
                MailAddress toAddress = new MailAddress("sairashakeel.py@gmail.com");
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAdress.Address, fromPassword)

                };
                String name = Guid.NewGuid().ToString();
                code = name.Split('-')[1];
                using (var message = new MailMessage(fromAdress, toAddress)
                {
                    Subject = "reset-Password",
                    Body = code

                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
