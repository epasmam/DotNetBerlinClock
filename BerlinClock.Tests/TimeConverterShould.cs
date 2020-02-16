using BerlinClock.Abstraction;
using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BerlinClock.Tests
{
    [TestClass]
    public class TimeConverterShould
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))] // Assert
        public void ThrowArgumentNullExceptionInCtorIfRendererIsNull()
        {
            // Arrange
            IClockBuilder builder = new Moq.Mock<IClockBuilder>().Object;

            // Act
            var converter = new TimeConverter(null, builder);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))] // Assert
        public void ThrowArgumentNullExceptionInCtorIfBuilderIsNull()
        {
            // Arrange
            IClockRenderer<String> renderer = new Moq.Mock<IClockRenderer<String>>().Object;

            // Act
            var converter = new TimeConverter(renderer, null);
        }

        [TestMethod]
        public void BuildClockFromStringAndRenderClockProperly()
        {
            // Arrange
            String expected = "testString";
            IBerlinClock result = new Moq.Mock<IBerlinClock>().Object;
            var builderMock = new Moq.Mock<IClockBuilder>();
            builderMock.Setup(b => b.BuildClocks(Moq.It.IsAny<String>())).Returns(result).Verifiable();

            var rendererMock = new Moq.Mock<IClockRenderer<string>>();
            rendererMock.Setup(m => m.RenderClocks(Moq.It.Is<IBerlinClock>(clock => result.Equals(clock)))).Returns(expected).Verifiable();

            var converter = new TimeConverter(rendererMock.Object, builderMock.Object);

            // Act
            String actual = converter.ConvertTime("InputTime");

            // Assert
            Assert.AreEqual(actual, expected);
            builderMock.VerifyAll();
            rendererMock.VerifyAll();
        }
    }
}
