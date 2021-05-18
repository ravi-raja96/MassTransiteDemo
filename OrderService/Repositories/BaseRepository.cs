using Microsoft.EntityFrameworkCore;
using OrderService.Context;
using OrderService.Repositories.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		private readonly OrderServiceDbContext _context;

		public BaseRepository(OrderServiceDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(T entity)
		{
			_context.Set<T>().Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entity = await _context.Set<T>().FindAsync(id);
			_context.Set<T>().Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<T> GetById(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<List<T>> GetListAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task UpdateAsync(T entity)
		{
			_context.Set<T>().Update(entity);
			await _context.SaveChangesAsync();
		}

		public IEnumerable<T> FindWithSpecificationPattern(ISpecification<T> specification = null)
		{
			IQueryable<T> data = _context.Set<T>().AsQueryable();

			return SpecificationEvaluator<T>.GetQuery(data, specification);
		}
	}
}
