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
        Task<int> Delete(Guid Id);
        Task<int> Count(string search);
        Task<int> Update(Movie movie);
        Task<Movie> GetById(Guid Id);
        Task<List<Movie>> ListAll(int skip, int take,
            string orderBy, string direction, string search);
    }
}
