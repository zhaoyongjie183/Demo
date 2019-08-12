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
            //redisHelper.HashSet("cache:a", "BBBB", TimeSpan.FromSeconds(20));

            var flag=redisHelper.LockTake("cache:b", "a",TimeSpan.FromMinutes(60));
           // var aa = redisHelper.LockRelease("cache:b", "a");
            Console.WriteLine("设置缓存成功");
            Console.ReadLine();
        }
    }
}
