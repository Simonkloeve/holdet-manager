using System;
namespace HoldetManager.Models
{
    public class Team
    {
        public long Id { get; }

        public string Name { get; }

        public Team(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
