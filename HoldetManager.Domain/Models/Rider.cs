using System;
using System.Collections.Generic;

namespace HoldetManager.Models
{
    public class Rider
    {
        public long Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public long TeamId { get; }
        public IEnumerable<StageResult> Results { get; }
        public double Value { get; }

        public string FullName => $"{FirstName} {LastName}";

        public Rider()
        {
        }

        public Rider(long id, string firstName, string lastName, long teamId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            TeamId = teamId;
        }
    }
}
