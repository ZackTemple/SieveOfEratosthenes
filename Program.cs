using System;

namespace SieveOfEratosthenes
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            bool runProgram = true;
            while (runProgram)
            {
                Console.WriteLine("Enter a number to check its primality:");
                var number = Int32.Parse(Console.ReadLine());
                
                // Catch for case when number is 1
                var primes = number != 1 ? GetPrimes(number) : new int[1];
                PrintPrimes(primes);

                var isPrime = primes[number - 1] == 1;
                var messageForIsPrime = isPrime ? String.Empty : "not ";
                Console.WriteLine($"\n{number} is {messageForIsPrime}prime.");
                
                Console.WriteLine("Would you like to test another number? (y/n)");
                string userWantsToContinue = Console.ReadLine();
                
                runProgram = userWantsToContinue.ToLower() == "y";
            }
        }

        private static int[] GetPrimes(int arrayLength)
        {
            var primes = new int[arrayLength];
            for (int i = 0; i <= primes.GetUpperBound(0); i++) primes[i] = 1;

            primes.SieveArray();

            return primes;
        }

        private static void SieveArray(this int[] array)
        {
            for (var outer = 1; outer <= array.GetUpperBound(0); outer++)
            {
                for (var inner = outer + 1; inner <= array.GetUpperBound(0); inner++)
                {
                    if (array[inner] == 1)
                    {
                        // inner and outer must add 1 to their values to align indexes with wanted numeric values
                        var isDivisible = (inner + 1) % (outer + 1) == 0;
                        array[inner] = isDivisible ? 0 : 1;
                    }
                }
            }
        }
        
        static void PrintPrimes(int[] array)
        {
            var upperBound = array.GetUpperBound(0);
            Console.WriteLine($"\nPrimes numbers from 1 to {upperBound + 1}:");
            for (int i = 0; i <= upperBound; i++)
            {
                if (array[i] == 1)
                {
                    // Like above, need to add one to align for numeric values
                    Console.Write((i + 1) + " ");
                }
            }
            Console.WriteLine();
        }
    }
}