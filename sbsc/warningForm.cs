using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NPOI.HSSF.UserModel;

namespace sbsc
{
    public partial class warningForm : Form
    {
        List<globalvariable.prodinerror> myerrlist;

        public warningForm( List<globalvariable.prodinerror> errlist)
        {
            InitializeComponent();
            myerrlist = new List<globalvariable.prodinerror>(errlist);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            

            this.Close();
        }

        private string getherrno(string clino)
        {
            try
            {
                using (lsDataClassesDataContext dc = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd="+globalvariable.mydbpass+";"))
                {
                    int theexits = (from c in dc.cur_ind
                                    where c.user_code == clino
                                    select c).Count();
                    if (theexits == 0)
                        return "false";
                    var query = from c in dc.cur_ind
                                where c.user_code == clino
                                select new { c.cur_year, c.cur_month, c.cur_date, c.err_ind };
                    int theyear = 0;
                    int themonth = 0;
                    int theday = 0;
                    int theind = 0;
                    int thecuryear = DateTime.Now.Year;
                    int thecurmonth = DateTime.Now.Month;
                    int thecurday = DateTime.Now.Day;


                    foreach (var q in query)
                    {
                        theyear = Convert.ToInt32(q.cur_year);
                        themonth = Convert.ToInt32(q.cur_month);
                        theday = Convert.ToInt32(q.cur_date);
                        theind = Convert.ToInt32(q.err_ind);

                    }

                    DateTime ValidDate = new DateTime(theyear, themonth, theday);

                    if (DateTime.Now.Date < ValidDate.Date)
                    {
                        MessageBox.Show("指针表异常，不能生成上传单号");
                        return "false";
                    }

                    if (theyear != thecuryear || themonth != thecurmonth || theday != thecurday)
                    {
                        var curindex = dc.cur_ind.First(d => d.user_code == clino);
                        curindex.cur_year = thecuryear;
                        curindex.cur_month = thecurmonth;
                        curindex.cur_date = thecurday;
                        curindex.err_ind = 0;
                        dc.SubmitChanges();
                        theyear = thecuryear;
                        themonth = thecurmonth;
                        theday = thecurday;
                        theind = 0;

                    }

                    if (theind > 999)
                        return "false";
                    else
                        return theyear.ToString() + themonth.ToString() + theday.ToString() + clino.Trim() + string.Format("{0:D3}", theind);



                }
            }
            catch
            {
                return "false";
            }
        }

        private void updatetheerrno(string cli)
        {
            try
            {
                using (lsDataClassesDataContext dc = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd="+globalvariable.mydbpass+";"))
                {
                    int theexits = (from c in dc.cur_ind
                                    where c.user_code == cli
                                    select c).Count();
                    if (theexits == 0)
                        return;

                    var query = from c in dc.cur_ind
                                where c.user_code == cli
                                select new { c.err_ind };
                    int theind = 0;
                    foreach (var q in query)
                    {

                        theind = Convert.ToInt32(q.err_ind);

                    }

                    theind++;
                    var thepass = dc.cur_ind.First(c => c.user_code == cli);
                    thepass.err_ind = theind;
                    dc.SubmitChanges();




                }
            }
            catch
            {
                throw;
            }

        }

        private void warningForm_Load(object sender, EventArgs e)
        {

            datagrid.ColumnCount = 10;
            datagrid.Columns[0].HeaderText = "序列";
            datagrid.Columns[1].HeaderText = "问题描述";
            datagrid.Columns[2].HeaderText = "问题程度";
            datagrid.Columns[3].HeaderText = "药品编号";
            datagrid.Columns[4].HeaderText = "药品名称";
            datagrid.Columns[5].HeaderText = "药品批号";
            datagrid.Columns[6].HeaderText = "药品产地";
            datagrid.Columns[7].HeaderText = "药品进仓单号";
            datagrid.Columns[8].HeaderText = "药品总共销售";
            datagrid.Columns[9].HeaderText = "药品总共进仓";


            DataGridViewColumn column = datagrid.Columns[1];
            column.Width = 250;


            int i = 1;
            foreach (globalvariable.prodinerror errl in myerrlist)
            {
                int index = datagrid.Rows.Add();
                datagrid.Rows[index].Cells[0].Value = i.ToString();
                datagrid.Rows[index].Cells[1].Value = errl.description;
                datagrid.Rows[index].Cells[2].Value = errl.thelevel;
                datagrid.Rows[index].Cells[3].Value = errl.prodno ;
                datagrid.Rows[index].Cells[4].Value = errl.prodname ;
                datagrid.Rows[index].Cells[5].Value = errl.batchno ;
                datagrid.Rows[index].Cells[6].Value = errl.prodadd ;
                datagrid.Rows[index].Cells[7].Value = errl.lastdepno;
                datagrid.Rows[index].Cells[8].Value = errl.invnum ;
                datagrid.Rows[index].Cells[9].Value = errl.depnum ;
                
                i++;             
            }

            string therrno = getherrno(globalvariable.usercode);
            if (therrno == "false")
                return;
            try
            {
                using (lsDataClassesDataContext dc = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd="+globalvariable.mydbpass+";"))
                {
                    err_main em = new err_main
                    {
                        err_no = therrno,
                        err_bywho = globalvariable.usercode,
                        err_Date = dc.GetSystemDate()

                    };
                    dc.err_main.InsertOnSubmit(em);

                    foreach (globalvariable.prodinerror prode in myerrlist)
                    {
                        err_sub es = new err_sub
                        {
                            err_no = therrno,
                            prod_no = prode.prodno,
                            batch_no = prode.batchno,
                            prod_add = prode.prodadd,
                            inv_num = prode.invnum,
                            dep_num = prode.depnum,
                            description = prode.description,
                            last_dep_no = prode.lastdepno,
                            addition = prode.addition
                        };
                        dc.err_sub.InsertOnSubmit(es);
                    }

                    updatetheerrno(globalvariable.usercode);
                    dc.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常信息保存失败"+ex.ToString());
                globalvariable glv = new globalvariable();
                glv.LogWrite("异常信息保存 " + ex.ToString());
            }
        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            string fileName = "error" + String.Format("{0:yyyy-MM-dd-HH-mm-ss}",DateTime.Now);
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;

            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();

            NPOI.SS.UserModel.ISheet sheet = workbook.CreateSheet("Sheet1");

            int rowCount = datagrid.Rows.Count;
            int colCount = datagrid.Columns.Count;

            NPOI.SS.UserModel.IRow dataRow = sheet.CreateRow(0);
            for (int j = 0; j < colCount; j++)
            {
               
                var cell = dataRow.CreateCell(j);
                cell.SetCellValue(datagrid.Columns[j].HeaderText);
            }

            for (int i = 0; i < rowCount; i++)
            {
                NPOI.SS.UserModel.IRow dataRow2 = sheet.CreateRow(i+1);
                for (int j = 0; j < colCount; j++)
                {
                    if (datagrid.Columns[j].Visible && datagrid.Rows[i].Cells[j].Value != null)
                    {
                        NPOI.SS.UserModel.ICell cell = dataRow2.CreateCell(j);
                        cell.SetCellValue(datagrid.Rows[i].Cells[j].Value.ToString());
                    }
                }
            }

            workbook.Write(ms);
            FileStream file = new FileStream(saveFileName, FileMode.Create);
            workbook.Write(file);
            file.Close();
            workbook = null;
            ms.Close();
            ms.Dispose();

            MessageBox.Show(fileName + "已经导出", "提示", MessageBoxButtons.OK);
        }

    

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
