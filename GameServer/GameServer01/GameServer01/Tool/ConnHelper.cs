using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer01.Tool
{
    class ConnHelper
    {
        private const string CONNECTION_STRING = "datasource=127.0.0.a;port=3306;database=game03;user=root;pwd=admin";

        public static MySqlConnection Connect()
        {
            MySqlConnection conn = new MySqlConnection(CONNECTION_STRING);
            conn.Open();
            return conn;
        }

        public static void CloseConnection(MySqlConnection conn)
        {
            if (conn != null)
            {
                conn.Close();
            }
            else
            {
                Console.WriteLine("MysqlConnection is null");
            }
        }
    }
}