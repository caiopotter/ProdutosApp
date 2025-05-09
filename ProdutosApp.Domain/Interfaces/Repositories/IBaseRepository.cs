using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface base para repositórios de entidades.
    /// </summary>
    public interface IBaseRepository<TEntity, TKey> where TEntity: class
    {
        Task AddAsync(TEntity obj);
        Task UpdateAsync(TEntity obj);
        Task DeleteAsync(TEntity obj);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TKey id);

    }
}
