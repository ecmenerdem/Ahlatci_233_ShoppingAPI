using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Business.Abstract
{
    public interface IGenericService<T>
    {
        Task<T> GetAsync(Expression<Func<T, bool>> Filter, params string[] IncludeProperties);/*userRepository.GetAsync(q=>q.id==5,"orders.orderdetails.product.category")*/

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Filter = null, params string[] IncludeProperties);

        Task<T> AddAsync(T Entity);

        Task UpdateAsync(T Entity);

        Task RemoveAsync(T Entity);
    }
}
