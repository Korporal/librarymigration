// In code that has target coditional package references, always use fully qualified names 
// in your code as this avoids having "using" present, if a "using" is present for a namespace
// that's not visible for some build target, we get silly compile errors.

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
            var s = System.Web.HttpContext.Current;
        }
#endif

#if NET5_0
        public const string Target = "Net5";

        public TargetSpecificCode()
        {
            var p = new CsvHelper.CsvParser(null, null);

            System.Web.HttpUtility.HtmlDecode(null);
        }
#endif
    }
}