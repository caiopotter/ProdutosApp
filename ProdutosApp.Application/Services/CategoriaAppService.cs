using ProdutosApp.Application.Dtos.Responses;
using ProdutosApp.Application.Interfaces;
using ProdutosApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Application.Services
{
    /// <summary>
    /// Classe de serviço de aplicação para a entidade Categoria.
    /// </summary>
    public class CategoriaAppService (ICategoriaDomainService _categoriaDomainService) : ICategoriaAppService
    {
        public async Task<List<CategoriaResponse>> ObterTodos()
        {
            var categorias = await _categoriaDomainService.ObterTodos();

            return categorias.Select(item => new CategoriaResponse
            {
                Id = item.Id,
                Nome = item.Nome
            }).ToList();
        }
       
    }
}
