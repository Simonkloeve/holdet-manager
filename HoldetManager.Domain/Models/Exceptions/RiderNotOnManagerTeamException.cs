using System;
namespace HoldetManager.Models.Exceptions
{
    public class TranferException : Exception
    {
        public TranferException(string message) : base(message)
        {
        }
    }
}
