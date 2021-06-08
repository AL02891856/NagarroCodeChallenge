using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodingTestNagarro
{
    public static class Program
    {
        static void Main()
        {
            var validInput = false;
            var input = string.Empty;

            // I added the validation to not accept numbers, this for not breaking the format [FirstLetter][NumberDistinct][LastLetter]
            // Example: Exercis3 --> E73 --> 2 numbers at the end
            while (!validInput) {
                Console.WriteLine("Type a string: ");
                input = Console.ReadLine();

                if (input.Any(char.IsDigit)) {
                    Console.WriteLine("Please do not type numbers. You can use non-alphabetic characters or spaces as separators.");
                }
                else {
                    validInput = true;
                }
            }

            var result = FormatString(input);
            Console.WriteLine("Original input: " + input);
            Console.WriteLine("Result: " + result);
        }

        public static string FormatString(string s) {
            var result = new List<string>();
            
            if (!s.Length.Equals(0)) { // if s is empty, don't do anything
               
                string[] wordsArr = Regex.Matches(s, "\\w+('(s|d|t|ve|m))?").Cast<Match>().Select(x => x.Value).ToArray();  // Use non-alphabetic as separator, we know at this point that we don't have numbers

                for (var i = 0; i < wordsArr.Length; i++)
                {
                    var word = wordsArr[i].ToCharArray();
                    var firstLetter = string.Empty;
                    var lastLetter = string.Empty;
                    var diffChar = new List<char>();

                    for (var j = 0; j < word.Length; j++) {
                        if (j == 0) { firstLetter = word[j].ToString(); continue; }
                        if (j + 1 == word.Length) { lastLetter = word[j].ToString(); continue; }

                        if (!diffChar.Contains(word[j])) {
                            diffChar.Add(word[j]);
                        }
                    }

                    result.Add(firstLetter + diffChar.Count + lastLetter);
                }
            }

            return string.Join(" ", result).Trim();
        }
    }
}
