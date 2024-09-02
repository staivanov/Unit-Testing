using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        //SetUp
        //TearDown

        private Math _math;

        [SetUp]
        public void SetUp()
            => _math = new Math();

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(2, 2, 2)]
        public void Max_WhenCalled_ReturnTheGreatestArgument(int a, int b, int expectedResult)
        {
            int result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }


        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            IEnumerable<int> result = _math.GetOddNumbers(5);

            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count(), Is.EqualTo(3));
            //Assert.That(result, Does.Contain(3));
            Assert.That(result, Does.Contain(5));
        }
    }
}
