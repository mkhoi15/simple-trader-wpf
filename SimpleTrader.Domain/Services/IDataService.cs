using System.Linq.Expressions;

namespace SimpleTrader.Domain.Services
{
	public interface IDataService<T>
	{
		Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
		Task<T> Get(int id, params Expression<Func<T, object>>[] includeProperties);
		Task<T> Create(T entity);
		Task<T> Update(int id, T entity);
		Task<bool> Delete(int id);
	}
}
