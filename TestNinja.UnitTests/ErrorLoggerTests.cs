using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            ErrorLogger logger = new ErrorLogger();
            string message = "Hello";
            logger.Log(message);

            Assert.That(logger.LastError, Is.EqualTo(message));
        }


        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            ErrorLogger logger = new ErrorLogger();
            //logger.Log(error);

            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
        }
    }
}
