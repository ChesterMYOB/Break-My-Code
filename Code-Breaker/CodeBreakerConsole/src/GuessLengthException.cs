using System;
using System.Runtime.Serialization;

namespace CodeBreaker.UnitTests
{
    public class GuessLengthException : Exception
    {
        public GuessLengthException(string message) : base(message)
        {
        }
    }
}
