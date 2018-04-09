using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSA.Extension
{
    public class SSALabelLine : SSANamedLine
    {
        public SSALabelLine(string text) : base("Label", text) { }
    }
}
