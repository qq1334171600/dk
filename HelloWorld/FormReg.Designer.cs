namespace HelloWorld
{
    partial class FormReg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReg));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxStuName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelMac = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxStuPassword = new System.Windows.Forms.TextBox();
            this.labelStuId = new System.Windows.Forms.Label();
            this.textBoxStuId = new System.Windows.Forms.TextBox();
            this.textBoxStuPhone = new System.Windows.Forms.TextBox();
            this.labelStuPhone = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxStuName
            // 
            this.textBoxStuName.Location = new System.Drawing.Point(222, 41);
            this.textBoxStuName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxStuName.Name = "textBoxStuName";
            this.textBoxStuName.Size = new System.Drawing.Size(210, 35);
            this.textBoxStuName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(484, 272);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "MAC地址：";
            // 
            // labelMac
            // 
            this.labelMac.AutoSize = true;
            this.labelMac.Location = new System.Drawing.Point(599, 272);
            this.labelMac.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMac.Name = "labelMac";
            this.labelMac.Size = new System.Drawing.Size(214, 24);
            this.labelMac.TabIndex = 3;
            this.labelMac.Text = "00-00-00-00-00-00";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 250);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 46);
            this.button1.TabIndex = 4;
            this.button1.Text = "注册";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(137, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "密码:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBoxStuPassword
            // 
            this.textBoxStuPassword.Location = new System.Drawing.Point(222, 133);
            this.textBoxStuPassword.Name = "textBoxStuPassword";
            this.textBoxStuPassword.Size = new System.Drawing.Size(210, 35);
            this.textBoxStuPassword.TabIndex = 6;
            // 
            // labelStuId
            // 
            this.labelStuId.AutoSize = true;
            this.labelStuId.Location = new System.Drawing.Point(517, 44);
            this.labelStuId.Name = "labelStuId";
            this.labelStuId.Size = new System.Drawing.Size(70, 24);
            this.labelStuId.TabIndex = 7;
            this.labelStuId.Text = "学号:";
            // 
            // textBoxStuId
            // 
            this.textBoxStuId.Location = new System.Drawing.Point(602, 44);
            this.textBoxStuId.Name = "textBoxStuId";
            this.textBoxStuId.Size = new System.Drawing.Size(210, 35);
            this.textBoxStuId.TabIndex = 8;
            // 
            // textBoxStuPhone
            // 
            this.textBoxStuPhone.Location = new System.Drawing.Point(602, 133);
            this.textBoxStuPhone.Name = "textBoxStuPhone";
            this.textBoxStuPhone.Size = new System.Drawing.Size(210, 35);
            this.textBoxStuPhone.TabIndex = 9;
            // 
            // labelStuPhone
            // 
            this.labelStuPhone.AutoSize = true;
            this.labelStuPhone.Location = new System.Drawing.Point(493, 136);
            this.labelStuPhone.Name = "labelStuPhone";
            this.labelStuPhone.Size = new System.Drawing.Size(94, 24);
            this.labelStuPhone.TabIndex = 10;
            this.labelStuPhone.Text = "手机号:";
            // 
            // FormReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 346);
            this.Controls.Add(this.labelStuPhone);
            this.Controls.Add(this.textBoxStuPhone);
            this.Controls.Add(this.textBoxStuId);
            this.Controls.Add(this.labelStuId);
            this.Controls.Add(this.textBoxStuPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelMac);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxStuName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormReg";
            this.Text = "学生注册窗口";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxStuName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelMac;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxStuPassword;
        private System.Windows.Forms.Label labelStuId;
        private System.Windows.Forms.TextBox textBoxStuId;
        private System.Windows.Forms.TextBox textBoxStuPhone;
        private System.Windows.Forms.Label labelStuPhone;
    }
}