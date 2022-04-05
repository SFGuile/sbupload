using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace sbsc
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        private void btnexit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void errexcelexpbtn_Click(object sender, EventArgs e)
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

        private void refreshbtn_Click(object sender, EventArgs e)
        {
            showexp();
        }

        private void showexp()
        {
            try
            {
                using (lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd="))
                {
                    var query = from c in db.err_sub
                                join m in db.err_main
                                on c.err_no equals m.err_no into joinempdt
                                from m in joinempdt.DefaultIfEmpty()
                                join p in db.product 
                                on c.prod_no equals p.prod_no into joinprod
                                from p in joinprod.DefaultIfEmpty()
                                select new {c.err_no ,m.err_Date,m.err_bywho ,c.prod_no ,c.batch_no ,c.prod_add ,p.prod_name ,p.prod_size ,c.last_dep_no ,c.inv_num ,c.dep_num ,c.description  };

                      DataTable thedt = new DataTable();
                      thedt.Columns.Add("serialno", typeof(int));
                      thedt.Columns.Add("err_no", typeof(string));
                      thedt.Columns.Add("err_Date", typeof(DateTime));
                      thedt.Columns.Add("err_bywho", typeof(string));
                      thedt.Columns.Add("prod_no", typeof(string));
                      thedt.Columns.Add("batch_no", typeof(string));
                      thedt.Columns.Add("prod_add", typeof(string));
                      thedt.Columns.Add("prod_name", typeof(string));
                      thedt.Columns.Add("prod_size", typeof(string));
                      thedt.Columns.Add("last_dep_no", typeof(string));
                      thedt.Columns.Add("inv_num", typeof(decimal));
                      thedt.Columns.Add("dep_num", typeof(decimal));
                      thedt.Columns.Add("description", typeof(string));

                      int index=1;
                      foreach (var q in query)
                      {
                          DataRow dr = thedt.NewRow();
                          dr[0] = index;
                          dr[1] = q.err_no;
                          dr[2] = q.err_Date;
                          dr[3] = q.err_bywho;
                          dr[4] = q.prod_no;
                          dr[5] = q.batch_no;
                          dr[6] = q.prod_add;
                          dr[7] = q.prod_name;
                          dr[8] = q.prod_size;
                          dr[9] = q.last_dep_no;
                          dr[10] = q.inv_num;
                          dr[11] = q.dep_num;
                          dr[12] = q.description;
                          thedt.Rows.Add(dr);
                          index++;
                      }
                      expgrid.DataSource = null;
                      expgrid.DataSource = thedt;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("程序出现异常:"+ex.ToString());
            }

        }

        private void btnexptxt_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog3save.ShowDialog() == DialogResult.OK)
            {
                // create a writer and open the file
                TextWriter tw = new StreamWriter(folderBrowserDialog3save.SelectedPath + "日志.txt");
                // write a line of text to the file
               
                // close the stream
                tw.Close();
                MessageBox.Show("已经保存到 " + folderBrowserDialog3save.SelectedPath + "\\日志.txt", "导出日志", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnrefreshexp_Click(object sender, EventArgs e)
        {
            refreshexp();
        }

        private void refreshexp()
        {
            if (File.Exists(globalvariable.theappath + "\\sblog.txt"))
            {
                errtext.Lines = File.ReadAllLines(globalvariable.theappath + "\\sblog.txt");
            }
            else
            {
                errtext.Text = "没有找到日志文件";
            }
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            showexp();
            refreshexp();
        }
    }
}
