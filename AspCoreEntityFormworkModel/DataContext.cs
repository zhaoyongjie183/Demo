using Microsoft.EntityFrameworkCore;

namespace AspCoreEntityFormworkModel
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<User>().ToTable("Users").Property(b=>b.UserName).HasMaxLength(50);

        }
    }
}
