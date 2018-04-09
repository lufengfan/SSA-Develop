using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Linq
{
    public interface IIndexing<out T>
    {
        int Index { get; }
        T Value { get; }
    }
}
