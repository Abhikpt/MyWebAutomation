using System;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using Microsoft.Office.Interop.Excel;
using FrameWorkDesign;

namespace MyWebAutomation.FrameWorkDesign.Utilities
{
    public class ExcelReading:BaseConfig
    {
        private Excel.Application _excelApp = null;
        public Excel.Workbook _workbook = null;
        public Excel.Worksheet _worksheet = null;
        static string startupPath = Environment.CurrentDirectory;
         string filePath  = startupPath.Replace("bin\\Debug\\netcoreapp3.1", "DataSet\\TestData.xlsx");    

        public void OpenExcel()
        {
            _excelApp = new Excel.Application();
            _workbook = _excelApp.Workbooks.Open(filePath);
        }

        public int[] GetTestDataRow(string testID)
        {
            int testRow = 0 , endRow = 0;
            OpenExcel();
             _worksheet = (Worksheet) _workbook.Sheets[1];

            int rowCount = _worksheet.UsedRange.Rows.Count;
            for(int i = 1; i <= rowCount; i++)
            {

                string cellValue = (string)(_worksheet.Cells[i, 1] as Excel.Range).Value;
                if(String.IsNullOrEmpty(cellValue))
                {
                    // testRow = i;
                    // break;
                }
                else if (cellValue.Equals(testID))
                {
                    testRow = i+2;
                    for(int j = testRow; j <= rowCount; j++)
                    {
                        string cellValue1 = (string)(_worksheet.Cells[j, 1] as Excel.Range).Value;
                        if(String.IsNullOrEmpty(cellValue1))
                        {
                            endRow = j;
                           goto Finish;
                        }
                    }
                }                
            }
            Finish:
            CloseExcel();
            return new int[] {testRow, endRow};
        }
         

        public string GetCellData( int rowIndex, int columnIndex)
        {
            OpenExcel();

            _worksheet = (Worksheet)_workbook.Sheets[1];
            string cellValue = (_worksheet.Cells[rowIndex, columnIndex] as Excel.Range).Value2.ToString();
            CloseExcel();
            return cellValue;
          
        }

        public string FetchJsonPayload(string testID)
        {
            string JsonRequest = null;
            OpenExcel();
            
            _worksheet = (Worksheet)_workbook.Sheets[1];
            var xcelSheetName = _worksheet.Name;
            int rowCount = _worksheet.UsedRange.Rows.Count;
            int colCount = _worksheet.UsedRange.Columns.Count;
            if(rowCount >=1 && colCount >=1)
            {
                for(int i = 1; i <= rowCount; i++)
                {
                    Excel.Range range = (Excel.Range)_worksheet.Cells[i, 1];
                    string cellValue = range.Value.ToString();

                    if(cellValue.Equals(testID))
                    {
                        JsonRequest = ((Excel.Range)_worksheet.Cells[i+2, 4]).Value.ToString();
                        Console.WriteLine(JsonRequest);
                        break;
                    }
                    i+=3;
                }
            }

            CloseExcel();
            return JsonRequest;
        }
                    

        public bool WriteTestCaseStatus(string testID, string statusValue)
        {
            bool tc_StatusConfirmation = false;
            OpenExcel();
            _worksheet = (Worksheet)_workbook.Sheets[1];
            var xlSheetName = _worksheet.Name;
            int rowCount = _worksheet.UsedRange.Rows.Count;
            int colCount = _worksheet.UsedRange.Columns.Count;
            if(rowCount >=1 && colCount >=1)
            {
                for(int i = 1; i <= rowCount; i++)
                {
                    Excel.Range range = (Excel.Range)_worksheet.Cells[i, 1];
                    string cellValue = range.Value.ToString();

                    if(cellValue.Equals(testID))
                    {
                        ((Excel.Range)_worksheet.Cells[i, 5]).Value = statusValue;
                        tc_StatusConfirmation = true;
                        break;
                    }
                    i+=3;
                }
            }
            CloseExcel();
            return tc_StatusConfirmation;
        }

        public void CloseExcel()
        {
            _workbook.Close(false, filePath, null);
            Marshal.ReleaseComObject(_workbook);
            _excelApp.Quit();
            Marshal.ReleaseComObject(_excelApp);
        }
    }
}