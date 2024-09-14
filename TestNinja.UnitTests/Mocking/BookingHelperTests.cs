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
        private Booking _booking;
        private Mock<IBookingRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _booking = new Booking
            {
                Id = 2,
                ArrivalDate = ArriveOn(2023, 4, 10),
                DepartureDate = DepartedOn(2023, 4, 11)
            };

            _repository = new Mock<IBookingRepository>();

            _repository.Setup(r => r.GetActiveBooking(1)).Returns(new List<Booking>
                {
                    _booking
                }.AsQueryable());
        }


        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            Booking firstBooking = new Booking
            {
                Id = 1,
                ArrivalDate = Before(_booking.ArrivalDate, 2),
                DepartureDate = Before(_booking.ArrivalDate)
            };

            string result = BookingHelper.OverlappingBookingsExist(firstBooking, _repository.Object);

            Assert.That(result, Is.Empty);
        }


        private DateTime Before(DateTime dateTime, int days = 1)
            => dateTime.AddDays(-days);

        private DateTime After(DateTime dateTime)
            => dateTime.AddDays(1);

        private DateTime ArriveOn(int year, int month, int day)
            => new DateTime(year, month, day);

        private DateTime DepartedOn(int year, int month, int day)
            => new DateTime(year, month, day);
    }
}
