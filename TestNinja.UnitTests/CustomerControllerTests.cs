using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            CustomerController controller = new CustomerController();
            ActionResult result = controller.GetCustomer(0);

            //Not found object
            Assert.That(result, Is.TypeOf<NotFound>());
            //Not found object or one its derivatives.
            //Assert.That(result, Is.InstanceOf<NotFound>());
        }


        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {

        }



    }
}
