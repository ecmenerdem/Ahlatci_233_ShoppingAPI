using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingAPI.DAL.Abstract.DataManagement;
using ShoppingAPI.Entity.Poco;

namespace ShoppingAPI.DAL.Abstract
{
    public interface ICategoryRepository:IRepository<Category>
    {
    }
}
