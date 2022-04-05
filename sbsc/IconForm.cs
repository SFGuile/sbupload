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
    public partial class IconForm : Form
    {

    
        public IconForm()
        {
            InitializeComponent();
        }

        private void IconForm_Load(object sender, EventArgs e)
        {
            listview.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void listview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listview.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;


            if (item == null)
            {
                this.listview.SelectedItems.Clear();
                MessageBox.Show("没有任何选择");
            }
            else if (item.Text == "药店医保个账结算")
            {
                ShowinvForm();
            }
            else if (item.Text == "取消药店医保个账结算")
            {
                ShowrefForm();
            }
            else if (item.Text == "药店进出库信息传送")
            {
                ShowupdForm();
            }
            else if (item.Text == "药店进出库信息删除")
            {
                ShowupdrecForm();
            }
            else if (item.Text == "系统设置")
            {
                ShowopForm();
            }
            else if (item.Text == "药店口令修改")
            {
                ShowchangepassForm();
            }
            else if (item.Text == "药店经办人注册")
            {
                ShowregForm(); 
               
            }
            else if (item.Text== "日志")
            {
                ShowlogForm();
            }
            else if (item.Text == "退出")
            {
                DialogResult result1 = MessageBox.Show("确定要退出吗？", "提示", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                    Application.Exit();
            }
        }

        private void ShowchangepassForm()
        {
            if (checkexists("Changepass") != 0)
            {
                Changepass changepassform = new Changepass();
                changepassform.MdiParent = this.MdiParent;
                changepassform.Show();
                changepassform.BringToFront();
            }
        }

        private void ShowinvForm()
        {
            if (checkexists("IndividalChargeForm") != 0)
            {
                IndividalChargeForm invform = new IndividalChargeForm();
                invform.MdiParent = this.MdiParent;
                invform.Show();
                invform.BringToFront();
            }
        }

        private void ShowrefForm()
        {

            if (checkexists("RefundForm") != 0)
            {
                RefundForm refundform = new RefundForm();
                refundform.MdiParent = this.MdiParent;
                refundform.Show();
                refundform.BringToFront();
            }
        }

        private void ShowupdForm()
        {
            if (checkexists("UploadDepForm") != 0)
            {
                UploadDepForm updepform = new UploadDepForm();
                updepform.MdiParent = this.MdiParent;
                updepform.Show();
                updepform.BringToFront();
            }
        }

        private void ShowupdrecForm()
        {

            if (checkexists("UploadRecordForm") != 0)
            {
                UploadRecordForm uprecform = new UploadRecordForm();
                uprecform.MdiParent = this.MdiParent;
                uprecform.Show();
                uprecform.BringToFront();
            }
        }
        private void ShowopForm()
        {
            if (checkexists("OptionForm") != 0)
            {
                OptionForm opform = new OptionForm();
                opform.MdiParent = this.MdiParent;
                opform.Show();
                opform.BringToFront();
            }
        }

        private void ShowregForm()
        {
            if (checkexists("RegistForm") != 0)
            {
                RegistForm regform = new RegistForm();
                regform.MdiParent = this.MdiParent;
                regform.Show();
                regform.BringToFront();
            }
        }

        private void ShowlogForm()
        {
            if (checkexists("LogForm") != 0)
            {
                LogForm logform = new LogForm();
                logform.MdiParent = this.MdiParent;
                logform.Show();
                logform.BringToFront();

            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
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

      

     


    }
}
