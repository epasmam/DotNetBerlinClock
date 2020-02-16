using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BerlinClock.Classes;
using BerlinClock.Abstraction;

namespace BerlinClock
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private ITimeConverter berlinClock = new TimeConverter(new TextClockRenderer());
        private String theTime;

        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(theExpectedBerlinClockOutput, berlinClock.ConvertTime(theTime));
        }

    }
}
