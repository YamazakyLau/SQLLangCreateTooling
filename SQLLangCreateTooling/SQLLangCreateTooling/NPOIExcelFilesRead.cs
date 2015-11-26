using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HSSF.Extractor;
using NPOI.HPSF.Extractor;
using OfficeOpenXml;
using System.Windows.Forms;

namespace SQLLangCreateTooling
{
    #region    //推荐学习的注释
    /*
     * 
     * 本例中只是简单的读取Excel文件并获取字符串，推荐扩展学习NPOI：
     * http://www.dotblogs.com.tw/killysss/archive/2010/01/27/13344.aspx
     * http://tonyqus.sinaapp.com/
     * ExcelPackage扩展：
     * http://excelpackage.codeplex.com/releases/view/1456
     * http://excelpackage.codeplex.com/
     */
    #endregion

    class NPOIExcelFilesRead
    {
        #region    //测试读取Excel成功与否的方法代码
		/// <summary>
        /// 测试NPOI组件方法得到*.xls文件第一张‘Sheet’的内容；未被用到的方法。
        /// </summary>
        /// <param name="FileName">文件完整的路径名，如D:\\test.xls</param>
        /// <returns>返回FileName第一张‘Sheet’的内容</returns>
        public static string npoiExtractStringTesting(string FileName)
        {
            try
            {
                FileInfo files = new FileInfo(FileName);
                using (FileStream fs = files.Open(FileMode.Open))
                {
                    HSSFWorkbook HBook = new HSSFWorkbook(fs);
                    ExcelExtractor extractor = new ExcelExtractor(HBook);
                    return extractor.Text;
                }

            }
            catch
            { 
                return null; 
            }
        }

		/// <summary>
        /// 测试ExcelPackage组件方法得到*.xlsx文件‘Sheet1’表中的第二行二列单元格内容；未被用到的方法。
        /// </summary>
        /// <param name="FileName">文件完整的路径名,D:\\test.xls</param>
        /// <returns>返回FileName文件‘Sheet1’表中第二行二列单元格的内容</returns>
        public static string excelPackageExtractStringTesting(string FileName)
        { 
            try 
            {
                ExcelPackage excelPackage;
                string text = "";

                FileInfo template = new FileInfo(FileName);
                FileInfo newFile = new FileInfo(@"Test.xlsx");
                excelPackage = new ExcelPackage(newFile, template);

                ExcelWorkbook myWorkbook = excelPackage.Workbook;
                ExcelWorksheet myWorksheet = myWorkbook.Worksheets["Sheet1"];

                //excelPackage.Save();
                text = myWorksheet.Cell(2, 2).Value;

                return text;
                
            } 
            catch 
            { 
                //
                return null;
            }
        }
        #endregion  //测试代码End

		/// <summary>
        /// 依据参数，选择生成SQL语言的方法。
        /// </summary>
        /// <param name="filesPath">文件完整的路径名,如D:\\test.xls</param>
		/// <param name="filesTypes">文件类型，如*.xls将会引用NPOI组件</param>
		/// <param name="sqlLangTypes">SQL语言类别，如Insert、Update、Delete、Up-Only</param>
        /// <returns></returns>
        public static void npoiPrintSQLLangTypesAndMethods(string filesPath, int filesTypes, int sqlLangTypes)
        {
            if(filesTypes == 2003)
            {
                #region    //xls文件的处理
                try
                {
                    FileStream fs = new FileStream(filesPath, FileMode.Open);

                    HSSFWorkbook HBook = new HSSFWorkbook(fs);
                    ISheet isheet = HBook.GetSheetAt(FormMain.defaultTables);

                    #region //回传当前读取的Sheet表名！
                    FormMain.selectTableName = isheet.SheetName;
                    #endregion

                    switch (sqlLangTypes)
                    {
                        case 1:
                            npoiPrintSQLLangInsertMulti(isheet);
                            break;
                        case 2:
                            npoiPrintSQLLangDelete(isheet);
                            break;
                        case 3:
                            npoiPrintSQLLangUpdate(isheet);
                            break;
                        case 4:
                            npoiPrintSQLLangUpdateOnly(isheet);
                            break;
                        case 5:
                            npoiPrintSQLLangInsertEachLineASentence(isheet);
                            break;
                        default:
                            break;

                    }

                    //释放过程中使用的资源！
                    HBook.Close();
                    fs.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show("过程出现异常错误" + ex.ToString(), "重要提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                #endregion
            }
            else if (filesTypes == 2007)    //*.XLSX
            {
                try
                {
                    ExcelPackage excelPackage;

                    FileInfo newFile = new FileInfo(filesPath);
                    excelPackage = new ExcelPackage(newFile);

                    ExcelWorkbook myWorkbook = excelPackage.Workbook;
                    ExcelWorksheet myWorksheet = myWorkbook.Worksheets[FormMain.defaultTables + 1];

                    #region //回传当前读取的Sheet表名！
                    FormMain.selectTableName = myWorksheet.Name;
                    #endregion

                    switch (sqlLangTypes)
                    {
                        case 1:
                            excelPackagePrintSQLLangInsertMulti(myWorksheet);
                            break;
                        case 2:
                            excelPackagePrintSQLLangDelete(myWorksheet);
                            break;
                        case 3:
                            excelPackagePrintSQLLangUpdate(myWorksheet);
                            break;
                        case 4:
                            excelPackagePrintSQLLangUpdateOnly(myWorksheet);
                            break;
                        case 5:
                            excelPackagePrintSQLLangInsertEachLineASentence(myWorksheet);
                            break;
                        default:
                            break;

                    }

                    //貌似很有必要释放内存，不然没法连续执行，不关掉程序文档打不开。
                    excelPackage.Dispose();
                }
                catch (IOException ex)
                {
                    MessageBox.Show("过程出现异常错误" + ex.ToString(), "重要提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }


        #region    //excelPackage读取数据库的方法--start--
		/// <summary>
        /// ExcelPackage组件方法生成UpdateOnly语句。
        /// </summary>
        /// <param name="myWorksheet">引用ExcelPackage组件的某张Sheet表的数据内容</param>
        /// <returns></returns>
        private static void excelPackagePrintSQLLangUpdateOnly(ExcelWorksheet myWorksheet)
        {
            int hangY = 1, lieXX = 1;
            string eCellStr = "";
            string basicStr = "UPDATE ";

            eCellStr = myWorksheet.Cell(1, 1).Value;

            while (eCellStr != null && eCellStr != "")
            {
                lieXX++;
                eCellStr = myWorksheet.Cell(1, lieXX).Value;
            }

            eCellStr = myWorksheet.Cell(1, 1).Value;
            while (eCellStr != null && eCellStr != "")
            {
                hangY++;
                eCellStr = myWorksheet.Cell(hangY, 1).Value;
            }

            if (hangY < 3 || lieXX < 4)
            {
                MessageBox.Show("表格内容太少，无进行语句生成！确认返回并重新选择文件？", "提醒",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;     //如果行列太少，那么直接无视！
            }

            try
            {
                FileStream aFile = new FileStream("UpdateOnly.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(aFile);

                /*
                 * Excel File Likes：(Sheet Name = DataBase Table name = String "update_only")
                    tables_name	        name	age sex
                    video_category      张松溪	22	1
                    video_category      宋远桥	33	2
                    video_category      俞岱岩	44	1
                    video_category      张三丰	55	1
                    video_category      殷梨亭	66	2
                 * UPDATE `update_only`.`video_category` SET age='22',sex='1' WHERE 'id'=
                 *                                  (SELECT 'id' FROM `update_only`.`video_category` WHERE 'name'='张松溪');
                 * 减少部分语句，假设已经切换到当前数据库：
                 * UPDATE `video_category` SET age='22',sex='1' WHERE 'id'=
                 *                                  (SELECT 'id' FROM `video_category` WHERE 'name'='张松溪');
                */
                for (int i = 2; i < hangY; i++)
                {
                    string outPrint;
                    outPrint = basicStr + myWorksheet.Cell(i, 1).Value + " SET ";
                    for (int j = 3; j < lieXX; j++)
                    {
                        outPrint = outPrint + myWorksheet.Cell(1, j).Value + "=" + "'" + myWorksheet.Cell(i, j).Value + "'";
                        if (j != lieXX - 1)
                        {
                            outPrint = outPrint + ",";
                        }
                        else
                        {
                            outPrint = outPrint + " ";
                        }
                    }
                    //假设主键名称为'id'
                    outPrint = outPrint + "WHERE '" + FormMain.primaryKeyName +
                                    "'=" + "(SELECT '" + FormMain.primaryKeyName + "' FROM '" + myWorksheet.Cell(i, 1).Value + "' WHERE '"
                                    + myWorksheet.Cell(1, 2).Value + "'='" + myWorksheet.Cell(i, 2).Value + "');";

                    // Write data to file.
                    sw.WriteLine(outPrint);
                }

                //结束写入
                sw.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("过程出现异常错误" + ex.ToString(), "重要提示",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

		/// <summary>
        /// ExcelPackage组件方法生成Update语句。
        /// </summary>
        /// <param name="myWorksheet">引用ExcelPackage组件的某张Sheet表的数据内容</param>
        /// <returns></returns>
        private static void excelPackagePrintSQLLangUpdate(ExcelWorksheet myWorksheet)
        {
            int hangY = 1, lieXX = 1;
            string eCellStr = "";
            string basicStr = "UPDATE ";

            eCellStr = myWorksheet.Cell(1, 1).Value;

            while (eCellStr != null && eCellStr != "")
            {
                lieXX++;
                eCellStr = myWorksheet.Cell(1, lieXX).Value;
            }

            eCellStr = myWorksheet.Cell(1, 1).Value;
            while (eCellStr != null && eCellStr != "")
            {
                hangY++;
                eCellStr = myWorksheet.Cell(hangY, 1).Value;
            }

            if (hangY < 3 || lieXX < 4)
            {
                MessageBox.Show("表格内容太少，无进行语句生成！确认返回并重新选择文件？", "提醒",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;     //如果行列太少，那么直接无视！
            }

            try
            {
                FileStream aFile = new FileStream("Update.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(aFile);

                /*
                * UPDATE `kswiki2`.`wish` SET status='12',text='dsf' WHERE id='1';
                */
                for (int i = 2; i < hangY; i++)
                {
                    string outPrint;
                    outPrint = basicStr + myWorksheet.Cell(i, 1).Value + " SET ";
                    for (int j = 3; j < lieXX; j++)
                    {
                        outPrint = outPrint + myWorksheet.Cell(1, j).Value + "=" + "'" + myWorksheet.Cell(i, j).Value + "'";
                        if (j != lieXX - 1)
                        {
                            outPrint = outPrint + ",";
                        }
                        else
                        {
                            outPrint = outPrint + " ";
                        }
                    }
                    outPrint = outPrint + "WHERE " + myWorksheet.Cell(1, 2).Value + "=" + "'" + myWorksheet.Cell(i, 2).Value + "';";

                    // Write data to file.
                    sw.WriteLine(outPrint);
                }

                //结束写入
                sw.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("过程出现异常错误" + ex.ToString(), "重要提示",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

		/// <summary>
        /// ExcelPackage组件方法生成Delete语句。
        /// </summary>
        /// <param name="myWorksheet">引用ExcelPackage组件的某张Sheet表的数据内容</param>
        /// <returns></returns>
        private static void excelPackagePrintSQLLangDelete(ExcelWorksheet myWorksheet)
        {
            int hangY = 1, lieXX = 1;
            string eCellStr = "";
            string basicStr = "DELETE FROM ";

            eCellStr = myWorksheet.Cell(1, 1).Value;

            while (eCellStr != null && eCellStr != "")
            {
                lieXX++;
                eCellStr = myWorksheet.Cell(1, lieXX).Value;
            }

            eCellStr = myWorksheet.Cell(1, 1).Value;
            while (eCellStr != null && eCellStr != "")
            {
                hangY++;
                eCellStr = myWorksheet.Cell(hangY, 1).Value;
            }

            if (hangY < 3 || lieXX < 2)
            {
                MessageBox.Show("表格内容太少，无进行语句生成！确认返回并重新选择文件？", "提醒",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;     //如果行列太少，那么直接无视！
            }

            try
            {
                FileStream aFile = new FileStream("Delete.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(aFile);

                /*
                * delete from tableA where statusB='12'and textC='dsf';
                */
                for (int i = 2; i < hangY; i++)
                {
                    string outPrint;

                    if (lieXX == 2)
                    {
                        outPrint = basicStr + myWorksheet.Cell(i, 1).Value + " where "
                            + myWorksheet.Cell(1, 2).Value + "='" + myWorksheet.Cell(i, 2).Value + "';";
                    }
                    else//如果大于2，就用3列的，大于3列的表格也只考虑3列数据！
                    {
                        outPrint = basicStr + myWorksheet.Cell(i, 1).Value + " where "
                            + myWorksheet.Cell(1, 2).Value + "='" + myWorksheet.Cell(i, 2).Value
                            + "' AND " + myWorksheet.Cell(1, 3).Value + "='" + myWorksheet.Cell(i, 3).Value
                            + "';";
                    }

                    // Write data to file.
                    sw.WriteLine(outPrint);
                }

                //结束写入
                sw.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("过程出现异常错误" + ex.ToString(), "重要提示",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

		/// <summary>
        /// ExcelPackage组件方法生成Insert语句。
        /// </summary>
        /// <param name="myWorksheet">引用ExcelPackage组件的某张Sheet表的数据内容</param>
        /// <returns></returns>
        public static void excelPackagePrintSQLLangInsertMulti(ExcelWorksheet myWorksheet)
        {
            int hangY = 1, lieXX = 1;
            string eCellStr = "";
            string basicStr = "INSERT INTO ";

            eCellStr = myWorksheet.Cell(1, 1).Value;

            while (eCellStr != null && eCellStr != "")
            {
                lieXX++;
                eCellStr = myWorksheet.Cell(1, lieXX).Value;
            }

            eCellStr = myWorksheet.Cell(1, 1).Value;
            while (eCellStr != null && eCellStr != "")
            {
                hangY++;
                eCellStr = myWorksheet.Cell(hangY, 1).Value;
            }

            if (hangY < 3 || lieXX < 3)
            {
                MessageBox.Show("表格内容太少，无进行语句生成！确认返回并重新选择文件？", "提醒",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;     //如果行列太少，那么直接无视！
            }

            FileStream aFile = new FileStream("Insert.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(aFile);

            /*
             * INSERT INTO `kswiki2`.`wish` (id,user_id,title,text,created_at,votes_count) VALUES 
             *           ('526','17','我想','你好啊','2014-09-20 21:33:25','230'),
             *           ('527','18','不想','我好啊','2014-09-21 21:34:26','231');
            */

            for (int i = 1; i < hangY; i++)
            {
                string outPrint = "";

                if (i == 1)
                {
                    outPrint = basicStr + myWorksheet.Cell(2, 1).Value + " (";
                }
                else
                {
                    outPrint = outPrint + "(";
                }
                for (int j = 2; j < lieXX; j++)
                {
                    if (i == 1)
                    {
                        if (j != lieXX - 1)
                            outPrint = outPrint + myWorksheet.Cell(1, j).Value + ",";
                        else
                            outPrint = outPrint + myWorksheet.Cell(1, j).Value + ") VALUES ";
                    }
                    else
                    {
                        outPrint = outPrint + "'" + myWorksheet.Cell(i, j).Value + "'";
                        if (j != lieXX - 1)
                        {
                            outPrint = outPrint + ",";
                        }
                        else
                        {
                            if (i != hangY - 1)
                            {
                                outPrint = outPrint + "),";
                            }
                            else
                            {   //末行加分号，表示所有插入语句结束
                                outPrint = outPrint + ");";
                            }
                        }
                    }

                }

                // Write data to file.
                sw.WriteLine(outPrint);
            }

            //结束写入
            sw.Close();
        }


        private static void excelPackagePrintSQLLangInsertEachLineASentence(ExcelWorksheet myWorksheet)
        {
            int hangY = 0, lieXX = 0;
            string eCellStr = "", langTop = "";
            string basicStr = "INSERT INTO ";

            eCellStr = myWorksheet.Cell(1, 1).Value;

            while (eCellStr != null && eCellStr != "")
            {
                lieXX++;
                eCellStr = myWorksheet.Cell(1, lieXX).Value;
            }

            eCellStr = myWorksheet.Cell(1, 1).Value;
            while (eCellStr != null && eCellStr != "")
            {
                hangY++;
                eCellStr = myWorksheet.Cell(hangY, 1).Value;
            }

            if (hangY < 3 || lieXX < 3)
            {
                MessageBox.Show("表格内容太少，无进行语句生成！确认返回并重新选择文件？", "提醒",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;     //如果行列太少，那么直接无视！
            }

            FileStream aFile = new FileStream("Insert.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(aFile);

            /**
             * INSERT INTO `kswiki2`.`wish` (id,user_id,title,text,created_at,votes_count) VALUES 
                        ('526','17','我想','你好啊','2014-09-20 21:33:25','230');
             * INSERT INTO `kswiki2`.`wish` (id,user_id,title,text,created_at,votes_count) VALUES 
                        ('527','18','不想','我好啊','2014-09-21 21:34:26','231');
             * 同一个表中插入，每行只写一句话，并以分号结束，方便大量的数据多次、多进程处理。
            **/
            langTop = basicStr + myWorksheet.Cell(2, 1).Value + " (";

            for (int j = 2; j < lieXX; j++)
            {
                langTop += myWorksheet.Cell(1, j).Value;
                if (j != lieXX - 1)
                {
                    langTop = langTop + ",";
                }
            }
            //固定部分无须带入循环中生成
            langTop += ") VALUES (";   //langTop = INSERT INTO `kswiki2`.`wish` (id,user_id,title,text,created_at,votes_count) VALUES (

            for (int i = 2; i < hangY; i++)
            {
                string outPrint = "";

                for (int j = 2; j < lieXX; j++)
                {
                    outPrint += "'" + myWorksheet.Cell(i, j).Value + "'";

                    if (j != lieXX - 1)
                    {
                        outPrint = outPrint + ",";
                    }
                }
                //outPrint = '526','17','我想','你好啊','2014-09-20 21:33:25','230'
                outPrint = langTop + outPrint + ");";

                // Write data to file.
                sw.WriteLine(outPrint);
            }

            //结束写入
            sw.Close();
        }

        #endregion    //excelPackage读取数据库的方法结束--END--



        #region    //npoi读取数据库的方法--start--
		/// <summary>
        /// NPOI组件方法生成UpdateOnly语句。
        /// </summary>
        /// <param name="isheet">引用NPOI组件的某张Sheet表的数据内容</param>
        /// <returns></returns>
        private static void npoiPrintSQLLangUpdateOnly(ISheet isheet)
        {
            int hangY, lieXX;
            string basicStr = "UPDATE ";

            hangY = isheet.LastRowNum;//建议不要出现无效数据列，如有部分单元格空白！
            lieXX = isheet.GetRow(0).LastCellNum;

            if (hangY < 2 || lieXX < 3)
            {
                MessageBox.Show("表格内容太少，无进行语句生成！确认返回并重新选择文件？", "提醒",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;     //如果行列太少，那么直接无视！
            }

            try
            {
                FileStream aFile = new FileStream("UpdateOnly.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(aFile);

                /*
                 * Excel File Likes：(Sheet Name = DataBase Table name = String "update_only")
                    tables_name	        name	age sex
                    video_category      张松溪	22	1
                    video_category      宋远桥	33	2
                    video_category      俞岱岩	44	1
                    video_category      张三丰	55	1
                    video_category      殷梨亭	66	2
                 * UPDATE `update_only`.`video_category` SET age='22',sex='1' WHERE 'id'=
                 *                                  (SELECT 'id' FROM `update_only`.`video_category` WHERE 'name'='张松溪');
                 * 减少部分语句，假设已经切换到当前数据库：
                 * UPDATE `video_category` SET age='22',sex='1' WHERE 'id'=
                 *                                  (SELECT 'id' FROM `video_category` WHERE 'name'='张松溪');
                */
                for (int i = 1; i <= hangY; i++)
                {
                    string outPrint;
                    outPrint = basicStr + isheet.GetRow(i).Cells[0].ToString() + " SET ";
                    for (int j = 2; j < lieXX; j++)
                    {
                        outPrint = outPrint + isheet.GetRow(0).Cells[j].ToString() + "=" + "'" + isheet.GetRow(i).Cells[j].ToString() + "'";
                        if (j != lieXX - 1)
                        {
                            outPrint = outPrint + ",";
                        }
                        else
                        {
                            outPrint = outPrint + " ";
                        }
                    }
                    //假设主键名称为'id'
                    outPrint = outPrint + "WHERE '" + FormMain.primaryKeyName +
                                    "'=" + "(SELECT '" + FormMain.primaryKeyName + "' FROM '" + isheet.GetRow(i).Cells[0].ToString() + "' WHERE '"
                                    + isheet.GetRow(0).Cells[1].ToString() + "'='" + isheet.GetRow(i).Cells[1].ToString() + "');";

                    // Write data to file.
                    sw.WriteLine(outPrint);
                }

                //结束写入
                sw.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("过程出现异常错误" + ex.ToString(), "重要提示",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

		/// <summary>
        /// NPOI组件方法生成Update语句。
        /// </summary>
        /// <param name="isheet">引用NPOI组件的某张Sheet表的数据内容</param>
        /// <returns></returns>
        private static void npoiPrintSQLLangUpdate(ISheet isheet)
        {
            int hangY, lieXX;
            string basicStr = "UPDATE ";

            hangY = isheet.LastRowNum;//建议不要出现无效数据列，如有部分单元格空白！
            lieXX = isheet.GetRow(0).LastCellNum;

            if (hangY < 2 || lieXX < 3)
            {
                MessageBox.Show("表格内容太少，无进行语句生成！确认返回并重新选择文件？", "提醒",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;     //如果行列太少，那么直接无视！
            }

            try
            {
                FileStream aFile = new FileStream("Update.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(aFile);

                /*
                * UPDATE `kswiki2`.`wish` SET status='12',text='dsf' WHERE id='1';
                */
                for (int i = 1; i <= hangY; i++)
                {
                    string outPrint;
                    outPrint = basicStr + isheet.GetRow(i).Cells[0].ToString() + " SET ";
                    for (int j = 2; j < lieXX; j++)
                    {
                        outPrint = outPrint + isheet.GetRow(0).Cells[j].ToString() + "=" + "'" + isheet.GetRow(i).Cells[j].ToString() + "'";
                        if (j != lieXX - 1)
                        {
                            outPrint = outPrint + ",";
                        }
                        else
                        {
                            outPrint = outPrint + " ";
                        }
                    }
                    outPrint = outPrint + "WHERE " + isheet.GetRow(0).Cells[1].ToString() + "=" + "'" + isheet.GetRow(i).Cells[1].ToString() + "';";

                    // Write data to file.
                    sw.WriteLine(outPrint);
                }

                //结束写入
                sw.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("过程出现异常错误" + ex.ToString(), "重要提示",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

		/// <summary>
        /// NPOI组件方法生成Delete语句。
        /// </summary>
        /// <param name="isheet">引用NPOI组件的某张Sheet表的数据内容</param>
        /// <returns></returns>
        private static void npoiPrintSQLLangDelete(ISheet isheet)
        {
            int hangY, lieXX;
            string basicStr = "DELETE FROM ";

            hangY = isheet.LastRowNum;//建议不要出现无效数据列，如有部分单元格空白！
            lieXX = isheet.GetRow(0).LastCellNum;

            if (hangY < 2 || lieXX < 2)
            {
                MessageBox.Show("表格内容太少，无进行语句生成！确认返回并重新选择文件？", "提醒",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;     //如果行列太少，那么直接无视！
            }

            try
            {
                FileStream aFile = new FileStream("Delete.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(aFile);

                /*
                * delete from tableA where statusB='12'and textC='dsf';
                */
                for (int i = 1; i <= hangY; i++)
                {
                    string outPrint;

                    if (lieXX == 2)
                    {
                        outPrint = basicStr + isheet.GetRow(i).Cells[0].ToString() + " where "
                            + isheet.GetRow(0).Cells[1].ToString() + "='" + isheet.GetRow(i).Cells[1].ToString() + "';";
                    }
                    else//如果大于2，就用3列的，大于3列的表格也只考虑3列数据！
                    {
                        outPrint = basicStr + isheet.GetRow(i).Cells[0].ToString() + " where "
                            + isheet.GetRow(0).Cells[1].ToString() + "='" + isheet.GetRow(i).Cells[1].ToString()
                            + "' AND " + isheet.GetRow(0).Cells[2].ToString() + "='" + isheet.GetRow(i).Cells[2].ToString()
                            + "';";
                    }

                    // Write data to file.
                    sw.WriteLine(outPrint);
                }

                //结束写入
                sw.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("过程出现异常错误" + ex.ToString(), "重要提示",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

		/// <summary>
        /// NPOI组件方法生成Insert语句。
        /// </summary>
        /// <param name="isheet">引用NPOI组件的某张Sheet表的数据内容</param>
        /// <returns></returns>
        public static void npoiPrintSQLLangInsertMulti(ISheet isheet)
        {
            int hangY, lieXX;
            string basicStr = "INSERT INTO ";

            hangY = isheet.LastRowNum;//建议不要出现无效数据列，如有部分单元格空白！
            lieXX = isheet.GetRow(0).LastCellNum;

            if (hangY < 2 || lieXX < 2)
            {
                MessageBox.Show("表格内容太少，无进行语句生成！确认返回并重新选择文件？", "提醒",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;     //如果行列太少，那么直接无视！
            }

            FileStream aFile = new FileStream("Insert.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(aFile);

            /*
             * INSERT INTO `kswiki2`.`wish` (id,user_id,title,text,created_at,votes_count) VALUES 
             *           ('526','17','我想','你好啊','2014-09-20 21:33:25','230'),
             *           ('527','18','不想','我好啊','2014-09-21 21:34:26','231');
             *  能否减少计算次数？？？如果是理论上其它方法也采用这种代码样式才行。
            */

            for (int i = 0; i <= hangY; i++)
            {
                string outPrint = "";

                if (i == 0)
                {
                    outPrint = basicStr + isheet.GetRow(1).Cells[0].ToString() + " (";
                }
                else
                {
                    outPrint = outPrint + "(";
                }
                for (int j = 1; j < lieXX; j++)
                {
                    if (i == 0)
                    {
                        if (j != lieXX - 1)
                            outPrint = outPrint + isheet.GetRow(0).Cells[j].ToString() + ",";
                        else
                            outPrint = outPrint + isheet.GetRow(0).Cells[j].ToString() + ") VALUES ";
                    }
                    else 
                    {
                        outPrint = outPrint + "'" + isheet.GetRow(i).Cells[j].ToString() + "'";
                        if (j != lieXX - 1)
                        {
                            outPrint = outPrint + ",";
                        }
                        else
                        {
                            if (i != hangY)
                            {
                                outPrint = outPrint + "),";
                            }
                            else
                            {   //末行加分号，表示所有插入语句结束
                                outPrint = outPrint + ");";
                            }
                        }
                    }

                }

                // Write data to file.
                sw.WriteLine(outPrint);
            }

            //结束写入
            sw.Close();
        }


        private static void npoiPrintSQLLangInsertEachLineASentence(ISheet isheet)
        {
            int hangY, lieXX;
            string basicStr = "INSERT INTO ";
            string langTop = "";

            hangY = isheet.LastRowNum;//建议不要出现无效数据列，如有部分单元格空白！
            lieXX = isheet.GetRow(0).LastCellNum;

            if (hangY < 2 || lieXX < 2)
            {
                MessageBox.Show("表格内容太少，无进行语句生成！确认返回并重新选择文件？", "提醒",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;     //如果行列太少，那么直接无视！
            }

            FileStream aFile = new FileStream("Insert.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(aFile);

            /*
             * INSERT INTO `kswiki2`.`wish` (id,user_id,title,text,created_at,votes_count) VALUES 
                        ('526','17','我想','你好啊','2014-09-20 21:33:25','230');
             * INSERT INTO `kswiki2`.`wish` (id,user_id,title,text,created_at,votes_count) VALUES 
                        ('527','18','不想','我好啊','2014-09-21 21:34:26','231');
             * 同一个表中插入，每行只写一句话，并以分号结束，方便大量的数据多次、多进程处理。
            */
            langTop = basicStr + isheet.GetRow(1).Cells[0].ToString() + " (";

            for (int j = 1; j < lieXX; j++)
            {
                langTop += isheet.GetRow(0).Cells[j].ToString();
                if (j != lieXX - 1)
                {
                    langTop = langTop + ",";
                }
            }
            //固定部分无须带入循环中生成
            langTop += ") VALUES (";   //langTop = INSERT INTO `kswiki2`.`wish` (id,user_id,title,text,created_at,votes_count) VALUES (

            for (int i = 1; i <= hangY; i++)
            {
                string outPrint = "";

                for (int j = 1; j < lieXX; j++)
                {
                    outPrint += "'" + isheet.GetRow(i).Cells[j].ToString() + "'";
                    
                    if (j != lieXX - 1)
                    {
                        outPrint = outPrint + ",";
                    }
                }
                //outPrint = '526','17','我想','你好啊','2014-09-20 21:33:25','230'
                outPrint = langTop + outPrint + ");";

                // Write data to file.
                sw.WriteLine(outPrint);
            }

            //结束写入
            sw.Close();
        }

        #endregion    //npoi读取数据库的方法结束--END--


    }
}
