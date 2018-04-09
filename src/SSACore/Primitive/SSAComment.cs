using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSA.Primitive
{
    public class SSAComment : SSALine
    {
        public override string LineText => $"; {this.text}";

        public SSAComment(string text) : base(text) { }
    }
}
