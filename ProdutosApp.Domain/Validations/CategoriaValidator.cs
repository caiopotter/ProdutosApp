using FluentValidation;
using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Validations
{
    /// <summary>
    /// Classe de validação de entidade de domínio para Categoria.
    /// </summary>
    internal class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(c => c.Id)
            .NotNull().WithMessage("O Id da categoria não pode ser nulo.")
            .NotEqual(Guid.Empty).WithMessage("O Id da categoria não pode ser vazio.");
           
            RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("O nome da categoria não pode ser vazio.")
            .Length(3, 50).WithMessage("O nome da categoria deve ter entre 3 e 50 caracteres.");
 }

    }

}
