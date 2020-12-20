using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoYoTest.Library
{
    public interface IShuttleService
    {
        Task<List<ShuttleLevel>> GetData();
        Task<List<ShuttleLevel>> GetShuttlesFor(int level, int shuttle);
    }
}
