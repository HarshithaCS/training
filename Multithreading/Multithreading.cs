using System;
using System.Threading;
namespace Multithreading
{
    public class MyThread
    {

        public void Thread1()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} is executing-{i} Time");
                Thread.Sleep(1000);
            }
        }
    }

    public class MyClass
    {

        public static void Main()
        {
            Console.WriteLine("Before thread starts");

            MyThread thr1 = new MyThread();
            MyThread thr2 = new MyThread();

            Thread tid1 = new Thread(new ThreadStart(thr1.Thread1));
            Thread tid2 = new Thread(new ThreadStart(thr2.Thread1));
            tid1.Name = "Thread1";
            tid2.Name = "Thread2";
            Console.WriteLine($"The current state of the {tid1.Name} is {tid1.ThreadState}");
            tid1.Start();
            Console.WriteLine("After thread1 starts");
            Console.WriteLine($"The current state of the {tid1.Name} is {tid1.ThreadState}");
            Thread.Sleep(5000);
            Console.WriteLine($"The current state of the {tid2.Name} is {tid2.ThreadState}");
            tid2.Start();
            Console.WriteLine("After thread2 starts");
            Console.WriteLine($"The current state of the {tid2.Name} is {tid2.ThreadState}");
            tid1.Abort();
            Console.WriteLine("Thread1 is aborted");
            Thread.Sleep(4000);
            tid2.Abort();
            Console.WriteLine("Thread2 is aborted");
            Console.ReadLine();

        }
    }
}