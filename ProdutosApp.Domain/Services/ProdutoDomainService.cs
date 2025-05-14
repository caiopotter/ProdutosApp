using FluentValidation;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Exceptions;
using ProdutosApp.Domain.Interfaces.Repositories;
using ProdutosApp.Domain.Interfaces.Services;
using ProdutosApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Services
{
    public class ProdutoDomainService (IUnitOfWork unitOfWork) : IProdutoDomainService
    {
        public async Task Adicionar(Produto produto)
        {
            ValidarProduto(produto);
            await VerificarCategoria(produto.CategoriaId);

            await unitOfWork.ProdutoRepository.AddAsync(produto);
            await unitOfWork.SaveChancesAsync();
        }
        public async Task Atualizar(Produto produto)
        {
            var registro = await unitOfWork.ProdutoRepository.GetByIdAsync(produto.Id);
            if (registro == null)
            {
                throw new NaoEncontradoException(nameof(Produto), produto.Id);
            }

            ValidarProduto(produto);
            await VerificarCategoria(produto.CategoriaId);

            await unitOfWork.ProdutoRepository.UpdateAsync(produto);
            await unitOfWork.SaveChancesAsync();
        }

        public async Task<Produto> Inativar(Guid? id)
        {
            var produto = await unitOfWork.ProdutoRepository.GetByIdAsync(id);
            if (produto == null)
            {
                throw new NaoEncontradoException(nameof(Produto), id);
            }

            produto.Inativar();

            await unitOfWork.ProdutoRepository.UpdateAsync(produto);
            await unitOfWork.SaveChancesAsync();
            return produto;
        }
        public async Task<List<Produto>> ObterTodos()
        {
            return await unitOfWork.ProdutoRepository.GetAllAsync();
        }
        public async Task<Produto?> ObterPorId(Guid? id)
        {
            return await unitOfWork.ProdutoRepository.GetByIdAsync(id);
        }

        private void ValidarProduto(Produto produto)
        {
            var produtoValidator = new ProdutoValidator();
            var result = produtoValidator.Validate(produto);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }

        private async Task VerificarCategoria(Guid? categoriaId)
        {
            var categoria = await unitOfWork.CategoriaRepository.GetByIdAsync(categoriaId);
            if (categoria == null)
            {
                throw new NaoEncontradoException(nameof(Categoria), categoriaId);
            }
        }
    }
    
}
