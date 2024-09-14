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
                ArrivalDate = ArriveOn(2017, 1, 15),
                DepartureDate = DepartOn(2017, 1, 20)
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
                ArrivalDate = Before(_booking.ArrivalDate, days: 2),
                DepartureDate = Before(_booking.ArrivalDate)
            };

            string result = BookingHelper.OverlappingBookingsExist(firstBooking, _repository.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void BookingStartsAndFinishesInTheMiddleOfAnExistingBooking_ReturnExistingBookingReference()
        {
            Booking firstBooking = new Booking
            {
                Id = 1,
                ArrivalDate = After(_booking.ArrivalDate),
                DepartureDate = Before(_booking.DepartureDate)
            };

            string result = BookingHelper
                .OverlappingBookingsExist(firstBooking, _repository.Object);

            Assert.That(result, Is.EqualTo(_booking.Reference));
        }

        [Test]
        public void BookingStartsBeforeAndFinishesAfterAnExistingBooking_ReturnExistingBookingReference()
        {
            Booking firstBooking = new Booking
            {
                Id = 1,
                ArrivalDate = Before(_booking.ArrivalDate),
                DepartureDate = After(_booking.DepartureDate)
            };

            string result = BookingHelper
                .OverlappingBookingsExist(firstBooking, _repository.Object);

            Assert.That(result, Is.EqualTo(_booking.Reference));
        }

        [Test]
        public void BookingStartsAndFinishesAfterAnExistingBooking_ReturnEmptyString()
        {
            Booking firstBooking = new Booking
            {
                Id = 1,
                ArrivalDate = Before(_booking.ArrivalDate, 2),
                DepartureDate = Before(_booking.DepartureDate)
            };

            string result = BookingHelper.OverlappingBookingsExist(firstBooking, _repository.Object);

            Assert.That(result, Is.EqualTo(_booking.Reference));
        }




        private DateTime Before(DateTime dateTime, int days = 1)
            => dateTime.AddDays(-days);

        private DateTime After(DateTime dateTime)
            => dateTime.AddDays(1);

        private DateTime ArriveOn(int year, int month, int day)
            => new DateTime(year, month, day);

        private DateTime DepartOn(int year, int month, int day)
            => new DateTime(year, month, day);
    }
}
