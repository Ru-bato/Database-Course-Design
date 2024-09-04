using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DB_Backend.DB_BackendDAL
{
    internal class AccommodateServer
    {
        //public static string conStr = Environment.GetEnvironmentVariable("MYDATABASE");
        public static string conStr = "User ID=system;Password=Db_12306;Data Source=47.100.21.14:1521/orcl";

    }
}
