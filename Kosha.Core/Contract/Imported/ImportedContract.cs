using Kosha.Core.Bussinus.SMHelper;
using Kosha.Core.Common.Helper;
using Kosha.Core.Common.Model;
using Kosha.Core.Services.Imported;
using Kosha.DataLayer;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosha.Core.Contract.Imported
{
    public class ImportedContract : IImportedContract
    {
        private readonly IUserHelper _userHelper;
        private readonly IImportedService _importedService;

        public ImportedContract(IUserHelper userHelper,
            IImportedService importedService)
        {
            _userHelper = userHelper;
            _importedService = importedService;
        }


        public async Task<MemoryStream> GetStatusReportExcel(string year, string month, long projectId)
        {
            var model = await _importedService.GetAllByProjectId(year, month, projectId);

            MemoryStream result = (MemoryStream)ExportToExcel(model);
            result.Position = 0;

            return result;
        }

        public object ExportToExcel(IEnumerable<Kosha_Summary> model)
        {
            using (var excelFile = new ExcelPackage())
            {


                var worksheet = excelFile.Workbook.Worksheets.Add("صورت وضعیت من");
                worksheet.View.RightToLeft = true;

                //worksheet.Cells["B1"].Value = "نام ‌و ‌نام‌خانوادگی";


                worksheet.Cells["A1"].LoadFromCollection(Collection: model, PrintHeaders: true, OfficeOpenXml.Table.TableStyles.Light13);

                var index = worksheet.Cells["1:1"].First(c => c.Value.ToString() == "ProjectRef").Start.Column;
                worksheet.DeleteColumn(index);

                var allCells = worksheet.Cells[1, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column];
                var cellFont = allCells.Style.Font;

                cellFont.SetFromFont(new Font("B Nazanin", 11));

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                MemoryStream result = new MemoryStream();
                result.Position = 0;

                excelFile.SaveAs(result);

                return result;
            }
        }

    }
}
