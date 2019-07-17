using EntityFormwork.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFormwork
{
    public  class MysqlContext : DbContext
    {
        //开启日志
        public static readonly LoggerFactory MyLoggerFactory= new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });
        private const string DefaultMySqlConnectionString = "server=39.105.168.143;port=3306;database=mysqlEF;uid=root;password=angelIN2019;Allow User Variables=True;Charset=utf8mb4;SslMode = none;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(DefaultMySqlConnectionString);
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<Blog>(m =>
            //{
            //    m.Property(n => n.BlogId); 
            //    m.Property(n => n.Url).HasMaxLength(50).IsRequired();
            //});
            //modelBuilder.Entity<Blog>().ToTable("Blog");
          
        }

        public DbSet<Blog> Blog { get; set; }

        public DbSet<Post> Post { get; set; }
    }
}
