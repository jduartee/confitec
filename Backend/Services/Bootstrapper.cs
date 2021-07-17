using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Confitec.Services
{
    public static class Bootstrapper
    {
        public static IServiceCollection UsarServicesHandlers(this IServiceCollection services)
        {
            return services.AddMediatR(typeof(Bootstrapper).Assembly);
        }
    }
}
