using EAD_BAL;
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
    public partial class AdminHome : Form
    {
        public AdminHome()
        {
            InitializeComponent();
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var id = (int)table.CurrentRow.Cells[1].Value;
                this.Hide();
                newUserScreen obj = new newUserScreen(id, "A");
                obj.ShowDialog();
            }
        }

        private void ShowData_Click(object sender, EventArgs e)
        {
            Object dt = UserBO.showData();
            table.DataSource = dt;
        }

        private void Logout_Click(object sender, EventArgs e)
        {

            this.Hide();
            MainScreen mScreen = new MainScreen();
            mScreen.Show();
        }
    }
}
