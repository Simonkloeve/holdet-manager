using System.Collections.Generic;
using Newtonsoft.Json;
using HoldetManager.Models;
using System.Linq;

namespace HoldetManager.Infrastructure.Models
{
    public class RidersAndTeamsBaseInput
    {
        [JsonProperty("teams")]
        public List<Team> Teams { get; set; }

        [JsonProperty("players")]
        public List<Player> Players { get; set; }

        [JsonProperty("persons")]
        public List<Person> Persons { get; set; }

        public IEnumerable<Rider> GetRidersAsDomainModel()
        {
            var personsById = Persons.ToDictionary(p => p.Id);

            foreach(var player in Players)
            {
                var person = personsById[player.Person.Id];

                yield return new Rider(player.Id, person.Firstname, person.Lastname, player.Team.Id);
            }
        }
    }
        
    public class Team
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("eliminated")]
        public bool Eliminated { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        public static explicit operator HoldetManager.Models.Team(Team t)
        {
            return new HoldetManager.Models.Team(t.Id, t.Name);
        }

    }

    public class PersonId
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public class TeamId
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }

   
    public class Player
    {
        [JsonProperty("person")]
        public PersonId Person { get; set; }

        [JsonProperty("team")]
        public TeamId Team { get; set; }
              

        [JsonProperty("eliminated")]
        public bool Eliminated { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public class Person
    {
        
        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

     }
    
}
