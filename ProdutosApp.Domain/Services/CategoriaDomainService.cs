using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Interfaces.Repositories;
using ProdutosApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Services
{
    /// <summary>
    /// Classe de serviço de domínio para a entidade Categoria.
    /// </summary>
    internal class CategoriaDomainService (IUnitOfWork _unitOfWork) : ICategoriaDomainService
    {
        public async Task<List<Categoria>> ObterTodos()
        {
            return await _unitOfWork.CategoriaRepository.GetAllAsync();
        }
    }
}
