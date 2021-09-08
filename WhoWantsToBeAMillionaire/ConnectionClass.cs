using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WhoWantsToBeAMillionaire
{
    public static class ConnectionClass
    {
        public static MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;user=root;database=millonaire;password=");
    }
}
