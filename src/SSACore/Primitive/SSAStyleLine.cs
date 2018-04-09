using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSA.Primitive
{
    public class SSAStyleLine : SSAFieldsLine
    {
        public SSAStyleLine(string text) : base("Style", text) { }
        public SSAStyleLine(string text, SSAFormatLine formatLine) : base("Style", text, formatLine) { }
        public SSAStyleLine(string[] fields) : base("Style", fields) { }
    }
}
