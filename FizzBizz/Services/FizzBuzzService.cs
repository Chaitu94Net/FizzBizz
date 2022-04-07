namespace FizzBizz.Services
{
    public class FizzBuzzService: IFizzBuzzService
    {
        public string CheckFizzBuzz(int value)
        {
            //can use switch case statement
            if (value % 3 == 0 && value % 5 == 0)
            {
                return "fizzbuzz";
            }
            else if (value % 3 == 0)
            {
                return "fizz";
            }
            else if (value % 5 == 0)
            {
                return "buzz";
            }           
            else if (value % 3 != 0 && value % 5 != 0)
            {
                return "Divided " + value.ToString() + " by 3;Divided " + value.ToString() + " by 5";
            }
            else
            {
                return value.ToString();
            }
        }
    }
 }

