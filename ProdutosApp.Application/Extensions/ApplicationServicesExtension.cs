using Microsoft.Extensions.DependencyInjection;
using ProdutosApp.Application.Interfaces;
using ProdutosApp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Application.Extensions
{
    /// <summary>
    /// Classe de extensão para os serviços de aplicação.
    /// </summary>
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaAppService, CategoriaAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            return services;
        }
    }
}
