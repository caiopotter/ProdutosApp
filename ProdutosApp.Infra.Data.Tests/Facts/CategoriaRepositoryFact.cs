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
    /// Classe de teste para o repositório de categorias.
    /// </summary>
    public class CategoriaRepositoryFact
    {
        private readonly Faker<Categoria> _fakerCategoria;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriaRepositoryFact()
        {
            _unitOfWork = new UnitOfWork(TestContext.CreateDataContext());
            _fakerCategoria = new Faker<Categoria>("pt_BR")
                .RuleFor(c => c.Id, f => f.Random.Guid())
                .RuleFor(c => c.Nome, f => f.Commerce.Categories(1).FirstOrDefault())
                .RuleFor(c => c.Ativo, true);
        }

        [Fact(DisplayName = "Adicionar categoria com sucesso no banco de dados.")]
        public async Task AdicionarCategoriaComSucesso()
        {
            var categoria = _fakerCategoria.Generate();

            await _unitOfWork.CategoriaRepository.AddAsync(categoria);

            var categoriaAdicionada = await _unitOfWork.CategoriaRepository.GetByIdAsync(categoria.Id);
            Assert.NotNull(categoriaAdicionada);

            categoriaAdicionada.Id.Should().Be(categoria.Id);
            categoriaAdicionada.Nome.Should().Be(categoria.Nome);
        }

        [Fact(DisplayName = "Atualizar categoria com sucesso no banco de dados.")]
        public async Task AtualizarCategoriaComSucesso()
        {
            var categoria = _fakerCategoria.Generate();
            await _unitOfWork.CategoriaRepository.AddAsync(categoria);
            await _unitOfWork.SaveChancesAsync();

            categoria.Nome = "Novo Nome";
            await _unitOfWork.CategoriaRepository.UpdateAsync(categoria);
            await _unitOfWork.SaveChancesAsync();

            var categoriaAtualizada = await _unitOfWork.CategoriaRepository.GetByIdAsync(categoria.Id);
            Assert.NotNull(categoriaAtualizada);
            categoriaAtualizada.Nome.Should().Be("Novo Nome");
            categoriaAtualizada.Id.Should().Be(categoria.Id);
        }

        [Fact(DisplayName = "Excluir categoria com sucesso no banco de dados.")]
        public async Task ExcluirCategoriaComSucesso()
        {
            var categoria = _fakerCategoria.Generate();
            await _unitOfWork.CategoriaRepository.AddAsync(categoria);
            await _unitOfWork.SaveChancesAsync();

            await _unitOfWork.CategoriaRepository.DeleteAsync(categoria);
            await _unitOfWork.SaveChancesAsync();
            var categoriaRemovida = await _unitOfWork.CategoriaRepository.GetByIdAsync(categoria.Id);

            categoriaRemovida.Should().BeNull();
            Assert.Null(categoriaRemovida);
        }

        [Fact(DisplayName = "Consultar categorias com sucesso no banco de dados.")]
        public async Task ConsultarCategoriasComSucesso()
        {
            var categorias = _fakerCategoria.Generate(5);
            foreach (var categoria in categorias)
            {
                await _unitOfWork.CategoriaRepository.AddAsync(categoria);
                await _unitOfWork.SaveChancesAsync();
            }

            var categoriasNoBanco = await _unitOfWork.CategoriaRepository.GetAllAsync();
            Assert.NotNull(categoriasNoBanco);
            categoriasNoBanco.Should().NotBeNull();
            categoriasNoBanco.Should().HaveCountGreaterThanOrEqualTo(5);
        }

        [Fact(DisplayName = "Obter categoria por Id com sucesso no banco de dados.")]
        public async Task ObterCategoriaPorIdComSucesso()
        {
            var categoria = _fakerCategoria.Generate();
            await _unitOfWork.CategoriaRepository.AddAsync(categoria);
            await _unitOfWork.SaveChancesAsync();

            var categoriaEncontrada = await _unitOfWork.CategoriaRepository.GetByIdAsync(categoria.Id);
            Assert.NotNull(categoriaEncontrada);
            categoriaEncontrada.Id.Should().Be(categoria.Id);
            categoriaEncontrada.Nome.Should().Be(categoria.Nome);
        }
    }
}
