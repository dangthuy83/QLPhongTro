using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongTro
{
    internal class Database
    {
        private string connectionString = @"Data Source = Localhost\SQLSERVER; Initial Catalog = QLPHONGTRO; user ID = sa; password = 123";
        private SqlConnection con;
        private DataTable dt;
        private SqlCommand cmd;
    }
}
