using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AndrewLipman_Integrative2
{
    public class GetData
    {
        //class fields
        GetData[] allData = null;
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int ReviewScore { get; set; }
        public int PossibleReviewScore { get; set; }
        public string ReviewText { get; set; }
        public string ReviewColor { get; set; }

        //constructor method to save data to array
        public void LoadData()
        {

            // MySQL Database Connection String
            string cs = @"server=10.63.56.143;userid=dbsAdmin1901;password=password;database=RestaurauntDB;port=8889";

            // Declare a MySQL Connectiond

       
            
            MySqlConnection conn = null;

            try
            {
                // Open a connection to MySQL
                conn = new MySqlConnection(cs);
                conn.Open();

                // Form SQL Statement
                string stm = "SELECT * From RestaurauntDB.RestaurantReviews;";

                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                // Execute SQL statement and place the returned data into rdr
                MySqlDataReader rdr = cmd.ExecuteReader();
                {
                    var list = new List<GetData>();
                    while (rdr.Read())

                        list.Add(new GetData
                        {
                            Id = DBchecks.CheckDBint(rdr, 0),
                            RestaurantId = DBchecks.CheckDBint(rdr, 1),
                            ReviewScore = DBchecks.CheckDBint(rdr, 2),
                            PossibleReviewScore = DBchecks.CheckDBint(rdr, 3),
                            ReviewText = DBchecks.CheckDBString(rdr, 4),
                            ReviewColor = DBchecks.CheckDBString(rdr, 5)
                        });
                    allData = list.ToArray();

                    //forloop to display test
                    for (int i = 0; i < allData.Length; i++)
                    {
                        Console.WriteLine(i);
                    }
                }

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
        }
        
       

    }
}


