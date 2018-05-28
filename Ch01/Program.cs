using System;
using System.Threading;
using System.Diagnostics;

namespace Ch01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Ch1_2();
            //Ch1_3();
            //Ch1_4();
            //Ch1_5();
            //Ch1_6();
            Ch1_7();

            Console.Read();
        }

        /// <summary>
        /// Thread Priority
        /// </summary>
        private static void Ch1_7()
        {
            var samepleThread = new SamepleThread();
            var t1 = new Thread(samepleThread.CountNumbers)
            {
                Name = "Thread1",
                Priority = ThreadPriority.Highest
            };
            var t2 = new Thread(samepleThread.CountNumbers)
            {
                Name = "Thead2",
                Priority = ThreadPriority.Lowest
            };
            t1.Start();
            t2.Start();
            Thread.Sleep(2000);
            samepleThread.Stop();
        }

        /// <summary>
        /// Normal Thread.
        /// </summary>
        private static void Ch1_2()
        {
            Thread t = new Thread(PrintNumbers);
            t.Start();
            PrintNumbers();
        }

        /// <summary>
        /// Delay Thread.
        /// </summary>
        private static void Ch1_3()
        {
            Thread t = new Thread(PrintNumbersWithDelay);
            t.Start();
            PrintNumbers();
        }

        /// <summary>
        /// Wait Thread.
        /// </summary>
        private static void Ch1_4()
        {
            Thread t = new Thread(PrintNumbersWithDelay);
            t.Start();
            t.Join();
            PrintNumbers();
        }

        private static void Ch1_5()
        {
            Thread t = new Thread(PrintNumbersWithDelay);
            t.Start();
            Thread.Sleep(6000);
            t.Abort();
            Console.WriteLine("The thread has been aborted.");
            t = new Thread(PrintNumbers);
            t.Start();
            PrintNumbers();
        }

        /// <summary>
        /// Thread Status
        /// </summary>
        private static void Ch1_6()
        {
            var t1 = new Thread(PrintNumbersWithStatus);
            var t2 = new Thread(DoNothing);
            Console.WriteLine(t1.ThreadState.ToString());
            t2.Start();
            t1.Start();
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine(t1.ThreadState.ToString());
            }

            Thread.Sleep(6000);
            t1.Abort();
            Console.WriteLine("the t1 thread has been aborted.");
            Console.WriteLine(t1.ThreadState.ToString());
            Console.WriteLine(t2.ThreadState.ToString());
        }

        private static void PrintNumbers()
        {
            Console.WriteLine("Starting...");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        private static void PrintNumbersWithDelay()
        {
            Console.WriteLine("Starting...");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(2000);
                Console.WriteLine(i);
            }
        }

        private static void DoNothing()
        {
            Thread.Sleep(2000);
        }

        private static void PrintNumbersWithStatus()
        {
            Console.WriteLine("Starting...");
            Console.WriteLine(Thread.CurrentThread.ThreadState.ToString());
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(2000);
                Console.WriteLine(i);
            }
        }
    }
}