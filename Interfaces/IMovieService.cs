using ExerciseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseProject.Interfaces
{
    public interface IMovieService
    {
        Task<int> Create(Movie movie);
        Task<int> Delete(Guid id);
        Task<int> Count(string search);
        Task<int> Update(Movie movie);
        Task<Movie> GetById(Guid id);
        Task<List<MovieDirector>> ListAll(int skip, int take,
            string orderBy, string direction, string search);
    }
}
