using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sybase.DataWindow;
using System.Data.SqlClient;
using sbsc.IndividalChargeModel;
using Newtonsoft.Json;
using System.Globalization;
using System.Drawing.Imaging;



namespace sbsc
{




    public partial class IndividalChargeForm : Form
    {
        SqlConnection dbConn;
        AdoTransaction adoTrans;
        List<globalvariable.prodinerror> listerr = new List<globalvariable.prodinerror>();

   
        string thelistno;
        int recept = 0;
        string sb_cardnoforupload, sb_idnoforupload, sb_cardno, sb_idno;
        string currentclino;
      

        public IndividalChargeForm()
        {
            InitializeComponent();
        }

        private void IndividalChargeForm_Load(object sender, EventArgs e)
        {
            try
            {
                dbConn = new SqlConnection(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;");
                dbConn.Open();
                adoTrans = new AdoTransaction(dbConn);
                adoTrans.BindConnection();
                dw_1.SetTransaction(adoTrans);
                dw_2.SetTransaction(adoTrans);
              /*  txtyptjrxm.MaxLength = 50;
                txtyptjrslx.MaxLength = 50;
                txtypshrxm.MaxLength = 50;
                txtypshryslx.MaxLength = 50;*/
                forminitial();

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误发生：" + ex.ToString());
                globalvariable glv = new globalvariable();
                glv.LogWrite("SP3_4001" + ex.ToString());
                this.Close();

            }

            if (globalvariable.iftestmodel == false)
            {
                fill.Visible = false;
                filldw1.Links[0].Visible=false;
                filldw2.Links[0].Visible = false;
            }

            try
            {
                using (lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + "; Connect Timeout=180;"))
                {
                    db.CommandTimeout = 10 * 60;
                    var query = (from c in db.company
                                 select c).FirstOrDefault();

                    if (query.sb_useaddionalpos != '0')
                    {
                        
                        dw_1.Modify("sb_useaddionalpos.TabSequence = 0");
                        //dw_1.Modify("sb_useaddionalpos.edit.DisplayOnly = 'yes'");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误：" + ex.ToString());
                globalvariable glv = new globalvariable();
                glv.LogWrite("SP3_4001" + ex.ToString());
            }

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                using (lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + "; Connect Timeout=180;"))
                {
                    db.CommandTimeout = 10 * 60;
                    var query = (from c in db.company
                                 select c).FirstOrDefault();
                    if (string.IsNullOrEmpty(query.sb_ypshrsfys) || string.IsNullOrEmpty(query.sb_ypshrxm) ||
                        string.IsNullOrEmpty(query.sb_ypshryslx) || string.IsNullOrEmpty(query.sb_yptjrsfys) ||
                        string.IsNullOrEmpty(query.sb_yptjrxm) || string.IsNullOrEmpty(query.sb_yptjryslx) ||
                        string.IsNullOrEmpty(query.sb_ssh) || string.IsNullOrEmpty(query.sb_zdbh) || string.IsNullOrEmpty(query.sb_ghdw))
                    {
                        MessageBox.Show("有必填的项目为空，请去系统设置里把该填的项目填上后再试，程序终止");
                        return;
                    }
                    else
                    {

                        InputListnoForm frm = new InputListnoForm();
                        frm.ShowDialog();
                        string val = frm.ReturnValue;
                        if (string.IsNullOrEmpty(val))
                            return;


                        long thecount = (from d in db.inv_main
                                         where d.list_no.Trim() == val.Trim() && (d.sbxslx.ToString().Trim() == "0" || d.sbxslx.ToString().Trim() == "1" || ( d.sbxslx.ToString().Trim() == "2" && d.sb_tzscjk.ToString().Trim()=="0"))
                                         select d).Count();
                        if (thecount == 0)
                        {
                            MessageBox.Show("查无此单或者你收款时并不是通过社保金卡保存或特诊卡保存，或者你按了金卡保存或特诊卡保存后又为了补打小票又按了收款保存：" + val);
                            return;
                        }

                        forminitial();

                        var jysj = (from i in db.inv_main
                                    where i.list_no.Trim() == val.Trim()
                                    join j in db.client
                                    on i.cli_no equals j.cli_no into joincli
                                    from j in joincli.DefaultIfEmpty()
                                    select new { i.inv_date, i.cli_name, i.inv_memo, j.cli_id, i.inv_mon, i.sbcf_bh, i.sbcfbz, i.sbcfjgsfjggz, i.sbcfkjjgmc, i.sbcfrq, i.sbcfysxm, i.sbcfzd, i.sbxp_no, i.sbxp_jysj, i.sbxslx, i.sb_ka_zhifu, i.SB_BZ1, i.SB_BZ2, i.SB_BZ3, i.SB_CFBZ1, i.SB_CFBZ2, i.SB_CFBZ3, i.sb_cli_no, i.sb_cli_name, i.sb_cli_id, i.sb_cli_sbcardno, i.cli_sbcardno, clisbclicard = j.cli_sbcardno,i.updSFZHM,i.sb_uploadchooseidsbcard ,invclino=i.cli_no,invsbclino=i.sb_cli_no}).FirstOrDefault();





                        List<recordresult> qinv = (from f in db.inv_sub
                                                   where f.list_no.Trim() == val.Trim()
                                                   join g in db.inv_main
                                                   on f.list_no equals g.list_no into joininv
                                                   from g in joininv.DefaultIfEmpty()
                                                   join h in db.product
                                                   on f.prod_no equals h.prod_no into joinprod
                                                   from h in joinprod.DefaultIfEmpty()
                                                   select new recordresult { prodno = f.prod_no, batchno = f.batch_no, prodadd = f.prod_add, prodmade = h.prod_made, availdate = f.avail_date, sellprice = f.sell_price, invnum = f.inv_num, sellmon = f.inv_num * f.sell_price, prodname = h.prod_name, monad = h.monad, prodsize = h.prod_size, recipe = h.recipe, zyps_bm = h.zyps_bm, barcode = h.bar_code, lastdepno = f.sb_dep_no, invdatesb = g.inv_ins_date, bz1 = f.SB_BZ1, bz2 = f.SB_BZ2, bz3 = f.SB_BZ3, ifprodmade=1 }).ToList();


                        //20171123

                        var notdupliactelist = from MyObjs in qinv
                                               group MyObjs by new { MyObjs.prodno, MyObjs.batchno } into g
                                               select new { g.Key.prodno, g.Key.batchno, mycount = g.Count() };



                        foreach (var nd in notdupliactelist)
                        {
                            if (nd.mycount == 1)
                            {
                                foreach (var mc in qinv.Where(x => x.prodno == nd.prodno && x.batchno == nd.batchno))
                                {
                                    if (!string.IsNullOrEmpty(mc.prodmade))
                                    {
                                        mc.prodadd = mc.prodmade;
                                        mc.ifprodmade = 0;
                                    }
                                }
                            }
                        }


                        //\\
                        recept = (from k in qinv
                                  where k.recipe == true
                                  select k).Count();

                        if (!string.IsNullOrEmpty(jysj.invsbclino) && jysj.invsbclino.ToLower() != "c9999")
                        {
                            currentclino = jysj.invsbclino;
                        }
                        else
                        {
                            currentclino = jysj.invclino;
                        }
                        

                    



                        //增加行，并移动记录到新增加的行
                        int li_Row;
                        li_Row = dw_1.InsertRow(0);
                        dw_1.ScrollToRow(li_Row);

                        //20171205
                        int li_Row2 = dw_2.InsertRow(0);
                        dw_2.ScrollToRow(li_Row2);
                        dw_2.SetItemString(li_Row2, "jgsfjggz", "0");
                        //\\

                        dw_1.SetItemString(li_Row, "list_no", val.Trim());
                        //  dw_1.SetItemString(li_Row, "zd", query.sb_zdbh);
                        //20150811修改
                        //  dw_1.SetItemString(li_Row, "jylx", "0201");
                        dw_1.SetItemString(li_Row, "jylx", "消费");
 

                        //20150422
                        if (jysj.sbxslx == '0' || jysj.sbxslx == '2')
                        {
                            dw_1.SetItemString(li_Row, "sb_ssh", query.sb_ssh);
                            dw_1.SetItemString(li_Row, "sb_zdbh", query.sb_zdbh);

                            //20191007
                            dw_1.SetItemString(li_Row, "sb_useaddionalpos", "1");
                            //\\

                        }
                        else if (jysj.sbxslx == '1')
                        {
                            dw_1.SetItemString(li_Row, "sb_ssh", query.sb_tzssh);
                            dw_1.SetItemString(li_Row, "sb_zdbh", query.sb_tzzdbh);

                            //20191007
                            
                            dw_1.SetItemString(li_Row, "sb_useaddionalpos", "0");
                            //\\
                        }

                        if (jysj.sbxslx != null)
                            dw_1.SetItemString(li_Row, "xslx", jysj.sbxslx.ToString());

                        //

                        sb_cardnoforupload = jysj.sb_cli_sbcardno;
                        sb_idnoforupload = jysj.sb_cli_id;
                        sb_cardno = jysj.cli_sbcardno;
                        sb_idno = jysj.cli_id;

                        //20181009
                        if (!string.IsNullOrEmpty(jysj.updSFZHM))
                        {
                            dw_1.SetItemString(li_Row, "xm", jysj.cli_name);
                            dw_1.SetItemString(li_Row, "sfzhm", jysj.updSFZHM);
                            dw_1.SetItemString(li_Row, "selectidorsbcard", jysj.sb_uploadchooseidsbcard.ToString());

                        }
                        else if (!string.IsNullOrEmpty(jysj.sb_cli_sbcardno) && jysj.sb_cli_sbcardno.Trim().Length != 0)
                        {
                            dw_1.SetItemString(li_Row, "xm", jysj.sb_cli_name);
                            dw_1.SetItemString(li_Row, "sfzhm", jysj.sb_cli_sbcardno);

                            //20191118
                            dw_1.SetItemString(li_Row, "selectidorsbcard", "0");
                            //
                        }
                        else if (!string.IsNullOrEmpty(jysj.cli_sbcardno) && jysj.cli_sbcardno.Trim().Length != 0)
                        {
                            dw_1.SetItemString(li_Row, "xm", jysj.cli_name);
                            dw_1.SetItemString(li_Row, "sfzhm", jysj.cli_sbcardno);

                            //20191118
                            dw_1.SetItemString(li_Row, "selectidorsbcard", "1");
                            //
                        }
                        else if  (!string.IsNullOrEmpty(jysj.clisbclicard) && jysj.clisbclicard.Trim().Length != 0)
                        {
                            dw_1.SetItemString(li_Row, "xm", jysj.cli_name);
                            dw_1.SetItemString(li_Row, "sfzhm", jysj.cli_sbcardno);

                            //20191118
                            dw_1.SetItemString(li_Row, "selectidorsbcard", "2");
                        }
                        else if (!string.IsNullOrEmpty(jysj.sb_cli_id) && jysj.sb_cli_id.Trim().Length != 0)
                        {
                            dw_1.SetItemString(li_Row, "xm", jysj.sb_cli_name);
                            dw_1.SetItemString(li_Row, "sfzhm", jysj.sb_cli_id);

                            //20191118
                            dw_1.SetItemString(li_Row, "selectidorsbcard", "3");
                            //
                        }
                        else if (!string.IsNullOrEmpty(jysj.cli_id) && jysj.cli_id.Trim().Length != 0)
                        {
                            dw_1.SetItemString(li_Row, "xm", jysj.cli_name);
                            dw_1.SetItemString(li_Row, "sfzhm", jysj.sb_cli_id);

                            //20191118
                            dw_1.SetItemString(li_Row, "selectidorsbcard", "4");
                            //
                        }
                        else
                        {
                            dw_1.SetItemString(li_Row, "xm", jysj.sb_cli_name);
                            dw_1.SetItemString(li_Row, "sfzhm", jysj.clisbclicard);

                            //20191118
                            dw_1.SetItemString(li_Row, "selectidorsbcard", "5");
                            //

                        }
                        //\\
                        //20151111
                        decimal psojyje = jysj.inv_mon;
                        if (jysj.sb_ka_zhifu != 0)
                            psojyje = jysj.sb_ka_zhifu;


                        //
                        //20171206
                        dw_1.SetItemString(li_Row, "yptjrxm", query.sb_yptjrxm);
                        dw_1.SetItemString(li_Row, "ypshrxm", query.sb_ypshrxm);

                        //

                        dw_1.SetItemDecimal(li_Row, "posyjje", psojyje);

                        dw_1.SetItemString(li_Row, "sb_yybh", globalvariable.YYBH);

                        //20160520
                        if (string.IsNullOrEmpty(jysj.SB_BZ1))
                            dw_1.SetItemString(li_Row, "memo1", "备注1");
                        else
                            dw_1.SetItemString(li_Row, "memo1", jysj.SB_BZ1);


                        if (string.IsNullOrEmpty(jysj.SB_BZ2))
                            dw_1.SetItemString(li_Row, "memo2", "备注2");
                        else
                            dw_1.SetItemString(li_Row, "memo2", jysj.SB_BZ2);

                        if (string.IsNullOrEmpty(jysj.SB_BZ3))
                            dw_1.SetItemString(li_Row, "memo3", "备注3");
                        else
                            dw_1.SetItemString(li_Row, "memo3", jysj.SB_BZ3);

                       if (string.IsNullOrEmpty(jysj.SB_CFBZ1))
                            dw_2.SetItemString(li_Row2, "ybmemo1", "备注1");
                        else
                            dw_2.SetItemString(li_Row2, "ybmemo1", jysj.SB_CFBZ1);

                        if (string.IsNullOrEmpty(jysj.SB_CFBZ2))
                            dw_2.SetItemString(li_Row2, "ybmemo2", "备注2");
                        else
                            dw_2.SetItemString(li_Row2, "ybmemo2", jysj.SB_CFBZ2);

                        if (string.IsNullOrEmpty(jysj.SB_CFBZ3))
                            dw_2.SetItemString(li_Row2, "ybmemo3", "备注3");
                        else
                            dw_2.SetItemString(li_Row2, "ybmemo3", jysj.SB_CFBZ3);
                        //\\


                        dw_2.SetItemString(li_Row2, "yptjrxm", query.sb_yptjrxm);


                    if (query.sb_yptjrsfys.Trim() == "1")
                        dw_2.SetItemString(li_Row2, "yprjtsfys", "1");
                    else
                        dw_2.SetItemString(li_Row2, "yprjtsfys", "0");



                    dw_2.SetItemString(li_Row2, "yptjrslx", query.sb_yptjryslx);
                    dw_2.SetItemString(li_Row2, "ypshrxm", query.sb_ypshrxm);
                    if (query.sb_ypshrsfys.Trim() == "1")
                        dw_2.SetItemString(li_Row2, "ypshrsfys", "1");
                    else
                        dw_2.SetItemString(li_Row2, "ypshrsfys", "0");
                    dw_2.SetItemString(li_Row2, "ypshryslx", query.sb_ypshryslx);


                        if (string.IsNullOrEmpty(jysj.sbxp_no))
                        {
                            //20150721
                          
                            if (recept == 0)
                            {

                                dw_1.SetItemString(li_Row, "bhcfybz", "0");
                               // modifydw(0);
                            }
                            else
                            {
                                //20180209
                                DialogResult dialogResultr = MessageBox.Show("你的品种里含有处方药，你是否添加处方信息？", "提示", MessageBoxButtons.YesNo);
                                if (dialogResultr == DialogResult.Yes)
                                {
                                    dw_1.SetItemString(li_Row, "bhcfybz", "1");
                                }
                                else if (dialogResultr == DialogResult.No)
                                {
                                    dw_1.SetItemString(li_Row, "bhcfybz", "0");
                                }
                              //  modifydw(1);
                            }
                           

                            //dw_1.SetItemString(li_Row, "bhcfybz", "0");
                            //modifydw(0);
                            //


                        }
                        else
                        {
                            dw_1.SetItemString(li_Row, "bhcfybz", jysj.sbcfbz);
                            dw_1.SetItemString(li_Row, "jyckh", jysj.sbxp_no);

                            if (!string.IsNullOrEmpty(jysj.sbxp_jysj))
                            {
                                DateTime dectemp;
                                if (DateTime.TryParseExact(jysj.sbxp_jysj.Trim(), "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dectemp))
                                {
                                    dw_1.SetItemDateTime(li_Row, "posjysj", dectemp);
                                }
                                else
                                {
                                    throw new Exception("解释POS交易时间时出错");
                                }
                            }

                            

                            if (!string.IsNullOrEmpty(jysj.sbcf_bh))
                            {
                                dw_2.SetItemString(li_Row2, "cfbh", jysj.sbcf_bh);
                            }
                            if (!string.IsNullOrEmpty(jysj.sbcfkjjgmc))
                            {
                                dw_2.SetItemString(li_Row2, "cfkjjgmc", jysj.sbcfkjjgmc);
                            }
                            if (!string.IsNullOrEmpty(jysj.sbcfjgsfjggz))
                            {
                                dw_2.SetItemString(li_Row2, "jgsfjggz", jysj.sbcfjgsfjggz);
                            }
                            if (!string.IsNullOrEmpty(jysj.sbcfzd))
                            {
                                dw_2.SetItemString(li_Row2, "zd", jysj.sbcfzd);
                            }

                            if (jysj.sbcfrq != null)
                            {
                              //  dw_2.SetItemDecimal(li_Row, "cfrq", jysj.sbcfrq ?? 0.0M);

                                 DateTime datetemp;
                                 if (DateTime.TryParseExact(jysj.sbcfrq.ToString(), "yyyyMMdd",CultureInfo.InvariantCulture,DateTimeStyles.None, out  datetemp))
                                 {
                                     dw_2.SetItemDate(li_Row2, "cfrq", datetemp);
                                 }
                                 else
                                 {
                                     throw new Exception("解释处方时间时出错");
                                 }

                            }

                            if (!string.IsNullOrEmpty(jysj.sbcfysxm))
                            {
                                dw_2.SetItemString(li_Row2, "cfysxm", jysj.sbcfysxm);
                            }


                        }


                        int y = 0;
                        thelistno = val;
                        foreach (var q in qinv)
                        {
                            y++;
                            string theprodno = q.prodno;
                            string thebatchno = q.batchno;
                            string theprodadd = q.prodadd;
                            decimal suminvq = (from n in db.inv_sub
                                               where n.prod_no.Trim() == theprodno.Trim() && n.batch_no.Trim() == thebatchno.Trim() && n.prod_add.Trim() == theprodadd.Trim() && n.list_no.Trim() != val.Trim()
                                               join gp in db.inv_main
                                               on n.list_no equals gp.list_no into joininvgroup
                                               from gp in joininvgroup.DefaultIfEmpty()
                                               where gp.inv_date <= jysj.inv_date
                                               select (decimal?)n.inv_num).Sum() ?? 0;

                            //20151203
                            decimal sumbackq = (from n in db.back_sub
                                                where n.prod_no.Trim() == theprodno.Trim() && n.batch_no.Trim() == thebatchno.Trim() && n.prod_add.Trim() == theprodadd.Trim()
                                                join gp in db.back_main
                                                on n.back_no equals gp.back_no into joininvgroup
                                                from gp in joininvgroup.DefaultIfEmpty()
                                                where gp.back_date <= jysj.inv_date
                                                select (decimal?)n.back_num).Sum() ?? 0;


                            suminvq = suminvq - sumbackq;
                            //

                            decimal sumdepq = (from dp in db.prod_dep
                                               where dp.prod_no.Trim() == q.prodno.Trim()
                                               select (decimal?)dp.lest_num).Sum() ?? 0;



                            string lastdepno = "";

                            var qdeps = from ds in db.dep_sub
                                        where ds.prod_no.Trim() == theprodno.Trim() && ds.batch_no.Trim() == thebatchno.Trim() && ds.prod_add.Trim() == theprodadd.Trim()
                                        join gpdm in db.dep_main
                                        on ds.dep_no equals gpdm.dep_no into joindepgroup
                                        from gpdm in joindepgroup.DefaultIfEmpty()
                                        where gpdm.dep_date <= jysj.inv_date
                                        select new { ds.dep_no, ds.dep_num };

                            listerr.Clear();
                            decimal suminvqorg = suminvq;
                            decimal sumdepnum = 0;
                            int querycount = qdeps.Count();

                            int i = 0;
                            foreach (var qdep in qdeps)
                            {
                                i++;
                                sumdepnum = sumdepnum + qdep.dep_num;
                                suminvq = suminvq - qdep.dep_num;
                                if (suminvq <= 0)
                                {
                                    lastdepno = qdep.dep_no;
                                    break;
                                }

                                if (i == querycount && suminvq > qdep.dep_num)
                                {
                                    lastdepno = qdep.dep_no;

                                    globalvariable.prodinerror pe = new globalvariable.prodinerror
                                    {
                                        prodno = theprodno,
                                        batchno = thebatchno,
                                        prodadd = theprodadd,
                                        prodname = q.prodname,
                                        lastdepno = lastdepno,
                                        invnum = suminvqorg,
                                        depnum = sumdepnum,
                                        description = "销售总数大于进仓总数不合逻辑",
                                        addition = false
                                    };

                                    listerr.Add(pe);
                                }

                            }


                            //添加gridview列
                            int index = griddetail.Rows.Add();
                            griddetail.Rows[index].Cells[0].Value = y.ToString();
                            griddetail.Rows[index].Cells[1].Value = q.barcode;
                            griddetail.Rows[index].Cells[2].Value = theprodno;
                            griddetail.Rows[index].Cells[3].Value = q.zyps_bm;
                            griddetail.Rows[index].Cells[4].Value = String.Format("{0:yyyyMMddHHmmss}", q.invdatesb);
                            griddetail.Rows[index].Cells[5].Value = q.prodname;
                            //20171207
                            griddetail.Rows[index].Cells[6].Value = q.prodname;
                            //\\
                            //20161228
                            /* DataGridViewComboBoxCell newCb = new DataGridViewComboBoxCell();
                             newCb.Items.Add("是");
                             newCb.Items.Add("否");
                             griddetail.Rows[index].Cells[7] = newCb;
                             //*/

                            //20150721

                            if (q.recipe == true)
                            {
                                griddetail.Rows[index].Cells[7].Value = "是";
                                griddetail.Rows[index].Cells[7].Style.ForeColor = Color.Red;


                            }
                            else
                            {
                                griddetail.Rows[index].Cells[7].Value = "否";


                            }

                            //20160526
                            globalvariable gl = new globalvariable();
                            griddetail.Rows[index].Cells[8].Value = gl.getcat(q.prodno);
                            //
                            griddetail.Rows[index].Cells[9].Value = q.prodsize;
                            griddetail.Rows[index].Cells[10].Value = q.monad;

                            if (string.IsNullOrEmpty(q.batchno.Trim()))
                            {
                                griddetail.Rows[index].Cells[11].Value = "无";
                                griddetail.Rows[index].Cells[11].Style.BackColor = Color.Red;
                            }
                            else
                                griddetail.Rows[index].Cells[11].Value = q.batchno;



                            griddetail.Rows[index].Cells[12].Value = String.Format("{0:yyyyMM}", q.availdate);

                            if (string.IsNullOrEmpty(q.prodadd.Trim()))
                            {
                                griddetail.Rows[index].Cells[13].Value = "无";
                                griddetail.Rows[index].Cells[13].Style.BackColor = Color.Red;
                               
                            }
                            else
                            
                                griddetail.Rows[index].Cells[13].Value = q.prodadd;

                            //20171208
                            griddetail.Rows[index].Cells[24].Value = q.ifprodmade.ToString();

                            //
                            griddetail.Rows[index].Cells[14].Value = query.sb_ghdw;
                            griddetail.Rows[index].Cells[15].Value = q.lastdepno;


                            griddetail.Rows[index].Cells[16].Value = q.sellprice;

                            griddetail.Rows[index].Cells[17].Value = q.invnum;

                            griddetail.Rows[index].Cells[18].Value = q.sellmon;
                            griddetail.Rows[index].Cells[19].Value = sumdepq + q.invnum;
                            griddetail.Rows[index].Cells[20].Value = sumdepq;

                            griddetail.Rows[index].Cells[21].Value = "备注1";
                            griddetail.Rows[index].Cells[22].Value = "备注2";
                            griddetail.Rows[index].Cells[23].Value = "备注3";
                            /// griddetail.Rows[index].Cells[15].Value = "";




                            //

                        }

                        if (listerr.Count() != 0)
                        {
                            FormCollection fc = Application.OpenForms;

                            foreach (Form myfrm in fc)
                            {
                                if (myfrm.Name == "warningForm")
                                    myfrm.Close();
                            }

                            warningForm theform = new warningForm(listerr);
                            theform.Show();
                        }



                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误：" + ex.ToString());
                globalvariable glv = new globalvariable();
                glv.LogWrite("SP3_4001" + ex.ToString());
            }

        }

        private void btnexit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result3 = MessageBox.Show("真的要退出吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result3 == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnreset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result3 = MessageBox.Show("确认要重填吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result3 == DialogResult.Yes)
            {
                forminitial();
            }
        }

        private void IndividalChargeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                adoTrans.UnbindConnection();
                dbConn.Close();
            }
            catch
            {
            }

        }

        private int forminitial()
        {
            try
            {
                dw_1.Reset();
                dw_2.Reset();
              /*  txtyptjrxm.Text = "";
                txtyptjrslx.Text = "";
                txtypshrxm.Text = "";
                txtypshryslx.Text = "";*/
                gridwillcharge.DataSource = null;
                gridchargeamout.DataSource = null;

                griddetail.DataSource = null;
                gridwillcharge.Rows.Clear();
                gridchargeamout.Rows.Clear();
                griddetail.Rows.Clear();


                gridwillcharge.ColumnCount = 3;
                gridwillcharge.Columns[0].HeaderText = "挂号号码";
                gridwillcharge.Columns[1].HeaderText = "姓名";
                gridwillcharge.Columns[2].HeaderText = "诊号";
                DataGridViewColumn column = gridwillcharge.Columns[0];
                column.Width = 50;
                column = gridwillcharge.Columns[1];
                column.Width = 50;
                column = gridwillcharge.Columns[2];
                column.Width = 50;
                gridchargeamout.ColumnCount = 2;
                gridchargeamout.Columns[0].HeaderText = "费用名称";
                gridchargeamout.Columns[1].HeaderText = "费用";
                column = gridchargeamout.Columns[0];
                column.Width = 50;
                column = gridchargeamout.Columns[1];
                column.Width = 50;

                griddetail.ColumnCount = 25;

                griddetail.Columns[0].HeaderText = "明细ID(序号)";
                griddetail.Columns[0].ReadOnly = true;

                griddetail.Columns[1].HeaderText = "条型码";
                griddetail.Columns[1].ReadOnly = true;

                griddetail.Columns[2].HeaderText = "项目唯一ID(药品编码)";
                griddetail.Columns[2].ReadOnly = true;
                griddetail.Columns[3].HeaderText = "中药配送药品编码";
                griddetail.Columns[3].ReadOnly = true;

                griddetail.Columns[4].HeaderText = "销售时间";
                griddetail.Columns[4].ReadOnly = true;


                griddetail.Columns[5].HeaderText = "项目名称(名称)";
                griddetail.Columns[5].ReadOnly = true;
                griddetail.Columns[6].HeaderText = "药品通用名称";
                griddetail.Columns[6].ReadOnly = true;

                griddetail.Columns[7].HeaderText = "处方药（仅作参考用）";
                // griddetail.Columns[7].ReadOnly = true;


                griddetail.Columns[8].HeaderText = "剂型";
                griddetail.Columns[8].ReadOnly = false;
                griddetail.Columns[9].HeaderText = "规格";
                griddetail.Columns[9].ReadOnly = true;
                griddetail.Columns[10].HeaderText = "单位";
                griddetail.Columns[10].ReadOnly = true;
                griddetail.Columns[11].HeaderText = "批号";
                griddetail.Columns[11].ReadOnly = true;

                griddetail.Columns[12].HeaderText = "有效期(年月)";
                griddetail.Columns[12].ReadOnly = true;
                //   griddetail.Columns[12].DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" };
                griddetail.Columns[13].HeaderText = "生产厂商(生产厂家)";
                griddetail.Columns[13].ReadOnly = true;
                griddetail.Columns[14].HeaderText = "购货单位";
                griddetail.Columns[14].ReadOnly = true;


                //20150721
                griddetail.Columns[15].HeaderText = "入库单号";
                griddetail.Columns[15].ReadOnly = true;

                //
                griddetail.Columns[16].HeaderText = "单价";
                griddetail.Columns[16].ReadOnly = true;
                griddetail.Columns[16].DefaultCellStyle.Format = "N2";

                griddetail.Columns[17].HeaderText = "数量";
                griddetail.Columns[17].ReadOnly = true;

                griddetail.Columns[18].HeaderText = "金额";
                griddetail.Columns[18].ReadOnly = true;
                griddetail.Columns[18].DefaultCellStyle.Format = "N2";

                griddetail.Columns[19].HeaderText = "销售前库存量";
                griddetail.Columns[19].ReadOnly = true;
                griddetail.Columns[20].HeaderText = "销售后库存量";
                griddetail.Columns[20].ReadOnly = true;

                griddetail.Columns[21].HeaderText = "备注1";
                griddetail.Columns[21].ReadOnly = false;

                griddetail.Columns[22].HeaderText = "备注2";
                griddetail.Columns[22].ReadOnly = false;

                griddetail.Columns[23].HeaderText = "备注3";
                griddetail.Columns[23].ReadOnly = false;

                griddetail.Columns[24].HeaderText = "";
                griddetail.Columns[24].ReadOnly = false;


                column = griddetail.Columns[0];
                column.Width = 80;
                column = griddetail.Columns[1];
                column.Width = 100;
                column = griddetail.Columns[2];
                column.Width = 80;
                column = griddetail.Columns[3];
                column.Width = 80;
                column = griddetail.Columns[4];
                column.Width = 100;
                column = griddetail.Columns[5];
                column.Width = 150;
                column = griddetail.Columns[6];
                column.Width = 150;
                column = griddetail.Columns[7];
                column.Width = 100;
                column = griddetail.Columns[8];
                column.Width = 100;
                column = griddetail.Columns[9];
                column.Width = 100;
                column = griddetail.Columns[10];
                column.Width = 50;
                column = griddetail.Columns[11];
                column.Width = 80;
                column = griddetail.Columns[12];
                column.Width = 100;
                column = griddetail.Columns[13];
                column.Width = 220;
                column = griddetail.Columns[14];
                column.Width = 250;
                column = griddetail.Columns[15];
                column.Width = 120;
                column = griddetail.Columns[16];
                column.Width = 80;
                column = griddetail.Columns[17];
                column.Width = 80;
                column = griddetail.Columns[18];
                column.Width = 80;
                column = griddetail.Columns[19];
                column.Width = 80;
                column = griddetail.Columns[20];
                column.Width = 80;
                column = griddetail.Columns[21];
                column.Width = 100;
                column = griddetail.Columns[22];
                column.Width = 100;
                column = griddetail.Columns[23];
                column.Width = 100;
                column = griddetail.Columns[24];
                column.Width = 10;

                griddetail.ScrollBars = ScrollBars.Both;

                sb_cardnoforupload="";
                sb_idnoforupload="";
                sb_cardno = "";
                sb_idno="";
                currentclino = "";
                return 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误：" + ex.ToString());
                globalvariable glv = new globalvariable();
                glv.LogWrite("SP3_4001" + ex.ToString());
                return -1;
            }


        }

        private void btnupload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dw_1.AcceptText();
            dw_2.AcceptText();

            if (dw_1.RowCount == 0)
                return;

            DialogResult result3 = MessageBox.Show("真的要提交吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result3 == DialogResult.Yes)
            {
                int havecount = 0;
                string ReturnValue = dw_1.GetItemString(dw_1.RowCount, "list_no");
                try
                {
                    using (lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + "; Connect Timeout=180;"))
                    {
                        db.CommandTimeout = 300;
                        havecount = (from d in db.inv_main
                                     where d.list_no.Trim() == ReturnValue.Trim() && d.JKSCBZ == '1'
                                     select d).Count();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("发生错误：" + ex.ToString());
                    return;
                }
                if (havecount > 0)
                {

                    DialogResult result2 = MessageBox.Show("这张单已经上传过社保局，你确认要再上传吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result2 == DialogResult.No)
                        return;
                    else
                    {
                        globalvariable glv = new globalvariable();
                        glv.LogWrite("SP3_4001 list_no:" + ReturnValue + "重复上传");

                    }
                }

                string therecipt = dw_1.GetItemString(dw_1.RowCount, "bhcfybz").Trim();
                if (checkerror(therecipt) < 0)
                {
                    if (listerr.Where(o => o.addition == true).Count() > 0)
                    {
                        FormCollection fc = Application.OpenForms;

                        foreach (Form myfrm in fc)
                        {
                            if (myfrm.Name == "warningForm")
                                myfrm.Close();
                        }

                        warningForm theform = new warningForm(listerr);
                        theform.Show();
                        if (listerr.Where(o => o.addition == true && o.thelevel == "错误").Count() > 0)
                            return;
                    }
                }
                else
                {
                    if (listerr.Where(o => o.addition == false).Count() > 0)
                    {
                        DialogResult result = MessageBox.Show("你有某些数据不合符逻辑，是否仍然要传上社保局呢？程序会在同意后继续", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.No)
                            return;
                    }
                    //   decimal invmon = 0;
                    int mycount = griddetail.Rows.Count - 1;
                    YBGZJSXX[] ybzj = new YBGZJSXX[mycount];



                    for (int thecount = 0; thecount < mycount; thecount++)
                    {
                        ybzj[thecount] = new YBGZJSXX();
                        ybzj[thecount].MXID = (thecount + 1).ToString();

                        string myprodno = griddetail.Rows[thecount].Cells[2].Value.ToString().Trim();

                        //20150727
                        if (myprodno.Substring(0, 1) == "3")
                            ybzj[thecount].TXM = "";
                        else if (griddetail.Rows[thecount].Cells[1].Value != null)
                            ybzj[thecount].TXM = griddetail.Rows[thecount].Cells[1].Value.ToString().Trim();
                        else
                            ybzj[thecount].TXM = "";
                        //
                        //20150522注释
                        /*
                          if ( myprodno.Substring(0,1)=="3")
                              ybzj[thecount].XMWYID = griddetail.Rows[thecount].Cells[2].Value.ToString().Trim();
                          else
                              ybzj[thecount].XMWYID = griddetail.Rows[thecount].Cells[1].Value.ToString().Trim();
                         */
                        ybzj[thecount].XMWYID = myprodno.Trim();

                        //20151204
                        string issbnewrule = "0";
                        try
                        {
                            using (lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + "; Connect Timeout=180;"))
                            {
                                db.CommandTimeout = 10 * 60;
                                issbnewrule = (from k in db.inv_main
                                               where k.list_no.Trim() == ReturnValue.Trim()
                                               select k.is_sb_new).FirstOrDefault().ToString();

                            }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("发生错误：" + ex.ToString());
                            globalvariable glv = new globalvariable();
                            glv.LogWrite("SP3_4001 " + ex.ToString());
                            return;
                        }

                        //

                        if (issbnewrule != "0")
                            ybzj[thecount].XSSJ = griddetail.Rows[thecount].Cells[4].Value.ToString().Trim();
                        else
                        {
                            DateTime dt = dw_1.GetItemDateTime(dw_1.RowCount, "posjysj");
                            ybzj[thecount].XSSJ = dt.ToString("yyyyMMddHHmmss");
                        }
                        ybzj[thecount].XMMC = griddetail.Rows[thecount].Cells[5].Value.ToString().Trim();
                        //20150529修改过
                        //  ybzj[thecount].YPTYMC = "";
                        //  ybzj[thecount].JX = "";
                        //  ybzj[thecount].GG = "";
                        ybzj[thecount].YPTYMC = griddetail.Rows[thecount].Cells[5].Value.ToString().Trim();
                        //20160520
                        ybzj[thecount].JX = griddetail.Rows[thecount].Cells[8].Value.ToString().Trim();
                        //
                        ybzj[thecount].GG = griddetail.Rows[thecount].Cells[9].Value.ToString().Trim();
                        //\\
                        string mybatchno = griddetail.Rows[thecount].Cells[11].Value.ToString().Trim();
                        ybzj[thecount].PH = mybatchno;

                        string myprodadd = griddetail.Rows[thecount].Cells[13].Value.ToString().Trim();
                        string supply = griddetail.Rows[thecount].Cells[14].Value.ToString().Trim();

                        //20170814



                        ybzj[thecount].YXQ = griddetail.Rows[thecount].Cells[12].Value.ToString();

                        //\\

                        ybzj[thecount].SCCS = myprodadd;

                        if (string.IsNullOrEmpty(supply))
                        {
                            MessageBox.Show("客户资料供应商没填，请在公司资料里填上，程序终止");
                            return;
                        }

                        ybzj[thecount].GHDW = supply.Trim();
                        ybzj[thecount].RKDH = griddetail.Rows[thecount].Cells[15].Value.ToString();
                        decimal dectemp;
                        if (decimal.TryParse(griddetail.Rows[thecount].Cells[16].Value.ToString().Trim(), out dectemp))
                        {
                            ybzj[thecount].DJ = Math.Round(dectemp, 2).ToString();
                        }
                        else
                        {
                            int anycount = thecount + 1;
                            MessageBox.Show("第" + anycount.ToString() + "发生错误：单价解释出错，程序终止");
                            globalvariable glv = new globalvariable();
                            glv.LogWrite("SP3_4001 第" + anycount.ToString() + "发生错误：单价解释出错");
                            return;
                        }

                        if (decimal.TryParse(griddetail.Rows[thecount].Cells[17].Value.ToString().Trim(), out dectemp))
                        {
                            ybzj[thecount].SL = Math.Round(dectemp, 3).ToString();
                        }
                        else
                        {
                            int anycount = thecount + 1;
                            MessageBox.Show("第" + anycount.ToString() + "发生错误：数量解释出错，程序终止");
                            globalvariable glv = new globalvariable();
                            glv.LogWrite("SP3_4001 第" + anycount.ToString() + "发生错误：数量解释出错");
                            return;

                        }

                        if (decimal.TryParse(griddetail.Rows[thecount].Cells[18].Value.ToString().Trim(), out dectemp))
                        {
                            ybzj[thecount].JE = Math.Round(dectemp, 3).ToString();
                        }
                        else
                        {
                            int anycount = thecount + 1;
                            MessageBox.Show("第" + anycount.ToString() + "发生错误：金额解释出错，程序终止");
                            globalvariable glv = new globalvariable();
                            glv.LogWrite("SP3_4001 第" + anycount.ToString() + "发生错误：金额解释出错");
                            return;
                        }

                        if (decimal.TryParse(griddetail.Rows[thecount].Cells[19].Value.ToString().Trim(), out dectemp))
                        {
                            ybzj[thecount].XSQKCL = Math.Round(dectemp, 3).ToString();
                        }
                        else
                        {
                            int anycount = thecount + 1;
                            MessageBox.Show("第" + anycount.ToString() + "发生错误：销售前库存量解释出错，程序终止");
                            globalvariable glv = new globalvariable();
                            glv.LogWrite("SP3_4001 第" + anycount.ToString() + "发生错误：销售前库存量解释出错");
                            return;
                        }

                        if (decimal.TryParse(griddetail.Rows[thecount].Cells[20].Value.ToString().Trim(), out dectemp))
                        {
                            ybzj[thecount].XSHKCL = Math.Round(dectemp, 3).ToString();
                        }
                        else
                        {
                            int anycount = thecount + 1;
                            MessageBox.Show("第" + anycount.ToString() + "发生错误：销售后库存量解释出错，程序终止");
                            globalvariable glv = new globalvariable();
                            glv.LogWrite("SP3_4001 第" + anycount.ToString() + "发生错误：销售后库存量解释出错");
                            return;
                        }
                        //20150529修改过
                        //    ybzj[thecount].BZ1 = "";
                        //    ybzj[thecount].BZ2 = "";
                        //   ybzj[thecount].BZ3 = "";
                        //
                        ybzj[thecount].BZ1 = griddetail.Rows[thecount].Cells[21].Value.ToString();
                        ybzj[thecount].BZ2 = griddetail.Rows[thecount].Cells[22].Value.ToString();
                        ybzj[thecount].BZ3 = griddetail.Rows[thecount].Cells[23].Value.ToString();
                    }

                    YBGZCFXX[] ybgz = new YBGZCFXX[1];
                    ybgz[0] = new YBGZCFXX();
                    if (dw_1.GetItemString(dw_1.RowCount, "bhcfybz").Trim() == "1")
                    {


                        if (dw_2.IsItemNull(dw_2.RowCount, "cfbh"))
                        {
                            ybgz[0].CFBH = "";
                        }
                        else
                        {
                            ybgz[0].CFBH = dw_2.GetItemString(dw_2.RowCount, "cfbh").Trim();
                        }
                        if (dw_2.IsItemNull(dw_2.RowCount, "cfkjjgmc"))
                        {
                            ybgz[0].CFKJJGMC = "";
                        }
                        else
                        {
                            ybgz[0].CFKJJGMC = dw_2.GetItemString(dw_2.RowCount, "cfkjjgmc").Trim();
                        }
                        if (dw_2.IsItemNull(dw_2.RowCount, "jgsfjggz"))
                        {
                            ybgz[0].JGSFJGGZ = "";
                        }
                        else
                        {
                            ybgz[0].JGSFJGGZ = dw_2.GetItemString(dw_2.RowCount, "jgsfjggz").Trim();
                        }

                        if (dw_2.IsItemNull(dw_2.RowCount, "cfrq"))
                        {
                            ybgz[0].CFRQ = DateTime.Now.ToString("yyyyMMdd");
                        }
                        else
                        {
                            DateTime dt = dw_2.GetItemDateTime(dw_2.RowCount, "cfrq");
                            ybgz[0].CFRQ = dt.ToString("yyyyMMdd");
                        }


                        if (dw_2.IsItemNull(dw_2.RowCount, "zd"))
                        {
                            ybgz[0].ZD = "";
                        }
                        else
                        {
                            ybgz[0].ZD = dw_2.GetItemString(dw_2.RowCount, "zd").Trim();
                        }

                        if (dw_2.IsItemNull(dw_2.RowCount, "cfysxm"))
                        {
                            ybgz[0].CFYSXM = "";
                        }
                        else
                        {
                            ybgz[0].CFYSXM = dw_2.GetItemString(dw_2.RowCount, "cfysxm").Trim();
                        }
                        ///2015327begin
                        string sbcf_bh = ybgz[0].CFBH;
                        string sbcfkjjgmc = ybgz[0].CFKJJGMC;
                        string sbcfjgsfjggz = ybgz[0].JGSFJGGZ;
                        string sbcfrq = ybgz[0].CFRQ.ToString();
                        string sbcfzd = ybgz[0].ZD;
                        string sbcfysxm = ybgz[0].CFYSXM;

                        //end
                    /*    ybgz[0].YPTJRXM = txtyptjrxm.Text.Trim();

                        if (comboxyprjtsfys.Text == "1是")
                            ybgz[0].YPTJRSFYS = "1";
                        else
                            ybgz[0].YPTJRSFYS = "0";
                        ybgz[0].YPTJRYSLX = txtyptjrslx.Text.Trim();
                        ybgz[0].YPSHRXM = txtypshrxm.Text.Trim();

                        if (comboxypshrsfys.Text == "1是")
                            ybgz[0].YPSHRSFYS = "1";
                        else
                            ybgz[0].YPSHRSFYS = "0";

                        ybgz[0].YPSHRYSLX = txtypshryslx.Text.Trim();
                     */
                        ybgz[0].YPTJRXM = dw_2.GetItemString(dw_2.RowCount, "yptjrxm");
                        ybgz[0].YPTJRSFYS = dw_2.GetItemString(dw_2.RowCount, "yprjtsfys");
                        ybgz[0].YPTJRYSLX = dw_2.GetItemString(dw_2.RowCount, "yptjrslx");
                        ybgz[0].YPSHRXM = dw_2.GetItemString(dw_2.RowCount, "ypshrxm");
                        ybgz[0].YPSHRSFYS = dw_2.GetItemString(dw_2.RowCount, "ypshrsfys");
                        ybgz[0].YPSHRYSLX = dw_2.GetItemString(dw_2.RowCount, "ypshryslx");

                    }
                    else
                    {
                        ybgz[0].CFBH = "";
                        ybgz[0].CFKJJGMC = "";
                        ybgz[0].JGSFJGGZ = "";
                        ybgz[0].CFRQ = "";
                        ybgz[0].ZD = "";
                        ybgz[0].CFYSXM = "";
                        ybgz[0].YPTJRXM = "";
                        ybgz[0].YPTJRSFYS = "";
                        ybgz[0].YPTJRYSLX = "";
                        ybgz[0].YPSHRXM = "";
                        ybgz[0].YPSHRSFYS = "";
                        ybgz[0].YPSHRYSLX = "";

                        if (recept > 0)
                        {
                            DialogResult result = MessageBox.Show("你上传药品中有处方药，你是否上传？程序会在同意后继续，为了保障权益，程序可能会把这次记录下来，敬请谅解", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.No)
                            {
                                try
                                {

                                    using (lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;"))
                                    {
                                        db.CommandTimeout = 10 * 60;
                                        sb_recipe_records_new sbrec = new sb_recipe_records_new()
                                        {
                                            list_no = ReturnValue.Trim(),
                                            sfcf = "1",
                                            sfsc = "0",
                                            upload_time = db.GetSystemDate()
                                        };
                                        db.sb_recipe_records_new.InsertOnSubmit(sbrec);
                                        db.SubmitChanges();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("发生错误:" + ex.ToString());
                                    globalvariable glv = new globalvariable();
                                    glv.LogWrite("SP3_4001 保存处方药上传时出错:" + ex.ToString());
                                }
                                return;
                            }

                        }

                    }

                    //20150529
                    //   ybgz[0].BZ1 = "";
                    //   ybgz[0].BZ2 = "";
                    //  ybgz[0].BZ3 = "";

                    //20160520

                    if (dw_2.IsItemNull(dw_2.RowCount, "ybmemo1"))
                        ybgz[0].BZ1 = "备注1";
                    else
                        ybgz[0].BZ1 = dw_2.GetItemString(dw_2.RowCount, "ybmemo1").Trim();


                    if (dw_2.IsItemNull(dw_2.RowCount, "ybmemo2"))
                        ybgz[0].BZ2 = "备注2";
                    else
                        ybgz[0].BZ2 = dw_2.GetItemString(dw_2.RowCount, "ybmemo2").Trim();

                    if (dw_2.IsItemNull(dw_2.RowCount, "ybmemo3"))
                        ybgz[0].BZ3 = "备注3";
                    else
                        ybgz[0].BZ3 = dw_2.GetItemString(dw_2.RowCount, "ybmemo3").Trim();

                    //
                    //


                    //20160309start
                    string memostr1 = "";
                    string memostr2 = "";
                    string memostr3 = "";

                    bool? ischecked = (bool?)checkbox.EditValue;
                    if (ischecked.HasValue)
                    {
                        //  memostr = "备注：这是补上传";
                        dw_1.SetItemString(dw_1.RowCount, "memo1", "备注：这是补上传");

                    }

                    //20160520
                    if (dw_1.IsItemNull(dw_1.RowCount, "memo1"))
                        memostr1 = "备注1";
                    else
                        memostr1 = dw_1.GetItemString(dw_1.RowCount, "memo1").Trim();

                    if (dw_1.IsItemNull(dw_1.RowCount, "memo2"))
                        memostr2 = "备注2";
                    else
                        memostr2 = dw_1.GetItemString(dw_1.RowCount, "memo2").Trim();

                    if (dw_1.IsItemNull(dw_1.RowCount, "memo3"))
                        memostr3 = "备注3";
                    else
                        memostr3 = dw_1.GetItemString(dw_1.RowCount, "memo3").Trim();

                    //


                    DateTime mydt = dw_1.GetItemDateTime(dw_1.RowCount, "posjysj");
                   

                    //20160309end
                    HashParams hp = new HashParams
                    {
                        JBR = globalvariable.JBR,
                        JBRQ = String.Format("{0:yyyyMMddHHmmss}", DateTime.Now),
                        YYBH = globalvariable.YYBH,
                        CLIENTTYPE = globalvariable.CLIENTTYPE,
                        JYCKH = dw_1.GetItemString(dw_1.RowCount, "jyckh").Trim(),
                        JYLX = dw_1.GetItemString(dw_1.RowCount, "jylx").Trim(),
                        SFZHM = dw_1.GetItemString(dw_1.RowCount, "sfzhm").Trim(),
                        POSJYSJ = mydt.ToString("yyyyMMddHHmmss"),
                        SHH = dw_1.GetItemString(dw_1.RowCount, "sb_ssh").Trim(),
                        ZDBH = dw_1.GetItemString(dw_1.RowCount, "sb_zdbh").Trim(),
                        BHCFYBZ = dw_1.GetItemString(dw_1.RowCount, "bhcfybz").Trim(),

                        //20150529
                        //  BZ1="",
                        //  BZ2="",
                        //  BZ3="",
                        //

                        //20160308
                        //BZ1 = "备注1",

                        BZ1 = memostr1,
                        //
                        BZ2 = memostr2,
                        BZ3 = memostr3,
                        //
                        FN = "SP3_4001",
                        POSJYJE = Math.Round(dw_1.GetItemDecimal(dw_1.RowCount, "posyjje"), 2).ToString(),
                        SESSIONID = globalvariable.SESSIONID
                    };

                    DataPackage dp = new DataPackage
                    {
                        YBGZCFXX = ybgz,
                        YBGZJSXX = ybzj
                    };

                    SampleResponse1 sr = new SampleResponse1
                    {
                        DataPackage = dp,
                        HashParams = hp
                    };
                    try
                    {
                        string json = JsonConvert.SerializeObject(sr);
                        globalvariable gv = new globalvariable();
                        string expcemsg = "";
                        string YWLSH = "";
                        string sbcf_bh = "";
                        string sbcfkjjgmc = "";
                        string sbcfjgsfjggz = "";
                        string sbcfrq = "";
                        string sbcfzd = "";
                        string sbcfysxm = "";
                        int myresult = gv.postoweb(json, globalvariable.webfunc, ref expcemsg, ref YWLSH);
                        if (myresult == 0)
                        {
                            try
                            {
                                using (lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;"))
                                {
                                    db.CommandTimeout = 10 * 60;
                                    string sblsh = (from im in db.inv_main
                                                    where im.list_no.Trim() == thelistno.Trim()
                                                    select im.SBWLSH).FirstOrDefault();

                                    if (!string.IsNullOrEmpty(sblsh))
                                    {
                                        DialogResult result2 = MessageBox.Show("这张单好像上传过的，你是否保存？程序会在同意后继续", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                        if (result2 == DialogResult.No)
                                            return;
                                    }
                                    var query = from im in db.inv_main
                                                where im.list_no.Trim() == thelistno.Trim()
                                                select im;
                                    foreach (var q in query)
                                    {
                                        q.SBWLSH = YWLSH;
                                        q.JKSCBZ = '1';
                                        q.JKSCSZ = db.GetSystemDate();
                                        q.sbcfbz = dw_1.GetItemString(dw_1.RowCount, "bhcfybz").Trim();
                                        q.sbzdbh = dw_1.GetItemString(dw_1.RowCount, "sb_zdbh").Trim();
                                        q.sb_ssh = dw_1.GetItemString(dw_1.RowCount, "sb_ssh").Trim();
                                        q.SB_BZ1 = memostr1;
                                        q.SB_BZ2 = memostr2;
                                        q.SB_BZ3 = memostr3;
                                        //20190809
                                        q.updSFZHM = dw_1.GetItemString(dw_1.RowCount, "sfzhm").Trim();
                                        //\\
                                        //20191118
                                        q.sb_uploadchooseidsbcard = char.Parse(dw_1.GetItemString(dw_1.RowCount, "selectidorsbcard"));
                                        //\\
                                        if (dw_1.IsItemNull(dw_1.RowCount, "xslx"))
                                        {
                                            q.sbxslx = null;
                                        }
                                        else
                                        {
                                            char tempchar;
                                            if (char.TryParse(dw_1.GetItemString(dw_1.RowCount, "xslx").Trim(), out tempchar))
                                                q.sbxslx = tempchar;
                                            else
                                                q.sbxslx = null;
                                        }

                                        if (q.sbcfbz == "1")
                                        {
                                            q.sbcf_bh = ybgz[0].CFBH;
                                            q.sbcfkjjgmc = ybgz[0].CFKJJGMC;
                                            q.sbcfjgsfjggz = ybgz[0].JGSFJGGZ;
                                            decimal dectemp;
                                            if (decimal.TryParse(ybgz[0].CFRQ.Trim(), out dectemp))
                                                q.sbcfrq = dectemp;
                                            else
                                            {
                                                throw new Exception("保存社保附加消息到销售主表时解释处方日期时出错:" + ybgz[0].CFRQ.Trim());
                                            }

                                            q.sbcfzd = ybgz[0].ZD;
                                            q.sbcfysxm = ybgz[0].CFYSXM;
                                            q.SB_CFBZ1 = ybgz[0].BZ1;
                                            q.SB_CFBZ2 = ybgz[0].BZ2;
                                            q.SB_CFBZ3 = ybgz[0].BZ3;

                                        }
                                        else
                                        {
                                            //20150721
                                            if (recept > 0)
                                            {
                                                q.sb_sc_recipe = '1';
                                                sb_recipe_records_new sbrec = new sb_recipe_records_new()
                                                {
                                                    list_no = ReturnValue.Trim(),
                                                    sfcf = "1",
                                                    sfsc = "1",
                                                    upload_time = db.GetSystemDate()
                                                };
                                                db.sb_recipe_records_new.InsertOnSubmit(sbrec);
                                            }

                                            //
                                        }
                                        q.sbxp_no = dw_1.GetItemString(dw_1.RowCount, "jyckh").Trim();
                                        q.sbxp_jysj = mydt.ToString("yyyyMMddHHmmss");



                                    }

                                    //

                                    for (int thecount = 0; thecount < mycount; thecount++)
                                    {
                                        var myquery = from ivs in db.inv_sub
                                                      where ivs.list_no.Trim() == thelistno.Trim() && ivs.prod_no.Trim() == ybzj[thecount].XMWYID.Trim()
                                                      && ivs.batch_no.Trim() == ybzj[thecount].PH.Trim() && ivs.prod_add.Trim() == ybzj[thecount].SCCS.Trim()
                                                      select ivs;
                                        foreach (var m in myquery)
                                        {

                                            m.SB_BZ1 = ybzj[thecount].BZ1;
                                            m.SB_BZ2 = ybzj[thecount].BZ2;
                                            m.SB_BZ3 = ybzj[thecount].BZ3;
                                            m.SB_JX = ybzj[thecount].JX;
                                        }
                                    }


                                    db.SubmitChanges();
                                }



                                MessageBox.Show("已经提交");

                                //20160510
                                ischecked = (bool?)captureitem.EditValue;
                                if (ischecked.HasValue)
                                {
                                    capturethescreen();
                                }
                                //
                                forminitial();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("保存社保单号的过程出现问题，请一定记下这个销售单号" + thelistno + "的社保流水号：" + YWLSH + "，这个已经记录到日志中并通知系统管理员，错误原因是" + ex.ToString());
                                globalvariable glv = new globalvariable();
                                glv.LogWrite("SP3_4001 " + "保存社保单号的过程出现问题，请一定记下这个销售单号" + thelistno + "的社保流水号：" + YWLSH + "，sbcf_bh：" + sbcf_bh + "，sbcfkjjgmc：" + sbcfkjjgmc + "，sbcfjgsfjggz：" + sbcfjgsfjggz + "，sbcfrq：" + sbcfrq + "，sbcfzd：" + sbcfzd + "，sbcfysxm" + sbcfysxm + "并通知系统管理员，错误原因是" + ex.ToString());
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("程序出错：" + expcemsg);
                            globalvariable glv = new globalvariable();
                            glv.LogWrite("SP3_4001 " + expcemsg);
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("程序出错:" + ex.ToString());
                        globalvariable glv = new globalvariable();
                        glv.LogWrite("SP3_4001 " + ex.ToString());
                    }



                }
            }
        }

        public int checkerror(string reciptmark)
        {
            if (dw_1.RowCount == 0)
            {
                adderrlist("你没有导入任何数据", "错误");
                return -1;

            }
            else
            {
                listerr.RemoveAll(o => o.addition == true);
                int thecolcount, thecolcount2;
                string ls_coltype;



                if (!int.TryParse(dw_1.Describe("DataWindow.Column.Count"), out thecolcount))
                    throw new Exception("解释dw_1记录数量时出错");

                string[] ls_columns = new string[thecolcount];
                string[] ls_coltext = new string[thecolcount];

                for (int j = 0; j < thecolcount; j++)
                {
                    ls_columns[j] = dw_1.Describe("#" + (j + 1).ToString() + ".Name").Trim();
                    ls_coltext[j] = dw_1.Describe(ls_columns[j] + "_t.text").Trim();
                    ls_coltype = dw_1.Describe(ls_columns[j] + ".ColType");

                /*    if (ls_columns[j] == "xslx")
                    {
                        if (dw_1.IsItemNull(dw_1.RowCount, ls_columns[j]))
                        {
                            adderrlist("因为所属销售类型不能上传", "错误");
                            continue;

                        }
                        else if (dw_1.GetItemString(dw_1.RowCount, ls_columns[j]).Trim() == "2" || dw_1.GetItemString(dw_1.RowCount, ls_columns[j]).Trim() == "")
                        {
                            adderrlist("因为所属销售类型不能上传", "错误");
                            continue;

                        }
                    }*/


                  //  if (reciptmark == "0")
                  //      if (ls_columns[j] == "cfbh" || ls_columns[j] == "cfkjjgmc" || ls_columns[j] == "jgsfjggz" || ls_columns[j] == "zd" || ls_columns[j] == "cfrq" || ls_columns[j] == "cfysxm")
                   //         continue;



                    if (dw_1.IsItemNull(dw_1.RowCount, ls_columns[j]))
                    {
                        adderrlist("列" + ls_coltext[j] + "的数据为空", "错误");

                    }

                    if (ls_columns[j] == "posjysj")
                    {
                        string mydata = dw_1.GetItemDateTime(dw_1.RowCount, ls_columns[j]).ToString("yyyy-MM-dd HH:mm:ss");
                        if (checkdatastringformat(mydata, false) != 0)
                        {
                            adderrlist("POS小票日期时间格式错误", "错误");
                        }


                    }


                }

                if (reciptmark == "1")
                {
                    if (!int.TryParse(dw_2.Describe("DataWindow.Column.Count"), out thecolcount2))
                        throw new Exception("解释dw_2记录数量时出错");


                    string[] ls_columns2 = new string[thecolcount2];
                    string[]  ls_coltext2 = new string[thecolcount2];

                    for (int j = 0; j < thecolcount2; j++)
                    {
                        ls_columns2[j] = dw_2.Describe("#" + (j + 1).ToString() + ".Name").Trim();
                        ls_coltext2[j] = dw_2.Describe(ls_columns2[j] + "_t.text").Trim();
                        ls_coltype = dw_2.Describe(ls_columns2[j] + ".ColType");

                        if (dw_2.IsItemNull(dw_2.RowCount, ls_columns2[j]))
                        {
                            adderrlist("列" + ls_coltext2[j] + "的数据为空", "错误");

                        }
                    }
                }

                if (griddetail.RowCount == 0)
                {
                    adderrlist("详细项目为空", "错误");
                    return -4;
                }
                else
                {
                    int mycount = 1;
                    foreach (DataGridViewRow rw in this.griddetail.Rows)
                    {

                        if (!rw.IsNewRow)
                        {
                            if (rw.Cells[15].Value == null || rw.Cells[15].Value == DBNull.Value)
                            {
                                adderrlist("第" + mycount.ToString() + "行进仓单号为空", "错误");
                                continue;
                            }
                            else if (String.IsNullOrEmpty(rw.Cells[15].Value.ToString().Trim()))
                            {
                                adderrlist("第" + mycount.ToString() + "行进仓单号为空", "错误");
                            }

                            //20150522
                            //20150727根据社保局要求没有条形码的可以不传
                            /*
                            string theprodno = rw.Cells[1].Value.ToString();
                            if (theprodno.Substring(0, 1) != "3")
                            {
                                if (rw.Cells[14].Value == null || rw.Cells[14].Value == DBNull.Value)
                                {
                                    adderrlist("第" + mycount.ToString() + "行有非中药的条形码为空", "错误");
                                    continue;
                                }
                                else if (String.IsNullOrEmpty(rw.Cells[14].Value.ToString().Trim()))
                                {
                                    adderrlist("第"+mycount.ToString()+"行有非中药的条形码为空", "错误");
                                }
                            }*/

                            //20150529


                            if (rw.Cells[9].Value == null || rw.Cells[9].Value == DBNull.Value)
                            {
                                adderrlist("第" + mycount.ToString() + "行规格为空", "错误");
                                continue;
                            }
                            else if (String.IsNullOrEmpty(rw.Cells[9].Value.ToString().Trim()))
                            {
                                adderrlist("第" + mycount.ToString() + "行规格为空", "错误");
                            }


                            //

                            if (rw.Cells[12].Value == null || rw.Cells[12].Value == DBNull.Value)
                            {
                                adderrlist("第" + mycount.ToString() + "行有效期为空", "错误");
                                continue;
                            }
                            else if (String.IsNullOrEmpty(rw.Cells[12].Value.ToString().Trim()))
                            {
                                adderrlist("第" + mycount.ToString() + "行有效期为空", "错误");
                            }
                            /*         else
                                     {
                                         DateTime dt;

                                         if (!DateTime.TryParse(rw.Cells[12].Value.ToString().Trim(),out dt))
                                         {
                                             adderrlist("第" + mycount.ToString() + "行有效期无法解释", "错误");
                                         }
                                     }*/

                            if (rw.Cells[24].Value.ToString().Trim() == "1" && globalvariable.iftestmodel == true)
                            {
                                adderrlist("第" + mycount.ToString() + "行产地不是全称，验收阶段必须要全称才能通过", "错误");
                            }


                        }
                        mycount++;

                    }
                }

              /*  string format = "yyyyMMdd";
                DateTime dateTime;
                if (reciptmark != "0")
                {
                   if (!dw_1.IsItemNull(dw_1.RowCount, "cfrq"))
                    {

                        datetimestr = dw_1.GetItemDecimal(dw_1.RowCount, "cfrq").ToString();
                        if (!DateTime.TryParseExact(datetimestr, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                        {
                            adderrlist("处方日期格式不正确", "错误");
                        }
                        else
                        {
                            //20150528
                            if (datetimestr.Trim().Length < 8)
                                adderrlist("处方日期长度可能不正确", "警告");
                            //
                            else if (dateTime >= DateTime.Now.AddYears(5) || dateTime <= DateTime.Now.AddYears(-5))
                                adderrlist("处方日期可能不正确", "警告");



                        }
                    }
                }

                if (!dw_1.IsItemNull(dw_1.RowCount, "posjysj"))
                {

                    format = "yyyyMMddHHmmss";

                    datetimestr = dw_1.GetItemDecimal(dw_1.RowCount, "posjysj").ToString();
                    if (!DateTime.TryParseExact(datetimestr, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                    {
                        adderrlist("POS交易时间格式不正确", "错误");
                    }
                    else
                    {
                        //20150528
                        if (datetimestr.Trim().Length < 8)
                            adderrlist("POS交易时间长度可能不正确", "警告");
                        //
                        else if (dateTime >= DateTime.Now.AddYears(5) || dateTime <= DateTime.Now.AddYears(-5))
                            adderrlist("POS交易时间可能不正确", "警告");

                    }
                }*/


                if (listerr.Where(o => o.addition == true).Count() > 0)
                {

                    return -3;
                }


            }
            return 0;
        }

        public int adderrlist(string descr, string lev)
        {
            globalvariable.prodinerror pe = new globalvariable.prodinerror
            {
                description = descr,
                thelevel = lev,
                addition = true
            };
            listerr.Add(pe);

            return 0;
        }



        private void barButtonItem1_ItemClick_2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dw_1.RowCount == 0)
                return;

            string therecipt = dw_1.GetItemString(dw_1.RowCount, "bhcfybz").Trim();
            int result = checkerror(therecipt);
            if (result == 0)
            {
                MessageBox.Show("没有错误");
            }
            else
            {
                if (listerr.Where(o => o.addition == true).Count() > 0)
                {
                    FormCollection fc = Application.OpenForms;

                    foreach (Form myfrm in fc)
                    {
                        if (myfrm.Name == "warningForm")
                            myfrm.Close();
                    }

                    warningForm theform = new warningForm(listerr);
                    theform.Show();
                    if (listerr.Where(o => o.addition == true && o.thelevel == "错误").Count() > 0)
                        return;
                }
            }
        }

      /*  private void dw_1_ItemChanged(object sender, Sybase.DataWindow.ItemChangedEventArgs e)
        {
            try
            {
                if (dw_1.GetColumnName() == "bhcfybz")
                {
                    string thebz = dw_1.GetText();
                    if (thebz.Trim() == "0")
                    {
                        modifydw(0);
                    }
                    else
                    {
                        modifydw(1);

                    }

                }
                else if (dw_1.GetColumnName() == "cfrq")
                {
                    string format = "yyyyMMdd";
                    DateTime dateTime;
                    string datetimestr = dw_1.GetText();
                    if (DateTime.TryParseExact(datetimestr, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                    {
                        if (datetimestr.Trim().Length < 8)
                            dw_1.Modify("warning_text.text='警告：处方日期长度可能不够'");
                        else if (dateTime >= DateTime.Now.AddYears(5) || dateTime <= DateTime.Now.AddYears(-5))
                            dw_1.Modify("warning_text.text='警告：处方日期可能不正确'");
                        else
                            dw_1.Modify("warning_text.text=' 处方时间为：" + String.Format("{0:yyyy年MM月dd日}", dateTime) + "'");
                    }
                    else
                    {
                        dw_1.Modify("warning_text.text='警告：处方日期格式不正确'");
                    }
                }
                else if (dw_1.GetColumnName() == "posjysj")
                {
                    string format = "yyyyMMddHHmmss";
                    DateTime dateTime;
                    string datetimestr = dw_1.GetText();
                    if (DateTime.TryParseExact(datetimestr, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                    {
                        if (datetimestr.Trim().Length < 14)
                            dw_1.Modify("warning_text.text='警告：POS交易时间长度可能不够'");
                        else if (dateTime >= DateTime.Now.AddYears(5) || dateTime <= DateTime.Now.AddYears(-5))
                            dw_1.Modify("warning_text.text='警告：POS交易时间可能不正确'");
                        else
                            dw_1.Modify("warning_text.text='POS时间为：" + String.Format("{0:yyyy/MM/dd HH:mm:ss}", dateTime) + "'");
                    }
                    else
                    {
                        dw_1.Modify("warning_text.text='警告：POS交易时间格式不正确'");
                    }
                }
                else if (dw_1.GetColumnName() == "xslx")
                {
                    string ls_zdbh;
                    string ls_tzzdbh;
                    string ls_shh;
                    string ls_tzssh;
                    using (lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd="))
                    {
                        try
                        {
                            ls_shh = (from c in db.company
                                      select c.sb_ssh).FirstOrDefault();
                            ls_tzssh = (from c in db.company
                                        select c.sb_tzssh).FirstOrDefault();
                            ls_zdbh = (from c in db.company
                                       select c.sb_zdbh).FirstOrDefault();
                            ls_tzzdbh = (from c in db.company
                                         select c.sb_tzzdbh).FirstOrDefault();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("查询过程出错" + ex.ToString());
                            return;
                        }
                    }
                }

            

            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误" + ex.ToString());
            }
        }*/

        private void modifydw(int thevalue)
        {
            if (thevalue == 0)
            {
                dw_1.Modify("cfbh_t.text='处方编号（可不填）：'");
                dw_1.Modify("cfkjjgmc_t.text='处方开具定点医疗机构名称（可不填）：'");
                dw_1.Modify("jgsfjggz_t.text='定点医疗机构是否加盖公章（可不填）：'");
                dw_1.Modify("zd_t.text='诊断（可不填）：'");
                dw_1.Modify("cfrq_t.text='处方日期（可不填）：'");
                dw_1.Modify("cfysxm_t.text='处方医生姓名（可不填）：'");
            }
            else
            {
                dw_1.Modify("cfbh_t.text='处方编号（要填）*：'");
                dw_1.Modify("cfkjjgmc_t.text='处方开具定点医疗机构名称（要填）*：'");
                dw_1.Modify("jgsfjggz_t.text='定点医疗机构是否加盖公章（要填）*：'");
                dw_1.Modify("zd_t.text='诊断（要填）*：'");
                dw_1.Modify("cfrq_t.text='处方日期（要填）*：'");
                dw_1.Modify("cfysxm_t.text='处方医生姓名（要填）*：'");

            }
        }

        private void btncapturescreen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            capturethescreen();
        }

        protected void capturethescreen()
        {



            string myfile = "d:\\"+globalvariable.thename+"销售" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";


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

        public class recordresult
        {
            public string prodno { get; set; }

            public string batchno { get; set; }

            public string prodadd { get; set; }

            public string prodmade { get; set; }

            public DateTime? availdate { get; set; }

            public decimal sellprice { get; set; }

            public decimal invnum { get; set; }

            public decimal sellmon { get; set; }

            public string prodname { get; set; }

            public string monad { get; set; }

            public string prodsize { get; set; }

            public bool recipe { get; set; }

            public string zyps_bm { get; set; }

            public string barcode { get; set; }

            public string lastdepno { get; set; }

            public DateTime invdatesb { get; set; }

            public string bz1 { get; set; }

            public string bz2 { get; set; }

            public string bz3 { get; set; }

            public short ifprodmade { get; set; }
        }

        private void dw_1_ItemError(object sender, ItemErrorEventArgs e)
        {
            if (e.ColumnName == "posjysj")
            {
                MessageBox.Show("因应社保局要求，现在POS交易时间格式改了，现在输入的时间格式为年年年年-月月-日日 时时:分分:秒秒 如2017-12-06 15:03:01", "错误");
                e.Action = ItemErrorAction.RejectWithNoMessage;
            }
            else
                e.Action = ItemErrorAction.Reject;
            
        }

        private void dw_2_ItemError(object sender, ItemErrorEventArgs e)
        {
            if (e.ColumnName == "cfrq")
            {
                MessageBox.Show("因应社保局要求，现在输入处方时间格式改了，现在输入的时间格式为年年年年-月月-日日  如2017-12-06", "错误");
                e.Action = ItemErrorAction.RejectWithNoMessage;
            }
            else
                e.Action = ItemErrorAction.Reject;
            
        }

        private void filldw1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Random rnd = new Random();
            int mynumber = rnd.Next(1, 10000000);
            dw_1.SetItemString(dw_1.RowCount, "jyckh", mynumber.ToString());
            dw_1.SetItemDateTime(dw_1.RowCount, "posjysj", DateTime.Now);
        }

        private void filldw2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Random rnd = new Random();
            int mynumber = rnd.Next(1, 10000000);
            dw_1.SetItemString(dw_1.RowCount, "jyckh", mynumber.ToString());
            dw_1.SetItemDateTime(dw_1.RowCount, "posjysj", DateTime.Now);
            dw_1.SetItemString(dw_1.RowCount, "bhcfybz", "1");
            int recipeno = rnd.Next(1, 1000000);
            dw_2.SetItemString(dw_2.RowCount, "cfbh", recipeno.ToString());
            dw_2.SetItemString(dw_2.RowCount, "cfkjjgmc", "东莞市人民医院");
            dw_2.SetItemDate(dw_2.RowCount, "cfrq", DateTime.Now.Date);
            dw_2.SetItemString(dw_2.RowCount, "cfysxm", "张医生");
            dw_2.SetItemString(dw_2.RowCount, "zd", "咽喉炎");
            dw_2.SetItemString(dw_2.RowCount, "jgsfjggz", "1");
        }

        private void dw_1_ItemChanged(object sender, Sybase.DataWindow.ItemChangedEventArgs e)
        {
            if (e.ColumnName == "posjysj")
            {
                string mydata = e.Data.ToString().Trim();
                if (checkdatastringformat(mydata, true) != 0)
                {
                    e.Action = ItemChangedAction.Reject;
                }
               

            }
            else if (e.ColumnName == "sb_useaddionalpos")
            {
                try
                {
                    using (lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + "; Connect Timeout=180;"))
                    {
                        db.CommandTimeout = 10 * 60;
                        var query = (from c in db.company
                                     select c).FirstOrDefault();

                        int li_Row;
                        li_Row = dw_1.RowCount;
                        string mydata = e.Data.ToString().Trim();
                        if (mydata == "1" || mydata == "2")
                        {
                            dw_1.SetItemString(li_Row, "sb_ssh", query.sb_ssh);
                            dw_1.SetItemString(li_Row, "sb_zdbh", query.sb_zdbh);
                        }
                        else
                        {
                            dw_1.SetItemString(li_Row, "sb_ssh", query.sb_tzssh);
                            dw_1.SetItemString(li_Row, "sb_zdbh", query.sb_tzzdbh);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("发生错误：" + ex.ToString());
                    globalvariable glv = new globalvariable();
                    glv.LogWrite("SP3_4001" + ex.ToString());
                }
            }
            else if (e.ColumnName == "selectidorsbcard")
            {
                int li_Row;
                li_Row = dw_1.RowCount;
                string mydata = e.Data.ToString().Trim();
                if (mydata == "2" || mydata == "5")
                {

                    try
                    {
                        using (lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + "; Connect Timeout=180;"))
                        {
                            db.CommandTimeout = 10 * 60;
                            var query = (from c in db.client
                                         where c.cli_no.Trim() == currentclino.Trim()
                                         select c).FirstOrDefault();


                            if (mydata == "2" )
                            {
                                dw_1.SetItemString(li_Row, "sfzhm", query.cli_sbcardno);
                               
                            }
                           
                            else if (mydata == "5")
                            {
                                dw_1.SetItemString(li_Row, "sfzhm", query.cli_id);
                                 

                            }
                         
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发生错误：" + ex.ToString());
                        globalvariable glv = new globalvariable();
                        glv.LogWrite("SP3_4001" + ex.ToString());
                    }
                }
                else if (mydata == "0")
                {
                    dw_1.SetItemString(li_Row, "sfzhm", sb_cardnoforupload);
                }
                else if (mydata == "1")
                {
                    dw_1.SetItemString(li_Row, "sfzhm", sb_cardno);
                }
                else if (mydata == "3")
                {
                    dw_1.SetItemString(li_Row, "sfzhm", sb_idnoforupload);
                }
                else if (mydata == "4")
                {
                    dw_1.SetItemString(li_Row, "sfzhm", sb_idno);
                }
               
            }

        }

        private int checkdatastringformat(string datastr,bool showwarning)
        {
            int totalength = System.Text.Encoding.Default.GetBytes(datastr).Length;
            if (totalength!=19 )
            {
                if (showwarning)
                {
                    MessageBox.Show("输入的POS小票时间长度不对，请检查冒号是否用了半角，数字用了半角，或者日期和数字之间缺少空格后重写输入再试试");

                }
                return -1;

            }

            for (int i = 0; i < 19; i++)
            {
                string strindex = datastr.Substring(i, 1);
                switch (i)
                {
                    case 4:
                        if (strindex!="-")
                        {
                            if (showwarning)
                            {
                                MessageBox.Show("第" + (i + 1).ToString() + "个字符不是-号或者半角-号");

                            } 
                            return -1;
                        }
                       break;
                    case 7:
                       if (strindex != "-")
                       {
                           if (showwarning)
                           {
                               MessageBox.Show("第" + (i + 1).ToString() + "个字符不是-号或者半角-号");

                           }
                           return -1;
                       }
                       break;

                    case 10:
                       if (strindex != " ")
                       {
                           if (showwarning)
                           {
                               MessageBox.Show("第" + (i + 1).ToString() + "个字符不是空格或者半角空格");

                           }
                           return -1;
                       }
                       break;

                    case 13:
                       if (strindex != ":")
                       {
                           if (showwarning)
                           {
                               MessageBox.Show("第" + (i + 1).ToString() + "个字符不是冒号或者半角冒号");

                           }
                           return -1;
                       }
                       break;
                    case 16:
                       if (strindex != ":")
                       {
                           if (showwarning)
                           {
                               MessageBox.Show("第" + (i + 1).ToString() + "个字符不是冒号或者半角冒号");

                           }
                           return -1;
                       }
                       break;

                    default:
                        if (!checkstrisnumber(strindex))
                        {
                            if (showwarning)
                            {
                                MessageBox.Show("第" + (i + 1).ToString() + "个字符不是数字或者半角数字");

                            }
                            return -1;
                        }
                        break;

                       
                }
                
            }

            return 0;

        }

        private bool checkstrisnumber(string mystr)
        {
            int n;
            bool isNumeric = int.TryParse(mystr, out n);
            return isNumeric;
        }

       



       







    }


}
