namespace sbsc
{
    partial class InputListnoForm
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
            this.txtlistno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btncomfirm = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtlistno
            // 
            this.txtlistno.Location = new System.Drawing.Point(89, 91);
            this.txtlistno.Name = "txtlistno";
            this.txtlistno.Size = new System.Drawing.Size(224, 21);
            this.txtlistno.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(86, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入业务流水号（销售单号）";
            // 
            // btncomfirm
            // 
            this.btncomfirm.Location = new System.Drawing.Point(107, 146);
            this.btncomfirm.Name = "btncomfirm";
            this.btncomfirm.Size = new System.Drawing.Size(75, 23);
            this.btncomfirm.TabIndex = 3;
            this.btncomfirm.Text = "确定";
            this.btncomfirm.UseVisualStyleBackColor = true;
            this.btncomfirm.Click += new System.EventHandler(this.btncomfirm_Click);
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(226, 146);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(75, 23);
            this.btnexit.TabIndex = 4;
            this.btnexit.Text = "退出";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // InputListnoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 226);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btncomfirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtlistno);
            this.Name = "InputListnoForm";
            this.Text = "业务流水号";
            this.Load += new System.EventHandler(this.InputListnoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtlistno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btncomfirm;
        private System.Windows.Forms.Button btnexit;
    }
}