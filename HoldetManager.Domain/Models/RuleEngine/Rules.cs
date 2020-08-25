using System;
namespace HoldetManager.Models.RuleEngine
{
    public class Rules
    {
        public Rules(double transferFee)
        {
            TransferFee = transferFee;
        }

        public double TransferFee { get; }
        
    }
}
