using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HoldetManager.Abstractions.Queries;
using HoldetManager.Infrastructure.Models;
using HoldetManager.Models;
using Newtonsoft.Json;
using Team = HoldetManager.Models.Team;

namespace HoldetManager.Infrastructure.Queries
{
    public class GetRidersAndTeamsQuery : HoldetBaseQuery, IGetRidersAndTeamsQuery
    {
        public GetRidersAndTeamsQuery(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<(IEnumerable<Rider> riders, IEnumerable<Team> teams)> GetAsync()
        {
            using var httpClient = HttpClientFactory.CreateClient("HoldetApi");

            var response = await httpClient.GetAsync(new Uri("tournaments/381",UriKind.Relative));

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();

                var ridersAndTeams = JsonConvert.DeserializeObject<RidersAndTeamsBaseInput>(body);

                var riders = ridersAndTeams.GetRidersAsDomainModel().ToList();

                var teams = ridersAndTeams.Teams.Select(t => (Team)t).ToList();

                return (riders, teams);

            }

            throw new Exception("Failed loading riders and teams");
        }
    }
}
