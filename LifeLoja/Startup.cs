using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLoja.DatabaseSettings;
using LifeLoja.GcpServices;
using LifeLoja.RabbitServices;
using LifeLoja.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace LifeLoja
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ProdutoStoreDatabaseSettings>(
      Configuration.GetSection(nameof(ProdutoStoreDatabaseSettings)));

            services.AddSingleton<IProdutoStoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ProdutoStoreDatabaseSettings>>().Value);

            services.AddSingleton<IProdutosService,ProdutosService>();
            services.AddSingleton<IPubSubRepositorio, PubSubRepositorio>();
            services.AddSingleton<IRabbitServices, ServicesRabbitRepositorio>();



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LifeLoja", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LifeLoja v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
