namespace sbsc
{
    partial class MainForm
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.individalpayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refundMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depinvmonthMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depinvmonthdeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changepasswordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.winToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.winToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(824, 24);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.individalpayMenuItem,
            this.refundMenuItem,
            this.depinvmonthMenuItem,
            this.depinvmonthdeleteMenuItem,
            this.optionMenuItem,
            this.changepasswordMenuItem,
            this.registedMenuItem,
            this.logMenuItem,
            this.exitMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.文件ToolStripMenuItem.Text = "文件(&N)";
            // 
            // individalpayMenuItem
            // 
            this.individalpayMenuItem.Name = "individalpayMenuItem";
            this.individalpayMenuItem.Size = new System.Drawing.Size(196, 22);
            this.individalpayMenuItem.Text = "药店医保个账结算(&G)";
            this.individalpayMenuItem.Click += new System.EventHandler(this.individalpayMenuItem_Click);
            // 
            // refundMenuItem
            // 
            this.refundMenuItem.Name = "refundMenuItem";
            this.refundMenuItem.Size = new System.Drawing.Size(196, 22);
            this.refundMenuItem.Text = "取消个账结算(&Q)";
            this.refundMenuItem.Click += new System.EventHandler(this.refundMenuItem_Click);
            // 
            // depinvmonthMenuItem
            // 
            this.depinvmonthMenuItem.Name = "depinvmonthMenuItem";
            this.depinvmonthMenuItem.Size = new System.Drawing.Size(196, 22);
            this.depinvmonthMenuItem.Text = "药店进出库传送(&C)";
            this.depinvmonthMenuItem.Click += new System.EventHandler(this.depinvmonthMenuItem_Click);
            // 
            // depinvmonthdeleteMenuItem
            // 
            this.depinvmonthdeleteMenuItem.Name = "depinvmonthdeleteMenuItem";
            this.depinvmonthdeleteMenuItem.Size = new System.Drawing.Size(196, 22);
            this.depinvmonthdeleteMenuItem.Text = "药店进出库信息删除(&S)";
            this.depinvmonthdeleteMenuItem.Click += new System.EventHandler(this.depinvmonthdeleteMenuItem_Click);
            // 
            // optionMenuItem
            // 
            this.optionMenuItem.Name = "optionMenuItem";
            this.optionMenuItem.Size = new System.Drawing.Size(196, 22);
            this.optionMenuItem.Text = "系统设置((&O)";
            this.optionMenuItem.Click += new System.EventHandler(this.optionMenuItem_Click);
            // 
            // changepasswordMenuItem
            // 
            this.changepasswordMenuItem.Name = "changepasswordMenuItem";
            this.changepasswordMenuItem.Size = new System.Drawing.Size(196, 22);
            this.changepasswordMenuItem.Text = "药店口令修改(&P)";
            this.changepasswordMenuItem.Click += new System.EventHandler(this.changepasswordMenuItem_Click);
            // 
            // registedMenuItem
            // 
            this.registedMenuItem.Name = "registedMenuItem";
            this.registedMenuItem.Size = new System.Drawing.Size(196, 22);
            this.registedMenuItem.Text = "药店经办人注册((&R)";
            this.registedMenuItem.Visible = false;
            this.registedMenuItem.Click += new System.EventHandler(this.registedMenuItem_Click);
            // 
            // logMenuItem
            // 
            this.logMenuItem.Name = "logMenuItem";
            this.logMenuItem.Size = new System.Drawing.Size(196, 22);
            this.logMenuItem.Text = "日志(&N)";
            this.logMenuItem.Click += new System.EventHandler(this.logMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(196, 22);
            this.exitMenuItem.Text = "退出(&X)";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // winToolStripMenuItem
            // 
            this.winToolStripMenuItem.Name = "winToolStripMenuItem";
            this.winToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.winToolStripMenuItem.Text = "窗口(&W)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 445);
            this.Controls.Add(this.menu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "主窗体";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem individalpayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refundMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depinvmonthMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depinvmonthdeleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changepasswordMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registedMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logMenuItem;
        private System.Windows.Forms.ToolStripMenuItem winToolStripMenuItem;
    }
}