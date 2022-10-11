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
            string username=textBoxUserName.Text;
            string password=textBoxPassword.Text;
            if (username == "" || password == "")
            {
                MessageBox.Show("请输入完整！");
                textBoxUserName.Text="";  //清空文本
                textBoxPassword.Text = "";
                return;
            }
            if (username == "admin")
            {
                MessageBox.Show("管理员账号！请重新输入");
                textBoxUserName.Text = "";  //清空文本
                textBoxPassword.Text = "";
                return;
            }
            DataBaseHepler hepler = new DataBaseHepler();
            string sql = "select stu_password,is_online from users where stu_id=" + username;
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
                string sqlUpdate = string.Format("update users set is_online='{0}' where stu_id='{1}'", 1, username);  //SQL语句，更新isOnline为上线状态
                using (MySqlCommand cmdUpdate = new MySqlCommand(sqlUpdate, hepler.GetCon()))  //创建数据库命令类
                {
                    cmdUpdate.ExecuteNonQuery();  //执行SQL语句
                    textBoxUserName.Text = "";
                    textBoxPassword.Text = "";
                    this.Hide();  //隐藏当前form
                }
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
