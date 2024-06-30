using TPL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL.Concurrency
{
    public class ConcurrentDistinctTasks
    {
        public async Task Execute()
        {
            var task1 = Task1();
            var task2 = Task2();

            Console.WriteLine($"Task1 Status: {task1.Status}");
            Console.WriteLine($"Task2 Status: {task2.Status}");

            Util.HoldOnFor(5);

            Console.WriteLine($"Task1 Status: {task1.Status}");
            Console.WriteLine($"Task2 Status: {task2.Status}");

            Util.HoldOnFor(5);

            Console.WriteLine($"Task1 Status: {task1.Status}");
            Console.WriteLine($"Task2 Status: {task2.Status}");

            Util.HoldOnFor(5);

            Console.WriteLine("Await Start");
            await task1;
            await task2;
            Console.WriteLine("Await End");
        }

        private async Task Task1()
        {
            Console.WriteLine("Task1: Await.Start");
            await Task.Delay(5000);
            Console.WriteLine("Task1: Await.End");

            Util.HoldOnFor(4, (time) =>
            {
                if (time.Millisecond == 100)
                    Console.WriteLine($"Task1: Running");
            });
        }

        private async Task Task2()
        {
            Console.WriteLine("Task2: Await.Start");
            await Task.Delay(3000);
            Console.WriteLine("Task2: Await.End");
        }
    }
}
