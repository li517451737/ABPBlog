using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ABPBlog.Controllers;
using ABPBlog.Articles;
using Abp.AspNetCore.Mvc.Authorization;
using ABPBlog.Authorization;
using Abp.Web.Models;
using ABPBlog.Articles.Dto;

namespace ABPBlog.Web.Mvc.Controllers
{
    [AbpMvcAuthorize(PermissionNames.ABPBlog_Pages_Articles)]
    public class ArticleInfoesController : ABPBlogControllerBase
    {
        private readonly IArticleInfoAppService _articleService;

        public ArticleInfoesController(IArticleInfoAppService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<JsonResult> GetArticleInfoes(string keyword, int? classifyId, int limit = 10, int offset = 0)
        {
            var articles = await _articleService.GetAllArticles(new GetArticleInfoDto
            {
                Keyword = keyword,
                Limit = limit,
                Offset = offset,
                ClassifyId = classifyId
            });
            int total = await _articleService.GetArticlesCountAsync();
            return Json(new { total = total, rows = articles.Items }, new Newtonsoft.Json.JsonSerializerSettings { DateFormatString = "yyyy-MM-dd" });
        }
    }
}