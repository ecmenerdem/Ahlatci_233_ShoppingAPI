using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShoppingAPI.Entity.Base;

namespace ShoppingAPI.DAL.Abstract.DataManagement
{
    public interface IRepository<T>where T:AuditableEntity
    {
        /*user.orders.orderdetails.product.category*/
        Task<T> GetAsync(Expression<Func<T, bool>> Filter, params string[] IncludeProperties);/*userRepository.GetAsync(q=>q.id==5,"orders.orderdetails.product.category")*/

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Filter = null, params string[] IncludeProperties);

        Task<EntityEntry<T>>AddAsync(T Entity);

        Task UpdateAsync(T Entity);

        Task RemoveAsync(T Entity);
    }
}
