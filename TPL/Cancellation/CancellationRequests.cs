using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL.Cancellation
{
    public class CancellationRequests
    {
        public void Execute()
        {
            var cts = new CancellationTokenSource();

            try
            {
                cts.CancelAfter(8000);

                Task.WhenAll(Task1(cts.Token), Task2(cts.Token)).Wait();
            }
            catch (TaskCanceledException)
            {

            }
            finally
            {
                cts.Dispose();
            }
        }

        private async Task Task1(CancellationToken ct)
        {
            await Task.Delay(1000, ct);

            while (!ct.IsCancellationRequested)
            {
                Console.WriteLine("Task 1 running");
                Util.HoldOnFor(1);
            };

            Console.WriteLine("Task 1 Canceled");

            Util.HoldOnFor(5);
        }

        private async Task Task2(CancellationToken ct)
        {
            await Task.Delay(1000, ct);

            while (true)
            {
                ct.ThrowIfCancellationRequested();
                Console.WriteLine("Task 2 running");
                Util.HoldOnFor(1);
            };
        }
    }
}
