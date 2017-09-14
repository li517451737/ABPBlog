using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABPBlog.Articles.Dto
{
    [AutoMapTo(typeof(ArticleInfo))]
    public class GetAllArticleInfoDto : EntityDto<int>
    {
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
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}
