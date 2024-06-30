using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TPL
{
    public class ReturnValuedTasks
    {
        public async Task Execute()
        {
            var task1 = Task1();
            var task2 = Task2();

            var v1 = await task1;
            var v2 = await task2;

            Console.WriteLine(v1 + v2);
        }

        public async Task<int> Task1()
        {
            await Task.Delay(2000);

            return 1;
        }

        public async Task<int> Task2()
        {
            await Task.Delay(3000);

            return 2;
        }
    }
}
