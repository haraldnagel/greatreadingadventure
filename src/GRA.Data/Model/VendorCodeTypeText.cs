﻿using System.ComponentModel.DataAnnotations;

namespace GRA.Data.Model
{
    public class VendorCodeTypeText
    {
        public int VendorCodeTypeId { get; set; }
        public VendorCodeType VendorCodeType { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

        [MaxLength(1000)]
        public string EmailAwardInstructions { get; set; }
    }
}
