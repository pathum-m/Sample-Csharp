using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL
{
    public class TaskAPI
    {
        [Fact]
        public void WhenALl()
        {
            var t1 = Task1();
            var t2 = Task2();
            var t3 = Task3();

            Assert.False(t1.IsCompleted);
            Assert.False(t2.IsCompleted);
            Assert.False(t3.IsCompleted);

            Task.WhenAll(t1, t2, t3).GetAwaiter().GetResult();

            Assert.True(t1.IsCompleted);
            Assert.True(t2.IsCompleted);
            Assert.True(t3.IsCompleted);
        }

        [Fact]
        public void WhenAny()
        {
            var t1 = Task1();
            var t2 = Task2();
            var t3 = Task3();

            List<Task> tasks = new() { t1, t2, t3 };

            Util.HoldOnFor(5);
            Console.WriteLine($"After 5 sec");

            while (tasks.Any(t => !t.IsCompleted))
            {
                var completedTask = Task.WhenAny(tasks).GetAwaiter().GetResult(); // Returns only when a task completed
                
                Console.WriteLine($"Task1: {t1.Status}");
                Console.WriteLine($"Task2: {t2.Status}");
                Console.WriteLine($"Task3: {t3.Status}");

                tasks.Remove(completedTask);
            }

            Util.HoldOnFor(5);
        }

        private async Task Task1()
        {
            Console.WriteLine("Task 1: Delay Start");
            await Task.Delay(2000);
            Console.WriteLine("Task 1: Delay End");
            Util.HoldOnFor(5, (time) => 
            {
                if (time.Millisecond == 200)
                    Console.WriteLine("Task 1");
            });
            await Task.Delay(1);
        }
        
        private async Task Task2()
        {
            await Task.Delay(3000);
            Util.HoldOnFor(10, (time) =>
            {
                if (time.Millisecond == 200)
                    Console.WriteLine("Task 2");
            });
        }

        private async Task Task3()
        {
            await Task.Delay(4000);
            Util.HoldOnFor(15, (time) =>
            {
                if (time.Millisecond == 200)
                    Console.WriteLine("Task 3");
            });
        }
    }
}
