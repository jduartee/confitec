﻿using Confitec.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Bootstrapper
    {
        public static IServiceCollection UseConfitectDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
