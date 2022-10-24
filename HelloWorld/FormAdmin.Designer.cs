namespace HelloWorld
{
    partial class FormAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonManageStudent = new System.Windows.Forms.Button();
            this.buttonSelectDaily = new System.Windows.Forms.Button();
            this.buttonChart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonManageStudent
            // 
            this.buttonManageStudent.Location = new System.Drawing.Point(12, 12);
            this.buttonManageStudent.Name = "buttonManageStudent";
            this.buttonManageStudent.Size = new System.Drawing.Size(124, 79);
            this.buttonManageStudent.TabIndex = 0;
            this.buttonManageStudent.Text = "学生管理";
            this.buttonManageStudent.UseVisualStyleBackColor = true;
            this.buttonManageStudent.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSelectDaily
            // 
            this.buttonSelectDaily.Location = new System.Drawing.Point(163, 12);
            this.buttonSelectDaily.Name = "buttonSelectDaily";
            this.buttonSelectDaily.Size = new System.Drawing.Size(174, 79);
            this.buttonSelectDaily.TabIndex = 1;
            this.buttonSelectDaily.Text = "周报查询";
            this.buttonSelectDaily.UseVisualStyleBackColor = true;
            // 
            // buttonChart
            // 
            this.buttonChart.Location = new System.Drawing.Point(367, 12);
            this.buttonChart.Name = "buttonChart";
            this.buttonChart.Size = new System.Drawing.Size(141, 79);
            this.buttonChart.TabIndex = 2;
            this.buttonChart.Text = "波形图";
            this.buttonChart.UseVisualStyleBackColor = true;
            this.buttonChart.Click += new System.EventHandler(this.buttonChart_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonChart);
            this.Controls.Add(this.buttonSelectDaily);
            this.Controls.Add(this.buttonManageStudent);
            this.Name = "FormAdmin";
            this.Text = "管理员窗口";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonManageStudent;
        private System.Windows.Forms.Button buttonSelectDaily;
        private System.Windows.Forms.Button buttonChart;
    }
}