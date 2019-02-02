using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace AndrewLipmanQuoteApplication
{
    class Quotes
    {
        //create database instance
        DBconnect conn = new DBconnect();

        //constructor
        public Quotes()
        {

        }

        //method to show the user a random quote and author
        public void SeeRandomQuote(MySqlConnection conn)
        {

            //sql statemnt
            string stm = "SELECT quoteId, QUOTE, QUOTEAUTHOR FROM Quotes " +
            "ORDER BY RAND() " +
            "LIMIT 1 ";

            //mysql connection
            MySqlCommand cmd = new MySqlCommand(stm, conn);

            //reader
            MySqlDataReader rdr = cmd.ExecuteReader();

            {
                while (rdr.Read())
                {
                    //convert to readable data
                    string quote = (string)rdr["quote"];
                    string quoteAuthor = (string)rdr["quoteAuthor"];

                    // Print the data.
                    Console.WriteLine(
                        $"\r\nQuote: {quote}" +
                        $"\r\n\r\nQuote Author:{quoteAuthor}");
                }
                rdr.Close();
            }
        }

        //add quote method - for users to upload their own quotes to the database
        public void AddQuote()
        {
            //prompt the user for the quote
            Console.WriteLine("You have selected to add your own quote or a favorite quote!" +
                "\r\n\r\nPlease type in the Quote first and press enter.");

            //catch response
            string userQuoteInput = Console.ReadLine();
            //validate
            while (string.IsNullOrWhiteSpace(userQuoteInput))
            {
                Console.WriteLine("Please do not leave this space blank! Please type in your quote and press enter.");
                userQuoteInput = Console.ReadLine();
            }

            //prompt the user for the author of the quote
            Console.WriteLine("Great! Now, please type in the Author of the Quote entered.");
            //catch response
            string userAuthorInput = Console.ReadLine();
            //validate
            while (string.IsNullOrWhiteSpace(userAuthorInput))
            {
                Console.WriteLine("Please do not leave this space blank! Please type in the quote's Author and press enter.");
                userAuthorInput = Console.ReadLine();
            }

            //SQL statement
            string stm = "INSERT INTO Quotes(quote, quoteAuthor) Values(@quote, @quoteAuthor)";

            //open database connection
            MySqlConnection conn = new MySqlConnection(@"server=192.168.0.4;userid=admin;password=password;database=AndrewLipmanCustomDatabase;port=8889");
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.Parameters.AddWithValue("@quote", userQuoteInput);
            cmd.Parameters.AddWithValue("@quoteAuthor", userAuthorInput);

            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Close();

            Console.WriteLine($"New Quote Added:" +
                $"\r\n{userQuoteInput}" +
                $"\r\nBy: {userAuthorInput}");
            Console.ReadKey();


        }

    }
}
