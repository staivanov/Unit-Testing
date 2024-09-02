using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            Math math = new Math();
            int result = math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }





    }
}
