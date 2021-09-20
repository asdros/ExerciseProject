using ExerciseProject.Interfaces;
using ExerciseProject.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
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
        private Guid? CreatePoster(MovieView movie)
        {
            Guid? posterId = null;
            if (movie.FileData != null && movie.FileData.Length > 0)
            {
                posterId = (Guid)_dapperService.Insert<Guid>($"INSERT INTO [dbo].[UploadedFile]([Filename], [FileData]) OUTPUT inserted.IdFile VALUES('{movie.Filename}', CONVERT(VARBINARY(MAX), '{movie.FileData}', 0))",
                   commandType: CommandType.Text);
            }
            return posterId;
        }
        public Task<int> Create(MovieView movie)
        {
            var posterId = CreatePoster(movie);
            var movieId = Task.FromResult
   (_dapperService.Insert<int>($"INSERT INTO [dbo].[Movie] ([Title] ,[YearOfProduction] ,[OriginalSoundtrack] ,[Genre] ,[DirectorID] ,[Description] ,[OtherTitles] ,[CreatedAt] ,[PosterId]) VALUES ('{movie.Title}',{movie.YearOfProduction},'{movie.OriginalSoundtrack}','{movie.Genre}',CAST('{movie.DirectorID}' AS UNIQUEIDENTIFIER),'{movie.Description}','{movie.OtherTitles}','{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}', TRY_CAST('{posterId}' AS UNIQUEIDENTIFIER));",
    commandType: CommandType.Text));
            return movieId;
        }

        public Task<MovieView> GetById(Guid id)
        {
            var movie = Task.FromResult
               (_dapperService.Get<MovieView>
               ($"SELECT [Movie].*, [Director].[Firstname], [Director].[Surname], [UploadedFile].[Filename], [UploadedFile].[FileData] FROM [Movie] LEFT OUTER JOIN [Director] ON [Movie].[DirectorID] = [Director].[Id] LEFT OUTER JOIN [UploadedFile] ON [Movie].[PosterId] = [UploadedFile].[IdFile]WHERE [Movie].[Id] = CAST('{id}' AS UNIQUEIDENTIFIER)",
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
            var movieCount = Task.FromResult(_dapperService.Get<int>
               ($"select COUNT(*) from [Movie] WHERE Title like '%{search}%'",
               commandType: CommandType.Text));
            return movieCount;
        }

        public Task<List<MovieDirector>> ListAll(int skip, int take,
           string orderBy, string direction = "DESC", string search = "")
        {
            var movies = Task.FromResult
               (_dapperService.GetAll<MovieDirector>
               ($"SELECT [Movie].*, [Director].[Firstname], [Director].[Surname] FROM [Movie] LEFT OUTER JOIN [Director] ON [Movie].[DirectorID] = [Director].[Id] WHERE Title like'%{search}%' OR [Director].[Surname] like '%{search}%' ORDER BY {orderBy} {direction} " +
               $"OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY; ", commandType: CommandType.Text));
            return movies;
        }

        public Task<int> Update(MovieView movie)
        {
            var posterId = CreatePoster(movie);
            var updateMovie = Task.FromResult
               (_dapperService.Update<int>($"UPDATE [dbo].[Movie] SET [Title] = '{movie.Title}', [YearOfProduction] = '{movie.YearOfProduction}', [OriginalSoundtrack] = '{movie.OriginalSoundtrack}', [Genre] = '{movie.Genre}', [DirectorID] = '{movie.DirectorID}', [Description] = '{movie.Description}', [OtherTitles] = '{movie.OtherTitles}', [CreatedAt] = '{DateTime.UtcNow:yyyy - MM - dd HH: mm:ss}', [PosterId] = TRY_CAST('{posterId}' AS UNIQUEIDENTIFIER) WHERE [Id] = CAST('{movie.ID}' AS UNIQUEIDENTIFIER)", commandType: CommandType.Text)); //todo
            return updateMovie;
        }

        public Task<int> DeletePoster(Guid? id)
        {
            var deletePoster = Task.FromResult
                    (_dapperService.Execute
                    ($"Delete [UploadedFile] where IdFile = CAST('{id}' AS UNIQUEIDENTIFIER)",
                    commandType: CommandType.Text));
            return deletePoster;
        }

        public Task<int> UpdateStatus(Guid id, bool value)
        {
            bool newStatus = !value;
            var movie = Task.FromResult
                (_dapperService.Update<int>($"UPDATE [dbo].[Movie] SET [isApproved] = '{newStatus}' WHERE [Id] = CAST('{id}' AS UNIQUEIDENTIFIER)"));
            return movie;
        }
    }
}

