using System;
using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.Tests
{
    [TestClass]
    public class BerlinClockImplCtorShould
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [DataRow(null)]
        [DataRow("")]
        public void ThrowArgumentNullExceptionIfctorParameterIsNullOrEmpty(String emptyTime)
        {
            // Arrange, Act
            var clock = new BerlinClockImpl(emptyTime);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("jksdhfksdhf")]
        [DataRow("12:00:00k")]
        [DataRow("25:00:00")]
        [DataRow("25/00/00")]
        public void ThrowArgumentExceptionIfctorParameterCannotBeParsed(String incorrectTime)
        {
            var clock = new BerlinClockImpl(incorrectTime);
        }
    }
}
