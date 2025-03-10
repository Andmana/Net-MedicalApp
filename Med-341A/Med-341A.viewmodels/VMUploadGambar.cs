﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med_341A.viewmodels
{
    public class VMUploadGambar
    {
        public long Id { get; set; }
        public long? BiodataId { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? ImageFile { get; set; }
        public long? ModifiedBy { get; set; }
        public byte[]? Image { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
