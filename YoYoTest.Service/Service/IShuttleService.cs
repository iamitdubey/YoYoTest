using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoYoTest.Service.Service
{
    public interface IShuttleService
    {
        Task<List<Shuttle>> GetData();
        Task<List<Shuttle>> GetShuttlesFor(int level);
    }
}
