using Bogus;
using FluentAssertions;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Interfaces.Repositories;
using ProdutosApp.Infra.Data.Repositories;
using ProdutosApp.Infra.Data.Tests.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Infra.Data.Tests.Facts
{
    /// <summary>
    /// Classe de teste para o repositório de produtos.
    /// </summary>
    public class ProdutoRepositoryFact
    {
        private readonly Faker<Produto> _fakerProduto;
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoRepositoryFact()
        {
            _unitOfWork = new UnitOfWork(TestContext.CreateDataContext());
            _fakerProduto = new Faker<Produto>("pt_BR")
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.Nome, f => f.Commerce.Product())
                .RuleFor(p => p.Preco, f => f.Random.Decimal(1, 100))
                .RuleFor(p => p.Quantidade, f => f.Random.Int(1, 100))
                .RuleFor(p => p.DataHoraCriacao, f => f.Date.Recent(10))
                .RuleFor(p => p.CategoriaId, f => f.Random.Guid())
                .RuleFor(p => p.Ativo, true);
        }

        [Fact(DisplayName = "Adicionar produto com sucesso no banco de dados.")]
        public async Task AdicionarProdutoComSucesso()
        {
            var produto = _fakerProduto.Generate();

            await _unitOfWork.ProdutoRepository.AddAsync(produto);

            var produtoAdicionado = await _unitOfWork.ProdutoRepository.GetByIdAsync(produto.Id);
            Assert.NotNull(produtoAdicionado);

            produtoAdicionado.Id.Should().Be(produto.Id);
            produtoAdicionado.Nome.Should().Be(produto.Nome);
            produtoAdicionado.Preco.Should().Be(produto.Preco);
            produtoAdicionado.Quantidade.Should().Be(produto.Quantidade);
            produtoAdicionado.DataHoraCriacao.Should().Be(produto.DataHoraCriacao);
            produtoAdicionado.CategoriaId.Should().Be(produto.CategoriaId);
        }

        [Fact(DisplayName = "Atualizar produto com sucesso no banco de dados.")]
        public async Task AtualizarProdutoComSucesso()
        {
            var produto = _fakerProduto.Generate();
            await _unitOfWork.ProdutoRepository.AddAsync(produto);
            await _unitOfWork.SaveChancesAsync();

            produto.Nome = "Novo Nome";
            await _unitOfWork.ProdutoRepository.UpdateAsync(produto);
            await _unitOfWork.SaveChancesAsync();

            var produtoAtualizada = await _unitOfWork.ProdutoRepository.GetByIdAsync(produto.Id);
            Assert.NotNull(produtoAtualizada);
            produtoAtualizada.Nome.Should().Be("Novo Nome");
            produtoAtualizada.Id.Should().Be(produto.Id);
            produtoAtualizada.Preco.Should().Be(produto.Preco);
            produtoAtualizada.Quantidade.Should().Be(produto.Quantidade);
            produtoAtualizada.DataHoraCriacao.Should().Be(produto.DataHoraCriacao);
            produtoAtualizada.CategoriaId.Should().Be(produto.CategoriaId);
        }

        [Fact(DisplayName = "Excluir produto com sucesso no banco de dados.")]
        public async Task ExcluirProdutoComSucesso()
        {
            var produto = _fakerProduto.Generate();
            await _unitOfWork.ProdutoRepository.AddAsync(produto);
            await _unitOfWork.SaveChancesAsync();

            await _unitOfWork.ProdutoRepository.DeleteAsync(produto);
            await _unitOfWork.SaveChancesAsync();
            var produtoRemovido = await _unitOfWork.ProdutoRepository.GetByIdAsync(produto.Id);

            produtoRemovido.Should().BeNull();
            Assert.Null(produtoRemovido);
        }

        [Fact(DisplayName = "Consultar produtos com sucesso no banco de dados.")]
        public async Task ConsultarProdutosComSucesso()
        {
            var produtos = _fakerProduto.Generate(5);
            foreach (var produto in produtos)
            {
                await _unitOfWork.ProdutoRepository.AddAsync(produto);
                await _unitOfWork.SaveChancesAsync();
            }

            var produtosNoBanco = await _unitOfWork.ProdutoRepository.GetAllAsync();
            Assert.NotNull(produtosNoBanco);
            produtosNoBanco.Should().NotBeNull();
            produtosNoBanco.Should().HaveCountGreaterThanOrEqualTo(5);
        }

        [Fact(DisplayName = "Obter produto por Id com sucesso no banco de dados.")]
        public async Task ObterProdutoPorIdComSucesso()
        {
            var produto = _fakerProduto.Generate();
            await _unitOfWork.ProdutoRepository.AddAsync(produto);
            await _unitOfWork.SaveChancesAsync();

            var produtoEncontrado = await _unitOfWork.ProdutoRepository.GetByIdAsync(produto.Id);
            Assert.NotNull(produtoEncontrado);
            produtoEncontrado.Id.Should().Be(produto.Id);
            produtoEncontrado.Nome.Should().Be(produto.Nome);
            produtoEncontrado.Preco.Should().Be(produto.Preco);
            produtoEncontrado.Quantidade.Should().Be(produto.Quantidade);
            produtoEncontrado.DataHoraCriacao.Should().Be(produto.DataHoraCriacao);
            produtoEncontrado.CategoriaId.Should().Be(produto.CategoriaId);
        }
    }
}
