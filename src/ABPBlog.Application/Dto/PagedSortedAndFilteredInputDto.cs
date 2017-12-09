using System;
using System.Collections.Generic;
using System.Text;

namespace ABPBlog.Dto
{
    public class PagedSortedAndFilteredInputDto : PagedAndSortedInputDto
    {
        public string Filter { get; set; }
    }
}
