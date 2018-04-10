using SSA.Primitive;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SSA
{
    [DebuggerDisplay("[{Name}], LineCount = {Lines.Length}")]
    public class SSANamedSection : SSASection
    {
        private string name;
        public string Name => this.name;

        public override ISSALine[] Lines => new[] { new SSARawTextLine($"[{this.Name}]") }.Concat(base.Lines).ToArray();

        public SSANamedSection(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
