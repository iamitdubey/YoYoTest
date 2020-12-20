using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoYoTest.Library
{
    public class ShuttleLevel
    {
        public string AccumulatedShuttleDistance { get; set; }
        public string ApproxVo2Max { get; set; }
        public string CommulativeTime { get; set; }
        public string LevelTime { get; set; }
        public string ShuttleNo { get; set; }
        public string Speed { get; set; }
        public string SpeedLevel { get; set; }
        public string StartTime { get; set; }
    }

    public class Root
    {
        public List<ShuttleLevel> MyArray { get; set; }
    }
}
