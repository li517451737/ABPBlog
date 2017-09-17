using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ABPBlog.Controllers;
using Abp.AspNetCore.Mvc.Authorization;
using ABPBlog.Authorization;
using ABPBlog.Articles;
using ABPBlog.Web.Models.Articles;
using Abp.Application.Services.Dto;

namespace ABPBlog.Web.Mvc.Controllers
{
    [AbpMvcAuthorize(PermissionNames.ABPBlog_Pages_ArticlesClassify)]
    public class ArticleClassifiesController : ABPBlogControllerBase
    {
        private readonly IArticleClassifyAppService _classifyService;

        public ArticleClassifiesController(IArticleClassifyAppService classifyService)
        {
            _classifyService = classifyService;
        }

        public async Task<IActionResult> Index()
        {
            var classifies = (await _classifyService.GetAllArticleClassifies()).Items;
            var list = ObjectMapper.Map<IReadOnlyList<ArticleClassifyListViewModel>>(classifies);
            return View(list);
        }

        public async Task<ActionResult> EditCLassifyModal(int classifyId)
        {
            var classifyInfo = await _classifyService.GetArticleClassifyForEdit(new NullableIdDto(classifyId));
            var model = new EditArticleCLassifyViewModel();
            ObjectMapper.Map(classifyInfo, model);
            return View("_EditClassifyModal", model);
        }
    }
}