namespace HelloWorld
{
    partial class FormAdd
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
            this.labelStuName = new System.Windows.Forms.Label();
            this.labelStuId = new System.Windows.Forms.Label();
            this.buttonAddStu = new System.Windows.Forms.Button();
            this.textBoxStuName = new System.Windows.Forms.TextBox();
            this.textBoxStuId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelStuName
            // 
            this.labelStuName.AutoSize = true;
            this.labelStuName.Location = new System.Drawing.Point(98, 61);
            this.labelStuName.Name = "labelStuName";
            this.labelStuName.Size = new System.Drawing.Size(70, 24);
            this.labelStuName.TabIndex = 0;
            this.labelStuName.Text = "姓名:";
            // 
            // labelStuId
            // 
            this.labelStuId.AutoSize = true;
            this.labelStuId.Location = new System.Drawing.Point(98, 119);
            this.labelStuId.Name = "labelStuId";
            this.labelStuId.Size = new System.Drawing.Size(82, 24);
            this.labelStuId.TabIndex = 1;
            this.labelStuId.Text = "学号：";
            // 
            // buttonAddStu
            // 
            this.buttonAddStu.Location = new System.Drawing.Point(233, 268);
            this.buttonAddStu.Name = "buttonAddStu";
            this.buttonAddStu.Size = new System.Drawing.Size(218, 68);
            this.buttonAddStu.TabIndex = 2;
            this.buttonAddStu.Text = "添加";
            this.buttonAddStu.UseVisualStyleBackColor = true;
            this.buttonAddStu.Click += new System.EventHandler(this.buttonAddStu_Click);
            // 
            // textBoxStuName
            // 
            this.textBoxStuName.Location = new System.Drawing.Point(202, 58);
            this.textBoxStuName.Name = "textBoxStuName";
            this.textBoxStuName.Size = new System.Drawing.Size(330, 35);
            this.textBoxStuName.TabIndex = 3;
            // 
            // textBoxStuId
            // 
            this.textBoxStuId.Location = new System.Drawing.Point(202, 116);
            this.textBoxStuId.Name = "textBoxStuId";
            this.textBoxStuId.Size = new System.Drawing.Size(330, 35);
            this.textBoxStuId.TabIndex = 4;
            // 
            // Form_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 402);
            this.Controls.Add(this.textBoxStuId);
            this.Controls.Add(this.textBoxStuName);
            this.Controls.Add(this.buttonAddStu);
            this.Controls.Add(this.labelStuId);
            this.Controls.Add(this.labelStuName);
            this.Name = "Form_add";
            this.Text = "增加数据";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStuName;
        private System.Windows.Forms.Label labelStuId;
        private System.Windows.Forms.Button buttonAddStu;
        private System.Windows.Forms.TextBox textBoxStuName;
        private System.Windows.Forms.TextBox textBoxStuId;
    }
}