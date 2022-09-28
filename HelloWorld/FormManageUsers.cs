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
using Excel = Microsoft.Office.Interop.Excel;

namespace HelloWorld
{
    public partial class FormManageUsers : Form
    {
        MySqlConnection connection;
        MySqlCommand cmd;
        StringBuilder builder;
        public FormManageUsers()
        {
            //初始化程序界面
            InitializeComponent();
            Timer timer = new Timer
            {
                Interval = 3000
            };
            timer.Tick += (object sender, EventArgs e) => {
                if(connection != null && connection.State == ConnectionState.Open && cmd != null)
                {
                    SelectUsers();
                }
                
            };
            timer.Start();

        }
        /**
         *获取一个数据库连接（MySQL数据库）
         *举例：我们想要使用自来水，就需要用水管连接到供水系统上
         *水管即连接，有了可用的连接才可以使用数据库里的数据
         *连接的材料：数据库的地址，数据库的名字，账号，密码。
         * */
        private MySqlConnection GetMySqlConnection()
        {
            string address = "server=120.48.99.11;port=3306;user=root;password=5845331588; database=dk;";
            if (connection == null)
            {
                connection = new MySqlConnection(address);
            }
            return connection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(connection == null)
            {
                GetMySqlConnection();
            }
            if (connection != null)
            {
                MessageBox.Show("初始化成功!");
            }
            else
            {
                MessageBox.Show("失败啦，找找原因吧！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (connection != null)
            {
                if(connection.State != ConnectionState.Open)
                {
                    try
                    {
                        connection.Open();
                        MessageBox.Show("数据库连接成功！");
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("数据库失败:" + ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("数据库已经连接！无需重复连接！");
                }

            }
        }
        private void SelectUsers()
        {
            string sql = "select stu_name,stu_id from users";
            cmd = new MySqlCommand(sql, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "t_user");
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SelectUsers();   
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            builder = new StringBuilder();
            for (int i=0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    for(int j=0; j < dataGridView1.Columns.Count; j++)
                    {
                        builder.Append(dataGridView1.Rows[i].Cells[j].Value.ToString()+",");
                    }
                }
            }
            //MessageBox.Show(builder.ToString());
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0) // 绘制 自动序号
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle vRect = e.CellBounds;
                vRect.Inflate(-2, 2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, vRect, e.CellStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                e.Handled = true;
            }

            // ----- 其它样式设置 -------
            if (e.RowIndex % 2 == 0)
            { // 行序号为双数（含0）时
                e.CellStyle.BackColor = Color.White;
            }
            else
            {
                e.CellStyle.BackColor = Color.Honeydew;
            }
            e.CellStyle.SelectionBackColor = Color.Gray; // 选中单元格时，背景色
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //单位格内数据对齐方式

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_add add=new Form_add();
            add.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (builder != null && builder.Length > 0)
            {
                FormAlter alter = new FormAlter(builder.ToString().Split(',')[0], builder.ToString().Split(',')[1]);
                alter.Show();
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
           /* if (connection == null)
            {
                connection=GetMySqlConnection();
                cmd=connection.
            }
            if (connection .State==ConnectionState.Closed)
            {
                connection.Open();
            }*/
           
            DialogResult dialog = MessageBox.Show("确定删除吗???", "警告!", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
            if(dialog == DialogResult.Yes&&builder.Length>0)
            {
                cmd = new MySqlCommand(null,connection);
                cmd.CommandText = "DELETE FROM users WHERE stu_id = \"" + builder.ToString().Split(',')[1]+"\"";
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("删除成功!");
                else
                    MessageBox.Show("删除失败！");
            }
        }

        private void buttonToExcel_Click(object sender, EventArgs e)
        {
            string fileName = "XZA-STU";//可以在这里设置默认文件名
            string saveFileName = "";//文件保存名
            SaveFileDialog saveDialog = new SaveFileDialog();//实例化文件对象
            saveDialog.DefaultExt = "xlsx";//文件默认扩展名
            saveDialog.Filter = "Excel文件|*.xlsx";//获取或设置当前文件名筛选器字符串，该字符串决定对话框的“另存为文件类型”或“文件类型”框中出现的选择内容。
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();//打开保存窗口给你选择路径和设置文件名
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，您的电脑可能未安装Excel");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;//Workbooks代表一个 Microsoft Excel 工作簿
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);//新建一个工作表。 新工作表将成为活动工作表。
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1 
                                                                                                                                  //写入标题             
            for (int i = 0; i < dataGridView1.ColumnCount; i++)//遍历循环获取DataGridView标题
            { worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText; }// worksheet.Cells[1, i + 1]表示工作簿第一行第i+1列，Columns[i].HeaderText表示第i列的表头
            //写入数值
            for (int r = 0; r < dataGridView1.Rows.Count; r++)//这里表示数据的行标,dataGridView1.Rows.Count表示行数
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)//遍历r行的列数
                {
                    worksheet.Cells[r + 2, i + 1] = dataGridView1.Rows[r].Cells[i].Value;//Cells[r + 2, i + 1]表示工作簿从第二行开始第一行保存为表头了，dataGridView1.Rows[r].Cells[i].Value获取列的r行i值
                }
                System.Windows.Forms.Application.DoEvents();//实时更新表格
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            MessageBox.Show(fileName + "资料保存成功", "提示", MessageBoxButtons.OK);//提示保存成功
            if (saveFileName != "")//saveFileName保存文件名不为空
            {
                try
                {
                    workbook.Saved = true;//获取或设置一个值，该值指示工作簿自上次保存以来是否进行了更改
                    workbook.SaveCopyAs(saveFileName);  //fileSaved = true;将工作簿副本保存到文件中，但不修改内存中打开的工作簿                 
                }
                catch (Exception ex)
                {//fileSaved = false;                      
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁           
        
        }
    }
}
