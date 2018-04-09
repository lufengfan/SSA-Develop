using SSA.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSA.Extension
{
    public class SSAPlaceInsertLine : SSANamedLine
    {
        protected ISSALine innerLine;
        public virtual ISSALine InnerLine => this.innerLine;
        public override string LineText => $"{this.Name}: {this.InnerLine.LineText}";

        public SSAPlaceInsertLine(ISSALine line) : base()
        {
            if (line == null) throw new ArgumentNullException(nameof(line));

            this.name = "PlaceInsert";
            this.innerLine = line;
        }
    }
}
