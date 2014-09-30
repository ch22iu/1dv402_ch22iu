using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace guess_the_secret_throw
{
    class Program
    {
        static void Main(string[] args)
        {
            secret throwing = new secret();
            throwing.Throw();

            Console.WriteLine(throwing._faceValue);
            Console.WriteLine("Throwing... Throw!!! ");
            Console.ReadLine();
        }
    }
}
