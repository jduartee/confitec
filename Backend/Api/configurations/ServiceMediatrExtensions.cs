using Confitec.Application.Configuration.Behavior.Logging;
using Confitec.Application.Configuration.Behavior.Validation;
using Confitec.Validation;
using FluentValidation;
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
            const string applicationAssemblyName = "Confitec.Application";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            return services
                .AddMediatR(AppDomain.CurrentDomain.Load("Confitec.Application"))
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>))
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));
        }
    }
}
