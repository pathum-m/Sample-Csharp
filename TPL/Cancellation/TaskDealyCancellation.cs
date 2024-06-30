using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL.Cancellation
{
    public class TaskDealyCancellation
    {
        [Fact]
        public void Test()
        { 
            var cts = new CancellationTokenSource();

            cts.CancelAfter(5000);

            Action action = () => Task.Delay(10000, cts.Token).Wait();

            action.Should().Throw<AggregateException>().WithInnerException<TaskCanceledException>();
        }
    }
}
