using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly DateTime time1 = new DateTime(2013, 1, 1, 9, 00, 00);
        private readonly DateTime time2 = new DateTime(2013, 1, 7, 11, 30, 00);
		[Test()]
        public void TestFlightInitializes()
        {
            var target = new Flight(time1, time2, 200);
            Assert.NotNull(target);
        }

        [Test()]
        public void TestFlightsAreEqual()
        {
            var target1 = new Flight(time1, time2, 200);
            var target2 = target1;
            Assert.True(target1.Equals(target2));

        }

        [Test()]
        public void TestCorrectBasePriceValue()
        {
            var target = new Flight(time1, time2, 200);
            Assert.AreEqual(320, target.getBasePrice());

        }

        [Test()]
        public void TestIfTwoFlightsAreEqual()
        {
            var target1 = new Flight(time1, time2, 350);
            var target2 = new Flight(time1, time2, 350);
            Assert.True(target1.Equals(target2));

        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestIfCustomerIsTimeTraveler()
        {
            new Flight(time2, time1, 100);

        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAbilityToGoNegativeDistanceAndBreakPhysics()
        {
            new Flight(time1, time2, -420);
        }
	}
}
