using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Qiniu.Http;
using Qiniu.Storage;
using Qiniu.Util;

namespace HelloWorld
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        String filePath = "";
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
        private string HttpPostNew(string Url, string postDataStr)
        {
            byte[] postBytes = Encoding.GetEncoding("utf-8").GetBytes(postDataStr);
            HttpWebRequest request = WebRequest.Create(Url) as HttpWebRequest;//(HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = postBytes.Length;
            Stream myRequestStream = request.GetRequestStream();
            myRequestStream.Write(postBytes, 0, postBytes.Length);
            myRequestStream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }
        /**
         * http://restapi.amap.com/v3/geocode/regeo?location=119.785925777778,33.4773057777778&key=17479d86c0c6a0305024e1142351a0a4
         * */
        public static string HttpGetNew(string Url, string postDataStr)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
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
        public static string GetMacByNetworkInterface()
        {
            try
            {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface ni in interfaces)
                {
                    return BitConverter.ToString(ni.GetPhysicalAddress().GetAddressBytes());
                }
            }
            catch (Exception)
            {
            }
            return "00-00-00-00-00-00";
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            string AccessKey = "mjd6uCjQwnEAJIuBO7SVEZmgKc9oIwS3qHGWJx_O";
            string SecretKey = "f7N8e_NqIWD32WZiq1tHz64amL60WbK28Ikl1nK8";
            Mac mac = new Mac(AccessKey, SecretKey);
            // 上传文件名
            string key = "dk-"+ GetMacByNetworkInterface()+ DateTime.Now.ToString()+".jpg";
            // 本地文件路径
            string filePath = this.filePath;
            // 存储空间名
            string Bucket = "z1334";
            // 设置上传策略
            PutPolicy putPolicy = new PutPolicy();
            // 设置要上传的目标空间
            putPolicy.Scope = Bucket;
            // 上传策略的过期时间(单位:秒)
            putPolicy.SetExpires(3600);
            // 文件上传完毕后，在多少天后自动被删除
           // putPolicy.DeleteAfterDays = 1;
            // 生成上传token
            string token = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());
            Config config = new Config();
            // 设置上传区域
            config.Zone = Zone.ZoneCnEast;
            // 设置 http 或者 https 上传
            config.UseHttps = false;
            config.UseCdnDomains = false;
            config.ChunkSize = ChunkUnit.U512K;
            // 表单上传
            FormUploader target = new FormUploader(config);
            HttpResult result = await target.UploadFile(filePath, key, token, null);
            MessageBox.Show(result.ToString());




            //string dkResult = dateTimePicker1.Text +"\n"+ label14.Text +"\n"+ filePath +"\n"+ richTextBox1.Text;
            //MessageBox.Show("打卡成功:\n"+dkResult);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CLocation myLocation = new CLocation(label14);
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

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void buttonManageUser_Click(object sender, EventArgs e)
        {
            FormManageUsers manageUsers = new FormManageUsers();
            manageUsers.Show();
        }

        private void buttonSelectPic_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog();//打开文件对话框 
            fileDialog.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;//初始化路径
            fileDialog.Filter = "图片(*.jpg;*.bmp;*.png)|*.jpg;*.bmp;*.png";//或"图片(*.jpg;*.bmp)|*.jpg;*.bmp";//过滤选项设置，文本文件，所有文件。
            fileDialog.FilterIndex = 0;//当前使用第二个过滤字符串
            fileDialog.RestoreDirectory = true;//对话框关闭时恢复原目录
            fileDialog.Title = "选择图片";
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = fileDialog.FileName;
                MessageBox.Show(filePath);
                pictureBox1.LoadAsync(filePath);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {

            MessageBox.Show("双击了" + this.listView1.SelectedItems[0] );
        }
    }
    class CLocation
    {
        bool getLocationIsSuccessful = false;
         Label mLabel14;
        public CLocation(Label label14)
        {
            mLabel14 = label14;
        }
        GeoCoordinateWatcher watcher;

        public void GetLocationEvent()
        {
            this.watcher = new GeoCoordinateWatcher();
            this.watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(Watcher_PositionChanged);
            bool started = this.watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));
                mLabel14.Text = "获取中...";
            Timer timer = new Timer
            {
                Interval = 10000
            };
            timer.Tick += (object sender, EventArgs e) => {
                if (!getLocationIsSuccessful && !started)
                {
                    mLabel14.Text = "获取失败";
                    timer.Stop();
                }
            };
            timer.Start();


        }

        void Watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            //MessageBox.Show("watcher_PositionChanged/" + e.ToString());
            PrintPosition(e.Position.Location.Latitude, e.Position.Location.Longitude);
            if (e.Position.Location.IsUnknown)
            {
                mLabel14.Text = "未知";
            }
        }

        void PrintPosition(double Latitude, double Longitude)
        {
            string result=Form1.HttpGetNew("http://restapi.amap.com/v3/geocode/regeo?location="+Longitude+","+Latitude+"&key=17479d86c0c6a0305024e1142351a0a4","");
            
            if(result.Length > 0)
            {
                try
                {
                    getLocationIsSuccessful = true;
                    Dictionary<string, object> dicJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
                    string status = dicJson["status"].ToString();
                    if (status.Equals("1"))
                    {
                        Dictionary<string, object> address = JsonConvert.DeserializeObject<Dictionary<string, object>>(dicJson["regeocode"].ToString());
                        string formatedAddress = address["formatted_address"].ToString();
                        mLabel14.Text = formatedAddress;
                        //MessageBox.Show(formatAddress);
                    }
                }catch(Exception e)
                {
                    MessageBox.Show("程序发生错误："+e.Message);
                }
            }
           

        }
    }

}
