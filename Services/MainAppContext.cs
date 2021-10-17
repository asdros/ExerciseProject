using ExerciseProject.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExerciseProject.Services
{
    public class MainAppContext : IdentityDbContext
    {
        public MainAppContext()
        {

        }

        public MainAppContext(DbContextOptions<MainAppContext> options):
            base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
