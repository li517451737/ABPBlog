using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ABPBlog.Articles
{
    public class ArticleClassify : FullAuditedEntity<int>
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        [MaxLength(20)]
        public string ClassName { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}
