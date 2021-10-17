using Dapper;
using ExerciseProject.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace ExerciseProject.Services
{
    public class DapperService : IDapperService
    {
        private readonly IConfiguration _config;
        public DapperService(IConfiguration config)
        {
            _config = config;
        }
        public DbConnection GetConnection()
        {
            return new SqlConnection
               (_config.GetConnectionString("DefaultConnection"));
        }
        public T Get<T>(string sp, CommandType commandType = CommandType.Text)
        {
            using IDbConnection db = new SqlConnection
               (_config.GetConnectionString("DefaultConnection"));
            return db.Query<T>(sp, commandType: commandType).FirstOrDefault();
        }
        public List<T> GetAll<T>(string sp, CommandType commandType = CommandType.Text)
        {
            using IDbConnection db = new SqlConnection
               (_config.GetConnectionString("DefaultConnection"));
            return db.Query<T>(sp, commandType: commandType).ToList();
        }
        public int Execute(string sp, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection
               (_config.GetConnectionString("DefaultConnection"));
            return db.Execute(sp, commandType: commandType);
        }
        public T Insert<T>(string sp, CommandType commandType = CommandType.Text)
        {
            T result;
            using IDbConnection db = new SqlConnection
               (_config.GetConnectionString("DefaultConnection"));
            IDbCommand command = db.CreateCommand();
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, commandType:
                       commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (DataException ex)
                {
                    tran.Rollback();
                    throw new DataException($"Unable to execute the query: {ex}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to connect with database: {ex}");
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return result;
        }
        public T Update<T>(string sp, CommandType commandType = CommandType.Text)
        {
            T result;
            using IDbConnection db = new SqlConnection
               (_config.GetConnectionString("DefaultConnection"));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, commandType:
                       commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (DataException ex)
                {
                    tran.Rollback();
                    throw new DataException($"Unable to execute the query: {ex}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to connect with database: {ex}");
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return result;
        }
        public void Dispose()
        {
        }
    }
}

