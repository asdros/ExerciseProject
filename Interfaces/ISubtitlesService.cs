using ExerciseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseProject.Interfaces
{
    public interface ISubtitlesService
    {
        Task<int> Create(SubtitlesFile subtitles);
        Task<int> Delete(Guid id);
        Task<int> Count(string search);
        Task<int> Update(SubtitlesFile movie);
        Task<UploadedFile> GetById(Guid id);
        Task<List<SubtitlesFile>> ListByMovieId(Guid id, int skip, int take,
            string orderBy, string direction, string search);
    }
}
