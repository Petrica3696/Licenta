using DataAccess.Read.Abstractions;
using Models.Read;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using System.Linq;

namespace DataAccess.Read.Implementations
{
    public class Repository : IRepository
    {
        private readonly string _connectionString;

        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected IDbConnection DbConnection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }

        public List<T> ExecuteQuery<T>(string query)
            where T : BaseModel
        {
            var dbConnection = DbConnection;
            dbConnection.Open();
            var result = dbConnection.Query<T>(query).ToList();
            dbConnection.Close();

            return result;
        }

        public T ExecuteQueryFirstOrDefault<T>(string query) 
            where T : BaseModel
        {
            var dbConnection = DbConnection;
            dbConnection.Open();
            var result = dbConnection.QueryFirstOrDefault<T>(query);
            dbConnection.Close();

            return result;
        }
    }
}
