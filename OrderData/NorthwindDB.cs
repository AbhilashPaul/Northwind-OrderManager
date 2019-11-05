using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderData
{   
    public static class NorthwindDB
    {
        /// <summary>
        /// Connects to the Northwind database
        /// </summary>
        /// <param name="MachineName">name of the machine the application runs on</param>
        /// <returns> returns the connection</returns>
        public static SqlConnection GetConnection(string MachineName)                                                                       //works only if the application and server is in the same machine
        {
            string connectionString = "Data Source=" + MachineName + @"\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }

        /// <summary>
        /// Overlaoding GetConnection methode.(Works only on my machine)
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()                                                                       //works only if the application and server is in the same machine
        {
            string connectionString = @"Data Source=ICTVM-DEN0N0SLQ\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }

    }
}
