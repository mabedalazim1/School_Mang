using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace School_Mang.BL.ExcelUtils
{
    public class ExcelWorkbookSession : IDisposable
    {
        public Application ExcelApp { get; private set; }
        public Workbook Workbook { get; private set; }
        public Worksheet Worksheet { get; private set; }

        private bool _disposed;

        public ExcelWorkbookSession(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("مسار ملف Excel غير صحيح.");

            if (!File.Exists(filePath))
                throw new FileNotFoundException(
                    "ملف Excel غير موجود.", filePath);

            try
            {
                ExcelApp = new Application();
                ExcelApp.Visible = false;
                ExcelApp.DisplayAlerts = false;

                Workbooks workbooks = ExcelApp.Workbooks;

                try
                {
                    Workbook = workbooks.Open(filePath);
                }
                finally
                {
                    ReleaseComObject(workbooks);
                }

                Sheets sheets = null;

                try
                {
                    sheets = Workbook.Sheets;
                    Worksheet = (Worksheet)sheets[1];
                }
                finally
                {
                    ReleaseComObject(sheets);
                }
            }
            catch
            {
                Dispose();
                throw;
            }
        }

        public void Save()
        {
            ThrowIfDisposed();
            Workbook.Save();
        }

        public void SaveAs(string filePath)
        {
            ThrowIfDisposed();

            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("مسار الحفظ غير صحيح.");

            Workbook.SaveAs(filePath);
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(
                    nameof(ExcelWorkbookSession));
        }

        private static void ReleaseComObject(object obj)
        {
            if (obj != null && Marshal.IsComObject(obj))
            {
                Marshal.FinalReleaseComObject(obj);
            }
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            _disposed = true;

            try
            {
                if (ExcelApp != null)
                    ExcelApp.DisplayAlerts = true;

                if (Workbook != null)
                    Workbook.Close(false);
            }
            catch
            {
                // نكمل تنظيف مراجع COM حتى لو فشل الإغلاق
            }

            ReleaseComObject(Worksheet);
            Worksheet = null;

            ReleaseComObject(Workbook);
            Workbook = null;

            try
            {
                if (ExcelApp != null)
                    ExcelApp.Quit();
            }
            catch
            {
                // نكمل التنظيف
            }

            ReleaseComObject(ExcelApp);
            ExcelApp = null;
        }
    }
}

