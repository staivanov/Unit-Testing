using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
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


        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            ErrorLogger logger = new ErrorLogger();
            Guid id = Guid.Empty,
                emptyGuid = Guid.Empty;
            logger.ErrorLogged += (sender, args) => { id = args; };
            logger.Log("a");
            
            Assert.That(id, Is.Not.EqualTo(emptyGuid));
        }
    }
}
