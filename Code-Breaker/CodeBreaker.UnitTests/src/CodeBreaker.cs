using System.Collections.Generic;
using System.Linq;
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

        public CodeBreaker(string codeOne, string codeTwo, string codeThree, string codeFour)
        {
            _code = new List<string>{ codeOne, codeTwo, codeThree, codeFour};
        }

        public CodeBreaker(List<string> code)
        {
            _code = code;
        }
        public string CheckGuess(List<string> guess)
        {
            if (guess.Count != _code.Count)
            {
                throw new GuessLengthException("Incorrect guess length!");
            }

            var mark = "";

            for (int i = 0; i < guess.Count; i++)
            {
                if (guess[i].Equals(_code[i]))
                {
                    mark = "b" + mark;
                    _code[i] = "";
                }
                else
                {
                    if (_code.Contains(guess[i]))
                    {
                        mark += "w";
                    }
                }
            }
            return mark;
        }
    }
}
