using ProdutosApp.Application.Dtos.Requests;
using ProdutosApp.Application.Dtos.Responses;
using ProdutosApp.Application.Interfaces;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Application.Services
{
    /// <summary>
    /// Classe de serviço de aplicação para a entidade Produto.
    /// </summary>
    public class ProdutoAppService (IProdutoDomainService produtoDomainService): IProdutoAppService
    {
        public async Task<ProdutoResponse> Adicionar(ProdutoRequest request)
        {
            var produto = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Preco = request.Preco,
                CategoriaId = request.CategoriaId,
                Quantidade = request.Quantidade,
                Ativo = true,
                DataHoraCriacao = DateTime.Now
            };

            await produtoDomainService.Adicionar(produto);

            return Map(produto);
        }

        public async Task<ProdutoResponse> Atualizar(Guid? id, ProdutoRequest request)
        {
            var produto = new Produto
            {
                Id = id,
                Nome = request.Nome,
                Preco = request.Preco,
                CategoriaId = request.CategoriaId,
                Quantidade = request.Quantidade,
                DataHoraCriacao = DateTime.Now,
                Ativo = true
            };

            await produtoDomainService.Atualizar(produto);

            return Map(produto);
        }

        public async Task<ProdutoResponse> Inativar(Guid? id)
        {
            var produto = await produtoDomainService.Inativar(id);

            return Map(produto);
        }

        public async Task<ProdutoResponse?> ObterPorId(Guid? id)
        {
            var produto = await produtoDomainService.ObterPorId(id);

            if (produto != null)
            {
                return Map(produto);
            }

            return null;
        }

        public async Task<List<ProdutoResponse>> ObterTodos()
        {
            var produtos = await produtoDomainService.ObterTodos();

            var response = new List<ProdutoResponse>();
            foreach (var item in produtos)
            {
                response.Add(Map(item));
            }

            return response;
        }

        private ProdutoResponse Map(Produto produto)
        {
            return new ProdutoResponse
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade,
                CategoriaId = produto.CategoriaId
            };
        }
    }
}
