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
            modelBuilder.Entity<ProductModel>().ToTable("ProductsTable").HasKey(o => o.Product_Id);

        }
        public DbSet<UserModel> UsersTable { get; set; }
        public DbSet<ProductModel> ProductsTable { get; set; }


    }
}
