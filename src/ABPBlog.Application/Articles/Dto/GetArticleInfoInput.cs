using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABPBlog.Articles.Dto
{
    /// <summary>
    /// 查询条件
    /// </summary>
    public class GetArticleInfoInput
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 分类编码
        /// </summary>
        public int? ClassifyId { get; set; }

        public int Limit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Offset { get; set; }
    }
}
