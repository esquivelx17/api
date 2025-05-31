using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;

namespace InvSis.Views.UtilitiesForms
{
    public static class ExportarExel
    {
        public static void ExportarDataGridViewToExcel(DataGridView dgv)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Productos");

                // Agregar encabezados
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dgv.Columns[i].HeaderText;
                    worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                    worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                }

                // Agregar filas
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    var row = dgv.Rows[i];
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        var cellValue = row.Cells[j].Value;
                        worksheet.Cell(i + 2, j + 1).Value = cellValue?.ToString() ?? "";
                    }
                }

                worksheet.Columns().AdjustToContents();

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                    saveFileDialog.Title = "Guardar archivo Excel";
                    saveFileDialog.FileName = "Ingrese nombre.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Exportación exitosa.", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
