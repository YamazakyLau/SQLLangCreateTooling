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
            this.textBoxSelect = new System.Windows.Forms.TextBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.radioButtonInsert = new System.Windows.Forms.RadioButton();
            this.radioButtonUpdate = new System.Windows.Forms.RadioButton();
            this.radioButtonDelete = new System.Windows.Forms.RadioButton();
            this.labelSqlType = new System.Windows.Forms.Label();
            this.labelTableNum = new System.Windows.Forms.Label();
            this.textBoxTableNum = new System.Windows.Forms.NumericUpDown();
            this.radioButtonUpdateOnly = new System.Windows.Forms.RadioButton();
            this.labelSheetName = new System.Windows.Forms.Label();
            this.label_Only = new System.Windows.Forms.Label();
            this.textBoxUpdateOnly = new System.Windows.Forms.TextBox();
            this.radioButtonInsertPerLine = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxTableNum)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSelect
            // 
            this.textBoxSelect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxSelect.Location = new System.Drawing.Point(12, 37);
            this.textBoxSelect.MaxLength = 255;
            this.textBoxSelect.Name = "textBoxSelect";
            this.textBoxSelect.Size = new System.Drawing.Size(564, 23);
            this.textBoxSelect.TabIndex = 0;
            this.textBoxSelect.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_TextChanged);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelInfo.ForeColor = System.Drawing.Color.Blue;
            this.labelInfo.Location = new System.Drawing.Point(15, 11);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(240, 16);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "请选择您想要引用的EXCEL文件：";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelVersion.ForeColor = System.Drawing.Color.Red;
            this.labelVersion.Location = new System.Drawing.Point(261, 11);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(120, 16);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "“未选取文件”";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCreate.Location = new System.Drawing.Point(496, 120);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(80, 40);
            this.buttonCreate.TabIndex = 3;
            this.buttonCreate.Text = "生 成";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // radioButtonInsert
            // 
            this.radioButtonInsert.AutoSize = true;
            this.radioButtonInsert.Location = new System.Drawing.Point(12, 86);
            this.radioButtonInsert.Name = "radioButtonInsert";
            this.radioButtonInsert.Size = new System.Drawing.Size(95, 16);
            this.radioButtonInsert.TabIndex = 4;
            this.radioButtonInsert.TabStop = true;
            this.radioButtonInsert.Text = "Insert-Multi";
            this.radioButtonInsert.UseVisualStyleBackColor = true;
            this.radioButtonInsert.CheckedChanged += new System.EventHandler(this.radioButtonInsert_CheckedChanged);
            // 
            // radioButtonUpdate
            // 
            this.radioButtonUpdate.AutoSize = true;
            this.radioButtonUpdate.Location = new System.Drawing.Point(159, 86);
            this.radioButtonUpdate.Name = "radioButtonUpdate";
            this.radioButtonUpdate.Size = new System.Drawing.Size(59, 16);
            this.radioButtonUpdate.TabIndex = 5;
            this.radioButtonUpdate.TabStop = true;
            this.radioButtonUpdate.Text = "Update";
            this.radioButtonUpdate.UseVisualStyleBackColor = true;
            this.radioButtonUpdate.CheckedChanged += new System.EventHandler(this.radioButtonUpdate_CheckedChanged);
            // 
            // radioButtonDelete
            // 
            this.radioButtonDelete.AutoSize = true;
            this.radioButtonDelete.Location = new System.Drawing.Point(306, 86);
            this.radioButtonDelete.Name = "radioButtonDelete";
            this.radioButtonDelete.Size = new System.Drawing.Size(59, 16);
            this.radioButtonDelete.TabIndex = 6;
            this.radioButtonDelete.TabStop = true;
            this.radioButtonDelete.Text = "Delete";
            this.radioButtonDelete.UseVisualStyleBackColor = true;
            this.radioButtonDelete.CheckedChanged += new System.EventHandler(this.radioButtonDelete_CheckedChanged);
            // 
            // labelSqlType
            // 
            this.labelSqlType.AutoSize = true;
            this.labelSqlType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSqlType.ForeColor = System.Drawing.Color.Blue;
            this.labelSqlType.Location = new System.Drawing.Point(15, 63);
            this.labelSqlType.Name = "labelSqlType";
            this.labelSqlType.Size = new System.Drawing.Size(200, 16);
            this.labelSqlType.TabIndex = 7;
            this.labelSqlType.Text = "请选择要生成的语句类型：";
            this.labelSqlType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelTableNum
            // 
            this.labelTableNum.AutoSize = true;
            this.labelTableNum.Location = new System.Drawing.Point(16, 142);
            this.labelTableNum.Name = "labelTableNum";
            this.labelTableNum.Size = new System.Drawing.Size(59, 12);
            this.labelTableNum.TabIndex = 9;
            this.labelTableNum.Text = "第1~9张表";
            // 
            // textBoxTableNum
            // 
            this.textBoxTableNum.Location = new System.Drawing.Point(98, 140);
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
            this.textBoxTableNum.TabIndex = 10;
            this.textBoxTableNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // radioButtonUpdateOnly
            // 
            this.radioButtonUpdateOnly.AutoSize = true;
            this.radioButtonUpdateOnly.ForeColor = System.Drawing.Color.DarkViolet;
            this.radioButtonUpdateOnly.Location = new System.Drawing.Point(12, 112);
            this.radioButtonUpdateOnly.Name = "radioButtonUpdateOnly";
            this.radioButtonUpdateOnly.Size = new System.Drawing.Size(89, 16);
            this.radioButtonUpdateOnly.TabIndex = 11;
            this.radioButtonUpdateOnly.TabStop = true;
            this.radioButtonUpdateOnly.Text = "Update-Only";
            this.radioButtonUpdateOnly.UseVisualStyleBackColor = true;
            this.radioButtonUpdateOnly.CheckedChanged += new System.EventHandler(this.radioButtonUpdateOnly_CheckedChanged);
            // 
            // labelSheetName
            // 
            this.labelSheetName.AutoSize = true;
            this.labelSheetName.ForeColor = System.Drawing.Color.Red;
            this.labelSheetName.Location = new System.Drawing.Point(157, 142);
            this.labelSheetName.Name = "labelSheetName";
            this.labelSheetName.Size = new System.Drawing.Size(95, 12);
            this.labelSheetName.TabIndex = 12;
            this.labelSheetName.Text = "“未选择Sheet”";
            // 
            // label_Only
            // 
            this.label_Only.AutoSize = true;
            this.label_Only.ForeColor = System.Drawing.Color.DarkViolet;
            this.label_Only.Location = new System.Drawing.Point(129, 114);
            this.label_Only.Name = "label_Only";
            this.label_Only.Size = new System.Drawing.Size(77, 12);
            this.label_Only.TabIndex = 13;
            this.label_Only.Text = "表主键名称：";
            // 
            // textBoxUpdateOnly
            // 
            this.textBoxUpdateOnly.ForeColor = System.Drawing.Color.DarkViolet;
            this.textBoxUpdateOnly.Location = new System.Drawing.Point(212, 111);
            this.textBoxUpdateOnly.MaxLength = 20;
            this.textBoxUpdateOnly.Name = "textBoxUpdateOnly";
            this.textBoxUpdateOnly.Size = new System.Drawing.Size(202, 21);
            this.textBoxUpdateOnly.TabIndex = 14;
            this.textBoxUpdateOnly.Text = "id";
            // 
            // radioButtonInsertPerLine
            // 
            this.radioButtonInsertPerLine.AutoSize = true;
            this.radioButtonInsertPerLine.Location = new System.Drawing.Point(453, 86);
            this.radioButtonInsertPerLine.Name = "radioButtonInsertPerLine";
            this.radioButtonInsertPerLine.Size = new System.Drawing.Size(89, 16);
            this.radioButtonInsertPerLine.TabIndex = 15;
            this.radioButtonInsertPerLine.TabStop = true;
            this.radioButtonInsertPerLine.Text = "Insert-Each";
            this.radioButtonInsertPerLine.UseVisualStyleBackColor = true;
            this.radioButtonInsertPerLine.CheckedChanged += new System.EventHandler(this.radioButtonInsertPerLine_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 168);
            this.Controls.Add(this.radioButtonInsertPerLine);
            this.Controls.Add(this.textBoxUpdateOnly);
            this.Controls.Add(this.label_Only);
            this.Controls.Add(this.labelSheetName);
            this.Controls.Add(this.radioButtonUpdateOnly);
            this.Controls.Add(this.textBoxTableNum);
            this.Controls.Add(this.labelTableNum);
            this.Controls.Add(this.labelSqlType);
            this.Controls.Add(this.radioButtonDelete);
            this.Controls.Add(this.radioButtonUpdate);
            this.Controls.Add(this.radioButtonInsert);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.textBoxSelect);
            this.Name = "FormMain";
            this.Text = "Excel表格自转SQL增删改语句工具";
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.showHelpForTools);
            ((System.ComponentModel.ISupportInitialize)(this.textBoxTableNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSelect;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.RadioButton radioButtonInsert;
        private System.Windows.Forms.RadioButton radioButtonUpdate;
        private System.Windows.Forms.RadioButton radioButtonDelete;
        private System.Windows.Forms.Label labelSqlType;
        private System.Windows.Forms.Label labelTableNum;
        private System.Windows.Forms.NumericUpDown textBoxTableNum;
        private System.Windows.Forms.RadioButton radioButtonUpdateOnly;
        private System.Windows.Forms.Label labelSheetName;
        private System.Windows.Forms.Label label_Only;
        private System.Windows.Forms.TextBox textBoxUpdateOnly;
        private System.Windows.Forms.RadioButton radioButtonInsertPerLine;
    }
}

