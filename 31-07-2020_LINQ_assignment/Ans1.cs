using System;
using System.Linq;

public class Vowel
{
        static void Main(string[] args)
        {
            Console.Write("Please Enter a String: ");
            string str = Console.ReadLine();
            char[] vow = {'a','e','i','o','u'};

            int get_vow_count = str.Count(v=>vow.Contains(v));

            Console.WriteLine("There are a total of "+get_vow_count+ " vowels in the given string!!");
        }
}
