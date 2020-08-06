using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Handlers
{
    class Calculator
    {
        public delegate void Tell_to_sum(int a, int b);

        public event Tell_to_sum Sum;
        public void Add_two()
        {
            int a, b;
            Console.WriteLine("Enter the first number: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number: ");
            b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Press Enter to get the sum of these two numbers:");
            isEnterPressed(a, b);
        }
        protected virtual  void isEnterPressed(int a, int b)
        {
            ConsoleKeyInfo k;
            k = Console.ReadKey();
            if (k.Key == ConsoleKey.Enter)
            {
                Sum?.Invoke(a, b);
            }
            else
            {
                Console.WriteLine("you didnt Press Enter!!");
            }
        }
    }
}
