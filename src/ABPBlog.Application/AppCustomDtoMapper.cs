using ABPBlog.Articles;
using ABPBlog.Articles.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABPBlog
{
    internal static class AppCustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ArticleClassify, CreateOrEditArticleClassifyDto>();
            configuration.CreateMap<ArticleClassify, ArticleClassifyDto>();
            configuration.CreateMap<ArticleInfo, CreateOrEditArticleInfoDto>();
            configuration.CreateMap<ArticleInfo, ArticleInfoDto>();

        }
    }
}
