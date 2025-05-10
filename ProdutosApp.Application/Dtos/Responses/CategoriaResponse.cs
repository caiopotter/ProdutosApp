using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Application.Dtos.Responses
{
    /// <summary>
    /// Classe de resposta para a entidade Categoria.
    /// </summary>
    public class CategoriaResponse
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }

    }
}
