using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ABPBlog.Photos
{
    /// <summary>
    /// 相册
    /// </summary>
    public class PhotoAlbum : AuditedEntity<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string AlbumName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(200)]
        public string Description { get; set; }

        /// <summary>
        /// 图片导航
        /// </summary>
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
