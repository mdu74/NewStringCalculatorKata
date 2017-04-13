using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            var filteredInput = Filter(ref input);

            var numbers = input.Split(filteredInput.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            CheckForNegative(numbers);
            return CalculateTheSumOf(numbers);
        }

        private static List<string> Filter(ref string input)
        {
            var delimiterList = new List<string> { ",", "\n" };

            if (input.StartsWith("//"))
            {
                var indexOfNewLine = input.IndexOf('\n');
                delimiterList.AddRange(input.Substring(0, indexOfNewLine)
                    .Replace("//", "")
                    .Split('[', ']'));
                input = input.Substring(indexOfNewLine + 1);
            }

            return delimiterList;
        }

        private static void CheckForNegative(string[] numbers)
        {
            var negativeNumbers = numbers.Where(n => int.Parse(n) < 0);
            if (negativeNumbers.Any())
            {
                throw new ArgumentException("No Negative Numbers Allowed: " + string.Join(",", negativeNumbers.ToList()));
            }
        }

        private static int CalculateTheSumOf(string[] numbers)
        {
            return numbers.Where(number => int.Parse(number) <= 1000).Sum(number => int.Parse(number));
        }
    }
}