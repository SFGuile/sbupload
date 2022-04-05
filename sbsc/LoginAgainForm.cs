using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sbsc.login;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace sbsc
{
    public partial class LoginAgainForm : Form
    {
        public LoginAgainForm()
        {
            InitializeComponent();
        }

        private void LoginAgainForm_Load(object sender, EventArgs e)
        {
            txtjbr.MaxLength = 20;
            txtyybh.MaxLength = 10;
            txtuserid.MaxLength = 10;
            txtpass.MaxLength = 32;
            txtjbrlx.MaxLength = 6;
            txtclienttype.MaxLength = 20;
            txtyybh.Text =globalvariable.YYBH;
            txtjbr.Text = globalvariable.JBR;
            txtuserid.Text = globalvariable.USERID;
            txtpass.Text = globalvariable.PWD;
            txtjbrlx.Text = globalvariable.JBRLX;
            txtclienttype.Text = globalvariable.CLIENTTYPE;
        }

        public int loginnet()
        {
            txtyybh.Text = txtyybh.Text.Trim();
            txtjbr.Text = txtjbr.Text.Trim();
            txtuserid.Text = txtuserid.Text.Trim();
            txtpass.Text = txtpass.Text.Trim();
            txtjbrlx.Text = txtjbrlx.Text.Trim();
            txtclienttype.Text = txtclienttype.Text.Trim();

            globalvariable.YYBH = txtyybh.Text.Trim();
            globalvariable.USERID = txtuserid.Text.Trim();
            globalvariable.PWD = txtpass.Text.Trim();
            globalvariable.JBR = txtjbr.Text.Trim();
            globalvariable.JBRLX = txtjbrlx.Text.Trim();
            globalvariable.CLIENTTYPE = txtclienttype.Text.Trim();

            HashParams hp = new HashParams
            {
                YYBH = globalvariable.YYBH,
                USERID = globalvariable.USERID,
                PASSWORD = globalvariable.PWD,
                JBR = globalvariable.JBR,
                JBRLX = globalvariable.JBRLX,
                CLIENTTYPE = globalvariable.CLIENTTYPE,
                FUNCNO = "1"
            };
            DataPackage dp = new DataPackage();

            RootObject ro = new RootObject
            {
                HashParams = hp,
                DataPackage = dp
            };

            try
            {
                servicelogin.webServiceLogin weblogin = new sbsc.servicelogin.webServiceLogin();

                //20150714
                if (weblogin.Url != globalvariable.weblogin)
                    weblogin.Url = globalvariable.weblogin;
                //
               


                    string json = JsonConvert.SerializeObject(ro);

                     string result=weblogin.login(json);


                     sbsc.retrunModel.HashParams deserializedreturn = JsonConvert.DeserializeObject<sbsc.retrunModel.HashParams>(result);
                        if (deserializedreturn.FHZ.Trim() != "1")
                        {
                            MessageBox.Show("登入调用出错:" + deserializedreturn.MSG);
                            return Convert.ToInt32(deserializedreturn.FHZ);
                        }
                        else
                        {
                            globalvariable.SESSIONID = deserializedreturn.SESSIONID;
                            MessageBox.Show("已经成功登入");
                            return 0;
                        }
                    
               
            }
            catch(Exception ex)
            {
                globalvariable glv = new globalvariable();
                glv.LogWrite("超时登陆" + ex.ToString());
                return -1;
            }



        }

        private void btncomfirm_Click(object sender, EventArgs e)
        {
            if (loginnet() == 0)
            {
                this.Close();
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认要退出吗？", "提示", MessageBoxButtons.YesNo , MessageBoxIcon.Question);
            if (result==DialogResult.Yes)
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认要保存吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string connstring = @"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;";
                    using (lsDataClassesDataContext db = new lsDataClassesDataContext(connstring))
                    {
                        var query = (from c in db.company
                                     select  c).FirstOrDefault();


                        query.sb_yybh = globalvariable.YYBH;
                        query.sb_jbr = globalvariable.JBR;
                        query.sb_id = globalvariable.USERID;
                        query.sb_pwd = globalvariable.pwd;
                        query.sb_jbrlx = globalvariable.JBRLX;
                        query.sb_clienttype = globalvariable.CLIENTTYPE;
                        db.SubmitChanges();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存时错误发生：" + ex.ToString());
                    globalvariable glv = new globalvariable();
                    glv.LogWrite("超时登陆" + ex.ToString());
                }
            }
        }
    }
}
