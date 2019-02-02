using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndrewLipman_TimeTrackerApp
{
    class Program
    {
        static void Main(string[] args)
        {

            /*Andrew Lipman
             * January 30, 2019
             * MDV229
             * TimeTrackerApplication
             **/

            //clear console
            Console.Clear();

            //call db connection
            TimeTrackDB db = new TimeTrackDB();

            //greet user with welcome message
            Console.WriteLine("Hello");

            string dbstring = "Select * From AndrewLipman_MDV229_DB.time_tracker_users;";

            db.PullInfo(dbstring);


            Console.ReadKey();
        }
    }
}
