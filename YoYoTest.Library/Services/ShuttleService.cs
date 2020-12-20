using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YoYoTest.Library.Infrastructure;

namespace YoYoTest.Library
{
    public class ShuttleService : IShuttleService
    {
        List<ShuttleLevel> Shuttles { get; set; }
        IReader jsonReader = new Infrastructure.JsonReader();
        public async Task<List<ShuttleLevel>> GetData()
        {
            try
            {
                Shuttles = await jsonReader.Read();
                return Shuttles;
            }
            catch (Exception)
            { }
            return null;
        }

        public async Task<List<ShuttleLevel>> GetShuttlesFor(int level, int shuttle)
        {
            List<ShuttleLevel> response = new List<ShuttleLevel>();
            try
            {
                shuttle = shuttle == 0 ? 1 : shuttle;

                if (Shuttles == null)
                {
                    string json = new TestJson().Json;
                    Shuttles = JsonConvert.DeserializeObject<List<ShuttleLevel>>(json);
                }
                response.Add(Shuttles.FirstOrDefault(x => Convert.ToInt32(x.SpeedLevel) == Level[level] && (Convert.ToInt32(x.ShuttleNo) == shuttle)));
            }
            catch (Exception ex)
            { }
            return response;
        }

        public List<int> Level = new List<int> { 5, 9, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };
    }
}
