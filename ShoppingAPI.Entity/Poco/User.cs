using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingAPI.Entity.Base;

namespace ShoppingAPI.Entity.Poco
{
    public class User:AuditableEntity
    {
        //User.Order.OrderDetails

        public User()
        {
            /*Lazy Loading -- Eager Loading*/
           Orders =  new HashSet<Order>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Adress { get; set; }

      
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
