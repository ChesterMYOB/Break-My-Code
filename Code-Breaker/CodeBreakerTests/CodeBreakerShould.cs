using System;
using System.Collections.Generic;
using System.Collections;
using NUnit.Framework;
using CodeBreaker;
using Assert = NUnit.Framework.Assert;

namespace CodeBreakerTests
{
    [TestFixture]
    public class CodeBreakerShould
    {
        private CodeChecker _codeChecker;

        [SetUp]
        public void SetUp()
        {
            _codeChecker = new CodeChecker();
        }

        [TestCaseSource(typeof(CodeBreakerTestData), "CorrectPositionAndColourCases")]
        [Test]
        public string ReturnBlackMarkForMatchingColourAndPosition(string code, string guess)
        {
            var codeColours = MakeColourList(code);
            var guessColours = MakeColourList(guess);

            return _codeChecker.CheckGuessForColourInCorrectPosition(codeColours, guessColours);
        }

        [TestCaseSource(typeof(CodeBreakerTestData), "CorrectColourButWrongPositionCases")]
        [Test]
        public string ReturnWhiteMarkForCorrectColourButWrongPosition(string code, string guess)
        {
            var codeColours = MakeColourList(code);
            var guessColours = MakeColourList(guess);

            return _codeChecker.CheckGuessForCorrectColourInWrongPosition(codeColours, guessColours);
        }

        [TestCaseSource(typeof(CodeBreakerTestData), "MixedCases")]
        [Test]
        public string ReturnBlackAndWhiteMark(string code, string guess)
        {
            var codeColours = MakeColourList(code);
            var guessColours = MakeColourList(guess);

            return _codeChecker.CheckGuess(codeColours, guessColours);
        }

        [Test]
        public void ThrowExceptionIfCodeAndGuessLengthDoNotMatch()
        {
            var codeColours = MakeColourList("rgyc");
            var guessColours = MakeColourList("rgy");

            Assert.Throws<ArgumentException>(() => _codeChecker.CheckGuess(codeColours, guessColours));
        }

        private static List<Colour> MakeColourList(string colours)
        {
            var colourList = new List<Colour>();
            foreach (char colour in colours)
            {
                colourList.Add((Colour)colour);
            }
            return colourList;
        }
    }

    public class CodeBreakerTestData
    {
        public static IEnumerable CorrectPositionAndColourCases
        {
            get
            {
                yield return new TestCaseData("rgyc", "rgyc").Returns("bbbb");
                yield return new TestCaseData("rgyc", "wgyc").Returns("bbb");
                yield return new TestCaseData("rgyc", "wwyc").Returns("bb");
                yield return new TestCaseData("rgyc", "wwwc").Returns("b");
            }
        }

        public static IEnumerable CorrectColourButWrongPositionCases
        {
            get
            {
                yield return new TestCaseData("rgyc", "crgy").Returns("wwww");
                yield return new TestCaseData("rgyc", "wcgy").Returns("www");
                yield return new TestCaseData("rgyc", "wwcy").Returns("ww");
                yield return new TestCaseData("rgyc", "wwwr").Returns("w");
            }
        }

        public static IEnumerable MixedCases
        {
            get
            {
                yield return new TestCaseData("rgyc", "rcyg").Returns("bbww");
                yield return new TestCaseData("rgyc", "wryc").Returns("bbw");
                yield return new TestCaseData("rygc", "rcyg").Returns("bwww");
                yield return new TestCaseData("rgyc", "rygw").Returns("bww");
                yield return new TestCaseData("rgyc", "ryww").Returns("bw");
            }
        }
    }
}
