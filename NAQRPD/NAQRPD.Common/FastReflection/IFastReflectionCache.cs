using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAQRPD.Common.FastReflection
{
    public interface IFastReflectionCache<TKey, TValue>
    {
        TValue Get(TKey key);
    }
}
