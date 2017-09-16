using Abp.Authorization;
using ABPBlog.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using ABPBlog.Articles.Dto;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Collections.Extensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Web.Models;

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
        
        public async Task<PagedListDto<ArticleInfoDto>> GetAllArticles(GetArticleInfoInput input)
        {
            var queryable = _repository.GetAll().Include(i=>i.ArticleClassify);
            int totalCount = await queryable.CountAsync();
            if (input != null)
            {
                queryable.WhereIf(input.ClassifyId.HasValue, i => i.ClassifyId == input.ClassifyId.Value)
                    .WhereIf(!string.IsNullOrEmpty(input.Keyword), o => o.Title.Contains(input.Keyword) || o.Intro.Contains(input.Keyword))
                    .OrderByDescending(i=>i.UpdateTime).Skip(input.Offset).Take(input.Limit);
            }
            var articleInfoes = await queryable.ToListAsync();
            return new PagedListDto<ArticleInfoDto>
            {
                Items = ObjectMapper.Map<List<ArticleInfoDto>>(articleInfoes),
                TotalCount = totalCount
            };
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
