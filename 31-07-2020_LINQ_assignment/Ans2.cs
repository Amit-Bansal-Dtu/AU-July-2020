using System;
using System.Linq;

public class Student_ee
{
	static void Main(string[] args)
        {
            string[] stu_names = {"Amit", "Reetha", "Renee", "Aakash", "Meenu", "Sheela"};

            var stu_with_ee = from s in stu_names
                              where s.Contains("ee")
                              select s;


            foreach(var std in stu_with_ee){
                Console.WriteLine(std);
            }
        }
}
