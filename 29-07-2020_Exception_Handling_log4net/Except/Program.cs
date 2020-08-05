using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Except
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {

            Console.WriteLine("Program 1 for file reading with exception handling and logging");
            Boolean is_success = true;
            string path = "C://Users//Amit Bansal//source//repos//Except//Except//data.txt";
            try
            {
                Console.WriteLine("Data read from the file is given below:");
                string text = File.ReadAllText(path);
                Console.WriteLine(text);
            }
            catch (DirectoryNotFoundException e)
            {
                is_success = false;
                Console.WriteLine("\nDirectory Not Found\n");
                log.Error(e.StackTrace);
            }
            catch (FileNotFoundException e)
            {
                is_success = false;
                Console.WriteLine("\nFile Not Found\n");
                log.Error(e.StackTrace);
            }
            catch (FileLoadException e)
            {
                is_success = false;
                Console.WriteLine("\nFile Could Not Be Loaded\n");
                log.Error(e.StackTrace);
            }
            catch (IOException e)
            {
                is_success = false;
                Console.WriteLine("\nAn Input Output Error has occured\n");
                log.Error(e.StackTrace);
            }
            catch (Exception e)
            {
                is_success = false;
                Console.WriteLine("\nAn Unexpected Error has occured\n");
                log.Fatal(e.StackTrace);
            }
            finally
            {
                if (is_success)
                {
                    Console.WriteLine("\n\n");
                    log.Info("Read Successful");
                }
                else
                {
                    Console.WriteLine("\n\n");
                    log.Warn("Reading Failed");
                }
                log.Info("Program Execution Ended\n\n");
            }

            // Second Program of dividing two numbers
            Console.WriteLine("\nProgram 2 for dividing two numbers with exception handling and logging");
            int a, b;
            Console.WriteLine("Enter the value of dividend:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the value of divisor:");
            b = Convert.ToInt32(Console.ReadLine());
            try
            {
                is_success = true;
                Console.WriteLine("Quotient: " + (a / b));
            }
            catch(Exception e)
            {
                is_success = false;
                log.Error(e.StackTrace);
            }
            finally
            {
                if (is_success) {
                    Console.WriteLine("Numbers divided successfully!!");
                }
                else
                {
                    Console.WriteLine("Failed Execution");
                }
                Console.ReadKey();
            }
        }
    }
}
