using Abp.Authorization;
using ABPBlog.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using System.Linq.Dynamic.Core;
using ABPBlog.Articles.Dto;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Collections.Extensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Web.Models;
using Abp.Linq.Extensions;

namespace ABPBlog.Articles
{

    [AbpAuthorize(PermissionNames.ABPBlog_Pages_Articles)]
    public class ArticleInfoAppService : ABPBlogAppServiceBase, IArticleInfoAppService
    {
        private readonly IRepository<ArticleInfo> _repository;

        public ArticleInfoAppService(IRepository<ArticleInfo> repository)
        {
            _repository = repository;
        }
        public async Task CreateOrEditArticleInfo(CreateOrEditArticleInfoDto input)
        {
            if (input.Id.HasValue)
            {
                await UpdateArticleInfo(input);
            }
            else
            {
                await CreateArticleInfo(input);
            }
        }

        public async Task DeleteArticleInfo(EntityDto input)
        {
            var articleInfo = await _repository.FirstOrDefaultAsync(input.Id);
            if (articleInfo != null)
                await _repository.DeleteAsync(articleInfo);
        }
        /// <summary>
        /// 获取所有帖子列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<ArticleInfoDto>> GetAllArticles(GetArticleInfoInput input)
        {
            var queryable = _repository.GetAll().Include(i=>i.ArticleClassify);
            if (input != null)
            {
                queryable.WhereIf(input.ClassifyId.HasValue, i => i.ClassifyId == input.ClassifyId.Value)
                    .WhereIf(!string.IsNullOrEmpty(input.Keyword), o => o.Title.Contains(input.Keyword) || o.Intro.Contains(input.Keyword)).AsQueryable();
            }
            var totalCount = await queryable.CountAsync();
            var articleInfoes = await queryable.AsNoTracking().OrderBy(input.Sorting).PageBy(input).ToListAsync();
            return new PagedResultDto<ArticleInfoDto>(totalCount, ObjectMapper.Map<List<ArticleInfoDto>>(articleInfoes));
        }
        public async Task<CreateOrEditArticleInfoDto> GetArticleInfoForEdit(NullableIdDto input)
        {
            CreateOrEditArticleInfoDto articleInfo = new CreateOrEditArticleInfoDto();
            if (input.Id.HasValue)
            {
                var info = await _repository.FirstOrDefaultAsync(input.Id.Value);
                ObjectMapper.Map(info, articleInfo);
            }
            return articleInfo;
        }
        protected virtual async Task UpdateArticleInfo(CreateOrEditArticleInfoDto input)
        {
            if (input.Id.HasValue)
            {
                var articleInfo = await _repository.FirstOrDefaultAsync(input.Id.Value);
                ObjectMapper.Map(input, articleInfo);
                await _repository.UpdateAsync(articleInfo);
            }
        }

        protected virtual async Task CreateArticleInfo(CreateOrEditArticleInfoDto input)
        {
            var aticleInfo = ObjectMapper.Map<ArticleInfo>(input);
            await _repository.InsertAsync(aticleInfo);
            await CurrentUnitOfWork.SaveChangesAsync();
        }
    }
}
