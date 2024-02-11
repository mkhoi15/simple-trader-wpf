

using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System.Linq.Expressions;

namespace SimpleTrader.EntityFramework.Services
{
	public class GenericDataService<T> : IDataService<T> where T : IEntity
	{
		private readonly SimpleTraderDbContextFactory _contextFactory;

        public GenericDataService(SimpleTraderDbContextFactory simpleTraderDbContextFactory)
        {
            _contextFactory = simpleTraderDbContextFactory;
        }
        public async Task<T> Create(T entity)
		{
			using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
			{
				var createdEntity = context.Set<T>().Add(entity);
				await context.SaveChangesAsync();	
				return createdEntity.Entity;
			}
		}

		public async Task<bool> Delete(int id)
		{
			using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
			{
				T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
				context.Set<T>().Remove(entity);
				await context.SaveChangesAsync();

				return true;
			}
		}

		public async Task<T> Get(int id, params Expression<Func<T, object>>[] includeProperties)
		{
			using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
			{
				IQueryable<T> query = context.Set<T>();

				foreach (var includeProperty in includeProperties)
				{
					query = query.Include(includeProperty);
				}

				T entity = await query.FirstOrDefaultAsync(e => e.Id == id);
				return entity;
			}
		}

		public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties)
		{
			using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
			{
				IQueryable<T> query = context.Set<T>();

				foreach (var includeProperty in includeProperties)
				{
					query = query.Include(includeProperty);
				}

				IList<T> entities = await query.ToListAsync();
				return entities;
			}
		}

		public async Task<T> Update(int id, T entity)
		{
			using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
			{
				entity.Id = id;

				context.Set<T>().Update(entity);
				await context.SaveChangesAsync();
				
				return entity;	
			}
		}
	}
}
