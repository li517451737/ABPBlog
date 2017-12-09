using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ABPBlog.Photos.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABPBlog.Photos
{
    public interface IPhotosAppService : IApplicationService
    {
        /// <summary>
        /// 新建或修改图片
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEditPhotoAsync(CreateOrEditPhotoDto input);

        /// <summary>
        /// 获取带编辑的图片信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CreateOrEditPhotoDto> GetPhotoForEditAsync(NullableIdDto<Guid> input);

        /// <summary>
        /// 获取图片列表
        /// </summary>
        /// <returns></returns>
        Task<PagedResultDto<PhotoDto>> GetPhotosAsync(GetPhotoDto input);

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeletePhotoAsync(EntityDto<Guid> input);
    }
}
