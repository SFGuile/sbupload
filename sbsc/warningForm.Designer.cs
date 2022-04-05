namespace sbsc
{
    partial class warningForm
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
            this.datagrid = new System.Windows.Forms.DataGridView();
            this.labmessage = new System.Windows.Forms.Label();
            this.labexplain = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.lablistno = new System.Windows.Forms.Label();
            this.labaddition = new System.Windows.Forms.Label();
            this.btnexport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // datagrid
            // 
            this.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid.Location = new System.Drawing.Point(29, 26);
            this.datagrid.Name = "datagrid";
            this.datagrid.RowTemplate.Height = 23;
            this.datagrid.Size = new System.Drawing.Size(730, 315);
            this.datagrid.TabIndex = 0;
            // 
            // labmessage
            // 
            this.labmessage.AutoSize = true;
            this.labmessage.Location = new System.Drawing.Point(43, 344);
            this.labmessage.Name = "labmessage";
            this.labmessage.Size = new System.Drawing.Size(137, 12);
            this.labmessage.TabIndex = 1;
            this.labmessage.Text = "为什么会见到这个窗体？";
            // 
            // labexplain
            // 
            this.labexplain.AutoSize = true;
            this.labexplain.Location = new System.Drawing.Point(43, 362);
            this.labexplain.Name = "labexplain";
            this.labexplain.Size = new System.Drawing.Size(509, 12);
            this.labexplain.TabIndex = 2;
            this.labexplain.Text = "说明你的库存中可能含有不属于正常进仓的药品，一旦这些品种上传上去，可能社保部门能查到";
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(583, 357);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 3;
            this.btnclose.Text = "忽略并关闭";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // lablistno
            // 
            this.lablistno.AutoSize = true;
            this.lablistno.Location = new System.Drawing.Point(29, 8);
            this.lablistno.Name = "lablistno";
            this.lablistno.Size = new System.Drawing.Size(0, 12);
            this.lablistno.TabIndex = 4;
            // 
            // labaddition
            // 
            this.labaddition.AutoSize = true;
            this.labaddition.Location = new System.Drawing.Point(45, 378);
            this.labaddition.Name = "labaddition";
            this.labaddition.Size = new System.Drawing.Size(509, 12);
            this.labaddition.TabIndex = 5;
            this.labaddition.Text = "另外，我们会在系统内把这次日志记录下来，但这些信息不会上传给社保局，但会作为一种参考";
            // 
            // btnexport
            // 
            this.btnexport.Location = new System.Drawing.Point(674, 357);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(75, 23);
            this.btnexport.TabIndex = 6;
            this.btnexport.Text = "导出excel";
            this.btnexport.UseVisualStyleBackColor = true;
            this.btnexport.Click += new System.EventHandler(this.btnexport_Click);
            // 
            // warningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 394);
            this.Controls.Add(this.btnexport);
            this.Controls.Add(this.labaddition);
            this.Controls.Add(this.lablistno);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.labexplain);
            this.Controls.Add(this.labmessage);
            this.Controls.Add(this.datagrid);
            this.Name = "warningForm";
            this.Text = "警告";
            this.Load += new System.EventHandler(this.warningForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagrid;
        private System.Windows.Forms.Label labmessage;
        private System.Windows.Forms.Label labexplain;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Label lablistno;
        private System.Windows.Forms.Label labaddition;
        private System.Windows.Forms.Button btnexport;
    }
}