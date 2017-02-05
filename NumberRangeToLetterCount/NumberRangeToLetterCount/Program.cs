using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRangeToLetterCount
{
    class Program
    {
        public static int NumberRangeToLetterCount(int a, int b)
        {
            int lowerRange, upperRange;
            int letterCount = 0;
            if (a > b)
            {
                lowerRange = b;
                upperRange = a;
            }
            else
            {
                lowerRange = a;
                upperRange = b;
            }

            for (int i = lowerRange; i <= upperRange; i++)
            {
                string countLetters = NumberToWords(i);

                letterCount = letterCount + countLetters.Count(char.IsLetter);
            }

            return letterCount;

        } 
        public static string NumberToWords(int a)
        {
            int number = a;
            if (number == 0)
            {
                return "zero";
            }
            if (number < 0)
            {
                return "negative " + NumberToWords(Math.Abs(number));

            }
            string words = "";

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += " ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }

            return words;
        }
        static void Main(string[] args)
        {
            int x = 100001;
            int y = 100001;
            do
            {
                Console.WriteLine("Enter a number between -100000 and 100000");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter another number between -100000 and 100000");
                y = Convert.ToInt32(Console.ReadLine());
            } while ((x > 100000) || (x < -100000) || (y > 100000) || (y < -100000));
            int a = NumberRangeToLetterCount(x, y);
            Console.WriteLine(a + " letters were used to write the number range.");
            Console.ReadKey();
        }
    }
}
