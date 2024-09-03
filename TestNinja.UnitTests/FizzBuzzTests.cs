using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(60)]
        public void GetOutput_InputIsDisivibleOnThreeAndFive_ReturnFizzBuzz(int number)
        {
            string result = FizzBuzz.GetOutput(number),
                fullWord = "FizzBuzz";

            Assert.That(result, Is.EqualTo(fullWord));
        }


        [Test]
        [TestCase(33)]
        public void GetOutPut_IsNumberDivisibleByThree_ReturnFizz(int number)
        {
            string result = FizzBuzz.GetOutput(number),
                  firstHalfOfTheWord = "Fizz";

            Assert.That(result, Is.EqualTo(firstHalfOfTheWord));
        }


        [Test]
        [TestCase(55)]
        public void GetOutPut_IsNumberDivisibleByFive_ReturnBuzz(int number)
        {
            string result = FizzBuzz.GetOutput(number),
                secondHalfOfTheWord = "Buzz";

            Assert.That(result, Is.EqualTo(secondHalfOfTheWord));
        }
    }
}
