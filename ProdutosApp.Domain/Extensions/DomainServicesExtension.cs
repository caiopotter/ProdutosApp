using Microsoft.Extensions.DependencyInjection;
using ProdutosApp.Domain.Interfaces.Services;
using ProdutosApp.Domain.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Extensions
{
    public static class DomainServicesExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaDomainService, CategoriaDomainService>();
            services.AddScoped<IProdutoDomainService, ProdutoDomainService>();
            return services;
        }
    }
}
