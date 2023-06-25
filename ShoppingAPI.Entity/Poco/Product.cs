using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ShoppingAPI.Entity.Base;

namespace ShoppingAPI.Entity.Poco
{
    public class Product:AuditableEntity
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }

        public virtual IEnumerable<OrderDetail>OrderDetails { get; set; }

        public virtual Category Category { get; set; }
    }
}
