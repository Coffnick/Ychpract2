using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ychpract2
{
    class Db
    {
        SqlConnection connection = new SqlConnection(@"Data Source =DESKTOP-2J8B4QQ\COFFNICK; Initial Catalog = Warehouse; Integrated Security = True;MultipleActiveResultSets=True;TrustServerCertificate=True");

        public void openCon()// открытие соеденеия с бд
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

        }

        public void closeCon()// закрытие соеденеия с бд
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public SqlConnection getConnection()// получения соеденеия с бд
        {
            return connection;
        }

    }
}
