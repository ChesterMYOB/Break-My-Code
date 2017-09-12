using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Assert = NUnit.Framework.Assert;

namespace CodeBreaker.UnitTests.tests
{
    [TestFixture]
    public class CodeBreakerShould
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
        public void CheckForCorrectGuess(string expected, Colour codeOne, Colour codeTwo, Colour codeThree, Colour codeFour)
        {
            var codeBreaker = new CodeBreaker();
            var mark = codeBreaker.CheckGuess(new List<Colour> { codeOne, codeTwo, codeThree, codeFour });
            Assert.AreEqual(expected, mark);
        }

        [Test]
        public void ThrowExceptionWhenGuessLengthDoesNotMatchCodeLength()
        {
            var codeBreaker = new CodeBreaker();
            var exception = Assert.Throws<GuessLengthException>(() => codeBreaker.CheckGuess(new List<Colour>{Colour.Red}));
            Assert.That(exception.Message, Is.EqualTo("Incorrect guess length!"));
        }


        [Test]
        public void ReturnMarkWhenCodeBreakerHasDuplicateColours()
        {
            var codeBreaker = new CodeBreaker(Colour.Green, Colour.Green, Colour.Cyan, Colour.Cyan);
            var mark = codeBreaker.CheckGuess(new List<Colour> { Colour.Green, Colour.Cyan, Colour.White, Colour.White });
            Assert.AreEqual("bw", mark);
        }

    }
}