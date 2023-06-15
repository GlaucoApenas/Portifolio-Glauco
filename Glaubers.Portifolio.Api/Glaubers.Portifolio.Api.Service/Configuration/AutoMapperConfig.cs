using System;
using Glaubers.Portifolio.Api.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Glaubers.Portifolio.Api.Service
{
    public static class AutoMapperConfig
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Internal
            services.AddAutoMapper(typeof(DomainViewModelMapping), typeof(ViewModelDomainMapping));
        }
    }
}
