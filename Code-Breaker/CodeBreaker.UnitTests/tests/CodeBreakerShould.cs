using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace CodeBreaker.UnitTests.tests
{
    [TestFixture]
    public class CodeBreakerShould
    {
        [Test]
        public void ReturnAllBlack_WhenAllColoursAndPositionsAreCorrect()
        {
            var codeBreaker = new CodeBreaker();
            var mark = codeBreaker.CheckGuess(new List<string>(){"r", "g", "y", "c"});
            Assert.AreEqual("bbbb", mark);
        }
    }
}