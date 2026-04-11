using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace School_Mang.BL.SITE
{
    class SiteExcelUtlity
    {
        MSG msg = new MSG();
        Waiting waiting = new Waiting();

        public bool WriteLessonsDataToExcel(
                                    string worksheetName,
                                    string saveAsLocation,
                                    string RasdDataName,
                                    string staticExcelFile)
        {

            Application excel;
            Workbook excelworkBook;
            Worksheet excelSheet;

            waiting.Wait();
            try
            {
                // Start Excel and get Application object.
                excel = new Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Open(staticExcelFile);

                // Workk sheet
                excelSheet = (Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;

                // Protected Excel
                excelSheet.Protect("kps2023");

                //now save the workbook and exit Excel

                excelworkBook.SaveAs(saveAsLocation); ;
                excelworkBook.Close(true);
                excelSheet = null;
                excelworkBook = null;

                excel.DisplayAlerts = true;
                excel.Quit();
                excel = null;

                waiting.End_WAit();
                return true;
            }
            catch (Exception ex)
            {
                waiting.End_WAit();
                msg.ErrorMesg(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelworkBook = null;
                excel = null;

                waiting.End_WAit();
            }
        }

        public System.Data.DataTable ReadUsersDataFromExcel(string staticExcelFile)

        {
            System.Data.DataTable dt = new System.Data.DataTable();
            DataRow row;

            Application excel;
            Workbook excelworkBook;
            Worksheet excelSheet;

            // Start Excel and get Application object.
            excel = new Application();

            waiting.Wait();
            try
            {
                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Open(staticExcelFile);

                // Workk sheet
                excelSheet = (Worksheet)excelworkBook.Sheets[1];
                Range xlRange = excelSheet.UsedRange;
                int row_no = Convert.ToInt32(excelSheet.Cells[1, 11].Value2);
                string file_name = Convert.ToString(excelSheet.Cells[1, 13].Value2);
                if (file_name != "users")
                {
                    excelworkBook.Close(0);
                    excelSheet = null;
                    excelworkBook = null;

                    excel.DisplayAlerts = true;
                    excel.Quit();
                    excel = null;
                    msg.ErrorMesg("تأكد من الملف المراد رفعه ..!");
                    waiting.End_WAit();
                    return null;
                }

                if (row_no == 0)
                {
                    excelworkBook.Close(0);
                    excelSheet = null;
                    excelworkBook = null;

                    excel.DisplayAlerts = true;
                    excel.Quit();
                    excel = null;

                    waiting.End_WAit();
                    return null;
                }
                else
                {
                    int rowCount = row_no + 3;

                    //Set DataTable Name and Columns Name

                    dt.Columns.Add("username", typeof(string));
                    dt.Columns.Add("password", typeof(string));
                    dt.Columns.Add("firstName", typeof(string));
                    dt.Columns.Add("fullName", typeof(string));
                    dt.Columns.Add("roleId", typeof(int));
                    dt.Columns.Add("osraId", typeof(string));
                    dt.Columns.Add("note", typeof(string));
                   

                    // loop through each row and add values to our sheet
                    //Get Row Data of Excel

                    int rowCounter; //This variable is used for row index number

                    rowCounter = 4;

                    for (int i = 4; i <= rowCount; i++) //Loop for available row of excel data
                    {
                        row = dt.NewRow(); //assign new row to DataTable

                        row["username"] = xlRange.Cells[i, 3].Value2;
                        row["password"] = xlRange.Cells[i, 4].Value2;
                        row["firstName"] = xlRange.Cells[i, 1].Value2;
                        row["fullName"] = xlRange.Cells[i, 2].Value2;
                        row["roleId"] = Convert.ToInt32(xlRange.Cells[i, 6].Value2);
                        row["osraId"] = xlRange.Cells[i, 5].Value2;
                        row["note"] = xlRange.Cells[i, 7].Value2;
                        

                        rowCounter++;

                        dt.Rows.Add(row); //add row to DataTable
                    }
                }
                excelworkBook.Close(0);
                excelSheet = null;
                excelworkBook = null;

                excel.DisplayAlerts = true;
                excel.Quit();
                excel = null;

                waiting.End_WAit();
                return dt;
            }
            catch (Exception ex)
            {
                waiting.End_WAit();
                msg.ErrorMesg(ex.Message);
                msg.ErrorMesg("يرجي التحقق من البيانات");
                excel.DisplayAlerts = true;
                excelSheet = null;
                excelworkBook = null;
                excel.Quit();
                excel = null;
                return null;
            }
            finally
            {
                excelSheet = null;
                excelworkBook = null;
                excel = null;
                waiting.End_WAit();
            }
        }

        public System.Data.DataTable ReadStudentsDataFromExcel(string staticExcelFile)

        {
            System.Data.DataTable dt = new System.Data.DataTable();
            DataRow row;

            Application excel;
            Workbook excelworkBook;
            Worksheet excelSheet;

            // Start Excel and get Application object.
            excel = new Application();

            waiting.Wait();
            try
            {
                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Open(staticExcelFile);

                // Workk sheet
                excelSheet = (Worksheet)excelworkBook.Sheets[1];
                Range xlRange = excelSheet.UsedRange;
                int row_no = Convert.ToInt32(excelSheet.Cells[1, 11].Value2);
                string file_name = Convert.ToString(excelSheet.Cells[1, 13].Value2);
                if (file_name != "students")
                {
                    excelworkBook.Close(0);
                    excelSheet = null;
                    excelworkBook = null;

                    excel.DisplayAlerts = true;
                    excel.Quit();
                    excel = null;
                    msg.ErrorMesg("تأكد من الملف المراد رفعه ..!");
                    waiting.End_WAit();
                    return null;
                }

                if (row_no == 0)
                {
                    excelworkBook.Close(0);
                    excelSheet = null;
                    excelworkBook = null;

                    excel.DisplayAlerts = true;
                    excel.Quit();
                    excel = null;

                    waiting.End_WAit();
                    return null;
                }
                else
                {
                    int rowCount = row_no + 3;

                    //Set DataTable Name and Columns Name

                    dt.Columns.Add("Student_Id", typeof(int));
                    dt.Columns.Add("Class_Id", typeof(int));
                    dt.Columns.Add("Gender_Id", typeof(int));
                    dt.Columns.Add("Religion_Id", typeof(int));
                    dt.Columns.Add("Grade_Id", typeof(int));
                    dt.Columns.Add("std_code", typeof(string));
                    dt.Columns.Add("Osraa_Id", typeof(string));
                    dt.Columns.Add("std_name", typeof(string));
                    dt.Columns.Add("full_name", typeof(string));


                    // loop through each row and add values to our sheet
                    //Get Row Data of Excel

                    int rowCounter; //This variable is used for row index number

                    rowCounter = 4;

                    for (int i = 4; i <= rowCount; i++) //Loop for available row of excel data
                    {
                        row = dt.NewRow(); //assign new row to DataTable

                        row["Student_Id"] = Convert.ToInt32(xlRange.Cells[i, 1].Value2);
                        row["Class_Id"] = Convert.ToInt32(xlRange.Cells[i, 2].Value2);
                        row["Gender_Id"] = Convert.ToInt32(xlRange.Cells[i, 3].Value2);
                        row["Religion_Id"] = Convert.ToInt32(xlRange.Cells[i, 4].Value2);
                        row["Grade_Id"] = Convert.ToInt32(xlRange.Cells[i, 5].Value2);
                        row["std_code"] = xlRange.Cells[i, 6].Value2;
                        row["Osraa_Id"] = xlRange.Cells[i, 7].Value2;
                        row["std_name"] = xlRange.Cells[i, 8].Value2;
                        row["full_name"] = xlRange.Cells[i, 9].Value2;


                        rowCounter++;

                        dt.Rows.Add(row); //add row to DataTable
                    }
                }
                excelworkBook.Close(0);
                excelSheet = null;
                excelworkBook = null;

                excel.DisplayAlerts = true;
                excel.Quit();
                excel = null;

                waiting.End_WAit();
                return dt;
            }
            catch (Exception ex)
            {
                waiting.End_WAit();
                msg.ErrorMesg(ex.Message);
                msg.ErrorMesg("يرجي التحقق من البيانات");
                excel.DisplayAlerts = true;
                excelSheet = null;
                excelworkBook = null;
                excel.Quit();
                excel = null;
                return null;
            }
            finally
            {
                excelSheet = null;
                excelworkBook = null;
                excel = null;
                waiting.End_WAit();
            }
        }
        
    }
}
