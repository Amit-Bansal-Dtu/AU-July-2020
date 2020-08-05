using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace DB_Net
{
    class Program
    {
        
        public void Insert_data(MySqlConnection conn)
        {
            Console.WriteLine("Enter the roll_no of new student: ");
            int r = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the name of new student: ");
            
            string n = Console.ReadLine();
            Console.WriteLine("Enter marks of new student: ");
            int m = Convert.ToInt32(Console.ReadLine());
            MySqlCommand cmd = new MySqlCommand("call insert_new_student('"+r+"','"+n+"','"+ m+"')", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            cmd.Dispose();
            Show_data(conn);
        }

        public void Delete_data(MySqlConnection conn)
        {
            Console.WriteLine("Enter the roll_no of the student to be deleted: ");
            int r = Convert.ToInt32(Console.ReadLine());
            MySqlCommand cmd = new MySqlCommand("call delete_student('"+r+"')", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            cmd.Dispose();
            Show_data(conn);
        }

        public void Show_data(MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand("call show_students_list()", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Console.WriteLine("Student's rollno, name is: " + ds.Tables[0].Rows[i]["roll_no"] + ", " + ds.Tables[0].Rows[i]["name"]);
                }
            }
            cmd.Dispose();
        }
        static void Main(string[] args)
        {
            Program obj = new Program();

            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=school;password=Sumit@1006762");
            conn.Open();
            Console.WriteLine("Initial data in Table student:");
            MySqlCommand cmd = new MySqlCommand("call show_students_list()", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Console.WriteLine("Student's rollno, name is: " + ds.Tables[0].Rows[i]["roll_no"] + ", " + ds.Tables[0].Rows[i]["name"]);
                }
            }
            cmd.Dispose();

            Boolean work = true;
            while (work)
            {
                Console.WriteLine("Enter 1 to insert new student, 2 to delete existing student, 3 to see the list of all students and 4 to exit the program: ");
                int selection = Convert.ToInt32(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        obj.Insert_data(conn);
                        break;
                    case 2:
                        obj.Delete_data(conn);
                        break;
                    case 3:
                        obj.Show_data(conn);
                        break;
                    case 4:
                        work = false;
                        break;
                }
            }
            Console.ReadKey();
            conn.Close();
        }
    }
}
