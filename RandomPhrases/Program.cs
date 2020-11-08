using System;
using System.Configuration.Assemblies;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace RandomPhrases
{
    class Program
    {
        static int Main(string[] args)
        {
restart:
            if (args.Length < 1)
            {
                return -1;
            }

            uint count = Convert.ToUInt32(args[0]);

            Random random = new Random((int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);

            string[] words = File.ReadAllLines("dic.txt");

            string total = "";

            for (uint i = 0; i < count; i++)
            {
                string word;
                /*for (uint j = 0; j < random.Next(2, 14); j++)
                {
                    char c = (char)random.Next(97, 122);
                    word += c;
                }*/

                int resultQuery = random.Next(0, words.Length - 1);

                word = words[resultQuery];

                if (total.Trim().EndsWith('.') || total.Trim().EndsWith(';'))
                {
                    word = word.ToUpper()[0] + word.Remove(0, 1);
                    word = word.ToUpper()[0] + word.Substring(1);
                }

                if (random.Next() % 20 == 0)
                    total += word + ", ";
                else if (random.Next() % 40 == 0)
                    total += word + " : ";
                else if (random.Next() % 30 == 0)
                    total += word + ". ";
                else if (random.Next() % 50 == 0)
                    total += word + "; ";
                else if (random.Next() % 60 == 0)
                    total += word + " - ";
                else if (random.Next() % 320 == 0)
                    total += word + " / ";
                else
                    total += word + " ";
            }

            total = total.Trim();
            if (!total.EndsWith('.'))
                total += ".";
            if (total.EndsWith(';') || total.EndsWith('/') || total.EndsWith(':') || total.EndsWith(',')
                || total.EndsWith('-'))
            {
                total = total.Remove(total.Length - 1);
                total = total.Trim();
                total += ".";
            }

            total = total.ToUpper()[0] + total.Remove(0, 1);
            total = total.ToUpper()[0] + total.Substring(1);

            Console.WriteLine(total);

            Console.WriteLine("----------------------\nPress Y to restart.");

            while (true)
            {
                if (Console.KeyAvailable || Console.ReadKey(true).Key == ConsoleKey.Y)
                {

                    goto restart;
                }
                else
                    return 0;
            }
        }
    }
}
