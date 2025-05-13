using Microsoft.EntityFrameworkCore;
using ProdutosApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Infra.Data.Tests.Contexts
{
    /// <summary>
    /// Classe de contexto e preparação dos teste.
    /// </summary>
    public class TestContext
    {
        public static DataContext CreateDataContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "ProdutosAppTeste")
                .Options;
            
            return new DataContext(options);
        }
    }
}
