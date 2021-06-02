using ExerciseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseProject.Interfaces
{
    public interface IDirectorService
    {
        Task<int> Create(Director director);
        Task<int> Delete(Guid id);
        Task<int> Count(string search);
        Task<int> Update(Director director);
        Task<Director> GetById(Guid id);
        Task<List<Director>> ListAll(int skip, int take,
            string orderBy, string direction, string search);
        Task<List<Director>> FetchAll();
    }
}
