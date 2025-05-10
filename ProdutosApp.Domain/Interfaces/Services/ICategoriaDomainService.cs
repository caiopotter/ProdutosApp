using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface de serviço de domínio para a entidade Categoria.
    /// </summary>
    public interface ICategoriaDomainService
    {
        Task<List<Categoria>> ObterTodos();
    }
}
