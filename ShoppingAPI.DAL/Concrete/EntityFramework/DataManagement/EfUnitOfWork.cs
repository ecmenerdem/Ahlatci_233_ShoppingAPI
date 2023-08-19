using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShoppingAPI.DAL.Abstract;
using ShoppingAPI.DAL.Abstract.DataManagement;
using ShoppingAPI.DAL.Concrete.EntityFramework.Context;
using ShoppingAPI.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.DAL.Concrete.EntityFramework.DataManagement
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ShoppingContext _shoppingContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EfUnitOfWork(ShoppingContext shoppingContext, IHttpContextAccessor httpContextAccessor)
        {
            _shoppingContext = shoppingContext;
            _httpContextAccessor = httpContextAccessor;
            UserRepository = new EfUserRepository(_shoppingContext);
            CategoryRepository = new EfCategoryRepository(_shoppingContext);
            OrderDetailRepository = new EfOrderDetailRepository(_shoppingContext);
            OrderRepository = new EfOrderRepository(_shoppingContext);
            ProductRepository = new EfProductRepository(_shoppingContext);
        }

        public IUserRepository UserRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IOrderDetailRepository OrderDetailRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IProductRepository ProductRepository { get; }

        public async Task<int> SaveChangeAsync()
        {
            foreach (EntityEntry<AuditableEntity> item in _shoppingContext.ChangeTracker.Entries<AuditableEntity>())
            {
                if (item.State==Microsoft.EntityFrameworkCore.EntityState.Added)
                {
                    item.Entity.AddedTime = DateTime.Now;
                    item.Entity.UpdatedTime = DateTime.Now;
                    item.Entity.AddedUser = 1;
                    item.Entity.UpdatedUser = 1;
                    item.Entity.Guid = Guid.NewGuid();
                    item.Entity.AddedIPV4Adress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    item.Entity.UpdatedIPV4Adress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

                    if (item.Entity.IsActive==null)
                    {
                        item.Entity.IsActive = true;
                    }
                    item.Entity.IsDeleted = false;
                }

                else if (item.State==Microsoft.EntityFrameworkCore.EntityState.Modified)
                {
                    item.Entity.UpdatedTime = DateTime.Now;
                    item.Entity.UpdatedUser = 1;
                    item.Entity.UpdatedIPV4Adress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

                }
            }
           return await _shoppingContext.SaveChangesAsync();
        }
    }
}
