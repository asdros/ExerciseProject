using ExerciseProject.Interfaces;
using ExerciseProject.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ExerciseProject.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IDapperService _dapperService;
        private readonly IConfiguration _configuration;

        public DirectorService(IDapperService dapperService, IConfiguration configuration)
        {
            _configuration = configuration;
            _dapperService = dapperService;
        }

        public Task<int> Count(string search)
        {
            var directorCount = Task.FromResult(_dapperService.Get<int>
                          ($"select COUNT(*) from [Director] WHERE Surname like '%{search}%'",
                          commandType: CommandType.Text));
            return directorCount;
        }

        public Task<int> Create(Director director)
        {
            var directorId = Task.FromResult
   (_dapperService.Insert<int>($"INSERT INTO [dbo].[Director] ([Firstname], [Surname]) VALUES ('{director.Firstname}', '{director.Surname}');",
    commandType: CommandType.Text));
            return directorId;
        }

        public Task<int> Delete(Guid id)
        {
            var deleteDirector = Task.FromResult
               (_dapperService.Execute
               ($"Delete [Director] where Id = CAST('{id}' AS UNIQUEIDENTIFIER)",
               commandType: CommandType.Text));
            return deleteDirector;
        }

        public Task<List<Director>> FetchAll()
        {
            var directors = Task.FromResult
                (_dapperService.GetAll<Director>
                ("Select * from [Director] Order by Surname; ",
                commandType: CommandType.Text));
            return directors;
        }

        public Task<Director> GetById(Guid id)
        {
            var director = Task.FromResult
               (_dapperService.Get<Director>
               ($"select * from [Director] where Id = CAST('{id}' AS UNIQUEIDENTIFIER)",
               commandType: CommandType.Text));
            return director;
        }

        public Task<List<Director>> ListAll(int skip, int take, string orderBy, string direction, string search)
        {
            var directors = Task.FromResult
               (_dapperService.GetAll<Director>
               ($"SELECT * FROM [Director] WHERE Firstname like '%{search}%' or Surname like '%{search}%' ORDER BY {orderBy} {direction} " +
               $"OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY; ", commandType: CommandType.Text));
            return directors;
        }

        public Task<int> Update(Director director)
        {
            throw new NotImplementedException();
        }
    }
}
