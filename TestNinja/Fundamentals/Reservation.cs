namespace TestNinja.Fundamentals
{
    public class Reservation
    {
        public User MadeBy { get; set; }

        public bool CanBeCancelledBy(User user)
        {
            bool isUserAdmin = user.IsAdmin,
                 isUserMadeByUser = MadeBy == user;

            if (isUserAdmin || isUserMadeByUser)
            {
                return true;
            }

            return false;
        }
    }
}