using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPlayGroundTemplate
{
    public class FizzBuzz
    {
        public string Calculate(int number)
        {
            const string fizz = "Fizz";
            const string buzz = "Buzz";
            const string whiz = "Whiz";

            if (DivisibleByThree(number) && DivisibleByFive(number))
            {
                return fizz + buzz;
            }
            
            if (DivisibleByThree(number))
            {
                if (IsPrime(number))
                {
                    return fizz + whiz;
                }
                return fizz;
            }

            if (DivisibleByFive(number))
            {
                if (IsPrime(number))
                {
                    return buzz + whiz;
                }
                return buzz;
            }
            
            return IsPrime(number) ? whiz : number.ToString();
        }

        private bool IsPrime(int number)
        {
            int numberOfTimeCanBeDivided;
            for (numberOfTimeCanBeDivided = 2; numberOfTimeCanBeDivided < number ; numberOfTimeCanBeDivided++)
            {
                if (number %  numberOfTimeCanBeDivided == 0)
                {
                    return false;
                }
            }

            return numberOfTimeCanBeDivided == number;
        }

        private bool DivisibleByFive(int number)
        {
            return number % 5 == 0;
        }

        private bool DivisibleByThree(int number)
        {
            return number % 3 == 0;
        }
    }
}
