using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sbsc.RegistModel;
using Newtonsoft.Json;

namespace sbsc
{
    public partial class RegistForm : Form
    {
        public RegistForm()
        {
            InitializeComponent();
        }

        private void RegistForm_Load(object sender, EventArgs e)
        {
            txtyybh.MaxLength = 10;
            txtjbr.MaxLength = 20;
            txtxm.MaxLength = 50;
            txtgmsfhm.MaxLength = 20;
            txtssks.MaxLength = 50;
            combjbrlx.SelectedIndex  = 0;
            comboxBGLX.SelectedIndex = 0;
            txtclienttype.Text= "DDYD";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
             DialogResult result = MessageBox.Show("确认要清空吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
             if (result == DialogResult.OK)
             {
                 txtyybh.Text = "";
                 txtjbr.Text = "";
                 txtxm.Text = "";
                 txtgmsfhm.Text = "";
                 txtssks.Text = "";
                 combjbrlx.SelectedIndex = 0;
                 comboxBGLX.SelectedIndex = 0;
             }
        }

        private void btnComfirm_Click(object sender, EventArgs e)
        {
             DialogResult result = MessageBox.Show("确认要提交吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
             if (result == DialogResult.OK)
             {
                 txtyybh.Text = txtyybh.Text.Trim();
                 txtjbr.Text = txtjbr.Text.Trim();
                 txtxm.Text = txtxm.Text.Trim();
                 txtgmsfhm.Text = txtgmsfhm.Text.Trim();
                 txtssks.Text = txtssks.Text.Trim();

                 string strbglx;
                 if (comboxBGLX.SelectedItem.ToString() == "1、新增")
                     strbglx = "1";
                 else
                     strbglx = "2";

                 string jbrlx;
                 if (combjbrlx.SelectedItem.ToString() == "1：普通经办人")
                     jbrlx = "1";
                 else if (combjbrlx.SelectedItem.ToString() == "2：收费员")
                     jbrlx = "2";
                 else
                     jbrlx = "3";

                 HashParams hp = new HashParams
                 {
                     YYBH = txtyybh.Text,
                     _JBR = txtjbr.Text,
                     JBRLX = jbrlx,
                     XM = txtxm.Text,
                     GMSFHM = txtgmsfhm.Text,
                     SSKS = txtssks.Text,
                     BGLX = strbglx,
                     JBR = globalvariable.JBR,
                     FN = "3",
                     SESSIONID = globalvariable.SESSIONID,
                     JBRQ = String.Format("{0:yyyyMMddHHmmss}", DateTime.Now),
                     CLIENTTYPE = txtclienttype.Text.Trim()

                 };

                 DataPackage dp = new DataPackage();
                 RootObject ro = new RootObject
                 {
                     HashParams = hp,
                     DataPackage = dp
                 };
                 string expcemsg = "";
                 string YWLSH = "";
                 string json = JsonConvert.SerializeObject(ro);
                 globalvariable gv = new globalvariable();
                 int myresult = gv.postoweb(json, globalvariable.webfunc, ref expcemsg, ref YWLSH);
                 if (myresult == 0)
                 {
                     MessageBox.Show("已经提交");
                     this.Close();
                 }
                 else
                 {
                     MessageBox.Show("程序出错：" + expcemsg);
                 }



             }
        }
    }
}
