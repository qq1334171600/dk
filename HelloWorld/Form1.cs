using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Device.Location;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HelloWorld
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            conn = GetMySqlConnection();
            if (conn!=null)
            {
                try
                {
                    conn.Open();
                    label3.Text = "是";
                }
                catch(MySqlException e)
                {
                    MessageBox.Show(e.Message);
                    label3.Text = "否";
                }
            }
        }
        private MySqlConnection GetMySqlConnection()
        {
            string address = "server=120.48.99.11;port=3306;user=root;password=5845331588; database=dk;";
            MySqlConnection connection = new MySqlConnection(address);
            return connection;
        }
        private void Form1_FormClosing(object sender,FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("是否关闭", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    conn.Close();
                    MessageBox.Show("数据库已关闭");
                }catch(MySqlException e1)
                {
                    MessageBox.Show(e1.Message);
                }
                finally
                {
                    conn.Close();
                }

                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("打卡成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CLocation myLocation = new CLocation();
            myLocation.GetLocationEvent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        /*
        点击显示注册界面 
        */
        private void button5_Click(object sender, EventArgs e)
        {
            Form2 formRegister=new Form2();
            formRegister.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    class CLocation
    {
        GeoCoordinateWatcher watcher;

        public void GetLocationEvent()
        {
            this.watcher = new GeoCoordinateWatcher();
            this.watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
            bool started = this.watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));
            if (!started)
            {
                MessageBox.Show("GeoCoordinateWatcher timed out on start.");
            }
        }

        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            MessageBox.Show("watcher_PositionChanged/" + e.ToString());
            PrintPosition(e.Position.Location.Latitude, e.Position.Location.Longitude);
        }

        void PrintPosition(double Latitude, double Longitude)
        {
            MessageBox.Show("Latitude: "+Latitude+", Longitude "+Longitude);
        }
    }

}
