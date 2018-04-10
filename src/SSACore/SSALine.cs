using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SSA
{
    [DebuggerDisplay("{LineText}")]
    public abstract class SSALine : ISSALine
    {
        protected string text;
        public virtual string LineText => this.text;

        protected SSALine() { }

        protected SSALine(string text) : this()
        {
            this.text = text ?? throw new ArgumentNullException(nameof(text));
        }
    }
}
