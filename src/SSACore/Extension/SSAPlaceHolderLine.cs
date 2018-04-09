using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSA.Extension
{
    public class SSAPlaceHolderLine : SSANamedLine
    {
        public SSAPlaceHolderLine() : base("PlaceHolder", string.Empty) { }
    }
}
