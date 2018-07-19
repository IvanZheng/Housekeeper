using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Housekeeper.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int count = 5000;
            var tasks = new List<Task>();
            var httpClient = new HttpClient();

            for (int i = 0; i < count; i++)
            {
                tasks.Add(GetAsync(httpClient));
            }

            Task.WaitAll(tasks.ToArray());
        }

        private static async Task GetAsync(HttpClient httpClient)
        {
            var result = await httpClient.GetAsync("http://localhost:9564/api/houses");
            await result.Content.ReadAsStringAsync();
        }
    }
}
