using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("Livros/ParaLer", Logica.LivrosLogica.LivrosParaLer);
            builder.MapRoute("Livros/Lendo", Logica.LivrosLogica.LivrosLendo);
            builder.MapRoute("Livros/Lidos", Logica.LivrosLogica.LivrosLidos);
            builder.MapRoute("Livros/Detalhes/{id:int}", Logica.LivrosLogica.ExibeDetalhes);
            builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", Logica.CadastroLogica.NovoLivroParaLer);
            builder.MapRoute("Cadastro/NovoLivro", Logica.CadastroLogica.ExibeFormulario);
            builder.MapRoute("Cadastro/Incluir", Logica.CadastroLogica.ProcessaFormulario);
            var rotas = builder.Build();

            app.UseRouter(rotas);
        }

    }
}