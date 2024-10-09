namespace TestNinja.Mocking
{
    public class Product
    {
        public float ListPrice { get; set; }

        public float GetPrice(Customer customer)
        {
            bool isCustomerGold = customer.IsGold;

            if (isCustomerGold)
            {
                return ListPrice * 0.7f;
            }

            return ListPrice;
        }
    }
}