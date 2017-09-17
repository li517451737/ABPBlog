using Abp.AutoMapper;
using ABPBlog.Articles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABPBlog.Web.Models.Articles
{
    [AutoMapFrom(typeof(ArticleClassifyDto))]
    public class ArticleClassifyListViewModel : ArticleClassifyDto
    {
    }
}
