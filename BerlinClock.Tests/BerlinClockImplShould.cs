using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BerlinClock.Abstraction;
using BerlinClock.Classes;
using System.Globalization;

namespace BerlinClock.Tests
{
    [TestClass]
    public class BerlinClockImplShould
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))] // Assert
        public void CtorShouldThrowArgumentExceptionOnIncorrectTime()
        {
            // Arrange, Act
            var clock = new BerlinClockImpl(Time.Incorrect);
        }

        [TestMethod]
        public void CtorShouldCreateObjectOnCorrectTime()
        {
            // Arrange, Act
            var clock = new BerlinClockImpl(new Time(0, 0, 0));

            // Assert
            Assert.IsNotNull(clock);
            Assert.IsInstanceOfType(clock, typeof(BerlinClockImpl));
        }

        [TestMethod]
        [DataRow("00:00:00", true)]
        [DataRow("00:00:01", false)]
        [DataRow("23:59:58", true)]
        [DataRow("23:59:59", false)]
        public void BlinkerStatusShouldBeCorrect(String time, Boolean isBlinkerOn)
        {
            // Arrange
            DateTime parsedInputTime = DateTime.ParseExact(time, "HH:mm:ss", CultureInfo.CurrentCulture);

            // Act
            var clock = new BerlinClockImpl(new Time(parsedInputTime.Hour, parsedInputTime.Minute, parsedInputTime.Second));

            // Assert
            Assert.AreEqual(clock.Blinker, isBlinkerOn);
        }
    }
}
