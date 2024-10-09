using System.Linq;

namespace TestNinja.Mocking
{
    public class BookingRepository : IBookingRepository
    {
        public IQueryable<Booking> GetActiveBooking(int? excludeBookingId = null)
        {
            string cancelled = "Cancelled";

            UnitOfWork unitOfWork = new UnitOfWork();

            IQueryable<Booking> bookings = unitOfWork
                .Query<Booking>()
                .Where(b => b.Status != cancelled);

            if (excludeBookingId.HasValue)
            {
                bookings = bookings.Where(b => b.Id != excludeBookingId.Value);
            }

            return bookings;
        }
    }
}
