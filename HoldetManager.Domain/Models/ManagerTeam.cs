using System;
using System.Collections.Generic;
using System.Linq;
using HoldetManager.Models.Exceptions;
using HoldetManager.Models.RuleEngine;

namespace HoldetManager.Models
{
    public class ManagerTeam
    {
        private readonly Rules _rules;

        private readonly Dictionary<long, Rider> _riders;

        public double AccountBalance { get; }

        public ManagerTeam()
        {
        }

        public void DoTransfer(ISet<Rider> outgoingRiders, ISet<Rider> incomingRiders)
        {
            var outgoingValue = 0.0;
            foreach(var rider in outgoingRiders)
            {
                if(!_riders.ContainsKey(rider.Id))
                {
                    throw new TranferException($"Rider {rider.FullName} {rider.Id} is was not found on the manager team");
                }

                outgoingValue += rider.Value;
            }


            var incomingValue = 0.0;
            foreach (var rider in incomingRiders)
            {
                if (_riders.ContainsKey(rider.Id))
                {
                    throw new TranferException($"Rider {rider.FullName} {rider.Id} is already on the manager team");
                }

                incomingValue += rider.Value;
            }


                        

        }

        public bool IsTransferAffordable(IEnumerable<Rider> outgoing, IEnumerable<Rider> incoming)
        {
            return AccountBalance + outgoing.Sum(r => r.Value) >= incoming.Sum(r => r.Value) * (1 + _rules.TransferFee);
        }
                
    }
}
