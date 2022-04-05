namespace sbsc
{
    partial class IndividalChargeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndividalChargeForm));
            this.rbmenu = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnitemimport = new DevExpress.XtraBars.BarButtonItem();
            this.btnupload = new DevExpress.XtraBars.BarButtonItem();
            this.btnreset = new DevExpress.XtraBars.BarButtonItem();
            this.btnexit = new DevExpress.XtraBars.BarButtonItem();
            this.btncheckerror = new DevExpress.XtraBars.BarButtonItem();
            this.btncheckerr = new DevExpress.XtraBars.BarButtonItem();
            this.checkbox = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btncapturescreen = new DevExpress.XtraBars.BarButtonItem();
            this.captureitem = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.filldw1 = new DevExpress.XtraBars.BarButtonItem();
            this.filldw2 = new DevExpress.XtraBars.BarButtonItem();
            this.homepage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.pg = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbupload = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.resetpg = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.exitpg = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbcheckerror = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.checkboxgroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.capture = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.fill = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.dw_1 = new Sybase.DataWindow.DataWindowControl();
            this.gridwillcharge = new System.Windows.Forms.DataGridView();
            this.gp1 = new System.Windows.Forms.GroupBox();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.gb3 = new System.Windows.Forms.GroupBox();
            this.gridchargeamout = new System.Windows.Forms.DataGridView();
            this.gbaddtion = new System.Windows.Forms.GroupBox();
            this.dw_2 = new Sybase.DataWindow.DataWindowControl();
            this.gbsub = new System.Windows.Forms.GroupBox();
            this.griddetail = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rbmenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridwillcharge)).BeginInit();
            this.gp1.SuspendLayout();
            this.gb2.SuspendLayout();
            this.gb3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridchargeamout)).BeginInit();
            this.gbaddtion.SuspendLayout();
            this.gbsub.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.griddetail)).BeginInit();
            this.SuspendLayout();
            // 
            // rbmenu
            // 
            this.rbmenu.ExpandCollapseItem.Id = 0;
            this.rbmenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbmenu.ExpandCollapseItem,
            this.btnitemimport,
            this.btnupload,
            this.btnreset,
            this.btnexit,
            this.btncheckerror,
            this.btncheckerr,
            this.checkbox,
            this.btncapturescreen,
            this.captureitem,
            this.filldw1,
            this.filldw2});
            this.rbmenu.Location = new System.Drawing.Point(0, 0);
            this.rbmenu.MaxItemId = 17;
            this.rbmenu.Name = "rbmenu";
            this.rbmenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.homepage});
            this.rbmenu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1,
            this.repositoryItemPictureEdit2,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.rbmenu.Size = new System.Drawing.Size(1091, 145);
            // 
            // btnitemimport
            // 
            this.btnitemimport.Caption = "导入HIS数据";
            this.btnitemimport.Glyph = global::sbsc.Properties.Resources.filesdown;
            this.btnitemimport.Id = 1;
            this.btnitemimport.Name = "btnitemimport";
            this.btnitemimport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnitemimport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnupload
            // 
            this.btnupload.Caption = "数据提交";
            this.btnupload.Glyph = global::sbsc.Properties.Resources.filesupload;
            this.btnupload.Id = 3;
            this.btnupload.Name = "btnupload";
            this.btnupload.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnupload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnupload_ItemClick);
            // 
            // btnreset
            // 
            this.btnreset.Caption = "重填";
            this.btnreset.Glyph = global::sbsc.Properties.Resources.reset;
            this.btnreset.Id = 5;
            this.btnreset.Name = "btnreset";
            this.btnreset.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnreset.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnreset_ItemClick);
            // 
            // btnexit
            // 
            this.btnexit.Caption = "退出";
            this.btnexit.Glyph = global::sbsc.Properties.Resources.exit;
            this.btnexit.Id = 6;
            this.btnexit.Name = "btnexit";
            this.btnexit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnexit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnexit_ItemClick);
            // 
            // btncheckerror
            // 
            this.btncheckerror.Caption = "检查错误";
            this.btncheckerror.Glyph = global::sbsc.Properties.Resources.checkerror;
            this.btncheckerror.Id = 8;
            this.btncheckerror.Name = "btncheckerror";
            this.btncheckerror.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btncheckerr
            // 
            this.btncheckerr.Caption = "检查错误";
            this.btncheckerr.Id = 9;
            this.btncheckerr.LargeGlyph = global::sbsc.Properties.Resources.checkerror;
            this.btncheckerr.Name = "btncheckerr";
            this.btncheckerr.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick_2);
            // 
            // checkbox
            // 
            this.checkbox.Caption = "上传时备注为补上传";
            this.checkbox.Edit = this.repositoryItemCheckEdit1;
            this.checkbox.Id = 10;
            this.checkbox.Name = "checkbox";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // btncapturescreen
            // 
            this.btncapturescreen.Caption = "截图";
            this.btncapturescreen.Id = 12;
            this.btncapturescreen.LargeGlyph = global::sbsc.Properties.Resources.capture;
            this.btncapturescreen.Name = "btncapturescreen";
            this.btncapturescreen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btncapturescreen_ItemClick);
            // 
            // captureitem
            // 
            this.captureitem.Caption = "上传完截图";
            this.captureitem.Edit = this.repositoryItemCheckEdit2;
            this.captureitem.Id = 14;
            this.captureitem.Name = "captureitem";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // filldw1
            // 
            this.filldw1.Caption = "1";
            this.filldw1.Id = 15;
            this.filldw1.Name = "filldw1";
            this.filldw1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.filldw1_ItemClick);
            // 
            // filldw2
            // 
            this.filldw2.Caption = "2";
            this.filldw2.Id = 16;
            this.filldw2.Name = "filldw2";
            this.filldw2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.filldw2_ItemClick);
            // 
            // homepage
            // 
            this.homepage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.pg,
            this.rbupload,
            this.resetpg,
            this.exitpg,
            this.rbcheckerror,
            this.checkboxgroup,
            this.capture,
            this.fill});
            this.homepage.Name = "homepage";
            this.homepage.Text = "主页";
            // 
            // pg
            // 
            this.pg.ItemLinks.Add(this.btnitemimport);
            this.pg.Name = "pg";
            // 
            // rbupload
            // 
            this.rbupload.ItemLinks.Add(this.btnupload);
            this.rbupload.Name = "rbupload";
            // 
            // resetpg
            // 
            this.resetpg.ItemLinks.Add(this.btnreset);
            this.resetpg.Name = "resetpg";
            // 
            // exitpg
            // 
            this.exitpg.Glyph = global::sbsc.Properties.Resources.exit;
            this.exitpg.ItemLinks.Add(this.btnexit);
            this.exitpg.Name = "exitpg";
            // 
            // rbcheckerror
            // 
            this.rbcheckerror.ItemLinks.Add(this.btncheckerr);
            this.rbcheckerror.Name = "rbcheckerror";
            // 
            // checkboxgroup
            // 
            this.checkboxgroup.ItemLinks.Add(this.checkbox);
            this.checkboxgroup.ItemLinks.Add(this.captureitem);
            this.checkboxgroup.Name = "checkboxgroup";
            // 
            // capture
            // 
            this.capture.ItemLinks.Add(this.btncapturescreen);
            this.capture.Name = "capture";
            // 
            // fill
            // 
            this.fill.ItemLinks.Add(this.filldw1);
            this.fill.ItemLinks.Add(this.filldw2);
            this.fill.Name = "fill";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            // 
            // dw_1
            // 
            this.dw_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_1.DataWindowObject = "d_sb_inv_main_2";
            this.dw_1.Icon = ((System.Drawing.Icon)(resources.GetObject("dw_1.Icon")));
            this.dw_1.LibraryList = "dwtest.pbl";
            this.dw_1.Location = new System.Drawing.Point(6, 13);
            this.dw_1.Name = "dw_1";
            this.dw_1.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw_1.Size = new System.Drawing.Size(909, 102);
            this.dw_1.TabIndex = 1;
            this.dw_1.ItemChanged += new Sybase.DataWindow.ItemChangedEventHandler(this.dw_1_ItemChanged);
            this.dw_1.ItemError += new Sybase.DataWindow.ItemErrorEventHandler(this.dw_1_ItemError);
           
            // 
            // gridwillcharge
            // 
            this.gridwillcharge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridwillcharge.Location = new System.Drawing.Point(6, 13);
            this.gridwillcharge.Name = "gridwillcharge";
            this.gridwillcharge.RowTemplate.Height = 23;
            this.gridwillcharge.Size = new System.Drawing.Size(139, 278);
            this.gridwillcharge.TabIndex = 3;
            // 
            // gp1
            // 
            this.gp1.Controls.Add(this.gridwillcharge);
            this.gp1.Location = new System.Drawing.Point(12, 151);
            this.gp1.Name = "gp1";
            this.gp1.Size = new System.Drawing.Size(151, 297);
            this.gp1.TabIndex = 4;
            this.gp1.TabStop = false;
            this.gp1.Text = "等待收费";
            // 
            // gb2
            // 
            this.gb2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gb2.Controls.Add(this.dw_1);
            this.gb2.Location = new System.Drawing.Point(169, 151);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(921, 127);
            this.gb2.TabIndex = 5;
            this.gb2.TabStop = false;
            // 
            // gb3
            // 
            this.gb3.Controls.Add(this.gridchargeamout);
            this.gb3.Location = new System.Drawing.Point(12, 454);
            this.gb3.Name = "gb3";
            this.gb3.Size = new System.Drawing.Size(150, 255);
            this.gb3.TabIndex = 6;
            this.gb3.TabStop = false;
            this.gb3.Text = "费用分类";
            // 
            // gridchargeamout
            // 
            this.gridchargeamout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridchargeamout.Location = new System.Drawing.Point(6, 21);
            this.gridchargeamout.Name = "gridchargeamout";
            this.gridchargeamout.RowTemplate.Height = 23;
            this.gridchargeamout.Size = new System.Drawing.Size(138, 232);
            this.gridchargeamout.TabIndex = 0;
            // 
            // gbaddtion
            // 
            this.gbaddtion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbaddtion.Controls.Add(this.dw_2);
            this.gbaddtion.Location = new System.Drawing.Point(175, 510);
            this.gbaddtion.Name = "gbaddtion";
            this.gbaddtion.Size = new System.Drawing.Size(922, 199);
            this.gbaddtion.TabIndex = 7;
            this.gbaddtion.TabStop = false;
            this.gbaddtion.Text = "含处方药品的上传项目（请在下方输入输方信息，一个销售单只能对应一个处方信息）";
            // 
            // dw_2
            // 
            this.dw_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_2.DataWindowObject = "d_sb_inv_recipe";
            this.dw_2.Icon = ((System.Drawing.Icon)(resources.GetObject("dw_2.Icon")));
            this.dw_2.LibraryList = "dwtest.pbd";
            this.dw_2.Location = new System.Drawing.Point(7, 20);
            this.dw_2.Name = "dw_2";
            this.dw_2.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw_2.Size = new System.Drawing.Size(909, 169);
            this.dw_2.TabIndex = 2;
            this.dw_2.ItemError += new Sybase.DataWindow.ItemErrorEventHandler(this.dw_2_ItemError);
            // 
            // gbsub
            // 
            this.gbsub.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbsub.Controls.Add(this.griddetail);
            this.gbsub.Location = new System.Drawing.Point(175, 296);
            this.gbsub.Name = "gbsub";
            this.gbsub.Size = new System.Drawing.Size(915, 204);
            this.gbsub.TabIndex = 9;
            this.gbsub.TabStop = false;
            // 
            // griddetail
            // 
            this.griddetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.griddetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.griddetail.Location = new System.Drawing.Point(0, 13);
            this.griddetail.Name = "griddetail";
            this.griddetail.RowTemplate.Height = 23;
            this.griddetail.Size = new System.Drawing.Size(909, 185);
            this.griddetail.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(175, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(803, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "注意：社保局验收截图时请记得不但把上面的处方的3个备注截图，还要把下面的3个备注截图，还有销售明细中的3个备注 共9个备注的图要分别截下来";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(211, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(845, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "2019年8月根据社保局最新指引，修改了上传会以小票中的9位医保卡号为优先，身份证号为次，如果上传时提示身份证号或者医保卡号不对，请认真核对好小票";
            // 
            // IndividalChargeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 712);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbsub);
            this.Controls.Add(this.gbaddtion);
            this.Controls.Add(this.gb3);
            this.Controls.Add(this.gb2);
            this.Controls.Add(this.gp1);
            this.Controls.Add(this.rbmenu);
            this.Name = "IndividalChargeForm";
            this.Text = "划价收费";
            this.Load += new System.EventHandler(this.IndividalChargeForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IndividalChargeForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.rbmenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridwillcharge)).EndInit();
            this.gp1.ResumeLayout(false);
            this.gb2.ResumeLayout(false);
            this.gb3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridchargeamout)).EndInit();
            this.gbaddtion.ResumeLayout(false);
            this.gbsub.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.griddetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rbmenu;
        private DevExpress.XtraBars.Ribbon.RibbonPage homepage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pg;
        private DevExpress.XtraBars.BarButtonItem btnitemimport;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private Sybase.DataWindow.DataWindowControl dw_1;
        private System.Windows.Forms.DataGridView gridwillcharge;
        private System.Windows.Forms.GroupBox gp1;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.GroupBox gb3;
        private System.Windows.Forms.DataGridView gridchargeamout;
        private System.Windows.Forms.GroupBox gbaddtion;
        private System.Windows.Forms.GroupBox gbsub;
        private DevExpress.XtraBars.BarButtonItem btnupload;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbupload;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private DevExpress.XtraBars.BarButtonItem btnreset;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup resetpg;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup exitpg;
        private DevExpress.XtraBars.BarButtonItem btnexit;
        private System.Windows.Forms.DataGridView griddetail;
        private DevExpress.XtraBars.BarButtonItem btncheckerror;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbcheckerror;
        private DevExpress.XtraBars.BarButtonItem btncheckerr;
        private DevExpress.XtraBars.BarEditItem checkbox;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup checkboxgroup;
        private DevExpress.XtraBars.BarButtonItem btncapturescreen;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup capture;
        private DevExpress.XtraBars.BarEditItem captureitem;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private System.Windows.Forms.Label label1;
        private Sybase.DataWindow.DataWindowControl dw_2;
        private DevExpress.XtraBars.BarButtonItem filldw1;
        private DevExpress.XtraBars.BarButtonItem filldw2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup fill;
        private System.Windows.Forms.Label label2;

    }
}