namespace sbsc
{
    partial class RefundForm
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
            this.btnsearch = new System.Windows.Forms.Button();
            this.labidno = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.gridrecrods = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.myselect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.serialno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.list_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sbls = new DevExpress.XtraGrid.Columns.GridColumn();
            this.JKSCBZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.JKSCSZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.refund_bz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.refund_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.inv_mon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.inv_bywho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cli_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cli_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.posxp_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.posxp_jysj = new DevExpress.XtraGrid.Columns.GridColumn();
            this.recipe_bz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cfbh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cfkjjgmc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cfrq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cfzd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cfysxm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btncomfirm = new System.Windows.Forms.Button();
            this.exitbtn = new System.Windows.Forms.Button();
            this.gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridrecrods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.btnsearch);
            this.gb.Controls.Add(this.labidno);
            this.gb.Controls.Add(this.txtid);
            this.gb.Location = new System.Drawing.Point(23, 12);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(582, 65);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            this.gb.Text = "请输入诊号后按回车";
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(476, 24);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 23);
            this.btnsearch.TabIndex = 2;
            this.btnsearch.Text = "查询";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // labidno
            // 
            this.labidno.AutoSize = true;
            this.labidno.Location = new System.Drawing.Point(6, 27);
            this.labidno.Name = "labidno";
            this.labidno.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labidno.Size = new System.Drawing.Size(209, 12);
            this.labidno.TabIndex = 1;
            this.labidno.Text = "销售单号或身份证号或者9位医保卡号:";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(221, 24);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(234, 21);
            this.txtid.TabIndex = 0;
            // 
            // gridrecrods
            // 
            this.gridrecrods.Location = new System.Drawing.Point(12, 92);
            this.gridrecrods.MainView = this.gridView1;
            this.gridrecrods.Name = "gridrecrods";
            this.gridrecrods.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridrecrods.Size = new System.Drawing.Size(754, 318);
            this.gridrecrods.TabIndex = 1;
            this.gridrecrods.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.myselect,
            this.serialno,
            this.list_no,
            this.sbls,
            this.JKSCBZ,
            this.JKSCSZ,
            this.refund_bz,
            this.refund_date,
            this.inv_mon,
            this.inv_bywho,
            this.cli_no,
            this.cli_name,
            this.posxp_no,
            this.posxp_jysj,
            this.recipe_bz,
            this.cfbh,
            this.cfkjjgmc,
            this.cfrq,
            this.cfzd,
            this.cfysxm});
            this.gridView1.GridControl = this.gridrecrods;
            this.gridView1.Name = "gridView1";
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
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
            this.myselect.VisibleIndex = 0;
            this.myselect.Width = 50;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
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
            this.serialno.Visible = true;
            this.serialno.VisibleIndex = 1;
            this.serialno.Width = 50;
            // 
            // list_no
            // 
            this.list_no.AppearanceHeader.Options.UseTextOptions = true;
            this.list_no.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.list_no.Caption = "单号";
            this.list_no.FieldName = "list_no";
            this.list_no.MaxWidth = 200;
            this.list_no.MinWidth = 200;
            this.list_no.Name = "list_no";
            this.list_no.Visible = true;
            this.list_no.VisibleIndex = 2;
            this.list_no.Width = 200;
            // 
            // sbls
            // 
            this.sbls.AppearanceHeader.Options.UseTextOptions = true;
            this.sbls.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.sbls.Caption = "社保流水号";
            this.sbls.FieldName = "sbls";
            this.sbls.MaxWidth = 200;
            this.sbls.MinWidth = 200;
            this.sbls.Name = "sbls";
            this.sbls.Visible = true;
            this.sbls.VisibleIndex = 3;
            this.sbls.Width = 200;
            // 
            // JKSCBZ
            // 
            this.JKSCBZ.AppearanceHeader.Options.UseTextOptions = true;
            this.JKSCBZ.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.JKSCBZ.Caption = "是否已经上传";
            this.JKSCBZ.FieldName = "JKSCBZ";
            this.JKSCBZ.MaxWidth = 80;
            this.JKSCBZ.MinWidth = 80;
            this.JKSCBZ.Name = "JKSCBZ";
            this.JKSCBZ.Visible = true;
            this.JKSCBZ.VisibleIndex = 4;
            this.JKSCBZ.Width = 80;
            // 
            // JKSCSZ
            // 
            this.JKSCSZ.AppearanceHeader.Options.UseTextOptions = true;
            this.JKSCSZ.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.JKSCSZ.Caption = "上传时间";
            this.JKSCSZ.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.JKSCSZ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.JKSCSZ.FieldName = "JKSCSZ";
            this.JKSCSZ.MaxWidth = 150;
            this.JKSCSZ.MinWidth = 150;
            this.JKSCSZ.Name = "JKSCSZ";
            this.JKSCSZ.Visible = true;
            this.JKSCSZ.VisibleIndex = 5;
            this.JKSCSZ.Width = 150;
            // 
            // refund_bz
            // 
            this.refund_bz.AppearanceHeader.Options.UseTextOptions = true;
            this.refund_bz.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.refund_bz.Caption = "是否已经冲正";
            this.refund_bz.FieldName = "refund_bz";
            this.refund_bz.MaxWidth = 80;
            this.refund_bz.MinWidth = 80;
            this.refund_bz.Name = "refund_bz";
            this.refund_bz.Visible = true;
            this.refund_bz.VisibleIndex = 6;
            this.refund_bz.Width = 80;
            // 
            // refund_date
            // 
            this.refund_date.AppearanceHeader.Options.UseTextOptions = true;
            this.refund_date.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.refund_date.Caption = "冲正时间";
            this.refund_date.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.refund_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.refund_date.FieldName = "refund_date";
            this.refund_date.MaxWidth = 150;
            this.refund_date.MinWidth = 150;
            this.refund_date.Name = "refund_date";
            this.refund_date.Visible = true;
            this.refund_date.VisibleIndex = 7;
            this.refund_date.Width = 150;
            // 
            // inv_mon
            // 
            this.inv_mon.AppearanceHeader.Options.UseTextOptions = true;
            this.inv_mon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.inv_mon.Caption = "金额";
            this.inv_mon.FieldName = "inv_mon";
            this.inv_mon.MaxWidth = 100;
            this.inv_mon.MinWidth = 100;
            this.inv_mon.Name = "inv_mon";
            this.inv_mon.Visible = true;
            this.inv_mon.VisibleIndex = 8;
            this.inv_mon.Width = 100;
            // 
            // inv_bywho
            // 
            this.inv_bywho.AppearanceHeader.Options.UseTextOptions = true;
            this.inv_bywho.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.inv_bywho.Caption = "销售员";
            this.inv_bywho.FieldName = "inv_bywho";
            this.inv_bywho.MaxWidth = 50;
            this.inv_bywho.MinWidth = 50;
            this.inv_bywho.Name = "inv_bywho";
            this.inv_bywho.Visible = true;
            this.inv_bywho.VisibleIndex = 9;
            this.inv_bywho.Width = 50;
            // 
            // cli_no
            // 
            this.cli_no.AppearanceHeader.Options.UseTextOptions = true;
            this.cli_no.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cli_no.Caption = "客户编号";
            this.cli_no.FieldName = "cli_no";
            this.cli_no.MaxWidth = 100;
            this.cli_no.MinWidth = 100;
            this.cli_no.Name = "cli_no";
            this.cli_no.Visible = true;
            this.cli_no.VisibleIndex = 10;
            this.cli_no.Width = 100;
            // 
            // cli_name
            // 
            this.cli_name.AppearanceHeader.Options.UseTextOptions = true;
            this.cli_name.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cli_name.Caption = "客户名称";
            this.cli_name.FieldName = "cli_name";
            this.cli_name.MaxWidth = 150;
            this.cli_name.MinWidth = 150;
            this.cli_name.Name = "cli_name";
            this.cli_name.Visible = true;
            this.cli_name.VisibleIndex = 11;
            this.cli_name.Width = 150;
            // 
            // posxp_no
            // 
            this.posxp_no.AppearanceHeader.Options.UseTextOptions = true;
            this.posxp_no.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.posxp_no.Caption = "POS签购单交易参考号";
            this.posxp_no.FieldName = "posxp_no";
            this.posxp_no.MaxWidth = 200;
            this.posxp_no.MinWidth = 200;
            this.posxp_no.Name = "posxp_no";
            this.posxp_no.Visible = true;
            this.posxp_no.VisibleIndex = 12;
            this.posxp_no.Width = 200;
            // 
            // posxp_jysj
            // 
            this.posxp_jysj.AppearanceHeader.Options.UseTextOptions = true;
            this.posxp_jysj.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.posxp_jysj.Caption = "POS交易时间";
            this.posxp_jysj.FieldName = "posxp_jysj";
            this.posxp_jysj.MaxWidth = 150;
            this.posxp_jysj.MinWidth = 150;
            this.posxp_jysj.Name = "posxp_jysj";
            this.posxp_jysj.Visible = true;
            this.posxp_jysj.VisibleIndex = 13;
            this.posxp_jysj.Width = 150;
            // 
            // recipe_bz
            // 
            this.recipe_bz.AppearanceHeader.Options.UseTextOptions = true;
            this.recipe_bz.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.recipe_bz.Caption = "是否是处方";
            this.recipe_bz.FieldName = "recipe_bz";
            this.recipe_bz.MaxWidth = 80;
            this.recipe_bz.MinWidth = 80;
            this.recipe_bz.Name = "recipe_bz";
            this.recipe_bz.Visible = true;
            this.recipe_bz.VisibleIndex = 14;
            this.recipe_bz.Width = 80;
            // 
            // cfbh
            // 
            this.cfbh.AppearanceHeader.Options.UseTextOptions = true;
            this.cfbh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cfbh.Caption = "处方编号";
            this.cfbh.FieldName = "cfbh";
            this.cfbh.MaxWidth = 100;
            this.cfbh.MinWidth = 100;
            this.cfbh.Name = "cfbh";
            this.cfbh.Visible = true;
            this.cfbh.VisibleIndex = 15;
            this.cfbh.Width = 100;
            // 
            // cfkjjgmc
            // 
            this.cfkjjgmc.AppearanceHeader.Options.UseTextOptions = true;
            this.cfkjjgmc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cfkjjgmc.Caption = "处方开具定点医疗机构名称";
            this.cfkjjgmc.FieldName = "cfkjjgmc";
            this.cfkjjgmc.MaxWidth = 200;
            this.cfkjjgmc.MinWidth = 200;
            this.cfkjjgmc.Name = "cfkjjgmc";
            this.cfkjjgmc.Visible = true;
            this.cfkjjgmc.VisibleIndex = 16;
            this.cfkjjgmc.Width = 200;
            // 
            // cfrq
            // 
            this.cfrq.AppearanceHeader.Options.UseTextOptions = true;
            this.cfrq.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cfrq.Caption = "处方日期";
            this.cfrq.FieldName = "cfrq";
            this.cfrq.MaxWidth = 200;
            this.cfrq.MinWidth = 200;
            this.cfrq.Name = "cfrq";
            this.cfrq.Visible = true;
            this.cfrq.VisibleIndex = 17;
            this.cfrq.Width = 200;
            // 
            // cfzd
            // 
            this.cfzd.AppearanceHeader.Options.UseTextOptions = true;
            this.cfzd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cfzd.Caption = "处方诊断";
            this.cfzd.FieldName = "cfzd";
            this.cfzd.MaxWidth = 100;
            this.cfzd.MinWidth = 100;
            this.cfzd.Name = "cfzd";
            this.cfzd.Visible = true;
            this.cfzd.VisibleIndex = 18;
            this.cfzd.Width = 100;
            // 
            // cfysxm
            // 
            this.cfysxm.AppearanceHeader.Options.UseTextOptions = true;
            this.cfysxm.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cfysxm.Caption = "处方医生姓名";
            this.cfysxm.FieldName = "cfysxm";
            this.cfysxm.MaxWidth = 100;
            this.cfysxm.MinWidth = 100;
            this.cfysxm.Name = "cfysxm";
            this.cfysxm.Visible = true;
            this.cfysxm.VisibleIndex = 19;
            this.cfysxm.Width = 100;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 433);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(401, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "1、处理有日结的发票时将自动冲减日结的金额。2、非当事收费员无权退款";
            // 
            // btncomfirm
            // 
            this.btncomfirm.Location = new System.Drawing.Point(176, 457);
            this.btncomfirm.Name = "btncomfirm";
            this.btncomfirm.Size = new System.Drawing.Size(75, 23);
            this.btncomfirm.TabIndex = 3;
            this.btncomfirm.Text = "确认";
            this.btncomfirm.UseVisualStyleBackColor = true;
            this.btncomfirm.Click += new System.EventHandler(this.btncomfirm_Click);
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(301, 457);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(75, 23);
            this.exitbtn.TabIndex = 4;
            this.exitbtn.Text = "退出";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // RefundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 492);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.btncomfirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gridrecrods);
            this.Controls.Add(this.gb);
            this.Name = "RefundForm";
            this.Text = "取消药店医保个账结算";
            this.Load += new System.EventHandler(this.RefundForm_Load);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridrecrods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Label labidno;
        private System.Windows.Forms.TextBox txtid;
        private DevExpress.XtraGrid.GridControl gridrecrods;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btncomfirm;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button btnsearch;
        private DevExpress.XtraGrid.Columns.GridColumn serialno;
        private DevExpress.XtraGrid.Columns.GridColumn list_no;
        private DevExpress.XtraGrid.Columns.GridColumn cli_no;
        private DevExpress.XtraGrid.Columns.GridColumn cli_name;
        private DevExpress.XtraGrid.Columns.GridColumn inv_mon;
        private DevExpress.XtraGrid.Columns.GridColumn JKSCBZ;
        private DevExpress.XtraGrid.Columns.GridColumn refund_bz;
        private DevExpress.XtraGrid.Columns.GridColumn myselect;
        private DevExpress.XtraGrid.Columns.GridColumn inv_bywho;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn sbls;
        private DevExpress.XtraGrid.Columns.GridColumn JKSCSZ;
        private DevExpress.XtraGrid.Columns.GridColumn refund_date;
        private DevExpress.XtraGrid.Columns.GridColumn posxp_no;
        private DevExpress.XtraGrid.Columns.GridColumn posxp_jysj;
        private DevExpress.XtraGrid.Columns.GridColumn recipe_bz;
        private DevExpress.XtraGrid.Columns.GridColumn cfbh;
        private DevExpress.XtraGrid.Columns.GridColumn cfkjjgmc;
        private DevExpress.XtraGrid.Columns.GridColumn cfrq;
        private DevExpress.XtraGrid.Columns.GridColumn cfzd;
        private DevExpress.XtraGrid.Columns.GridColumn cfysxm;
    }
}