using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Handlers
{
   class Program
    {
        public static void Add(int a, int b)
        {
            Console.WriteLine("Sum of the two numbers is: " + (a + b));
        }

        static void Main(string[] args)
        {
            //Ans-1
            Console.WriteLine("*********Solution 1*********");
            Calculator c = new Calculator();
            c.Sum += Add;
            c.Add_two();

            //Ans-2
            Console.WriteLine("*********Solution 2*********");
            MultiCast m = new MultiCast();
            m.Append();
            Console.ReadKey();
            
            //Ans-3
            Console.WriteLine("*********Solution 3*********");
            CallBack cl = new CallBack();
            cl.call();
            Console.ReadKey();

        }
    }
}