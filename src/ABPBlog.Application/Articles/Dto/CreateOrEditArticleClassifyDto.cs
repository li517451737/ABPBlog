using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABPBlog.Articles.Dto
{
    [AutoMapTo(typeof(ArticleClassify))]
    public class CreateOrEditArticleClassifyDto : NullableIdDto
    {
        public string ClassName { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        public DateTime CreationTime { get; set; }

        public CreateOrEditArticleClassifyDto()
        {
            CreationTime = Abp.Timing.Clock.Now;
        }
    }
}
