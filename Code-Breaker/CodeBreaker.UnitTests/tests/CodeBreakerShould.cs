﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace CodeBreaker.UnitTests
{
    [TestFixture]
    public class CodeBerakerShould
    {
        private static readonly object[] CheckForCorrectGuessCases =
        {
            new object[] {"", Colour.White, Colour.White, Colour.White, Colour.White},
            new object[] {"bbww", Colour.Red, Colour.Cyan, Colour.Yellow, Colour.Green},
            new object[] {"b", Colour.Red, Colour.Red, Colour.White, Colour.White},

            new object[] {"w", Colour.White, Colour.White, Colour.Red, Colour.White},
            new object[] {"b", Colour.Red, Colour.White, Colour.White, Colour.White},

            new object[] {"ww", Colour.Green, Colour.White, Colour.Cyan, Colour.White},
            new object[] {"bw", Colour.White, Colour.Red, Colour.White, Colour.Cyan},
            new object[] {"bb", Colour.White, Colour.Green, Colour.White, Colour.Cyan},

            new object[] {"www", Colour.White, Colour.Red, Colour.Green, Colour.Yellow},
            new object[] {"bww", Colour.White, Colour.Red, Colour.Green, Colour.Cyan},
            new object[] {"bbw", Colour.White, Colour.Red, Colour.Yellow, Colour.Cyan},
            new object[] {"bbb", Colour.White, Colour.Green, Colour.Yellow, Colour.Cyan},

            new object[] {"wwww", Colour.Cyan, Colour.Red, Colour.Green, Colour.Yellow},
            new object[] {"bwww", Colour.Yellow, Colour.Red, Colour.Green, Colour.Cyan},
            new object[] {"bbww", Colour.Red, Colour.Green, Colour.Cyan, Colour.Yellow},
            new object[] {"bbbb", Colour.Red, Colour.Green, Colour.Yellow, Colour.Cyan}
        };

        [Test, TestCaseSource(nameof(CheckForCorrectGuessCases))]
        [TestCaseSource(nameof(CheckForCorrectGuessCases))]
        public void CheckForCorrectGuess(string expected, Colour codeOne, Colour codeTwo, Colour codeThree, Colour codeFour)
        {
            var codeBreaker = new CodeBreaker();
            var mark = codeBreaker.CheckGuess(new List<Colour> { Colour.Red, Colour.Green, Colour.Yellow, Colour.Cyan }, new List<Colour> { codeOne, codeTwo, codeThree, codeFour });
            Assert.AreEqual(expected, mark);
        }

        private static readonly object[] CheckForCorrectGuessWithVariableGuessLengthCases =
        {
            new object[] {"bbbbb", new List<Colour> { Colour.Green, Colour.Green, Colour.Cyan, Colour.Cyan, Colour.Red }, new List<Colour> { Colour.Green, Colour.Green, Colour.Cyan, Colour.Cyan, Colour.Red }},
            new object[] {"bbb",  new List<Colour> { Colour.Green, Colour.Green, Colour.Cyan }, new List<Colour> { Colour.Green, Colour.Green, Colour.Cyan }},
            new object[] {"b",  new List<Colour> { Colour.Yellow, Colour.Yellow, Colour.Green, Colour.White }, new List<Colour> { Colour.Cyan, Colour.Yellow, Colour.Indigo, Colour.Red }},
            new object[] {"b", new List<Colour> { Colour.Cyan, Colour.Yellow, Colour.Indigo, Colour.Red }, new List<Colour> { Colour.Yellow, Colour.Yellow, Colour.Green, Colour.White } }
        };

        [Test, TestCaseSource(nameof(CheckForCorrectGuessWithVariableGuessLengthCases))]
        public void CheckForCorrectGuess_WithVariableGuessLengths(string expected, List<Colour> guess, List<Colour> code)
        {
            var codeBreaker = new CodeBreaker();
            var mark = codeBreaker.CheckGuess(code, guess);
            Assert.AreEqual(expected, mark);
        }

        [Test, TestCaseSource(nameof(CheckForCorrectGuessWithVariableGuessLengthCases))]
        public void CheckGuess_CanCheckTwice(string expected, List<Colour> guess, List<Colour> code)
        {
            var codeBreaker = new CodeBreaker();
            var mark = codeBreaker.CheckGuess(code, guess);
            Assert.AreEqual(expected, mark);
            mark = codeBreaker.CheckGuess(code, guess);
            Assert.AreEqual(expected, mark);
        }

        [Test]
        public void ThrowArgumentExceptionWithCorrectMessage_WhenGuessLengthDoesNotMatchCodeLength()
        {
            var codeBreaker = new CodeBreaker();
            var exception = Assert.Throws<ArgumentException>(() => codeBreaker.CheckGuess(new List<Colour> { Colour.Brown, Colour.Brown }, new List<Colour> { Colour.Red }));
            Assert.That(exception.Message, Is.EqualTo("Guess length does not match code length"));
        }
    }
}