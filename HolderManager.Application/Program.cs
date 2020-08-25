using System;
using HoldetManager.Abstractions.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace HolderManager.Application
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .ConfigureServices()
            .BuildServiceProvider();

            var getDataQuery = serviceProvider.GetRequiredService<IGetRidersAndTeamsQuery>();

            var (riders, teams) = await getDataQuery.GetAsync();

        }


    }
}
