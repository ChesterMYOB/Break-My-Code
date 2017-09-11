using System.Collections.Generic;
using NUnit.Framework;

namespace CodeBreaker.UnitTests
{
    public class CodeBreaker
    {
        private List<string> _code;

        public CodeBreaker()
        {
            _code = new List<string>
            {
                "r",
                "g",
                "y",
                "c"
            };
        }

        public CodeBreaker(List<string> code)
        {
            _code = code;
        }
        public string CheckGuess(List<string> guess)
        {
            var mark = "";

            for (int i = 0; i < guess.Count; i++)
            {
                if (guess[i].Equals(_code[i]))
                    mark += "b";
            }
            return mark;
        }
    }
}
