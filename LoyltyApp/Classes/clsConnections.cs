using System;
using System.Data;

namespace LoyltyApp
{
    class clsConnections : clsVariables //Get the Static Variables in the Class clsVariables
    {
        public static string setConnectionString()
        {
            return @"Data Source=DESKTOP-NA1U314\DATA_USER; Initial Catalog=LoyalityDBApplication; User ID=user;Password=8080;";
        }

        public static void setOleDbConnectionState()//For Sql Connection
        {
            if (sOleDbConnection.State == ConnectionState.Open) sOleDbConnection.Close();
            sOleDbConnection.ConnectionString = setConnectionString();
        }
    }
}
