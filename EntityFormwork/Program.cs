using EntityFormwork.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFormwork
{
    class Program
    {
        static void Main(string[] args)
        {
            MysqlContext mysqlContext = new MysqlContext();

            mysqlContext.Database.EnsureCreated(); //针对当前访问的上下文对象，如果数据库中存在该表，则不做修改；否则的话进行创建



            mysqlContext.Blog.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });

            mysqlContext.SaveChanges();

            mysqlContext.Database.Migrate();

            Console.ReadKey();
        }
    }
}
