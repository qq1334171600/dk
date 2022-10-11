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
    public partial class FormReg : Form
    {
        public FormReg()
        {
            InitializeComponent();
            string mac = Util.GetMacByNetworkInterface();
            labelMac.Text = mac;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxStuName.Text == "" || textBoxStuPassword.Text == "")
            {
                MessageBox.Show("请输入完整！");
                return;
            }
            if (textBoxStuName.Text == "admin")
            {
                MessageBox.Show("管理员账号！请重新输入");
                return;
            }
            string cmdString = "INSERT INTO users ( stu_name, stu_id,stu_password,stu_phone ,mac, course_id ) VALUES (\"" 
                + textBoxStuName.Text + "\", \"" + textBoxStuId.Text+ "\", \"" + textBoxStuPassword.Text  +"\", \"" + textBoxStuPhone.Text + "\", \"" +labelMac.Text+"\", \"1\")";
            DataBaseHepler dataBaseHepler = new DataBaseHepler();
            MessageBox.Show(cmdString);
            int result=dataBaseHepler.sqlExcute(cmdString);
            if (result == 1)
            {
                MessageBox.Show("注册成功");
            }
            else
            {
                MessageBox.Show("注册失败");
            }

        }
    }
}
