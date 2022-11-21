using Microsoft.Extensions.DependencyInjection;
using OrariQzer.ApplicationCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrariQzer.ApplicationCore.Services;

namespace OrariQzer.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddSingleton<IGoogleService,GoogleService>();
            return services;
        }
    }
}
