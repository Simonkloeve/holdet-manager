using System;
using Microsoft.Extensions.DependencyInjection;
using HoldetManager.Abstractions.Queries;
using HoldetManager.Infrastructure.Queries;

namespace HolderManager.Application
{
    public static class DependebcyInjectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient("HoldetApi", c => { c.BaseAddress = new Uri("https://fs-api.swush.com"); });

            //Queries
            serviceCollection.AddScoped<IGetRidersAndTeamsQuery, GetRidersAndTeamsQuery>();

            return serviceCollection;
        }
    }
}
