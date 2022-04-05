using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sbsc

{
    public partial class InputListnoForm : Form
    {
        public string ReturnValue { get; set; }

        public InputListnoForm()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void btncomfirm_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ReturnValue = txtlistno.Text;
                using (lsDataClassesDataContext db = new lsDataClassesDataContext(@"server =" + globalvariable.mylocate + ";database=" + globalvariable.mydbname + ";uid=sa;pwd=" + globalvariable.mydbpass + ";Connect Timeout=180;"))
                {
                    db.CommandTimeout = 10 * 60;
                    long thecount = (from d in db.inv_main
                                     where d.list_no.Trim() == ReturnValue.Trim()
                                     select d).Count();
                    if (thecount == 0)
                    {
                        MessageBox.Show("查无此单：" + ReturnValue);
                        return;
                    }

                    thecount = (from d in db.inv_main
                                where d.list_no.Trim() == ReturnValue.Trim() && d.JKSCBZ== '1'
                                select d).Count();

                     if(thecount>0)
                     {
                          DialogResult result2 = MessageBox.Show("这张单已经上传过社保局，你确认要再上传吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result2 == DialogResult.No)
                            return;
                     }
                }

                this.Close();
            }
        }

        private void InputListnoForm_Load(object sender, EventArgs e)
        {
           txtlistno.Text=Clipboard.GetText();
        }
    }
}
