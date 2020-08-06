using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Handlers
{
    class MultiCast
    {
        private string property;
        public MultiCast()
        {
            property = "";
        }
        public delegate void Tell_to_append(string a, string b);

        public void fun1(string a, string b)
        {
            if (a.Length > b.Length)
            {
                property += a;
            }
            else
            {
                property += b;
            }
        }
        public void fun2(string a, string b)
        {
            if (a.Length > b.Length)
            {
                property += a;
            }
            else
            {
                property += b;
            }
        }

        public void Append()
        {
            string a, b;
            Console.WriteLine("Enter 1st String: ");
            a = Console.ReadLine();
            Console.WriteLine("Enter 2nd String: ");
            b = Console.ReadLine();

            Tell_to_append obj;
            obj = fun1;
            obj += fun2;

            obj(a, b);
            Console.WriteLine("Property is now : "+property);
        }
    }
}
