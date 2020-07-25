using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Core.CustomEntities
{
    public class MetaData
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
        public int HasNextPage { get; set; }

        public int HasPreviousPage { get; set; }
        public string NextPageUrl { get; set; }
        public string PreviousPageUrl { get; set; }
    }
}
