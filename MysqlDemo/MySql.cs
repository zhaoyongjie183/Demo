using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MysqlDemo
{
    /// <summary>	
    /// 描述：
    /// 创建人： zhaoyongjie
    /// 创建时间：2019/7/31 10:49:02
    /// </summary>
    public class MySql
    {
        private readonly string connestr = "server=39.105.168.143;port=3306;database=test;uid=root;password=angelIN2019;Allow User Variables=True;Charset=utf8mb4;";

        public void Exec()
        {
            using (IDbConnection conn = new MySqlConnection(connestr))
            {
                conn.Open();
                var command = conn.CreateCommand();
               
            }
        }
    }
}
