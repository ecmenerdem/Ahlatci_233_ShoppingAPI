using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingAPI.Entity.Poco;

namespace ShoppingAPI.DAL.Abstract.DataManagement
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }/*_uow.UserRepository.AddAsync(user)*/
        ICategoryRepository CategoryRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        Task<int> SaveChangeAsync();
    }
}
