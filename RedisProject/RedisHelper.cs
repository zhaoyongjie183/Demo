﻿using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace RedisProject
{
    /// <summary>	
    /// 描述：
    /// 创建人： zhaoyongjie
    /// 创建时间：2019/8/9 15:29:39
    /// </summary>
    public class RedisHelper 
    {
        /// <summary>
        /// redis连接实例字典
        /// key:业务编码
        /// </summary>
        public ConcurrentDictionary<string, ConnectionMultiplexer> RedisCons { get; set; } = new ConcurrentDictionary<string, ConnectionMultiplexer>();

        /// <summary>
        /// 自定义redis服务器
        /// </summary>
        public string RedisServer = "192.168.200.182:6379";

        /// <summary>
        /// 自定义redis数据库
        /// </summary>
        public int DBIndex = 11;

        /// <summary>
        /// 获取redis连接
        /// </summary>
        /// <param name="businessKey"></param>
        /// <returns></returns>
        public ConnectionMultiplexer GetConnectionMultiplexer()
        {
            return ConnectionMultiplexer.Connect($"{RedisServer},syncTimeout=10000 ");
        }

        /// <summary>
        /// 获取数据库
        /// </summary>
        /// <returns></returns>
        public IDatabase GetRedisDB(ConnectionMultiplexer redisCon)
        {
            return redisCon.GetDatabase(DBIndex);
        }


        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <param name="validFor">过期时间</param>
        public void StringSet(string key, object value, TimeSpan? validFor)
        {
            try
            {
                var redisCon = GetConnectionMultiplexer();
                var db = GetRedisDB(redisCon);
                var jsonvalue = JsonConvert.SerializeObject(value);
                db.StringSet(key, jsonvalue);
                if (validFor != null)
                {
                    db.KeyExpire(key, validFor,CommandFlags.NoRedirect);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("添加缓存失败");
            }
        }

        public void HashSet(string key, object value, TimeSpan? validFor)
        {
            try
            {
                var redisCon = GetConnectionMultiplexer();
                var db = GetRedisDB(redisCon);
                db.HashSet(key, "a","b");
                if (validFor != null)
                {
                    db.KeyExpire(key, validFor, CommandFlags.NoRedirect);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("添加缓存失败");
            }
        }
    }
}
