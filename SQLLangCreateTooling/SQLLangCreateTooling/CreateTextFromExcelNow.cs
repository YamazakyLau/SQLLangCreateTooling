using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace SQLLangCreateTooling
{
    /*
     * 新版本统一改成getDataSet.Tables[0]，因为该方法虽然引用了第N张表，但转成DataSet后只认为是第0张表！
     * getDataSet.Tables[tb]是错误的！
     */
    class CreateTextFromExcelNow
    {
        public static void printSQLLangInsert(DataSet getDataSet)
        {
            int hangY, lieXX;
            string basicStr = "INSERT INTO ";

            hangY = getDataSet.Tables[0].Rows.Count;//建议不要出现无效数据列，如有部分单元格空白！
            lieXX = getDataSet.Tables[0].Columns.Count;

            if (hangY < 2 || lieXX < 2)
            {
                MessageBox.Show("表格内容太少，无进行语句生成！确认返回并重新选择文件？", "提醒",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;     //如果行列太少，那么直接无视！
            }

            try
            {
                FileStream aFile = new FileStream("Insert.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(aFile);

                /*
                * INSERT INTO `kswiki2`.`wish` (id,user_id,title,text,created_at,votes_count) VALUES 
                *           ('526','17','我想','你好啊','2014-09-20 21:33:25','230'),
                *           ('527','18','不想','我好啊','2014-09-21 21:34:26','231');
                */

                for (int i = 0; i < hangY; i++)
                {
                    string outPrint = "";

                    if (i == 0)
                    {
                        outPrint = basicStr + getDataSet.Tables[0].Rows[1][0].ToString() + " (";
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
                                outPrint = outPrint + getDataSet.Tables[0].Rows[0][j].ToString() + ",";
                            else
                                outPrint = outPrint + getDataSet.Tables[0].Rows[0][j].ToString() + ") VALUES ";
                        }
                        else 
                        {
                            outPrint = outPrint + "'" + getDataSet.Tables[0].Rows[i][j].ToString() + "'";
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
            catch (IOException ex)
            {
                MessageBox.Show("过程出现异常错误" + ex.ToString(), "重要提示",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        
        public static void printSQLLangDelete(DataSet getDataSet) 
        {
            int hangY, lieXX;
            string basicStr = "DELETE FROM ";

            hangY = getDataSet.Tables[0].Rows.Count;//建议不要出现无效数据列，如有部分单元格空白！
            lieXX = getDataSet.Tables[0].Columns.Count;

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
                for (int i = 1; i < hangY; i++)
                {
                    string outPrint;

                    if (lieXX == 2)
                    {
                        outPrint = basicStr + getDataSet.Tables[0].Rows[i][0].ToString() + " where "
                            + getDataSet.Tables[0].Rows[0][1].ToString() + "='" + getDataSet.Tables[0].Rows[i][1].ToString() + "';";
                    }
                    else//如果大于2，就用3列的，大于3列的表格也只考虑3列数据！
                    {
                        outPrint = basicStr + getDataSet.Tables[0].Rows[i][0].ToString() + " where "
                            + getDataSet.Tables[0].Rows[0][1].ToString() + "='" + getDataSet.Tables[0].Rows[i][1].ToString()
                            + "' AND " + getDataSet.Tables[0].Rows[0][2].ToString() + "='" + getDataSet.Tables[0].Rows[i][2].ToString()
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


            /* *调试过程！
            String testStr = getDataSet.Tables[0].Rows[0][0].ToString();
            testStr = getDataSet.Tables[0].Rows[0][1].ToString();
            testStr = getDataSet.Tables[0].Rows[0][2].ToString();
        
            testStr = getDataSet.Tables[0].Rows[1][0].ToString();
            testStr = getDataSet.Tables[0].Rows[1][1].ToString();
            testStr = getDataSet.Tables[0].Rows[1][2].ToString();

            testStr = getDataSet.Tables[0].Rows[2][0].ToString();
            testStr = getDataSet.Tables[0].Rows[2][1].ToString();
            testStr = getDataSet.Tables[0].Rows[2][2].ToString();*/

        }
        
        public static void printSQLLangUpdateOnly(DataSet getDataSet)
        {
            int hangY, lieXX;
            string basicStr = "UPDATE ";

            hangY = getDataSet.Tables[0].Rows.Count;//建议不要出现无效数据列，如有部分单元格空白！
            lieXX = getDataSet.Tables[0].Columns.Count;

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
                for (int i = 1; i < hangY; i++)
                {
                    string outPrint;
                    outPrint = basicStr + getDataSet.Tables[0].Rows[i][0].ToString() + " SET ";
                    for(int j=2; j < lieXX; j++)
                    {
                        outPrint = outPrint + getDataSet.Tables[0].Rows[0][j].ToString() + "=" + "'" + getDataSet.Tables[0].Rows[i][j].ToString() + "'";
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
                    outPrint = outPrint + "WHERE " + getDataSet.Tables[0].Rows[0][1].ToString() + "=" + "'" + getDataSet.Tables[0].Rows[i][1].ToString() + "';";

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


        public static void printSQLLangUpdate(DataSet getDataSet)
        {
            int hangY, lieXX;
            string basicStr = "UPDATE ";

            hangY = getDataSet.Tables[0].Rows.Count;//建议不要出现无效数据列，如有部分单元格空白！
            lieXX = getDataSet.Tables[0].Columns.Count;

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
                for (int i = 1; i < hangY; i++)
                {
                    string outPrint;
                    outPrint = basicStr + getDataSet.Tables[0].Rows[i][0].ToString() + " SET ";
                    for (int j = 2; j < lieXX; j++)
                    {
                        outPrint = outPrint + getDataSet.Tables[0].Rows[0][j].ToString() + "=" + "'" + getDataSet.Tables[0].Rows[i][j].ToString() + "'";
                        if (j != lieXX - 1)
                        {
                            outPrint = outPrint + ",";
                        }
                        else
                        {
                            outPrint = outPrint + " ";
                        }
                    }
                    outPrint = outPrint + "WHERE " + getDataSet.Tables[0].Rows[0][1].ToString() + "=" + "'" + getDataSet.Tables[0].Rows[i][1].ToString() + "';";

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
    }
}
