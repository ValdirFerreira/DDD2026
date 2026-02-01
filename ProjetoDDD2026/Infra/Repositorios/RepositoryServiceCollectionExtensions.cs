using Domain.Interfaces;
using Domain.InterfacesServicos;
using Domain.Servicos;
using Infra.Repositorios.Genericos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositorios
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddEfRepositories(this IServiceCollection services)
        {
            // Repositórios específicos
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IPesquisaRepository, PesquisaRepository>();
            services.AddScoped<IPerguntaRepository, PerguntaRepository>();
            services.AddScoped<IOpcaoRepository, OpcaoRepository>();

            services.AddScoped<IRespostaRepository, RespostaRepository>();            
            services.AddScoped<IOpcaoRespostaRepository, OpcaoRespostaRepository>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Services
            services.AddScoped<IRespostaServico, RespostaServico>();
            services.AddScoped<IPerguntaServico, PerguntaServico>();

            return services;
        }
    }
}
