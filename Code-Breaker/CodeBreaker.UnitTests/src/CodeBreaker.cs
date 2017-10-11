using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBreaker.UnitTests
{
    public class CodeBreaker
    {
        private List<Colour> _code;
        private List<Colour> _restoreCode;
        private List<Colour> _guess;


        public CodeBreaker()
        {
            _code = new List<Colour> { Colour.Red, Colour.Green, Colour.Yellow, Colour.Cyan };
        }

        public CodeBreaker(List<Colour> code)
        {
            _code = code;
        }

        public void ResetCode(List<Colour> code)
        {
            _code = code;
        }

        public string CheckGuess(List<Colour> guess)
        {
            if (guess.Contains(Colour.Empty))
                throw new ArgumentException("Cannot have an empty colour in guess");

            if (guess.Count != _code.Count)
                throw new ArgumentException("Guess length does not match code length");

            _guess = guess.ToList();

            _restoreCode = _code.ToList();
            var mark = GetMark();
            _code = _restoreCode;

            return mark;
        }

        private string GetMark()
        {
            var blackMarks = CheckMatchingColourAndPosition();
            var whiteMarks = CheckOnlyMatchingColour();
            return blackMarks + whiteMarks;
        }

        private string CheckMatchingColourAndPosition()
        {
            var marks = "";
            for (var position = _code.Count - 1; position >= 0; position--)
            {
                if (_guess[position].Equals(_code[position]))
                {
                    marks += AddBlackMark();
                    _code.Remove(_code[position]);
                    _guess.Remove(_guess[position]);
                }
            }
            return marks;
        }
        private string CheckOnlyMatchingColour()
        {
            var marks = "";
            foreach (var c in _guess)
            {
                if (_code.Contains(c))  marks += AddWhiteMark();
            }
            return marks;
        }

        private static string AddBlackMark()
        {      
            return Peg.Black.ToPegString();
        }

        private static string AddWhiteMark()
        {
            return Peg.White.ToPegString();
        }
    }
}
