using System;
using System.Linq;
using System.Collections.Generic;

namespace RomanianNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Romanian romanian = new Romanian();

            Console.WriteLine(romanian.ArabToRomain(2048));
            Console.WriteLine(romanian.RomainToArab("MMXLVIII"));
        }
    }

    class Romanian
    {
        public int Number { get; set; }

        public Dictionary<int, string> RomainArab { get; set; }
        public Dictionary<string, int> ArabRomain { get; set; }

        public Romanian()
        {
            RomainArab = FillRomain();
            ArabRomain = FillArab();
        }

        public Dictionary<int, string> FillRomain()
        {
            Dictionary<int, string> result = new Dictionary<int, string>
            {
                { 1000, "M" },
                { 900, "CM" },
                { 500, "D" },
                { 400, "CD" },
                { 100, "C" },
                { 90, "XC" },
                { 50, "L" },
                { 40, "XL" },
                { 10, "X" },
                { 9, "IX" },
                { 5, "V" },
                { 4, "IV" },
                { 1, "I" }
            };

            return result;
        }

        public Dictionary<string, int> FillArab()
        {
            Dictionary<string, int> result = new Dictionary<string, int>
            {
                { "M", 1000 },
                { "CM", 900 },
                { "D", 500 },
                { "CD", 400 },
                { "C", 100 },
                { "XC", 90 },
                { "L", 50 },
                { "XL", 40 },
                { "X", 10 },
                { "IX", 9 },
                { "V", 5 },
                { "IV", 4 },
                { "I", 1 }
            };

            return result;
        }

        public string ArabToRomain(int number)
        {
            string result = "";

            while (number > 0)
            {
                foreach (var value in RomainArab.Keys.OrderByDescending(x => x))
                {
                    if (number >= value)
                    {
                        result += RomainArab[value];
                        number -= value;
                        break;
                    }
                }
            }

            return result;
        }

        public int RomainToArab(string number)
        {
            int result = 0;

            while (number.Length != 0)
            {
                if (number.Length == 1)
                {
                    result += ArabRomain[number];
                    break;
                }

                string key = number[0].ToString() + number[1].ToString();

                if (ArabRomain.ContainsKey(key))
                {
                    result += ArabRomain[key];
                    number = number.Substring(2, number.Length - 2);
                }
                else
                {
                    key = number[0].ToString();
                    result += ArabRomain[key];
                    number = number.Substring(1, number.Length - 1);
                }
            }

            return result;
        }
    }
}
