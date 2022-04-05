namespace sbsc
{
    partial class IconForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IconForm));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("个人结算", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("进出库信息", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("其它", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("退出", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("药店医保个账结算", 7);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("取消药店医保个账结算", 5);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("药店进出库信息传送", 0);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("药店进出库信息删除", 2);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("系统设置", 6);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("药店口令修改", 1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("退出", 3);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("日志", 8);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.listview = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "mainstatisct.jpg");
            this.imageList.Images.SetKeyName(1, "mainchangepass.jpeg");
            this.imageList.Images.SetKeyName(2, "maindelete.jpeg");
            this.imageList.Images.SetKeyName(3, "mainexit.jpg");
            this.imageList.Images.SetKeyName(4, "mainlog.jpg");
            this.imageList.Images.SetKeyName(5, "mainmoneyback.jpeg");
            this.imageList.Images.SetKeyName(6, "mainoption.png");
            this.imageList.Images.SetKeyName(7, "mainpaymoney.jpg");
            this.imageList.Images.SetKeyName(8, "mainregister.jpeg");
            // 
            // listview
            // 
            this.listview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listview.GridLines = true;
            listViewGroup1.Header = "个人结算";
            listViewGroup1.Name = "listindividual";
            listViewGroup2.Header = "进出库信息";
            listViewGroup2.Name = "listdepinv";
            listViewGroup3.Header = "其它";
            listViewGroup3.Name = "other";
            listViewGroup4.Header = "退出";
            listViewGroup4.Name = "exitgroup";
            this.listview.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
            listViewItem1.Group = listViewGroup1;
            listViewItem1.ToolTipText = "把社保刷卡信息发送到社保局服务器里";
            listViewItem2.Group = listViewGroup1;
            listViewItem2.ToolTipText = "将已经上传的刷卡信息删除";
            listViewItem3.Group = listViewGroup2;
            listViewItem3.ToolTipText = "把某个月份的进出库信息传到社保局服务器里";
            listViewItem4.Group = listViewGroup2;
            listViewItem4.ToolTipText = "把药店进出库信息删除";
            listViewItem5.Group = listViewGroup3;
            listViewItem5.ToolTipText = "设置上传资料中的某些信息";
            listViewItem6.Group = listViewGroup3;
            listViewItem6.ToolTipText = "修改药店登陆口令";
            listViewItem7.Group = listViewGroup4;
            listViewItem7.ToolTipText = "退出";
            listViewItem8.Group = listViewGroup3;
            listViewItem8.ToolTipText = "异常记录日志";
            this.listview.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8});
            this.listview.LargeImageList = this.imageList;
            this.listview.Location = new System.Drawing.Point(0, 0);
            this.listview.Name = "listview";
            this.listview.Size = new System.Drawing.Size(771, 469);
            this.listview.TabIndex = 7;
            this.listview.UseCompatibleStateImageBehavior = false;
            this.listview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listview_MouseDoubleClick);
            
            // 
            // IconForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 469);
            this.Controls.Add(this.listview);
            this.Name = "IconForm";
            this.Text = "菜单";
            this.Load += new System.EventHandler(this.IconForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ListView listview;
    }
}