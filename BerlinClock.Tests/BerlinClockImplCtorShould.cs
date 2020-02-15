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
    }
}
