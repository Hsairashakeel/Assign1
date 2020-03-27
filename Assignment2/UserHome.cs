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
            var dto = new EAD_Entities.UserDTO();
            dto = EAD_BAL.UserBO.GetUserData(id);
            var imagName = dto.imageNmae;
            string applicationBsePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string imgPath = (applicationBsePath + @"\images\");
            string path = imgPath + imagName;
            pictureBox1.Load(path);


        }

        private void editProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
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
