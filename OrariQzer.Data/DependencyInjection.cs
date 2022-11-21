using Microsoft.Extensions.DependencyInjection;
using OrariQzer.ApplicationCore.Interfaces.Repository;
using OrariQzer.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrariQzer.Data.Repository;

namespace OrariQzer.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddScoped<IOrariRepository, OrariRepository>();
            services.AddScoped<IVotiRepository, VotiRepository>();
            return services;
        }
    }
}
