using TPL;
using System.Net.Http;

namespace TPL.Concurrency
{
    public class ConcurrentTasks
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

            Task.WhenAll(tasks).Wait();

            Console.WriteLine("Process: End");

            foreach (var t in tasks.Where(t => t.IsFaulted))
            {
                Console.WriteLine($"{t.Id}: {t.Exception.InnerException.Message}");
            }
        }

        public async Task Task1(int id, int sec)
        {
            Console.WriteLine($"Task {id}: Start");

            await Task.Delay(sec);

            Console.WriteLine($"Task {id}: End");
        }


        public void ConcurrentHttpRequests()
        {
            List<Task<HttpResponseMessage>> tasks = new();

            using (var http = new HttpClient())
            {
                Console.WriteLine("Tasks start");

                for (var i = 0; i < 10; i++)
                    tasks.Add(http.GetAsync("https://www.dailymail.co.uk/home/index.html"));

                Util.HoldOnFor(40);

                Console.WriteLine("Before Waiting");

                Task.WhenAll(tasks).Wait();
            }

            var s = tasks.Select(t => t.Result.Content.ReadAsStringAsync().Result); // Use other parallel techniques

            Console.WriteLine(string.Join("", s));
        }
    }
}
