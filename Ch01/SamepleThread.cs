using System;
using System.Threading;

namespace Ch01
{
    public class SamepleThread
    {
        private bool _isStopped = false;

        public void Stop()
        {
            _isStopped = true;
        }

        public void CountNumbers()
        {
            long counter = 0;
            Console.WriteLine($"{Thread.CurrentThread.Name}'s counter is {counter}.");
            while (!_isStopped)
            {
                counter++;
            }

            Console.WriteLine($@"{Thread.CurrentThread.Name} with {Thread.CurrentThread.Priority.ToString()} priority has a count = {counter:N0}");
        }
    }
}