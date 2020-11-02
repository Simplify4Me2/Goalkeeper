using GoalKeeper.MApi.Application;
using GoalKeeper.MApi.Application.IO;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace GoalKeeper.MApi.WebApi.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class IocConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddMediatR(typeof(IAmApplication), typeof(IAmApplicationIO), typeof(Startup));
        }
    }
}
