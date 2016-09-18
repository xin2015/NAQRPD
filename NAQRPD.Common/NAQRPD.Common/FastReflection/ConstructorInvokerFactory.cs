using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NAQRPD.Common.FastReflection
{
    public class ConstructorInvokerFactory : IFastReflectionFactory<ConstructorInfo, IConstructorInvoker>
    {
        public IConstructorInvoker Create(ConstructorInfo key)
        {
            return new ConstructorInvoker(key);
        }
    }
}
