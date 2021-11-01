using ExerciseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseProject.Interfaces
{
    public interface IMovieService
    {
        Task<int> Create(MovieView movie);
        Task<int> Delete(Guid id, string table);
        Task<int> Count(string search);
        Task<int> Update(MovieView movie, string table);
        Task<MovieView> GetById(Guid id, string table);
        Task<int> DeletePoster(Guid? id);
        Task<List<MovieDirector>> ListAll(int skip, int take,
            string orderBy, string direction, string search);
        Task<int> UpdateStatus(Guid id, bool Status);

    }
}
