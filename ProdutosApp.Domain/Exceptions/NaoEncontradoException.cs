using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Exceptions
{
    /// <summary>
    /// Classe de exceção para indicar que um recurso não foi encontrado.
    /// </summary>
    public class NaoEncontradoException : Exception
    {
        public NaoEncontradoException(string entidade, Guid? id)
            : base($"O recurso {entidade} com o id {id} não foi encontrado.")
        {
        }

        public NaoEncontradoException(string mensagem)
            : base(mensagem)
        {
        }
    }
}
