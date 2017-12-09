using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABPBlog.Photos.Dto
{
    [AutoMapFrom(typeof(Photo))]
    public class PhotoDto : EntityDto<Guid>
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        public string ThumbnailUrl { get; set; }


    }
}
