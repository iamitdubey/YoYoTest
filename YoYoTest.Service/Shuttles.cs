using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoYoTest.Service
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Shuttle
    {
        public string AccumulatedShuttleDistance { get; set; }
        public int SpeedLevel { get; set; }
        public string ShuttleNo { get; set; }
        public string Speed { get; set; }
        public string LevelTime { get; set; }
        public string CommulativeTime { get; set; }
        public string StartTime { get; set; }
        public string ApproxVo2Max { get; set; }
    }

    public class Data
    {
        public List<Shuttle> Shuttles { get; set; }
    }
}
