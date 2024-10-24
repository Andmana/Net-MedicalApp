using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med_341A.viewmodels
{
    public class VSearchPage
    {
        public string? CodeTransaction { get; set; }
        public string? Name { get; set; }

        public int? CategoryId { get; set; }
        public int? SegmentationId { get; set; }

        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }

        public int? pageNumber { get; set; }
        public int? pageSize { get; set; }

        public int? CurrentPageSize { get; set; }
    }
}
