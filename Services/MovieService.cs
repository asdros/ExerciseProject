using Dapper;
using ExerciseProject.Interfaces;
using ExerciseProject.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseProject.Services
{
    public class MovieService : IMovieService
    {
        private readonly IDapperService _dapperService;
        public MovieService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }
        public Task<int> Create(Movie movie)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Title", movie.Title, DbType.String);
            dbPara.Add("YearOfProduction", movie.YearOfProduction, DbType.Int16);
            dbPara.Add("OriginalSoundtrack", movie.OriginalSoundtrack, DbType.String);
            dbPara.Add("Genre", movie.Genre, DbType.String);
            dbPara.Add("DirectorID", movie.DirectorID, DbType.Int32);
            dbPara.Add("Description", movie.Description, DbType.String);
            dbPara.Add("OtherTitles", movie.OtherTitles, DbType.String);
            dbPara.Add("CreatedAt", DateTime.UtcNow, DbType.DateTime);
            var movieId = Task.FromResult
               (_dapperService.Insert<int>("[dbo].[spAddPublisher]",
               dbPara, commandType: CommandType.StoredProcedure));
            return movieId;
        }
        public Task<Movie> GetById(Guid id)
        {
            var movie = Task.FromResult
               (_dapperService.Get<Movie>
               ($"select * from [Movie] where Id = {id}", null,
               commandType: CommandType.Text));
            return movie;
        }
        public Task<int> Delete(Guid id)
        {
            var deletePublisher = Task.FromResult
               (_dapperService.Execute
               ($"Delete [Publisher] where Id = {id}", null,
               commandType: CommandType.Text));
            return deletePublisher;
        }
        public Task<int> Count(string search)
        {
            var totPublisher = Task.FromResult(_dapperService.Get<int>
               ($"select COUNT(*) from [Movie] WHERE Title like '%{search}%'", null,
               commandType: CommandType.Text));
            return totPublisher;
        }
        public Task<List<Movie>> ListAll(int skip, int take,
           string orderBy, string direction = "DESC", string search = "")
        {
            var movies = Task.FromResult
               (_dapperService.GetAll<Movie>
               ($"SELECT * FROM [Movie] WHERE Title like'%{search}%' ORDER BY {orderBy} {direction} " +
               $"OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY; ", null, commandType: CommandType.Text));
           return movies;
        }
        public Task<int> Update(Movie movie)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Title", movie.Title, DbType.String);
            dbPara.Add("YearOfProduction", movie.YearOfProduction, DbType.Int16);
            dbPara.Add("OriginalSoundtrack", movie.OriginalSoundtrack, DbType.String);
            dbPara.Add("Genre", movie.Genre, DbType.String);
            dbPara.Add("DirectorID", movie.DirectorID, DbType.Int32);
            dbPara.Add("Description", movie.Description, DbType.String);
            dbPara.Add("OtherTitles", movie.OtherTitles, DbType.String);
            dbPara.Add("CreatedAt", DateTime.UtcNow, DbType.DateTime);
            var updatePublisher = Task.FromResult
               (_dapperService.Update<int>("[dbo].[spUpdatePublisher]",
               dbPara, commandType: CommandType.StoredProcedure));
            return updatePublisher;
        }
    }
}

