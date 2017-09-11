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
            new object[] {"bbbb", new List<string>{"r", "g", "y", "c"}},
            new object[] {"", new List<string> {"w", "w", "w", "w"}}
        };

        [Test, TestCaseSource(nameof(CheckForCorrectGuessCases))]
        public void CheckForCorrectGuess(string expected, List<string> guess)
        {
            var codeBreaker = new CodeBreaker();
            var mark = codeBreaker.CheckGuess(guess);
            Assert.AreEqual(expected, mark);
        }
        
    }
}