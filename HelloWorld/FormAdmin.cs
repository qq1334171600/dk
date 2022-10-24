using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }
        //学生管理
        private void button1_Click(object sender, EventArgs e)
        {
            FormManageUsers manageUsers = new FormManageUsers();
            manageUsers.Show();
        }

        private void buttonChart_Click(object sender, EventArgs e)
        {

        }
    }
}
