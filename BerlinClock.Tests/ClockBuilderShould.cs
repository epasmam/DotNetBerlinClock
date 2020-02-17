using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BerlinClock.Abstraction;
using BerlinClock.Classes;

namespace BerlinClock.Tests
{
    [TestClass]
    public class ClockBuilderShould
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))] // Assert
        public void ThrowArgumentNullExceptionInCtorOnNullTimeParserParameter()
        {
            // Arrange, Act
            var builder = new ClockBuilder(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))] // Assert
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void ThrowArgumentNullExceptionInBuildClocksOnNullOrEmptyTime(String time)
        {
            // Arrange
            var timeParser = new Moq.Mock<ITimeParser>();
            timeParser.Setup(parser => parser.GetTimeFromString(Moq.It.IsAny<String>())).Callback(Assert.Fail);

            var builder = new ClockBuilder(timeParser.Object);

            // Act
            builder.BuildClocks(time);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))] // Assert
        public void ThrowArgumentExceptionInBuildClocksOnIncorrectTimeProvided()
        {
            // Arrange
            var timeParser = new Moq.Mock<ITimeParser>();
            timeParser.Setup(parser => parser.GetTimeFromString(Moq.It.IsAny<String>())).Returns(Time.Incorrect).Verifiable();

            var builder = new ClockBuilder(timeParser.Object);

            // Act
            try
            {
                builder.BuildClocks("Dummy");
            }
            finally
            {
                timeParser.VerifyAll();
            }
        }

        [TestMethod]
        public void CreateBerlinClockImplClassWithProvidedTime()
        {
            // Arrange
            var timeParser = new Moq.Mock<ITimeParser>();
            timeParser.Setup(parser => parser.GetTimeFromString(Moq.It.IsAny<String>())).Returns(Time.FromInt32(123456)).Verifiable();

            var builder = new ClockBuilder(timeParser.Object);

            // Act
            IBerlinClock clock = builder.BuildClocks("Dummy");

            // Assert
            Assert.IsNotNull(clock);
            Assert.IsInstanceOfType(clock, typeof(BerlinClockImpl));
            timeParser.VerifyAll();
        }
    }
}
