using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace ExerciseProject.Interfaces
{
    public interface IDapperService : IDisposable
    {
        DbConnection GetConnection();
        T Get<T>(string sp, CommandType commandType = CommandType.Text);
        List<T> GetAll<T>(string sp, CommandType commandType = CommandType.Text);
        int Execute(string sp, CommandType commandType = CommandType.Text);
        T Insert<T>(string sp, CommandType commandType = CommandType.Text);
        T Update<T>(string sp, CommandType commandType = CommandType.Text);
    }
}
