using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling
{
    class Question1
    {
        public void perform()
        {
            string direc_name;
            Console.WriteLine("Enter the name of the directory to be created: ");
            direc_name = Console.ReadLine();
            string path = "G:\\" + direc_name;
            if (Directory.Exists(path))
            {
                Console.WriteLine("Directory Already Exists!!");
            }
            Directory.CreateDirectory("G:\\" + direc_name);
            
            create_empty_file(path);
        }

        public void create_empty_file(string path)
        {
            string file_path = path + "\\file.txt";
            if (File.Exists(file_path))
            {
                File.Delete(file_path);
            }
            var myFile = File.Create(file_path);
            myFile.Close();
            input_data(file_path);
            count_words(file_path);
            reverse_data(path);
        }

        public void count_words(string path)
        {
            int count = 0;
            string[] lines = File.ReadAllLines(path);
            foreach(string line in lines)
            {
                string[] arr = line.Split(' ');
                count = count + arr.Length;
            }
            Console.WriteLine("Number of words in file.txt are : " + count);
        }

        public void input_data(string path)
        {
            List<string> lines = new List<string>();
            Boolean Keep_adding = true;
            int i = 0;
            while (Keep_adding)
            {
                Console.WriteLine("Enter a line to be added to the file: ");
                string line = Console.ReadLine();
                lines.Add(line);
                Console.Write("Do you want to add more lines? (y/n)");
                string s = Console.ReadLine();
                if (s == "n" || s=="N")
                {
                    Keep_adding = false;
                }
                i = i + 1;
            }
            try
            {
                File.WriteAllLines(path, lines);
            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        
        public void reverse_data(string path)
        {
            string old_path = path + "\\file.txt";
            string file_path = path + "\\reverse_file.txt";
            if (File.Exists(file_path))
            {
                File.Delete(file_path);
            }
            var myFile = File.Create(file_path);
            myFile.Close();
            string[] lines = File.ReadAllLines(old_path);
            Array.Reverse(lines);
            File.WriteAllLines(file_path, lines);
        }
    }
}
