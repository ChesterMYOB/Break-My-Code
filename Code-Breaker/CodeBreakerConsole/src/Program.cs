using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CodeBreakerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var codeSize = RetrieveCodeSize("Enter in the code size: "); 
        }

        private static int RetrieveCodeSize(string message)
        {
            while (true) {
                Console.WriteLine(message);
                var input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input is required!");
                    continue;
                }
                int result;
                if (!int.TryParse(input, out result))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (!Enumerable.Range(1, 100).Contains(result))
                {
                    Console.WriteLine("Input must be between 1 and 100!");
                    continue;
                }
                return result;
            }
        }
    }
}
