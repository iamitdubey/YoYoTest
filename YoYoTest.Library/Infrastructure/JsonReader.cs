using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YoYoTest.Library.Infrastructure
{
    public class JsonReader : IReader
    {
        public async Task<List<ShuttleLevel>> Read()
        {
            try
            {
                string json = new TestJson().Json; // Todo: use DI
                return JsonConvert.DeserializeObject<List<ShuttleLevel>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while trying to Read from JsonReader." + ex);
            }
            return null;
        }
    }
}
