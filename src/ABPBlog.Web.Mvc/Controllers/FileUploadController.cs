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
        public JsonResult UploadImageFile(string DefaultFileUploadTextInput)
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
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> CkUploadImage()
        {
            var CKEditorFuncNum = HttpContext.Request.Query["CKEditorFuncNum"];
            string tpl = "<script>window.parent.CKEDITOR.tools.callFunction(\"{0}\", \"{1}\",\"{2}\");</script>";
            var file = Request.Form.Files["upload"];
            if (file == null)
                return Content(string.Format(tpl, CKEditorFuncNum, "", "请选择图片"), "text/html");
            List<string> imgtypelist = new List<string> { "image/jpeg", "image/png", "image/x-png", "image/icon","image/gif", "image/bmp" };
            if (imgtypelist.FindIndex(x => x == file.ContentType) == -1)
            {
                return Content(string.Format(tpl, CKEditorFuncNum,"", "请上传一张图片！"), "text/html");
            }
            var fileName = file.FileName;
            var filePhysicalFoder = Path.Combine(_evn.WebRootPath, "upload", "image", "ckImage");
            if (!Directory.Exists(filePhysicalFoder))
                Directory.CreateDirectory(filePhysicalFoder);
            var filePhysicalPath = Path.Combine(filePhysicalFoder, fileName);//我把它保存在网站根目录的 upload 文件夹
            if (System.IO.File.Exists(filePhysicalPath))
                System.IO.File.Delete(filePhysicalPath);
            await Task.Run(() =>
            {
                using (var stream = new FileStream(filePhysicalPath, FileMode.CreateNew))
                {
                    file.CopyTo(stream);
                }
            });
            var url = "/upload/image/ckImage/" + fileName;
            //上传成功后，我们还需要通过以下的一个脚本把图片返回到第一个tab选项
            return Content(string.Format(tpl, CKEditorFuncNum, url, ""), "text/html");
        }
    }
}