namespace TimelineComposite
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTemplatePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTemplateBrowse = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTemplateRemove = new System.Windows.Forms.Button();
            this.btnTemplateAdd = new System.Windows.Forms.Button();
            this.lvTemplate = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnMultiLangRemove = new System.Windows.Forms.Button();
            this.btnMultiLangAdd = new System.Windows.Forms.Button();
            this.lvMultiLang = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiStartGenerate = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTemplatePath
            // 
            this.txtTemplatePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemplatePath.Location = new System.Drawing.Point(56, 6);
            this.txtTemplatePath.Name = "txtTemplatePath";
            this.txtTemplatePath.Size = new System.Drawing.Size(256, 23);
            this.txtTemplatePath.TabIndex = 0;
            this.txtTemplatePath.Validating += new System.ComponentModel.CancelEventHandler(this.PathValidating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "模版：";
            // 
            // btnTemplateBrowse
            // 
            this.btnTemplateBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTemplateBrowse.Location = new System.Drawing.Point(318, 6);
            this.btnTemplateBrowse.Name = "btnTemplateBrowse";
            this.btnTemplateBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnTemplateBrowse.TabIndex = 2;
            this.btnTemplateBrowse.TabStop = false;
            this.btnTemplateBrowse.Text = "浏览(&B)";
            this.btnTemplateBrowse.UseVisualStyleBackColor = true;
            this.btnTemplateBrowse.Click += new System.EventHandler(this.btnTemplateBrowse_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "文本文件|*.txt|SSA文件|*.ssa;*.ass|所有文件|*.*";
            this.openFileDialog.FilterIndex = 2;
            this.openFileDialog.ReadOnlyChecked = true;
            this.openFileDialog.ShowReadOnly = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(407, 351);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.txtTemplatePath);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnTemplateBrowse);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(399, 321);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "模版和添加的文本";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnTemplateRemove);
            this.groupBox1.Controls.Add(this.btnTemplateAdd);
            this.groupBox1.Controls.Add(this.lvTemplate);
            this.groupBox1.Location = new System.Drawing.Point(6, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 280);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加的文本";
            // 
            // btnTemplateRemove
            // 
            this.btnTemplateRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTemplateRemove.Location = new System.Drawing.Point(306, 251);
            this.btnTemplateRemove.Name = "btnTemplateRemove";
            this.btnTemplateRemove.Size = new System.Drawing.Size(75, 23);
            this.btnTemplateRemove.TabIndex = 2;
            this.btnTemplateRemove.Text = "移除(&R)";
            this.btnTemplateRemove.UseVisualStyleBackColor = true;
            // 
            // btnTemplateAdd
            // 
            this.btnTemplateAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTemplateAdd.Location = new System.Drawing.Point(225, 251);
            this.btnTemplateAdd.Name = "btnTemplateAdd";
            this.btnTemplateAdd.Size = new System.Drawing.Size(75, 23);
            this.btnTemplateAdd.TabIndex = 1;
            this.btnTemplateAdd.Text = "添加(&A)";
            this.btnTemplateAdd.UseVisualStyleBackColor = true;
            this.btnTemplateAdd.Click += new System.EventHandler(this.btnTemplateAdd_Click);
            // 
            // lvTemplate
            // 
            this.lvTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTemplate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvTemplate.FullRowSelect = true;
            this.lvTemplate.GridLines = true;
            this.lvTemplate.Location = new System.Drawing.Point(6, 22);
            this.lvTemplate.Name = "lvTemplate";
            this.lvTemplate.Size = new System.Drawing.Size(375, 223);
            this.lvTemplate.TabIndex = 0;
            this.lvTemplate.UseCompatibleStateImageBehavior = false;
            this.lvTemplate.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名称";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "文件位置";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 300;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnMultiLangRemove);
            this.tabPage2.Controls.Add(this.btnMultiLangAdd);
            this.tabPage2.Controls.Add(this.lvMultiLang);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(399, 321);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "多语言组合设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnMultiLangRemove
            // 
            this.btnMultiLangRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMultiLangRemove.Location = new System.Drawing.Point(318, 292);
            this.btnMultiLangRemove.Name = "btnMultiLangRemove";
            this.btnMultiLangRemove.Size = new System.Drawing.Size(75, 23);
            this.btnMultiLangRemove.TabIndex = 2;
            this.btnMultiLangRemove.Text = "移除(&R)";
            this.btnMultiLangRemove.UseVisualStyleBackColor = true;
            // 
            // btnMultiLangAdd
            // 
            this.btnMultiLangAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMultiLangAdd.Location = new System.Drawing.Point(237, 292);
            this.btnMultiLangAdd.Name = "btnMultiLangAdd";
            this.btnMultiLangAdd.Size = new System.Drawing.Size(75, 23);
            this.btnMultiLangAdd.TabIndex = 1;
            this.btnMultiLangAdd.Text = "添加(&A)";
            this.btnMultiLangAdd.UseVisualStyleBackColor = true;
            // 
            // lvMultiLang
            // 
            this.lvMultiLang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMultiLang.CheckBoxes = true;
            this.lvMultiLang.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvMultiLang.FullRowSelect = true;
            this.lvMultiLang.GridLines = true;
            this.lvMultiLang.Location = new System.Drawing.Point(6, 6);
            this.lvMultiLang.Name = "lvMultiLang";
            this.lvMultiLang.Size = new System.Drawing.Size(387, 280);
            this.lvMultiLang.TabIndex = 0;
            this.lvMultiLang.UseCompatibleStateImageBehavior = false;
            this.lvMultiLang.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            this.columnHeader4.Width = 25;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 30;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "语言顺序";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 120;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "保存位置";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 200;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtOutput);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(399, 321);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "输出";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(3, 3);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(393, 315);
            this.txtOutput.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStartGenerate});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(431, 25);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsmiStartGenerate
            // 
            this.tsmiStartGenerate.Name = "tsmiStartGenerate";
            this.tsmiStartGenerate.Size = new System.Drawing.Size(68, 21);
            this.tsmiStartGenerate.Text = "开始生成";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 390);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTemplatePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTemplateBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTemplateRemove;
        private System.Windows.Forms.Button btnTemplateAdd;
        private System.Windows.Forms.ListView lvTemplate;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnMultiLangRemove;
        private System.Windows.Forms.Button btnMultiLangAdd;
        private System.Windows.Forms.ListView lvMultiLang;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiStartGenerate;
    }
}

