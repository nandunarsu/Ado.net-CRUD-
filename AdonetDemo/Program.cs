using System;
using System.Data.SqlClient;
using System.Xml.Serialization;


namespace AdonetDemo
{
    class Program
    {
        public static string connectionString = "server=DESKTOP-8Q6KN97\\SQLEXPRESS; Initial Catalog = Employeedb; Integrated Security = SSPI";
        public static SqlConnection con = new SqlConnection(connectionString);
        private static int choice;

        public static void Insert()
        {
            Console.WriteLine("Enter the student id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter student name:");
            string name= Console.ReadLine();
            Console.WriteLine("Enter student Age:");    
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter student Address:");
            string Address = Console.ReadLine();
            string insertquery = "INSERT INTO STUDENT VALUES (' " + id + " ',' " + name + " ',' " + age + " ','" + Address +"');";
            SqlCommand cmd = new SqlCommand(insertquery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Value inserted");
            con.Close();

        }
        public static void Delete()
        {
            Console.WriteLine("Enter the student id that you wnat to delete:");
            int deleteid = int.Parse(Console.ReadLine());
            string deletequery = "DELETE FROM EMPLOYEE WHERE EMPID = '" + deleteid + "'";
            SqlCommand cmd = new SqlCommand(deletequery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Deleted the row for the student id " + deleteid);
            con.Close();
        }
        public static void Display()
        {
            string displayquery = "SELECT * FROM STUDENT;";
            SqlCommand cmd = new SqlCommand(displayquery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Console.Write("Id:" + dataReader.GetValue(0) + " ");
                Console.Write("NAME:" + dataReader.GetValue(1) + " ");
                Console.Write("AGE:" + dataReader.GetValue(2) + " ");
                Console.Write("ADDRESS:" + dataReader.GetValue(3) + " ");
                Console.WriteLine();
            }
            
            Console.WriteLine("Displayed");
            con.Close();
        }

        public static void Update()
        {
            Console.WriteLine("Enter the student id you want to update");
            int cond = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter student name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter student Age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter student Address:");
            string Address = Console.ReadLine();

            string updatequery =  "UPDATE STUDENT SET NAME = '" + name + "', AGE = " + age + ", ADDRESS = '" + Address + "'  WHERE STUID = " + cond + ";";

            SqlCommand cmd = new SqlCommand(updatequery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data updated");
            con.Close();
        }

        public static void Create()
        {
            string createquery = "CREATE TABLE STUDENT ( STUID INT PRIMARY KEY, NAME VARCHAR(40), AGE INT, ADDRESS VARCHAR(100))";
            SqlCommand cmd = new SqlCommand(createquery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table created");
            con.Close();

        }

        static void Main()
        {
            do
            {
                Console.WriteLine("Enter your choice\n 1.Create\n 2.Insertion \n 3.Deletion\n 4.Update\n,5.Display\n6.Exit ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Create();
                        break;
                    case 2:
                        Insert();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        Update();
                        break;
                    case 5:
                        Display();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                }
            } while (choice <= 6);
            
        }
    }
}
