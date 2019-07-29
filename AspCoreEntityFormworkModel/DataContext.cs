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
            //1.使用fluent api做更新
            //modelBuilder.Entity<User>()
            //  .Property(b => b.UserName).IsRequired()
            //  .HasMaxLength(50);
            //modelBuilder.Entity<User>()
            //.Property(b => b.Password).IsRequired()
            //.HasMaxLength(50);
            //modelBuilder.Entity<User>().ToTable("Users").HasData(new User { Id=1,UserName="test",Password="123456"});
            //2.使用map文件做更新
            modelBuilder.AddConfiguration<User>(new UserMap());

        }
    }
}
