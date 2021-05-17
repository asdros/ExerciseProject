using Microsoft.EntityFrameworkCore;

namespace ExerciseProject.Services
{
    public class AppContext : DbContext
    {
        public AppContext()
        {

        }

        public AppContext(DbContextOptions<AppContext> options):
            base(options)
        {

        }
    }
}
