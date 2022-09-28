using MySql.Data.MySqlClient;
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
    public partial class Form_add : Form
    {
        public Form_add()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void buttonAddStu_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("server=120.48.99.11;database=dk;uid=root;pwd=5845331588");

                MySqlCommand cmd = null;

                string cmdString = "";

                conn.Open();

                cmdString = "INSERT INTO users ( stu_name, stu_id, mac, course_id ) VALUES (\""+textBoxStuName.Text+"\", \""+textBoxStuId.Text+"\", \"00-00-00-00-00-00\", \"1\")";

                cmd = new MySqlCommand(cmdString, conn);

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("添加成功！");
            }catch(Exception ex)
            {
                MessageBox.Show("发生错误："+ex.Message);
            }
        }
    }
}
