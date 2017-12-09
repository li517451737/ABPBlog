using ABPBlog.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABPBlog.Photos.Dto
{
    public class GetPhotoDto : PagedSortedAndFilteredInputDto
    {
        /// <summary>
        /// 相册编码
        /// </summary>
        public Guid? AlbumId { get; set; }
    }
}
