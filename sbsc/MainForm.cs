using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sbsc
{
    public partial class MainForm : Form
    {
        string thedbname;
        string themdname;
        public MainForm(string usedb,string mdname)
        {
            InitializeComponent();
            thedbname = usedb;
            themdname = mdname;
            globalvariable.thename = mdname;
            this.Text = "所在环境：" + thedbname + "，门店名：" + themdname.Trim() + "，登陆社保编号：" + globalvariable.YYBH + "，登陆用户名：" + globalvariable.curclino;
        }
        
        

        
        private void individalpayMenuItem_Click(object sender, EventArgs e)
        {
            ShowinvForm();
        }

        private void refundMenuItem_Click(object sender, EventArgs e)
        {
            ShowrefForm();
        }

        private void depinvmonthMenuItem_Click(object sender, EventArgs e)
        {
            ShowupdForm();
        }

        private void depinvmonthdeleteMenuItem_Click(object sender, EventArgs e)
        {
            ShowupdrecForm();
        }

        private void optionMenuItem_Click(object sender, EventArgs e)
        {
            ShowopForm();
        }

        private void changepasswordMenuItem_Click(object sender, EventArgs e)
        {
            ShowchangepassForm();
        }

        private void registedMenuItem_Click(object sender, EventArgs e)
        {
            ShowregForm();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("确定要退出吗？","提示",MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
                Application.Exit();
        }

        private void logMenuItem_Click(object sender, EventArgs e)
        {
            ShowlogForm();
        }

     

        private void ShowchangepassForm()
        {
            if (checkexists("Changepass") != 0)
            {
                Changepass changepassform = new Changepass();
                changepassform.MdiParent = this;
                changepassform.Show();
                changepassform.BringToFront();
            }
        }

        private void ShowinvForm()
        {
            if (checkexists("IndividalChargeForm") != 0)
            {
                IndividalChargeForm invform = new IndividalChargeForm();
                invform.MdiParent = this;
                invform.Show();
                invform.BringToFront();
            }
        }

        private void ShowrefForm()
        {

            if (checkexists("RefundForm") != 0)
            {
                RefundForm refundform = new RefundForm();
                refundform.MdiParent = this;
                refundform.Show();
                refundform.BringToFront();
            }
        }

        private void ShowupdForm()
        {
            if (checkexists("UploadDepForm") != 0)
            {
                UploadDepForm updepform = new UploadDepForm();
                updepform.MdiParent = this;
                updepform.Show();
                updepform.BringToFront();
            }
        }

        private void ShowupdrecForm()
        {

            if (checkexists("UploadRecordForm") != 0)
            {
                UploadRecordForm uprecform = new UploadRecordForm();
                uprecform.MdiParent = this;
                uprecform.Show();
                uprecform.BringToFront();
            }
        }
        private void ShowopForm()
        {
            if (checkexists("OptionForm") != 0)
            {
                OptionForm opform = new OptionForm();
                opform.MdiParent = this;
                opform.Show();
                opform.BringToFront();
            }
        }

        private void ShowregForm()
        {
            if (checkexists("RegistForm") != 0)
            {
                RegistForm regform = new RegistForm();
                regform.MdiParent = this;
                regform.Show();
                regform.BringToFront();
            }
        }

        private void ShowlogForm()
        {
            if (checkexists("LogForm") != 0)
            {
                LogForm logform = new LogForm();
                logform.MdiParent = this;
                logform.Show();
                logform.BringToFront();

            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            IconForm iform = new IconForm();
            iform.MdiParent = this;
            iform.Show();
            iform.WindowState = FormWindowState.Maximized;
        }


        private int checkexists(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form myfrm in fc)
            {
                if (myfrm.Name == name)
                {
                    myfrm.BringToFront();
                    return 0;
                }
            }

            return -1;
        }


        public void AddMenuItem(string text, string action)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = text;
            item.Click += new EventHandler(winToolStripMenuItem_Click);
            item.Tag = action;
            winToolStripMenuItem.DropDownItems.Insert(winToolStripMenuItem.DropDownItems.Count, item);
        }

        private void winToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            string args = menuItem.Tag.ToString();

            if (!string.IsNullOrEmpty(args))
            {
                if (args == "ShowinvForm")
                {
                    ShowinvForm();
                }
                else if (args == "ShowrefForm")
                {
                    ShowrefForm();
                }
                else if (args == "ShowupdForm")
                {
                    ShowupdForm();
                }
                else if (args == "ShowupdrecForm")
                {
                    ShowupdrecForm();
                }
                else if (args == "ShowopForm")
                {
                    ShowopForm();
                }
                else if (args == "ShowchangepassForm")
                {
                    ShowchangepassForm();
                }
                else if (args == "ShowregForm")
                {
                    ShowregForm();
                }
                else if (args == "ShowlogForm")
                {
                    ShowlogForm();
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
              result = MessageBox.Show("确定退出吗？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
             if (result == DialogResult.OK)
             {
                 Application.ExitThread();
             }
             else
             {
                 e.Cancel = true;
             }
        }

       

        
       
    }

}
