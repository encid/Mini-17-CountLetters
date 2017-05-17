using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Mini17CountLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = "The quick brown fox jumps over the lazy dog and the sleeping cat early in the day.";
            var output = "";
            var letter_count = count_letters(data);

            foreach (var pair in letter_count)
                output += string.Format("{0}:{1} ", pair.Key, pair.Value);

            Console.Write(output);
            Console.ReadKey();
        }

        static Dictionary<char, int> count_letters(string input)
        {
            Regex regex = new Regex("A-Za-z");
            var letter_count = new Dictionary<char, int>();

            foreach (var letter in input)
            {
                if (char.IsLetter(letter))
                    if (letter_count.ContainsKey(letter))                                                                                                   
                        letter_count[char.ToLower(letter)]++;
                    else
                        letter_count.Add(char.ToLower(letter), 1);                                       
            }

            return letter_count.OrderByDescending(pair => pair.Value)
                               .ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}