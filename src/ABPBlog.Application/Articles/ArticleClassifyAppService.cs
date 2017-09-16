using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using ABPBlog.Articles.Dto;
using Abp.Authorization;
using ABPBlog.Authorization;
using Abp.Domain.Repositories;
using System.Linq;
using Abp.UI;
using Abp.Collections.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ABPBlog.Articles
{
    [AbpAuthorize(PermissionNames.ABPBlog_Pages_ArticlesClassify)]
    public class ArticleClassifyAppService : ABPBlogAppServiceBase, IArticleClassifyAppService
    {
        private readonly IRepository<ArticleClassify> _repository;

        public ArticleClassifyAppService(IRepository<ArticleClassify> repository)
        {
            _repository = repository;
        }

        public async Task CreateOrEditArticleClassify(CreateOrEditArticleClassifyDto input)
        {
            if (input.Id.HasValue)
            {
                await UpdateArticleClassify(input);
            }
            else
            {
                await CreateArticleClassify(input);
            }
        }

        public async Task DeleteArticleClassify(EntityDto input)
        {
            var classifyInfo = await _repository.FirstOrDefaultAsync(input.Id);
            if (classifyInfo != null)
                await _repository.DeleteAsync(classifyInfo);
        }

        public async Task<ListResultDto<ArticleClassifyDto>> GetAllArticleClassifies()
        {
            var queryable = await _repository.GetAll().Where(i=>!i.IsDeleted).ToListAsync();

            return new ListResultDto<ArticleClassifyDto>(ObjectMapper.Map<List<ArticleClassifyDto>>(queryable));
        }

        public async Task<CreateOrEditArticleInfoDto> GetArticleClassifyForEdit(NullableIdDto input)
        {

            CreateOrEditArticleInfoDto classifyInfo = new CreateOrEditArticleInfoDto();
            if (input.Id.HasValue)
            {
                var info = await _repository.FirstOrDefaultAsync(input.Id.Value);
                ObjectMapper.Map(info, classifyInfo);
            }
            return classifyInfo;
        }
        protected virtual async Task UpdateArticleClassify(CreateOrEditArticleClassifyDto input)
        {
            if (input.Id.HasValue)
            {
                var oldClassify = await _repository.FirstOrDefaultAsync(input.Id.Value);
                ObjectMapper.Map(input, oldClassify);
                await _repository.UpdateAsync(oldClassify); 
            }
        }

        protected virtual async Task CreateArticleClassify(CreateOrEditArticleClassifyDto input)
        {
            if (_repository.GetAll().Any(i => i.ClassName.Equals(input.ClassName)))
                throw new UserFriendlyException("分类名称已存在");
            var classifyInfo = ObjectMapper.Map<ArticleClassify>(input);
            await _repository.InsertAsync(classifyInfo);
            await CurrentUnitOfWork.SaveChangesAsync();
        }
    }
}
