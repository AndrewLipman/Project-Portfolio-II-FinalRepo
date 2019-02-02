using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AndrewLipman_Integrative2
{
    static class DBchecks
    {
       
        public static int CheckDBint(MySqlDataReader rdr, int columnIndex)
        {
            if (!rdr.IsDBNull(columnIndex))
            {

                return rdr.GetInt32(columnIndex);
            }
            else
            {
                return -1;
            }
        }
        public static string CheckDBString(MySqlDataReader rdr, int columnIndex)
        {
            if (!rdr.IsDBNull(columnIndex))
            {
                return rdr.GetString(columnIndex);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
