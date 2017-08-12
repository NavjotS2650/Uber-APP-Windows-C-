using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRANDER_01
{
    class LoginInfo
    {
        public static string username = "";
        public static string password = "";

        public static bool authenticate()
        {
           string conString = "Server=(local); Database=InClassExercises; User=PrimeUser; Password=12345";
        SqlConnection connection = new SqlConnection(conString);
            DataTable table = new DataTable();

            SqlDataAdapter adapter = adapter = new SqlDataAdapter("SELECT COUNT(*) FROM UserInfo WHERE Username='" + username +
          "' AND password='" + password + "'", connection);
            adapter.Fill(table);

            if (table.Rows[0][0].ToString() == "1")
            {
                return true;
            }

            return false;
        }
    }
}
