using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.Design;

namespace demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var x = Console.ReadLine();
            //Console.WriteLine("your name : " + x);

            //var input = Console.ReadLine();
            //var password = "tamil123";
            //if (input == password)
            //{
            //    Console.WriteLine("Welcome back");
            //}
            //else {
            //    Console.WriteLine("Please enter valid password");
            //}


            // find odd or even 
            /* int input = Convert.ToInt32(Console.ReadLine());  // convert to integer
             Console.WriteLine(input.GetType()); // Get datatype
             if (input % 2 == 0)
             {
                 Console.WriteLine("Its even number");
             }
             else
             {
                 Console.WriteLine("Its odd number");
             }*/


            /*
            // check string input
            Console.Write("Enter your fname : "); // Enter value in single line
            string str = Console.ReadLine();
            Console.Write("Enter your lname: ");
            string str1 = Console.ReadLine();
            Console.Write(str + str1); */

            /*
            //Arithmatic operators
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Addition : " + (num1+num2)); // Addition
            Console.WriteLine("Subtraction : " + (num1 - num2)); // Subtraction 
            Console.WriteLine("Multiple : " + (num1 * num2));  // Multiple
            Console.WriteLine("Divisible : " + (num1 / num2)); // Divisible  */

            /*
            //SQL Connection 
            SqlConnection conn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=User_reg_data;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM signup_info", conn);
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read()) {
                Console.WriteLine( rdr[1] + "\t" + rdr[2] + "\t" + rdr[3] + "\t" + rdr[4] + "\t" + rdr[5]);
            };


            //Just for practice
            SqlConnection connect = new SqlConnection("link");
            SqlCommand comment = new SqlCommand("SELECT * FROM table_name", connect);
            connect.Open();
            SqlDataReader rdr1 = comment.ExecuteReader();
            while (rdr1.Read())
            {
                Console.WriteLine(rdr1[0] + "\t" + rdr1[1] + "\t" + rdr[2]);
            }
           

            // Insert value into table manual
            SqlConnection conn = new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=User_reg_data;Integrated Security=True");
            String str = "INSERT INTO signup_info VALUES (12,'black', 3456, 'covai', 'india')";
            SqlCommand cmd = new SqlCommand(str, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            

            Console.Write("Enter your student id : "); 
            int student_id =int.Parse(Console.ReadLine());      //input for id
            Console.Write("Enter your name : ");
            String student_name = Console.ReadLine();           //input for studet name
            Console.Write("Enter your postal code: ");
            int postal_code = int.Parse(Console.ReadLine());    //input for postal code
            Console.Write("Enter your city name: ");
            String city = Console.ReadLine();                   //input for city
            Console.Write("Enter your country: ");
            String country = Console.ReadLine();                //input for country

            //connection and insert data
            SqlConnection conn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=User_reg_data;Integrated Security=True");
            String str = $"INSERT INTO signup_info VALUES ({student_id}, '{student_name}', {postal_code}, '{city}', '{country}' )";
            SqlCommand cmd = new SqlCommand(str, conn);
            conn.Open();
            cmd.ExecuteNonQuery();

            //show result
            cmd.CommandText = "SELECT * FROM signup_info";
            SqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                Console.WriteLine(red[1] + "\t" + red[2] + "\t" + red[3] + "\t" + red[4] + "\t" + red[5]);
            }
            */

            /*
            //UPDATE Query:
            //connection and insert data
            SqlConnection conn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=User_reg_data;Integrated Security=True");
            String str ="UPDATE signup_info SET country = 'india' WHERE student_id = 2";
            SqlCommand cmd = new SqlCommand(str, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            //show result
            cmd.CommandText = "SELECT * FROM signup_info";
            SqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                Console.WriteLine(red[1] + "\t" + red[2] + "\t" + red[3] + "\t" + red[4] + "\t" + red[5]);
            }*/


            //DELETE Query:
            //connection and insert data
            SqlConnection conn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=User_reg_data;Integrated Security=True");
            String str = "DELETE FROM signup_info WHERE student_id = 16";
            SqlCommand cmd = new SqlCommand(str, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            //show result
            cmd.CommandText = "SELECT * FROM signup_info";
            SqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                Console.WriteLine(red[1] + "\t" + red[2] + "\t" + red[3] + "\t" + red[4] + "\t" + red[5]);
            }

            Console.ReadKey();
        }
    }
}
