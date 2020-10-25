using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YoYoTest.Service.Service
{
    public class ShuttleService : IShuttleService
    {
        static ShuttleService()
        {
            string json = System.IO.File.ReadAllText("fitnessrating_beeptest.json");
            Shuttles = JsonConvert.DeserializeObject<List<Shuttle>>(json);
        }
        static List<Shuttle> Shuttles { get; set; }
        public async Task<List<Shuttle>> GetData()
        {
            string json = System.IO.File.ReadAllText("fitnessrating_beeptest.json");
            Shuttles = JsonConvert.DeserializeObject<List<Shuttle>>(json);
            return Shuttles;
        }

        public async Task<List<Shuttle>> GetShuttlesFor(int level)
        {
            return Shuttles.Where(x => x.SpeedLevel == level).ToList();
        }
    }
}
