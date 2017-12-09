using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ABPBlog.Photos.Dto
{
    [AutoMapTo(typeof(Photo))]
    public class CreateOrEditPhotoDto : NullableIdDto<Guid>
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
    }
}
