using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProdutosApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Infra.Data.Extensions
{
    /// <summary>
    /// Classe de extensão para injeção de dependência do Entity Framework.
    /// </summary>
    public static class EntityFrameworkExtension
    {
        /// <summary>
        /// Método de extensão para registrar o Entity Framework no serviço de injeção de dependência.
        /// </summary>
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            // Adiciona o DataContext com a string de conexão do banco de dados
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ProdutosAppBD")));
            return services;
        }
    }
}
