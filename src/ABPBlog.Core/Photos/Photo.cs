using Abp.Domain.Entities.Auditing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ABPBlog.Photos
{
    /// <summary>
    /// 图片信息
    /// </summary>
    public class Photo : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Url { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// 相册
        /// </summary>
        [JsonIgnore]
        public virtual PhotoAlbum PhotoAlbum { get; set; }
    }
}
