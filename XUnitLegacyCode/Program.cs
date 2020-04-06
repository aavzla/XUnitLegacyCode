using System;
using System.Collections.Generic;

namespace XUnitLegacyCodeSproutMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var dictionaryService = new DictionaryService();

            var dictFrom = new Dictionary<int, int>()
            {
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
            };

            var dictTo = new Dictionary<int, int>()
            {
                { 7, 0 },
                { 8, 0 },
                { 9, 0 },
                { 1, 23 }
            };

            dictionaryService.AppendDictionary<int, int>(dictFrom, dictTo);

            Console.WriteLine($"List of Values of the To Dictionary");
            foreach (var item in dictTo)
            {
                Console.WriteLine($"Key {item.Key} and Value {item.Value}");
            }

            Console.WriteLine("Press a key...");
            Console.ReadKey();
        }
    }
}
