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
    public partial class newUserScreen : Form
    {
        int id = 0;
        string typeOfUser = "";
        public newUserScreen(int id_,string t)
        {

            id = id_;
            typeOfUser = t;
            InitializeComponent();
        }

        private void newUserScreen_Load(object sender, EventArgs e)
        {
            string applicationBsePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            System.IO.Directory.CreateDirectory(applicationBsePath + @"\images\");

            if (id != 0)
            {

                var dto = new EAD_Entities.UserDTO();

                dto = EAD_BAL.UserBO.GetUserData(id);
                dto.UserID = id;
                nameTxt.Text = dto.Name;
                passwordTxt.Text = dto.password;
                loginTxt.Text = dto.Login;
                nic.Text = dto.nic;
                emailTxt.Text = dto.Login;
                (DOBTxt.Value) = dto.DOB;
                emailTxt.Text = dto.email;

                string gen;
                if (dto.gender == 'm')
                {
                    gen = "Male";
                }
                else
                {
                    gen = "Female";
                }
                if (dto.imageNmae != "")
                {
                    var imagName = dto.imageNmae;
                    string imgPath = (applicationBsePath + @"\images\");
                    string path = imgPath + imagName;
                    profilePhoto.Load(path);
                }
                genderTxt.SelectedItem = gen;
                cricket.Checked = dto.cricket;
                chess.Checked = dto.chess;
                hockey.Checked = dto.hockey;
                adressTxt.Text = dto.adress;
                ageTxt.Value = dto.age;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {
            var result = FileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                String file = FileDialog.FileName;
                profilePhoto.Load(file);
            }
        }

        private void create_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text == "")
            {
                MessageBox.Show("Please fill the name field");
                return;
            }
            if (emailTxt.Text == "")
            {
                MessageBox.Show("Please fill the email field");
                return;
            }
           
            if (passwordTxt.Text == "")
            {
                MessageBox.Show("Please fill the password field");
                return;
            }
            try
            {
                MailAddress mailAdd = new MailAddress(emailTxt.Text.Trim());

            }
            catch
            {
                MessageBox.Show("Invalid email address");
                return;
            }
            if (loginTxt.Text == "")
            {
                MessageBox.Show("Please fill the login field");
                return;

            }
            if (genderTxt.Text == "")
            {
                MessageBox.Show("Please fill the gender field");
                return;

            }
            if (adressTxt.Text == "")
            {
                MessageBox.Show("Please fill the adress field");
                return;

            }
            if (ageTxt.Text == "")
            {
                MessageBox.Show("Please fill the age field");
                return;

            }
            if (ageTxt.Value < 18)
            {
                MessageBox.Show("You should be at least 18 years old to register");
                return;
            }
            if (nic.Text == "")
            {
                MessageBox.Show("Please fill the NIC field");
                return;
            }
            if (DateTime.Today.AddYears(-18) < DOBTxt.Value.Date)
            {
                MessageBox.Show("You should be at least 18 years old to register");
                return;
            }
            char gen;
            if ((genderTxt.SelectedItem.ToString()) == "Female")
            {
                gen = 'f';
            }
            else
            {
                gen = 'm';
            }
            bool Cricket = cricket.Checked ? true : false;
            bool Hockey = hockey.Checked ? true : false;
            bool Chess = chess.Checked ? true : false;
            string uniqName="";
            if (profilePhoto.Image != null)
            {
                string applicationBsePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                String pathToSaveImage = applicationBsePath + @"\images\";
                uniqName = Guid.NewGuid().ToString() + ".jpg";
                string imagPath = pathToSaveImage + uniqName;
                profilePhoto.Image.Save(imagPath);
            }
           
            if (id != 0)
            {
                var dto = new EAD_Entities.UserDTO();
                dto.Name = nameTxt.Text.Trim();
                dto.password = passwordTxt.Text.Trim();
                dto.Login = loginTxt.Text.Trim();
                dto.nic = nic.Text.Trim();
                dto.DOB = (DOBTxt.Value);
                dto.gender = gen;
                dto.imageNmae = uniqName;
                dto.createOn = DateTime.Now;
                dto.cricket = Cricket;
                dto.chess = Chess;
                dto.hockey = Hockey;
                dto.adress = adressTxt.Text.Trim();
                dto.age = ageTxt.Value;
                dto.UserID = id;
                dto.email = emailTxt.Text.Trim();
                              
                {
                    int count = UserBO.Save(dto);
                    if (count > 0)
                    {

                        MessageBox.Show("successful");

                        this.Hide();
                        if (typeOfUser == "A")
                        {
                            AdminHome obj = new AdminHome();
                            obj.Show();

                        }
                        else
                        {
                            UserHome obj = new UserHome(dto.UserID, dto.Name);
                            obj.Show();
                        }

                    }
                }
            }
            else

            {
                var dto = new EAD_Entities.UserDTO();
                dto.Name = nameTxt.Text.Trim();
                dto.password = passwordTxt.Text.Trim();
                dto.Login = loginTxt.Text.Trim();
                dto.nic = nic.Text.Trim();
                dto.DOB = (DOBTxt.Value);
                dto.gender = gen;
                dto.createOn = DateTime.Now;
                dto.cricket = Cricket;
                dto.chess = Chess;
                dto.hockey = Hockey;
                dto.adress = adressTxt.Text.Trim();
                dto.age = ageTxt.Value;
                dto.imageNmae = uniqName;
                dto.email =( emailTxt.Text).Trim();
                bool result = UserBO.IsExistingUser(loginTxt.Text.Trim());
                if (result == true)
                {
                    MessageBox.Show("username already exists");
                    return;
                }
                bool result2 = UserBO.IsExistingEmail(emailTxt.Text.Trim());
                if (result2 == true)
                {
                    MessageBox.Show("email already exists");
                    return;
                }
                else
                {
                    int count = UserBO.Save(dto);
                    if (count > 0)
                    {

                        MessageBox.Show("successful");
                        var userObj = new EAD_Entities.UserDTO();
                        userObj = EAD_BAL.UserBO.GetUserDataByLogin(loginTxt.Text.Trim());
                        this.Hide();
                        UserHome obj = new UserHome(userObj.UserID, userObj.Name);
                        obj.Show();

                    }
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                this.Hide();
                MainScreen mScreen = new MainScreen();
                mScreen.Show();
            }
            else if(typeOfUser=="A")
            {
                this.Hide();
                AdminHome adminH = new AdminHome();
                adminH.Show();
            }
            else if(typeOfUser=="U")
            {
                var dto = new EAD_Entities.UserDTO();
                dto = EAD_BAL.UserBO.GetUserData(id);
                this.Hide();
                UserHome obj = new UserHome(dto.UserID, dto.Name);
                obj.Show(); 
            }
        }
    }
}
