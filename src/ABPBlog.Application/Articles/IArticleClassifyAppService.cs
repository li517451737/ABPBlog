using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ABPBlog.Articles.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABPBlog.Articles
{
    public interface IArticleClassifyAppService : IApplicationService
    {

        Task<ListResultDto<GetAllArticleInfoDto>> GetAllArticleClassifies();

        Task CreateOrEditArticleClassify(CreateOrEditArticleClassifyDto input);

        Task<CreateOrEditArticleInfoDto> GetArticleClassifyForEdit(NullableIdDto input);

        Task DeleteArticleClassify(EntityDto input);

        Task<int> GetArticlesCountAsync();

    }
}
