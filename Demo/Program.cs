using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();

            var stream = client.GetStreamAsync("http://localhost:5000/api/values").Result;

            var users = Serializer.Deserialize<List<Student>>(stream);

            foreach (var item in users)

            {

                Console.WriteLine($"ID:{item.ID}-Name:{item.StuName}-Age:{item.StuAge}");

            }

            Console.ReadKey();
        }
    }

    [ProtoContract]
    public class Student
    {
        /// <summary>
        /// 学生ID
        /// </summary>
        [ProtoMember(1, IsRequired = true, Name = "学生ID")]
        public int ID { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        [ProtoMember(2)]
        public string StuName { get; set; }

        /// <summary>
        /// 学生年龄
        /// </summary>
        [ProtoMember(3)]
        public string StuAge { get; set; }
    }


}
