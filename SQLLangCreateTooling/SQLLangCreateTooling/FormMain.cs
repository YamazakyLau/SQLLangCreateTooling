using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;


namespace SQLLangCreateTooling
{
    public partial class FormMain : Form
    {
        private static int defaultSqlType = 1;//增删改 => 1234，默认是增。
        private static int thisYourFirstTap = 1;

        public static int defaultTables = 0;

        public static string selectTableName = "";
        public static string primaryKeyName = "";

        public FormMain()
        {
            InitializeComponent();
            this.radioButtonInsert.Checked = true;
            this.textBoxUpdateOnly.ReadOnly = true;
        }

        private void textBox_TextChanged(object sender, MouseEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); //new一个方法

            //"(*.et;*.xls;*.xlsx)|*.et;*.xls;*.xlsx|all|*.*"---------------如果要多种选择
            ofd.Filter = "(*.xls;*.xlsx)|*.xls;*.xlsx";//删选、设定文件显示类型
            ofd.ShowDialog(); //显示打开文件的窗口
            this.textBoxSelect.Text = ofd.FileName; //获得选择的文件路径

        #region //修改 labelVersion 的字串显示
		 
            int filesType = fileTypesOrExcelTypes(this.textBoxSelect.Text);
            if (filesType > 0)
            {
                if (filesType == 2003)
                    this.labelVersion.Text = "Excel-2003格式";
                else if (filesType == 2007)
                {
                    this.labelVersion.Text = "Excel-2007格式";
                }
                else
                    this.labelVersion.Text = "\"不可识别文件\"";
            }
            else
                this.labelVersion.Text = "\"未选取文件\"";
        #endregion
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            //whichTablesSelect();  //屏蔽的功能
            int fileTypes = fileTypesOrExcelTypes(this.textBoxSelect.Text);
            primaryKeyName = this.textBoxUpdateOnly.Text;

            if (fileTypes > 0)
            {
                NPOIExcelFilesRead.printSQLLangTypesAndMethods(this.textBoxSelect.Text, fileTypes, defaultSqlType);

                this.labelSheetName.Text = "表格名为：“" + selectTableName + "”";
            }
            else
            #region //调戏用户的提示框，前面两次会提醒用户需要引入文件，后续不再提醒
            {
                if (thisYourFirstTap == 1)
                {
                    MessageBox.Show("亲，您给哥选一个EXCEL文件再戳好不-,-!!!", "重要提醒",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    thisYourFirstTap += 1;
                }
                else if (thisYourFirstTap == 2)
                {
                    MessageBox.Show("亲，再戳不理你了，哼~~  -,-!!!", "重要警告",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    thisYourFirstTap += 1;
                }
            }
            #endregion //调戏动作结束
        }

        private int fileTypesOrExcelTypes(string str)
        {
            if (str != "")
            {
                FileInfo files = new FileInfo(str);

                if (files.Exists == true)
                {
                    //string matchExcel = ".xls$|.xlsx$";//正则表达式方法
                    if (str.EndsWith(".xls"))
                        return 2003;
                    else if (str.EndsWith(".xlsx"))
                        return 2007;
                    else
                        return 0;
                }
                else
                    return -1;
            }
            else
                return -1;
        }

        private void radioButtonInsert_CheckedChanged(object sender, EventArgs e)
        {
            defaultSqlType = 1;
            this.textBoxUpdateOnly.ReadOnly = true;
        }

        private void radioButtonUpdate_CheckedChanged(object sender, EventArgs e)
        {
            defaultSqlType = 3;
            this.textBoxUpdateOnly.ReadOnly = true;
        }

        private void radioButtonDelete_CheckedChanged(object sender, EventArgs e)
        {
            defaultSqlType = 2;
            this.textBoxUpdateOnly.ReadOnly = true;

        }

        private void radioButtonUpdateOnly_CheckedChanged(object sender, EventArgs e)
        {
            defaultSqlType = 4;
            this.textBoxUpdateOnly.ReadOnly = false;
        }

        #region //旧的代码，OleDbConnection方式，OLEDB方法打开Excel文档；已经弃用的代码。
        private void createLangByType(int num, DataSet getDataSet)
        {
            switch (defaultSqlType)
            {
                case 1:
                    CreateTextFromExcelNow.printSQLLangInsert(getDataSet);
                    break;
                case 2:
                    CreateTextFromExcelNow.printSQLLangDelete(getDataSet);
                    break;
                case 3:
                    CreateTextFromExcelNow.printSQLLangUpdate(getDataSet);
                    break;
                case 4:
                    CreateTextFromExcelNow.printSQLLangUpdateOnly(getDataSet);
                    break;
                default:
                    break;
            
            }
        }

        private void whichTablesSelect()
        {
            if (this.textBoxTableNum.Text == "")
            {
                defaultTables = 0;
            }
            else
            {
                try
                {
                    System.Text.RegularExpressions.Regex rex =
                                new System.Text.RegularExpressions.Regex(@"^\d{1}$");

                    if (rex.IsMatch(this.textBoxTableNum.Text))
                    {
                        defaultTables = Convert.ToInt32(this.textBoxTableNum.Text);
                        if (defaultTables > 0)
                        {
                            defaultTables = defaultTables - 1;//传统意义上认为最前面的为第一张表！
                        }
                    }
                }
                catch
                {
                    //报错就报错吧，哥懒得理它。
                }
            }
        }

        private void testToExcel(string filePath)
        {
            try
            {
                string strConn;
                if (filePath.EndsWith(".xls"))  //Excel格式为2003版本
                {
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath +
                        ";Extended Properties=\"Excel 8.0;HDR=NO;IMEX=1\""; //HDR=YES;那么第一行数据获取不到！
                }
                else if (filePath.EndsWith(".xlsx"))    //Excel格式为2007或以上版本
                {
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath +
                        ";Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1\"";
                }
                else
                {
                    return;// null;//如果走到这里干脆自杀掉 -,-!!!.反正不知道怎么处理.
                }

                OleDbConnection oleConn = new OleDbConnection(strConn);
                oleConn.Open();

                System.Data.DataTable schemaTable = oleConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "TABLE" });
                string tableName = schemaTable.Rows[1]["TABLE_NAME"].ToString().Trim();//这里表示第几张表格！

                String sql = "SELECT * FROM  [" + tableName + "]";//可以是更改Sheet名称，比如sheet2，等等 
                OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, oleConn);

                DataSet OleDsExcle = new DataSet();
                OleDaExcel.Fill(OleDsExcle, tableName);

                oleConn.Close();

                int hangY = OleDsExcle.Tables[1].Rows.Count;
                hangY = OleDsExcle.Tables[1].Rows.Count;
                hangY = OleDsExcle.Tables[2].Rows.Count;

                return;// OleDsExcle;
            }
            catch (Exception err)
            {
                MessageBox.Show("数据绑定Excel失败!失败原因：" + err.Message, "提示信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;// null;
            }
        }

        //如果连接字符串不对，有可能出现"Could not find installable ISAM ” Exception
        private string GetConnectionString(string fileName)
        {
            string connectString = "";
            //xls文件的连接字符串
            if (fileName.EndsWith(".xls"))  //Excel格式为2003版本
            {
                connectString =
                @" Provider=Microsoft.Jet.OLEDB.4.0;" +
                @" Data Source=" + fileName + ";" +
                @" Extended Properties=" + Convert.ToChar(34).ToString() +
                @" Excel 8.0;" + Convert.ToChar(34).ToString();
            }
            //xlsx，Excel 2007文件的连接字符串 
            else if (fileName.EndsWith(".xlsx"))    //Excel格式为2007或以上版本
            {
                connectString =
                    @" Provider=Microsoft.ACE.OLEDB.12.0;" +
                    @" Data Source=" + fileName + ";" +
                    @" Extended Properties=" + Convert.ToChar(34).ToString() +
                    @" Excel 12.0;" + Convert.ToChar(34).ToString();
            }
            /* 旧的写法可能有问题，见：
             * private void testToExcel(string filePath)
            */

            return connectString;
        }

        private DataSet created_SQL_Lang_FromExcelFile(string filePath)
        {
            /** 
             * filePath = "E:\\QQ_File\\康视马甲10.22.xls";
             * filePath = filePath.Replace("\\","\\\\");//这里原字串中已经有两道杠了 
             **/
            try
            {
                string strConn;
                string tableName;

                strConn = GetConnectionString(filePath);

                OleDbConnection oleConn = new OleDbConnection(strConn);
                oleConn.Open();//开启SQL服务还是报错.....

                System.Data.DataTable schemaTable = oleConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "TABLE" });
                try
                {
                    tableName = schemaTable.Rows[defaultTables]["TABLE_NAME"].ToString().Trim();

                    String sql = "SELECT * FROM  [" + tableName + "]";//可以是更改Sheet名称，比如sheet2，等等 
                    OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, oleConn);

                    DataSet OleDsExcle = new DataSet();
                    OleDaExcel.Fill(OleDsExcle, tableName);

                    createLangByType(defaultSqlType, OleDsExcle);

                    oleConn.Close();

                    //提醒用户已经生成数据完毕！
                    MessageBox.Show("文件已经生成或追加完毕，请注意查看！", "完成提示",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //return OleDsExcle;
                    return null;
                }
                catch
                {
                    int trueTables = defaultTables + 1;
                    MessageBox.Show("第" + trueTables + "张表不存在或无法读取！", "温馨提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
            }
            catch
            {
                MessageBox.Show("读取Excel数据失败!表格内容为空或无法识别。\n请确认数据有效性！", "温馨提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }
        #endregion //旧的代码结束

        private void showHelpForTools(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show("软件如有问题，请与我联系，https://github.com/YamazakyLau \n非诚勿扰！", "亲,哥终于找到你了！",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBoxTableNum_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;//阻止输入
            
            //例外情形，数字或删除键
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == (char)8))
            {
                e.Handled = false;
            }
        }


    }
}
