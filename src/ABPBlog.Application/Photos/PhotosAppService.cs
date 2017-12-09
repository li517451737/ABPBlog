using Abp.Domain.Repositories;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using ABPBlog.Photos.Dto;
using Abp.Linq.Extensions;
using Abp.Collections.Extensions;
using Abp.Extensions;
using System.Linq.Dynamic.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ABPBlog.Photos
{
    public class PhotosAppService : ABPBlogAppServiceBase, IPhotosAppService
    {
        private readonly IRepository<Photo, Guid> _repository;

        public PhotosAppService(IRepository<Photo, Guid> repository)
        {
            _repository = repository;
        }

        public async Task CreateOrEditPhotoAsync(CreateOrEditPhotoDto input)
        {
            if (input.Id.HasValue)
            {
                await EditPhotoAsync(input);
            }
            else
            {
                await CreatePhotoAsync(input);
            }
        }

        public async Task<CreateOrEditPhotoDto> GetPhotoForEditAsync(NullableIdDto<Guid> input)
        {
            CreateOrEditPhotoDto output = new CreateOrEditPhotoDto();
            if (input.Id.HasValue)
            {
                var photo = await _repository.FirstOrDefaultAsync(input.Id.Value);
                ObjectMapper.Map(photo, output);
            }
            return output;
        }
        /// <summary>
        /// 查询图片列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<PhotoDto>> GetPhotosAsync(GetPhotoDto input)
        {
            var queryable = _repository.GetAll().WhereIf(input.AlbumId.HasValue, p => p.AlbumId == input.AlbumId.Value);
            queryable = !input.Sorting.IsNullOrWhiteSpace() ? queryable.OrderBy(input.Sorting) : queryable.OrderByDescending(p => p.CreationTime);
            var photosCount = await queryable.CountAsync();

            var photos = queryable.PageBy(input).ToListAsync();
            return new PagedResultDto<PhotoDto>(photosCount, ObjectMapper.Map<List<PhotoDto>>(photos));
        }

        public async Task DeletePhotoAsync(EntityDto<Guid> input)
        {
            var photo = await _repository.FirstOrDefaultAsync(input.Id);
            if (photo != null)
            {
                await _repository.DeleteAsync(photo);
            }
        }

        private async Task CreatePhotoAsync(CreateOrEditPhotoDto input)
        {
            var photo = ObjectMapper.Map<Photo>(input);
            await _repository.InsertAsync(photo);
            await CurrentUnitOfWork.SaveChangesAsync();
        }

        private async Task EditPhotoAsync(CreateOrEditPhotoDto input)
        {
            var oldPhoto = await _repository.FirstOrDefaultAsync(input.Id.Value);
            if (oldPhoto != null)
            {
                ObjectMapper.Map(input, oldPhoto);
                await _repository.UpdateAsync(oldPhoto);
            }
        }
    }
}
