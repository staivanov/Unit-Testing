using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnErrorMessage()
        {
            VideoService videoService = new VideoService(new FakeFileReader());       
            string result = videoService.ReadVideoTitle(),
                errorMessage = "error";

            Assert.That(result, Does.Contain(errorMessage).IgnoreCase);
        }






    }
}
