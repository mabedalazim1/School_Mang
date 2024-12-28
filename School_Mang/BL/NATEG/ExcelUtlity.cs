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
                range = excelSheet.Range[excelSheet.Cells[count_data + 5, 1], excelSheet.Cells[152, 19]];
                range.Delete(XlDeleteShiftDirection.xlShiftUp);

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

        public bool WriteAmalDataToExcel(System.Data.DataTable dataTable,
                                         string worksheetName,
                                         string saveAsLocation,
                                         string RasdDataName,
                                         string staticExcelFile,
                                         string test_kind,
                                         string grade_data,
                                         string year_data,
                                         string term_kind,
                                         short grade,
                                         byte term_id,
                                         byte prim = 0)
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

                // Add File Information
                excelSheet.Cells[1, 30] = test_kind;
                excelSheet.Cells[2, 30] = term_kind;
                excelSheet.Cells[3, 30] = grade_data;
                excelSheet.Cells[4, 30] = year_data;
                excelSheet.Cells[5, 30] = 1;
                excelSheet.Cells[6, 30] = grade;
                excelSheet.Cells[7, 30] = term_id;

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
                  
                    switch (prim)
                    {
                        case 0:
                            excelSheet.Cells[rowcount, 17] = datarow[2].ToString();
                            break;

                        case 1:
                            excelSheet.Cells[rowcount, 13] = datarow[2].ToString();
                            break;

                        case 2:
                            excelSheet.Cells[rowcount, 11] = datarow[2].ToString();
                            break;
                        case 3:
                            excelSheet.Cells[rowcount, 13] = datarow[2].ToString();
                            break;
                    }
                    
                }

                // Delete Unused Rows
                Range range;
                range = excelSheet.Range[excelSheet.Cells[count_data + 5, 1], excelSheet.Cells[152, 19]];
                range.Delete(XlDeleteShiftDirection.xlShiftUp);

                // Protected Excel
                excelSheet.Protect("kps2023");

                //now save the workbook and exit Excel

                excelworkBook.SaveAs(saveAsLocation);
                excel.DisplayAlerts = true;
                excelworkBook.Close(true);
                excelSheet = null;
                excelworkBook = null;

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


        public bool WriteTestDataToExcel(System.Data.DataTable dataTable,
                                       string worksheetName,
                                       string saveAsLocation,
                                       string RasdDataName,
                                       string staticExcelFile,
                                       string test_kind,
                                       string grade_data,
                                       string year_data,
                                       string term_kind,
                                       short grade,
                                       byte term_id)
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

                // Add File Information
                excelSheet.Cells[1, 30] = test_kind;
                excelSheet.Cells[2, 30] = term_kind;
                excelSheet.Cells[3, 30] = grade_data;
                excelSheet.Cells[4, 30] = year_data;
                excelSheet.Cells[5, 30] = 2;
                excelSheet.Cells[6, 30] = grade;
                excelSheet.Cells[7, 30] = term_id;
                // loop through each row and add values to our sheet
                short rowcount = 4;
                
                short count_data = Convert.ToInt16(dataTable.Rows.Count);

                foreach (DataRow datarow in dataTable.Rows)
                {
                    // Reset Counter
                  

                    rowcount += 1;

                    // Add values
                   
                    excelSheet.Cells[rowcount, 1] = datarow[0].ToString();
                    excelSheet.Cells[rowcount, 2] = datarow[1].ToString();

                }

                // Delete Unused Rows
                Range range;
                range = excelSheet.Range[excelSheet.Cells[count_data + 5, 1], excelSheet.Cells[152, 19]];
                range.Delete(XlDeleteShiftDirection.xlShiftUp);

                // Protected Excel
                excelSheet.Protect("kps2023");

                //now save the workbook and exit Excel


                excelworkBook.SaveAs(saveAsLocation);
                excel.DisplayAlerts = true;
                excelworkBook.Close(true);
                excelSheet = null;
                excelworkBook = null;


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
    

        public bool WriteSeryDataToExcel(System.Data.DataTable dataTable,
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

                excelSheet.Cells[2, 2] = RasdDataName;

                // loop through each row and add values to our sheet
                short rowcount = 4;
                short id = 0;
               
                short count_data = Convert.ToInt16(dataTable.Rows.Count);


                foreach (DataRow datarow in dataTable.Rows)
                {
                  
                    rowcount += 1;
                    id += 1;
                  

                    // Add values
                    excelSheet.Cells[rowcount, 1] = id.ToString(); // Id
                    excelSheet.Cells[rowcount, 2] = datarow[2].ToString(); // Name
                    excelSheet.Cells[rowcount, 3] = datarow[0].ToString(); // Golos
                }

                // Delete Unused Rows
                Range range;
                range = excelSheet.Range[excelSheet.Cells[count_data + 5, 1], excelSheet.Cells[152, 19]];
                range.Delete(XlDeleteShiftDirection.xlShiftUp);

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
       
        public System.Data.DataTable ReadRasdDataFromExcel(string staticExcelFile)

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

                int rowCount = xlRange.Rows.Count;
                //rowCount = 25;
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
                return null;
            }
            finally
            {
                excel.DisplayAlerts = true;
                excelSheet = null;
                excelworkBook = null;
                excel = null;
                waiting.End_WAit();
            }

        }

        public System.Data.DataTable ReadSeryData(string staticExcelFile)

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

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                //Set DataTable Name and Columns Name

                dt.Columns.Add("Golos", typeof(int));
                dt.Columns.Add("Sery", typeof(int));
                dt.Columns.Add("Year_Id", typeof(int));

                // loop through each row and add values to our sheet
                //Get Row Data of Excel

                int rowCounter; //This variable is used for row index number

                rowCounter = 4;

                for (int i = 4; i <= rowCount; i++) //Loop for available row of excel data
                {
                    row = dt.NewRow(); //assign new row to DataTable

                    row["Golos"] = Convert.ToInt32(xlRange.Cells[i, 3].Value2);
                    row["Sery"] = Convert.ToInt32(xlRange.Cells[i, 4].Value2);
                    row["Year_Id"] = Properties.Settings.Default.year_cod;
                    rowCounter++;

                    dt.Rows.Add(row); //add row to DataTable
                }

                excelworkBook.Close(0);

                excel.DisplayAlerts = true;
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

        public System.Data.DataTable GetInformationData(string staticExcelFile)

        {
            System.Data.DataTable dt = new System.Data.DataTable();
            
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

                dt.Columns.Add("test_kind", typeof(string));
                dt.Columns.Add("term_kind", typeof(string));
                dt.Columns.Add("grade_data", typeof(string));
                dt.Columns.Add("year_data", typeof(string));
                dt.Columns.Add("test_kind_id", typeof(string));
                dt.Columns.Add("test_grade_id", typeof(string));
                dt.Columns.Add("term_id", typeof(string));
                dt.Columns.Add("degree_data", typeof(string));

                //assign new row to DataTable
                DataRow NewRow = dt.NewRow();

                NewRow["test_kind"] = excelSheet.Cells[1, 30].Value2;
                NewRow["term_kind"] = excelSheet.Cells[2, 30].Value2;
                NewRow["grade_data"] = excelSheet.Cells[3, 30].Value2;
                NewRow["year_data"] = excelSheet.Cells[4, 30].Value2;
                NewRow["test_kind_id"] = excelSheet.Cells[5, 30].Value2;
                NewRow["test_grade_id"] = excelSheet.Cells[6, 30].Value2;
                NewRow["term_id"] = excelSheet.Cells[7, 30].Value2;
                NewRow["degree_data"] = excelSheet.Cells[8, 30].Value2;

                dt.Rows.Add(NewRow); //add row to DataTable

                excelworkBook.Close(0);

                excel.DisplayAlerts = true;
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

        public System.Data.DataTable GetInformationData_SofofOla(string staticExcelFile)

        {
            System.Data.DataTable dt = new System.Data.DataTable();

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

                dt.Columns.Add("test_kind", typeof(string));
                dt.Columns.Add("grade_data", typeof(string));
               

                //assign new row to DataTable
                DataRow NewRow = dt.NewRow();

                NewRow["test_kind"] = excelSheet.Cells[5, 16].Value2;
                NewRow["grade_data"] = excelSheet.Cells[5, 17].Value2;
                

                dt.Rows.Add(NewRow); //add row to DataTable

                excelworkBook.Close(0);

                excel.DisplayAlerts = true;
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


        public System.Data.DataTable Read_Amal_1_2_3(string staticExcelFile)

        {
            System.Data.DataTable dt = new System.Data.DataTable();

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

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                dt.Columns.Add("Golos", typeof(int));
                dt.Columns.Add("arabic", typeof(decimal));
                dt.Columns.Add("dain", typeof(decimal));
                dt.Columns.Add("math", typeof(decimal));
                dt.Columns.Add("english", typeof(decimal));
                dt.Columns.Add("motadd", typeof(decimal));
                dt.Columns.Add("badnia", typeof(decimal));

                int rowCounter; //This variable is used for row index number
                DataRow row;
                rowCounter = 5;

                for (int i = 4; i <= rowCount; i++) //Loop for available row of excel data
                {
                    row = dt.NewRow(); //assign new row to DataTable

                    row["Golos"] = Convert.ToInt32(xlRange.Cells[i, 4].Value2);
                    row["arabic"] = Convert.ToDecimal(xlRange.Cells[i, 5].Value2);
                    row["dain"] = Convert.ToDecimal(xlRange.Cells[i, 6].Value2);
                    row["math"] = Convert.ToDecimal(xlRange.Cells[i, 7].Value2);
                    row["english"] = Convert.ToDecimal(xlRange.Cells[i, 10].Value2);
                    row["motadd"] = Convert.ToDecimal(xlRange.Cells[i, 8].Value2);
                    row["badnia"] = Convert.ToDecimal(xlRange.Cells[i, 13].Value2);
                    rowCounter++;

                    dt.Rows.Add(row); //add row to DataTable
                }

                excelworkBook.Close(0);

                excel.DisplayAlerts = true;
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
        public System.Data.DataTable Read_Amal_1_2(string staticExcelFile)

        {
            System.Data.DataTable dt = new System.Data.DataTable();

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

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                dt.Columns.Add("Golos", typeof(int));
                dt.Columns.Add("arabic", typeof(decimal));
                dt.Columns.Add("dain", typeof(decimal));
                dt.Columns.Add("math", typeof(decimal));
                dt.Columns.Add("scince", typeof(decimal));
                dt.Columns.Add("english", typeof(decimal));
                dt.Columns.Add("maharat", typeof(decimal));
                dt.Columns.Add("mabday", typeof(decimal));
                dt.Columns.Add("nehay", typeof(decimal));

                int rowCounter; //This variable is used for row index number
                DataRow row;
                rowCounter = 5;

                for (int i = 5; i <= rowCount; i++) //Loop for available row of excel data
                {
                    row = dt.NewRow(); //assign new row to DataTable

                    row["Golos"] = Convert.ToInt32(xlRange.Cells[i, 4].Value2);
                    row["arabic"] = Convert.ToDecimal(xlRange.Cells[i, 5].Value2);
                    row["dain"] = Convert.ToDecimal(xlRange.Cells[i, 6].Value2);
                    row["math"] = Convert.ToDecimal(xlRange.Cells[i, 7].Value2);
                    row["scince"] = Convert.ToDecimal(xlRange.Cells[i, 8].Value2);
                    row["english"] = Convert.ToDecimal(xlRange.Cells[i, 9].Value2);
                    row["maharat"] = Convert.ToDecimal(xlRange.Cells[i, 10].Value2);
                    row["mabday"] = Convert.ToDecimal(xlRange.Cells[i, 11].Value2);
                    row["nehay"] = Convert.ToDecimal(xlRange.Cells[i, 12].Value2);
                    rowCounter++;

                    dt.Rows.Add(row); //add row to DataTable
                }

                excelworkBook.Close(0);

                excel.DisplayAlerts = true;
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

        public System.Data.DataTable Read_Amal_3(string staticExcelFile)

        {
            System.Data.DataTable dt = new System.Data.DataTable();

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

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                dt.Columns.Add("Golos", typeof(int));
                dt.Columns.Add("arabic", typeof(decimal));
                dt.Columns.Add("dain", typeof(decimal));
                dt.Columns.Add("math", typeof(decimal));
                dt.Columns.Add("scince", typeof(decimal));
                dt.Columns.Add("english", typeof(decimal));
                dt.Columns.Add("maharat", typeof(decimal));
              

                int rowCounter; //This variable is used for row index number
                DataRow row;
                rowCounter = 5;

                for (int i = 5; i <= rowCount; i++) //Loop for available row of excel data
                {
                    row = dt.NewRow(); //assign new row to DataTable

                    row["Golos"] = Convert.ToInt32(xlRange.Cells[i, 4].Value2);
                    row["arabic"] = Convert.ToDecimal(xlRange.Cells[i, 5].Value2);
                    row["dain"] = Convert.ToDecimal(xlRange.Cells[i, 6].Value2);
                    row["math"] = Convert.ToDecimal(xlRange.Cells[i, 7].Value2);
                    row["scince"] = Convert.ToDecimal(xlRange.Cells[i, 8].Value2);
                    row["english"] = Convert.ToDecimal(xlRange.Cells[i, 9].Value2);
                    row["maharat"] = Convert.ToDecimal(xlRange.Cells[i, 10].Value2);
                   
                    rowCounter++;

                    dt.Rows.Add(row); //add row to DataTable
                }

                excelworkBook.Close(0);

                excel.DisplayAlerts = true;
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

        public System.Data.DataTable Read_Amal_4_5_6(string staticExcelFile)

        {
            System.Data.DataTable dt = new System.Data.DataTable();

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

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                dt.Columns.Add("Golos", typeof(int));
                dt.Columns.Add("arabic", typeof(decimal));
                dt.Columns.Add("dain", typeof(decimal));
                dt.Columns.Add("math", typeof(decimal));
                dt.Columns.Add("scince", typeof(decimal));
                dt.Columns.Add("social", typeof(decimal));
                dt.Columns.Add("english", typeof(decimal));
                dt.Columns.Add("maharat", typeof(decimal));
                dt.Columns.Add("tocnolegy", typeof(decimal));

                int rowCounter; //This variable is used for row index number
                DataRow row ;
                rowCounter = 5;

                for (int i = 5; i <= rowCount; i++) //Loop for available row of excel data
                {
                    row = dt.NewRow(); //assign new row to DataTable

                    row["Golos"] = Convert.ToInt32(xlRange.Cells[i, 4].Value2);
                    row["arabic"] = Convert.ToDecimal(xlRange.Cells[i, 5].Value2);
                    row["dain"] = Convert.ToDecimal(xlRange.Cells[i, 6].Value2);
                    row["math"] = Convert.ToDecimal(xlRange.Cells[i, 7].Value2);
                    row["scince"] = Convert.ToDecimal(xlRange.Cells[i, 8].Value2);
                    row["social"] = Convert.ToDecimal(xlRange.Cells[i, 9].Value2);
                    row["english"] = Convert.ToDecimal(xlRange.Cells[i, 10].Value2);
                    row["maharat"] = Convert.ToDecimal(xlRange.Cells[i, 11].Value2);
                    row["tocnolegy"] = Convert.ToDecimal(xlRange.Cells[i, 12].Value2);
                    rowCounter++;

                    dt.Rows.Add(row); //add row to DataTable
                }
                
                excelworkBook.Close(0);

                excel.DisplayAlerts = true;
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
        
        public System.Data.DataTable Read_Test(string staticExcelFile, byte stage = 1)

        {
            System.Data.DataTable dt = new System.Data.DataTable();

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

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                dt.Columns.Add("Golos", typeof(int));
                dt.Columns.Add("arabic", typeof(decimal));
                dt.Columns.Add("dain", typeof(decimal));
                dt.Columns.Add("math", typeof(decimal));
                dt.Columns.Add("scince", typeof(decimal));
                dt.Columns.Add("social", typeof(decimal));
                dt.Columns.Add("english", typeof(decimal));
                dt.Columns.Add("maharat", typeof(decimal));
                dt.Columns.Add("tocnolegy", typeof(decimal));

                int rowCounter; //This variable is used for row index number
                DataRow row ;
                rowCounter = 5;

                for (int i = 5; i <= rowCount; i++) //Loop for available row of excel data
                {
                    row = dt.NewRow(); //assign new row to DataTable

                    row["Golos"] = Convert.ToInt32(xlRange.Cells[i, 1].Value2);
                    row["arabic"] = Convert.ToDecimal(xlRange.Cells[i, 3].Value2);
                    row["dain"] = Convert.ToDecimal(xlRange.Cells[i, 4].Value2);
                    switch(stage)
                    {
                        case 0:
                            row["math"] = Convert.ToDecimal(xlRange.Cells[i, 5].Value2);
                            row["scince"] = Convert.ToDecimal(xlRange.Cells[i, 6].Value2);
                            row["english"] = Convert.ToDecimal(xlRange.Cells[i, 7].Value2);
                            row["social"] = 0;
                            row["maharat"] = 0;
                            row["tocnolegy"] = 0;

                            break;

                        case 1:
                        row["math"] = Convert.ToDecimal(xlRange.Cells[i, 5].Value2);
                        row["scince"] = Convert.ToDecimal(xlRange.Cells[i, 6].Value2);
                        row["social"] = Convert.ToDecimal(xlRange.Cells[i, 7].Value2);
                        row["english"] = Convert.ToDecimal(xlRange.Cells[i, 8].Value2);
                        row["maharat"] = Convert.ToDecimal(xlRange.Cells[i, 9].Value2);
                        row["tocnolegy"] = Convert.ToDecimal(xlRange.Cells[i, 10].Value2);
                            break;

                        case 2:
                            row["math"] = Convert.ToDecimal(xlRange.Cells[i, 29].Value2);
                            row["scince"] = Convert.ToDecimal(xlRange.Cells[i, 7].Value2);
                            row["social"] = Convert.ToDecimal(xlRange.Cells[i, 8].Value2);
                            row["english"] = Convert.ToDecimal(xlRange.Cells[i, 9].Value2);
                            row["maharat"] = Convert.ToDecimal(xlRange.Cells[i, 10].Value2);
                            row["tocnolegy"] = Convert.ToDecimal(xlRange.Cells[i, 11].Value2);
                            break;
                    }
                    
                    if(Convert.ToInt32(xlRange.Cells[i, 1].Value2) == 0)
                    {
                        break;
                    }
                    rowCounter++;

                    dt.Rows.Add(row); //add row to DataTable
                }

                excelworkBook.Close(0);

                excel.DisplayAlerts = true;
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

        public System.Data.DataTable Read_Amal_7_8_9(string staticExcelFile)

        {
            System.Data.DataTable dt = new System.Data.DataTable();

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

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                dt.Columns.Add("Golos", typeof(int));
                dt.Columns.Add("arabic", typeof(decimal));
                dt.Columns.Add("dain", typeof(decimal));
                dt.Columns.Add("math", typeof(decimal));
                dt.Columns.Add("scince", typeof(decimal));
                dt.Columns.Add("scince_practical", typeof(decimal));
                dt.Columns.Add("social", typeof(decimal));
                dt.Columns.Add("english", typeof(decimal));
                dt.Columns.Add("maharat", typeof(decimal));
                dt.Columns.Add("tocnolegy", typeof(decimal));
                dt.Columns.Add("tocnolegy_practical", typeof(decimal));
                dt.Columns.Add("nashat_1", typeof(decimal));
                dt.Columns.Add("nashat_2", typeof(decimal));

                int rowCounter; //This variable is used for row index number
                DataRow row;
                rowCounter = 5;

                for (int i = 5; i <= rowCount; i++) //Loop for available row of excel data
                {
                    row = dt.NewRow(); //assign new row to DataTable

                    row["Golos"] = Convert.ToInt32(xlRange.Cells[i, 4].Value2);
                    row["arabic"] = Convert.ToDecimal(xlRange.Cells[i, 5].Value2);
                    row["dain"] = Convert.ToDecimal(xlRange.Cells[i, 6].Value2);
                    row["math"] = Convert.ToDecimal(xlRange.Cells[i, 7].Value2);
                    row["scince"] = Convert.ToDecimal(xlRange.Cells[i, 8].Value2);
                    row["scince_practical"] = Convert.ToDecimal(xlRange.Cells[i, 9].Value2);
                    row["social"] = Convert.ToDecimal(xlRange.Cells[i, 10].Value2);
                    row["english"] = Convert.ToDecimal(xlRange.Cells[i, 11].Value2);
                    row["maharat"] = Convert.ToDecimal(xlRange.Cells[i, 12].Value2);
                    row["tocnolegy"] = Convert.ToDecimal(xlRange.Cells[i, 13].Value2);
                    row["tocnolegy_practical"] = Convert.ToDecimal(xlRange.Cells[i, 14].Value2);
                    row["nashat_1"] = Convert.ToDecimal(xlRange.Cells[i, 15].Value2);
                    row["nashat_2"] = Convert.ToDecimal(xlRange.Cells[i, 16].Value2);
                    rowCounter++;

                    dt.Rows.Add(row); //add row to DataTable
                }

                excelworkBook.Close(0);

                excel.DisplayAlerts = true;
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
