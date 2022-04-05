namespace sbsc
{
    partial class Changepass
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
            this.btncomfirm = new System.Windows.Forms.Button();
            this.labyybh = new System.Windows.Forms.Label();
            this.txtyybh = new System.Windows.Forms.TextBox();
            this.oldpasslab = new System.Windows.Forms.Label();
            this.txtoldpass = new System.Windows.Forms.TextBox();
            this.newpasslab = new System.Windows.Forms.Label();
            this.txtnewpass = new System.Windows.Forms.TextBox();
            this.newcomifrmpasslab = new System.Windows.Forms.Label();
            this.txtnewpasscomfirm = new System.Windows.Forms.TextBox();
            this.btnclearn = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.labuserid = new System.Windows.Forms.Label();
            this.txtuserid = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btncomfirm
            // 
            this.btncomfirm.Location = new System.Drawing.Point(43, 269);
            this.btncomfirm.Name = "btncomfirm";
            this.btncomfirm.Size = new System.Drawing.Size(75, 23);
            this.btncomfirm.TabIndex = 10;
            this.btncomfirm.Text = "提交";
            this.btncomfirm.UseVisualStyleBackColor = true;
            this.btncomfirm.Click += new System.EventHandler(this.btncomfirm_Click);
            // 
            // labyybh
            // 
            this.labyybh.AutoSize = true;
            this.labyybh.Location = new System.Drawing.Point(29, 49);
            this.labyybh.Name = "labyybh";
            this.labyybh.Size = new System.Drawing.Size(89, 12);
            this.labyybh.TabIndex = 0;
            this.labyybh.Text = "医药机构编号：";
            // 
            // txtyybh
            // 
            this.txtyybh.Location = new System.Drawing.Point(134, 46);
            this.txtyybh.Name = "txtyybh";
            this.txtyybh.ReadOnly = true;
            this.txtyybh.Size = new System.Drawing.Size(169, 21);
            this.txtyybh.TabIndex = 1;
            // 
            // oldpasslab
            // 
            this.oldpasslab.AutoSize = true;
            this.oldpasslab.Location = new System.Drawing.Point(65, 135);
            this.oldpasslab.Name = "oldpasslab";
            this.oldpasslab.Size = new System.Drawing.Size(53, 12);
            this.oldpasslab.TabIndex = 4;
            this.oldpasslab.Text = "旧密码：";
            // 
            // txtoldpass
            // 
            this.txtoldpass.Location = new System.Drawing.Point(132, 132);
            this.txtoldpass.Name = "txtoldpass";
            this.txtoldpass.PasswordChar = '*';
            this.txtoldpass.Size = new System.Drawing.Size(169, 21);
            this.txtoldpass.TabIndex = 5;
            // 
            // newpasslab
            // 
            this.newpasslab.AutoSize = true;
            this.newpasslab.Location = new System.Drawing.Point(65, 178);
            this.newpasslab.Name = "newpasslab";
            this.newpasslab.Size = new System.Drawing.Size(53, 12);
            this.newpasslab.TabIndex = 6;
            this.newpasslab.Text = "新密码：";
            // 
            // txtnewpass
            // 
            this.txtnewpass.Location = new System.Drawing.Point(132, 175);
            this.txtnewpass.Name = "txtnewpass";
            this.txtnewpass.PasswordChar = '*';
            this.txtnewpass.Size = new System.Drawing.Size(169, 21);
            this.txtnewpass.TabIndex = 7;
            // 
            // newcomifrmpasslab
            // 
            this.newcomifrmpasslab.AutoSize = true;
            this.newcomifrmpasslab.Location = new System.Drawing.Point(41, 221);
            this.newcomifrmpasslab.Name = "newcomifrmpasslab";
            this.newcomifrmpasslab.Size = new System.Drawing.Size(77, 12);
            this.newcomifrmpasslab.TabIndex = 8;
            this.newcomifrmpasslab.Text = "新密码确认：";
            // 
            // txtnewpasscomfirm
            // 
            this.txtnewpasscomfirm.Location = new System.Drawing.Point(132, 218);
            this.txtnewpasscomfirm.Name = "txtnewpasscomfirm";
            this.txtnewpasscomfirm.PasswordChar = '*';
            this.txtnewpasscomfirm.Size = new System.Drawing.Size(169, 21);
            this.txtnewpasscomfirm.TabIndex = 9;
            // 
            // btnclearn
            // 
            this.btnclearn.Location = new System.Drawing.Point(134, 269);
            this.btnclearn.Name = "btnclearn";
            this.btnclearn.Size = new System.Drawing.Size(75, 23);
            this.btnclearn.TabIndex = 11;
            this.btnclearn.Text = "清空";
            this.btnclearn.UseVisualStyleBackColor = true;
            this.btnclearn.Click += new System.EventHandler(this.btnclearn_Click);
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(226, 269);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(75, 23);
            this.btnexit.TabIndex = 12;
            this.btnexit.Text = "退出";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // labuserid
            // 
            this.labuserid.AutoSize = true;
            this.labuserid.Location = new System.Drawing.Point(53, 92);
            this.labuserid.Name = "labuserid";
            this.labuserid.Size = new System.Drawing.Size(65, 12);
            this.labuserid.TabIndex = 2;
            this.labuserid.Text = "社保编码：";
            // 
            // txtuserid
            // 
            this.txtuserid.Location = new System.Drawing.Point(134, 89);
            this.txtuserid.Name = "txtuserid";
            this.txtuserid.ReadOnly = true;
            this.txtuserid.Size = new System.Drawing.Size(167, 21);
            this.txtuserid.TabIndex = 3;
            // 
            // Changepass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 363);
            this.Controls.Add(this.txtuserid);
            this.Controls.Add(this.labuserid);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnclearn);
            this.Controls.Add(this.txtnewpasscomfirm);
            this.Controls.Add(this.newcomifrmpasslab);
            this.Controls.Add(this.txtnewpass);
            this.Controls.Add(this.newpasslab);
            this.Controls.Add(this.txtoldpass);
            this.Controls.Add(this.oldpasslab);
            this.Controls.Add(this.txtyybh);
            this.Controls.Add(this.labyybh);
            this.Controls.Add(this.btncomfirm);
            this.Name = "Changepass";
            this.Load += new System.EventHandler(this.Changepass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncomfirm;
        private System.Windows.Forms.Label labyybh;
        private System.Windows.Forms.TextBox txtyybh;
        private System.Windows.Forms.Label oldpasslab;
        private System.Windows.Forms.TextBox txtoldpass;
        private System.Windows.Forms.Label newpasslab;
        private System.Windows.Forms.TextBox txtnewpass;
        private System.Windows.Forms.Label newcomifrmpasslab;
        private System.Windows.Forms.TextBox txtnewpasscomfirm;
        private System.Windows.Forms.Button btnclearn;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Label labuserid;
        private System.Windows.Forms.TextBox txtuserid;
    }
}