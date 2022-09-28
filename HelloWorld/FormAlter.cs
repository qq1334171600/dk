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
    public partial class FormAlter : Form
    {
        string mStuName = "";
        string mStuId = "";
        public FormAlter(string stuName,string stuId)
        {
            InitializeComponent();
            mStuName = stuName;
            mStuId = stuId;
            textBoxStuId.Text = mStuId;
            textBoxStuName.Text = mStuName;
        }

        private void buttonAlter_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("server=120.48.99.11;database=dk;uid=root;pwd=5845331588");

                MySqlCommand cmd = null;

                string cmdString = "";

                conn.Open();

                cmdString = "UPDATE users SET stu_name=\""+textBoxStuName.Text+"\",stu_id=\""+textBoxStuId.Text+"\" WHERE stu_id=\""+mStuId+"\"";

                cmd = new MySqlCommand(cmdString, conn);

                var row = cmd.ExecuteNonQuery();

                conn.Close();

                if (row > 0)

                {

                    MessageBox.Show("修改成功！");

                }
                else
                {
                    MessageBox.Show("修改失败!");
                }

              
            }catch (Exception ex)
            {
                MessageBox.Show("修改错误：" + ex.Message);
            }
        }
    }
}
