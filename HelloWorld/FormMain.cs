﻿using System;
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
using static System.Net.WebRequestMethods;

namespace HelloWorld
{
    public partial class FormMain : Form
    {
        MySqlConnection conn;
        String filePath = "";
        public FormMain()
        {
            InitializeComponent();
            if (Status.isLogin == true)
            {
                label11.Text = "是";
            }
            else
            {
                label11.Text = "否";
            }
            labelMac.Text = Util.GetMacByNetworkInterface();
            DataBaseHepler data = new DataBaseHepler();
            conn = data.GetCon();
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
        
        private void Form1_FormClosing(object sender,FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("是否关闭", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    DataBaseHepler hepler = new DataBaseHepler();
                    string sqlUpdate = string.Format("update users set is_online='{0}' where stu_id='{1}'", 0, Status.stuId);  //SQL语句，更新isOnline为上线状态
                    hepler.sqlExcute(sqlUpdate);
                    Status.isLogin = false;
                    Status.stuId = "";
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
            this.Dispose();
        }
        private  async void button1_Click(object sender, EventArgs e)
        {
            if (Status.isLogin)
            {
                string picUrl = "http://7.zhangjian.link/dk/";
                //http://7.zhangjian.link/dk/202200501240/2022-10-16/12-00-17.jpg
                HttpResult result = await Util.UploadPicture(filePath);
                if(result.Code == 200)
                {
                    string cmdString = "INSERT INTO attendance ( attendance_id, stu_id,time,location ,pic_url, notes ) VALUES (\""
                + "dk_" + Status.stuId + "_" + Util.GetMacByNetworkInterface() + "_" + DateTime.Now.ToString("yyyy-MM-dd/HH-mm-ss") +"\",\""
                + Status.stuId+"\",\""+ dateTimePicker1.Text+"\",\""+label14.Text+"\",\""+picUrl+Status.stuId+"/"+ DateTime.Now.ToString("yyyy-MM-dd/HH-mm-ss")+".jpg\",\""+richTextBox1.Text+"\")";
                    MessageBox.Show(cmdString);
                    DataBaseHepler hepler = new DataBaseHepler();
                    int dkResult = hepler.sqlExcute(cmdString);
                    if (dkResult == 1)
                    {
                        MessageBox.Show("打卡成功");
                    }
                }
                //string dkResult = dateTimePicker1.Text +"\n"+ label14.Text +"\n"+ filePath +"\n"+ richTextBox1.Text;
                //MessageBox.Show("打卡成功:\n"+dkResult);
            }
            else
            {
                MessageBox.Show("请登录");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Status.isLogin == true)
            {
                CLocation myLocation = new CLocation(label14);
                myLocation.GetLocationEvent();
            }
            else
            {
                MessageBox.Show("请先登录!");
            }
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
            FormReg formRegister=new FormReg();
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
            if (Status.isLogin == true)
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
            else
            {
                MessageBox.Show("请登录");
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

        private void button4_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (Status.isLogin == true)
            {

            }
            else
            {
                MessageBox.Show("请登录！");
            }
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
            string result=Util.HttpGetNew("http://restapi.amap.com/v3/geocode/regeo?location="+Longitude+","+Latitude+"&key=17479d86c0c6a0305024e1142351a0a4","");
            
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
