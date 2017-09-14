using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABPBlog.Articles.Dto
{
    [AutoMapTo(typeof(ArticleInfo))]
    public class CreateOrEditArticleInfoDto
    {
        public int? Id { get; set; }
        /// <summary>
        /// 分类编码
        /// </summary>
        public int ClassifyId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Intro { get; set; }

        /// <summary>
        /// 封面
        /// </summary>
        public string CoverImg { get; set; }

        /// <summary>
        /// 详情
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 来源地址
        /// </summary>
        public string SourceUrl { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
    }
}
