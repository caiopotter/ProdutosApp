using Microsoft.EntityFrameworkCore;
using ProdutosApp.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Infra.Data.Contexts
{
    /// <summary>
    /// Classe de contexto do Entity Framework Core para a aplicação ProdutosApp.
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        /// <summary>
        /// Método para adicionar as classes de mapeamento feitas no projeto
        /// 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
        }
    }
}
