using OrderService.Repositories.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Repositories
{
	public interface IBaseRepository<T> where T : class
	{
		Task<List<T>> GetListAsync();
		Task<T> GetById(int id);
		Task AddAsync(T entity);
		Task DeleteAsync(int id);
		Task UpdateAsync(T entity);
		IEnumerable<T> FindWithSpecificationPattern(ISpecification<T> specification = null);
	}
}
