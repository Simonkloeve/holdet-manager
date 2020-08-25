using System.Collections.Generic;
using System.Threading.Tasks;
using HoldetManager.Models;

namespace HoldetManager.Abstractions.Queries
{
    public interface IGetRidersAndTeamsQuery
    {
        Task<(IEnumerable<Rider> riders, IEnumerable<Team> teams)> GetAsync();
    }
}