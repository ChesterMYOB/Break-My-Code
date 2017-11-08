using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBreaker.UnitTests
{
    public class CodeBreaker
    {
        public string CheckGuess(List<Colour> code, List<Colour> guess)
        {
            if (guess.Count != code.Count)
                throw new ArgumentException("Guess length does not match code length");
            return GetMark(code.ToList(), guess.ToList());
        }

        private string GetMark(List<Colour> code, List<Colour> guess)
        {
            var blackMarks = CheckMatchingColourAndPosition(code, guess);
            var whiteMarks = CheckOnlyMatchingColour(code, guess);
            return blackMarks + whiteMarks;
        }

        private string CheckMatchingColourAndPosition(List<Colour> code, List<Colour> guess)
        {
            var marks = "";
            for (var position = code.Count - 1; position >= 0; position--)
            {
                if (guess[position].Equals(code[position]))
                {
                    marks += AddBlackMark();
                    code.Remove(code[position]);
                    guess.Remove(guess[position]);
                }
            }
            return marks;
        }
        private string CheckOnlyMatchingColour(List<Colour> code, List<Colour> guess)
        {
            var marks = "";
            foreach (var c in guess)
            {
                if (code.Contains(c))  marks += AddWhiteMark();
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
