using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoMocksUsage.Src
{
    public class SampleClass : ISample
    {
        public void MethodWithOutParameter(out int ret)
        {
            ret = 100;
        }
    }
}
