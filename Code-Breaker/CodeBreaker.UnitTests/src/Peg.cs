using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBreaker.UnitTests.src
{
    public enum Peg
    {
        Black = 'b',
        White = 'w'
    }

    public static class PegExtension
    {
        public static string ToPegString(this Peg peg)
        {
            switch (peg)
            {
                case Peg.Black:
                    return "b";
                case Peg.White:
                    return "w";
                default:
                    return "No Enum String Assigned!";
            }
        }
    }
}
