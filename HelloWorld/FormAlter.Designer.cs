namespace HelloWorld
{
    partial class FormAlter
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
            this.buttonAlter = new System.Windows.Forms.Button();
            this.labelStuName = new System.Windows.Forms.Label();
            this.labelStuId = new System.Windows.Forms.Label();
            this.textBoxStuName = new System.Windows.Forms.TextBox();
            this.textBoxStuId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonAlter
            // 
            this.buttonAlter.Location = new System.Drawing.Point(322, 333);
            this.buttonAlter.Name = "buttonAlter";
            this.buttonAlter.Size = new System.Drawing.Size(156, 61);
            this.buttonAlter.TabIndex = 0;
            this.buttonAlter.Text = "修改";
            this.buttonAlter.UseVisualStyleBackColor = true;
            this.buttonAlter.Click += new System.EventHandler(this.buttonAlter_Click);
            // 
            // labelStuName
            // 
            this.labelStuName.AutoSize = true;
            this.labelStuName.Location = new System.Drawing.Point(88, 73);
            this.labelStuName.Name = "labelStuName";
            this.labelStuName.Size = new System.Drawing.Size(70, 24);
            this.labelStuName.TabIndex = 1;
            this.labelStuName.Text = "姓名:";
            // 
            // labelStuId
            // 
            this.labelStuId.AutoSize = true;
            this.labelStuId.Location = new System.Drawing.Point(88, 153);
            this.labelStuId.Name = "labelStuId";
            this.labelStuId.Size = new System.Drawing.Size(70, 24);
            this.labelStuId.TabIndex = 2;
            this.labelStuId.Text = "学号:";
            // 
            // textBoxStuName
            // 
            this.textBoxStuName.Location = new System.Drawing.Point(238, 73);
            this.textBoxStuName.Name = "textBoxStuName";
            this.textBoxStuName.Size = new System.Drawing.Size(240, 35);
            this.textBoxStuName.TabIndex = 3;
            // 
            // textBoxStuId
            // 
            this.textBoxStuId.Location = new System.Drawing.Point(238, 153);
            this.textBoxStuId.Name = "textBoxStuId";
            this.textBoxStuId.Size = new System.Drawing.Size(240, 35);
            this.textBoxStuId.TabIndex = 4;
            // 
            // FormAlter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxStuId);
            this.Controls.Add(this.textBoxStuName);
            this.Controls.Add(this.labelStuId);
            this.Controls.Add(this.labelStuName);
            this.Controls.Add(this.buttonAlter);
            this.Name = "FormAlter";
            this.Text = "修改数据";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAlter;
        private System.Windows.Forms.Label labelStuName;
        private System.Windows.Forms.Label labelStuId;
        private System.Windows.Forms.TextBox textBoxStuName;
        private System.Windows.Forms.TextBox textBoxStuId;
    }
}