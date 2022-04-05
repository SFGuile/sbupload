using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Data.SqlClient;
using sbsc.login;
using System.Net;
using Newtonsoft.Json;


namespace sbsc
{
    public partial class LoginForm : Form
    {
        string curdir;
        string curver = "1.0.0.67";
        int thecount = 0;
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        extern static bool IsWow64Process(IntPtr hProcess, [MarshalAs(UnmanagedType.Bool)] out bool isWow64);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern static IntPtr GetCurrentProcess();
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        extern static IntPtr GetModuleHandle(string moduleName);
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        extern static IntPtr GetProcAddress(IntPtr hModule, string methodName);

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btncomfirm_Click(object sender, EventArgs e)
        {
            txtuser.Text = txtuser.Text.Trim();
            txtpass.Text = txtpass.Text.Trim();
            txtYYBH.Text = txtYYBH.Text.Trim();
            txtsbuser.Text = txtsbuser.Text.Trim();
            txtsbpass.Text = txtsbpass.Text.Trim();
            txtjbr.Text = txtjbr.Text.Trim();
            txtJBRLX.Text = txtJBRLX.Text.Trim();
            txtclienttype.Text = txtclienttype.Text.Trim();
            
            string username;
            string passwd1;


             //20150714
            string mdname="";
            string usedb;

        

            
            if (comboxedit.SelectedItem.ToString() == "东莞测试库")
            {
                globalvariable.weblogin = globalvariable.webaddresslogintest;
                globalvariable.webfunc = globalvariable.webaddressfunctest;
                usedb="！！！注意，这是测试库！！！";
            }
            else
            {
                globalvariable.weblogin = globalvariable.webaddresslogin;
                globalvariable.webfunc = globalvariable.webaddressfunc;
                usedb="正式库";
            }

            //

            username = txtuser.Text.Trim();
            passwd1 = txtpass.Text.Trim();
            string connstring = @"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;"; ;
            string apppath = AppDomain.CurrentDomain.BaseDirectory;
            globalvariable.theappath = apppath;
            bool havecert = false;
                try
                {
                    
                    using (lsDataClassesDataContext db = new lsDataClassesDataContext(connstring))
                    {
                        db.CommandTimeout = 300;
                        var query = from w in db.word
                                    where (w.user_code == username.ToLower() && w.user_pass == passwd1)
                                    select w;

                        var cliname=(from co in db.company 
                                     select co.com_name ).FirstOrDefault();

                        mdname=cliname.ToString();

                        if (query.Count() != 0)
                        {
                            havecert = true;

                            if (File.Exists(apppath + "\\myexe.sql"))
                            {
                                FileInfo file = new FileInfo(apppath + "\\myexe.sql");
                                string script = file.OpenText().ReadToEnd();
                                string connstr = @"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;"; 
                                SqlConnection conn = new SqlConnection(connstr);
                                globalvariable glv = new globalvariable();
                                glv.ExecuteBatchNonQuery(script, conn);


                            }
                            else
                            {
                                MessageBox.Show("程序终止，请将myexe.sql复制到程序文件夹下面");
                                return;
                            }

                        }
                        else
                        {
                            MessageBox.Show("登陆密码错误");
                            thecount++;
                            if (thecount == 5)
                            {
                                MessageBox.Show("密码错误次数已经5次，程序退出");
                                Application.Exit();
                            }
                            return;
                        }
                        string retailver = (from com in db.company
                                            select com.ver).FirstOrDefault();
                        if (!string.IsNullOrEmpty(retailver))
                        {
                            if (retailver.Length != 6)
                            {
                                MessageBox.Show("零售版本号有误，程序终止");
                                return;
                            }
                            else
                            {
                                string compstr = "201210";
                                for (int i = 0; i < 3; i++)
                                {
                                    if (Convert.ToInt16(retailver.Substring(i, 2)) < Convert.ToInt16(compstr.Substring(i, 2)))
                                    {
                                        MessageBox.Show("零售版是" + compstr + "以前的，请更新后再试");
                                        return;
                                    }
                                    else if (Convert.ToInt16(retailver.Substring(i, 2)) > Convert.ToInt16(compstr.Substring(i, 2)))
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                        string sbver = (from d in db.company
                                        select d.sb_ver).FirstOrDefault();
                        if (!string.IsNullOrEmpty(sbver))
                        {
                            Version vcurr = new Version(curver.Trim());
                          
                                Version vorginal = new Version(sbver);
                                if (vcurr.CompareTo(vorginal) < 0)
                                {
                                    MessageBox.Show("不能少于之前版本，程序终止");
                                    return;
                                }
                                else if (vcurr.CompareTo(vorginal) > 0)
                                {
                                    company co = (from c in db.company select c).FirstOrDefault();
                                    co.sb_ver = sbver;
                                    db.SubmitChanges();
                                }
                            

                            
                        }
                        else
                        {
                            company co = (from c in db.company select c).FirstOrDefault();
                            co.sb_ver = sbver;
                            db.SubmitChanges();
                        }
                      
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误发生：" + ex.ToString());
                    globalvariable glv = new globalvariable();
                    glv.LogWrite("登陆" + ex.ToString());
                }
                    if (havecert == true && loginnet()==0)
                    {
                        globalvariable.curclino = txtuser.Text.Trim();
                        //20150714
                       this.Hide();



                       MainForm mf = new MainForm(usedb, mdname);
                        mf.StartPosition = FormStartPosition.CenterParent;
                        mf.ShowDialog();
                        this.Close();
 
                    }

               
            
        }

        public int loginnet()
        {
            globalvariable.YYBH = txtYYBH.Text.Trim();
            globalvariable.USERID = txtsbuser.Text.Trim();
            globalvariable.PWD = txtsbpass.Text.Trim();
            globalvariable.JBR = txtjbr.Text.Trim();
            globalvariable.JBRLX = txtJBRLX.Text.Trim();
            globalvariable.CLIENTTYPE = txtclienttype.Text.Trim();

            HashParams hp = new HashParams
            {
                YYBH = globalvariable.YYBH,
                USERID = globalvariable.USERID,
                PASSWORD = globalvariable.PWD,
                JBR = globalvariable.JBR,
                JBRLX = globalvariable.JBRLX,
                CLIENTTYPE=globalvariable.CLIENTTYPE ,
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
                if(weblogin.Url != globalvariable.weblogin)
                    weblogin.Url = globalvariable.weblogin;
                //
                    string json = JsonConvert.SerializeObject(ro);


                    string result = weblogin.login(json);

                    sbsc.retrunModel.returnvalue deserializedreturn = JsonConvert.DeserializeObject<sbsc.retrunModel.returnvalue>(result);
                        if (deserializedreturn.HashParams.FHZ.Trim() != "1")
                        {
                            MessageBox.Show("登入调用出错:" + deserializedreturn.HashParams.MSG);
                            return Convert.ToInt32(deserializedreturn.HashParams.FHZ);
                        }
                        else
                        {
                            globalvariable.SESSIONID = deserializedreturn.HashParams.SESSIONID;
                            if (cbrememberme.Checked == true)
                            {
                                try
                                {
                                    string connstring = @"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;";
                                    using (lsDataClassesDataContext db = new lsDataClassesDataContext(connstring))
                                    {
                                        db.CommandTimeout = 300;
                                        var query = (from c in db.company
                                                     select c).FirstOrDefault();


                                        query.sb_yybh = globalvariable.YYBH;
                                        query.sb_jbr = globalvariable.JBR;
                                        query.sb_id = globalvariable.USERID;
                                        query.sb_pwd = globalvariable.PWD;
                                        query.sb_jbrlx = globalvariable.JBRLX;
                                        query.sb_clienttype = globalvariable.CLIENTTYPE;
                                        query.sb_rememberme = true;
                                        query.sb_ver = curver;
                                        db.SubmitChanges();

                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("保存时出错：" + ex.ToString());
                                    return -2;
                                }
                            }
                            else
                            {
                                try
                                {
                                    string connstring = @"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;"; 
                                    using (lsDataClassesDataContext db = new lsDataClassesDataContext(connstring))
                                    {
                                        db.CommandTimeout = 300;
                                        var query = (from c in db.company
                                                     select c).FirstOrDefault();
                                        query.sb_rememberme = false;
                                        db.SubmitChanges();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("保存时出错：" + ex.ToString());
                                    globalvariable glv = new globalvariable();
                                    glv.LogWrite("登陆 " + ex.ToString());
                                    return -2;
                                }

                            }
                            return 0;
                        }
                    
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("出错：" + ex.ToString());
                globalvariable glv = new globalvariable();
                glv.LogWrite("登陆 " + ex.ToString());
                return -1;
            }


           
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            curdir = System.Environment.CurrentDirectory;
            Boolean myfileexist = File.Exists(curdir + "\\hm.ini");
            if (myfileexist == false)
            {
                MessageBox.Show("找不到配置文件，程序将会退出");
                Application.Exit();
            }

            txtYYBH.MaxLength = 10;
            txtsbuser.MaxLength = 50;
            txtsbpass.MaxLength = 20;
            txtjbr.MaxLength = 20;
            txtJBRLX.MaxLength = 6;
            txtclienttype.MaxLength = 20;
            //20150713
            comboxedit.EditValue  = "东莞正式库";
            //
            System.Text.StringBuilder myserverstring = new System.Text.StringBuilder(255);
            System.Text.StringBuilder mydbstring = new System.Text.StringBuilder(255);
            System.Text.StringBuilder mydbpasstring = new System.Text.StringBuilder(255);

            GetPrivateProfileString("Connect", "ServerName", "", myserverstring, 255, curdir + "\\hm.ini");
            GetPrivateProfileString("Connect", "Database", "", mydbstring, 255, curdir + "\\hm.ini");
            GetPrivateProfileString("Connect", "LogPass", "", mydbpasstring, 255, curdir + "\\hm.ini");

            globalvariable.webaddresslogintest = "http://192.168.102.19:8001/web/services/webServiceLogin?wsdl";
            globalvariable.webaddressfunctest = "http://192.168.102.19:8001/web/services/WebserviceFacade?wsdl";
            globalvariable.webaddresslogin = "http://192.168.102.188/web/services/webServiceLogin?wsdl";
            globalvariable.webaddressfunc = "http://192.168.102.188/web/services/WebserviceFacade?wsdl";


            globalvariable.mylocate = myserverstring.ToString();
            globalvariable.mydbname = mydbstring.ToString();
            globalvariable.mydbpass = mydbpasstring.ToString();
            globalvariable.currdict = curdir;
            labversion.Text = "版本号："+curver;

            
            try
            {
                string connstring = @"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;";
                using (lsDataClassesDataContext db = new lsDataClassesDataContext(connstring))
                {
                    db.CommandTimeout = 300;
                    var query = (from c in db.company
                                 select new { c.sb_yybh, c.sb_id, c.sb_pwd, c.sb_jbr,c.sb_jbrlx, c.sb_clienttype, c.sb_rememberme }).FirstOrDefault();
                    if (query.sb_rememberme==true)
                    {
                        txtYYBH.Text  = query.sb_yybh;
                        txtsbuser.Text = query.sb_id;
                        txtsbpass.Text = query.sb_pwd;
                        txtjbr.Text = query.sb_jbr;
                        txtJBRLX.Text = query.sb_jbrlx;
                        txtclienttype.Text = query.sb_clienttype;
                        cbrememberme.Checked = true;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误："+ex.ToString());
                globalvariable glv = new globalvariable();
                glv.LogWrite("登陆 " + ex.ToString());
            }
        }

        private void comboxedit_DrawItem(object sender, DevExpress.XtraEditors.ListBoxDrawItemEventArgs e)
        {
            switch (e.Item.ToString())
            {
                case "东莞测试库":
                    e.Appearance.ForeColor = Color.Red;
                    break;
                default:
                    e.Appearance.ForeColor = Color.Black;
                    break;
            }
        }


      
    }
}
