using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Linq
{
    internal sealed class IndexedItem<T> : IIndexing<T>
    {
        public int Index { get; private set; }

        public T Value { get; private set; }

        public IndexedItem(int index, T value)
        {
            this.Index = index;
            this.Value = value;
        }
    }
}
