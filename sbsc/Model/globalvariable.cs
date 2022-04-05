using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Reflection;

namespace sbsc
{
    public class globalvariable
    {

        public class prodinerror
        {
            public string prodno;

            public string prodname;

            public string batchno;

            public string prodadd ;

            public string lastdepno;

            public decimal invnum;

            public decimal depnum ;

            public string description;

            public string thelevel;

            public bool addition;

            public string ghdw;

            public string cliname;
        }


        public static string webaddresslogin
        {
            get
            {
                return _webaddresslogin;
            }
            set
            {
                _webaddresslogin = value;
            }

        }

        public static string webaddressfunc
        {
            get
            {
                return _webaddressfunc;
            }
            set
            {
                _webaddressfunc = value;
            }

        }


        //20150713
        public static string webaddresslogintest
        {
            get
            {
                return _webaddresslogintest;
            }
            set
            {
                _webaddresslogintest = value;
            }

        }

        public static string webaddressfunctest
        {
            get
            {
                return _webaddressfunctest;
            }
            set
            {
                _webaddressfunctest = value;
            }

        }





        //
        

        public static string weblogin
        {
            get
            {
                return _weblogin;
            }
            set
            {
                _weblogin = value;
            }

        }

        public static string webfunc
        {
            get
            {
                return _webfunc;
            }
            set
            {
                _webfunc = value;
            }

        }


        public static string SESSIONID
        {
            get
            {
                return _sessionid;
            }
            set
            {
                _sessionid = value;
            }

        }

        public static string YYBH
        {
            get
            {
                return _YYBH;
            }
            set
            {
                _YYBH = value;
            }

        }

        public static string theappath
        {
            get
            {
                return _theappath;
            }
            set
            {
                _theappath = value;
            }

        }


        public static string USERID
        {
            get
            {
                return _USERID;
            }
            set
            {
                _USERID = value;
            }

        }

        public static string PWD
        {
            get
            {
                return _PWD;
            }
            set
            {
                _PWD = value;
            }

        }
        public static string JBRLX
        {
            get
            {
                return _JBRLX;
            }
            set
            {
                _JBRLX = value;
            }

        }
        public static string CLIENTTYPE
        {
            get
            {
                return _CLIENTTYPE;
            }
            set
            {
                _CLIENTTYPE = value;
            }

        }

        public static string JBR
        {
            get
            {
                return _JBR;
            }
            set
            {
                _JBR = value;
            }

        }


        public static string thename
        {
            get
            {
                return _thename;
            }
            set
            {
                _thename = value;
            }

        }

        public static bool iftestmodel
        {
            get
            {
                return _iftestmodel;
            }
            set
            {
                _iftestmodel = value;
            }
        }

        static string _weblogin;
        static string _webfunc;
        static string _webaddresslogin;
        static string _webaddressfunc;
        static string _webaddresslogintest;
        static string _webaddressfunctest;

       
        static string _YYBH;
        static string _USERID;
        static string _PWD;
        static string _JBRLX;
        static string _JBR;
        static string _CLIENTTYPE;
        static string _mylocate;
        static string _mydbname;
        static string _mydbpass;
        static string _curclino;
        static string _usercode;
        static string _currdict;
        static string _un;
        static string _pwd;
        static string _sessionid;
        static string _ghdw;
        static string _cliname;
        static string _theappath;
        static string _thename;
        static bool _iftestmodel;

        public static string mylocate
        {

            get
            {
                return _mylocate;
            }
            set
            {
                _mylocate = value;
            }
        }
        public static string mydbname
        {

            get
            {
                return _mydbname;
            }
            set
            {
                _mydbname = value;
            }
        }

        public static string mydbpass
        {

            get
            {
                return _mydbpass;
            }
            set
            {
                _mydbpass = value;
            }
        }

        public static string curclino
        {

            get
            {
                return _curclino;
            }
            set
            {
                _curclino = value;
            }
        }

        public static string usercode
        {

            get
            {
                return _usercode;
            }
            set
            {
                _usercode = value;
            }
        }

        public static string currdict
        {

            get
            {
                return _currdict;
            }
            set
            {
                _currdict = value;
            }
        }

        public static string un
        {

            get
            {
                return _un;
            }
            set
            {
                _un = value;
            }
        }

        public static string pwd
        {

            get
            {
                return _pwd;
            }
            set
            {
                _pwd = value;
            }
        }

        public static string ghdw
        {
            get
            {
                return _ghdw;
            }
            set
            {
                _ghdw = value;
            }

        }

        public static string cliname
        {
            get
            {
                return _cliname;
            }
            set
            {
                _cliname = value;
            }

        }


        public void ExecuteBatchNonQuery(string sql, SqlConnection conn)
        {
            string sqlBatch = string.Empty;
            SqlCommand cmd = new SqlCommand(string.Empty, conn);
            conn.Open();
            sql += "\nGO";   // make sure last batch is executed.
            try
            {
                foreach (string line in sql.Split(new string[2] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (line.ToUpperInvariant().Trim() == "GO")
                    {
                        cmd.CommandText = sqlBatch;
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {
                        }
                        sqlBatch = string.Empty;
                    }
                    else
                    {
                        sqlBatch += line + "\n";
                    }
                }
            }
            finally
            {
                conn.Close();
            }
        }

        public int postoweb(string json, string theurl, ref string MSG, ref string YWLSH)
        {
            try
            {

                        serviceprocess.WebserviceFacade ws = new sbsc.serviceprocess.WebserviceFacade();
                         //20150714
                          if (ws.Url != theurl)
                              ws.Url = theurl;
                          //
                      //20150529
                     //   var obj = Newtonsoft.Json.Linq.JToken.Parse(json);
                        string result = ws.process(json);
                         
                      //20151102
                          if (string.IsNullOrEmpty(result))
                          throw new Exception("服务器出现异常，返回空值，请记下这个销售单并通知管理员或者社保局。"+json);
                          

                        //
                        if (result.Contains("【"))
                        {
                            int found1 = result.IndexOf("【");
                            int found2 = result.IndexOf("】");
                            result = result.Remove(found1, found2 - found1);
                        }


                        sbsc.retrunModel.returnvalue deserializedreturn = JsonConvert.DeserializeObject<sbsc.retrunModel.returnvalue>(result);
                        if (deserializedreturn.HashParams.FHZ.Trim() != "1")
                        {

                            MSG = deserializedreturn.HashParams.MSG;
                            return Convert.ToInt32(deserializedreturn.HashParams.FHZ);
                        }
                        else
                        {
                            YWLSH = deserializedreturn.HashParams.YWLSH;
                            return 0;
                        }
     
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("出错：" + ex.ToString());
                MSG = ex.ToString();
                globalvariable glv = new globalvariable();
                glv.LogWrite(ex.ToString());
                return -1;
            }


        }

        //20160526
        public string getcat(string prodno)
        {
            if (string.IsNullOrEmpty(prodno))
                return "无";

            if (prodno.Length<2)
                 return "无";

            string dogstr = prodno.Substring(0, 2);
            switch (dogstr)
            { 
                //1
                case "10":
                return "胶囊剂";

                case "11":
                return "片剂";

                case "12":
                return "颗粒剂";

                case "13":
                return "滴剂、喷剂";

                case "14":
                return "软膏剂、栓剂";

                case "15":
                return "丸剂";

                case "16":
                return "注射剂";

                case "17":
                return "口服液体制剂";

                case "18":
                return "外用液体制剂";

              
                //2

                case "20":
                return "胶囊剂";

                case "21":
                return "片剂";

                case "22":
                return "颗粒剂";

                case "23":
                return "滴剂、喷剂";

                case "24":
                return "软膏剂、栓剂";

                case "25":
                return "丸剂";

                case "26":
                return "注射剂";

                case "27":
                return "口服液体制剂";

                case "28":
                return "外用液体制剂";

          

                //3

                case "30":
                return "中药材及饮片";

                case "31":
                return "根茎类中药材及饮片";

                case "32":
                return "花叶类中药材及饮片";

                case "33":
                return "果实、种子类中药材及饮片";

                case "34":
                return "全草类中药材及饮片";

                case "35":
                return "动物及矿石类中药材及饮片";

                case "36":
                return "皮、藤木树脂类中药材及饮片";

                case "37":
                return "毒性中药材";

                case "38":
                return "中药材及饮片";

                case "39":
                return "菌、炭类、药粉、其它";

                //4

                case "40":
                return "一类医疗器械";

                case "41":
                return "二类医疗器械";

                case "42":
                return "三类医疗器械";

                case "43":
                return "其它医疗器械";

                case "46":
                return "牙科用材料";

         

                //5

                case "51":
                return "非准字卫生材料及辅料";
                    
                case "52":
                return "准字卫生材料及辅料";

  

                //6 

                case "61":
                return "化学试剂";

                case "62":
                return "玻璃仪器";

               //7 

                case "70":
                return "胶囊剂、丸剂";

                case "71":
                return "片剂";

                case "72":
                return "颗粒剂（冲剂、散剂）";

                case "73":
                return "口服液体制剂";

             
                //8 

                case "81":
                return "沐浴类、洗头水";

                case "82":
                return "牙膏、牙涮类";

                case "83":
                return "霜剂、洗面奶、面膜类";

                case "84":
                return "皂类";

                case "85":
                return "洗衣粉、洗洁精类";

                case "86":
                return "卫生巾类";


                //9

  
                case "91":
                return "消毒剂";

                case "92":
                return "劳保用品";

                case "93":
                return "药用包装材料";

               
                default:
                return "其它";
            }
        }

        //
        public void LogWrite(string logMessage)
        {
             string  m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "sblog.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("记录日志出错"+ex.ToString());
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
                MessageBox.Show("记录日志出错" + ex.ToString());
            }
        }


    }

    public class retrunvalue
    {
        public string FHZ { get; set; }

        public string MSG { get; set; }

        public string SESSIONID { get; set; }

        public string YWLSH { get; set; }
    }
}
