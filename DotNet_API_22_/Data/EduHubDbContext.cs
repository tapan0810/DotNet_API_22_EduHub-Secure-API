using DotNet_API_22_.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet_API_22_.Data
{
    public class EduHubDbContext:DbContext
    {
        public EduHubDbContext(DbContextOptions<EduHubDbContext>options):base(options) { }
        public DbSet<School> Schools => Set<School>();
        public DbSet<User> Users => Set<User>();
    }
}
