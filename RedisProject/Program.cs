using System;

namespace RedisProject
{
    class Program
    {
        static void Main(string[] args)
        {

            RedisHelper redisHelper = new RedisHelper();
            var c=redisHelper.GetConnectionMultiplexer();
            
           // redisHelper.StringSet("cache:a", "BBBB",TimeSpan.FromSeconds(20));
            redisHelper.HashSet("cache:a", "BBBB", TimeSpan.FromSeconds(20));
            Console.WriteLine("设置缓存成功");
            Console.ReadLine();
        }
    }
}
