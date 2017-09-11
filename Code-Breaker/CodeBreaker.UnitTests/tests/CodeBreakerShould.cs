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
            new object[] {"", new List<string> {"w", "w", "w", "w"}},
            new object[] {"bbww", new List<string> {"r", "c", "y", "g"}},
            new object[] {"b", new List<string> {"r", "r", "w", "w"}},

            new object[] {"w", new List<string> {"w", "w", "r", "w"}},
            new object[] {"b", new List<string> {"r", "w", "w", "w"}},

            new object[] {"ww", new List<string> {"g", "w", "c", "w"}},
            new object[] {"bw", new List<string> {"w", "r", "w", "c"}},
            new object[] {"bb", new List<string> {"w", "g", "w", "c"}},

            new object[] {"www", new List<string> {"w", "r", "g", "y"}},
            new object[] {"bww", new List<string> {"w", "r", "g", "c"}},
            new object[] {"bbw", new List<string> {"w", "r", "y", "c"}},
            new object[] {"bbb", new List<string> {"w", "g", "y", "c"}},

            new object[] {"wwww", new List<string> {"c", "r", "g", "y"}},
            new object[] {"bwww", new List<string> {"y", "r", "g", "c"}},
            new object[] {"bbww", new List<string> {"r", "g", "c", "y"}},
            new object[] {"bbbb", new List<string>{"r", "g", "y", "c"}},
        };

        [Test, TestCaseSource(nameof(CheckForCorrectGuessCases))]
        public void CheckForCorrectGuess(string expected, List<string> guess)
        {
            var codeBreaker = new CodeBreaker();
            var mark = codeBreaker.CheckGuess(guess);
            Assert.AreEqual(expected, mark);
        }

        [Test]
        public void ThrowExceptionWhenGuessLengthDoesNotMatchCodeLength()
        {
            var codeBreaker = new CodeBreaker("a", "b", "c", "d");
            var exception = Assert.Throws<GuessLengthException>(() => codeBreaker.CheckGuess(new List<string>{"a"}));
            Assert.That(exception.Message, Is.EqualTo("Incorrect guess length!"));
        }
        
    }
}