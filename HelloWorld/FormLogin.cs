using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            labelMac.Text = Util.GetMacByNetworkInterface();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string stuId=textBoxUserName.Text;
            string password=textBoxPassword.Text;
            if (stuId == "" || password == "")
            {
                MessageBox.Show("请输入完整！");
                textBoxUserName.Text="";  //清空文本
                textBoxPassword.Text = "";
                return;
            }
            if (stuId == "admin")
            {
                MessageBox.Show("管理员账号！请重新输入");
                textBoxUserName.Text = "";  //清空文本
                textBoxPassword.Text = "";
                return;
            }
            DataBaseHepler hepler = new DataBaseHepler();
            string sql = "select stu_password,is_online from users where stu_id=" + stuId;
            MySqlDataReader sqlRead = hepler.selectReturnDataReader(sql);
            if (!sqlRead.Read())
            {
                
                MessageBox.Show("账号不存在！请重新输入");
                textBoxPassword.Text="";  //清空文本
                textBoxUserName.Text = "";
            }
            else if (sqlRead["is_online"].ToString().Trim() == "1")
            {
                MessageBox.Show("账号已登录！请重新输入");
                textBoxPassword.Text = "";  //清空文本
                textBoxUserName.Text = "";
            }
            else if (sqlRead["stu_password"].ToString().Trim() == password)
            {
                MessageBox.Show("登录成功！");
                string sqlUpdate = string.Format("update users set is_online='{0}' where stu_id='{1}'", 1, stuId);  //SQL语句，更新isOnline为上线状态
                hepler.sqlExcute(sqlUpdate);
                Status.stuId = stuId;
                Status.isLogin = true;
                textBoxUserName.Text = "";
                textBoxPassword.Text = "";
                FormMain form=new FormMain();
                form.Show();
                form.Refresh();
                this.Hide();  //隐藏当前form

            }
            else
            {
                MessageBox.Show("密码错误！请重新输入");
                textBoxUserName.Text = "";
                textBoxPassword.Text = "";
            }
        }
        

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
