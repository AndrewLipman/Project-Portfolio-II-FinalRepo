using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;



namespace AndrewLipman_TimeTrackerApp
{
    class TimeTrackDB
    {
        public TimeTrackDB()
        {
           
        }
        public void PullInfo(string input)
        {
            //open connection to mysql
            string cs = "server=92.168.0.13;userid=admin'@'%;password=password;database=AndrewLipman_MDV229_DB;port=8889";

            //declare connection
            MySqlConnection connection = null;

            try
            {
                //open a connection to mysql
                connection = new MySqlConnection(cs);
                connection.Open();

                //SQLstatement
                string stm = input;

                MySqlCommand cmd = new MySqlCommand(stm, connection);

                //reader
                MySqlDataReader reader = cmd.ExecuteReader();
                {
                    
                }

            }
            catch(MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally
            {
                if(connection!= null)
                {
                    connection.Close();
                }
            }
        }
    }
}
