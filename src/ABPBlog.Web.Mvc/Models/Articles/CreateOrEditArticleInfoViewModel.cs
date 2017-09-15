using Abp.AutoMapper;
using ABPBlog.Articles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABPBlog.Web.Models.Articles
{
    [AutoMapTo(typeof(CreateOrEditArticleInfoDto))]
    public class CreateOrEditArticleInfoViewModel : CreateOrEditArticleInfoDto
    {
        public bool IsEdit
        {
            get { return Id.HasValue; }
        }
    }
}
