using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BerlinClock.Abstraction;
using BerlinClock.Classes;

namespace BerlinClock.Tests
{
    [TestClass]
    public class TimeParserShould
    {
        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("jksdhfksdhf")]
        [DataRow("12:00:00k")]
        [DataRow("25:00:00")]
        [DataRow("13:68:12")]
        [DataRow("07:15:99")]
        [DataRow("20/00/00")]
        public void ReturnIncorrectTimeIfParameterIsNullOrEmpty(String emptyTime)
        {
            // Arrange
            var timeParser = new TimeParser();

            // Act
            Time actual = timeParser.GetTimeFromString(emptyTime);

            // Assert
            Assert.AreEqual(actual, Time.Incorrect);
        }

        [TestMethod]
        public void ParseMidnightProperly()
        {
            // Arrange
            var timeParser = new TimeParser();

            // Act
            var actual = timeParser.GetTimeFromString("24:00:00");

            // Assert
            Assert.AreEqual(actual, new Time(24, 0, 0));
        }

        [TestMethod]
        [DataRow("00:00:00")]
        [DataRow("23:59:59")]
        [DataRow("01:23:45")]
        [DataRow("22:22:22")]
        [DataRow("13:49:33")]
        [DataRow("09:53:03")]
        [DataRow("01:10:01")]
        public void ParseCorrectTimeProperly(String correctTime)
        {
            // Arrange
            var timeParser = new TimeParser();
            DateTime parsedInputTime = DateTime.ParseExact(correctTime, "HH:mm:ss", CultureInfo.CurrentCulture);

            // Act
            Time actual = timeParser.GetTimeFromString(correctTime);

            // Assert
            Assert.AreEqual(actual, new Time(parsedInputTime.Hour, parsedInputTime.Minute, parsedInputTime.Second));
        }
    }
}
