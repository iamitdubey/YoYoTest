using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YoYoTest.Library.Infrastructure
{
    public interface IReader
    {
        Task<List<ShuttleLevel>> Read();
    }
}
