using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lock
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 10; i++)
            {
                Random random = new Random();

                Console.WriteLine(random.Next(1, 4));
            }

            //oper c1 = new oper();

            ////在t1线程中调用LockMe，并将deadlock设为true（将出现死锁）
            //Thread t1 = new Thread(c1.LockMe);
            //t1.Start(true);
            //Thread.Sleep(100);

            ////在主线程中lock c1
            //lock (c1)
            //{
            //    //调用没有被lock的方法
            //    c1.DoNotLockMe();
            //    //调用被lock的方法，并试图将deadlock解除
            //    c1.LockMe(false);
            //}

            Console.ReadLine();
        }
    }
}
