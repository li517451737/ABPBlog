using Abp.AspNetCore.Mvc.Authorization;
using ABPBlog.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ABPBlog.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : ABPBlogControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}