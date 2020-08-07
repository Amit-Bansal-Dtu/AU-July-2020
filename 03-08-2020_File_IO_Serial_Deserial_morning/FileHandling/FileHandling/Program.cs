using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***********Answer-1***********");
            Question1 q1 = new Question1();
            q1.perform();

            Console.WriteLine("***********Answer-2***********");
            Question2 q2 = new Question2();
            q2.perform();
            Console.ReadKey();
        }
    }
}
