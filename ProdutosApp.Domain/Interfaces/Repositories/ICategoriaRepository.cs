using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface de repositório para a entidade Categoria.
    /// </summary>
    public interface ICategoriaRepository: IBaseRepository<Categoria, Guid?>
    {
    }
}
