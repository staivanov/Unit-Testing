using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        //SetUp
        //TearDown

        private Math _math;

        public void SetUp()
            => _math = new Math();

        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            int result = _math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }


        [Test]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {
            int result = _math.Max(2, 1);
            Assert.That(result, Is.EqualTo(2));
        }


        [Test]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {
            int result = _math.Max(2, 1);
            Assert.That(result, Is.EqualTo(2));

        }


        [Test]
        public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
        {
            int result = _math.Max(2, 2);
            Assert.That(result, Is.EqualTo(2));

        }
    }
}
