namespace TestNinja.Fundamentals
{
    public class FizzBuzz
    {
        public static string GetOutput(int number)
        {
            bool isNumberDividedBy3Even = number % 3 == 0,
                 isNumberDividedBy5Even = number % 5 == 0,
                 isNumberEven = isNumberDividedBy3Even && isNumberDividedBy5Even;

            if (isNumberEven)
            {
                return "FizzBuzz";
            }

            if (isNumberDividedBy3Even)
            {
                return "Fizz";
            }

            if (isNumberDividedBy5Even)
            {
                return "Buzz";
            }

            return number.ToString();
        }
    }
}