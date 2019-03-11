using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessFacade;
using Data;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;

namespace ViewSec.Areas.Admin.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ImportExcelController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly GmmContext _context;

        public ImportExcelController(IHostingEnvironment hostingEnvironment, GmmContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        /// <summary>
        /// https://www.c-sharpcorner.com/article/import-and-export-data-using-epplus-core/
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IList<Band> ImportExcelFile()
        {
            string rootFolder = _hostingEnvironment.WebRootPath;
            string fileName = @"Upload\testUploadFile.xlsx";
            FileInfo file = new FileInfo(Path.Combine(rootFolder, fileName));

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets["Data_Gmm2018"];
                int totalRows = workSheet.Dimension.Rows;

                List<Band> bandLijst = new List<Band>();

                for (int i = 2; i <= totalRows; i++)
                {
                    Band p = new Band
                    {
                        Name = workSheet.Cells[i, 2].Value.ToString()
                    };
                    bandLijst.Add(p);
                }

                _context.Bands.AddRange(bandLijst);
                _context.SaveChanges();

                return bandLijst;
            }
        }
    }
}