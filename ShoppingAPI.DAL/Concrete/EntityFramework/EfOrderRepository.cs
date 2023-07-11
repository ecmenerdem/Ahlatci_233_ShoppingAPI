using Microsoft.EntityFrameworkCore;
using ShoppingAPI.DAL.Abstract;
using ShoppingAPI.DAL.Concrete.EntityFramework.DataManagement;
using ShoppingAPI.Entity.Poco;

namespace ShoppingAPI.DAL.Concrete.EntityFramework
{
    public class EfOrderRepository : EfRepository<Order>, IOrderRepository
    {
        public EfOrderRepository(DbContext context) : base(context)
        {
        }
    }
}
