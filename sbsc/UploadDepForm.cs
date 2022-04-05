using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

namespace sbsc
{
    public partial class UploadDepForm : Form
    {
        DateTime dtbegin;
        DateTime dtend;
        
        public UploadDepForm()
        {
            InitializeComponent();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnchoosemonth_Click(object sender, EventArgs e)
        {
            monthcalend.Visible = true;
           

        }

        private void monthcalend_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime dt = monthcalend.SelectionRange.Start;
            dtbegin = new DateTime(dt.Year, dt.Month, 1);
            dtend = dtbegin.AddMonths(1).AddDays(-1);
            txtbegdate.Text = dtbegin.ToString("yyyy-M-d 0:00:00");
            txtenddate.Text = dtend.ToString("yyyy-M-d 0:00:00");
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    Button btn = (Button)ctrl;
                    btn.Enabled = true;
                    
                }
            }
          //  monthcalend.Visible = false; 
            
        }

        private void UploadDepForm_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button && (ctrl.Name != "btnchoosemonth" || ctrl.Name != "exitbtn"))
                {
                    Button btn = (Button)ctrl;
                    btn.Enabled = false;
                }
            }
        }

        private void btnquery_Click(object sender, EventArgs e)
        {
            if (txtbegdate.Text == "" || txtenddate.Text== "")
            {
                MessageBox.Show("你没有选择任何日期，请选择后再试");
                return;
            }
            showthemain();

        }

        private int showthemain()
        {
            
            gridmain.DataSource = null;

            DataTable dt = new DataTable();
           
            dt.Columns.Add("serial", typeof(int));
            dt.Columns.Add("thetype", typeof(string));
            dt.Columns.Add("listno", typeof(string));
            dt.Columns.Add("clino", typeof(string));
            dt.Columns.Add("cliname", typeof(string));
            dt.Columns.Add("thedate", typeof(DateTime));
            dt.Columns.Add("themon", typeof(decimal));
            dt.Columns.Add("theno", typeof(string));
            dt.Columns.Add("sfyjsc", typeof(string));
            gridmain.DataSource = dt;

            try
            {
                using (lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;"))
                {


                    long  countsbscbzprod = (from p in db.product where p.sb_sc_bz == '1' select p).Count();




                    if (rbdisplaydidntupload.Checked == true)
                    {
                        var query= from c in db.inv_main
                                    where c.inv_date >= dtbegin && c.inv_date <= dtend && c.upload_bz==null
                                    select new { c.list_no, c.inv_date, c.inv_mon, c.inv_bywho, c.cli_no, c.cli_name,c.upload_bz};
                        
                        if (countsbscbzprod > 0)
                        {

                           query = from c in db.inv_main
                                    where c.inv_date >= dtbegin && c.inv_date <= dtend && c.upload_bz == null
                                        //20201211
                                         && (from ivs in db.inv_sub
                                             join p in db.product on ivs.prod_no equals p.prod_no into ps
                                             from p in ps.DefaultIfEmpty()
                                             where p.sb_sc_bz == null && ivs.list_no == c.list_no
                                             select c.list_no).Contains(c.list_no)
                                    //\\
                                    select new { c.list_no, c.inv_date, c.inv_mon, c.inv_bywho, c.cli_no, c.cli_name, c.upload_bz };
                        }
                         

                        int i = 0;
                        foreach (var q in query)
                        {
                            
                            mainview.AddNewRow();
                            int rowHandle = mainview.GetRowHandle(mainview.DataRowCount);
                            if (mainview.IsNewItemRow(rowHandle))
                             {
                                 
                                 mainview.SetRowCellValue(rowHandle, mainview.Columns[0], i + 1);
                                 mainview.SetRowCellValue(rowHandle, mainview.Columns[1], "销售");
                                 mainview.SetRowCellValue(rowHandle, mainview.Columns[2], q.list_no);
                                 mainview.SetRowCellValue(rowHandle, mainview.Columns[3], q.cli_no);
                                 mainview.SetRowCellValue(rowHandle, mainview.Columns[4], q.cli_name);
                                 mainview.SetRowCellValue(rowHandle, mainview.Columns[5], q.inv_date);

                                //20201211

                                 if (countsbscbzprod == 0)
                                 {
                                     mainview.SetRowCellValue(rowHandle, mainview.Columns[6], q.inv_mon);
                                 }
                                 else
                                 {
                                     //20201211
                                     var invmoncalcultated = (from ivs in db.inv_sub
                                                              join p in db.product on ivs.prod_no equals p.prod_no into ps
                                                              from p in ps.DefaultIfEmpty()
                                                              where p.sb_sc_bz == null && ivs.list_no == q.list_no
                                                              select ivs.inv_num * ivs.sell_price).Sum();

                                     mainview.SetRowCellValue(rowHandle, mainview.Columns[6], invmoncalcultated);
                                     //\\
                                 }
                                 //\\



                                 mainview.SetRowCellValue(rowHandle, mainview.Columns[7], q.inv_bywho);
                                 if (q.upload_bz == '1')
                                     mainview.SetRowCellValue(rowHandle, mainview.Columns[8], "已上传");
                                 else
                                     mainview.SetRowCellValue(rowHandle, mainview.Columns[8], "未上传");
                                 i++;
                             }
                        }

                       var query2 =  from d in db.dep_main
                                where d.dep_date >= dtbegin && d.dep_date <= dtend && d.upload_bz ==null
                                join s in db.supply
                                on d.sup_no equals s.sup_no into joinsupply
                                from s in joinsupply.DefaultIfEmpty() 
                                select new { d.dep_no, d.dep_date, d.dep_mon, d.dep_bywho, d.sup_no, s.sup_name, d.upload_bz };



                       if (countsbscbzprod > 0)
                       {

                           query2 = from d in db.dep_main
                                    where d.dep_date >= dtbegin && d.dep_date <= dtend && d.upload_bz == null
                                    && (from dps in db.dep_sub
                                        join p in db.product on dps.prod_no equals p.prod_no into ps
                                        from p in ps.DefaultIfEmpty()
                                        where p.sb_sc_bz == null && dps.dep_no == d.dep_no
                                        select d.dep_no).Contains(d.dep_no)
                                    join s in db.supply
                                    on d.sup_no equals s.sup_no into joinsupply
                                    from s in joinsupply.DefaultIfEmpty()
                                    select new { d.dep_no, d.dep_date, d.dep_mon, d.dep_bywho, d.sup_no, s.sup_name, d.upload_bz };
                       }


                       foreach (var q in query2)
                       {

                           mainview.AddNewRow();
                           int rowHandle = mainview.GetRowHandle(mainview.DataRowCount);
                           if (mainview.IsNewItemRow(rowHandle))
                           {
                               
                               
                               mainview.SetRowCellValue(rowHandle, mainview.Columns[0], i + 1);
                               mainview.SetRowCellValue(rowHandle, mainview.Columns[1], "进仓");
                               mainview.SetRowCellValue(rowHandle, mainview.Columns[2], q.dep_no);
                               mainview.SetRowCellValue(rowHandle, mainview.Columns[3], q.sup_no);
                               mainview.SetRowCellValue(rowHandle, mainview.Columns[4], q.sup_name);
                               mainview.SetRowCellValue(rowHandle, mainview.Columns[5], q.dep_date);


                               //20201212

                               if (countsbscbzprod == 0)
                               {
                                   mainview.SetRowCellValue(rowHandle, mainview.Columns[6], q.dep_mon);
                               }
                               else
                               {

                                   //20201211
                                   var depmoncalcultated = (from dps in db.dep_sub
                                                            join p in db.product on dps.prod_no equals p.prod_no into ps
                                                            from p in ps.DefaultIfEmpty()
                                                            where p.sb_sc_bz == null && dps.dep_no == q.dep_no
                                                            select dps.buy_price * dps.dep_num).Sum();


                                   mainview.SetRowCellValue(rowHandle, mainview.Columns[6], depmoncalcultated);
                               }
                               //\\


                               mainview.SetRowCellValue(rowHandle, mainview.Columns[7], q.dep_bywho);
                               if (q.upload_bz == '1')
                                   mainview.SetRowCellValue(rowHandle, mainview.Columns[8], "已上传");
                               else
                                   mainview.SetRowCellValue(rowHandle, mainview.Columns[8], "未上传");
                               i++;
                           }
                       }

 
                    }
                    else
                    {

                        //20201212
                        var query = from c in db.inv_main
                                    where c.inv_date >= dtbegin && c.inv_date <= dtend
                                    select new { c.list_no, c.inv_date, c.inv_mon, c.inv_bywho, c.cli_no, c.cli_name, c.upload_bz };


                        if (countsbscbzprod > 0)
                        {
                              query = from c in db.inv_main
                                        where c.inv_date >= dtbegin && c.inv_date <= dtend
                                            //20201211
                                             && (from ivs in db.inv_sub
                                                 join p in db.product on ivs.prod_no equals p.prod_no into ps
                                                 from p in ps.DefaultIfEmpty()
                                                 where p.sb_sc_bz == null && ivs.list_no == c.list_no
                                                 select c.list_no).Contains(c.list_no)
                                        //\\
                                        select new { c.list_no, c.inv_date, c.inv_mon, c.inv_bywho, c.cli_no, c.cli_name, c.upload_bz };
                        }

                        int i = 0;
                        foreach (var q in query)
                        {

                            mainview.AddNewRow();
                            int rowHandle = mainview.GetRowHandle(mainview.DataRowCount);
                            if (mainview.IsNewItemRow(rowHandle))
                            {

                                mainview.SetRowCellValue(rowHandle, mainview.Columns[0], i + 1);
                                mainview.SetRowCellValue(rowHandle, mainview.Columns[1], "销售");
                                mainview.SetRowCellValue(rowHandle, mainview.Columns[2], q.list_no);
                                mainview.SetRowCellValue(rowHandle, mainview.Columns[3], q.cli_no);
                                mainview.SetRowCellValue(rowHandle, mainview.Columns[4], q.cli_name);
                                mainview.SetRowCellValue(rowHandle, mainview.Columns[5], q.inv_date);


                                //20201212
                                if (countsbscbzprod == 0)
                                {
                                    mainview.SetRowCellValue(rowHandle, mainview.Columns[6], q.inv_mon);
                                }
                                else
                                {

                                    //20201211
                                    var invmoncalcultated = (from ivs in db.inv_sub
                                                             join p in db.product on ivs.prod_no equals p.prod_no into ps
                                                             from p in ps.DefaultIfEmpty()
                                                             where p.sb_sc_bz == null && ivs.list_no == q.list_no
                                                             select ivs.inv_num * ivs.sell_price).Sum();

                                    mainview.SetRowCellValue(rowHandle, mainview.Columns[6], invmoncalcultated);
                                }
                                //\\

                                mainview.SetRowCellValue(rowHandle, mainview.Columns[7], q.inv_bywho);
                                if (q.upload_bz == '1')
                                    mainview.SetRowCellValue(rowHandle, mainview.Columns[8], "已上传");
                                else
                                    mainview.SetRowCellValue(rowHandle, mainview.Columns[8], "未上传");
                                i++;
                            }
                        }


                        //20201212
                        var query2 = from d in db.dep_main
                                     where d.dep_date >= dtbegin && d.dep_date <= dtend
                                     join s in db.supply
                                     on d.sup_no equals s.sup_no into joinsupply
                                     from s in joinsupply.DefaultIfEmpty()
                                     select new { d.dep_no, d.dep_date, d.dep_mon, d.dep_bywho, d.sup_no, s.sup_name, d.upload_bz };
                        //\\

                        if (countsbscbzprod > 0)
                        {
                           query2 = from d in db.dep_main
                                         where d.dep_date >= dtbegin && d.dep_date <= dtend
                                             //20201211
                                         && (from dps in db.dep_sub
                                             join p in db.product on dps.prod_no equals p.prod_no into ps
                                             from p in ps.DefaultIfEmpty()
                                             where p.sb_sc_bz == null && dps.dep_no == d.dep_no
                                             select d.dep_no).Contains(d.dep_no)
                                         //\\
                                         join s in db.supply
                                         on d.sup_no equals s.sup_no into joinsupply
                                         from s in joinsupply.DefaultIfEmpty()
                                         select new { d.dep_no, d.dep_date, d.dep_mon, d.dep_bywho, d.sup_no, s.sup_name, d.upload_bz };
                        }

                        foreach (var q in query2)
                        {
                            mainview.AddNewRow();
                            int rowHandle = mainview.GetRowHandle(mainview.DataRowCount);
                            if (mainview.IsNewItemRow(rowHandle))
                            {


                                mainview.SetRowCellValue(rowHandle, mainview.Columns[0], i + 1);
                                mainview.SetRowCellValue(rowHandle, mainview.Columns[1], "进仓");
                                mainview.SetRowCellValue(rowHandle, mainview.Columns[2], q.dep_no);
                                mainview.SetRowCellValue(rowHandle, mainview.Columns[3], q.sup_no);
                                mainview.SetRowCellValue(rowHandle, mainview.Columns[4], q.sup_name);
                                mainview.SetRowCellValue(rowHandle, mainview.Columns[5], q.dep_date);

                                //20201212
                                if (countsbscbzprod == 0)
                                {
                                    mainview.SetRowCellValue(rowHandle, mainview.Columns[6], q.dep_mon);
                                }
                                else
                                {
                                    //20201211
                                    var depmoncalcultated = (from dps in db.dep_sub
                                                             join p in db.product on dps.prod_no equals p.prod_no into ps
                                                             from p in ps.DefaultIfEmpty()
                                                             where p.sb_sc_bz == null && dps.dep_no == q.dep_no
                                                             select dps.buy_price * dps.dep_num).Sum();

                                    mainview.SetRowCellValue(rowHandle, mainview.Columns[6], depmoncalcultated);
                                }
                                //\\

                                mainview.SetRowCellValue(rowHandle, mainview.Columns[7], q.dep_bywho);
                                if (q.upload_bz == '1')
                                    mainview.SetRowCellValue(rowHandle, mainview.Columns[8], "已上传");
                                else
                                    mainview.SetRowCellValue(rowHandle, mainview.Columns[8], "未上传");
                                i++;
                            }
                        }

                    }

                    if (mainview.RowCount == 0)
                    {
                        MessageBox.Show("没有任何结果");
                    }

                }
                return 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show("出现错误" + ex.ToString());
                return -1;
            }

        }

       

       

        private void btnupload_Click(object sender, EventArgs e)
        {
            if (mainview.DataRowCount == 0)
            {
                MessageBox.Show("请查询出结果后再试，程序终止");
                return;
            }
             DialogResult result3 = MessageBox.Show("真的要上传吗？计算进仓至少要10分钟或者更长的时间，视乎计算机的配置，请耐心等待", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

             if (result3 == DialogResult.Yes)
             {
                 string calmethod = "1";
                 if (rbcalaccurate.Checked == true)
                     calmethod = "2";

                 SummaryUploadForm suform = new SummaryUploadForm(dtbegin, dtend, calmethod);
                     suform.ShowDialog();
                 
             }
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            long therowcount = mainview.RowCount;
            if (therowcount > 0)
            {
                for (int i = 0; i < therowcount; i++)
                {

                    mainview.SetRowCellValue(i, "myselected", true);

                }
            }
            else
            {
                MessageBox.Show("还没查询或者记录为空，程序终止！");
            }
        }

        private void btndeselect_Click(object sender, EventArgs e)
        {
            long therowcount = mainview.RowCount;
            if (therowcount > 0)
            {
                for (int i = 0; i < therowcount; i++)
                {

                    mainview.SetRowCellValue(i, "myselected", false);

                }
            }
            else
            {
                MessageBox.Show("还没查询或者记录为空，程序终止！");
            }
        }

        private void btnexportexcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel File|*.xls";
            saveFile.Title = "导出的EXCEL文件";
            saveFile.ShowDialog();
            if (saveFile.FileName != "")
            {
                gridmain.ExportToXls(saveFile.FileName);
                MessageBox.Show("已经导出");
            }
        }

        private void btnfilter_Click(object sender, EventArgs e)
        {
           // gridView1.ShowCustomFilterDialog();
        }

        private void monthcalend_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthcalend.Visible = false;
        }

        private void mainview_DoubleClick(object sender, EventArgs e)
        {
            if (mainview.DataRowCount > 0)
            {
                GridView view = (GridView)sender;

                Point pt = view.GridControl.PointToClient(Control.MousePosition);

                DoRowDoubleClick(view, pt);

            }
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            gridsub.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("serialno", typeof(int));
            dt.Columns.Add("thelistno", typeof(string));
            dt.Columns.Add("prodno", typeof(string));
            dt.Columns.Add("zyprodno", typeof(string));
            dt.Columns.Add("prodname", typeof(string));
            dt.Columns.Add("batchno", typeof(string));
            dt.Columns.Add("prodadd", typeof(string));
            dt.Columns.Add("prodsize", typeof(string));
            dt.Columns.Add("monad", typeof(string));
            dt.Columns.Add("invnum", typeof(decimal));
            dt.Columns.Add("sellprice", typeof(decimal));
            dt.Columns.Add("je", typeof(decimal));
            dt.Columns.Add("availdate", typeof(DateTime));
            gridsub.DataSource = dt;


            //    subview.Columns.Clear();

            GridHitInfo info = view.CalcHitInfo(pt);

            if (info.InRow || info.InRowCell)
            {

                string listno;
                string thetype;
                listno = view.GetRowCellValue(info.RowHandle, "listno").ToString();
                thetype = view.GetRowCellValue(info.RowHandle, "thetype").ToString();
                using (lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;"))
                {

                    try
                    {
                        if (thetype == "销售")
                        {
                            var query = from c in db.inv_sub
                                        where c.list_no.Trim() == listno.Trim()
                                        join p in db.product
                                        on c.prod_no equals p.prod_no into joinprod
                                        from p in joinprod.DefaultIfEmpty()
                                        //20201211
                                        where p.sb_sc_bz==null 
                                        //\\
                                        select new { listno = c.list_no, prodno = c.prod_no, zypsbm = p.zyps_bm, prodname = p.prod_name, batchno = c.batch_no, prodadd = c.prod_add, prodsize = p.prod_size, monad = p.monad, invnum = c.inv_num, sellprice = c.sell_price, sellmon = c.inv_num * c.sell_price, availdate = c.avail_date };

                            int i = 0;


                            foreach (var q in query)
                            {

                                subview.AddNewRow();
                                int rowHandle = subview.GetRowHandle(subview.DataRowCount);
                                if (mainview.IsNewItemRow(rowHandle))
                                {
                                    subview.SetRowCellValue(rowHandle, subview.Columns[0], i + 1);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[1], q.listno);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[2], q.prodno);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[3], q.zypsbm);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[4], q.prodname);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[5], q.batchno);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[6], q.prodadd);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[7], q.prodsize);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[8], q.monad);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[9], q.invnum);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[10], q.sellprice);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[11], q.sellmon);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[12], q.availdate);
                                    i++;
                                }
                            }

                        }
                        else
                        {
                            var query = from c in db.dep_sub
                                        where c.dep_no.Trim() == listno.Trim()
                                        join p in db.product
                                        on c.prod_no equals p.prod_no into joinprod
                                        from p in joinprod.DefaultIfEmpty()
                                        //20201211
                                        where p.sb_sc_bz == null
                                        //\\
                                        select new { listno = c.dep_no, prodno = c.prod_no, zypsbm = p.zyps_bm, prodname = p.prod_name, batchno = c.batch_no, prodadd = c.prod_add, prodsize = p.prod_size, monad = p.monad, invnum = c.dep_num, sellprice = c.buy_price, sellmon = c.dep_num * c.buy_price, availdate = c.avail_date };

                            int i = 0;
                            foreach (var q in query)
                            {

                                subview.AddNewRow();
                                int rowHandle = subview.GetRowHandle(subview.DataRowCount);
                                if (mainview.IsNewItemRow(rowHandle))
                                {
                                    subview.SetRowCellValue(rowHandle, subview.Columns[0], i + 1);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[1], q.listno);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[2], q.prodno);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[3], q.zypsbm);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[4], q.prodname);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[5], q.batchno);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[6], q.prodadd);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[7], q.prodsize);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[8], q.monad);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[9], q.invnum);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[10], q.sellprice);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[11], q.sellmon);
                                    subview.SetRowCellValue(rowHandle, subview.Columns[12], q.availdate);
                                    i++;
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("出现错误：" + ex.ToString());
                        return;
                    }
                }
            }
        }

        private void rbdisplayall_Click(object sender, EventArgs e)
        {

            if (rbdisplayall.Checked == true)
             MessageBox.Show("注意查看全部时容易重复上传，请小心操作");
             
        }

        private void rbdisplaydidntupload_CheckedChanged(object sender, EventArgs e)
        {
            gridmain.DataSource = null;
            gridsub.DataSource = null;
        }

        private void rbdisplayall_CheckedChanged(object sender, EventArgs e)
        {
            gridmain.DataSource = null;
            gridsub.DataSource = null;
        }

       


      
    }
}
