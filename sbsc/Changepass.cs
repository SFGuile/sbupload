using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sbsc.changepass;
using Newtonsoft.Json;

namespace sbsc
{
    public partial class Changepass : Form
    {
        public Changepass()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Changepass_Load(object sender, EventArgs e)
        {
            txtyybh.MaxLength = 10;
            txtuserid.MaxLength = 50;
            txtoldpass.MaxLength = 32;
            txtnewpass.MaxLength = 32;
            txtnewpasscomfirm.MaxLength = 32;
            txtyybh.Text  = globalvariable.YYBH;
            txtuserid.Text  = globalvariable.USERID;
        }

        private void btnclearn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认要清空吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                txtyybh.Text = "";
                txtuserid.Text = "";
                txtoldpass.Text = "";
                txtnewpass.Text = "";
                txtnewpasscomfirm.Text = "";
            }

        }

        private void btncomfirm_Click(object sender, EventArgs e)
        {
             DialogResult result = MessageBox.Show("确认要提交吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
             if (result == DialogResult.OK)
             {
                 txtyybh.Text = txtyybh.Text.Trim();
                 txtuserid.Text = txtuserid.Text.Trim();
                 txtoldpass.Text = txtoldpass.Text.Trim(); ;
                 txtnewpass.Text = txtnewpass.Text.Trim();
                 txtnewpasscomfirm.Text = txtnewpasscomfirm.Text.Trim();

                 if (string.IsNullOrEmpty(txtnewpass.Text))
                 {
                     MessageBox.Show("出错：新密码不能为空");
                     return;
                 }
                 else if (string.IsNullOrEmpty(txtnewpasscomfirm.Text))
                 {
                     MessageBox.Show("出错：新密码确认不能为空");
                     return;
                 }
                 else if (txtnewpass.Text != txtnewpasscomfirm.Text)
                 {
                     MessageBox.Show("出错：新密码和新密码确认不一致");
                     return;
                 }


                 HashParams hp = new HashParams
                 {
                     JBR = globalvariable.JBR,
                     FN = "2",
                     SESSIONID = globalvariable.SESSIONID,
                     YYBH = txtyybh.Text,
                     USERID = txtuserid.Text,
                     OLDPWD = txtoldpass.Text,
                     NEWPWD = txtnewpass.Text,
                     JBRQ = String.Format("{0:yyyyMMddHHmmss}", DateTime.Now),
                     CLIENTTYPE=globalvariable.CLIENTTYPE

                 };
                 DataPackage dp = new DataPackage();
                 RootObject ro = new RootObject
                 {
                     HashParams = hp,
                     DataPackage = dp
                 };
                 string expcemsg="";
                 string json ="";
                 try
                 {
                     json = JsonConvert.SerializeObject(ro);
                 }
                 catch(Exception ex)
                 {
                     globalvariable glv = new globalvariable();
                     glv.LogWrite("更改密码 " + ex.ToString());
                 }
                 globalvariable gv=new globalvariable();
                 string ywlsh="";
                 int myresult = gv.postoweb(json, globalvariable.webfunc,ref expcemsg,ref ywlsh);
                 if (myresult == 0)
                 {
                     MessageBox.Show("密码已改，程序需要重新登陆，记得在社保登陆密码密码栏改成你改更后的密码");
                     Application.Restart();
                 }
                 else
                 {
                     MessageBox.Show("程序出错：" + expcemsg);
                     globalvariable glv = new globalvariable();
                     glv.LogWrite("更改密码 " + expcemsg.ToString());
                 }


             }
        }
    }
}
