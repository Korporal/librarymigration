using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace SomeLibrary.Targeted
{
    // This is code that must be implemented differently between NetF and NetC likley using class and methods that are 
    // only available on these targets, stuff not available for NetS. The exampole code here is trivial for ease of readability.
    public class TargetSpecificCode
    {
#if NET472
        public const string Target = "NetF";

        public TargetSpecificCode()
        {
            var s = HttpContext.Current;
        }
#endif

#if NET5_0
        public const string Target = "NetS";
#endif
    }
}