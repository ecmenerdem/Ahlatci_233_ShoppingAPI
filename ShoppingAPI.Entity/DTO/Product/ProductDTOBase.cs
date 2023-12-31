﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Entity.DTO.Product
{
    public class ProductDTOBase
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryGUID { get; set; }
        public string CategoryName { get; set; }
        public string FeaturedImage { get; set; }
    }
}
