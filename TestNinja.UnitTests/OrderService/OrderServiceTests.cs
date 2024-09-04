using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {   //Arrange
            Mock<IStorage> storage = new Mock<IStorage>();
            OrderService service = new OrderService(storage.Object);
            //Act
            Order newOrder = new Order();
            service.PlaceOrder(newOrder);
            //Assert
            storage.Verify(s => s.Store(newOrder));
        }







    }
}
