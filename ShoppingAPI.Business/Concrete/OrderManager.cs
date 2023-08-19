using ShoppingAPI.Business.Abstract;
using ShoppingAPI.DAL.Abstract.DataManagement;
using ShoppingAPI.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IUnitOfWork _uow;

        public OrderManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Order> AddAsync(Order Entity)
        {
            await _uow.OrderRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Order>> GetAllAsync(Expression<Func<Order, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.OrderRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Order> GetAsync(Expression<Func<Order, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.OrderRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(Order Entity)
        {
            await _uow.OrderRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(Order Entity)
        {
            await _uow.OrderRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
