using Microsoft.EntityFrameworkCore;
using ShoppingAPI.DAL.Abstract;
using ShoppingAPI.DAL.Concrete.EntityFramework.DataManagement;
using ShoppingAPI.Entity.Poco;

namespace ShoppingAPI.DAL.Concrete.EntityFramework
{
    public class EfOrderDetailRepository : EfRepository<OrderDetail>, IOrderDetailRepository
    {
        public EfOrderDetailRepository(DbContext context) : base(context)
        {
        }
    }
}
