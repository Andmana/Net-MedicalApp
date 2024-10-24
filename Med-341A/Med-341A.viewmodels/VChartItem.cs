using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med_341A.viewmodels
{
    public class VChartItem
    {
        public int Id { get; set; }

        public int IdChart { get; set; }

        public int IdItem { get; set; }

        public string Name { get; set; }

        public int Qty { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }
        public decimal SumPrice { get; set; }

        public bool? IsDelete { get; set; }

        public int CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public int? UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
