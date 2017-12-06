using Abp.AspNetCore.Mvc.Authorization;
using ABPBlog.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ABPBlog.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : ABPBlogControllerBase
    {
        public ActionResult Index()
        {
            Logger.Error("错误哇哈哈");
            Logger.Info("哇哈哈");

            return View();
        }
	}
}