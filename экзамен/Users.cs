using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class Users : Database
    {
        public Users()
        {
            connect = "server = localhost; user = root; database = employee;";
            connection = new MySql.Data.MySqlClient.MySqlConnection(connect);
        }
    }
}
