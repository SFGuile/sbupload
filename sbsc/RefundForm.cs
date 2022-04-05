using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sbsc.RefundModel;
using Newtonsoft.Json;
using DevExpress.XtraGrid.Views.Grid;


namespace sbsc
{
    public partial class RefundForm : Form
    {
        public RefundForm()
        {
            InitializeComponent();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            txtid.Text = txtid.Text.Trim();
            string theseachstr = txtid.Text;
            if (string.IsNullOrEmpty(theseachstr))
                return;
            gridrecrods.DataSource = null;
            try
            {
                using (lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;"))
                {
                    var query = from c in db.inv_main
                                join d in db.client
                                on c.cli_no equals d.cli_no into joincli
                                from d in joincli.DefaultIfEmpty()
                                where (c.list_no.Contains(theseachstr) || d.cli_id.Contains(theseachstr) || d.cli_sbcardno.Contains(theseachstr)) && c.JKSCBZ == '1'
                                orderby c.inv_date descending,c.list_no descending  
                                select new { c.list_no ,c.SBWLSH,c.JKSCBZ ,c.refund_bz,c.inv_mon,c.inv_bywho,c.cli_no ,c.cli_name,c.JKSCSZ  ,c.refund_time,c.sbxp_no,c.sbxp_jysj ,c.sbcfbz,c.sbcf_bh ,c.sbcfkjjgmc,c.sbcfrq ,c.sbcfzd,c.sbcfysxm };

                    int thecount = query.Count();
                    if(thecount==0)
                    {
                        MessageBox.Show("找不到该客户或者该客户没有通过接口上传的记录");
                        return;
                    }

                    DataTable table = new DataTable();
                    table.Columns.Add("myselect", typeof(bool));
                    table.Columns.Add("serialno", typeof(int));
                    table.Columns.Add("list_no", typeof(string));
                    table.Columns.Add("sbls", typeof(string));
                    table.Columns.Add("JKSCBZ", typeof(string));
                    table.Columns.Add("JKSCSZ", typeof(DateTime));
                    table.Columns.Add("refund_bz", typeof(string));
                    table.Columns.Add("refund_date", typeof(DateTime));
                    table.Columns.Add("inv_mon", typeof(decimal));
                    table.Columns.Add("inv_bywho", typeof(string));
                    table.Columns.Add("cli_no", typeof(string));
                    table.Columns.Add("cli_name", typeof(string));
                    table.Columns.Add("posxp_no", typeof(string));
                    table.Columns.Add("posxp_jysj", typeof(string));
                    table.Columns.Add("recipe_bz", typeof(string));
                    table.Columns.Add("cfbh", typeof(string));
                    table.Columns.Add("cfkjjgmc", typeof(string));
                    table.Columns.Add("cfrq", typeof(decimal));
                    table.Columns.Add("cfzd", typeof(string));
                    table.Columns.Add("cfysxm", typeof(string));

                    int theindex = 1;
                    foreach (var q in query)
                    {
                        DataRow row= table.NewRow();
                       
                        row["myselect"] = false;
                        
                        row["serialno"] = theindex;
                        row["list_no"] = q.list_no;
                        row["sbls"] = q.SBWLSH;
                        if (q.JKSCBZ == '1')
                            row["JKSCBZ"] = "是";
                        else
                            row["JKSCBZ"] = "否";
                        
                        if (q.JKSCSZ!=null)
                            row["JKSCSZ"] = q.JKSCSZ;

                        if (q.refund_bz== '1')
                            row["refund_bz"] = "是";
                        else
                            row["refund_bz"] = "否";
                        
                        if (q.refund_time!=null)
                        row["refund_date"] = q.refund_time;


                        row["inv_mon"]=q.inv_mon ;
                        row["inv_bywho"]=q.inv_bywho ;
                        row["cli_no"]=q.cli_no ;
                        row["cli_name"]=q.cli_name ;

                        row["posxp_no"] = q.sbxp_no ;
                        row["posxp_jysj"] = q.sbxp_jysj;
                        
                        if(q.sbcfbz.Trim()=="1")
                            row["recipe_bz"] = "是";
                        else
                            row["recipe_bz"] = "否";

                        row["cfbh"] = q.sbcf_bh;
                        row["cfkjjgmc"] = q.sbcfkjjgmc;
                        if (q.sbcfrq!=null)
                        row["cfrq"] = q.sbcfrq;
                        row["cfzd"] = q.sbcfzd;
                        row["cfysxm"] =q.sbcfysxm ;

                        table.Rows.Add(row);
                        theindex++;
                    }
                    gridrecrods.DataSource = table;
                  

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("发生错误:"+ex.ToString());
                globalvariable glv = new globalvariable();
                glv.LogWrite("SP3_4002" + ex.ToString());
            }

        }

        private void btncomfirm_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
                return;
            DialogResult result = MessageBox.Show("确认要把所选的冲正吗？", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int checkcount = 0;
               
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    bool check_ = (bool)gridView1.GetRowCellValue(i, "myselect");
                    if (check_ == true)
                    {
                        checkcount++;
                    }
                   

                }

                if (checkcount == 0)
                {
                    MessageBox.Show("没有任何选择，程序终止");
                    return;
                }
                else if (checkcount >1)
                {
                    MessageBox.Show("不允许选择超过1个以上，程序终止");
                    return;
                }
                int thegetrow = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    bool check_ = (bool)gridView1.GetRowCellValue(i, "myselect");
                    if (check_ == true)
                    {
                        thegetrow = i;
                    }
                }

                string theSBWLSH = (string)gridView1.GetRowCellValue(thegetrow, "sbls").ToString().Trim();
                string theczbz = (string)gridView1.GetRowCellValue(thegetrow, "refund_bz").ToString().Trim();
                string listno = (string)gridView1.GetRowCellValue(thegetrow, "list_no").ToString().Trim();

                if (theczbz == "是")
                {
                    DialogResult result2 = MessageBox.Show( listno+"已经冲正过，是否仍然再冲正，冲正可能会产生错误？", "提示", MessageBoxButtons.YesNo);
                    if (result2 == DialogResult.No)
                        return;
                }

                HashParams hp = new HashParams
                {
                    FN = "SP3_4002",
                    SESSIONID = globalvariable.SESSIONID,
                    JBR = globalvariable.JBR,
                    JBRQ = String.Format("{0:yyyyMMddHHmmss}", DateTime.Now),
                    YYBH = globalvariable.YYBH,
                    YWLSH = theSBWLSH,
                    CLIENTTYPE = globalvariable.CLIENTTYPE,
                    JYLX ="取消消费"
                    

                };

                DataPackage dp = new DataPackage();

                SampleResponse1 sr = new SampleResponse1
                {
                    HashParams = hp,
                    DataPackage =dp
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
                                inv_main im = db.inv_main.First(c => c.list_no == listno && c.SBWLSH == theSBWLSH);
                                im.refund_bz = '1';
                                im.refund_time = db.GetSystemDate();
                                db.SubmitChanges();
                                MessageBox.Show("已经冲正");
                                gridrecrods.DataSource = null;
                                txtid.Text = null;
                            }
                        }
                        catch (RankException ex)
                        {
                            MessageBox.Show("保存时发生错误:" + ex.ToString());
                            globalvariable glv = new globalvariable();
                            glv.LogWrite("SP3_4002" + ex.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("冲正出错：" + expcemsg);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("程序发生错误:" + ex.ToString());
                    globalvariable glv = new globalvariable();
                    glv.LogWrite("SP3_4002" + ex.ToString());
                }


            }

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "myselect")
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (i != gridView1.FocusedRowHandle)
                    {
                        DataRow row = gridView1.GetDataRow(i);
                        row["myselect"] = false;
                     
                    }
                }
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column.FieldName == "refund_bz")
                {
                    GridView view = sender as GridView;

                    // Some condition
                    if (view.GetRowCellValue(e.RowHandle, view.Columns["refund_bz"]).ToString().Trim() == "是")
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
                else if (e.Column.FieldName == "refund_date")
                {
                    GridView view = sender as GridView;

                    // Some condition
                    if (view.GetRowCellValue(e.RowHandle, view.Columns["refund_bz"]).ToString().Trim() == "是")
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void RefundForm_Load(object sender, EventArgs e)
        {

        }

        

       

       
    }
}
