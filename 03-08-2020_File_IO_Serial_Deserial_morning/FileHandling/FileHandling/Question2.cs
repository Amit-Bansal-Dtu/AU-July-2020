using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling
{
    class Question2
    {

        string oldPath, path1, path2;

        public Question2()
        {
            oldPath = "G:\\Newbinary.bin";
            path1 = "G:\\Filter.txt";
            path2 = "G:\\WithoutFilter.txt";

            if (File.Exists(path1))
            {
                File.Delete(path1);
            }
            if (File.Exists(path2))
            {
                File.Delete(path2);
            }
        }
        public void perform()
        { 
            using (FileStream file = File.OpenRead(oldPath))
            {
                byte[] data = new byte[file.Length];
                file.Read(data, 0, (int)file.Length);
                file.Close();

                using (StreamWriter f1 = new StreamWriter(path1))
                {
                    using (StreamWriter f2 = new StreamWriter(path2))
                    {
                        for (int i = 0; i < data.Length; i++)
                        {
                            if ((Convert.ToInt32(data[i]) >= 32) &&
                                (Convert.ToInt32(data[i]) <= 127) ||
                                (Convert.ToInt32(data[i]) == 10) ||
                                (Convert.ToInt32(data[i]) == 13))
                            {
                                f1.Write(Convert.ToChar(data[i]));
                            }
                            f2.Write(Convert.ToChar(data[i]));
                        }
                        f1.Close();
                        f2.Close();
                        Console.WriteLine("program Executed Successfully, check your concerned Directory");
                    }
                }
            }
        }
    }
}
