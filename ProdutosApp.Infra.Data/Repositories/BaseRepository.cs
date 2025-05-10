using Microsoft.EntityFrameworkCore;
using ProdutosApp.Domain.Interfaces.Repositories;
using ProdutosApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Infra.Data.Repositories
{
    /// <summary>
    /// Implementação do repositório genérico.
    /// </summary>
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class
    {

        protected readonly DataContext _dataContext;

        protected BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual async Task AddAsync(TEntity obj)
        {
            await _dataContext.Set<TEntity>().AddAsync(obj);
        }

        public virtual async Task DeleteAsync(TEntity obj)
        {
            await Task.FromResult(_dataContext.Set<TEntity>().Remove(obj));
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _dataContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await _dataContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task UpdateAsync(TEntity obj)
        {
            await Task.FromResult(_dataContext.Set<TEntity>().Update(obj));
        }
    }
}
