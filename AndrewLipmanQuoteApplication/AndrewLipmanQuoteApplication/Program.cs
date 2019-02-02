using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AndrewLipmanQuoteApplication
{
    class Program
    {
        static void Main(string[] args)
        {


            //clear console
            Console.Clear();

            //this program will be designed as a simple system to allow users to randomly view a positive quote or saying throughout the day
            //Users will have the ability to log in, view a quote, add their own quotes, as well as add and remove quotes from the users favorites area.

            //greet user and welcome to program
            Console.WriteLine("Hello User, welcome to our quote program! here one can view random quotes and add new quotes to the database!");

            //instanciate connection
            DBconnect Dbconnect = new DBconnect();
            
            //user login
            Login login = new Login();   

            //bool to control switch statement menu
            bool running = true;

            while (running)
            {


                //menu options
                Console.Clear();
                Console.WriteLine("Please make a selection from below to begin");
                Console.WriteLine("1.View a Random Quote" +
                    "\r\n2.Add Your Own Quote" +
                   "\r\n3.Exit");

                //catch user response
                string userResponsestring = Console.ReadLine().ToLower();

                switch (userResponsestring)
                {
                    case "1":
                    case "view a quote":
                        {
                            MySqlConnection conn = new MySqlConnection(@"server=192.168.0.4;userid=admin;password=password;database=AndrewLipmanCustomDatabase;port=8889");
                            conn.Open();
                            Quotes newQuotes = new Quotes();
                            newQuotes.SeeRandomQuote(conn);
                            conn.Close();
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                    case "add your own quote":
                        {
                            MySqlConnection conn = new MySqlConnection(@"server=192.168.0.4;userid=admin;password=password;database=AndrewLipmanCustomDatabase;port=8889");
                            conn.Open();
                            Quotes addingquotes = new Quotes();
                            addingquotes.AddQuote();
                        }
                        break;
                    case "3":
                    case "exit":
                        {
                            running = false;
                            Console.WriteLine("Thankyou Have a nice day!");
                            Console.ReadKey();
                        }
                        break;
                    default: Console.WriteLine("Please make a selection from the available options.");
                        break;
                }



            }

            Console.Clear();
        }
    }
}
