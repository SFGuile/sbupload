namespace sbsc
{
    partial class UploadRecordForm
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
            this.gb = new System.Windows.Forms.GroupBox();
            this.btnexit = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnexport = new System.Windows.Forms.Button();
            this.btnfilt = new System.Windows.Forms.Button();
            this.btnsort = new System.Windows.Forms.Button();
            this.btndeselectall = new System.Windows.Forms.Button();
            this.btnselectall = new System.Windows.Forms.Button();
            this.btnquery = new System.Windows.Forms.Button();
            this.invmaingrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.serialno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.myselect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.updno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.upload_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.upd_bywho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ny = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qxbz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qx_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.enddatbtn = new System.Windows.Forms.Button();
            this.txtbegdate = new System.Windows.Forms.TextBox();
            this.txtenddate = new System.Windows.Forms.TextBox();
            this.btnbegdate = new System.Windows.Forms.Button();
            this.labbegindate = new System.Windows.Forms.Label();
            this.labenddate = new System.Windows.Forms.Label();
            this.invsubgrid = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sn_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.upd_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prod_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prod_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prod_name2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dep_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prod_add = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prod_made = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sup_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.md_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dep_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.jx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prod_size = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dep_num = new DevExpress.XtraGrid.Columns.GridColumn();
            this.inv_num = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lest_num = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dep_mon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BZ1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BZ2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BZ3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mycount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labwaring = new System.Windows.Forms.Label();
            this.monthcal = new System.Windows.Forms.MonthCalendar();
            this.btnmark = new System.Windows.Forms.Button();
            this.gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invmaingrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invsubgrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.btnexit);
            this.gb.Controls.Add(this.btndelete);
            this.gb.Controls.Add(this.btnexport);
            this.gb.Controls.Add(this.btnfilt);
            this.gb.Controls.Add(this.btnsort);
            this.gb.Controls.Add(this.btndeselectall);
            this.gb.Controls.Add(this.btnselectall);
            this.gb.Controls.Add(this.btnquery);
            this.gb.Location = new System.Drawing.Point(33, 68);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(909, 50);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(647, 13);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(75, 23);
            this.btnexit.TabIndex = 7;
            this.btnexit.Text = "返回";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.button8_Click);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(462, 13);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(185, 23);
            this.btndelete.TabIndex = 6;
            this.btndelete.Text = "根据所选删除网上的进出库信息";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnexport
            // 
            this.btnexport.Location = new System.Drawing.Point(386, 13);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(75, 23);
            this.btnexport.TabIndex = 5;
            this.btnexport.Text = "导出excel";
            this.btnexport.UseVisualStyleBackColor = true;
            this.btnexport.Click += new System.EventHandler(this.btnexport_Click);
            // 
            // btnfilt
            // 
            this.btnfilt.Enabled = false;
            this.btnfilt.Location = new System.Drawing.Point(310, 13);
            this.btnfilt.Name = "btnfilt";
            this.btnfilt.Size = new System.Drawing.Size(75, 23);
            this.btnfilt.TabIndex = 4;
            this.btnfilt.Text = "过滤";
            this.btnfilt.UseVisualStyleBackColor = true;
            // 
            // btnsort
            // 
            this.btnsort.Enabled = false;
            this.btnsort.Location = new System.Drawing.Point(234, 13);
            this.btnsort.Name = "btnsort";
            this.btnsort.Size = new System.Drawing.Size(75, 23);
            this.btnsort.TabIndex = 3;
            this.btnsort.Text = "排序";
            this.btnsort.UseVisualStyleBackColor = true;
            // 
            // btndeselectall
            // 
            this.btndeselectall.Location = new System.Drawing.Point(158, 13);
            this.btndeselectall.Name = "btndeselectall";
            this.btndeselectall.Size = new System.Drawing.Size(75, 23);
            this.btndeselectall.TabIndex = 2;
            this.btndeselectall.Text = "全不选";
            this.btndeselectall.UseVisualStyleBackColor = true;
            this.btndeselectall.Click += new System.EventHandler(this.btndeselectall_Click);
            // 
            // btnselectall
            // 
            this.btnselectall.Location = new System.Drawing.Point(82, 13);
            this.btnselectall.Name = "btnselectall";
            this.btnselectall.Size = new System.Drawing.Size(75, 23);
            this.btnselectall.TabIndex = 1;
            this.btnselectall.Text = "全选";
            this.btnselectall.UseVisualStyleBackColor = true;
            this.btnselectall.Click += new System.EventHandler(this.btnselectall_Click);
            // 
            // btnquery
            // 
            this.btnquery.Location = new System.Drawing.Point(6, 13);
            this.btnquery.Name = "btnquery";
            this.btnquery.Size = new System.Drawing.Size(75, 23);
            this.btnquery.TabIndex = 0;
            this.btnquery.Text = "查询";
            this.btnquery.UseVisualStyleBackColor = true;
            this.btnquery.Click += new System.EventHandler(this.btnquery_Click);
            // 
            // invmaingrid
            // 
            this.invmaingrid.Location = new System.Drawing.Point(33, 150);
            this.invmaingrid.MainView = this.gridView1;
            this.invmaingrid.Name = "invmaingrid";
            this.invmaingrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.invmaingrid.Size = new System.Drawing.Size(712, 265);
            this.invmaingrid.TabIndex = 1;
            this.invmaingrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.serialno,
            this.myselect,
            this.updno,
            this.upload_date,
            this.upd_bywho,
            this.ny,
            this.qxbz,
            this.qx_date});
            this.gridView1.GridControl = this.invmaingrid;
            this.gridView1.Name = "gridView1";
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // serialno
            // 
            this.serialno.AppearanceHeader.Options.UseTextOptions = true;
            this.serialno.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.serialno.Caption = "序列";
            this.serialno.FieldName = "serialno";
            this.serialno.MaxWidth = 50;
            this.serialno.MinWidth = 50;
            this.serialno.Name = "serialno";
            this.serialno.OptionsColumn.AllowEdit = false;
            this.serialno.Visible = true;
            this.serialno.VisibleIndex = 0;
            this.serialno.Width = 50;
            // 
            // myselect
            // 
            this.myselect.AppearanceHeader.Options.UseTextOptions = true;
            this.myselect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.myselect.Caption = "选择";
            this.myselect.ColumnEdit = this.repositoryItemCheckEdit1;
            this.myselect.FieldName = "myselect";
            this.myselect.MaxWidth = 50;
            this.myselect.MinWidth = 50;
            this.myselect.Name = "myselect";
            this.myselect.Visible = true;
            this.myselect.VisibleIndex = 1;
            this.myselect.Width = 50;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // updno
            // 
            this.updno.AppearanceHeader.Options.UseTextOptions = true;
            this.updno.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.updno.Caption = "上传单号";
            this.updno.FieldName = "updno";
            this.updno.MaxWidth = 200;
            this.updno.MinWidth = 200;
            this.updno.Name = "updno";
            this.updno.OptionsColumn.AllowEdit = false;
            this.updno.Visible = true;
            this.updno.VisibleIndex = 2;
            this.updno.Width = 200;
            // 
            // upload_date
            // 
            this.upload_date.Caption = "上传时间";
            this.upload_date.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.upload_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.upload_date.FieldName = "upload_date";
            this.upload_date.MaxWidth = 150;
            this.upload_date.MinWidth = 150;
            this.upload_date.Name = "upload_date";
            this.upload_date.Visible = true;
            this.upload_date.VisibleIndex = 3;
            this.upload_date.Width = 150;
            // 
            // upd_bywho
            // 
            this.upd_bywho.AppearanceHeader.Options.UseTextOptions = true;
            this.upd_bywho.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.upd_bywho.Caption = "操作员";
            this.upd_bywho.FieldName = "upd_bywho";
            this.upd_bywho.MaxWidth = 100;
            this.upd_bywho.MinWidth = 100;
            this.upd_bywho.Name = "upd_bywho";
            this.upd_bywho.OptionsColumn.AllowEdit = false;
            this.upd_bywho.Visible = true;
            this.upd_bywho.VisibleIndex = 4;
            this.upd_bywho.Width = 100;
            // 
            // ny
            // 
            this.ny.AppearanceHeader.Options.UseTextOptions = true;
            this.ny.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ny.Caption = "上传信息所属年月";
            this.ny.FieldName = "ny";
            this.ny.MaxWidth = 100;
            this.ny.MinWidth = 100;
            this.ny.Name = "ny";
            this.ny.OptionsColumn.AllowEdit = false;
            this.ny.Visible = true;
            this.ny.VisibleIndex = 5;
            this.ny.Width = 100;
            // 
            // qxbz
            // 
            this.qxbz.AppearanceHeader.Options.UseTextOptions = true;
            this.qxbz.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.qxbz.Caption = "是否已取消";
            this.qxbz.FieldName = "qxbz";
            this.qxbz.MaxWidth = 90;
            this.qxbz.MinWidth = 90;
            this.qxbz.Name = "qxbz";
            this.qxbz.OptionsColumn.AllowEdit = false;
            this.qxbz.Visible = true;
            this.qxbz.VisibleIndex = 6;
            this.qxbz.Width = 90;
            // 
            // qx_date
            // 
            this.qx_date.AppearanceHeader.Options.UseTextOptions = true;
            this.qx_date.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.qx_date.Caption = "取消日期";
            this.qx_date.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.qx_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.qx_date.FieldName = "qx_date";
            this.qx_date.MaxWidth = 150;
            this.qx_date.MinWidth = 150;
            this.qx_date.Name = "qx_date";
            this.qx_date.OptionsColumn.AllowEdit = false;
            this.qx_date.Visible = true;
            this.qx_date.VisibleIndex = 7;
            this.qx_date.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.enddatbtn);
            this.groupBox1.Controls.Add(this.txtbegdate);
            this.groupBox1.Controls.Add(this.txtenddate);
            this.groupBox1.Controls.Add(this.btnbegdate);
            this.groupBox1.Controls.Add(this.labbegindate);
            this.groupBox1.Controls.Add(this.labenddate);
            this.groupBox1.Location = new System.Drawing.Point(33, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(593, 55);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日期选择查询";
            // 
            // enddatbtn
            // 
            this.enddatbtn.Location = new System.Drawing.Point(512, 20);
            this.enddatbtn.Name = "enddatbtn";
            this.enddatbtn.Size = new System.Drawing.Size(75, 23);
            this.enddatbtn.TabIndex = 0;
            this.enddatbtn.Text = "选择日期";
            this.enddatbtn.UseVisualStyleBackColor = true;
            this.enddatbtn.Click += new System.EventHandler(this.enddatbtn_Click);
            // 
            // txtbegdate
            // 
            this.txtbegdate.Location = new System.Drawing.Point(87, 20);
            this.txtbegdate.Name = "txtbegdate";
            this.txtbegdate.ReadOnly = true;
            this.txtbegdate.Size = new System.Drawing.Size(131, 21);
            this.txtbegdate.TabIndex = 1;
            // 
            // txtenddate
            // 
            this.txtenddate.Location = new System.Drawing.Point(375, 20);
            this.txtenddate.Name = "txtenddate";
            this.txtenddate.ReadOnly = true;
            this.txtenddate.Size = new System.Drawing.Size(131, 21);
            this.txtenddate.TabIndex = 2;
            // 
            // btnbegdate
            // 
            this.btnbegdate.Location = new System.Drawing.Point(224, 20);
            this.btnbegdate.Name = "btnbegdate";
            this.btnbegdate.Size = new System.Drawing.Size(74, 23);
            this.btnbegdate.TabIndex = 3;
            this.btnbegdate.Text = "选择日期";
            this.btnbegdate.UseVisualStyleBackColor = true;
            this.btnbegdate.Click += new System.EventHandler(this.btnbegdate_Click);
            // 
            // labbegindate
            // 
            this.labbegindate.AutoSize = true;
            this.labbegindate.Location = new System.Drawing.Point(16, 20);
            this.labbegindate.Name = "labbegindate";
            this.labbegindate.Size = new System.Drawing.Size(65, 12);
            this.labbegindate.TabIndex = 4;
            this.labbegindate.Text = "开始日期：";
            // 
            // labenddate
            // 
            this.labenddate.AutoSize = true;
            this.labenddate.Location = new System.Drawing.Point(304, 20);
            this.labenddate.Name = "labenddate";
            this.labenddate.Size = new System.Drawing.Size(65, 12);
            this.labenddate.TabIndex = 5;
            this.labenddate.Text = "结束日期：";
            // 
            // invsubgrid
            // 
            this.invsubgrid.Location = new System.Drawing.Point(33, 421);
            this.invsubgrid.MainView = this.gridView3;
            this.invsubgrid.Name = "invsubgrid";
            this.invsubgrid.Size = new System.Drawing.Size(712, 178);
            this.invsubgrid.TabIndex = 16;
            this.invsubgrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.sn_no,
            this.upd_no,
            this.prod_no,
            this.prod_name,
            this.prod_name2,
            this.dep_no,
            this.prod_add,
            this.prod_made,
            this.sup_name,
            this.md_name,
            this.dep_date,
            this.jx,
            this.prod_size,
            this.dep_num,
            this.inv_num,
            this.lest_num,
            this.dep_mon,
            this.BZ1,
            this.BZ2,
            this.BZ3,
            this.mycount});
            this.gridView3.GridControl = this.invsubgrid;
            this.gridView3.Name = "gridView3";
            // 
            // sn_no
            // 
            this.sn_no.AppearanceHeader.Options.UseTextOptions = true;
            this.sn_no.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.sn_no.Caption = "序列";
            this.sn_no.FieldName = "sn_no";
            this.sn_no.MaxWidth = 50;
            this.sn_no.MinWidth = 50;
            this.sn_no.Name = "sn_no";
            this.sn_no.OptionsColumn.AllowEdit = false;
            this.sn_no.Visible = true;
            this.sn_no.VisibleIndex = 0;
            this.sn_no.Width = 50;
            // 
            // upd_no
            // 
            this.upd_no.AppearanceHeader.Options.UseTextOptions = true;
            this.upd_no.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.upd_no.Caption = "上传单号";
            this.upd_no.FieldName = "upd_no";
            this.upd_no.MaxWidth = 200;
            this.upd_no.MinWidth = 200;
            this.upd_no.Name = "upd_no";
            this.upd_no.OptionsColumn.AllowEdit = false;
            this.upd_no.Visible = true;
            this.upd_no.VisibleIndex = 1;
            this.upd_no.Width = 200;
            // 
            // prod_no
            // 
            this.prod_no.AppearanceHeader.Options.UseTextOptions = true;
            this.prod_no.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.prod_no.Caption = "药品编号";
            this.prod_no.FieldName = "prod_no";
            this.prod_no.MaxWidth = 100;
            this.prod_no.MinWidth = 100;
            this.prod_no.Name = "prod_no";
            this.prod_no.OptionsColumn.AllowEdit = false;
            this.prod_no.Visible = true;
            this.prod_no.VisibleIndex = 2;
            this.prod_no.Width = 100;
            // 
            // prod_name
            // 
            this.prod_name.AppearanceHeader.Options.UseTextOptions = true;
            this.prod_name.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.prod_name.Caption = "药品名称";
            this.prod_name.FieldName = "prod_name";
            this.prod_name.MaxWidth = 300;
            this.prod_name.MinWidth = 300;
            this.prod_name.Name = "prod_name";
            this.prod_name.OptionsColumn.AllowEdit = false;
            this.prod_name.Visible = true;
            this.prod_name.VisibleIndex = 3;
            this.prod_name.Width = 300;
            // 
            // prod_name2
            // 
            this.prod_name2.AppearanceHeader.Options.UseTextOptions = true;
            this.prod_name2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.prod_name2.Caption = "通用名";
            this.prod_name2.FieldName = "prod_name2";
            this.prod_name2.MaxWidth = 300;
            this.prod_name2.MinWidth = 300;
            this.prod_name2.Name = "prod_name2";
            this.prod_name2.OptionsColumn.AllowEdit = false;
            this.prod_name2.Visible = true;
            this.prod_name2.VisibleIndex = 4;
            this.prod_name2.Width = 300;
            // 
            // dep_no
            // 
            this.dep_no.AppearanceHeader.Options.UseTextOptions = true;
            this.dep_no.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dep_no.Caption = "进仓单号";
            this.dep_no.FieldName = "dep_no";
            this.dep_no.MaxWidth = 150;
            this.dep_no.MinWidth = 150;
            this.dep_no.Name = "dep_no";
            this.dep_no.OptionsColumn.AllowEdit = false;
            this.dep_no.Visible = true;
            this.dep_no.VisibleIndex = 5;
            this.dep_no.Width = 150;
            // 
            // prod_add
            // 
            this.prod_add.AppearanceHeader.Options.UseTextOptions = true;
            this.prod_add.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.prod_add.Caption = "生产厂商（简）";
            this.prod_add.FieldName = "prod_add";
            this.prod_add.MaxWidth = 100;
            this.prod_add.MinWidth = 100;
            this.prod_add.Name = "prod_add";
            this.prod_add.OptionsColumn.AllowEdit = false;
            this.prod_add.Visible = true;
            this.prod_add.VisibleIndex = 6;
            this.prod_add.Width = 100;
            // 
            // prod_made
            // 
            this.prod_made.Caption = "生产厂商（详）";
            this.prod_made.FieldName = "prod_made";
            this.prod_made.MaxWidth = 200;
            this.prod_made.MinWidth = 200;
            this.prod_made.Name = "prod_made";
            this.prod_made.OptionsColumn.AllowEdit = false;
            this.prod_made.OptionsColumn.ReadOnly = true;
            this.prod_made.Visible = true;
            this.prod_made.VisibleIndex = 7;
            this.prod_made.Width = 200;
            // 
            // sup_name
            // 
            this.sup_name.AppearanceHeader.Options.UseTextOptions = true;
            this.sup_name.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.sup_name.Caption = "供应商名称";
            this.sup_name.FieldName = "sup_name";
            this.sup_name.MaxWidth = 100;
            this.sup_name.MinWidth = 100;
            this.sup_name.Name = "sup_name";
            this.sup_name.OptionsColumn.AllowEdit = false;
            this.sup_name.Visible = true;
            this.sup_name.VisibleIndex = 8;
            this.sup_name.Width = 100;
            // 
            // md_name
            // 
            this.md_name.AppearanceHeader.Options.UseTextOptions = true;
            this.md_name.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.md_name.Caption = "购货单位";
            this.md_name.FieldName = "md_name";
            this.md_name.MaxWidth = 100;
            this.md_name.MinWidth = 100;
            this.md_name.Name = "md_name";
            this.md_name.OptionsColumn.AllowEdit = false;
            this.md_name.Visible = true;
            this.md_name.VisibleIndex = 9;
            this.md_name.Width = 100;
            // 
            // dep_date
            // 
            this.dep_date.AppearanceHeader.Options.UseTextOptions = true;
            this.dep_date.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dep_date.Caption = "购货日期";
            this.dep_date.FieldName = "dep_date";
            this.dep_date.MaxWidth = 80;
            this.dep_date.MinWidth = 80;
            this.dep_date.Name = "dep_date";
            this.dep_date.OptionsColumn.AllowEdit = false;
            this.dep_date.Visible = true;
            this.dep_date.VisibleIndex = 10;
            this.dep_date.Width = 80;
            // 
            // jx
            // 
            this.jx.AppearanceHeader.Options.UseTextOptions = true;
            this.jx.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.jx.Caption = "剂型";
            this.jx.FieldName = "jx";
            this.jx.MaxWidth = 80;
            this.jx.MinWidth = 80;
            this.jx.Name = "jx";
            this.jx.OptionsColumn.AllowEdit = false;
            this.jx.Visible = true;
            this.jx.VisibleIndex = 11;
            this.jx.Width = 80;
            // 
            // prod_size
            // 
            this.prod_size.AppearanceHeader.Options.UseTextOptions = true;
            this.prod_size.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.prod_size.Caption = "规格";
            this.prod_size.FieldName = "prod_size";
            this.prod_size.MaxWidth = 100;
            this.prod_size.MinWidth = 100;
            this.prod_size.Name = "prod_size";
            this.prod_size.OptionsColumn.AllowEdit = false;
            this.prod_size.Visible = true;
            this.prod_size.VisibleIndex = 12;
            this.prod_size.Width = 100;
            // 
            // dep_num
            // 
            this.dep_num.AppearanceHeader.Options.UseTextOptions = true;
            this.dep_num.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dep_num.Caption = "购货数量";
            this.dep_num.FieldName = "dep_num";
            this.dep_num.MaxWidth = 80;
            this.dep_num.MinWidth = 80;
            this.dep_num.Name = "dep_num";
            this.dep_num.OptionsColumn.AllowEdit = false;
            this.dep_num.Visible = true;
            this.dep_num.VisibleIndex = 13;
            this.dep_num.Width = 80;
            // 
            // inv_num
            // 
            this.inv_num.AppearanceHeader.Options.UseTextOptions = true;
            this.inv_num.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.inv_num.Caption = "销货数量";
            this.inv_num.FieldName = "inv_num";
            this.inv_num.MaxWidth = 80;
            this.inv_num.MinWidth = 80;
            this.inv_num.Name = "inv_num";
            this.inv_num.OptionsColumn.AllowEdit = false;
            this.inv_num.Visible = true;
            this.inv_num.VisibleIndex = 14;
            this.inv_num.Width = 80;
            // 
            // lest_num
            // 
            this.lest_num.AppearanceHeader.Options.UseTextOptions = true;
            this.lest_num.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lest_num.Caption = "结存量";
            this.lest_num.FieldName = "lest_num";
            this.lest_num.MaxWidth = 80;
            this.lest_num.MinWidth = 80;
            this.lest_num.Name = "lest_num";
            this.lest_num.OptionsColumn.AllowEdit = false;
            this.lest_num.Visible = true;
            this.lest_num.VisibleIndex = 15;
            this.lest_num.Width = 80;
            // 
            // dep_mon
            // 
            this.dep_mon.AppearanceHeader.Options.UseTextOptions = true;
            this.dep_mon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dep_mon.Caption = "购货价格";
            this.dep_mon.FieldName = "dep_mon";
            this.dep_mon.MaxWidth = 80;
            this.dep_mon.MinWidth = 80;
            this.dep_mon.Name = "dep_mon";
            this.dep_mon.OptionsColumn.AllowEdit = false;
            this.dep_mon.Visible = true;
            this.dep_mon.VisibleIndex = 16;
            this.dep_mon.Width = 80;
            // 
            // BZ1
            // 
            this.BZ1.AppearanceHeader.Options.UseTextOptions = true;
            this.BZ1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.BZ1.Caption = "备注1";
            this.BZ1.FieldName = "BZ1";
            this.BZ1.MaxWidth = 50;
            this.BZ1.MinWidth = 50;
            this.BZ1.Name = "BZ1";
            this.BZ1.OptionsColumn.AllowEdit = false;
            this.BZ1.Visible = true;
            this.BZ1.VisibleIndex = 17;
            this.BZ1.Width = 50;
            // 
            // BZ2
            // 
            this.BZ2.AppearanceHeader.Options.UseTextOptions = true;
            this.BZ2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.BZ2.Caption = "备注2";
            this.BZ2.FieldName = "BZ2";
            this.BZ2.MaxWidth = 50;
            this.BZ2.MinWidth = 50;
            this.BZ2.Name = "BZ2";
            this.BZ2.OptionsColumn.AllowEdit = false;
            this.BZ2.Visible = true;
            this.BZ2.VisibleIndex = 18;
            this.BZ2.Width = 50;
            // 
            // BZ3
            // 
            this.BZ3.AppearanceHeader.Options.UseTextOptions = true;
            this.BZ3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.BZ3.Caption = "备注3";
            this.BZ3.FieldName = "BZ3";
            this.BZ3.MaxWidth = 50;
            this.BZ3.MinWidth = 50;
            this.BZ3.Name = "BZ3";
            this.BZ3.OptionsColumn.AllowEdit = false;
            this.BZ3.Visible = true;
            this.BZ3.VisibleIndex = 19;
            this.BZ3.Width = 50;
            // 
            // mycount
            // 
            this.mycount.Caption = "count";
            this.mycount.FieldName = "mycount";
            this.mycount.MaxWidth = 50;
            this.mycount.MinWidth = 50;
            this.mycount.Name = "mycount";
            this.mycount.OptionsColumn.AllowEdit = false;
            this.mycount.OptionsColumn.ReadOnly = true;
            this.mycount.Visible = true;
            this.mycount.VisibleIndex = 20;
            this.mycount.Width = 50;
            // 
            // labwaring
            // 
            this.labwaring.AutoSize = true;
            this.labwaring.Location = new System.Drawing.Point(39, 125);
            this.labwaring.Name = "labwaring";
            this.labwaring.Size = new System.Drawing.Size(233, 12);
            this.labwaring.TabIndex = 17;
            this.labwaring.Text = "注意：如果删除网上的资料只能整个月删除";
            // 
            // monthcal
            // 
            this.monthcal.Location = new System.Drawing.Point(3, 208);
            this.monthcal.Name = "monthcal";
            this.monthcal.TabIndex = 18;
            this.monthcal.Visible = false;
            this.monthcal.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthcal_DateSelected);
            this.monthcal.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthcal_DateChanged);
            // 
            // btnmark
            // 
            this.btnmark.Location = new System.Drawing.Point(756, 81);
            this.btnmark.Name = "btnmark";
            this.btnmark.Size = new System.Drawing.Size(175, 23);
            this.btnmark.TabIndex = 8;
            this.btnmark.Text = "将所选单标记为取消(备用)";
            this.btnmark.UseVisualStyleBackColor = true;
            this.btnmark.Click += new System.EventHandler(this.btnmark_Click);
            // 
            // UploadRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 608);
            this.Controls.Add(this.btnmark);
            this.Controls.Add(this.monthcal);
            this.Controls.Add(this.labwaring);
            this.Controls.Add(this.invsubgrid);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.invmaingrid);
            this.Controls.Add(this.gb);
            this.Name = "UploadRecordForm";
            this.Text = "上传过的进出库信息记录";
            this.Load += new System.EventHandler(this.UploadRecordForm_Load);
            this.gb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.invmaingrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invsubgrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Button btndeselectall;
        private System.Windows.Forms.Button btnselectall;
        private System.Windows.Forms.Button btnquery;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnexport;
        private System.Windows.Forms.Button btnfilt;
        private System.Windows.Forms.Button btnsort;
        private DevExpress.XtraGrid.GridControl invmaingrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button enddatbtn;
        private System.Windows.Forms.TextBox txtbegdate;
        private System.Windows.Forms.TextBox txtenddate;
        private System.Windows.Forms.Button btnbegdate;
        private System.Windows.Forms.Label labbegindate;
        private System.Windows.Forms.Label labenddate;
        private DevExpress.XtraGrid.GridControl invsubgrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private System.Windows.Forms.Label labwaring;
        private System.Windows.Forms.MonthCalendar monthcal;
        private DevExpress.XtraGrid.Columns.GridColumn serialno;
        private DevExpress.XtraGrid.Columns.GridColumn myselect;
        private DevExpress.XtraGrid.Columns.GridColumn updno;
        private DevExpress.XtraGrid.Columns.GridColumn upd_bywho;
        private DevExpress.XtraGrid.Columns.GridColumn ny;
        private DevExpress.XtraGrid.Columns.GridColumn qxbz;
        private DevExpress.XtraGrid.Columns.GridColumn qx_date;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn upd_no;
        private DevExpress.XtraGrid.Columns.GridColumn prod_no;
        private DevExpress.XtraGrid.Columns.GridColumn prod_name;
        private DevExpress.XtraGrid.Columns.GridColumn dep_no;
        private DevExpress.XtraGrid.Columns.GridColumn prod_add;
        private DevExpress.XtraGrid.Columns.GridColumn sup_name;
        private DevExpress.XtraGrid.Columns.GridColumn dep_date;
        private DevExpress.XtraGrid.Columns.GridColumn md_name;
        private DevExpress.XtraGrid.Columns.GridColumn sn_no;
        private DevExpress.XtraGrid.Columns.GridColumn dep_num;
        private DevExpress.XtraGrid.Columns.GridColumn inv_num;
        private DevExpress.XtraGrid.Columns.GridColumn lest_num;
        private DevExpress.XtraGrid.Columns.GridColumn dep_mon;
        private DevExpress.XtraGrid.Columns.GridColumn jx;
        private DevExpress.XtraGrid.Columns.GridColumn prod_size;
        private DevExpress.XtraGrid.Columns.GridColumn BZ1;
        private DevExpress.XtraGrid.Columns.GridColumn BZ2;
        private DevExpress.XtraGrid.Columns.GridColumn BZ3;
        private DevExpress.XtraGrid.Columns.GridColumn prod_name2;
        private DevExpress.XtraGrid.Columns.GridColumn upload_date;
        private System.Windows.Forms.Button btnmark;
        private DevExpress.XtraGrid.Columns.GridColumn prod_made;
        private DevExpress.XtraGrid.Columns.GridColumn mycount;
    }
}