using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace TaskManager45.Models
{
    public class TaskRepository
    {
        public IEnumerable<Task> GetTasks()
        {
            using (var connection = GetSqlConnection())
            {
                return connection.Query<Task>("select * from Task"); 
            }
        }

        private SqlConnection GetSqlConnection()
        {
            var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["TaskManager45"].ConnectionString);
            cnn.Open();
            return cnn;
        }

    }
}