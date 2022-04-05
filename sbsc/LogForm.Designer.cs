namespace sbsc
{
    partial class LogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mytab = new System.Windows.Forms.TabControl();
            this.normalexp = new System.Windows.Forms.TabPage();
            this.exitbtn = new System.Windows.Forms.Button();
            this.refreshbtn = new System.Windows.Forms.Button();
            this.errexcelexpbtn = new System.Windows.Forms.Button();
            this.expgrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.serialno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.err_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.err_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.err_bywho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prod_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.batch_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prod_Add = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prod_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prod_size = new DevExpress.XtraGrid.Columns.GridColumn();
            this.last_dep_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.inv_num = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dep_num = new DevExpress.XtraGrid.Columns.GridColumn();
            this.description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.anotherexp = new System.Windows.Forms.TabPage();
            this.btnrefreshexp = new System.Windows.Forms.Button();
            this.btnexit2 = new System.Windows.Forms.Button();
            this.btnexptxt = new System.Windows.Forms.Button();
            this.errtext = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog3save = new System.Windows.Forms.FolderBrowserDialog();
            this.mytab.SuspendLayout();
            this.normalexp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expgrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.anotherexp.SuspendLayout();
            this.SuspendLayout();
            // 
            // mytab
            // 
            this.mytab.Controls.Add(this.normalexp);
            this.mytab.Controls.Add(this.anotherexp);
            this.mytab.Location = new System.Drawing.Point(46, 35);
            this.mytab.Name = "mytab";
            this.mytab.SelectedIndex = 0;
            this.mytab.Size = new System.Drawing.Size(781, 455);
            this.mytab.TabIndex = 0;
            // 
            // normalexp
            // 
            this.normalexp.Controls.Add(this.exitbtn);
            this.normalexp.Controls.Add(this.refreshbtn);
            this.normalexp.Controls.Add(this.errexcelexpbtn);
            this.normalexp.Controls.Add(this.expgrid);
            this.normalexp.Location = new System.Drawing.Point(4, 21);
            this.normalexp.Name = "normalexp";
            this.normalexp.Padding = new System.Windows.Forms.Padding(3);
            this.normalexp.Size = new System.Drawing.Size(773, 430);
            this.normalexp.TabIndex = 0;
            this.normalexp.Text = "普通异常";
            this.normalexp.UseVisualStyleBackColor = true;
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(213, 6);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(75, 23);
            this.exitbtn.TabIndex = 3;
            this.exitbtn.Text = "退出";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // refreshbtn
            // 
            this.refreshbtn.Location = new System.Drawing.Point(19, 6);
            this.refreshbtn.Name = "refreshbtn";
            this.refreshbtn.Size = new System.Drawing.Size(75, 23);
            this.refreshbtn.TabIndex = 2;
            this.refreshbtn.Text = "刷新";
            this.refreshbtn.UseVisualStyleBackColor = true;
            this.refreshbtn.Click += new System.EventHandler(this.refreshbtn_Click);
            // 
            // errexcelexpbtn
            // 
            this.errexcelexpbtn.Location = new System.Drawing.Point(114, 6);
            this.errexcelexpbtn.Name = "errexcelexpbtn";
            this.errexcelexpbtn.Size = new System.Drawing.Size(75, 23);
            this.errexcelexpbtn.TabIndex = 1;
            this.errexcelexpbtn.Text = "导出EXCEL";
            this.errexcelexpbtn.UseVisualStyleBackColor = true;
            this.errexcelexpbtn.Click += new System.EventHandler(this.errexcelexpbtn_Click);
            // 
            // expgrid
            // 
            this.expgrid.Location = new System.Drawing.Point(6, 48);
            this.expgrid.MainView = this.gridView1;
            this.expgrid.Name = "expgrid";
            this.expgrid.Size = new System.Drawing.Size(761, 376);
            this.expgrid.TabIndex = 0;
            this.expgrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.serialno,
            this.err_no,
            this.err_date,
            this.err_bywho,
            this.prod_no,
            this.batch_no,
            this.prod_Add,
            this.prod_name,
            this.prod_size,
            this.last_dep_no,
            this.inv_num,
            this.dep_num,
            this.description});
            this.gridView1.GridControl = this.expgrid;
            this.gridView1.Name = "gridView1";
            // 
            // serialno
            // 
            this.serialno.AppearanceHeader.Options.UseTextOptions = true;
            this.serialno.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.serialno.Caption = "序列";
            this.serialno.MaxWidth = 50;
            this.serialno.MinWidth = 50;
            this.serialno.Name = "serialno";
            this.serialno.Visible = true;
            this.serialno.VisibleIndex = 0;
            this.serialno.Width = 50;
            // 
            // err_no
            // 
            this.err_no.AppearanceHeader.Options.UseTextOptions = true;
            this.err_no.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.err_no.Caption = "异常单号";
            this.err_no.MaxWidth = 200;
            this.err_no.MinWidth = 200;
            this.err_no.Name = "err_no";
            this.err_no.Visible = true;
            this.err_no.VisibleIndex = 1;
            this.err_no.Width = 200;
            // 
            // err_date
            // 
            this.err_date.AppearanceHeader.Options.UseTextOptions = true;
            this.err_date.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.err_date.Caption = "日期";
            this.err_date.MaxWidth = 100;
            this.err_date.MinWidth = 100;
            this.err_date.Name = "err_date";
            this.err_date.Visible = true;
            this.err_date.VisibleIndex = 2;
            this.err_date.Width = 100;
            // 
            // err_bywho
            // 
            this.err_bywho.AppearanceHeader.Options.UseTextOptions = true;
            this.err_bywho.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.err_bywho.Caption = "操作员";
            this.err_bywho.MaxWidth = 50;
            this.err_bywho.MinWidth = 50;
            this.err_bywho.Name = "err_bywho";
            this.err_bywho.Visible = true;
            this.err_bywho.VisibleIndex = 3;
            this.err_bywho.Width = 50;
            // 
            // prod_no
            // 
            this.prod_no.AppearanceHeader.Options.UseTextOptions = true;
            this.prod_no.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.prod_no.Caption = "药品编号";
            this.prod_no.MaxWidth = 100;
            this.prod_no.MinWidth = 100;
            this.prod_no.Name = "prod_no";
            this.prod_no.Visible = true;
            this.prod_no.VisibleIndex = 4;
            this.prod_no.Width = 100;
            // 
            // batch_no
            // 
            this.batch_no.AppearanceHeader.Options.UseTextOptions = true;
            this.batch_no.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.batch_no.Caption = "批号";
            this.batch_no.MaxWidth = 100;
            this.batch_no.MinWidth = 100;
            this.batch_no.Name = "batch_no";
            this.batch_no.Visible = true;
            this.batch_no.VisibleIndex = 5;
            this.batch_no.Width = 100;
            // 
            // prod_Add
            // 
            this.prod_Add.AppearanceHeader.Options.UseTextOptions = true;
            this.prod_Add.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.prod_Add.Caption = "产地";
            this.prod_Add.MaxWidth = 100;
            this.prod_Add.MinWidth = 100;
            this.prod_Add.Name = "prod_Add";
            this.prod_Add.Visible = true;
            this.prod_Add.VisibleIndex = 6;
            this.prod_Add.Width = 100;
            // 
            // prod_name
            // 
            this.prod_name.AppearanceHeader.Options.UseTextOptions = true;
            this.prod_name.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.prod_name.Caption = "药品名称";
            this.prod_name.MaxWidth = 200;
            this.prod_name.MinWidth = 200;
            this.prod_name.Name = "prod_name";
            this.prod_name.Visible = true;
            this.prod_name.VisibleIndex = 7;
            this.prod_name.Width = 200;
            // 
            // prod_size
            // 
            this.prod_size.Caption = "规格";
            this.prod_size.MaxWidth = 100;
            this.prod_size.MinWidth = 100;
            this.prod_size.Name = "prod_size";
            this.prod_size.Visible = true;
            this.prod_size.VisibleIndex = 8;
            this.prod_size.Width = 100;
            // 
            // last_dep_no
            // 
            this.last_dep_no.AppearanceHeader.Options.UseTextOptions = true;
            this.last_dep_no.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.last_dep_no.Caption = "进仓单号";
            this.last_dep_no.MaxWidth = 100;
            this.last_dep_no.MinWidth = 100;
            this.last_dep_no.Name = "last_dep_no";
            this.last_dep_no.Visible = true;
            this.last_dep_no.VisibleIndex = 9;
            this.last_dep_no.Width = 100;
            // 
            // inv_num
            // 
            this.inv_num.AppearanceHeader.Options.UseTextOptions = true;
            this.inv_num.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.inv_num.Caption = "总销售数";
            this.inv_num.MaxWidth = 100;
            this.inv_num.MinWidth = 100;
            this.inv_num.Name = "inv_num";
            this.inv_num.Visible = true;
            this.inv_num.VisibleIndex = 10;
            this.inv_num.Width = 100;
            // 
            // dep_num
            // 
            this.dep_num.AppearanceHeader.Options.UseTextOptions = true;
            this.dep_num.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dep_num.Caption = "总进仓数";
            this.dep_num.MaxWidth = 100;
            this.dep_num.MinWidth = 100;
            this.dep_num.Name = "dep_num";
            this.dep_num.Visible = true;
            this.dep_num.VisibleIndex = 11;
            this.dep_num.Width = 100;
            // 
            // description
            // 
            this.description.AppearanceHeader.Options.UseTextOptions = true;
            this.description.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.description.Caption = "描述";
            this.description.MaxWidth = 500;
            this.description.MinWidth = 500;
            this.description.Name = "description";
            this.description.Visible = true;
            this.description.VisibleIndex = 12;
            this.description.Width = 500;
            // 
            // anotherexp
            // 
            this.anotherexp.Controls.Add(this.btnrefreshexp);
            this.anotherexp.Controls.Add(this.btnexit2);
            this.anotherexp.Controls.Add(this.btnexptxt);
            this.anotherexp.Controls.Add(this.errtext);
            this.anotherexp.Location = new System.Drawing.Point(4, 21);
            this.anotherexp.Name = "anotherexp";
            this.anotherexp.Padding = new System.Windows.Forms.Padding(3);
            this.anotherexp.Size = new System.Drawing.Size(773, 430);
            this.anotherexp.TabIndex = 1;
            this.anotherexp.Text = "数据库操作异常";
            this.anotherexp.UseVisualStyleBackColor = true;
            // 
            // btnrefreshexp
            // 
            this.btnrefreshexp.Location = new System.Drawing.Point(23, 19);
            this.btnrefreshexp.Name = "btnrefreshexp";
            this.btnrefreshexp.Size = new System.Drawing.Size(75, 23);
            this.btnrefreshexp.TabIndex = 3;
            this.btnrefreshexp.Text = "刷新";
            this.btnrefreshexp.UseVisualStyleBackColor = true;
            this.btnrefreshexp.Click += new System.EventHandler(this.btnrefreshexp_Click);
            // 
            // btnexit2
            // 
            this.btnexit2.Location = new System.Drawing.Point(210, 19);
            this.btnexit2.Name = "btnexit2";
            this.btnexit2.Size = new System.Drawing.Size(75, 23);
            this.btnexit2.TabIndex = 2;
            this.btnexit2.Text = "退出";
            this.btnexit2.UseVisualStyleBackColor = true;
            this.btnexit2.Click += new System.EventHandler(this.btnexit2_Click);
            // 
            // btnexptxt
            // 
            this.btnexptxt.Location = new System.Drawing.Point(118, 19);
            this.btnexptxt.Name = "btnexptxt";
            this.btnexptxt.Size = new System.Drawing.Size(75, 23);
            this.btnexptxt.TabIndex = 1;
            this.btnexptxt.Text = "导出异常";
            this.btnexptxt.UseVisualStyleBackColor = true;
            this.btnexptxt.Click += new System.EventHandler(this.btnexptxt_Click);
            // 
            // errtext
            // 
            this.errtext.Location = new System.Drawing.Point(23, 48);
            this.errtext.Multiline = true;
            this.errtext.Name = "errtext";
            this.errtext.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.errtext.Size = new System.Drawing.Size(711, 357);
            this.errtext.TabIndex = 0;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 502);
            this.Controls.Add(this.mytab);
            this.Name = "LogForm";
            this.Text = "日志";
            this.Load += new System.EventHandler(this.LogForm_Load);
            this.mytab.ResumeLayout(false);
            this.normalexp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expgrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.anotherexp.ResumeLayout(false);
            this.anotherexp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mytab;
        private System.Windows.Forms.TabPage normalexp;
        private System.Windows.Forms.TabPage anotherexp;
        private System.Windows.Forms.Button errexcelexpbtn;
        private DevExpress.XtraGrid.GridControl expgrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btnexptxt;
        private System.Windows.Forms.TextBox errtext;
        private DevExpress.XtraGrid.Columns.GridColumn serialno;
        private DevExpress.XtraGrid.Columns.GridColumn err_no;
        private DevExpress.XtraGrid.Columns.GridColumn err_date;
        private DevExpress.XtraGrid.Columns.GridColumn err_bywho;
        private DevExpress.XtraGrid.Columns.GridColumn prod_no;
        private DevExpress.XtraGrid.Columns.GridColumn batch_no;
        private DevExpress.XtraGrid.Columns.GridColumn prod_Add;
        private DevExpress.XtraGrid.Columns.GridColumn prod_name;
        private DevExpress.XtraGrid.Columns.GridColumn last_dep_no;
        private DevExpress.XtraGrid.Columns.GridColumn inv_num;
        private DevExpress.XtraGrid.Columns.GridColumn dep_num;
        private DevExpress.XtraGrid.Columns.GridColumn description;
        private DevExpress.XtraGrid.Columns.GridColumn prod_size;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button refreshbtn;
        private System.Windows.Forms.Button btnrefreshexp;
        private System.Windows.Forms.Button btnexit2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog3save;
    }
}