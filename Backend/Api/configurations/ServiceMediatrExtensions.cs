using Confitec.Application.Configuration.Behavior.Logging;
using Confitec.Application.Configuration.Behavior.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.Api.configurations
{
    public static class ServiceMediatrExtensions
    {
        public static IServiceCollection ConfigurarMeriatrHandlers(this IServiceCollection services)
        {
            return services
                .AddMediatR(AppDomain.CurrentDomain.Load("Confitec.Application"))
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>))
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        }
    }
}
