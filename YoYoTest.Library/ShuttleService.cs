using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace YoYoTest.Library
{
    public class ShuttleService : IShuttleService
    {
        List<MyArray> Shuttles { get; set; }
        public async Task<List<MyArray>> GetData()
        {
            try
            {
                //if (Shuttles == null)
                {
                    string json = new TestJson().Json;
                    Shuttles = JsonConvert.DeserializeObject<List<MyArray>>(json);
                }
                return Shuttles;
            }
            catch (Exception)
            { }
            return null;
        }

        public async Task<List<MyArray>> GetShuttlesFor(int level, int shuttle)
        {
            List<MyArray> response = new List<MyArray>();
            try
            {
                shuttle = shuttle == 0 ? 1 : shuttle;
                
                if (Shuttles == null)
                {
                    string json = new TestJson().Json;
                    Shuttles = JsonConvert.DeserializeObject<List<MyArray>>(json);
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
