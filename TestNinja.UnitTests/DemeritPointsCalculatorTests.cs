using NUnit.Framework;
using System;
using TestNinja.Fundamentals;
using Assert = NUnit.Framework.Assert;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        [Test]
        [TestCase(-100)]
        [TestCase(600)]
        public void CalculateDemeritPoints_IsSpeedPossitiveOrSpeedExceedMaxSpeed_ThrowNewArgumentOutOfRangeException(int speed)
        {
            DemeritPointsCalculator calculator = new DemeritPointsCalculator();
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculateDemeritPoints(speed));
        }


        [Test]
        [TestCase(65)]
        [TestCase(30)]
        public void CalculateDemeritPoints_SpeedIsBelowOrEqualSpeedLimit_ReturnZero(int speed)
        {
            DemeritPointsCalculator calculator = new DemeritPointsCalculator();
            int result = calculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        [TestCase(30)]
        public void CalculateDemeritPoints_GetDemeritPoints_ReturnDemeritPoints(int speed)
        {
            DemeritPointsCalculator calculator = new DemeritPointsCalculator();
            int result = calculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.Not.Zero);
        }
    }
}
