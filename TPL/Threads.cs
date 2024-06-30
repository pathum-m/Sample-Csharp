using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL
{
    public class Threads
    {
        public void Execute()
        {
            var t = Task.Factory.StartNew(() => Task1());

            Util.HoldOnFor(5, (time) =>
            {
                if (time.Millisecond == 100) Console.WriteLine($"MAIN: {Thread.CurrentThread.ManagedThreadId}");
            });

            t.Wait();
        }

        private void Task1()
        {
            Util.HoldOnFor(10, (time) =>
            {
                if (time.Millisecond == 100) Console.WriteLine($"TASK: {Thread.CurrentThread.ManagedThreadId}");
            });
        }
    }
}
