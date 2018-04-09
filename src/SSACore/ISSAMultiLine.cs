using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSA
{
    public interface ISSAMultiLine
    {
        ISSALine[] Lines { get; }
    }
}
