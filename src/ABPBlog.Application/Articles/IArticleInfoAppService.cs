using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ABPBlog.Articles.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABPBlog.Articles
{
    public interface IArticleInfoAppService : IApplicationService
    {
        Task<PagedResultDto<ArticleInfoDto>> GetAllArticles(GetArticleInfoInput input);

        Task CreateOrEditArticleInfo(CreateOrEditArticleInfoDto input);

        Task<CreateOrEditArticleInfoDto> GetArticleInfoForEdit(NullableIdDto input);

        Task DeleteArticleInfo(EntityDto input);
    }
}
