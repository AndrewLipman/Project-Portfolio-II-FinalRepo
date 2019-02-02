using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AndrewLipman_Integrative2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Andrew Lipman
             *January 10, 2019
             * MDV229
             * Integrative 2
             * Convert SQL to JSON
             */

            //clear console
            Console.Clear();

            //bool to control menu
            bool running = true;

            //db connection
            DBconnec databaseConnection = new DBconnec();
            GetData newData = new GetData();
            


            //Create menu for user selection
            Console.WriteLine("Hello Admin, what would you like to do today?");

            while (running)
            {
                //display menu
                Console.WriteLine("Menu Options:" +
                    "\r\n1.Convert the Restaurant Reviews Database From SQL to JSON" +
                    "\r\n2.Showcase Our Five Star Rating System" +
                    "\r\n3.Showcase Our Animated Bar Graph System" +
                    "\r\n4.Play A Card Game" +
                    "\r\n5.Exit");
                //create variable for user selection
                string userSelectionString = Console.ReadLine().ToLower();

                //Switch statement for menu optinons
                switch (userSelectionString)
                {
                    case "1":
                    case "convert the restaurant reviews database from sql to json":
                        {


                            newData.LoadData();
                            Console.WriteLine("Restaurant Reviews Database Successfully Converted to JSON!");

                        }
                        break;
                    case "2":
                    case "showcase our five star rating system":
                        {
                            //Display menu
                            Console.WriteLine("Hello Admin, How would you like to sort the data:" +
                                "\r\n1.List Restaurants Alphabetically(Show Rating Next To Name)" +
                                "\r\n2.List Restaurants in Reverse Alphabetical(Show Rating Next To Name)" +
                                "\r\n3.Sort Restaurants From Best/Most Stars to Worst(Show Rating Next To Name)" +
                                "\r\n4.Sort Restaurants From Worst/Least(Show Rating Next To Name)" +
                                "\r\n5.Show only X and Up");

                            //Create varible for user selection
                            string userSelectionTwoString = Console.ReadLine().ToLower();

                            //switch statement for sub menu
                            switch (userSelectionTwoString)
                            {

                                case "1":
                                case "list restaurants alphabetically(show rating next to mine)":
                                    {
                                        
                                    }
                                    break;
                                case "2":
                                case "list restaurants in reverse alphabetical(show rating next to name)":
                                    {

                                    }
                                    break;
                                case "3":
                                case "sort restaurants from best/most starts to worst(show rating next to name)":
                                    {

                                    }
                                    break;
                                case "4":
                                case "show only x and up":
                                    {

                                    }
                                    break;
                                case "5":
                                case "exit":
                                    {
                                        //display sub menu
                                        Console.WriteLine("1.Show the Best(5 stars)" +
                                            "\r\n2.Show 4 Stars and Up" +
                                            "\r\n3.Show 3 Stars and Up" +
                                            "\r\n4.Show the Worst(1 Stars)" +
                                            "\r\n5.Show Unrated" +
                                            "\r\n6.Back");

                                        //create variable for user selection
                                        string userSelectionThreeString = Console.ReadLine().ToLower();

                                        //switch statement for sub menu
                                        switch (userSelectionThreeString)
                                        {
                                            case "1":
                                            case "show the best(5 stars)":
                                                {

                                                }
                                                break;
                                            case "2":
                                            case "show 4 stars and up":
                                                {

                                                }
                                                break;
                                            case "3":
                                            case "show 3 stars and up:":
                                                {

                                                }
                                                break;
                                            case "4":
                                            case "show the worst(1 stars)":
                                                {

                                                }
                                                break;
                                            case "5":
                                            case "show unrated":
                                                {

                                                }
                                                break;
                                            case "6":
                                            case "back":
                                                {

                                                }
                                                break;       
                                        }
                                    }
                                    break;
                                case "6":
                                case "back":
                                    {
                                        
                                    }
                                    break;                               
                            }
                              
                        }
                        break;
                    case "3":
                    case "showcase our animated bar graph system":
                        {

                        }
                        break;
                    case "4":
                    case "play a card game":
                        {

                        }
                        break;
                    case "5":
                    case "exit":
                        {
                            running = false;
                            Console.WriteLine("Thankyou! Have a nice day!");
                        }
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
