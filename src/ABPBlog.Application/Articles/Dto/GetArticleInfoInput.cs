using Abp.Application.Services.Dto;
using Abp.Extensions;
using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABPBlog.Articles.Dto
{
    /// <summary>
    /// 查询条件
    /// </summary>
    public class GetArticleInfoInput: PagedAndSortedResultRequestDto, IShouldNormalize
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 分类编码
        /// </summary>
        public int? ClassifyId { get; set; }

        public void Normalize()
        {
            if (Sorting.IsNullOrWhiteSpace())
            {
                Sorting = "LastModificationTime DESC";
            }
            MaxResultCount = 10;
        }
    }
}
