using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp2
{
    class Database
    {
        public string connect;
        public MySqlConnection connection;

        public Database()
        {
            connect = "server = localhost; user = root; database = traffic;";
            connection = new MySqlConnection(connect);
        }
    }
}
