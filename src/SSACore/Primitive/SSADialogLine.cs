using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSA.Primitive
{
    public class SSADialogLine : SSAFieldsLine
    {
        public SSADialogLine(string text) : base("Dialogue", text) { }
        public SSADialogLine(string text, SSAFormatLine formatLine) : base("Dialogue", text, formatLine) { }
        public SSADialogLine(string[] fields) : base("Dialogue", fields) { }
    }
}
