using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount()
        {
            Product product = new Product() { ListPrice = 100 };
            Customer newCustomer = new Customer() { IsGold = true };

            float result = product.GetPrice(newCustomer),
                testPrice = 70;


            Assert.That(result, Is.EqualTo(testPrice));

        }
    }
}
