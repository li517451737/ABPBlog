using ABPBlog.Controllers;
using Microsoft.AspNetCore.Antiforgery;

namespace ABPBlog.Web.Host.Controllers
{
    public class AntiForgeryController : ABPBlogControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}