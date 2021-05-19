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
        private readonly IConfiguration _configuration;

        public MovieService(IDapperService dapperService, IConfiguration configuration)
        {
            _configuration = configuration;
            _dapperService = dapperService;
        }
        public Task<int> Create(Movie movie)
        {
            //var movieId = Task.FromResult
            //   (_dapperService.Insert<int>($"INSERT INTO [dbo].[Movie] ([Title] ,[YearOfProduction] ,[OriginalSoundtrack] ,[Genre] ,[DirectorID] ,[Description] ,[OtherTitles] ,[CreatedAt] ,[PosterId]) VALUES ('{movie.Title}',{movie.YearOfProduction},'{movie.OriginalSoundtrack}','{movie.Genre}',CAST('{movie.DirectorID}' AS UNIQUEIDENTIFIER),'{movie.Description}','{movie.OtherTitles}','{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}',CAST('{movie.PosterID}' AS UNIQUEIDENTIFIER));",
            //    commandType: CommandType.Text));

            var movieId = Task.FromResult
   (_dapperService.Insert<int>($"INSERT INTO [dbo].[Movie] ([Title] ,[YearOfProduction] ,[OriginalSoundtrack] ,[Genre] ,[DirectorID] ,[Description] ,[OtherTitles] ,[CreatedAt] ,[PosterId]) VALUES ('{movie.Title}',{movie.YearOfProduction},'{movie.OriginalSoundtrack}','{movie.Genre}',CAST('{movie.DirectorID}' AS UNIQUEIDENTIFIER),'{movie.Description}','{movie.OtherTitles}','{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}', NULL);",
    commandType: CommandType.Text));
            return movieId;
 
        }
        public Task<Movie> GetById(Guid id)
        {
            var movie = Task.FromResult
               (_dapperService.Get<Movie>
               ($"select * from [Movie] where Id = CAST('{id}' AS UNIQUEIDENTIFIER)",
               commandType: CommandType.Text));
            return movie;
        }
        public Task<int> Delete(Guid id)
        {
            var deleteMovie = Task.FromResult
               (_dapperService.Execute
               ($"Delete [Movie] where Id = CAST('{id}' AS UNIQUEIDENTIFIER)",
               commandType: CommandType.Text));
            return deleteMovie;
        }
        public Task<int> Count(string search)
        {
            var totPublisher = Task.FromResult(_dapperService.Get<int>
               ($"select COUNT(*) from [Movie] WHERE Title like '%{search}%'",
               commandType: CommandType.Text));
            return totPublisher;
        }
        public Task<List<Movie>> ListAll(int skip, int take,
           string orderBy, string direction = "DESC", string search = "")
        {
            var movies = Task.FromResult
               (_dapperService.GetAll<Movie>
               ($"SELECT * FROM [Movie] WHERE Title like'%{search}%' ORDER BY {orderBy} {direction} " +
               $"OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY; ", commandType: CommandType.Text));
            return movies;
        }
        public Task<int> Update(Movie movie)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Title", movie.Title, DbType.String);
            dbPara.Add("YearOfProduction", movie.YearOfProduction, DbType.Int16);
            dbPara.Add("OriginalSoundtrack", movie.OriginalSoundtrack, DbType.String);
            dbPara.Add("Genre", movie.Genre, DbType.String);
            dbPara.Add("DirectorID", movie.DirectorID, DbType.Guid);
            dbPara.Add("Description", movie.Description, DbType.String);
            dbPara.Add("OtherTitles", movie.OtherTitles, DbType.String);
            dbPara.Add("CreatedAt", DateTime.UtcNow, DbType.DateTime);
            var updatePublisher = Task.FromResult
               (_dapperService.Update<int>("[dbo].[spUpdatePublisher]                                                                   ",
               dbPara, commandType: CommandType.Text));
            return updatePublisher;
        }
    }
}

