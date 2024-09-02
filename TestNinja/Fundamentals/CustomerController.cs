namespace TestNinja.Fundamentals
{
    public class CustomerController
    {
        public ActionResult GetCustomer(int id)
        {
            int notFoundCount = 0;

            if (id == notFoundCount)
            {
                return new NotFound();
            }

            return new Ok();
        }
    }

    public class ActionResult { }

    public class NotFound : ActionResult { }

    public class Ok : ActionResult { }
}