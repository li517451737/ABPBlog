using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ABPBlog.Controllers;
using Abp.UI;
using Abp.IO.Extensions;
using Abp.Web.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ABPBlog.Web.Mvc.Controllers
{
    public class FileUploadController : ABPBlogControllerBase
    {
        private readonly IHostingEnvironment _evn;
        public FileUploadController(IHostingEnvironment evn)
        {
            _evn = evn;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> UploadImageFile(string DefaultFileUploadTextInput)
        {
            try
            {
                var file = Request.Form.Files.First();

                //Check input
                if (file == null)
                {
                    throw new UserFriendlyException(L("File_Empty_Error"));
                }

                if (file.Length > 1048576) //1MB
                {
                    throw new UserFriendlyException(L("File_SizeLimit_Error"));
                }
                var folder = Path.Combine(_evn.WebRootPath, "Upload", "image");
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                var fileName = Path.Combine(folder, file.FileName);
                if (System.IO.File.Exists(fileName))
                    System.IO.File.Delete(fileName);
                using (var stream = new FileStream(fileName, FileMode.CreateNew))
                {
                    file.CopyTo(stream);
                }
                //byte[] fileBytes;
                //using (var stream = file.OpenReadStream())
                //{
                //    fileBytes = stream.GetAllBytes();
                //}
                //var fileObject = new BinaryObject(null, fileBytes);
                //await _binaryObjectManager.SaveAsync(fileObject);

                return Json(new AjaxResponse(new
                {
                    url = "/Upload/image/" + file.FileName,
                    contentType = file.ContentType,
                    defaultFileUploadTextInput = DefaultFileUploadTextInput
                }));
            }
            catch (UserFriendlyException ex)
            {
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
    }
}