using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader;
        private VideoService _service;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _service = new VideoService(_fileReader.Object);
        }


        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnErrorMessage()
        {
            string emptyString = "",
                   path = "video.txt";

            _fileReader.Setup(fr => fr.Read(path)).Returns(emptyString);

            string result = _service.ReadVideoTitle();
            string errorMessage = "error";

            Assert.That(result, Does.Contain(errorMessage).IgnoreCase);
        }






    }
}
