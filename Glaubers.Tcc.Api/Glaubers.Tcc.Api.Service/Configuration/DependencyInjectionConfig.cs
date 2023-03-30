using System;
using Glaubers.Tcc.Api.Infra.Ioc;
using Glaubers.Tcc.Api.Infra.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Glaubers.Tcc.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void Inject(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Common Injector
            Bootstrap.Register(services);
            Bootstrap.Register<ApiContext>(services);
        }
    }
}
