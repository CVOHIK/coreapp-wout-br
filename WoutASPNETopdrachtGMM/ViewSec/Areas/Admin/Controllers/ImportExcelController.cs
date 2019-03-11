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
        private readonly Dictionary<string, int> gmm_col = new Dictionary<string, int>() {
            ["Dagen"] = 1,
            ["Band"] = 2
        };
        //TODO betere binding tussen Excel en Model verzinnen

        public ImportExcelController(IHostingEnvironment hostingEnvironment, GmmContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        /// <see>
        /// https://www.c-sharpcorner.com/article/import-and-export-data-using-epplus-core/
        /// </see>
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

                var bandLijst = new List<Band>();
                var memberLijst = new List<Member>();

                for (int i = 2; i <= totalRows; i++)
                {
                    DateTime dag = DateTime.Parse(workSheet.Cells[i, gmm_col["Band"]].Value.ToString());

                    Band p = new Band
                    {
                        Name = workSheet.Cells[i, gmm_col["Dagen"]].Value.ToString()
                    };
                    bandLijst.Add(p);

                    //TODO andere geg uit Excel halen
                }

                _context.Bands.AddRange(bandLijst);
                _context.SaveChanges();

                return bandLijst;
            }
        }
    }
}