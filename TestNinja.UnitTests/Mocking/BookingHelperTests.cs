using NUnit.Framework;
using TestNinja.Mocking;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class BookingHelperTests
    {

        [Test]
        public void OverlappingBookingsExist_BookingStartsAndFinishesBeforeAnExistingBooking_Return_Empty_String()
        {
            var repository = new Mock<IBookingRepository>();
            repository.Setup(r => r.GetActiveBooking(1)).Returns(new List<Booking>
            {
               new Booking {
                   Id = 2,
                   ArrivalDate = new DateTime(2023, 4, 10, 2, 0, 0),
                   DepartureDate = new DateTime(2023, 4, 11, 5, 0,0)
               }
            }.AsQueryable());


            Booking secondBooking = new Booking
            {
                Id = 2,
                ArrivalDate = new DateTime(2023, 5, 15, 2, 0, 0),
                DepartureDate = new DateTime(2023, 5, 16, 8, 0, 0)
            };

            var result = BookingHelper.OverlappingBookingsExist(secondBooking, repository.Object);

            Assert.That(result, Is.Empty);
        }
    }
}
