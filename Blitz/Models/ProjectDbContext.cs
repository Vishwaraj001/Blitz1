using Microsoft.EntityFrameworkCore;

namespace Blitz.Models
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("UsersTable").HasKey(o => o.U_EmailId);
           
        }
        public DbSet<UserModel> UsersTable { get; set; }

        
    }
}
