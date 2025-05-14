using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para o serviço de domínio de produtos.
    /// </summary>
    public interface IProdutoDomainService
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task<Produto> Inativar(Guid? id);
        Task<List<Produto>> ObterTodos();
        Task<Produto?> ObterPorId(Guid? id);
    }
}
