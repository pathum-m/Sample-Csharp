using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL.Concurrency
{
    public class ConcurrentTasksExceptions
    {
        [Fact]
        public void Debug()
        {
            Tasks();
        }

        public void Tasks()
        {
            Console.WriteLine("Process: Start");

            var tasks = new List<Task>();

            for (var i = 0; i < 100; i++)
            {
                tasks.Add(Task1(i, i % 20 * 1000));
            }

            try
            {
                Task.WhenAll(tasks).Wait();
            }
            catch
            { 
                // Continue on individual task exceptions
            }

            Console.WriteLine("Process: End");

            foreach (var t in tasks.Where(t => t.IsFaulted))
            {
                Console.WriteLine($"{t.Id}: {t.Exception.InnerException.Message}");
            }
        }

        public async Task Task1(int id, int sec)
        {
            Console.ForegroundColor = id == 20 ? ConsoleColor.Red : ConsoleColor.White;
            Console.WriteLine($"Task {id}: Start");

            await Task.Delay(sec);

            Util.HoldOnFor(1);

            if (id == 20) throw new Exception($"Task 20 failed");

            Console.ForegroundColor = id == 20 ? ConsoleColor.Red : ConsoleColor.White;
            Console.WriteLine($"Task {id}: End");
        }
    }
}
