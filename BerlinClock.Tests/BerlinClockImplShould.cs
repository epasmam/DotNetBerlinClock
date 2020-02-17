using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BerlinClock.Abstraction;
using BerlinClock.Classes;

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
        [DataRow(000000, true)]
        [DataRow(000001, false)]
        [DataRow(235958, true)]
        [DataRow(235959, false)]
        public void BlinkerStatusShouldBeCorrect(Int32 timeInInt32, Boolean isBlinkerOn)
        {
            // Arrange
            var time = Time.FromInt32(timeInInt32);
            // Act
            var clock = new BerlinClockImpl(time);

            // Assert
            Assert.AreEqual(clock.Blinker, isBlinkerOn);
        }

        [TestMethod]
        [DataRow(000000, new []{ false, false, false, false})]
        [DataRow(045959, new[] { false, false, false, false })]
        [DataRow(050000, new[] { true, false, false, false })]
        [DataRow(095959, new[] { true, false, false, false })]
        [DataRow(100000, new[] { true, true, false, false })]
        [DataRow(145959, new[] { true, true, false, false })]
        [DataRow(150000, new[] { true, true, true, false })]
        [DataRow(195959, new[] { true, true, true, false })]
        [DataRow(200000, new[] { true, true, true, true })]
        [DataRow(235959, new[] { true, true, true, true})]
        public void FiveHoursBulbsShouldReturnCorrectNumberOfBulbLightsProperlyPositioned(Int32 timeInInt32, Boolean[] positions)
        {
            // Arrange
            var time = Time.FromInt32(timeInInt32);
            // Act
            var clock = new BerlinClockImpl(time);

            // Assert
            Assert.AreEqual(clock.FiveHoursBulbs.Count(), 4);
            Int32 i = 0;
            Dictionary<Int32, Boolean> result = clock.FiveHoursBulbs.ToDictionary(k => i++, k => k);
            Assert.IsTrue(result.Aggregate(true, (isValid, bulbLight) => isValid && (positions[bulbLight.Key] == bulbLight.Value), isValid => isValid));
        }

        [TestMethod]
        [DataRow(000000, new[] { false, false, false, false })]
        [DataRow(015959, new[] { true, false, false, false })]
        [DataRow(020000, new[] { true, true, false, false })]
        [DataRow(035959, new[] { true, true, true, false })]
        [DataRow(040000, new[] { true, true, true, true })]
        [DataRow(050000, new[] { false, false, false, false })]
        public void HoursBulbsShouldReturnCorrectNumberOfBulbLightsProperlyPositioned(Int32 timeInInt32, Boolean[] positions)
        {
            // Arrange
            var time = Time.FromInt32(timeInInt32);
            // Act
            var clock = new BerlinClockImpl(time);

            // Assert
            Assert.AreEqual(clock.HoursBulbs.Count(), 4);
            Int32 i = 0;
            Dictionary<Int32, Boolean> result = clock.HoursBulbs.ToDictionary(k => i++, k => k);
            Assert.IsTrue(result.Aggregate(true, (isValid, bulbLight) => isValid && (positions[bulbLight.Key] == bulbLight.Value), isValid => isValid));
        }

        [TestMethod]
        [DataRow(000000, new[] { false, false, false, false, false, false, false, false, false, false, false })]
        [DataRow(000500, new[] { true, false, false, false, false, false, false, false, false, false, false })]
        [DataRow(001000, new[] { true, true, false, false, false, false, false, false, false, false, false })]
        [DataRow(001500, new[] { true, true, true, false, false, false, false, false, false, false, false })]
        [DataRow(002000, new[] { true, true, true, true, false, false, false, false, false, false, false })]
        [DataRow(002500, new[] { true, true, true, true, true, false, false, false, false, false, false })]
        [DataRow(003000, new[] { true, true, true, true, true, true, false, false, false, false, false })]
        [DataRow(003500, new[] { true, true, true, true, true, true, true, false, false, false, false })]
        [DataRow(004000, new[] { true, true, true, true, true, true, true, true, false, false, false })]
        [DataRow(004500, new[] { true, true, true, true, true, true, true, true, true, false, false })]
        [DataRow(005000, new[] { true, true, true, true, true, true, true, true, true, true, false })]
        [DataRow(005500, new[] { true, true, true, true, true, true, true, true, true, true, true })]
        public void FiveMinutesBulbsShouldReturnCorrectNumberOfBulbLightsProperlyPositioned(Int32 timeInInt32, Boolean[] positions)
        {
            // Arrange
            var time = Time.FromInt32(timeInInt32);
            // Act
            var clock = new BerlinClockImpl(time);

            // Assert
            Assert.AreEqual(clock.FiveMinutesBulbs.Count(), 11);
            Int32 i = 0;
            Dictionary<Int32, Boolean> result = clock.FiveMinutesBulbs.ToDictionary(k => i++, k => k);
            Assert.IsTrue(result.Aggregate(true, (isValid, bulbLight) => isValid && (positions[bulbLight.Key] == bulbLight.Value), isValid => isValid));
        }

        [TestMethod]
        [DataRow(000000, new[] { false, false, false, false })]
        [DataRow(010059, new[] { false, false, false, false })]
        [DataRow(020100, new[] { true, false, false, false })]
        [DataRow(030159, new[] { true, false, false, false })]
        [DataRow(040200, new[] { true, true, false, false })]
        [DataRow(050259, new[] { true, true, false, false })]
        [DataRow(060300, new[] { true, true, true, false })]
        [DataRow(070359, new[] { true, true, true, false })]
        [DataRow(080400, new[] { true, true, true, true })]
        [DataRow(090459, new[] { true, true, true, true })]
        [DataRow(100500, new[] { false, false, false, false })]
        public void MinutesBulbsShouldReturnCorrectNumberOfBulbLightsProperlyPositioned(Int32 timeInInt32, Boolean[] positions)
        {
            // Arrange
            var time = Time.FromInt32(timeInInt32);
            // Act
            var clock = new BerlinClockImpl(time);

            // Assert
            Assert.AreEqual(clock.MinutesBulbs.Count(), 4);
            Int32 i = 0;
            Dictionary<Int32, Boolean> result = clock.MinutesBulbs.ToDictionary(k => i++, k => k);
            Assert.IsTrue(result.Aggregate(true, (isValid, bulbLight) => isValid && (positions[bulbLight.Key] == bulbLight.Value), isValid => isValid));
        }
    }
}
