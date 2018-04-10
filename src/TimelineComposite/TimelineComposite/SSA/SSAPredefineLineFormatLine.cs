using SSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimelineComposite.SSA
{
    internal class SSAPredefineLineFormatLine : SSANamedLine
    {
        public SSAPredefineLineFormatLine(string text) : base("PredefineLineFormat", text) { }
    }
}
