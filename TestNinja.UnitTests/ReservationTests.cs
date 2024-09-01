using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            Reservation reservation = new Reservation();
            //Act
            User user = new User() { IsAdmin = true };
            bool result = reservation.CanBeCancelledBy(user);
            //Assert
            Assert.That(result, Is.True);
        }


        [Test]
        public void CanBeCancelledBy_SameUserCancellingTheReservation_ReturnTrue()
        {
            User user = new User();
            Reservation reservation = new Reservation() { MadeBy = user };
            bool result = reservation.CanBeCancelledBy(user);

            Assert.That(result, Is.True);
        }


        [Test]
        public void CanBeCancelledBy_AnotherUserCancellingTheReservation_ReturnFalse()
        {
            Reservation reservation = new Reservation() { MadeBy = new User() };
            bool result = reservation.CanBeCancelledBy(new User());

            Assert.That(result, Is.False);
        }
    }
}
