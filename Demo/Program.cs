using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //HttpClient client = new HttpClient();

            //var stream = client.GetStreamAsync("http://localhost:5000/api/values").Result;

            //var users = Serializer.Deserialize<List<Student>>(stream);

            //foreach (var item in users)

            //{

            //    Console.WriteLine($"ID:{item.ID}-Name:{item.StuName}-Age:{item.StuAge}");

            //}

            string a = "a";
            string b = "b";
            Swap(ref a, ref b);

            Console.WriteLine(a+ b);

            //Thread.Sleep(10000);

            //Task task = new Task(()=> { DownLoadFile_My("asdas"); });
            //task.Start();
            //System.Threading.ThreadDownLoadFile_My("asdas")Pool.QueueUserWorkItem((status)=> { DownLoadFile_My(status); });
            //Thread t = new Thread(DownLoadFile_My);//创建了线程还未开启
            //t.Start("http://abc/def/**.mp4");//用来给函数传递参数，开启线程
            //Console.WriteLine("main()");

            //Thread t = new Thread(DownLoadFile_My);//创建了线程还未开启
            //t.Start("http://abc/def/**.mp4");//用来给函数传递参数，开启线程
            //Console.WriteLine("main()");

            var result=new MyClass().ReadAsync(new byte[5], 1, 1);
            Console.WriteLine(result.Result);
            Console.WriteLine("执行完成");
            Console.ReadKey();

         
        }
        static void DownLoadFile_My(object filePath)
        {
            Console.WriteLine("开始下载...    线程ID：" + Thread.CurrentThread.ManagedThreadId);
           Thread.Sleep(100);
            Console.WriteLine("下载完成！");
        }

        static void Swap(ref string a, ref string b)
        {
            string c = a;
            a = b;
            b = c;
        }

        static void Swap<T>(ref T a,ref T b)
        {
            T temp;
            temp = a;
            a = b;
            b = temp;

        }
    }
    public class MyClass
    {
        public Task<int> ReadAsync(byte[] buffer, int offset, int count)
        {
            
            return  Task.FromResult(1);
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
