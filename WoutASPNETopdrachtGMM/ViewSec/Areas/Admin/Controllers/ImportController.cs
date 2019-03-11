using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessFacade;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ViewSec.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ImportController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly GmmContext _context;

        public ImportController(IHostingEnvironment hostingEnvironment, GmmContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OnPostImport()
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "Upload";
            string sFileExtension = Path.GetExtension(file.FileName).ToLower();
            string fileName = "testUploadFile" + sFileExtension;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            StringBuilder sb = new StringBuilder();
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string fullPath = Path.Combine(newPath, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                var bands =  new ImportExcelController(_hostingEnvironment, _context).ImportExcelFile();

                //Return table met imported bands
                sb.Append("<table class='table'><tr><th>Id</th><th>Name</th><th>Members</th></tr>");
                sb.AppendLine("<tr>");
                for (int i = 0; i < bands.Count; i++)
                {
                    sb.AppendFormat("<td>{0}</td><td>{1}</td><td>{2}</td>", bands[i].Id.ToString(), bands[i].Name.ToString(), bands[i].Members.ToString());
                    sb.AppendLine("</tr>");
                }
                sb.Append("</table>");
            }
            return this.Content(sb.ToString());
        }
    }
}