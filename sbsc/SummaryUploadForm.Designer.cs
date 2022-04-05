namespace sbsc
{
    partial class SummaryUploadForm
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
            this.btnext = new System.Windows.Forms.Button();
            this.gridsummary = new DevExpress.XtraGrid.GridControl();
            this.sumaryview = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.serialno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.updno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.yybh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ny = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prodno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prodname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prodname2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.depno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prodadd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prodmade = new DevExpress.XtraGrid.Columns.GridColumn();
            this.supname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.depdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cliname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.jx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.prodsize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.depnum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.invnum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lestnum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.je = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BZ1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BZ2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BZ3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mycount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnexport = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labprogress = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btncapture = new System.Windows.Forms.Button();
            this.labwaring = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridsummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sumaryview)).BeginInit();
            this.SuspendLayout();
            // 
            // btnext
            // 
            this.btnext.Location = new System.Drawing.Point(482, 423);
            this.btnext.Name = "btnext";
            this.btnext.Size = new System.Drawing.Size(75, 23);
            this.btnext.TabIndex = 0;
            this.btnext.Text = "下一步>";
            this.btnext.UseVisualStyleBackColor = true;
            this.btnext.Click += new System.EventHandler(this.btnext_Click);
            // 
            // gridsummary
            // 
            this.gridsummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridsummary.Location = new System.Drawing.Point(24, 61);
            this.gridsummary.MainView = this.sumaryview;
            this.gridsummary.Name = "gridsummary";
            this.gridsummary.Size = new System.Drawing.Size(806, 343);
            this.gridsummary.TabIndex = 1;
            this.gridsummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.sumaryview});
            // 
            // sumaryview
            // 
            this.sumaryview.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.serialno,
            this.updno,
            this.yybh,
            this.ny,
            this.prodno,
            this.prodname,
            this.prodname2,
            this.depno,
            this.prodadd,
            this.prodmade,
            this.supname,
            this.depdate,
            this.cliname,
            this.jx,
            this.prodsize,
            this.depnum,
            this.invnum,
            this.lestnum,
            this.je,
            this.BZ1,
            this.BZ2,
            this.BZ3,
            this.mycount});
            this.sumaryview.GridControl = this.gridsummary;
            this.sumaryview.Name = "sumaryview";
            this.sumaryview.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.sumaryview_RowCellStyle);
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
            this.updno.OptionsColumn.ReadOnly = true;
            this.updno.Visible = true;
            this.updno.VisibleIndex = 1;
            this.updno.Width = 200;
            // 
            // yybh
            // 
            this.yybh.AppearanceHeader.Options.UseTextOptions = true;
            this.yybh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.yybh.Caption = "医药机构编号";
            this.yybh.FieldName = "yybh";
            this.yybh.MaxWidth = 100;
            this.yybh.MinWidth = 100;
            this.yybh.Name = "yybh";
            this.yybh.OptionsColumn.AllowEdit = false;
            this.yybh.OptionsColumn.ReadOnly = true;
            this.yybh.Visible = true;
            this.yybh.VisibleIndex = 2;
            this.yybh.Width = 100;
            // 
            // ny
            // 
            this.ny.AppearanceHeader.Options.UseTextOptions = true;
            this.ny.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ny.Caption = "年月";
            this.ny.FieldName = "ny";
            this.ny.MaxWidth = 100;
            this.ny.MinWidth = 100;
            this.ny.Name = "ny";
            this.ny.OptionsColumn.AllowEdit = false;
            this.ny.OptionsColumn.ReadOnly = true;
            this.ny.Visible = true;
            this.ny.VisibleIndex = 3;
            this.ny.Width = 100;
            // 
            // prodno
            // 
            this.prodno.AppearanceHeader.Options.UseTextOptions = true;
            this.prodno.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.prodno.Caption = "项目唯一ID";
            this.prodno.FieldName = "prodno";
            this.prodno.MaxWidth = 100;
            this.prodno.MinWidth = 100;
            this.prodno.Name = "prodno";
            this.prodno.OptionsColumn.AllowEdit = false;
            this.prodno.OptionsColumn.ReadOnly = true;
            this.prodno.Visible = true;
            this.prodno.VisibleIndex = 4;
            this.prodno.Width = 100;
            // 
            // prodname
            // 
            this.prodname.AppearanceHeader.Options.UseTextOptions = true;
            this.prodname.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.prodname.Caption = "项目名称";
            this.prodname.FieldName = "prodname";
            this.prodname.MaxWidth = 200;
            this.prodname.MinWidth = 200;
            this.prodname.Name = "prodname";
            this.prodname.OptionsColumn.AllowEdit = false;
            this.prodname.OptionsColumn.ReadOnly = true;
            this.prodname.Visible = true;
            this.prodname.VisibleIndex = 5;
            this.prodname.Width = 200;
            // 
            // prodname2
            // 
            this.prodname2.AppearanceHeader.Options.UseTextOptions = true;
            this.prodname2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.prodname2.Caption = "药品通用名称";
            this.prodname2.FieldName = "prodname2";
            this.prodname2.MaxWidth = 200;
            this.prodname2.MinWidth = 200;
            this.prodname2.Name = "prodname2";
            this.prodname2.OptionsColumn.AllowEdit = false;
            this.prodname2.OptionsColumn.ReadOnly = true;
            this.prodname2.Visible = true;
            this.prodname2.VisibleIndex = 6;
            this.prodname2.Width = 200;
            // 
            // depno
            // 
            this.depno.AppearanceHeader.Options.UseTextOptions = true;
            this.depno.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.depno.Caption = "入库单号";
            this.depno.FieldName = "depno";
            this.depno.MaxWidth = 200;
            this.depno.MinWidth = 200;
            this.depno.Name = "depno";
            this.depno.OptionsColumn.AllowEdit = false;
            this.depno.OptionsColumn.ReadOnly = true;
            this.depno.Visible = true;
            this.depno.VisibleIndex = 7;
            this.depno.Width = 200;
            // 
            // prodadd
            // 
            this.prodadd.AppearanceHeader.Options.UseTextOptions = true;
            this.prodadd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.prodadd.Caption = "生产厂商（简）";
            this.prodadd.FieldName = "prodadd";
            this.prodadd.MaxWidth = 150;
            this.prodadd.MinWidth = 150;
            this.prodadd.Name = "prodadd";
            this.prodadd.OptionsColumn.AllowEdit = false;
            this.prodadd.OptionsColumn.ReadOnly = true;
            this.prodadd.Visible = true;
            this.prodadd.VisibleIndex = 8;
            this.prodadd.Width = 150;
            // 
            // prodmade
            // 
            this.prodmade.Caption = "生产厂商（详）";
            this.prodmade.FieldName = "prodmade";
            this.prodmade.MaxWidth = 300;
            this.prodmade.MinWidth = 300;
            this.prodmade.Name = "prodmade";
            this.prodmade.OptionsColumn.AllowEdit = false;
            this.prodmade.OptionsColumn.ReadOnly = true;
            this.prodmade.Visible = true;
            this.prodmade.VisibleIndex = 9;
            this.prodmade.Width = 300;
            // 
            // supname
            // 
            this.supname.AppearanceHeader.Options.UseTextOptions = true;
            this.supname.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.supname.Caption = "购货单位";
            this.supname.FieldName = "supname";
            this.supname.MaxWidth = 250;
            this.supname.MinWidth = 250;
            this.supname.Name = "supname";
            this.supname.OptionsColumn.AllowEdit = false;
            this.supname.OptionsColumn.ReadOnly = true;
            this.supname.Visible = true;
            this.supname.VisibleIndex = 10;
            this.supname.Width = 250;
            // 
            // depdate
            // 
            this.depdate.Caption = "购货日期";
            this.depdate.FieldName = "depdate";
            this.depdate.MaxWidth = 100;
            this.depdate.MinWidth = 100;
            this.depdate.Name = "depdate";
            this.depdate.OptionsColumn.AllowEdit = false;
            this.depdate.OptionsColumn.ReadOnly = true;
            this.depdate.Visible = true;
            this.depdate.VisibleIndex = 11;
            this.depdate.Width = 100;
            // 
            // cliname
            // 
            this.cliname.Caption = "销货单位";
            this.cliname.FieldName = "cliname";
            this.cliname.MaxWidth = 300;
            this.cliname.MinWidth = 300;
            this.cliname.Name = "cliname";
            this.cliname.OptionsColumn.AllowEdit = false;
            this.cliname.OptionsColumn.ReadOnly = true;
            this.cliname.Visible = true;
            this.cliname.VisibleIndex = 12;
            this.cliname.Width = 300;
            // 
            // jx
            // 
            this.jx.AppearanceHeader.Options.UseTextOptions = true;
            this.jx.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.jx.Caption = "剂型";
            this.jx.FieldName = "jx";
            this.jx.MaxWidth = 120;
            this.jx.MinWidth = 120;
            this.jx.Name = "jx";
            this.jx.Visible = true;
            this.jx.VisibleIndex = 13;
            this.jx.Width = 120;
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
            this.prodsize.VisibleIndex = 14;
            this.prodsize.Width = 100;
            // 
            // depnum
            // 
            this.depnum.AppearanceHeader.Options.UseTextOptions = true;
            this.depnum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.depnum.Caption = "购货数量";
            this.depnum.DisplayFormat.FormatString = "N3";
            this.depnum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.depnum.FieldName = "depnum";
            this.depnum.MaxWidth = 100;
            this.depnum.MinWidth = 100;
            this.depnum.Name = "depnum";
            this.depnum.OptionsColumn.AllowEdit = false;
            this.depnum.OptionsColumn.ReadOnly = true;
            this.depnum.Visible = true;
            this.depnum.VisibleIndex = 15;
            this.depnum.Width = 100;
            // 
            // invnum
            // 
            this.invnum.AppearanceHeader.Options.UseTextOptions = true;
            this.invnum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.invnum.Caption = "销货数量";
            this.invnum.DisplayFormat.FormatString = "N3";
            this.invnum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.invnum.FieldName = "invnum";
            this.invnum.MaxWidth = 100;
            this.invnum.MinWidth = 100;
            this.invnum.Name = "invnum";
            this.invnum.OptionsColumn.AllowEdit = false;
            this.invnum.OptionsColumn.ReadOnly = true;
            this.invnum.Visible = true;
            this.invnum.VisibleIndex = 16;
            this.invnum.Width = 100;
            // 
            // lestnum
            // 
            this.lestnum.AppearanceHeader.Options.UseTextOptions = true;
            this.lestnum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lestnum.Caption = "结存量";
            this.lestnum.DisplayFormat.FormatString = "N3";
            this.lestnum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.lestnum.FieldName = "lestnum";
            this.lestnum.MaxWidth = 100;
            this.lestnum.MinWidth = 100;
            this.lestnum.Name = "lestnum";
            this.lestnum.OptionsColumn.AllowEdit = false;
            this.lestnum.OptionsColumn.ReadOnly = true;
            this.lestnum.Visible = true;
            this.lestnum.VisibleIndex = 17;
            this.lestnum.Width = 100;
            // 
            // je
            // 
            this.je.AppearanceHeader.Options.UseTextOptions = true;
            this.je.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.je.Caption = "购货价格(购货金额)";
            this.je.DisplayFormat.FormatString = "N2";
            this.je.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.je.FieldName = "je";
            this.je.MaxWidth = 100;
            this.je.MinWidth = 100;
            this.je.Name = "je";
            this.je.OptionsColumn.AllowEdit = false;
            this.je.OptionsColumn.ReadOnly = true;
            this.je.Visible = true;
            this.je.VisibleIndex = 18;
            this.je.Width = 100;
            // 
            // BZ1
            // 
            this.BZ1.AppearanceHeader.Options.UseTextOptions = true;
            this.BZ1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.BZ1.Caption = "备注1";
            this.BZ1.FieldName = "BZ1";
            this.BZ1.MaxWidth = 100;
            this.BZ1.MinWidth = 100;
            this.BZ1.Name = "BZ1";
            this.BZ1.Visible = true;
            this.BZ1.VisibleIndex = 19;
            this.BZ1.Width = 100;
            // 
            // BZ2
            // 
            this.BZ2.AppearanceHeader.Options.UseTextOptions = true;
            this.BZ2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.BZ2.Caption = "备注2";
            this.BZ2.FieldName = "BZ2";
            this.BZ2.MaxWidth = 100;
            this.BZ2.MinWidth = 100;
            this.BZ2.Name = "BZ2";
            this.BZ2.Visible = true;
            this.BZ2.VisibleIndex = 20;
            this.BZ2.Width = 100;
            // 
            // BZ3
            // 
            this.BZ3.AppearanceHeader.Options.UseTextOptions = true;
            this.BZ3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.BZ3.Caption = "备注3";
            this.BZ3.FieldName = "BZ3";
            this.BZ3.MaxWidth = 100;
            this.BZ3.MinWidth = 100;
            this.BZ3.Name = "BZ3";
            this.BZ3.Visible = true;
            this.BZ3.VisibleIndex = 21;
            this.BZ3.Width = 100;
            // 
            // mycount
            // 
            this.mycount.Caption = "count";
            this.mycount.FieldName = "mycount";
            this.mycount.Name = "mycount";
            this.mycount.OptionsColumn.AllowEdit = false;
            this.mycount.OptionsColumn.ReadOnly = true;
            this.mycount.Visible = true;
            this.mycount.VisibleIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "这是汇总后，将要上传的记录，确认无误后按下一步";
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(580, 423);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(75, 23);
            this.btnexit.TabIndex = 3;
            this.btnexit.Text = "退出";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnexport
            // 
            this.btnexport.Location = new System.Drawing.Point(384, 423);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(75, 23);
            this.btnexport.TabIndex = 4;
            this.btnexport.Text = "导出EXCEL";
            this.btnexport.UseVisualStyleBackColor = true;
            this.btnexport.Click += new System.EventHandler(this.button3_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(743, 454);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 23);
            this.progressBar.TabIndex = 6;
            // 
            // labprogress
            // 
            this.labprogress.AutoSize = true;
            this.labprogress.Location = new System.Drawing.Point(741, 428);
            this.labprogress.Name = "labprogress";
            this.labprogress.Size = new System.Drawing.Size(53, 12);
            this.labprogress.TabIndex = 7;
            this.labprogress.Text = "progress";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Goldenrod;
            this.label3.Location = new System.Drawing.Point(12, 480);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(761, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "如果发现下一步不能按，是因为2015年12月28为了在社保局不要误会如果计算时发现数据有异常仍然弹出此框，但是不让按“下一步”进行上传";
            // 
            // btncapture
            // 
            this.btncapture.Location = new System.Drawing.Point(286, 423);
            this.btncapture.Name = "btncapture";
            this.btncapture.Size = new System.Drawing.Size(75, 23);
            this.btncapture.TabIndex = 9;
            this.btncapture.Text = "截图";
            this.btncapture.UseVisualStyleBackColor = true;
            this.btncapture.Click += new System.EventHandler(this.btncapture_Click);
            // 
            // labwaring
            // 
            this.labwaring.AutoSize = true;
            this.labwaring.ForeColor = System.Drawing.Color.Red;
            this.labwaring.Location = new System.Drawing.Point(36, 428);
            this.labwaring.Name = "labwaring";
            this.labwaring.Size = new System.Drawing.Size(0, 12);
            this.labwaring.TabIndex = 10;
            // 
            // SummaryUploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 496);
            this.Controls.Add(this.labwaring);
            this.Controls.Add(this.btncapture);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labprogress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnexport);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridsummary);
            this.Controls.Add(this.btnext);
            this.Name = "SummaryUploadForm";
            this.Text = "上传上月进出库信息传送";
            this.Load += new System.EventHandler(this.SummaryUploadForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridsummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sumaryview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnext;
        private DevExpress.XtraGrid.GridControl gridsummary;
        private DevExpress.XtraGrid.Views.Grid.GridView sumaryview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnexport;
        private DevExpress.XtraGrid.Columns.GridColumn updno;
        private DevExpress.XtraGrid.Columns.GridColumn yybh;
        private DevExpress.XtraGrid.Columns.GridColumn ny;
        private DevExpress.XtraGrid.Columns.GridColumn prodno;
        private DevExpress.XtraGrid.Columns.GridColumn prodname;
        private DevExpress.XtraGrid.Columns.GridColumn prodname2;
        private DevExpress.XtraGrid.Columns.GridColumn depno;
        private DevExpress.XtraGrid.Columns.GridColumn prodadd;
        private DevExpress.XtraGrid.Columns.GridColumn supname;
        private DevExpress.XtraGrid.Columns.GridColumn jx;
        private DevExpress.XtraGrid.Columns.GridColumn prodsize;
        private DevExpress.XtraGrid.Columns.GridColumn depnum;
        private DevExpress.XtraGrid.Columns.GridColumn invnum;
        private DevExpress.XtraGrid.Columns.GridColumn lestnum;
        private DevExpress.XtraGrid.Columns.GridColumn je;
        private DevExpress.XtraGrid.Columns.GridColumn BZ1;
        private DevExpress.XtraGrid.Columns.GridColumn BZ2;
        private DevExpress.XtraGrid.Columns.GridColumn BZ3;
        private DevExpress.XtraGrid.Columns.GridColumn serialno;
        private DevExpress.XtraGrid.Columns.GridColumn depdate;
        private DevExpress.XtraGrid.Columns.GridColumn cliname;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labprogress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btncapture;
        private System.Windows.Forms.Label labwaring;
        private DevExpress.XtraGrid.Columns.GridColumn prodmade;
        private DevExpress.XtraGrid.Columns.GridColumn mycount;
    }
}