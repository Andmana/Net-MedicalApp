using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med_341A.viewmodels
{
    public class VMenuRole
    {
        public long Id { get; set; }

        public string? MenuName { get; set; }
        public string? MenuController { get; set; }
        public string? MenuAction { get; set; }
        public string? MenuIconSmall { get; set; }
        public string? MenuIconBig { get; set; }
        public long? MenuSorting { get; set; }
        public bool? IsParent { get; set; }

        public long? MenuParent { get; set; }
        public long? IdRole { get; set; }
        public string? NameRole { get; set; }
        public long? IdMenu { get; set; }
        public bool is_selected { get; set; }
        public List<VMenuRole>? List_Child { get; set; }
    }
}
