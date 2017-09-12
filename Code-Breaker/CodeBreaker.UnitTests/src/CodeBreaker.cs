using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodeBreaker.UnitTests
{
    public class CodeBreaker
    {
        private readonly List<Colour> _code;

        public CodeBreaker()
        {
            _code = new List<Colour>
            {
                Colour.Red,
                Colour.Green,
                Colour.Yellow,
                Colour.Cyan
            };
        }

        public CodeBreaker(Colour codeOne, Colour codeTwo, Colour codeThree, Colour codeFour)
        {
            _code = new List<Colour> { codeOne, codeTwo, codeThree, codeFour};
        }

        public CodeBreaker(List<Colour> code)
        {
            _code = code;
        }

        public string CheckGuess(List<Colour> guess)
        {
            if (guess.Contains(Colour.Empty))
                throw new ArgumentException("Cannot have an empty colour in guess");

            if (guess.Count != _code.Count)         
                throw new GuessLengthException("Incorrect guess length!");
            

            var mark = "";

            for (int i = 0; i < guess.Count; i++)
            {
                if (guess[i].Equals(_code[i]))
                {
                    mark = Peg.Black.ToFriendlyString() + mark;
                    _code[i] = Colour.Empty;
                }
                else
                {
                    if (_code.Contains(guess[i]))
                    {
                        mark += Peg.White.ToFriendlyString();
                    }
                }
            }
            return mark;
        }
    }
}
