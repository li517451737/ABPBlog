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
using Abp.Application.Services.Dto;
using ABPBlog.Web.Models.Articles;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABPBlog.Web.Mvc.Controllers
{
    [AbpMvcAuthorize(PermissionNames.ABPBlog_Pages_Articles)]
    public class ArticleInfoesController : ABPBlogControllerBase
    {
        private readonly IArticleInfoAppService _articleService;
        private readonly IArticleClassifyAppService _classifyService;

        public ArticleInfoesController(IArticleInfoAppService articleService, IArticleClassifyAppService classifyService)
        {
            _articleService = articleService;
            _classifyService = classifyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateOrEdit(int? id)
        {
            var model = await _articleService.GetArticleInfoForEdit(new NullableIdDto(id));
            CreateOrEditArticleInfoViewModel viewModel = new CreateOrEditArticleInfoViewModel();
            if (model != null && model.Id.HasValue)
                ObjectMapper.Map(model, viewModel);
            var classifyList = await _classifyService.GetAllArticleClassifies();
            ViewBag.ClassifyList = new SelectList(classifyList.Items, "Id", "ClassName");
            return View(viewModel);
        }
    }
}