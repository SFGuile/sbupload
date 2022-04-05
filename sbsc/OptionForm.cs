using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Sybase.DataWindow;

namespace sbsc
{
    public partial class OptionForm : Form
    {
        SqlConnection dbConn;
        AdoTransaction adoTrans;

        public OptionForm()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            DialogResult result3 = MessageBox.Show("真的要重填吗","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result3 == DialogResult.Yes)
            {
                dw_1.Reset();
                dw_1.Retrieve();
            }
        }

        private void OptionForm_Load(object sender, EventArgs e)
        {
            try
            {
                dbConn = new SqlConnection(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";");
                dbConn.Open();
                adoTrans = new AdoTransaction(dbConn);
                adoTrans.BindConnection();
                dw_1.SetTransaction(adoTrans);
                dw_1.Retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误发生：" + ex.ToString());
                globalvariable glv = new globalvariable();
                glv.LogWrite("系统设置 " + ex.ToString());
                this.Close();

            }

        }

        private void OptionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                adoTrans.UnbindConnection();
                dbConn.Close();
            }
            catch(Exception ex)
            {
                globalvariable glv = new globalvariable();
                glv.LogWrite("系统设置" + ex.ToString());
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
             DialogResult result3 = MessageBox.Show("真的要保存吗","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

             if (result3 == DialogResult.Yes)
             {
                 adoTrans.Transaction = dbConn.BeginTransaction();
                 try
                 {
                     dw_1.UpdateData();
                     adoTrans.Transaction.Commit();
                     MessageBox.Show("数据保存成功!");
                 }
                 catch (Exception ex)
                 {
                     adoTrans.Transaction.Rollback();
                     MessageBox.Show("数据保存失败!\r\n\r\n详细错误信息:\r\n" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     globalvariable glv = new globalvariable();
                     glv.LogWrite("系统设置 " + ex.ToString());
                 }
             }

        }
    }
}
