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





    }
}
