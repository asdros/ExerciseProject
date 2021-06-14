using ExerciseProject.Interfaces;
using ExerciseProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ExerciseProject.Services
{
    public class SubtitlesService : ISubtitlesService
    {
        private readonly IDapperService _dapperService;
        private readonly IConfiguration _configuration;

        public SubtitlesService(IDapperService dapperService, IConfiguration configuration)
        {
            _configuration = configuration;
            _dapperService = dapperService;
        }

        public Task<int> Count(string search)
        {
            var subtitlesCount = Task.FromResult(_dapperService.Get<int>
               ($"SELECT COUNT(*) FROM [Subtitles] LEFT OUTER JOIN [UploadedFile] ON [Subtitles].[Id] = [UploadedFile].[IdFile] WHERE [Subtitles].[Title] LIKE '%{search}%' OR [UploadedFile].[Filename] LIKE '%{search}%'",
               commandType: CommandType.Text));
            return subtitlesCount;
        }

        public Task<int> Create(SubtitlesFile subtitles)
        {
           var subtitlesFileId = InsertFile(subtitles);
            var subtitlesId = Task.FromResult
   (_dapperService.Insert<int>($"INSERT INTO [dbo].[Subtitles] ([Title] ,[Description] ,[Language] ,[MovieId] ,[AddedOn] ,[SubtitlesFileId]) VALUES ('{subtitles.Title}','{subtitles.Description}','{subtitles.Language}',CAST('{subtitles.MovieID}' AS UNIQUEIDENTIFIER),'{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}', CAST('{subtitlesFileId}' AS UNIQUEIDENTIFIER));",
    commandType: CommandType.Text));
            return subtitlesId;
        }

        private Guid? InsertFile(SubtitlesFile subtitles)
        {
            Guid? subtitlesFileId = null;
            if (subtitles.Filename != null && subtitles.Filename.Length > 0)
            {
                subtitlesFileId = (Guid)_dapperService.Insert<Guid>($"INSERT INTO [dbo].[UploadedFile]([Filename], [FileData]) OUTPUT inserted.IdFile VALUES('{subtitles.Filename}', 0)",
                   commandType: CommandType.Text);
            }
            return subtitlesFileId;
        }

        public Task<int> Delete(Guid id)
        {
            var deleteSubtitles = Task.FromResult
               (_dapperService.Execute
               ($"Delete [Subtitles] where Id = CAST('{id}' AS UNIQUEIDENTIFIER)",
               commandType: CommandType.Text));
            return deleteSubtitles;
        }

        public Task<UploadedFile> GetById(Guid id)
        {   // TODO download file
            var subtitlesFile = Task.FromResult
                (_dapperService.Get<UploadedFile>
                ($"SELECT [UploadedFile].[Filename], [UploadedFile].[FileData] FROM [UploadedFile] WHERE [UploadedFile].[IdFile] = CAST('{id}' AS UNIQUEIDENTIFIER)",
                commandType: CommandType.Text));
            return subtitlesFile;
        }

        public Task<List<SubtitlesFile>> ListByMovieId(Guid id, int skip, int take, string orderBy, string direction = "DESC", string search = "")
        {
            var subtitles = Task.FromResult
                           (_dapperService.GetAll<SubtitlesFile>
                           ($"SELECT [Subtitles].*, [UploadedFile].[Filename], [UploadedFile].[FileData] FROM [Subtitles] JOIN [UploadedFile] ON [Subtitles].[SubtitlesFileId] = [UploadedFile].[IdFile] WHERE [Subtitles].[MovieID] = CAST('{id}' AS UNIQUEIDENTIFIER) AND [Subtitles].[Title] LIKE '%{search}%' ORDER BY {orderBy} {direction} " +
                           $"OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY; ", commandType: CommandType.Text));
            return subtitles;
        }

        public Task<int> Update(SubtitlesFile movie)
        {
            throw new NotImplementedException();
        }
    }
}
