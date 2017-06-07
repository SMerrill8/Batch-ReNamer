using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace Ideal.ReNamer
{
    /// <summary>
    /// ExcelProcessor is responsible for interfacing with MS Excel.  All of the data 
    /// coming from and to Hydromax USA is currently done by exchanging Excel spreadsheets.
    /// </summary>
    public class ExcelProcessor
    {
        /// <summary>
        /// Borrowed from http://epplus.codeplex.com
        /// </summary>
        /// <param name="fileName">Existing file</param>
        /// <param name="hasHeaders"></param>
        /// <param name="startRow"></param>
        /// <exception cref="ArgumentException">If the fileName does not exist.</exception>
        /// <returns></returns>
        public static Dictionary<int, string> ImportOfficeOpenXmlWorkbook(string fileName, bool hasHeaders, int startRow = 2)
        {
            Dictionary<int, string> ret = new Dictionary<int, string>();
            FileInfo fileInfo = new FileInfo(fileName);
            int index = -1;
            try
            {
                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet sheet = package.Workbook.Worksheets[1];

                    int topRow = startRow;
                    const string leftCol = "A"; // Original Filename
                    const string rightCol = "B"; // New Filename
                    if (!hasHeaders) topRow--;

                    List<List<string>> outRange = GetValuesFromRange(sheet, leftCol, topRow, rightCol);

                    for (index = 0; index < outRange.Count; index++)
                    {
                        List<string> outRow = outRange[index];
                        ret.Add(index + topRow, $"{outRow[0]}|{outRow[1]}");
                    }
                }
            }
            catch (Exception e)
            {
                string msg = index == -1
                    ? $"{e.Message}"
                    : $"at worksheet row {index}: {e.Message}";
                throw new ApplicationException(msg);
            }
            return ret;
        }

        private static List<List<string>> GetValuesFromRange(ExcelWorksheet sheet, string leftCol, int topRow,
            string rightCol)
        {
            List<List<string>> outRange = new List<List<string>>();
            bool done = false;
            int r = topRow;

            do
            {
                List<string> b = GetRow(sheet, r++, leftCol, rightCol);
                // determine when we are done reading rows:
                if (b.Count == 0)
                {
                    done = true;
                }
                else if (String.IsNullOrEmpty(b[1])) // source filename is empty
                {
                    done = true;
                }

                if (done) continue;
                outRange.Add(b);
            } while (!done);

            return outRange;
        }

        private static List<string> GetRow(ExcelWorksheet sheet, int r, string leftCol, string rightCol)
        {
            // read an entire row at once for speed optimization
            List<string> ret = new List<string>();
            foreach (ExcelRangeBase v in sheet.Cells[$"{leftCol}{r}:{rightCol}{r}"])
            {
                if (v.Value == null)
                {
                    // null values are empty strings now.
                    ret.Add(String.Empty);
                }
                else
                {

                    ret.Add(v.Text);
                }
            }
            return ret;
        }
    }
}