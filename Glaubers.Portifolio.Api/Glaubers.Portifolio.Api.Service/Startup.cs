using MediatR;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Glaubers.Portifolio.Api.Infra.Context;
using Glaubers.Portifolio.Api.Configuration;
using Microsoft.Extensions.Configuration;
using Glaubers.Portifolio.Api.Extensions.Config;
using Glaubers.Portifolio.Api.Repository.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Glaubers.Portifolio.Api.Service
{
    public class Startup
    {
        public IConfigurationRoot configuration { get; }
        public Startup(IHostEnvironment env)
        {
            configuration = configuration.ApplyConfig(env).Build();

            //Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

            //Log.Logger = new LoggerConfiguration()
            //    //.WriteTo.Http("https://localhost:44383/v1.0/log-events", httpClient: new CustomHttpClient())
            //    .CreateLogger()
            //    .ForContext<Program>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Auto mapper
            services.ConfigureAutoMapper();

            // Database
            services.ConfigureSql<ApiContext>(configuration);

            // Dependency Injection
            services.Inject();

            // MediatR
            //services.AddMediatR(typeof(Startup));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API DO TCC", Version = "V1" });
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API DO TCC"));
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
