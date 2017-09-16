using System;
using System.Collections.Generic;
using System.Text;

namespace ABPBlog
{
    public class PagedListDto<T> where T : class
    {
        public int TotalCount { get; set; }

        public List<T> Items { get; set; }
    }
}
