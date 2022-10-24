using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HelloWorld
{
    public partial class FormChart : Form
    {
        private Queue<double> dataQueue = new Queue<double>(100);

        private int curValue = 0;

        private int num = 5;//每次删除增加几个点
        public FormChart()
        {
            InitializeComponent();
            InitChart();
        }
        /// <summary>
        /// 初始化图表
        /// </summary>
        private void InitChart()
        {
            //定义图表区域
            this.chart1.ChartAreas.Clear();
            ChartArea chartArea1 = new ChartArea("C1");
            this.chart1.ChartAreas.Add(chartArea1);
            //定义存储和显示点的容器
            this.chart1.Series.Clear();
            Series series1 = new Series("随机数");
            series1.ChartArea = "C1";
            this.chart1.Series.Add(series1);
            //设置图表显示样式
            this.chart1.ChartAreas[0].AxisY.Minimum = 0;
            this.chart1.ChartAreas[0].AxisY.Maximum = 100;
            this.chart1.ChartAreas[0].AxisX.Interval = 5;
            this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            //设置标题
            this.chart1.Titles.Clear();
            this.chart1.Titles.Add("");
            this.chart1.Titles[0].Text = "图表显示";
            this.chart1.Titles[0].ForeColor = Color.RoyalBlue;
            this.chart1.Titles[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            //设置图表显示样式
            this.chart1.Series[0].Color = Color.Red;
            /*if (radioButton1.Checked)
            {
                this.chart1.Titles[0].Text = string.Format("XXX {0} 显示", radioButton1.Text);
                this.chart1.Series[0].ChartType = SeriesChartType.Line;
            }*/
            if (radioButton2.Checked)
            {
                this.chart1.Titles[0].Text = string.Format("XXX {0} 显示", radioButton2.Text);
                this.chart1.Series[0].ChartType = SeriesChartType.Spline;
            }
            this.chart1.Series[0].Points.Clear();
        }
        /// <summary>
        /// 定时器事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateQueueValue();
            this.chart1.Series[0].Points.Clear();
            for (int i = 0; i < dataQueue.Count; i++)
            {
                this.chart1.Series[0].Points.AddXY((i + 1), dataQueue.ElementAt(i));
            }
        }
        //更新队列中的值
        private void UpdateQueueValue()
        {

            if (dataQueue.Count > 100)
            {
                //先出列
                for (int i = 0; i < num; i++)
                {
                    dataQueue.Dequeue();
                }
            }
            /*if (radioButton1.Checked)
            {
                Random r = new Random();
                for (int i = 0; i < num; i++)
                {
                    dataQueue.Enqueue(r.Next(0, 100));
                }
            }*/
            if (radioButton2.Checked)
            {
                for (int i = 0; i < num; i++)
                {
                    //对curValue只取[0,360]之间的值
                    curValue = curValue % 360;
                    //对得到的正玄值，放大50倍，并上移50
                    dataQueue.Enqueue((50 * Math.Sin(curValue * Math.PI / 180)) + 50);
                    curValue = curValue + 10;
                }
            }
        }
    

    private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
        }
    }
}
