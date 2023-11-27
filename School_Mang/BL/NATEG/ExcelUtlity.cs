using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace School_Mang.BL.NATEG
{
    class ExcelUtlity
    {
        MSG msg = new MSG();
        Waiting waiting = new Waiting();

        public bool WriteRasdDataToExcel(System.Data.DataTable dataTable,
                                          string worksheetName, 
                                          string saveAsLocation, 
                                          string RasdDataName,
                                          string staticExcelFile,
                                          short test_kind)
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
                
                excelSheet.Cells[2, 2] = RasdDataName;

                // loop through each row and add values to our sheet
                short rowcount = 4;
                short id = 0;
                short c_id = 0;
                short class_id = 0;
                short count_data = Convert.ToInt16(dataTable.Rows.Count);


                foreach (DataRow datarow in dataTable.Rows)
                {
                    // Reset Counter
                    if (class_id != Convert.ToInt16(datarow[2])) c_id = 0;
                    class_id = Convert.ToInt16(datarow[2]);

                    rowcount += 1;
                    id += 1;
                    c_id += 1;

                    // Add values
                    excelSheet.Cells[rowcount, 1] = id.ToString();
                    excelSheet.Cells[rowcount, 2] = c_id.ToString();
                    excelSheet.Cells[rowcount, 3] = datarow[1].ToString();
                    excelSheet.Cells[rowcount, 4] = datarow[0].ToString();
                    excelSheet.Cells[rowcount, 16] = test_kind.ToString();
                    excelSheet.Cells[rowcount, 17] = datarow[3].ToString();
                    excelSheet.Cells[rowcount, 19] = datarow[2].ToString();

                }

                // Delete Unused Rows
                Range range;
                range = excelSheet.Range[excelSheet.Cells[ count_data +5 , 1], excelSheet.Cells[152,19]];
                range.Delete();

                // Protected Excel
                excelSheet.Protect("kps2023");

                //now save the workbook and exit Excel

                excelworkBook.SaveAs(saveAsLocation); ;
                excelworkBook.Close(true); 
                
                excel.Quit();

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

        public System.Data.DataTable ReadRasdDataFromExcel(string staticExcelFile  )
                                      
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            DataRow row;

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
                excelSheet = (Worksheet)excelworkBook.Sheets[1];
                Range xlRange = excelSheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                rowCount = 25;
                int colCount = xlRange.Columns.Count;

                //Set DataTable Name and Columns Name

                dt.Columns.Add("student_Id", typeof(int));
                dt.Columns.Add("arabic_degre", typeof(int));
                dt.Columns.Add("dain_degre", typeof(int));
                dt.Columns.Add("math_degre", typeof(int));
                dt.Columns.Add("scince_degre", typeof(int));
                dt.Columns.Add("social_degre", typeof(int));
                dt.Columns.Add("english_degre", typeof(int));
                dt.Columns.Add("maharat_degre", typeof(int));
                dt.Columns.Add("tocnolegy_degre", typeof(int));
                dt.Columns.Add("badania_degre", typeof(int));
                dt.Columns.Add("general_degre", typeof(int));
                dt.Columns.Add("sort_code", typeof(int));
                dt.Columns.Add("test_kind_Id", typeof(int));
                dt.Columns.Add("grade_Id", typeof(int));
                dt.Columns.Add("french_degre", typeof(int));
                dt.Columns.Add("createdAt", typeof(DateTimeOffset));
                dt.Columns.Add("updatedAt", typeof(DateTimeOffset));

                // loop through each row and add values to our sheet
                //Get Row Data of Excel

                int rowCounter; //This variable is used for row index number

                rowCounter = 4;

                for (int i = 4; i <= rowCount; i++) //Loop for available row of excel data
                {
                    row = dt.NewRow(); //assign new row to DataTable
                    
                    row["student_Id"] = Convert.ToInt32(xlRange.Cells[i, 4].Value2);
                    row["arabic_degre"] = Convert.ToInt32(xlRange.Cells[i, 5].Value2);
                    row["dain_degre"] = Convert.ToInt32(xlRange.Cells[i, 6].Value2);
                    row["math_degre"] = Convert.ToInt32(xlRange.Cells[i, 7].Value2);
                    row["scince_degre"] = Convert.ToInt32(xlRange.Cells[i, 8].Value2);
                    row["social_degre"] = Convert.ToInt32(xlRange.Cells[i, 9].Value2);
                    row["english_degre"] = Convert.ToInt32(xlRange.Cells[i, 10].Value2);
                    row["maharat_degre"] = Convert.ToInt32(xlRange.Cells[i, 11].Value2);
                    row["tocnolegy_degre"] = Convert.ToInt32(xlRange.Cells[i, 12].Value2);
                    row["badania_degre"] = Convert.ToInt32(xlRange.Cells[i, 13].Value2);
                    row["general_degre"] = Convert.ToInt32(xlRange.Cells[i, 14].Value2);
                    row["sort_code"] = Convert.ToInt32(xlRange.Cells[i, 15].Value2);
                    row["test_kind_Id"] = Convert.ToInt32(xlRange.Cells[i, 16].Value2);
                    row["grade_Id"] = Convert.ToInt32(xlRange.Cells[i, 17].Value2);
                    row["french_degre"] = Convert.ToInt32(xlRange.Cells[i, 18].Value2);
                    row["createdAt"] = DateTimeOffset.Now;
                    row["updatedAt"] = DateTimeOffset.Now;
                    
                        rowCounter++;
                 
                   dt.Rows.Add(row); //add row to DataTable
                }
                    excelworkBook.Close(true);

                excel.Quit();
                excelSheet = null;
                excelworkBook = null;
                excel = null;

                waiting.End_WAit();
                return dt;
            }
            catch (Exception ex)
            {
                waiting.End_WAit();
                msg.ErrorMesg(ex.Message);
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
