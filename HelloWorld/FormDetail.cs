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
    public partial class FormDetail : Form
    {
        public FormDetail(string stuName,string stuId,string time,string location,string picUrl,string notes)
        {
            InitializeComponent();
            labelStuName.Text = stuName;
            labelStuId.Text = stuId;
            labelTime.Text = time;
            labelLocation.Text = location;
            pictureBox.LoadAsync(picUrl);
            richTextBox1.Text = notes;
        }

        private void FormDetail_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
