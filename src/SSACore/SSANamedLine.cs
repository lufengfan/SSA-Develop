using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSA
{
    public class SSANamedLine : SSALine
    {
        protected string name;
        public string Name => this.name;

        public override string LineText => $"{this.Name}: {base.LineText}";

        public string Text => base.LineText;

        protected SSANamedLine() : base() { }

        public SSANamedLine(string name, string text) : base(text)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
