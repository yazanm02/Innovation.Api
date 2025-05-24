using ClosedXML.Excel;
using System.Reflection;
using System.Collections.Generic;
using System.IO;

namespace Innovation_Task.Services
{
    public class ExcelExportService
    {
        public byte[] ExportToExcel<T>(List<T> data, string sheetName, string? title, List<string>? selectedColumns)
        {
            try
            {
                // كود التصدير هنا (اللي أعطيتني إياه)

                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add(sheetName);
                int currentRow = 1;

                if (!string.IsNullOrEmpty(title))
                {
                    worksheet.Cell(currentRow, 1).Value = title;
                    worksheet.Range(currentRow, 1, currentRow, selectedColumns.Count).Merge();
                    worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                    worksheet.Cell(currentRow, 1).Style.Font.FontSize = 16;
                    worksheet.Cell(currentRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    currentRow++;
                }

                for (int i = 0; i < selectedColumns.Count; i++)
                {
                    worksheet.Cell(currentRow, i + 1).Value = selectedColumns[i];
                    worksheet.Cell(currentRow, i + 1).Style.Font.Bold = true;
                    worksheet.Cell(currentRow, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                }
                currentRow++;

                foreach (var item in data)
                {
                    for (int col = 0; col < selectedColumns.Count; col++)
                    {
                        var propInfo = typeof(T).GetProperty(selectedColumns[col]);
                        if (propInfo == null)
                            throw new Exception($"Property '{selectedColumns[col]}' not found on type '{typeof(T).Name}'.");

                        var val = propInfo.GetValue(item);
                        worksheet.Cell(currentRow, col + 1).Value = val?.ToString();
                    }
                    currentRow++;
                }

                using var stream = new MemoryStream();
                workbook.SaveAs(stream);
                return stream.ToArray();
            }
            catch (Exception ex)
            {
                // هنا سجل الخطأ (مثلاً في ملف لوج أو Console)
                Console.WriteLine($"ExportToExcel failed: {ex.Message}");
                throw; // أعِد رمي الخطأ ليصل إلى الـ API controller
            }
        }

    }
}
