using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BerlinClock.Abstraction;

namespace BerlinClock.Tests
{
    [TestClass]
    public class TimeShould
    {
        [TestMethod]
        public void ReturnIncorrectTimeInFromInt32IfTimeInIntIsNegative()
        {
            // Arrange
            var negativeTimeInInt32 = -1;

            // Act
            Time actual = Time.FromInt32(negativeTimeInInt32);

            // Assert
            Assert.AreEqual(Time.Incorrect, actual);
        }

        [TestMethod]
        [DataRow(240001)]
        [DataRow(240100)]
        [DataRow(3423423)]
        [DataRow(29300)]
        [DataRow(200184)]
        public void ReturnIncorrectTimeInCtorIfTimeHasOverflows(Int32 time)
        {
            // Arrange
            Int32 hours = time / 10000;
            Int32 minutes = time / 100 % 100;
            Int32 seconds = time % 100;

            // Act
            Time actual = new Time(hours, minutes, seconds);

            // Assert
            Assert.AreEqual(Time.Incorrect, actual);
        }


        [TestMethod]
        public void ParseMidnightProperly()
        {
            // Arrange
            var midnightInInt32 = 240000;

            // Act
            Time actual = Time.FromInt32(midnightInInt32);

            // Assert
            Assert.AreEqual(24, actual.Hours);
            Assert.AreEqual(0, actual.Minutes);
            Assert.AreEqual(0, actual.Seconds);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(235959)]
        [DataRow(123456)]
        [DataRow(201854)]
        [DataRow(2543)]
        public void ReturnParsedTimrIfTimeIsCorrect(Int32 time)
        {
            // Arrange
            Int32 hours = time / 10000;
            Int32 minutes = time / 100 % 100;
            Int32 seconds = time % 100;

            // Act
            Time actual = new Time(hours, minutes, seconds);

            // Assert
            Assert.AreEqual(hours, actual.Hours);
            Assert.AreEqual(minutes, actual.Minutes);
            Assert.AreEqual(seconds, actual.Seconds);
        }
    }
}
