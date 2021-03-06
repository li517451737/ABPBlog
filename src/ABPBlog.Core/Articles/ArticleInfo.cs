﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ABPBlog.Articles
{
    public class ArticleInfo : FullAuditedEntity<int>
    {
        /// <summary>
        /// 分类编码
        /// </summary>
        public int ClassifyId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        [MaxLength(200)]
        public string Intro { get; set; }

        /// <summary>
        /// 封面
        /// </summary>
        [Required]
        [MaxLength(255)]
        [DataType(DataType.ImageUrl)]
        public string CoverImg { get; set; }

        /// <summary>
        /// 详情
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 来源地址
        /// </summary>
        [MaxLength(255)]
        public string SourceUrl { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(255)]
        public string Memo { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        [ForeignKey("ClassifyId")]
        public virtual ArticleClassify ArticleClassify { get; set; }
    }
}
