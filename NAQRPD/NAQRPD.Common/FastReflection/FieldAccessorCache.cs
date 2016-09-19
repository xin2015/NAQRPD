using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NAQRPD.Common.FastReflection
{
    public class FieldAccessorCache : FastReflectionCache<FieldInfo, IFieldAccessor>
    {
        protected override IFieldAccessor Create(FieldInfo key)
        {
            return FastReflectionFactories.FieldAccessorFactory.Create(key);
        }
    }
}
