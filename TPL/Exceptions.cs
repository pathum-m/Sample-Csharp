
namespace TPL
{
    public class Exceptions
    {
        [Fact]
        public async void ExceptionsInMultipleTasks()
        {
            try
            {
                Task.WaitAll(Task1(), Task2());
            }
            catch (Exception e)
            {
                Assert.IsType<InvalidOperationException>(e);
            }
        }

        private async Task Task1()
        {
            throw new InvalidOperationException("Exception in task1");
        }

        private async Task Task2()
        {
            throw new InvalidOperationException("Exception in task2");
        }
    }
}
