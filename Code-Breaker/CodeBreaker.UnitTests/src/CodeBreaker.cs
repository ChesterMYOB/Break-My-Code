using System;
using System.Collections.Generic;
using CodeBreaker.UnitTests.src;

namespace CodeBreaker.UnitTests
{
    public class CodeBreaker
    {
        private readonly List<Colour> _code;

        public CodeBreaker() {
            _code = new List<Colour> { Colour.Red, Colour.Green, Colour.Yellow, Colour.Cyan };
        }

        public CodeBreaker(List<Colour> code)
        {
            _code = code;
        }

        public CodeBreaker(params Colour[] codeColours)
        {
            var list = new List<Colour>();
            list.AddRange(codeColours);
            _code = list;
        }

        public string CheckGuess(List<Colour> guess)
        {
            if (guess.Contains(Colour.Empty))
                throw new ArgumentException("Cannot have an empty colour in guess");

            if (guess.Count != _code.Count)         
                throw new ArgumentException("Guess length does not match code length");
            
            var mark = "";

            for (int position = 0; position < guess.Count; position++)
            {
                if (guess[position].Equals(_code[position]))
                {
                    mark = Peg.Black.ToPegString() + mark;
                    _code[position] = Colour.Empty;
                }
                else
                {
                    if (_code.Contains(guess[position]))
                    {
                        mark += Peg.White.ToPegString();
                    }
                }
            }
            return mark;
        }
    }
}
