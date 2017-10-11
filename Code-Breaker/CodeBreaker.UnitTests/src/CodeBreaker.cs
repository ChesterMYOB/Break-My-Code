using System;
using System.Collections.Generic;

namespace CodeBreaker.UnitTests
{
    public class CodeBreaker
    {
        private List<Colour> _code;
        private List<Colour> _codeWithoutColourAndPositionMatches;
        private List<Colour> _guessWithoutColourAndPositionMatches;

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


            var mark = GetMark(guess);

            return mark;
        }

        private string GetMark(List<Colour> guess)
        {
            _codeWithoutColourAndPositionMatches = new List<Colour>();
            _guessWithoutColourAndPositionMatches = new List<Colour>();
            return CheckMatchingColourAndPosition(guess) + CheckOnlyMatchingColour();
        }

        private string CheckMatchingColourAndPosition(List<Colour> guess)
        {
            var marks = "";
            for (var position = 0; position < guess.Count; position++)
            {
                if (guess[position].Equals(_code[position]))
                {
                    marks += AddBlackMark();
                }
                else
                {
                    _codeWithoutColourAndPositionMatches.Add(_code[position]);
                    _guessWithoutColourAndPositionMatches.Add(guess[position]);
                }
            }
            return marks;
        }
        private string CheckOnlyMatchingColour()
        {
            var marks = "";
            foreach (var c in _guessWithoutColourAndPositionMatches)
            {
                if (_codeWithoutColourAndPositionMatches.Contains(c))
                {
                    marks += AddWhiteMark();
                }
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
