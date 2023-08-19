using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Entity.DTO.Category
{
    public class CategoryDTOBase
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
    }
}
