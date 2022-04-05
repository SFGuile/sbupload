using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sbsc.UploadInvDepModel;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Transactions;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing.Imaging;

namespace sbsc
{
    public partial class SummaryUploadForm : Form
    {
        
       
        DateTime thebegdt;
        DateTime theenddt;
        string themethod = "1";
        string myupdno;
        List<YDSYJTEMP> ydlist = new List<YDSYJTEMP>();
        public SummaryUploadForm(DateTime begdt,DateTime endt,string calmethod)
        {
            InitializeComponent();
            themethod = calmethod;
             thebegdt = begdt;
            theenddt = endt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel File|*.xls";
            saveFile.Title = "导出的EXCEL文件";
            saveFile.ShowDialog();
            if (saveFile.FileName != "")
            {
                sumaryview.ExportToXls(saveFile.FileName);
                MessageBox.Show("已经导出");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void SummaryUploadForm_Load(object sender, EventArgs e)
        {
            int result=0;
            if (themethod == "2")
            {
               result=calmethodaccu();
            }
            else
            {

                result = calmethodfast();
            }

            if (result != 0)
            {
                //  this.Close();
                btnext.Enabled = false;
                labwaring.Text = "注意，你的数据有异常无法上传，请改正后再试";
            }

            //计算次数
            var notdupliactelist = from MyObjs in ydlist
                                   group MyObjs by new { MyObjs.XMWYID, MyObjs.RKDH } into g
                                   select new { g.Key.XMWYID, g.Key.RKDH, mycount = g.Count() };


            foreach (var nd in notdupliactelist)
            {
                if (nd.mycount == 1)
                {
                    foreach (var mc in ydlist.Where(x => x.XMWYID == x.XMWYID && x.RKDH == nd.RKDH ))
                    {

                        mc.mycount = nd.mycount;
                        
                    }
                }
            }


            //\\
            DataTable thedt = new DataTable();
            thedt.Columns.Add("serialno", typeof(string));
            thedt.Columns.Add("updno", typeof(string));
            thedt.Columns.Add("yybh", typeof(string));
            thedt.Columns.Add("ny", typeof(string));
            thedt.Columns.Add("prodno", typeof(string));
            thedt.Columns.Add("prodname", typeof(string));
            thedt.Columns.Add("prodname2", typeof(string));
            thedt.Columns.Add("depno", typeof(string));
            thedt.Columns.Add("prodadd", typeof(string));
            thedt.Columns.Add("supname", typeof(string));
            thedt.Columns.Add("depdate", typeof(string));
            thedt.Columns.Add("cliname", typeof(string));
            thedt.Columns.Add("jx", typeof(string));
            thedt.Columns.Add("prodsize", typeof(string));
            thedt.Columns.Add("depnum", typeof(decimal));
            thedt.Columns.Add("invnum", typeof(decimal));
            thedt.Columns.Add("lestnum", typeof(decimal));
            thedt.Columns.Add("je", typeof(string));
            thedt.Columns.Add("BZ1", typeof(string));
            thedt.Columns.Add("BZ2", typeof(string));
            thedt.Columns.Add("BZ3", typeof(string));
            thedt.Columns.Add("prodmade", typeof(string));
            thedt.Columns.Add("mycount", typeof(int));

            int index = 0;
            myupdno = getheupdno(globalvariable.curclino);
            if (myupdno == "false")
            {
                MessageBox.Show("获取单号时出错，程序终止");
                return;
            }
            foreach (YDSYJTEMP yd in ydlist)
            {

                DataRow dr = thedt.NewRow();
                dr[0] = index + 1;
                dr[1] = myupdno;
                dr[2] = yd.YYBH;
                dr[3] = yd.NY;
                dr[4] = yd.XMWYID;
                dr[5] = yd.XMMC;
                dr[6] = yd.YPTYMC;
                dr[7] = yd.RKDH;
                dr[8] = yd.SCCS;
                dr[9] = yd.GHDW;
                dr[10] = yd.GHRQ;
                dr[11] = yd.XHDW;
                dr[12] = yd.JX;
                dr[13] = yd.GG;
                dr[14] = yd.GHSL;
                dr[15] = yd.XHSL;
                dr[16] = yd.JCL;
                dr[17] = yd.GHJG;
                dr[18] = yd.BZ1;
                dr[19] = yd.BZ2;
                dr[20] = yd.BZ3;
                dr[21] = yd.prodmade;
                dr[22] = yd.mycount;
                thedt.Rows.Add(dr);;
                index++;
            }

            gridsummary.DataSource = thedt;

            labprogress.Text = "";

        }





        private int calmethodfast()
        {
            int returncode = 0;
            List<globalvariable.prodinerror> listerr = new List<globalvariable.prodinerror>();
            try
            {
                using (lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;"))
                {

                    db.CommandTimeout = 1800;
                    var query = db.cal_month_dep_fast2(thebegdt, theenddt);

                    List<resultist> query2 = new List<resultist>();

                    foreach (var q in query)
                    {

                        if (q.dep_num == null)
                            throw new Exception("单号：" + q.dep_no + "药品编号：" + q.prod_no + "批号：" + q.batch_no + "产地：" + q.prod_add + "进仓数异常");
                        if (q.buy_price == null)
                            throw new Exception("单号：" + q.dep_no + "药品编号：" + q.prod_no + "批号：" + q.batch_no + "产地：" + q.prod_add + "进价异常");
                        if (q.lest_num == null)
                            throw new Exception("单号：" + q.dep_no + "药品编号：" + q.prod_no + "批号：" + q.batch_no + "产地：" + q.prod_add + "库存数异常");
                        if (q.inv_num == null)
                            throw new Exception("单号：" + q.dep_no + "药品编号：" + q.prod_no + "批号：" + q.batch_no + "产地：" + q.prod_add + "销售数异常");

                        resultist dp = new resultist
                        {
                            dep_no = q.dep_no,
                            prod_no = q.prod_no,
                            batch_no = q.batch_no,
                            prod_add = q.prod_add,
                            dep_date = q.dep_date,
                            prod_made=q.prod_made,
                            dep_num = (decimal?)q.dep_num ?? 0.0M,
                            buy_price = (decimal?)q.buy_price ?? 0.0M,
                            lest_num = (decimal?)q.lest_num ?? 0.0M,
                            inv_num = (decimal?)q.inv_num ?? 0.0M
                        };

                        query2.Add(dp);

                    }

                    var errquery = from c in query2
                                   where c.dep_no.Contains("error")
                                   join p in db.product
                                   on c.prod_no equals p.prod_no into joinprod
                                   from p in joinprod.DefaultIfEmpty()
                                   select new { listno = c.dep_no, prodno = c.prod_no, batchno = c.batch_no, prodadd = c.prod_add,prodmade=c.prod_made, invdate = c.dep_date, prodname = p.prod_name, invnum = (decimal?)c.inv_num ?? 0.0M, lestnum = (decimal?)c.lest_num ?? 0.0M, buyprice = (decimal?)c.buy_price ?? 0.0M, depnum = (decimal?)c.dep_num ?? 0.0M };







                    int thecount = errquery.Count();

                    if (thecount > 0)
                    {
                       
                        foreach (var errq in errquery)
                        {
                            /*   decimal suminvq = (from n in db.inv_sub
                                                  where n.prod_no == errq.prodno && n.batch_no == errq.batchno && n.prod_add == errq.prodadd
                                                  select n.inv_num).Sum();

                               decimal depq = (from ds in db.dep_sub
                                               where ds.prod_no == errq.prodno && ds.batch_no == errq.batchno && ds.prod_add == errq.prodadd
                                               select ds.dep_num).Sum();*/

                            globalvariable.prodinerror pe = new globalvariable.prodinerror
                            {
                                prodno = errq.prodno,
                                batchno = errq.batchno,
                                prodadd = errq.prodadd,
                                prodname = errq.prodname,
                                lastdepno = "",
                                invnum = errq.invnum,
                                depnum = errq.depnum,
                                description = "此批号因为总的销售数大于总的进仓数量而不能计算出进仓单所以为空或者存储过程计算不到进仓单号",
                                addition = false
                            };

                            listerr.Add(pe);
                        }

                      

                        //20151228屏蔽return -2 或者某天恢复
                        returncode =- 2;
                    }


                    /*
                        var querysum = from x in query2
                                       group x by new { x.dep_no, x.prod_no, x.dep_date, x.prod_add } into g
                                       join p in db.product
                                                   on g.Key.prod_no equals p.prod_no into joinprod
                                       from p in joinprod.DefaultIfEmpty()
                                       select new { depno = g.Key.dep_no, prodno = g.Key.prod_no, depdate = g.Key.dep_date, depnum = g.Sum(x => x.dep_num), invnum = g.Sum(x => x.inv_num), lestnum = g.Sum(x => x.lest_num), prodname = p.prod_name, prodsize = p.prod_size, buyprice = g.Average(x => x.buy_price), prodadd = g.Key.prod_add };
                  
                    */

                    List<Depsum> querydepsum = (from x in query2
                                                orderby depno, prodno
                                                group x by new { x.dep_no, x.prod_no, x.dep_date, x.prod_add } into g

                                                select new Depsum { depno = g.Key.dep_no, prodno = g.Key.prod_no, depdate = g.Key.dep_date, depnum = g.Sum(x => x.dep_num), invnum = g.Sum(x => x.inv_num), lestnum = g.Sum(x => x.lest_num), buyprice = g.Average(x => x.buy_price), prodadd = g.Key.prod_add }).ToList();

                    List<SumResult> querysum2 = new List<SumResult>();

                    foreach (var q in querydepsum)
                    {
                        string theprodno = q.prodno;
                        string prodname = null;
                        string prodsize = null;
                        string poodmade=null;
                        
                        var p = (from prod in db.product
                                     where prod.prod_no == theprodno
                                     select prod).FirstOrDefault();
                        if (p != null)
                        {
                            prodname = p.prod_name;
                            prodsize = p.prod_size;
                           poodmade=p.prod_made;
                        }
                        

                        SumResult sr = new SumResult
                        {
                            depno = q.depno,
                            prodno = q.prodno,
                            depdate = q.depdate,
                            buyprice = q.buyprice,
                            depnum = q.depnum,
                            invnum = q.invnum,
                            lestnum = q.lestnum,
                            prodadd = q.prodadd,
                            prodname = prodname,
                            prodsize = prodsize,
                            prodmade=poodmade
                        };

                        querysum2.Add(sr);
                    }

                   
                    

                    globalvariable.ghdw = (from d in db.company
                                           select d.sb_ghdw).FirstOrDefault();

                    globalvariable.cliname = (from d in db.company
                                              select d.com_name).FirstOrDefault();

                  

                    foreach (var q in querysum2)
                    {

                        string prodadd = null;
                        if (!string.IsNullOrEmpty(q.prodadd))
                            prodadd = q.prodadd.Trim();
                        else
                            prodadd = "无";

                        //20160608
                        string prodsize = null;
                        if (!string.IsNullOrEmpty(q.prodsize))
                            prodsize = q.prodsize.Trim();
                        else
                            prodsize = "无";
                        //
                        /*
                                                if (string.IsNullOrEmpty(q.depno))
                                                    throw new Exception(q.prodno + "进仓单号出错");

                                                if (string.IsNullOrEmpty(q.prodname))
                                                    throw new Exception(q.prodno + "药品名称出错");
                                                if (string.IsNullOrEmpty(q.prodadd))
                                                    throw new Exception(q.prodno + "产地出错");

                                                if (q.depdate==null)
                                                   throw new Exception(q.prodno + "进仓日期出错");*/

                        //20151206
                        if (string.IsNullOrEmpty(q.prodno))
                        {
                            globalvariable.prodinerror pe = new globalvariable.prodinerror
                            {
                                prodno = q.prodno,
                                batchno = "",
                                prodadd = q.prodadd,
                                prodname = q.prodname,
                                lastdepno = "",
                                invnum = q.invnum,
                                depnum = q.depnum,
                                description = "此药品编号为空",
                                addition = false
                            };

                            listerr.Add(pe);
                            returncode = -2;
                        }
                        //20161226
                        else if ((q.prodno?? "").Trim()=="")
                        {
                            globalvariable.prodinerror pe = new globalvariable.prodinerror
                            {
                                prodno = q.prodno,
                                batchno = "",
                                prodadd = q.prodadd,
                                prodname = q.prodname,
                                lastdepno = "",
                                invnum = q.invnum,
                                depnum = q.depnum,
                                description = "此药品编号为空",
                                addition = false
                            };

                            listerr.Add(pe);
                            returncode = -2;
 
                        }

                        if (string.IsNullOrEmpty(q.prodname))
                        {
                            globalvariable.prodinerror pe = new globalvariable.prodinerror
                            {
                                prodno = q.prodno,
                                batchno = "",
                                prodadd = q.prodadd,
                                prodname = q.prodname,
                                lastdepno = "",
                                invnum = q.invnum,
                                depnum = q.depnum,
                                description =q.prodno+"查询记录中有药品名称为空",
                                addition = false
                            };

                            listerr.Add(pe);
                            returncode = -2;
                          
                        }
                        //20161226
                        else if ((q.prodname?? "").Trim()=="")
                        {
                            globalvariable.prodinerror pe = new globalvariable.prodinerror
                            {
                                prodno = q.prodno,
                                batchno = "",
                                prodadd = q.prodadd,
                                prodname = q.prodname,
                                lastdepno = "",
                                invnum = q.invnum,
                                depnum = q.depnum,
                                description = q.prodno + "查询记录中有药品名称为空",
                                addition = false
                            };

                            listerr.Add(pe);
                            returncode = -2;

                        }

                        if (string.IsNullOrEmpty(q.depno))
                        {
                            globalvariable.prodinerror pe = new globalvariable.prodinerror
                            {
                                prodno = q.prodno,
                                batchno = "",
                                prodadd = q.prodadd,
                                prodname = q.prodname,
                                lastdepno = "",
                                invnum = q.invnum,
                                depnum = q.depnum,
                                description = q.prodno + "查询记录中有进仓单号为空",
                                addition = false
                            };

                            listerr.Add(pe);
                            returncode = -2;
                          
                        }
                        //20161226
                        else if ((q.depno?? "").Trim() == "")
                        {
                            globalvariable.prodinerror pe = new globalvariable.prodinerror
                            {
                                prodno = q.prodno,
                                batchno = "",
                                prodadd = q.prodadd,
                                prodname = q.prodname,
                                lastdepno = "",
                                invnum = q.invnum,
                                depnum = q.depnum,
                                description = q.prodno + "查询记录中有进仓单号为空",
                                addition = false
                            };

                            listerr.Add(pe);
                            returncode = -2;
                        }




                     /*   if (string.IsNullOrEmpty(q.prodadd))
                        {
                            globalvariable.prodinerror pe = new globalvariable.prodinerror
                            {
                                prodno = q.prodno,
                                batchno = "",
                                prodadd = q.prodadd,
                                prodname = q.prodname,
                                lastdepno = "",
                                invnum = q.invnum,
                                depnum = q.depnum,
                                description = q.prodno + "查询记录中有产地为空",
                                addition = false
                            };

                            listerr.Add(pe);
                            returncode = -2;
                         
                        }

                            //20161226
                        else if ((q.prodadd ?? "").Trim() == "")
                        {
                            var p = (from prod in db.product
                                     where prod.prod_no == q.prodno
                                     select prod).FirstOrDefault();
                            if (p == null || (p.last_add ?? "").Trim() == "")
                            {



                                globalvariable.prodinerror pe = new globalvariable.prodinerror
                                {
                                    prodno = q.prodno,
                                    batchno = "",
                                    prodadd = q.prodadd,
                                    prodname = q.prodname,
                                    lastdepno = "",
                                    invnum = q.invnum,
                                    depnum = q.depnum,
                                    description = q.prodno + "查询记录中有产地为空",
                                    addition = false
                                };

                                listerr.Add(pe);
                                returncode = -2;
                            }
                            else
                                q.prodadd = p.last_add;
                        }
                        */


                        if (string.IsNullOrEmpty(prodsize) && q.prodno.Substring(0,1)!="3")
                        {
                            globalvariable.prodinerror pe = new globalvariable.prodinerror
                            {
                                prodno = q.prodno,
                                batchno = "",
                                prodadd = q.prodadd,
                                prodname = q.prodname,
                                lastdepno = "",
                                invnum = q.invnum,
                                depnum = q.depnum,
                                description = q.prodno + "查询记录中有规格为空",
                                addition = false
                            };

                            listerr.Add(pe);
                            returncode = -2;
                           
                        }
                            //20161226
                        else if ((prodsize ?? "").Trim() == "" && q.prodno.Substring(0, 1) != "3")
                        {
                            globalvariable.prodinerror pe = new globalvariable.prodinerror
                            {
                                prodno = q.prodno,
                                batchno = "",
                                prodadd = q.prodadd,
                                prodname = q.prodname,
                                lastdepno = "",
                                invnum = q.invnum,
                                depnum = q.depnum,
                                description = q.prodno + "查询记录中有规格为空",
                                addition = false
                            };

                            listerr.Add(pe);
                            returncode = -2;
                        }


                        //
                        globalvariable gl=new globalvariable();

                        YDSYJTEMP ydsj = new YDSYJTEMP
                        {
                            YYBH = globalvariable.YYBH,
                            NY = theenddt.ToString("yyyyMM"),
                            XMWYID = q.prodno.Trim(),
                            XMMC = q.prodname.Trim(),
                            //20150529修改
                            //  YPTYMC = "",
                            //
                            YPTYMC = q.prodname.Trim(),
                            RKDH = q.depno.Trim(),
                            SCCS = q.prodadd,
                            GHDW = globalvariable.ghdw.Trim(),
                            GHRQ = q.depdate.ToString("yyyyMMdd"),
                            XHDW = globalvariable.cliname.Trim(),
                            //20150529修改
                            //  JX = "",
                            //  GG = "",
                            //20160526
                            JX = gl.getcat(q.prodno.Trim()),
                            GG = prodsize,
                            //
                            GHSL = q.depnum,
                            XHSL = q.invnum,
                            JCL = q.lestnum,
                            GHJG = q.buyprice,
                            //20150529修改
                            /*  BZ1 = "",
                              BZ2 = "",
                              BZ3 = ""*/
                            BZ1 = "备注1",
                            BZ2 = "备注2",
                            BZ3 = "备注3",
                            prodmade=q.prodmade
                        };

                        ydlist.Add(ydsj);
                    }

                    if (returncode == -2)
                    {
                        warningForm wf = new warningForm(listerr);
                        wf.ShowDialog();
                    }

                    return returncode;



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序出错：" + ex.ToString());
                globalvariable glv = new globalvariable();
                glv.LogWrite("SP3_4003" + ex.ToString());
                return -3;
            }


        }

        private int calmethodaccu()
        {
            int returncode = 0;
            List<globalvariable.prodinerror> listerr = new List<globalvariable.prodinerror>();
            try
            {
                using (lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;"))
                {

                    db.CommandTimeout = 1800;
                    var query = db.cal_month_dep_acm(thebegdt, theenddt);

                    List<resultist> query2 = new List<resultist>();

                    foreach (var q in query)
                    {

                        if (q.dep_num == null)
                            throw new Exception("单号：" + q.dep_no + "药品编号：" + q.prod_no + "批号：" + q.batch_no + "产地：" + q.prod_add + "进仓数异常");
                        if (q.buy_price == null)
                            throw new Exception("单号：" + q.dep_no + "药品编号：" + q.prod_no + "批号：" + q.batch_no + "产地：" + q.prod_add + "进价异常");
                        if (q.lest_num == null)
                            throw new Exception("单号：" + q.dep_no + "药品编号：" + q.prod_no + "批号：" + q.batch_no + "产地：" + q.prod_add + "库存数异常");
                        if (q.inv_num == null)
                            throw new Exception("单号：" + q.dep_no + "药品编号：" + q.prod_no + "批号：" + q.batch_no + "产地：" + q.prod_add + "销售数异常");

                        resultist dp = new resultist
                        {
                            dep_no = q.dep_no,
                            prod_no = q.prod_no,
                            batch_no = q.batch_no,
                            prod_add = q.prod_add,
                            dep_date = q.dep_date,
                            prod_made = q.prod_made,
                            dep_num = (decimal?)q.dep_num ?? 0.0M,
                            buy_price = (decimal?)q.buy_price ?? 0.0M,
                            lest_num = (decimal?)q.lest_num ?? 0.0M,
                            inv_num = (decimal?)q.inv_num ?? 0.0M
                        };

                        query2.Add(dp);

                    }

                    var errquery = from c in query2
                                   where c.dep_no.Contains("error")
                                   join p in db.product
                                   on c.prod_no equals p.prod_no into joinprod
                                   from p in joinprod.DefaultIfEmpty()
                                   select new { listno = c.dep_no, prodno = c.prod_no, batchno = c.batch_no, prodadd = c.prod_add, prodmade = c.prod_made, invdate = c.dep_date, prodname = p.prod_name, invnum = (decimal?)c.inv_num ?? 0.0M, lestnum = (decimal?)c.lest_num ?? 0.0M, buyprice = (decimal?)c.buy_price ?? 0.0M, depnum = (decimal?)c.dep_num ?? 0.0M };







                    int thecount = errquery.Count();

                    if (thecount > 0)
                    {

                        foreach (var errq in errquery)
                        {
                            /*   decimal suminvq = (from n in db.inv_sub
                                                  where n.prod_no == errq.prodno && n.batch_no == errq.batchno && n.prod_add == errq.prodadd
                                                  select n.inv_num).Sum();

                               decimal depq = (from ds in db.dep_sub
                                               where ds.prod_no == errq.prodno && ds.batch_no == errq.batchno && ds.prod_add == errq.prodadd
                                               select ds.dep_num).Sum();*/

                            globalvariable.prodinerror pe = new globalvariable.prodinerror
                            {
                                prodno = errq.prodno,
                                batchno = errq.batchno,
                                prodadd = errq.prodadd,
                                prodname = errq.prodname,
                                lastdepno = "",
                                invnum = errq.invnum,
                                depnum = errq.depnum,
                                description = "此批号因为总的销售数大于总的进仓数量而不能计算出进仓单所以为空或者存储过程计算不到进仓单号",
                                addition = false
                            };

                            listerr.Add(pe);
                        }



                        //20151228屏蔽return -2 或者某天恢复
                        returncode = -2;
                    }


                    /*
                        var querysum = from x in query2
                                       group x by new { x.dep_no, x.prod_no, x.dep_date, x.prod_add } into g
                                       join p in db.product
                                                   on g.Key.prod_no equals p.prod_no into joinprod
                                       from p in joinprod.DefaultIfEmpty()
                                       select new { depno = g.Key.dep_no, prodno = g.Key.prod_no, depdate = g.Key.dep_date, depnum = g.Sum(x => x.dep_num), invnum = g.Sum(x => x.inv_num), lestnum = g.Sum(x => x.lest_num), prodname = p.prod_name, prodsize = p.prod_size, buyprice = g.Average(x => x.buy_price), prodadd = g.Key.prod_add };
                  
                    */

                    List<Depsum> querydepsum = (from x in query2
                                                orderby depno, prodno
                                                group x by new { x.dep_no, x.prod_no, x.dep_date, x.prod_add } into g

                                                select new Depsum { depno = g.Key.dep_no, prodno = g.Key.prod_no, depdate = g.Key.dep_date, depnum = g.Sum(x => x.dep_num), invnum = g.Sum(x => x.inv_num), lestnum = g.Sum(x => x.lest_num), buyprice = g.Average(x => x.buy_price), prodadd = g.Key.prod_add }).ToList();

                    List<SumResult> querysum2 = new List<SumResult>();

                    foreach (var q in querydepsum)
                    {
                        string theprodno = q.prodno;
                        string prodname = null;
                        string prodsize = null;
                        string poodmade = null;

                        var p = (from prod in db.product
                                 where prod.prod_no == theprodno
                                 select prod).FirstOrDefault();
                        if (p != null)
                        {
                            prodname = p.prod_name;
                            prodsize = p.prod_size;
                            poodmade = p.prod_made;
                        }


                        SumResult sr = new SumResult
                        {
                            depno = q.depno,
                            prodno = q.prodno,
                            depdate = q.depdate,
                            buyprice = q.buyprice,
                            depnum = q.depnum,
                            invnum = q.invnum,
                            lestnum = q.lestnum,
                            prodadd = q.prodadd,
                            prodname = prodname,
                            prodsize = prodsize,
                            prodmade = poodmade
                        };

                        querysum2.Add(sr);
                    }




                    globalvariable.ghdw = (from d in db.company
                                           select d.sb_ghdw).FirstOrDefault();

                    globalvariable.cliname = (from d in db.company
                                              select d.com_name).FirstOrDefault();



                    foreach (var q in querysum2)
                    {

                        string prodadd = null;
                        if (!string.IsNullOrEmpty(q.prodadd))
                            prodadd = q.prodadd.Trim();
                        else
                            prodadd = "无";

                        //20160608
                        string prodsize = null;
                        if (!string.IsNullOrEmpty(q.prodsize))
                            prodsize = q.prodsize.Trim();
                        else
                            prodsize = "无";
                        //
                        /*
                                                if (string.IsNullOrEmpty(q.depno))
                                                    throw new Exception(q.prodno + "进仓单号出错");

                                                if (string.IsNullOrEmpty(q.prodname))
                                                    throw new Exception(q.prodno + "药品名称出错");
                                                if (string.IsNullOrEmpty(q.prodadd))
                                                    throw new Exception(q.prodno + "产地出错");

                                                if (q.depdate==null)
                                                   throw new Exception(q.prodno + "进仓日期出错");*/

                        //20151206
                        if (string.IsNullOrEmpty(q.prodno))
                        {
                            globalvariable.prodinerror pe = new globalvariable.prodinerror
                            {
                                prodno = q.prodno,
                                batchno = "",
                                prodadd = q.prodadd,
                                prodname = q.prodname,
                                lastdepno = "",
                                invnum = q.invnum,
                                depnum = q.depnum,
                                description = "此药品编号为空",
                                addition = false
                            };

                            listerr.Add(pe);
                            returncode = -2;
                        }
                        //20161226
                        else if ((q.prodno ?? "").Trim() == "")
                        {
                            globalvariable.prodinerror pe = new globalvariable.prodinerror
                            {
                                prodno = q.prodno,
                                batchno = "",
                                prodadd = q.prodadd,
                                prodname = q.prodname,
                                lastdepno = "",
                                invnum = q.invnum,
                                depnum = q.depnum,
                                description = "此药品编号为空",
                                addition = false
                            };

                            listerr.Add(pe);
                            returncode = -2;

                        }

                        if (string.IsNullOrEmpty(q.prodname))
                        {
                            globalvariable.prodinerror pe = new globalvariable.prodinerror
                            {
                                prodno = q.prodno,
                                batchno = "",
                                prodadd = q.prodadd,
                                prodname = q.prodname,
                                lastdepno = "",
                                invnum = q.invnum,
                                depnum = q.depnum,
                                description = q.prodno + "查询记录中有药品名称为空",
                                addition = false
                            };

                            listerr.Add(pe);
                            returncode = -2;

                        }
                        //20161226
                        else if ((q.prodname ?? "").Trim() == "")
                        {
                            globalvariable.prodinerror pe = new globalvariable.prodinerror
                            {
                                prodno = q.prodno,
                                batchno = "",
                                prodadd = q.prodadd,
                                prodname = q.prodname,
                                lastdepno = "",
                                invnum = q.invnum,
                                depnum = q.depnum,
                                description = q.prodno + "查询记录中有药品名称为空",
                                addition = false
                            };

                            listerr.Add(pe);
                            returncode = -2;

                        }

                        if (string.IsNullOrEmpty(q.depno))
                        {
                            globalvariable.prodinerror pe = new globalvariable.prodinerror
                            {
                                prodno = q.prodno,
                                batchno = "",
                                prodadd = q.prodadd,
                                prodname = q.prodname,
                                lastdepno = "",
                                invnum = q.invnum,
                                depnum = q.depnum,
                                description = q.prodno + "查询记录中有进仓单号为空",
                                addition = false
                            };

                            listerr.Add(pe);
                            returncode = -2;

                        }
                        //20161226
                        else if ((q.depno ?? "").Trim() == "")
                        {
                            globalvariable.prodinerror pe = new globalvariable.prodinerror
                            {
                                prodno = q.prodno,
                                batchno = "",
                                prodadd = q.prodadd,
                                prodname = q.prodname,
                                lastdepno = "",
                                invnum = q.invnum,
                                depnum = q.depnum,
                                description = q.prodno + "查询记录中有进仓单号为空",
                                addition = false
                            };

                            listerr.Add(pe);
                            returncode = -2;
                        }




                        /*   if (string.IsNullOrEmpty(q.prodadd))
                           {
                               globalvariable.prodinerror pe = new globalvariable.prodinerror
                               {
                                   prodno = q.prodno,
                                   batchno = "",
                                   prodadd = q.prodadd,
                                   prodname = q.prodname,
                                   lastdepno = "",
                                   invnum = q.invnum,
                                   depnum = q.depnum,
                                   description = q.prodno + "查询记录中有产地为空",
                                   addition = false
                               };

                               listerr.Add(pe);
                               returncode = -2;
                         
                           }

                               //20161226
                           else if ((q.prodadd ?? "").Trim() == "")
                           {
                               var p = (from prod in db.product
                                        where prod.prod_no == q.prodno
                                        select prod).FirstOrDefault();
                               if (p == null || (p.last_add ?? "").Trim() == "")
                               {



                                   globalvariable.prodinerror pe = new globalvariable.prodinerror
                                   {
                                       prodno = q.prodno,
                                       batchno = "",
                                       prodadd = q.prodadd,
                                       prodname = q.prodname,
                                       lastdepno = "",
                                       invnum = q.invnum,
                                       depnum = q.depnum,
                                       description = q.prodno + "查询记录中有产地为空",
                                       addition = false
                                   };

                                   listerr.Add(pe);
                                   returncode = -2;
                               }
                               else
                                   q.prodadd = p.last_add;
                           }
                           */


                        if (string.IsNullOrEmpty(prodsize) && q.prodno.Substring(0, 1) != "3")
                        {
                            globalvariable.prodinerror pe = new globalvariable.prodinerror
                            {
                                prodno = q.prodno,
                                batchno = "",
                                prodadd = q.prodadd,
                                prodname = q.prodname,
                                lastdepno = "",
                                invnum = q.invnum,
                                depnum = q.depnum,
                                description = q.prodno + "查询记录中有规格为空",
                                addition = false
                            };

                            listerr.Add(pe);
                            returncode = -2;

                        }
                        //20161226
                        else if ((prodsize ?? "").Trim() == "" && q.prodno.Substring(0, 1) != "3")
                        {
                            globalvariable.prodinerror pe = new globalvariable.prodinerror
                            {
                                prodno = q.prodno,
                                batchno = "",
                                prodadd = q.prodadd,
                                prodname = q.prodname,
                                lastdepno = "",
                                invnum = q.invnum,
                                depnum = q.depnum,
                                description = q.prodno + "查询记录中有规格为空",
                                addition = false
                            };

                            listerr.Add(pe);
                            returncode = -2;
                        }


                        //
                        globalvariable gl = new globalvariable();

                        YDSYJTEMP ydsj = new YDSYJTEMP
                        {
                            YYBH = globalvariable.YYBH,
                            NY = theenddt.ToString("yyyyMM"),
                            XMWYID = q.prodno.Trim(),
                            XMMC = q.prodname.Trim(),
                            //20150529修改
                            //  YPTYMC = "",
                            //
                            YPTYMC = q.prodname.Trim(),
                            RKDH = q.depno.Trim(),
                            SCCS = q.prodadd,
                            GHDW = globalvariable.ghdw.Trim(),
                            GHRQ = q.depdate.ToString("yyyyMMdd"),
                            XHDW = globalvariable.cliname.Trim(),
                            //20150529修改
                            //  JX = "",
                            //  GG = "",
                            //20160526
                            JX = gl.getcat(q.prodno.Trim()),
                            GG = prodsize,
                            //
                            GHSL = q.depnum,
                            XHSL = q.invnum,
                            JCL = q.lestnum,
                            GHJG = q.buyprice,
                            //20150529修改
                            /*  BZ1 = "",
                              BZ2 = "",
                              BZ3 = ""*/
                            BZ1 = "备注1",
                            BZ2 = "备注2",
                            BZ3 = "备注3",
                            prodmade = q.prodmade
                        };

                        ydlist.Add(ydsj);
                    }

                    if (returncode == -2)
                    {
                        warningForm wf = new warningForm(listerr);
                        wf.ShowDialog();
                    }

                    return returncode;



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序出错：" + ex.ToString());
                globalvariable glv = new globalvariable();
                glv.LogWrite("SP3_4003" + ex.ToString());
                return -3;
            }

        }

        private string getheupdno(string clino)
        {
            try
            {
                lsDataClassesDataContext dc = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;");
                int theexits = (from c in dc.cur_ind
                                where c.user_code.Trim() == clino.Trim()
                                select c).Count();
                if (theexits == 0)
                    return "false";
                var query = from c in dc.cur_ind
                            where c.user_code.Trim() == clino.Trim()
                            select new { c.cur_year, c.cur_month, c.cur_date, c.upd_ind };
                int theyear = 0;
                int themonth = 0;
                int theday = 0;
                int theind = 0;
                int thecuryear = DateTime.Now.Year;
                int thecurmonth = DateTime.Now.Month;
                int thecurday = DateTime.Now.Day;


                foreach (var q in query)
                {
                    int tempint;
                    if (int.TryParse(q.cur_year.ToString(), out tempint))
                    {
                        theyear = tempint;
                    }
                    else
                    {
                        MessageBox.Show("解释年份出错，不能生成上传单号");
                        return "false";
                    }

                    if (int.TryParse(q.cur_month.ToString(), out tempint))
                    {
                        themonth = tempint;
                    }
                    else
                    {
                        MessageBox.Show("解释月份出错，不能生成上传单号");
                        return "false";
                    }

                    if (int.TryParse(q.cur_date.ToString(), out tempint))
                    {
                        theday = tempint;
                    }
                    else
                    {
                        MessageBox.Show("解释日期出错，不能生成上传单号");
                        return "false";
                    }

                    if (int.TryParse(q.upd_ind.ToString(), out tempint))
                    {
                        theind = tempint;
                    }
                    else
                    {
                        MessageBox.Show("解释指针出错，不能生成上传单号");
                        return "false";
                    }
                }

                DateTime ValidDate = new DateTime(theyear, themonth, theday);

                if (DateTime.Now.Date < ValidDate.Date)
                {
                    MessageBox.Show("指针表异常，不能生成上传单号");
                    return "false";
                }

                if (theyear != thecuryear || themonth != thecurmonth || theday != thecurday)
                {
                    var curindex = dc.cur_ind.First(d => d.user_code.Trim() == clino.Trim());
                    curindex.cur_year = thecuryear;
                    curindex.cur_month = thecurmonth;
                    curindex.cur_date = thecurday;
                    curindex.upd_ind = 0;
                    dc.SubmitChanges();
                    theyear = thecuryear;
                    themonth = thecurmonth;
                    theday = thecurday;
                    theind = 0;

                }

                if (theind > 999)
                    return "false";
                else
                    return "upd"+theyear.ToString() + string.Format("{0:D2}",themonth) +  string.Format("{0:D2}",theday) + clino.Trim() + string.Format("{0:D3}", theind);




            }
            catch
            {
                return "false";
            }
        }

     

        private void btnext_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("你确认提交以上数据吗？", "提示", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {


                for (int i = 0; i < sumaryview.DataRowCount; i++)
                {
                    string depno = sumaryview.GetDataRow(i)["depno"].ToString();
                    string prodno = sumaryview.GetDataRow(i)["prodno"].ToString();
                    string prodadd = sumaryview.GetDataRow(i)["prodadd"].ToString();
                    if (prodadd.Trim() == "无")
                        prodadd = "";


                    string bz1 = sumaryview.GetDataRow(i)["BZ1"].ToString();
                    string bz2 = sumaryview.GetDataRow(i)["BZ2"].ToString();
                    string bz3 = sumaryview.GetDataRow(i)["BZ3"].ToString();
                    string sbjx = sumaryview.GetDataRow(i)["jx"].ToString();
                    foreach (var mc in   ydlist.Where(d=>d.XMWYID.Trim() == prodno.Trim() && d.RKDH.Trim() == depno.Trim() && d.SCCS.Trim() == prodadd.Trim()))
                    {
                        mc.BZ1 = bz1;
                        mc.BZ2 = bz2;
                        mc.BZ3 = bz3;
                        mc.JX = sbjx;

                    }
                }



                int Counts = ydlist.Count();
                int pageSize = 500;
                int pageCount;

                HashParams hm = new HashParams
                {
                    FN = "SP3_4003",
                    YYBH = globalvariable.YYBH,
                    JBR = globalvariable.JBR,
                    JBRQ = String.Format("{0:yyyyMMddHHmmss}", DateTime.Now),
                    SESSIONID = globalvariable.SESSIONID,
                    CLIENTTYPE = globalvariable.CLIENTTYPE
                };

                if (Counts % pageSize != 0)
                {
                    pageCount = Counts / pageSize + 1;
                }
                else
                {
                    pageCount = Counts / pageSize;
                }

                //20150530
                progressBar.Maximum = pageCount;
                //
                 

                for (int pageIndex = 0; pageIndex < pageCount; pageIndex++)
                {
                    var resultPagging = ydlist.ToList().Skip((pageIndex - 1) * pageSize).Take(pageSize);
                    int thecount = resultPagging.Count();
                    YDSYJCKXXCS[] ybzj = new YDSYJCKXXCS[thecount];
                    int theindex = 0;
                    foreach (YDSYJTEMP yd in resultPagging)
                    {
                        ybzj[theindex] = new YDSYJCKXXCS();
                        ybzj[theindex].YYBH = yd.YYBH;
                        ybzj[theindex].NY = yd.NY;
                        ybzj[theindex].XMWYID = yd.XMWYID;
                        ybzj[theindex].XMMC = yd.XMMC;
                        ybzj[theindex].YPTYMC = yd.YPTYMC;
                        ybzj[theindex].RKDH = yd.RKDH;


                        //20171124
                        /*if (!string.IsNullOrEmpty(yd.SCCS.Trim()))
                           ybzj[theindex].SCCS = yd.SCCS;
                        else
                          ybzj[theindex].SCCS = "无";*/

                        if (yd.prodmade == null)
                            yd.prodmade = "";

                        if (yd.mycount == 1 && !string.IsNullOrEmpty(yd.prodmade.Trim()))
                        {
                            ybzj[theindex].SCCS = yd.prodmade.Trim();
                        }
                        else if (!string.IsNullOrEmpty(yd.SCCS.Trim()))
                        {
                            ybzj[theindex].SCCS = yd.SCCS;
                        }
                        else
                        {
                            ybzj[theindex].SCCS = "无";
                        }


                        //\\
                        ybzj[theindex].GHDW = yd.GHDW;
                        ybzj[theindex].GHRQ = yd.GHRQ;
                        ybzj[theindex].XHDW = yd.XHDW;
                        ybzj[theindex].JX = yd.JX;
                        ybzj[theindex].GG = yd.GG;
                        ybzj[theindex].GHSL = Math.Round(yd.GHSL,3).ToString();
                        ybzj[theindex].XHSL = Math.Round(yd.XHSL, 3).ToString();
                        ybzj[theindex].JCL = Math.Round(yd.JCL, 3).ToString();
                        ybzj[theindex].GHJG = Math.Round(yd.GHJG, 2).ToString();
                        ybzj[theindex].BZ1 = yd.BZ1;
                        ybzj[theindex].BZ2 = yd.BZ2;
                        ybzj[theindex].BZ3 = yd.BZ3;
                        theindex++;
                    }

                    DataPackage dp = new DataPackage
                    {
                        YDSYJCKXXCS = ybzj
                    };
                    SampleResponse1 sr = new SampleResponse1
                    {
                        HashParams = hm,
                        DataPackage = dp
                    };
                    string json = JsonConvert.SerializeObject(sr);
                    globalvariable gv = new globalvariable();
                    string expcemsg = "";
                    string YWLSH = "";
                    int myresult = gv.postoweb(json, globalvariable.webfunc, ref expcemsg, ref YWLSH);
                    //20150530
                   
                    labprogress.Text  = "当前进度："+(pageIndex+ 1).ToString() + "/" + pageCount.ToString();
                    labprogress.Refresh();
                    progressBar.Value = pageIndex + 1;
                    
;
                    //
                    if (myresult != 0)
                    {
                        //20150530
                        progressBar.Value = 0;
                        //
                        DialogResult dialogResult2 = MessageBox.Show("上传过程出现异常，原因：" + expcemsg + "，程序将要终止，是否把在社保服务器里的" + thebegdt.ToString("yyyy/MM") + "月所有记录清空？", "提示", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            //清空数据
                            sbsc.RemoveUploadinvdepModel.HashParams hp2 = new sbsc.RemoveUploadinvdepModel.HashParams
                            {
                                YYBH = globalvariable.YYBH,
                                FN = "SP3_4004",
                                JBR = globalvariable.JBR,
                                JBRQ = String.Format("{0:yyyyMMddHHmmss}", DateTime.Now),
                                SESSIONID = globalvariable.SESSIONID,
                                CLIENTTYPE = globalvariable.CLIENTTYPE,
                                NY = thebegdt.ToString("yyyyMM"),
                                SCFS = "1",
                                XMWYID = ""
                            };
                            sbsc.RemoveUploadinvdepModel.DataPackage dp2 = new sbsc.RemoveUploadinvdepModel.DataPackage();

                            sbsc.RemoveUploadinvdepModel.SampleResponse1 sr2= new sbsc.RemoveUploadinvdepModel.SampleResponse1
                            {
                                HashParams = hp2,
                                DataPackage = dp2
                            };


                            string json2 = JsonConvert.SerializeObject(sr2);


                            int myresult2 = gv.postoweb(json2, globalvariable.webfunc, ref expcemsg, ref YWLSH);
                            if (myresult2 != 0)
                            {
                                MessageBox.Show("删除社保服务器中的记录出现错误，请通知系统管理员!");
                                globalvariable glv = new globalvariable();
                                glv.LogWrite("SP3_4003" + myresult2.ToString());
                                this.Close();
                            }
                            else
                            MessageBox.Show("已经把社保局服务器里的" + thebegdt.ToString("yyyy/MM") + "资料删除了");
                        }
                        this.Close();
                        return;
                    }

                }

                //保存上传内容


            //    using (TransactionScope tran = new TransactionScope())
             //   {
                    try
                    {
                        lsDataClassesDataContext dc = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;");
                        {

                            dc.CommandTimeout = 1800;
                            int tempint;
                            if (!int.TryParse(thebegdt.ToString("yyyyMM"), out  tempint))
                                throw new Exception("保存时解释日期为整形时出错" + thebegdt.ToString("yyyyMM"));

                            char tempchar;

                            if (!char.TryParse(themethod.Trim(),out tempchar))
                                throw new Exception("保存时解释方法为单字符型时出错" + themethod.Trim());

                            upd_main um = new upd_main
                            {
                                upd_no = myupdno,
                                upd_date = DateTime.Now,
                                ny = tempint,
                                upd_bywho = globalvariable.curclino,
                                model = tempchar

                            };

                            dc.upd_main.InsertOnSubmit(um);

                            foreach (YDSYJTEMP yd in ydlist)
                            {

                              

                                upd_sub us = new upd_sub
                               {
                                   upd_no = myupdno,
                                   prod_no = yd.XMWYID,
                                   prod_name = yd.XMMC,
                                   prod_name2 = yd.YPTYMC,
                                   dep_no = yd.RKDH,
                                   prod_add = yd.SCCS,
                                   sup_name = yd.GHDW,
                                   dep_date = yd.GHRQ.ToString(),
                                   md_name = yd.XHDW,
                                   jx = yd.JX,
                                   prod_size = yd.GG,
                                   dep_num = yd.GHSL,
                                   inv_num = yd.XHSL,
                                   lest_num = yd.JCL,
                                   buy_price = yd.GHJG,
                                   BZ1 = yd.BZ1,
                                   BZ2 = yd.BZ2,
                                   BZ3 = yd.BZ3,
                                   prod_made=yd.prodmade,
                                   mycount=yd.mycount

                               };
                                dc.upd_sub.InsertOnSubmit(us);

                                //20180926
                                var myquerydep = from k in dc.dep_main
                                                 where k.dep_no.Trim() == yd.RKDH.Trim()
                                                 select k;

                                foreach (var q2 in myquerydep)
                                {
                                    q2.upload_bz = Convert.ToChar('1');
                                    q2.upload_time = dc.GetSystemDate();
                                }
                                //\\

                            }




                            var qs2 = from k in dc.dep_main
                                      where k.dep_date >= thebegdt && k.dep_date <= theenddt
                                      select k ;

                              
                                
                                foreach (var q2 in qs2)
                                {
                                    q2.upload_bz =Convert.ToChar('1');
                                    q2.upload_time = dc.GetSystemDate();
                                }

                                var qs = from f in dc.inv_main
                                         where f.inv_date >= thebegdt && f.inv_date <= theenddt 
                                         select f;

                                foreach (var q in qs)
                                {
                                    q.upload_bz = Convert.ToChar('1');
                                    q.upload_time = dc.GetSystemDate();
                                }
                            



                            int theexits = (from c in dc.cur_ind
                                            where c.user_code.Trim() == globalvariable.curclino.Trim()
                                            select c).Count();
                            if (theexits == 0)
                            {
                                MessageBox.Show("更新指针时出错");
                                throw new Exception("更新指针时出错");
                            }
                            var query = from c in dc.cur_ind
                                        where c.user_code.Trim() == globalvariable.curclino.Trim()
                                        select new { c.upd_ind };
                            int theind = 0;

                           
                          

                            foreach (var q in query)
                            {
                                if (int.TryParse(q.upd_ind.ToString(), out tempint))
                                {
                                    theind = tempint;
                                }
                                else
                                {
                                    MessageBox.Show("更新指针解释时出错");
                                    throw new Exception("更新指针解释时出错");
                                }
                              
                            }

                            theind++;
                            var thepass = dc.cur_ind.First(c => c.user_code.Trim() == globalvariable.curclino.Trim());
                            thepass.upd_ind = theind;

                            dc.SubmitChanges();
                      //      tran.Complete();
                            MessageBox.Show("上传完成");
                           this.Close();
                           
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("请通知管理员，保存上传的记录到本地时发生异常：" + ex.ToString());
                        globalvariable glv = new globalvariable();
                        glv.LogWrite("SP3_4003" + ex.ToString());
                        this.Close();
                        return;
                        
                    }
                //  }



            }
                        
        }

        private void sumaryview_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column.FieldName == "prodadd")
                {
                    GridView view = sender as GridView;

                    // Some condition
                    if (view.GetRowCellValue(e.RowHandle, view.Columns["prodadd"]).ToString().Trim() == "无")
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
               
            }
        }

        private void btncapture_Click(object sender, EventArgs e)
        {
            string myfile = "d:\\"+globalvariable.thename+"进出库" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";


            Rectangle bounds = this.Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }
                bitmap.Save(myfile, ImageFormat.Jpeg);
            }

            MessageBox.Show("保存截图到" + myfile);
        }
    }



    public class SumResult
    {
        public string depno { get; set; }
        public string prodno { get; set; }
        public DateTime depdate { get; set; }
        public decimal depnum { get; set; }
        public decimal invnum { get; set; }
        public decimal lestnum { get; set; }
        public decimal buyprice { get; set; }
        public string prodadd { get; set; }
        public string prodname { get; set; }
        public string prodsize { get; set; }
        public string prodmade { get; set; }
    }

    public class Depsum
    {
      public string   depno { get; set; }  
      public string   prodno { get; set; } 
      public DateTime  depdate { get; set; }
      public decimal depnum { get; set; }
      public decimal invnum { get; set; }
      public decimal lestnum { get; set; } 
     public decimal    buyprice { get; set; }
     public string prodadd { get; set; } 
    }
        public class Prodlist
    {
       
        public string prod_no { get; set; } 
       
        public string prod_name { get; set; }
        public string prod_size { get; set; }
     
    }

    public class Invsubrecords
    {
        public string listno { get; set; }

        public string prodno { get; set; }



        public string batchno { get; set; }

        public string prodadd { get; set; }

        public string sbdepnomemo { get; set; }

        public string prodname { get; set; }
    }


    public class Querydep
    {
        public string depno { get; set; }

        public string prodno { get; set; }

        public string batchno { get; set; }

        public string prodadd { get; set; }

        public string prodname { get; set; }

        public string monad { get; set; }

        public string prodsize { get; set; }

        public decimal  depnum { get; set; }

        public decimal buyprice { get; set; }

        public decimal je { get; set; }

        public decimal lestnum { get; set; }

        public DateTime depdate { get; set; }

        public string prodmade { get; set; }
    }

    public class QueryInv
    {
        public string listno { get; set; }

        public string prodno { get; set; }

        public string batchno { get; set; }

        public string prodadd { get; set; }

        public DateTime invdate { get; set; }

        public string sbdepnomemo { get; set; }

        public string prodname { get; set; }

        public decimal invnum { get; set; }

        public decimal lestnum { get; set; }

        public decimal buyprice { get; set; }

        public string sbdepnummeo { get; set; }

       //20150529

        public string prodsize { get; set; }

        public string prodmade { get; set; }
       
    }

    public class Qdep
    {
        public string depno { get; set; }

        public string prodno { get; set; }

        public DateTime depdate { get; set; }

        public decimal depnum { get; set; }

        public decimal invnum { get; set; }

        public decimal lestnum { get; set; }

        public string prodname { get; set; }

        public decimal buyprice { get; set; }

        public string prodadd { get; set; }
    }

    public class resultist
    {
        public string dep_no;
       
        public string prod_no;
       
        public string batch_no;
       
        public string prod_add;
        
        public DateTime dep_date;
        
        public decimal dep_num;
       
        public decimal inv_num;
      
        public decimal lest_num;
        
        public decimal buy_price;

        public string prod_made;
    }

   
}
