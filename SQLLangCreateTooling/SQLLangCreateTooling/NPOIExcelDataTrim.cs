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
    class NPOIExcelDataTrim
    {
        /// <summary>
        /// rawDataTableMaxRows需要用户手动数一数该最大列数是多少。
        /// </summary>
        private static int rawDataTableMaxRows = 0;


        public static void npoiTrimTypesAndMethods(string filePath, int fileTypes, int defaultTables)
        {
            if (fileTypes == 2003)
            {
                try
                {
                    FileStream fs = new FileStream(filePath, FileMode.Open);

                    HSSFWorkbook HBook = new HSSFWorkbook(fs);
                    ISheet isheet = HBook.GetSheetAt(FormMain.defaultTables);

                    #region //回传当前读取的Sheet表名！
                    FormMain.selectTableName = isheet.SheetName;
                    #endregion

                    npoiDataTrimMerge(isheet);

                    //释放过程中使用的资源！
                    HBook.Close();
                    fs.Close();
                    FormMain.isSqlLangCreatedSuccessful = true;
                }
                catch (Exception ex)
                {
                    FormMain.isSqlLangCreatedSuccessful = false;
                    MessageBox.Show("过程出现异常错误" + ex.ToString(), "重要提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (fileTypes == 2007)
            {
                try
                {
                    ExcelPackage excelPackage;

                    FileInfo newFile = new FileInfo(filePath);
                    excelPackage = new ExcelPackage(newFile);

                    ExcelWorkbook myWorkbook = excelPackage.Workbook;
                    ExcelWorksheet myWorksheet = myWorkbook.Worksheets[FormMain.defaultTables + 1];

                    #region //回传当前读取的Sheet表名！
                    FormMain.selectTableName = myWorksheet.Name;
                    #endregion

                    excelPackageDataTrimMerge(myWorksheet);

                    //貌似很有必要释放内存，不然没法连续执行，不关掉程序文档打不开。
                    excelPackage.Dispose();
                    FormMain.isSqlLangCreatedSuccessful = true;
                }
                catch (Exception ex)
                {
                    FormMain.isSqlLangCreatedSuccessful = false;
                    MessageBox.Show("过程出现异常错误" + ex.ToString(), "重要提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

        }


        public static void whichDataTrimStyle(string text)
        {
            if (text == "")
            {
                rawDataTableMaxRows = 0;
            }
            else
            {
                try
                {
                    System.Text.RegularExpressions.Regex rex =
                                new System.Text.RegularExpressions.Regex(@"\d{2}$|\d{1}$");

                    if (rex.IsMatch(text))
                    {
                        rawDataTableMaxRows = Convert.ToInt32(text);
                    }
                }
                catch
                {
                    //报错就报错吧，哥懒得理它。
                }
            }
        }


        /// <summary>
        /// ExcelPackage组件方法生成将多列集合成两列。
        /// </summary>
        /// <param name="myWorksheet">引用ExcelPackage组件的某张Sheet表的数据内容</param>
        /// <returns></returns>
        private static void excelPackageDataTrimMerge(ExcelWorksheet myWorksheet)
        {
            int hangY = 1, lieXX = 1;
            string eStrHang = "", eStrLie = "";

            try
            {
                FileStream aFile = new FileStream("excelPackage-dataTrimMerge.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(aFile);

                /*
                 * * line A likes; 小胖A   男  20岁    宅  木讷
                 * output likes: 
                 * 小胖A   男
                 * 小胖A   20岁
                 * 小胖A   宅
                 * 小胖A   木讷
                */
                eStrHang = myWorksheet.Cell(hangY, 1).Value;
                while (eStrHang != null && eStrHang != "")
                {
                    string outPrint = "";

                    while (lieXX <= rawDataTableMaxRows)
                    {
                        eStrLie = myWorksheet.Cell(hangY, lieXX).Value;
                        if (eStrLie != null && eStrLie != "")
                        {
                            outPrint += eStrHang + "\t" + eStrLie + "\n";   //每行写一次不算多！
                        }
                        lieXX++;
                    }

                    hangY++;
                    lieXX = 1;
                    eStrHang = myWorksheet.Cell(hangY, 1).Value;

                    // Write data to file.
                    sw.WriteLine(outPrint);
                    //清空缓冲区
                    sw.Flush();
                }

                //结束写入
                sw.Close();
                aFile.Close();
            }
            catch
            {
                throw new ApplicationException();
            }
        }


        /// <summary>
        /// NPOI组件方法生成将多列集合成两列。
        /// </summary>
        /// <param name="isheet">引用NPOI组件的某张Sheet表的数据内容</param>
        /// <returns></returns>
        private static void npoiDataTrimMerge(ISheet isheet)
        {
            int hangY = 0, lieXX = 1;
            string eStrHang = "", eStrLie = "";

            try
            {
                FileStream aFile = new FileStream("npoi-dataTrimMerge.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(aFile);

                /*
                 * * line A likes; 小胖B   男  20岁    宅  木讷
                 * output likes: 
                 * 小胖B   男
                 * 小胖B   20岁
                 * 小胖B   宅
                 * 小胖B   木讷
                */
                while (hangY <= isheet.LastRowNum)
                {
                    string outPrint = "";

                    eStrHang = isheet.GetRow(hangY).Cells[0].ToString();
                    while (lieXX < rawDataTableMaxRows)
                    {
                        eStrLie = isheet.GetRow(hangY).Cells[lieXX].ToString();
                        if (eStrLie != null && eStrLie != "")
                        {
                            outPrint += eStrHang + "\t" + eStrLie + "\n";   //每行写一次不算多！
                        }
                        lieXX++;
                    }

                    hangY++;
                    lieXX = 1;

                    // Write data to file.
                    sw.WriteLine(outPrint);
                    //清空缓冲区
                    sw.Flush();
                }

                //结束写入
                sw.Close();
                aFile.Close();
            }
            catch 
            {
                throw new ApplicationException();
            }
        }


        public static void npoiGroupMixedOneMethods(string filePath, int fileTypes, int defaultTables)
        {
            if (fileTypes == 2003)
            {
                try
                {
                    FileStream fs = new FileStream(filePath, FileMode.Open);

                    HSSFWorkbook HBook = new HSSFWorkbook(fs);
                    ISheet isheet = HBook.GetSheetAt(FormMain.defaultTables);

                    #region //回传当前读取的Sheet表名！
                    FormMain.selectTableName = isheet.SheetName;
                    #endregion

                    npoiDataGroupMixedOne(isheet);

                    //释放过程中使用的资源！
                    HBook.Close();
                    fs.Close();
                    FormMain.isSqlLangCreatedSuccessful = true;
                }
                catch (Exception ex)
                {
                    FormMain.isSqlLangCreatedSuccessful = false;
                    MessageBox.Show("过程出现异常错误" + ex.ToString(), "重要提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (fileTypes == 2007)
            {
                try
                {
                    ExcelPackage excelPackage;

                    FileInfo newFile = new FileInfo(filePath);
                    excelPackage = new ExcelPackage(newFile);

                    ExcelWorkbook myWorkbook = excelPackage.Workbook;
                    ExcelWorksheet myWorksheet = myWorkbook.Worksheets[FormMain.defaultTables + 1];

                    #region //回传当前读取的Sheet表名！
                    FormMain.selectTableName = myWorksheet.Name;
                    #endregion

                    excelPackageDataGroupMixedOne(myWorksheet);

                    //貌似很有必要释放内存，不然没法连续执行，不关掉程序文档打不开。
                    excelPackage.Dispose();
                    FormMain.isSqlLangCreatedSuccessful = true;
                }
                catch (Exception ex)
                {
                    FormMain.isSqlLangCreatedSuccessful = false;
                    MessageBox.Show("过程出现异常错误" + ex.ToString(), "重要提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

        }


        private static void excelPackageDataGroupMixedOne(ExcelWorksheet myWorksheet)
        {
            int hangY = 1;
            string eStrHang = "", eStrNext = "";

            try
            {
                FileStream aFile = new FileStream("excelPackage-dataGroupMixedOne.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(aFile);

                /*
                 * raw datas like: 
                 * 小胖B   男
                 * 小胖B   20岁
                 * 小胖B   宅
                 * 小胖B   木讷
                 * After mix like:
                 * 小胖B   男  20岁    宅  木讷
                */
                eStrNext = myWorksheet.Cell(hangY, 1).Value;

                while (eStrNext != null && eStrNext != "")
                {
                    string outPrint = "";

                    if (eStrNext == eStrHang)
                    {
                        outPrint += "\t" + myWorksheet.Cell(hangY, 2).Value;
                        hangY++;

                        // Write data to file.
                        sw.Write(outPrint);

                        if (myWorksheet.Cell(hangY, 1).Value != null)
                        {
                            eStrNext = myWorksheet.Cell(hangY, 1).Value;
                        }
                        else
                            break;
                    }
                    else
                    {
                        eStrHang = myWorksheet.Cell(hangY, 1).Value;
                        outPrint += "\t" + myWorksheet.Cell(hangY, 2).Value;
                        hangY++;

                        // Write data to file.
                        sw.Write("\n" + eStrHang + outPrint);

                        if (myWorksheet.Cell(hangY, 1).Value != null)
                        {
                            eStrNext = myWorksheet.Cell(hangY, 1).Value;
                        }
                        else
                            continue;
                    }

                    //清空缓冲区
                    sw.Flush();
                }

                //结束写入
                sw.Close();
                aFile.Close();
            }
            catch
            {
                throw new ApplicationException();
            }
        }


        private static void npoiDataGroupMixedOne(ISheet isheet)
        {
            int hangY = 0;
            string eStrHang = "", eStrNext = "";

            try
            {
                FileStream aFile = new FileStream("npoi-dataGroupMixedOne.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(aFile);

                /*
                 * raw datas like: 
                 * 小胖B   男
                 * 小胖B   20岁
                 * 小胖B   宅
                 * 小胖B   木讷
                 * After mix like:
                 * 小胖B   男  20岁    宅  木讷
                */
                eStrNext = isheet.GetRow(0).Cells[0].ToString();

                while (hangY <= isheet.LastRowNum)
                {
                    string outPrint = "";

                    if (eStrNext == eStrHang)
                    {
                        outPrint += "\t" + isheet.GetRow(hangY).Cells[1].ToString();
                        hangY++;

                        // Write data to file.
                        sw.Write(outPrint);

                        if (isheet.GetRow(hangY).Cells[0].ToString() != null)
                        {
                            eStrNext = isheet.GetRow(hangY).Cells[0].ToString();
                        }
                        else
                            continue;
                    }
                    else
                    {
                        eStrHang = isheet.GetRow(hangY).Cells[0].ToString();
                        outPrint += "\t" + isheet.GetRow(hangY).Cells[1].ToString();
                        hangY++;

                        // Write data to file.
                        sw.Write("\n" + eStrHang + outPrint);

                        if (hangY <= isheet.LastRowNum)
                        {
                            eStrNext = isheet.GetRow(hangY).Cells[0].ToString();
                        }
                        else
                            break;
                    }

                    //清空缓冲区
                    sw.Flush();
                }

                //结束写入
                sw.Close();
                aFile.Close();
            }
            catch
            {
                throw new ApplicationException();
            }
        }
    }
}
