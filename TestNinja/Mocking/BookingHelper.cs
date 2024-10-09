using System.Linq;

namespace TestNinja.Mocking
{
    public static class BookingHelper
    {
        public static string OverlappingBookingsExist(Booking booking, IBookingRepository repository)
        {
            string cancelled = "Cancelled";

            if(booking.Status == cancelled)
            {
                return string.Empty;
            }

            IQueryable<Booking> bookings = repository.GetActiveBooking(booking.Id);

            Booking overlappingBooking =
                bookings.FirstOrDefault(
                    b => booking.ArrivalDate < b.DepartureDate &&
                         b.ArrivalDate < booking.DepartureDate);
  
            return overlappingBooking == null ? string.Empty : overlappingBooking.Reference;
        }
    }
}