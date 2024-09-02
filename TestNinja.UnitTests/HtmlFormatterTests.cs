using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {

        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            HtmlFormatter htmlFormatter = new HtmlFormatter();

            string result = htmlFormatter.FormatAsBold("abcd");
            string expectingReturnedResult = "<strong>abcd</strong>";
            string prefixStrongTag = "<strong>",
                postfixStrongTag = "</strong>",
                message = "abcd";

            //Specific
            Assert.That(result, Is.EqualTo(expectingReturnedResult).IgnoreCase);

            //More general
            Assert.That(result, Does.StartWith(prefixStrongTag).IgnoreCase);
            Assert.That(result, Does.EndWith(postfixStrongTag));
            Assert.That(result, Does.Contain(message));
        }
    }
}
