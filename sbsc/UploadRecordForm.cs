using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using sbsc.RemoveUploadinvdepModel;
using Newtonsoft.Json;

namespace sbsc
{
    public partial class UploadRecordForm : Form
    {
        public UploadRecordForm()
        {
            InitializeComponent();
        }

        bool mychoosebeg = new bool();
        DateTime begdt = new DateTime();
        DateTime endt = new DateTime();


        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UploadRecordForm_Load(object sender, EventArgs e)
        {

        }

        private void btnbegdate_Click(object sender, EventArgs e)
        {
            monthcal.Visible = true;
            mychoosebeg = true;
        }

        private void enddatbtn_Click(object sender, EventArgs e)
        {
            monthcal.Visible = true;
            mychoosebeg = false;
        }

        private void monthcal_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (mychoosebeg)
            {
                txtbegdate.Text = monthcal.SelectionRange.Start.ToString();
                begdt = monthcal.SelectionRange.Start.Date;
             //   monthcal.Visible = false;

            }
            else
            {
                txtenddate.Text = monthcal.SelectionRange.Start.ToString();
                endt = monthcal.SelectionRange.Start.Date;
             //   monthcal.Visible = false;
            }
        }

        private void btnquery_Click(object sender, EventArgs e)
        {
            showthedetail();

        }

        private int showthedetail()
        {
            if (txtbegdate.Text.Trim()  == "" || txtenddate.Text.Trim() == "")
            {
                MessageBox.Show("开始或者结束日期为空，不能查询");
                return -2;
            }
            int  thebegdec = Convert.ToInt32 (begdt.Date.Year * 100 + begdt.Date.Month);
             int theenddec = Convert.ToInt32(endt.Date.Year * 100 + endt.Date.Month);
            if (thebegdec>theenddec)
            {
                MessageBox.Show("开始日期不能大于结束日期");
                return -1;
            }
            try
            {
                lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;");
                {
                    var query = from c in db.upd_main
                                where Convert.ToInt32(c.ny) >= thebegdec && Convert.ToInt32(c.ny) <= theenddec
                                
                                select new { c.upd_no, c.upd_date, c.upd_bywho, c.ny, c.qx_bz, c.qx_Date };
                    int index = 1;

                    DataTable table = new DataTable();
                    table.Columns.Add("serialno", typeof(int));
                    table.Columns.Add("myselect", typeof(bool));
                    table.Columns.Add("updno", typeof(string));
                    table.Columns.Add("upload_date", typeof(DateTime));
                    table.Columns.Add("upd_bywho", typeof(string));
                    table.Columns.Add("ny", typeof(decimal ));
                    table.Columns.Add("qxbz", typeof(string));
                    table.Columns.Add("qx_date", typeof(DateTime));
                    foreach (var q in query)
                    {
                        DataRow dr = table.NewRow();
                        dr["serialno"] = index;
                        dr["myselect"] = false;
                        dr["updno"] = q.upd_no;
                        dr["upd_bywho"] = q.upd_bywho;
                        dr["ny"] = q.ny;

                        if (string.IsNullOrEmpty(q.qx_bz))
                        dr["qxbz"] ="否";
                        else if (q.qx_bz.Trim()=="1")
                        dr["qxbz"] = "是";
                        else
                        dr["qxbz"] = "否";

                        dr["upload_date"] = q.upd_date;
                        if (q.qx_Date!=null)
                        dr["qx_date"] = q.qx_Date;
                        table.Rows.Add(dr);
                        index++;
                    }

                    invmaingrid.DataSource = null;
                    invmaingrid.DataSource = table;

                    if (gridView1.RowCount == 0)
                    {
                        MessageBox.Show("没有任何记录");
                    }

                    return 0;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("查询发生错误："+ex.ToString());
                globalvariable glv = new globalvariable();
                glv.LogWrite("SP3_4003" + ex.ToString());
                return -3;
            }

        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel File|*.xls";
            saveFile.Title = "导出的EXCEL文件";
            saveFile.ShowDialog();
            if (saveFile.FileName != "")
            {
                gridView1.ExportToXls(saveFile.FileName);
                MessageBox.Show("已经导出");
            }
        }

        private void btnselectall_Click(object sender, EventArgs e)
        {
            long therowcount = gridView1.RowCount;
            if (therowcount > 0)
            {
                for (int i = 0; i < therowcount; i++)
                {

                    gridView1.SetRowCellValue(i, "myselect", true);

                }
            }
          
        }

        private void btndeselectall_Click(object sender, EventArgs e)
        {
            long therowcount = gridView1.RowCount;
            if (therowcount > 0)
            {
                for (int i = 0; i < therowcount; i++)
                {

                    gridView1.SetRowCellValue(i, "myselect", false);

                }
            }
        }

      

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
                return;

            DialogResult result = MessageBox.Show("确认要删除社保局服务器内所选的月份的数据吗？", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int theselecount = 0;
                for(int i=0;i<gridView1.RowCount;i++)
                {
                string value = gridView1.GetDataRow(i)["myselect"].ToString();
                if (value.ToLower().Trim()== "true")
                    theselecount++;
                
                }

                if (theselecount > 0)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string thecheck = gridView1.GetDataRow(i)["myselect"].ToString();
                        string qx = gridView1.GetDataRow(i)["qxbz"].ToString();
                        string updno = gridView1.GetDataRow(i)["updno"].ToString();

                        if (thecheck.ToLower().Trim() == "true")
                        {
                            if (qx.ToLower().Trim() == "是")
                            {
                                DialogResult result2 = MessageBox.Show(updno + "已经删除过了，确认还要尝试删除吗？", "提示", MessageBoxButtons.YesNo);
                                if (result2 == DialogResult.No)
                                    continue;
                            }

                            string ny = gridView1.GetDataRow(i)["ny"].ToString();

                            HashParams hp = new HashParams
                            {
                                YYBH = globalvariable.YYBH,
                                FN = "SP3_4004",
                                SESSIONID = globalvariable.SESSIONID,
                                JBR = globalvariable.JBR,
                                JBRQ = String.Format("{0:yyyyMMddHHmmss}", DateTime.Now),
                                CLIENTTYPE = globalvariable.CLIENTTYPE,
                                NY = ny,
                                SCFS = "1",
                                XMWYID = ""
                            };
                            sbsc.RemoveUploadinvdepModel.DataPackage dp = new sbsc.RemoveUploadinvdepModel.DataPackage();

                            sbsc.RemoveUploadinvdepModel.SampleResponse1 sr = new sbsc.RemoveUploadinvdepModel.SampleResponse1
                            {
                                HashParams = hp,
                                DataPackage = dp
                            };



                            try
                            {
                                string json = JsonConvert.SerializeObject(sr);
                                globalvariable gv = new globalvariable();
                                string expcemsg = "";
                                string YWLSH = "";
                                int myresult = gv.postoweb(json, globalvariable.webfunc, ref expcemsg, ref YWLSH);
                                if (myresult == 0)
                                {
                                    try
                                    {
                                        using (lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;"))
                                        {
                                            upd_main updm = (from c in db.upd_main
                                                             where c.upd_no.Trim() == updno.Trim()
                                                             select c).FirstOrDefault();
                                            updm.qx_bz = "1";
                                            updm.qx_Date = db.GetSystemDate();
                                            db.SubmitChanges();


                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(updno + "保存过程出错：" + ex.ToString());
                                        globalvariable glv = new globalvariable();
                                        glv.LogWrite("SP3_4004" + ex.ToString());
                                        return;
                                    }
                                }
                                else
                                {
                                    if (expcemsg.Contains("提示代码:MYBDY000019， 没有找到对应医疗机构对应年月的记录!出错!"))
                                    {
                                        throw new Exception("没有找到对应医疗机构对应年月的记录");
                                    }
                                    else
                                    throw new Exception(expcemsg);
                                }
                                
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(updno + "错误发生：" + ex.ToString());
                                globalvariable glv = new globalvariable();
                                glv.LogWrite("SP3_4004" + ex.ToString());
                                return;
                            }
                        }

                        
                        

                    }

                    MessageBox.Show("删除完毕");
                    invmaingrid.DataSource = null;
                }
                else
                {
                    MessageBox.Show("你没有选择，程序终止");
                    return;
                }


            }
        }

        private void monthcal_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthcal.Visible = false;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.DataRowCount > 0)
            {
                GridView view = (GridView)sender;

                Point pt = view.GridControl.PointToClient(Control.MousePosition);

                DoRowDoubleClick(view, pt);

            }
            

          
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                string updno;
                updno = view.GetRowCellValue(info.RowHandle, "updno").ToString();

                if (string.IsNullOrEmpty(updno))
                {
                    MessageBox.Show("获取单号失败", "错误");
                    return;
                }
                try
                {
                    lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;");
                    {
                        var query = from c in db.upd_sub
                                    where c.upd_no.Trim() == updno.Trim()
                                    orderby c.prod_no, c.prod_add
                                    select c;

                        DataTable table = new DataTable();
                        table.Columns.Add("sn_no", typeof(int));
                        table.Columns.Add("upd_no", typeof(string));
                        table.Columns.Add("prod_no", typeof(string));
                        table.Columns.Add("prod_name", typeof(string));
                        table.Columns.Add("prod_name2", typeof(string));
                        table.Columns.Add("dep_no", typeof(string));
                        table.Columns.Add("prod_add", typeof(string));
                        table.Columns.Add("sup_name", typeof(string));
                        table.Columns.Add("md_name", typeof(string));
                        table.Columns.Add("dep_date", typeof(string));
                        table.Columns.Add("jx", typeof(string));
                        table.Columns.Add("prod_size", typeof(string));
                        table.Columns.Add("dep_num", typeof(decimal));
                        table.Columns.Add("inv_num", typeof(decimal));
                        table.Columns.Add("lest_num", typeof(decimal));
                        table.Columns.Add("dep_mon", typeof(decimal));
                        table.Columns.Add("BZ1", typeof(string));
                        table.Columns.Add("BZ2", typeof(string));
                        table.Columns.Add("BZ3", typeof(string));
                        table.Columns.Add("prod_made", typeof(string));
                        table.Columns.Add("mycount", typeof(int));

                        int index = 1;
                        foreach (var q in query)
                        {
                            DataRow dr = table.NewRow();
                            dr["sn_no"] = index;
                            dr["upd_no"] = q.upd_no;
                            dr["prod_no"] = q.prod_no;
                            dr["prod_name"] = q.prod_name;
                            dr["prod_name2"] = q.prod_name2;
                            dr["dep_no"] = q.dep_no;
                            dr["prod_add"] = q.prod_add;
                            dr["sup_name"] = q.sup_name;
                            dr["md_name"] = q.md_name;
                            dr["dep_date"] = q.dep_date;
                            dr["jx"] = q.jx;
                            dr["prod_size"] = q.prod_size;
                            dr["dep_num"] = q.dep_num;
                            dr["prod_size"] = q.prod_size;
                            dr["dep_num"] = q.dep_num;
                            dr["inv_num"] = q.inv_num;
                            dr["lest_num"] = q.lest_num;
                            dr["dep_mon"] = q.buy_price;
                            dr["BZ1"] = q.BZ1;
                            dr["BZ2"] = q.BZ2;
                            dr["BZ3"] = q.BZ3;
                            dr["prod_made"] = q.prod_made;
                            dr["mycount"] = q.mycount;
                            table.Rows.Add(dr);
                            index++;
                        }

                        invsubgrid.DataSource = null;
                        invsubgrid.DataSource = table;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("发生错误" + ex.ToString());
                    globalvariable glv = new globalvariable();
                    glv.LogWrite("SP3_4004" + ex.ToString());
                }


            }
        }

        private void btnmark_Click(object sender, EventArgs e)
        {
              if (gridView1.RowCount == 0)
                return;

            DialogResult result = MessageBox.Show("确认要把所选数据标记为已经取消吗？", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int theselecount = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string value = gridView1.GetDataRow(i)["myselect"].ToString();
                    if (value.ToLower().Trim() == "true")
                        theselecount++;

                }

                if (theselecount > 0)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string thecheck = gridView1.GetDataRow(i)["myselect"].ToString();
                        string qx = gridView1.GetDataRow(i)["qxbz"].ToString();
                        string updno = gridView1.GetDataRow(i)["updno"].ToString();

                        if (thecheck.ToLower().Trim() == "true" && qx.ToLower().Trim() != "是")
                        {
                            try
                            {
                                lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;");
                                {
                                    var query = from c in db.upd_main 
                                                where c.upd_no.Trim() == updno.Trim()
                                                select c;
                                    foreach (var q in query)
                                    {
                                        q.qx_bz = "1";
                                        q.qx_Date = db.GetSystemDate();
                                        db.SubmitChanges();
                                        globalvariable glv = new globalvariable();
                                        glv.LogWrite("SP3_4004 :" + updno.Trim()+"手工改为已经取消");
                                    }
                                }
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(updno + "保存过程出错：" + ex.ToString());
                                globalvariable glv = new globalvariable();
                                glv.LogWrite("SP3_4004" + ex.ToString());
                                return;
                            }
                        }

                       
                    }

                    MessageBox.Show("标记结束");
                    invmaingrid.DataSource = null;
                }
                else
                {
                    MessageBox.Show("你没有选择，程序终止");
                    return;
                }
            }
        }

       

      
    }
}
