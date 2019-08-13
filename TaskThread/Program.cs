using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskThread
{
    class Program
    {
        static void Main(string[] args)
        {
            //1、子线程不带参数 Thread每次都会开启一个新线程
            //Thread thread = new Thread(Method);
            //thread.Start();
            //2、子线程带参数
            //Thread thread = new Thread(ParameterMethod);
            //thread.Start("这是带参数的线程");
            //3、线程池无参数
            //ThreadPool是Thread的一个升级版，ThreadPool是从线程池中获取线程，
            //如果线程池中又空闲的元素，则直接调用，如果没有才会创建，
            // 而Thread则是会一直创建新的线程，要知道开启一个线程就算什么事都不做也会消耗大约1m的内存，是非常浪费性能的
            //ThreadPool.QueueUserWorkItem(new WaitCallback(obj => {
            //    Console.WriteLine("线程ID："+Thread.CurrentThread.ManagedThreadId);
            //    Console.WriteLine("是否前台线程：" + Thread.CurrentThread.IsBackground);
            //    Console.WriteLine("是否线程池线程：" + Thread.CurrentThread.IsThreadPoolThread);
            // }
            //)) ;

            //4、线程池有参数
            //ThreadPool.QueueUserWorkItem(new WaitCallback(obj => {
            //    Console.WriteLine("线程ID：" + Thread.CurrentThread.ManagedThreadId);
            //    Console.WriteLine("是否前台线程：" + Thread.CurrentThread.IsBackground);
            //    Console.WriteLine("是否线程池线程：" + Thread.CurrentThread.IsThreadPoolThread);
            //    Console.WriteLine("参数："+obj);
            //}), "这是参数");

            //4.1、线程池取消取消子线程操作


            //CancellationTokenSource cts = new CancellationTokenSource();
            //ThreadPool.QueueUserWorkItem(new WaitCallback(CanCancelMethod), cts.Token);
            //cts.Cancel();
            //5、task
            //方法1  使用Task的Run方法
            //Task.Run(() => {
            //    Console.WriteLine($"线程{Thread.CurrentThread.ManagedThreadId}已开启");
            //});

            //方法2   使用Task工厂类TaskFactory对象的StartNew方法
            //(new TaskFactory()).StartNew(() =>
            //{
            //    Console.WriteLine($"线程{Thread.CurrentThread.ManagedThreadId}已开启");
            //});

            Console.WriteLine("主线程开始");
            TaskDemo1();
            Console.WriteLine("主线程结束");

            //6、await async async和await关键字用来实现异步编程，async用来修饰方法，await用来调用方法，
            //await关键字必须出现在有async的方法中，await调用的方法可以不用async关键字修饰
            //Demo1();

            // Console.WriteLine("主线程结束");

            //Console.WriteLine("主线程开始");
            //AsyncDemo1();
            //Console.WriteLine("主线程结束");



            Console.ReadLine();
        }

        static async void AsyncDemo1()
        {
            Console.WriteLine("异步开始");
            await AsyncDemo2();
            Console.WriteLine("异步结束");
        }

        static async Task<int> AsyncDemo2()
        {
            Console.WriteLine("子线程开始");
            //当前子线程暂停1s
            await Task.Delay(1000);
            Console.WriteLine("子线程结束");
            return 0;
        }

        static void TaskDemo1()
        {
            Console.WriteLine("异步开始");
           var t1= Task.Run<int>(() =>
            {
                return TaskDemo2();
            });
            //Task.WaitAll(t1);等待所有任务结束 
            Console.WriteLine("异步结束");
        }

        static int TaskDemo2()
        {
            Console.WriteLine("子线程开始");
            Thread.Sleep(1000);
            Console.WriteLine("子线程结束");
            return 1;
        }

        static async void Demo1()
        {
           var a= await Demo2();
            Console.WriteLine(a);
        }
        static async Task<int> Demo2()
        {
            return 1;
        }

        static void Method()
        {
            Thread.Sleep(1000);
            Console.WriteLine("新线程");
        }

        static void ParameterMethod(object x)
        {
            Console.WriteLine("线程ID："+Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("是否前台线程：" + Thread.CurrentThread.IsBackground);
            Console.WriteLine("是否线程池线程：" + Thread.CurrentThread.IsThreadPoolThread);
            Thread.Sleep(3000);
            Console.WriteLine(x);
        }

        static void CanCancelMethod(Object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            if (ct.IsCancellationRequested)
            {
                Console.WriteLine("该线程已取消");
            }
            //就算ct.IsCancellationRequested为真，接下来的代码还是会执行
            //因为该方法并没有ruturn
            Thread.Sleep(1000);
            Console.WriteLine($"子线程{Thread.CurrentThread.ManagedThreadId}结束");
        }
    }
}
