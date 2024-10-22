using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med_341A.viewmodels
{
    public class VFlagExists
    {
        public VFlagExists()
        {
            Success = true;
            isNameExists = false;
            isCodeExists = false;

        }
        public bool Success { get; set; }

        public bool isNameExists { get; set; }
        public bool isCodeExists { get; set; }
    }
}
