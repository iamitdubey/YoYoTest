using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoYoTest.Library
{
    public interface IShuttleService
    {
        Task<List<MyArray>> GetData();
        Task<List<MyArray>> GetShuttlesFor(int level, int shuttle);
    }
}
