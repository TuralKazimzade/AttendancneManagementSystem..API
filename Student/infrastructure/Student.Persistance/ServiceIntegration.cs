using AMS.Application.Repositories;
using AMS.Persistance.Contexts;
using AMS.Persistance.Interceptors;
using AMS.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Persistance
{
    public static class ServiceIntegration
    {
        public static void AddPersistanceService(this IServiceCollection services,
                                                    IConfiguration configuration )
        {
            var connectionstring = configuration.GetConnectionString("Database");
            services.AddDbContext<AMSContext>(options => options
                                                      .UseSqlServer(connectionstring)
                                                      .AddInterceptors(new UpdateBaseEntityInterceptor()));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
