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
                return connection.Query<Task>("select * from Task Where IsDeleted is null or IsDeleted = 0 order by CreatedAt Desc"); 
            }
        }

        public Task GetTask(int id)
        {
            using (var connection = GetSqlConnection())
            {
                return connection.Query<Task>("select * from Task where TaskId = @id", new { id = id }).Single();
            }
        }

        public void UpdateTask(Task t)
        {
            using (var connection = GetSqlConnection())
            {
                connection.Execute("update Task set Description = @Description, UpdatedAt = @UpdatedAt, CreatedAt = @CreatedAt, CompletedAt = @CompletedAt where TaskId = @TaskId", t);
            }
        }

        public void CreateTask(string description)
        {
            var now = DateTime.Now;

            using (var connection = GetSqlConnection())
            {
                connection.Execute("insert into Task (Description, UpdatedAt, CreatedAt) Values (@Description, @UpdatedAt, @CreatedAt)",
                    new { Description = description, UpdatedAt = now, CreatedAt = now });
            }
        }

        public void DeleteTask(int id)
        {
            using (var connection = GetSqlConnection())
            {
                connection.Execute("update Task set IsDeleted = 1 where TaskId = @id", new { id = id });
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