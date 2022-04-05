namespace sbsc
{
    partial class UploadDepForm
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
            this.txtbegdate = new System.Windows.Forms.TextBox();
            this.txtenddate = new System.Windows.Forms.TextBox();
            this.labbegindate = new System.Windows.Forms.Label();
            this.labenddate = new System.Windows.Forms.Label();
            this.btnquery = new System.Windows.Forms.Button();
            this.btnfilter = new System.Windows.Forms.Button();
            this.btnsort = new System.Windows.Forms.Button();
            this.btnupload = new System.Windows.Forms.Button();
            this.exitbtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnchoosemonth = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnexportexcel = new System.Windows.Forms.Button();
            this.rbdisplaydidntupload = new System.Windows.Forms.RadioButton();
            this.rbdisplayall = new System.Windows.Forms.RadioButton();
            this.gridmain = new DevExpress.XtraGrid.GridControl();
            this.mainview = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.serial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.thetype = new DevExpress.XtraGrid.Columns.GridColumn();
            this.listno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clino = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cliname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.thedate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.themon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.theno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sfyjsc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridsub = new DevExpress.XtraGrid.GridControl();
            this.subview = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.serialno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.thelistno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prodno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.zyprodno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prodname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.batchno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prodadd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prodsize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.monad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.invnum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sellprice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.je = new DevExpress.XtraGrid.Columns.GridColumn();
            this.availdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.monthcalend = new System.Windows.Forms.MonthCalendar();
            this.labwarning = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbcalaccurate = new System.Windows.Forms.RadioButton();
            this.rbcalfaster = new System.Windows.Forms.RadioButton();
            this.labwarning2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridmain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridsub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subview)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbegdate
            // 
            this.txtbegdate.Location = new System.Drawing.Point(182, 25);
            this.txtbegdate.Name = "txtbegdate";
            this.txtbegdate.ReadOnly = true;
            this.txtbegdate.Size = new System.Drawing.Size(131, 21);
            this.txtbegdate.TabIndex = 1;
            // 
            // txtenddate
            // 
            this.txtenddate.Location = new System.Drawing.Point(390, 25);
            this.txtenddate.Name = "txtenddate";
            this.txtenddate.ReadOnly = true;
            this.txtenddate.Size = new System.Drawing.Size(131, 21);
            this.txtenddate.TabIndex = 2;
            // 
            // labbegindate
            // 
            this.labbegindate.AutoSize = true;
            this.labbegindate.Location = new System.Drawing.Point(111, 25);
            this.labbegindate.Name = "labbegindate";
            this.labbegindate.Size = new System.Drawing.Size(65, 12);
            this.labbegindate.TabIndex = 4;
            this.labbegindate.Text = "开始日期：";
            // 
            // labenddate
            // 
            this.labenddate.AutoSize = true;
            this.labenddate.Location = new System.Drawing.Point(319, 25);
            this.labenddate.Name = "labenddate";
            this.labenddate.Size = new System.Drawing.Size(65, 12);
            this.labenddate.TabIndex = 5;
            this.labenddate.Text = "结束日期：";
            // 
            // btnquery
            // 
            this.btnquery.Location = new System.Drawing.Point(11, 20);
            this.btnquery.Name = "btnquery";
            this.btnquery.Size = new System.Drawing.Size(75, 23);
            this.btnquery.TabIndex = 6;
            this.btnquery.Text = "查询";
            this.btnquery.UseVisualStyleBackColor = true;
            this.btnquery.Click += new System.EventHandler(this.btnquery_Click);
            // 
            // btnfilter
            // 
            this.btnfilter.Enabled = false;
            this.btnfilter.Location = new System.Drawing.Point(101, 20);
            this.btnfilter.Name = "btnfilter";
            this.btnfilter.Size = new System.Drawing.Size(75, 23);
            this.btnfilter.TabIndex = 7;
            this.btnfilter.Text = "过滤";
            this.btnfilter.UseVisualStyleBackColor = true;
            this.btnfilter.Click += new System.EventHandler(this.btnfilter_Click);
            // 
            // btnsort
            // 
            this.btnsort.Enabled = false;
            this.btnsort.Location = new System.Drawing.Point(191, 20);
            this.btnsort.Name = "btnsort";
            this.btnsort.Size = new System.Drawing.Size(75, 23);
            this.btnsort.TabIndex = 8;
            this.btnsort.Text = "排序";
            this.btnsort.UseVisualStyleBackColor = true;
            // 
            // btnupload
            // 
            this.btnupload.Location = new System.Drawing.Point(281, 20);
            this.btnupload.Name = "btnupload";
            this.btnupload.Size = new System.Drawing.Size(75, 23);
            this.btnupload.TabIndex = 11;
            this.btnupload.Text = "上传";
            this.btnupload.UseVisualStyleBackColor = true;
            this.btnupload.Click += new System.EventHandler(this.btnupload_Click);
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(463, 20);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(75, 23);
            this.exitbtn.TabIndex = 12;
            this.exitbtn.Text = "退出";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnchoosemonth);
            this.groupBox1.Controls.Add(this.txtbegdate);
            this.groupBox1.Controls.Add(this.txtenddate);
            this.groupBox1.Controls.Add(this.labbegindate);
            this.groupBox1.Controls.Add(this.labenddate);
            this.groupBox1.Location = new System.Drawing.Point(32, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(671, 55);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "月份选择查询";
            // 
            // btnchoosemonth
            // 
            this.btnchoosemonth.Location = new System.Drawing.Point(11, 20);
            this.btnchoosemonth.Name = "btnchoosemonth";
            this.btnchoosemonth.Size = new System.Drawing.Size(75, 23);
            this.btnchoosemonth.TabIndex = 6;
            this.btnchoosemonth.Text = "选择月份";
            this.btnchoosemonth.UseVisualStyleBackColor = true;
            this.btnchoosemonth.Click += new System.EventHandler(this.btnchoosemonth_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnexportexcel);
            this.groupBox2.Controls.Add(this.btnquery);
            this.groupBox2.Controls.Add(this.btnfilter);
            this.groupBox2.Controls.Add(this.exitbtn);
            this.groupBox2.Controls.Add(this.btnsort);
            this.groupBox2.Controls.Add(this.btnupload);
            this.groupBox2.Location = new System.Drawing.Point(32, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(722, 58);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // btnexportexcel
            // 
            this.btnexportexcel.Location = new System.Drawing.Point(371, 20);
            this.btnexportexcel.Name = "btnexportexcel";
            this.btnexportexcel.Size = new System.Drawing.Size(75, 23);
            this.btnexportexcel.TabIndex = 12;
            this.btnexportexcel.Text = "导出EXCEL";
            this.btnexportexcel.UseVisualStyleBackColor = true;
            this.btnexportexcel.Click += new System.EventHandler(this.btnexportexcel_Click);
            // 
            // rbdisplaydidntupload
            // 
            this.rbdisplaydidntupload.AutoSize = true;
            this.rbdisplaydidntupload.Checked = true;
            this.rbdisplaydidntupload.Location = new System.Drawing.Point(6, 20);
            this.rbdisplaydidntupload.Name = "rbdisplaydidntupload";
            this.rbdisplaydidntupload.Size = new System.Drawing.Size(95, 16);
            this.rbdisplaydidntupload.TabIndex = 15;
            this.rbdisplaydidntupload.TabStop = true;
            this.rbdisplaydidntupload.Text = "只显示未上传";
            this.rbdisplaydidntupload.UseVisualStyleBackColor = true;
            this.rbdisplaydidntupload.CheckedChanged += new System.EventHandler(this.rbdisplaydidntupload_CheckedChanged);
            // 
            // rbdisplayall
            // 
            this.rbdisplayall.AutoSize = true;
            this.rbdisplayall.Location = new System.Drawing.Point(107, 20);
            this.rbdisplayall.Name = "rbdisplayall";
            this.rbdisplayall.Size = new System.Drawing.Size(203, 16);
            this.rbdisplayall.TabIndex = 16;
            this.rbdisplayall.TabStop = true;
            this.rbdisplayall.Text = "显示已经上传和未上传的所有记录";
            this.rbdisplayall.UseVisualStyleBackColor = true;
            this.rbdisplayall.Click += new System.EventHandler(this.rbdisplayall_Click);
            this.rbdisplayall.CheckedChanged += new System.EventHandler(this.rbdisplayall_CheckedChanged);
            // 
            // gridmain
            // 
            this.gridmain.Location = new System.Drawing.Point(32, 204);
            this.gridmain.MainView = this.mainview;
            this.gridmain.Name = "gridmain";
            this.gridmain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridmain.Size = new System.Drawing.Size(795, 256);
            this.gridmain.TabIndex = 17;
            this.gridmain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.mainview});
            // 
            // mainview
            // 
            this.mainview.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.serial,
            this.thetype,
            this.listno,
            this.clino,
            this.cliname,
            this.thedate,
            this.themon,
            this.theno,
            this.sfyjsc});
            this.mainview.GridControl = this.gridmain;
            this.mainview.Name = "mainview";
            this.mainview.DoubleClick += new System.EventHandler(this.mainview_DoubleClick);
            // 
            // serial
            // 
            this.serial.AppearanceHeader.Options.UseTextOptions = true;
            this.serial.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.serial.Caption = "序列";
            this.serial.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.serial.FieldName = "serial";
            this.serial.MaxWidth = 50;
            this.serial.MinWidth = 50;
            this.serial.Name = "serial";
            this.serial.OptionsColumn.AllowEdit = false;
            this.serial.OptionsColumn.ReadOnly = true;
            this.serial.Visible = true;
            this.serial.VisibleIndex = 0;
            this.serial.Width = 50;
            // 
            // thetype
            // 
            this.thetype.AppearanceHeader.Options.UseTextOptions = true;
            this.thetype.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.thetype.Caption = "类型";
            this.thetype.FieldName = "thetype";
            this.thetype.MaxWidth = 100;
            this.thetype.MinWidth = 100;
            this.thetype.Name = "thetype";
            this.thetype.OptionsColumn.AllowEdit = false;
            this.thetype.OptionsColumn.ReadOnly = true;
            this.thetype.Visible = true;
            this.thetype.VisibleIndex = 1;
            this.thetype.Width = 100;
            // 
            // listno
            // 
            this.listno.AppearanceHeader.Options.UseTextOptions = true;
            this.listno.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.listno.Caption = "单号";
            this.listno.FieldName = "listno";
            this.listno.MaxWidth = 200;
            this.listno.MinWidth = 200;
            this.listno.Name = "listno";
            this.listno.OptionsColumn.AllowEdit = false;
            this.listno.OptionsColumn.ReadOnly = true;
            this.listno.Visible = true;
            this.listno.VisibleIndex = 2;
            this.listno.Width = 200;
            // 
            // clino
            // 
            this.clino.AppearanceHeader.Options.UseTextOptions = true;
            this.clino.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clino.Caption = "客户/供应商编号";
            this.clino.FieldName = "clino";
            this.clino.MaxWidth = 70;
            this.clino.MinWidth = 70;
            this.clino.Name = "clino";
            this.clino.OptionsColumn.AllowEdit = false;
            this.clino.OptionsColumn.ReadOnly = true;
            this.clino.Visible = true;
            this.clino.VisibleIndex = 3;
            this.clino.Width = 70;
            // 
            // cliname
            // 
            this.cliname.AppearanceHeader.Options.UseTextOptions = true;
            this.cliname.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cliname.Caption = "客户/供应商名称";
            this.cliname.FieldName = "cliname";
            this.cliname.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.cliname.MaxWidth = 150;
            this.cliname.MinWidth = 150;
            this.cliname.Name = "cliname";
            this.cliname.Visible = true;
            this.cliname.VisibleIndex = 4;
            this.cliname.Width = 150;
            // 
            // thedate
            // 
            this.thedate.AppearanceHeader.Options.UseTextOptions = true;
            this.thedate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.thedate.Caption = "（销售/进仓）日期";
            this.thedate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.thedate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.thedate.FieldName = "thedate";
            this.thedate.MaxWidth = 150;
            this.thedate.MinWidth = 150;
            this.thedate.Name = "thedate";
            this.thedate.OptionsColumn.AllowEdit = false;
            this.thedate.OptionsColumn.ReadOnly = true;
            this.thedate.Visible = true;
            this.thedate.VisibleIndex = 5;
            this.thedate.Width = 150;
            // 
            // themon
            // 
            this.themon.AppearanceHeader.Options.UseTextOptions = true;
            this.themon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.themon.Caption = "金额";
            this.themon.DisplayFormat.FormatString = "N2";
            this.themon.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.themon.FieldName = "themon";
            this.themon.MaxWidth = 100;
            this.themon.MinWidth = 100;
            this.themon.Name = "themon";
            this.themon.OptionsColumn.AllowEdit = false;
            this.themon.OptionsColumn.ReadOnly = true;
            this.themon.Visible = true;
            this.themon.VisibleIndex = 6;
            this.themon.Width = 100;
            // 
            // theno
            // 
            this.theno.AppearanceHeader.Options.UseTextOptions = true;
            this.theno.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.theno.Caption = "操作员";
            this.theno.FieldName = "theno";
            this.theno.MaxWidth = 50;
            this.theno.MinWidth = 50;
            this.theno.Name = "theno";
            this.theno.OptionsColumn.AllowEdit = false;
            this.theno.OptionsColumn.ReadOnly = true;
            this.theno.Visible = true;
            this.theno.VisibleIndex = 7;
            this.theno.Width = 50;
            // 
            // sfyjsc
            // 
            this.sfyjsc.AppearanceHeader.Options.UseTextOptions = true;
            this.sfyjsc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.sfyjsc.Caption = "是否已上传";
            this.sfyjsc.FieldName = "sfyjsc";
            this.sfyjsc.MaxWidth = 70;
            this.sfyjsc.MinWidth = 70;
            this.sfyjsc.Name = "sfyjsc";
            this.sfyjsc.OptionsColumn.AllowEdit = false;
            this.sfyjsc.OptionsColumn.FixedWidth = true;
            this.sfyjsc.Visible = true;
            this.sfyjsc.VisibleIndex = 8;
            this.sfyjsc.Width = 20;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridsub
            // 
            this.gridsub.Location = new System.Drawing.Point(33, 466);
            this.gridsub.MainView = this.subview;
            this.gridsub.Name = "gridsub";
            this.gridsub.Size = new System.Drawing.Size(794, 219);
            this.gridsub.TabIndex = 18;
            this.gridsub.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.subview});
            // 
            // subview
            // 
            this.subview.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.serialno,
            this.thelistno,
            this.prodno,
            this.zyprodno,
            this.prodname,
            this.batchno,
            this.prodadd,
            this.prodsize,
            this.monad,
            this.invnum,
            this.sellprice,
            this.je,
            this.availdate});
            this.subview.GridControl = this.gridsub;
            this.subview.Name = "subview";
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
            this.serialno.OptionsColumn.ReadOnly = true;
            this.serialno.Visible = true;
            this.serialno.VisibleIndex = 0;
            this.serialno.Width = 50;
            // 
            // thelistno
            // 
            this.thelistno.AppearanceHeader.Options.UseTextOptions = true;
            this.thelistno.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.thelistno.Caption = "单号";
            this.thelistno.FieldName = "thelistno";
            this.thelistno.MaxWidth = 200;
            this.thelistno.MinWidth = 200;
            this.thelistno.Name = "thelistno";
            this.thelistno.OptionsColumn.AllowEdit = false;
            this.thelistno.OptionsColumn.ReadOnly = true;
            this.thelistno.Visible = true;
            this.thelistno.VisibleIndex = 1;
            this.thelistno.Width = 200;
            // 
            // prodno
            // 
            this.prodno.AppearanceHeader.Options.UseTextOptions = true;
            this.prodno.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.prodno.Caption = "药品编号";
            this.prodno.FieldName = "prodno";
            this.prodno.MaxWidth = 100;
            this.prodno.MinWidth = 100;
            this.prodno.Name = "prodno";
            this.prodno.OptionsColumn.AllowEdit = false;
            this.prodno.OptionsColumn.ReadOnly = true;
            this.prodno.Visible = true;
            this.prodno.VisibleIndex = 2;
            this.prodno.Width = 100;
            // 
            // zyprodno
            // 
            this.zyprodno.AppearanceHeader.Options.UseTextOptions = true;
            this.zyprodno.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.zyprodno.Caption = "中药配送编码";
            this.zyprodno.FieldName = "zyprodno";
            this.zyprodno.MaxWidth = 100;
            this.zyprodno.MinWidth = 100;
            this.zyprodno.Name = "zyprodno";
            this.zyprodno.OptionsColumn.AllowEdit = false;
            this.zyprodno.OptionsColumn.ReadOnly = true;
            this.zyprodno.Visible = true;
            this.zyprodno.VisibleIndex = 3;
            this.zyprodno.Width = 100;
            // 
            // prodname
            // 
            this.prodname.AppearanceHeader.Options.UseTextOptions = true;
            this.prodname.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.prodname.Caption = "药品名称";
            this.prodname.FieldName = "prodname";
            this.prodname.MaxWidth = 200;
            this.prodname.MinWidth = 200;
            this.prodname.Name = "prodname";
            this.prodname.OptionsColumn.AllowEdit = false;
            this.prodname.OptionsColumn.ReadOnly = true;
            this.prodname.Visible = true;
            this.prodname.VisibleIndex = 4;
            this.prodname.Width = 200;
            // 
            // batchno
            // 
            this.batchno.AppearanceHeader.Options.UseTextOptions = true;
            this.batchno.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.batchno.Caption = "批号";
            this.batchno.FieldName = "batchno";
            this.batchno.MaxWidth = 100;
            this.batchno.MinWidth = 100;
            this.batchno.Name = "batchno";
            this.batchno.OptionsColumn.AllowEdit = false;
            this.batchno.OptionsColumn.ReadOnly = true;
            this.batchno.Visible = true;
            this.batchno.VisibleIndex = 5;
            this.batchno.Width = 100;
            // 
            // prodadd
            // 
            this.prodadd.AppearanceHeader.Options.UseTextOptions = true;
            this.prodadd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.prodadd.Caption = "生产企业/产地";
            this.prodadd.FieldName = "prodadd";
            this.prodadd.MaxWidth = 100;
            this.prodadd.MinWidth = 100;
            this.prodadd.Name = "prodadd";
            this.prodadd.OptionsColumn.AllowEdit = false;
            this.prodadd.OptionsColumn.ReadOnly = true;
            this.prodadd.Visible = true;
            this.prodadd.VisibleIndex = 6;
            this.prodadd.Width = 100;
            // 
            // prodsize
            // 
            this.prodsize.AppearanceHeader.Options.UseTextOptions = true;
            this.prodsize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.prodsize.Caption = "规格";
            this.prodsize.FieldName = "prodsize";
            this.prodsize.MaxWidth = 100;
            this.prodsize.MinWidth = 100;
            this.prodsize.Name = "prodsize";
            this.prodsize.OptionsColumn.AllowEdit = false;
            this.prodsize.OptionsColumn.ReadOnly = true;
            this.prodsize.Visible = true;
            this.prodsize.VisibleIndex = 7;
            this.prodsize.Width = 100;
            // 
            // monad
            // 
            this.monad.AppearanceHeader.Options.UseTextOptions = true;
            this.monad.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.monad.Caption = "单位";
            this.monad.FieldName = "monad";
            this.monad.MaxWidth = 100;
            this.monad.MinWidth = 100;
            this.monad.Name = "monad";
            this.monad.OptionsColumn.AllowEdit = false;
            this.monad.OptionsColumn.ReadOnly = true;
            this.monad.Visible = true;
            this.monad.VisibleIndex = 8;
            this.monad.Width = 100;
            // 
            // invnum
            // 
            this.invnum.AppearanceHeader.Options.UseTextOptions = true;
            this.invnum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.invnum.Caption = "数量";
            this.invnum.DisplayFormat.FormatString = "N3";
            this.invnum.FieldName = "invnum";
            this.invnum.MaxWidth = 100;
            this.invnum.MinWidth = 100;
            this.invnum.Name = "invnum";
            this.invnum.OptionsColumn.AllowEdit = false;
            this.invnum.OptionsColumn.ReadOnly = true;
            this.invnum.Visible = true;
            this.invnum.VisibleIndex = 9;
            this.invnum.Width = 100;
            // 
            // sellprice
            // 
            this.sellprice.AppearanceHeader.Options.UseTextOptions = true;
            this.sellprice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.sellprice.Caption = "单价";
            this.sellprice.DisplayFormat.FormatString = "n2";
            this.sellprice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.sellprice.FieldName = "sellprice";
            this.sellprice.MaxWidth = 100;
            this.sellprice.MinWidth = 100;
            this.sellprice.Name = "sellprice";
            this.sellprice.OptionsColumn.AllowEdit = false;
            this.sellprice.OptionsColumn.ReadOnly = true;
            this.sellprice.Visible = true;
            this.sellprice.VisibleIndex = 10;
            this.sellprice.Width = 100;
            // 
            // je
            // 
            this.je.AppearanceHeader.Options.UseTextOptions = true;
            this.je.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.je.Caption = "金额";
            this.je.DisplayFormat.FormatString = "N2";
            this.je.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.je.FieldName = "je";
            this.je.MaxWidth = 100;
            this.je.MinWidth = 100;
            this.je.Name = "je";
            this.je.OptionsColumn.AllowEdit = false;
            this.je.OptionsColumn.ReadOnly = true;
            this.je.Visible = true;
            this.je.VisibleIndex = 11;
            this.je.Width = 100;
            // 
            // availdate
            // 
            this.availdate.AppearanceHeader.Options.UseTextOptions = true;
            this.availdate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.availdate.Caption = "有效期";
            this.availdate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.availdate.FieldName = "availdate";
            this.availdate.MaxWidth = 100;
            this.availdate.MinWidth = 100;
            this.availdate.Name = "availdate";
            this.availdate.OptionsColumn.AllowEdit = false;
            this.availdate.OptionsColumn.ReadOnly = true;
            this.availdate.Visible = true;
            this.availdate.VisibleIndex = 12;
            this.availdate.Width = 100;
            // 
            // monthcalend
            // 
            this.monthcalend.Location = new System.Drawing.Point(32, 204);
            this.monthcalend.Name = "monthcalend";
            this.monthcalend.TabIndex = 19;
            this.monthcalend.Visible = false;
            this.monthcalend.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthcalend_DateSelected);
            this.monthcalend.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthcalend_DateChanged);
            // 
            // labwarning
            // 
            this.labwarning.AutoSize = true;
            this.labwarning.Location = new System.Drawing.Point(32, 165);
            this.labwarning.Name = "labwarning";
            this.labwarning.Size = new System.Drawing.Size(677, 12);
            this.labwarning.TabIndex = 20;
            this.labwarning.Text = "注意：如果要看单据明细，请双击单据记录，另外千万不要在繁忙时间做此工作，因为此工作很消耗性能，会影响到收银的速度";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbdisplaydidntupload);
            this.groupBox3.Controls.Add(this.rbdisplayall);
            this.groupBox3.Location = new System.Drawing.Point(32, 114);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(334, 48);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询选项";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbcalaccurate);
            this.groupBox4.Controls.Add(this.rbcalfaster);
            this.groupBox4.Location = new System.Drawing.Point(373, 117);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(411, 45);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "上传进出库信息选项";
            // 
            // rbcalaccurate
            // 
            this.rbcalaccurate.AutoSize = true;
            this.rbcalaccurate.Location = new System.Drawing.Point(146, 20);
            this.rbcalaccurate.Name = "rbcalaccurate";
            this.rbcalaccurate.Size = new System.Drawing.Size(119, 16);
            this.rbcalaccurate.TabIndex = 1;
            this.rbcalaccurate.TabStop = true;
            this.rbcalaccurate.Text = "用较精确方法计算";
            this.rbcalaccurate.UseVisualStyleBackColor = true;
            // 
            // rbcalfaster
            // 
            this.rbcalfaster.AutoSize = true;
            this.rbcalfaster.Checked = true;
            this.rbcalfaster.Location = new System.Drawing.Point(16, 20);
            this.rbcalfaster.Name = "rbcalfaster";
            this.rbcalfaster.Size = new System.Drawing.Size(119, 16);
            this.rbcalfaster.TabIndex = 0;
            this.rbcalfaster.TabStop = true;
            this.rbcalfaster.Text = "用较快速方法计算";
            this.rbcalfaster.UseVisualStyleBackColor = true;
            // 
            // labwarning2
            // 
            this.labwarning2.AutoSize = true;
            this.labwarning2.Location = new System.Drawing.Point(66, 189);
            this.labwarning2.Name = "labwarning2";
            this.labwarning2.Size = new System.Drawing.Size(521, 12);
            this.labwarning2.TabIndex = 23;
            this.labwarning2.Text = "如果社保局来验收，验收时并不是验收这个界面，而是按了“上传”按扭后，能让你上传那个界面";
            // 
            // UploadDepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 709);
            this.Controls.Add(this.labwarning2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.monthcalend);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.labwarning);
            this.Controls.Add(this.gridsub);
            this.Controls.Add(this.gridmain);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UploadDepForm";
            this.Text = "上传进出库信息";
            this.Load += new System.EventHandler(this.UploadDepForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridmain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridsub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subview)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbegdate;
        private System.Windows.Forms.TextBox txtenddate;
        private System.Windows.Forms.Label labbegindate;
        private System.Windows.Forms.Label labenddate;
        private System.Windows.Forms.Button btnquery;
        private System.Windows.Forms.Button btnfilter;
        private System.Windows.Forms.Button btnsort;
        private System.Windows.Forms.Button btnupload;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbdisplaydidntupload;
        private System.Windows.Forms.RadioButton rbdisplayall;
        private DevExpress.XtraGrid.GridControl gridmain;
        private DevExpress.XtraGrid.Views.Grid.GridView mainview;
        private System.Windows.Forms.Button btnexportexcel;
        private DevExpress.XtraGrid.GridControl gridsub;
        private DevExpress.XtraGrid.Views.Grid.GridView subview;
        private System.Windows.Forms.Button btnchoosemonth;
        private System.Windows.Forms.MonthCalendar monthcalend;
        private DevExpress.XtraGrid.Columns.GridColumn serial;
        private DevExpress.XtraGrid.Columns.GridColumn thetype;
        private DevExpress.XtraGrid.Columns.GridColumn listno;
        private DevExpress.XtraGrid.Columns.GridColumn thedate;
        private DevExpress.XtraGrid.Columns.GridColumn themon;
        private DevExpress.XtraGrid.Columns.GridColumn theno;
        private DevExpress.XtraGrid.Columns.GridColumn sfyjsc;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn clino;
        private DevExpress.XtraGrid.Columns.GridColumn cliname;
        private DevExpress.XtraGrid.Columns.GridColumn serialno;
        private DevExpress.XtraGrid.Columns.GridColumn thelistno;
        private DevExpress.XtraGrid.Columns.GridColumn prodno;
        private DevExpress.XtraGrid.Columns.GridColumn zyprodno;
        private DevExpress.XtraGrid.Columns.GridColumn prodname;
        private DevExpress.XtraGrid.Columns.GridColumn batchno;
        private DevExpress.XtraGrid.Columns.GridColumn prodadd;
        private DevExpress.XtraGrid.Columns.GridColumn prodsize;
        private DevExpress.XtraGrid.Columns.GridColumn monad;
        private DevExpress.XtraGrid.Columns.GridColumn invnum;
        private DevExpress.XtraGrid.Columns.GridColumn sellprice;
        private DevExpress.XtraGrid.Columns.GridColumn je;
        private DevExpress.XtraGrid.Columns.GridColumn availdate;
        private System.Windows.Forms.Label labwarning;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbcalaccurate;
        private System.Windows.Forms.RadioButton rbcalfaster;
        private System.Windows.Forms.Label labwarning2;
    }
}