using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Chaching
{
    public interface IChachedQuery
    {
        string Key { get; }
        TimeSpan? Expitation { get; }
    }
}
