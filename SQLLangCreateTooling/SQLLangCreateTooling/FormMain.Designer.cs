namespace SQLLangCreateTooling
{
    partial class FormMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCreate = new System.Windows.Forms.Button();
            this.groupBoxExcel = new System.Windows.Forms.GroupBox();
            this.radioButtonInsertPerLine = new System.Windows.Forms.RadioButton();
            this.textBoxUpdateOnly = new System.Windows.Forms.TextBox();
            this.label_Only = new System.Windows.Forms.Label();
            this.labelSheetName = new System.Windows.Forms.Label();
            this.radioButtonUpdateOnly = new System.Windows.Forms.RadioButton();
            this.textBoxTableNum = new System.Windows.Forms.NumericUpDown();
            this.labelTableNum = new System.Windows.Forms.Label();
            this.labelSqlType = new System.Windows.Forms.Label();
            this.radioButtonDelete = new System.Windows.Forms.RadioButton();
            this.radioButtonUpdate = new System.Windows.Forms.RadioButton();
            this.radioButtonInsert = new System.Windows.Forms.RadioButton();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.textBoxSelect = new System.Windows.Forms.TextBox();
            this.groupBoxTxt = new System.Windows.Forms.GroupBox();
            this.buttonGroupMixedOne = new System.Windows.Forms.Button();
            this.buttonDataTrim = new System.Windows.Forms.Button();
            this.linkLabelHelpInfo = new System.Windows.Forms.LinkLabel();
            this.numericUpDownGroupRules = new System.Windows.Forms.NumericUpDown();
            this.labelGroupRules = new System.Windows.Forms.Label();
            this.labelNewData = new System.Windows.Forms.Label();
            this.labelRawData = new System.Windows.Forms.Label();
            this.numericUpDownNewData = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRawData = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxExcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxTableNum)).BeginInit();
            this.groupBoxTxt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGroupRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRawData)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreate
            // 
            this.buttonCreate.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCreate.Location = new System.Drawing.Point(478, 134);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(80, 40);
            this.buttonCreate.TabIndex = 8;
            this.buttonCreate.Text = "生 成";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // groupBoxExcel
            // 
            this.groupBoxExcel.Controls.Add(this.radioButtonInsertPerLine);
            this.groupBoxExcel.Controls.Add(this.buttonCreate);
            this.groupBoxExcel.Controls.Add(this.textBoxUpdateOnly);
            this.groupBoxExcel.Controls.Add(this.label_Only);
            this.groupBoxExcel.Controls.Add(this.labelSheetName);
            this.groupBoxExcel.Controls.Add(this.radioButtonUpdateOnly);
            this.groupBoxExcel.Controls.Add(this.textBoxTableNum);
            this.groupBoxExcel.Controls.Add(this.labelTableNum);
            this.groupBoxExcel.Controls.Add(this.labelSqlType);
            this.groupBoxExcel.Controls.Add(this.radioButtonDelete);
            this.groupBoxExcel.Controls.Add(this.radioButtonUpdate);
            this.groupBoxExcel.Controls.Add(this.radioButtonInsert);
            this.groupBoxExcel.Controls.Add(this.labelVersion);
            this.groupBoxExcel.Controls.Add(this.labelInfo);
            this.groupBoxExcel.Controls.Add(this.textBoxSelect);
            this.groupBoxExcel.Location = new System.Drawing.Point(12, 12);
            this.groupBoxExcel.Name = "groupBoxExcel";
            this.groupBoxExcel.Size = new System.Drawing.Size(564, 180);
            this.groupBoxExcel.TabIndex = 0;
            this.groupBoxExcel.TabStop = false;
            this.groupBoxExcel.Text = "Excel表格处理";
            // 
            // radioButtonInsertPerLine
            // 
            this.radioButtonInsertPerLine.AutoSize = true;
            this.radioButtonInsertPerLine.Location = new System.Drawing.Point(339, 122);
            this.radioButtonInsertPerLine.Name = "radioButtonInsertPerLine";
            this.radioButtonInsertPerLine.Size = new System.Drawing.Size(89, 16);
            this.radioButtonInsertPerLine.TabIndex = 5;
            this.radioButtonInsertPerLine.TabStop = true;
            this.radioButtonInsertPerLine.Text = "Insert-Each";
            this.radioButtonInsertPerLine.UseVisualStyleBackColor = true;
            this.radioButtonInsertPerLine.CheckedChanged += new System.EventHandler(this.radioButtonInsertPerLine_CheckedChanged);
            // 
            // textBoxUpdateOnly
            // 
            this.textBoxUpdateOnly.ForeColor = System.Drawing.Color.DarkViolet;
            this.textBoxUpdateOnly.Location = new System.Drawing.Point(200, 151);
            this.textBoxUpdateOnly.MaxLength = 20;
            this.textBoxUpdateOnly.Name = "textBoxUpdateOnly";
            this.textBoxUpdateOnly.Size = new System.Drawing.Size(202, 21);
            this.textBoxUpdateOnly.TabIndex = 0;
            this.textBoxUpdateOnly.Text = "id";
            // 
            // label_Only
            // 
            this.label_Only.AutoSize = true;
            this.label_Only.ForeColor = System.Drawing.Color.DarkViolet;
            this.label_Only.Location = new System.Drawing.Point(117, 155);
            this.label_Only.Name = "label_Only";
            this.label_Only.Size = new System.Drawing.Size(77, 12);
            this.label_Only.TabIndex = 0;
            this.label_Only.Text = "表主键名称：";
            // 
            // labelSheetName
            // 
            this.labelSheetName.AutoSize = true;
            this.labelSheetName.ForeColor = System.Drawing.Color.Red;
            this.labelSheetName.Location = new System.Drawing.Point(208, 73);
            this.labelSheetName.Name = "labelSheetName";
            this.labelSheetName.Size = new System.Drawing.Size(95, 12);
            this.labelSheetName.TabIndex = 0;
            this.labelSheetName.Text = "“未选择Sheet”";
            // 
            // radioButtonUpdateOnly
            // 
            this.radioButtonUpdateOnly.AutoSize = true;
            this.radioButtonUpdateOnly.ForeColor = System.Drawing.Color.DarkViolet;
            this.radioButtonUpdateOnly.Location = new System.Drawing.Point(6, 153);
            this.radioButtonUpdateOnly.Name = "radioButtonUpdateOnly";
            this.radioButtonUpdateOnly.Size = new System.Drawing.Size(89, 16);
            this.radioButtonUpdateOnly.TabIndex = 6;
            this.radioButtonUpdateOnly.TabStop = true;
            this.radioButtonUpdateOnly.Text = "Update-Only";
            this.radioButtonUpdateOnly.UseVisualStyleBackColor = true;
            this.radioButtonUpdateOnly.CheckedChanged += new System.EventHandler(this.radioButtonUpdateOnly_CheckedChanged);
            // 
            // textBoxTableNum
            // 
            this.textBoxTableNum.Location = new System.Drawing.Point(164, 68);
            this.textBoxTableNum.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.textBoxTableNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.textBoxTableNum.Name = "textBoxTableNum";
            this.textBoxTableNum.Size = new System.Drawing.Size(38, 21);
            this.textBoxTableNum.TabIndex = 0;
            this.textBoxTableNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelTableNum
            // 
            this.labelTableNum.AutoSize = true;
            this.labelTableNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTableNum.ForeColor = System.Drawing.Color.Blue;
            this.labelTableNum.Location = new System.Drawing.Point(6, 69);
            this.labelTableNum.Name = "labelTableNum";
            this.labelTableNum.Size = new System.Drawing.Size(152, 16);
            this.labelTableNum.TabIndex = 0;
            this.labelTableNum.Text = "-请选择第1~9张表：";
            // 
            // labelSqlType
            // 
            this.labelSqlType.AutoSize = true;
            this.labelSqlType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSqlType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelSqlType.Location = new System.Drawing.Point(6, 107);
            this.labelSqlType.Name = "labelSqlType";
            this.labelSqlType.Size = new System.Drawing.Size(155, 12);
            this.labelSqlType.TabIndex = 0;
            this.labelSqlType.Text = "-请选择要生成的语句类型：";
            this.labelSqlType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // radioButtonDelete
            // 
            this.radioButtonDelete.AutoSize = true;
            this.radioButtonDelete.Location = new System.Drawing.Point(240, 122);
            this.radioButtonDelete.Name = "radioButtonDelete";
            this.radioButtonDelete.Size = new System.Drawing.Size(59, 16);
            this.radioButtonDelete.TabIndex = 4;
            this.radioButtonDelete.TabStop = true;
            this.radioButtonDelete.Text = "Delete";
            this.radioButtonDelete.UseVisualStyleBackColor = true;
            this.radioButtonDelete.CheckedChanged += new System.EventHandler(this.radioButtonDelete_CheckedChanged);
            // 
            // radioButtonUpdate
            // 
            this.radioButtonUpdate.AutoSize = true;
            this.radioButtonUpdate.Location = new System.Drawing.Point(141, 122);
            this.radioButtonUpdate.Name = "radioButtonUpdate";
            this.radioButtonUpdate.Size = new System.Drawing.Size(59, 16);
            this.radioButtonUpdate.TabIndex = 3;
            this.radioButtonUpdate.TabStop = true;
            this.radioButtonUpdate.Text = "Update";
            this.radioButtonUpdate.UseVisualStyleBackColor = true;
            this.radioButtonUpdate.CheckedChanged += new System.EventHandler(this.radioButtonUpdate_CheckedChanged);
            // 
            // radioButtonInsert
            // 
            this.radioButtonInsert.AutoSize = true;
            this.radioButtonInsert.Location = new System.Drawing.Point(6, 122);
            this.radioButtonInsert.Name = "radioButtonInsert";
            this.radioButtonInsert.Size = new System.Drawing.Size(95, 16);
            this.radioButtonInsert.TabIndex = 2;
            this.radioButtonInsert.TabStop = true;
            this.radioButtonInsert.Text = "Insert-Multi";
            this.radioButtonInsert.UseVisualStyleBackColor = true;
            this.radioButtonInsert.CheckedChanged += new System.EventHandler(this.radioButtonInsert_CheckedChanged);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelVersion.ForeColor = System.Drawing.Color.Red;
            this.labelVersion.Location = new System.Drawing.Point(252, 17);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(120, 16);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "“未选取文件”";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelInfo.ForeColor = System.Drawing.Color.Blue;
            this.labelInfo.Location = new System.Drawing.Point(6, 17);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(248, 16);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "-请选择您想要引用的EXCEL文件：";
            // 
            // textBoxSelect
            // 
            this.textBoxSelect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxSelect.Location = new System.Drawing.Point(3, 43);
            this.textBoxSelect.MaxLength = 255;
            this.textBoxSelect.Name = "textBoxSelect";
            this.textBoxSelect.Size = new System.Drawing.Size(555, 23);
            this.textBoxSelect.TabIndex = 1;
            this.textBoxSelect.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_TextChanged);
            // 
            // groupBoxTxt
            // 
            this.groupBoxTxt.Controls.Add(this.button1);
            this.groupBoxTxt.Controls.Add(this.buttonGroupMixedOne);
            this.groupBoxTxt.Controls.Add(this.buttonDataTrim);
            this.groupBoxTxt.Controls.Add(this.linkLabelHelpInfo);
            this.groupBoxTxt.Controls.Add(this.numericUpDownGroupRules);
            this.groupBoxTxt.Controls.Add(this.labelGroupRules);
            this.groupBoxTxt.Controls.Add(this.labelNewData);
            this.groupBoxTxt.Controls.Add(this.labelRawData);
            this.groupBoxTxt.Controls.Add(this.numericUpDownNewData);
            this.groupBoxTxt.Controls.Add(this.numericUpDownRawData);
            this.groupBoxTxt.Location = new System.Drawing.Point(12, 210);
            this.groupBoxTxt.Name = "groupBoxTxt";
            this.groupBoxTxt.Size = new System.Drawing.Size(564, 107);
            this.groupBoxTxt.TabIndex = 0;
            this.groupBoxTxt.TabStop = false;
            this.groupBoxTxt.Text = "excel数据二维化集中";
            // 
            // buttonGroupMixedOne
            // 
            this.buttonGroupMixedOne.Location = new System.Drawing.Point(9, 78);
            this.buttonGroupMixedOne.Name = "buttonGroupMixedOne";
            this.buttonGroupMixedOne.Size = new System.Drawing.Size(160, 23);
            this.buttonGroupMixedOne.TabIndex = 3;
            this.buttonGroupMixedOne.Text = "数据同类合并（反）";
            this.buttonGroupMixedOne.UseVisualStyleBackColor = true;
            this.buttonGroupMixedOne.Click += new System.EventHandler(this.buttonGroupMixedOne_Click);
            // 
            // buttonDataTrim
            // 
            this.buttonDataTrim.Location = new System.Drawing.Point(398, 78);
            this.buttonDataTrim.Name = "buttonDataTrim";
            this.buttonDataTrim.Size = new System.Drawing.Size(160, 23);
            this.buttonDataTrim.TabIndex = 2;
            this.buttonDataTrim.Text = "开始数据整理（正）";
            this.buttonDataTrim.UseVisualStyleBackColor = true;
            this.buttonDataTrim.Click += new System.EventHandler(this.buttonDataTrim_Click);
            // 
            // linkLabelHelpInfo
            // 
            this.linkLabelHelpInfo.AutoSize = true;
            this.linkLabelHelpInfo.Location = new System.Drawing.Point(385, 52);
            this.linkLabelHelpInfo.Name = "linkLabelHelpInfo";
            this.linkLabelHelpInfo.Size = new System.Drawing.Size(173, 12);
            this.linkLabelHelpInfo.TabIndex = 0;
            this.linkLabelHelpInfo.TabStop = true;
            this.linkLabelHelpInfo.Text = "请先选择文档并指定第几张表格";
            this.linkLabelHelpInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHelpInfo_LinkClicked);
            // 
            // numericUpDownGroupRules
            // 
            this.numericUpDownGroupRules.Location = new System.Drawing.Point(284, 50);
            this.numericUpDownGroupRules.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownGroupRules.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownGroupRules.Name = "numericUpDownGroupRules";
            this.numericUpDownGroupRules.ReadOnly = true;
            this.numericUpDownGroupRules.Size = new System.Drawing.Size(38, 21);
            this.numericUpDownGroupRules.TabIndex = 0;
            this.numericUpDownGroupRules.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelGroupRules
            // 
            this.labelGroupRules.AutoSize = true;
            this.labelGroupRules.Location = new System.Drawing.Point(9, 52);
            this.labelGroupRules.Name = "labelGroupRules";
            this.labelGroupRules.Size = new System.Drawing.Size(269, 12);
            this.labelGroupRules.TabIndex = 0;
            this.labelGroupRules.Text = "处理数据依据基准列（维持与原始数据列一致）：";
            // 
            // labelNewData
            // 
            this.labelNewData.AutoSize = true;
            this.labelNewData.Location = new System.Drawing.Point(295, 22);
            this.labelNewData.Name = "labelNewData";
            this.labelNewData.Size = new System.Drawing.Size(125, 12);
            this.labelNewData.TabIndex = 0;
            this.labelNewData.Text = "处理结束新数据列数：";
            // 
            // labelRawData
            // 
            this.labelRawData.AutoSize = true;
            this.labelRawData.Location = new System.Drawing.Point(9, 22);
            this.labelRawData.Name = "labelRawData";
            this.labelRawData.Size = new System.Drawing.Size(185, 12);
            this.labelRawData.TabIndex = 0;
            this.labelRawData.Text = "原始数据列数统计（限30以内）：";
            // 
            // numericUpDownNewData
            // 
            this.numericUpDownNewData.Location = new System.Drawing.Point(426, 20);
            this.numericUpDownNewData.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownNewData.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNewData.Name = "numericUpDownNewData";
            this.numericUpDownNewData.ReadOnly = true;
            this.numericUpDownNewData.Size = new System.Drawing.Size(38, 21);
            this.numericUpDownNewData.TabIndex = 0;
            this.numericUpDownNewData.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericUpDownRawData
            // 
            this.numericUpDownRawData.Location = new System.Drawing.Point(200, 20);
            this.numericUpDownRawData.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownRawData.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownRawData.Name = "numericUpDownRawData";
            this.numericUpDownRawData.Size = new System.Drawing.Size(38, 21);
            this.numericUpDownRawData.TabIndex = 0;
            this.numericUpDownRawData.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(175, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 328);
            this.Controls.Add(this.groupBoxTxt);
            this.Controls.Add(this.groupBoxExcel);
            this.Name = "FormMain";
            this.Text = "Excel表格自转SQL增删改语句工具";
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.showHelpForTools);
            this.groupBoxExcel.ResumeLayout(false);
            this.groupBoxExcel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxTableNum)).EndInit();
            this.groupBoxTxt.ResumeLayout(false);
            this.groupBoxTxt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGroupRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRawData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.GroupBox groupBoxExcel;
        private System.Windows.Forms.RadioButton radioButtonInsertPerLine;
        private System.Windows.Forms.TextBox textBoxUpdateOnly;
        private System.Windows.Forms.Label label_Only;
        private System.Windows.Forms.Label labelSheetName;
        private System.Windows.Forms.RadioButton radioButtonUpdateOnly;
        private System.Windows.Forms.NumericUpDown textBoxTableNum;
        private System.Windows.Forms.Label labelTableNum;
        private System.Windows.Forms.Label labelSqlType;
        private System.Windows.Forms.RadioButton radioButtonDelete;
        private System.Windows.Forms.RadioButton radioButtonUpdate;
        private System.Windows.Forms.RadioButton radioButtonInsert;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.TextBox textBoxSelect;
        private System.Windows.Forms.GroupBox groupBoxTxt;
        private System.Windows.Forms.NumericUpDown numericUpDownRawData;
        private System.Windows.Forms.NumericUpDown numericUpDownNewData;
        private System.Windows.Forms.Label labelRawData;
        private System.Windows.Forms.Label labelNewData;
        private System.Windows.Forms.Label labelGroupRules;
        private System.Windows.Forms.NumericUpDown numericUpDownGroupRules;
        private System.Windows.Forms.LinkLabel linkLabelHelpInfo;
        private System.Windows.Forms.Button buttonDataTrim;
        private System.Windows.Forms.Button buttonGroupMixedOne;
        private System.Windows.Forms.Button button1;
    }
}
