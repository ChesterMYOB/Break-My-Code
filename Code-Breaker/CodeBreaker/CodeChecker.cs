using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBreaker
{
    public class CodeChecker
    {

        public string CheckGuess(List<Colour> code, List<Colour> guess)
        {
            if (guess.Count != code.Count)
            {
                throw new ArgumentException("Guess must be the same length as the code");
            }

            var blackMarks = CheckGuessForColourInCorrectPosition(code, guess);
            var whiteMarks = CheckGuessForCorrectColourInWrongPosition(code, guess);
            return blackMarks + whiteMarks;
        }

        public string CheckGuessForColourInCorrectPosition(List<Colour> code, List<Colour> guess)
        {
            var mark = "";
            for (var position = 0; position < code.Count; position++)
            {
                if (isMatchingColour(code[position], guess[position]))
                {
                    mark += Mark.Black.AsString();
                }
            }
            return mark;
        }

        public string CheckGuessForCorrectColourInWrongPosition(List<Colour> code, List<Colour> guess)
        {
            var mark = "";
            for (var position = 0; position < code.Count; position++)
            {
                if (code.Contains(guess[position]) && !isMatchingColour(code[position], guess[position]))
                {
                    mark += Mark.White.AsString();
                }
            }
            return mark;
        }

        private bool isMatchingColour(Colour colourOne, Colour colourTwo)
        {
            return colourOne.Equals(colourTwo);
        }
    }
}
