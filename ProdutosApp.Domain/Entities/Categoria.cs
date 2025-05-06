using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Entities
{
    /// <summary>
    /// Classe de modelo de entidade de domínio para Categoria.
    /// </summary>
    public class Categoria
    {
        #region Propriedades

        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public bool? Ativo { get; set; }

        #endregion

        #region Relacionamentos

        public ICollection<Produto>? Produtos { get; set; }

        #endregion
    }
}
