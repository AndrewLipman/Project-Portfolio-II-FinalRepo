using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AndrewLipman_Integrative2
{
    class DBconnec
    {
        public DBconnec()
        {

        }
        public void ConnectDB()
        {
            Console.WriteLine("Start\n");

            // MySQL Database Connection String
            string cs = @"server=10.63.11.95;userid=dbsAdmin1901;password=password;database=RestaurauntDB;port=8889";

            // Declare a MySQL Connection
            MySqlConnection conn = null;

            try
            {
                // Open a connection to MySQL
                conn = new MySqlConnection(cs);
                conn.Open();

                // Form SQL Statement
                string stm = "SELECT id AS [RestaurantReviews.`id`], RestaurantNumber AS [RestaurantReviews.`RestaurantId`]," +
                    " ReviewScore AS[RestarauntReviews.`ReviewScore`], PossibleReviewScore AS [RestarauntReviews.`PossibleReviewScore`]," +
                    "ReviewText AS[RestaurantReviews.`ReviewText`], ReviewColor AS [RestaurantReviews.`ReviewColor`] From RestaurauntReviews" +
                    "FOR JSON PATH, ROOT('RestaurantReviews');";

                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                // Execute SQL statement and place the returned data into rdr
                MySqlDataReader rdr = cmd.ExecuteReader();


            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            Console.WriteLine("Done");
        }
    }
}
