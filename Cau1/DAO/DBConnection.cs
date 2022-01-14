using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.DAO
{
    public class DBConnection
    {
        public DBConnection() { }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=LAPTOP-BV18R5O2\SQLEXPRESS;
                                                    Initial Catalog=HR; User Id=sa; Password=123456";
            return conn;
        }
    }
}
