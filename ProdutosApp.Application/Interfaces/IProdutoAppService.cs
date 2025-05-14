using ProdutosApp.Application.Dtos.Requests;
using ProdutosApp.Application.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Application.Interfaces
{
    /// <summary>
    /// Interface de serviço de aplicação para a entidade Produto.
    /// </summary>
    public interface IProdutoAppService
    {
        Task<ProdutoResponse> Adicionar(ProdutoRequest request);
        Task<ProdutoResponse> Atualizar(Guid? id, ProdutoRequest request);
        Task<ProdutoResponse> Inativar(Guid? id);
        Task<List<ProdutoResponse>> ObterTodos();
        Task<ProdutoResponse?> ObterPorId(Guid? id);
    }
}
