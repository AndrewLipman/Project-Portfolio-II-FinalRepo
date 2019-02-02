using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AndrewLipmanQuoteApplication
{
    class Login
    {
        DBconnect conn = new DBconnect();
        public Login()
        {
            
            //inform user what to do
            Console.WriteLine("please log in or create a new account to continue.");

            //menu for options
            Console.WriteLine("1.Log In" +
                "\r\n2.Create Account");

            //variable to hold user selection
            string userSelection = Console.ReadLine().ToLower();
            
            //switch statement for menu options
            switch (userSelection)
            {
                case "1":
                case "log in":
                    {
                        Console.Clear();
                        //request log in information from user
                        Console.WriteLine("First please type in your user name and press enter.");

                        //catch response
                        string userName = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("Next, please type in your password and press enter.");

                        string userPassword = Console.ReadLine();

                        MySqlConnection conn = new MySqlConnection(@"server=192.168.0.4;userid=admin;password=password;database=AndrewLipmanCustomDatabase;port=8889");
                        conn.Open();
                        LoginMethod(conn, userName, userPassword);
                        conn.Close();
                        Console.ReadKey();
                    }
                    break;
                case "2":
                case "create account":
                    {
                        Console.Clear();
                        //request new user name
                        Console.WriteLine("To create a new account please type in a user name and press enter.");

                        //catch response
                        string userNameString = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(userNameString))
                        {
                            Console.WriteLine("Please do not leave this space blank. Type in a username and press enter.");
                            userNameString = Console.ReadLine();
                        }

                        Console.Clear();
                        //request new user password
                        Console.WriteLine("Please type in a new password and press enter.");

                        //catch response
                        string userPasswordString = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(userPasswordString))
                        {
                            Console.WriteLine("Please do not leave this space blank. type in a user password and press enter.");
                            userPasswordString = Console.ReadLine();
                        }
                        MySqlConnection conn = new MySqlConnection(@"server=192.168.0.4;userid=admin;password=password;database=AndrewLipmanCustomDatabase;port=8889");
                        conn.Open();

                        CreateAccount(conn, userNameString, userPasswordString);
                        conn.Close();
                        Console.ReadKey();

                    }
                    break;
                default:
                    Console.WriteLine("Please onlly make a selection from the options above");
                    break;
            }


        }
        //login method
        public void LoginMethod(MySqlConnection conn, string userName, string password)
        {

            string stm = "SELECT userName, userPassword from users where userName = @userName AND userPassword = @userPassword;";
            // Prepare SQL Statement
            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@userPassword", password);
            // Execute SQL statement and place the returned data into rdr
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                userName = Convert.ToString(rdr["userName"]);
                password = Convert.ToString(rdr["userPassword"]);
                rdr.Close();
                Console.WriteLine($"Login Successful! Hello {userName}!!!");
                
            }
            else
            {
                Console.WriteLine("Login failed");
                
            }
            rdr.Close();
        }
        //create account method
        public void CreateAccount(MySqlConnection conn, string userName, string userPassword)
        {
            //SQL statement

            string stm = "INSERT INTO Users(userName, userPassword) VALUES(@userName1, @userPassword1)";

            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.Parameters.AddWithValue("@userName1", userName);
            cmd.Parameters.AddWithValue("@userPassword1", userPassword);

            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Close();

            Console.WriteLine($"User Creation Successful!!! Hello {userName}");
            
        }
    }
}

