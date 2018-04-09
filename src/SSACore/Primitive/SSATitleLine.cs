using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSA.Primitive
{
    public sealed class SSATitleLine : SSANamedLine
    {
        public new string Text
        {
            get => this.text;
            set => this.text = value ?? throw new ArgumentNullException(nameof(value));
        }

        public SSATitleLine(string text) : base("Title", text) { }
    }
}
