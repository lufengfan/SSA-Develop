using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSA.Primitive
{
    public class SSAV4PlusStylesSection : SSAFormattedSection
    {
        public SSAV4PlusStylesSection() : base("V4+ Styles") { }

        protected internal override ISSALine CreateNamedLine(string name, string text)
        {
            switch (name)
            {
                case "Style":
                    return new SSAStyleLine(text, this.FormatLine);
                default:
                    return base.CreateNamedLine(name, text);
            }
        }

        public override SSAFieldsLine CreateFieldsLine(string name, string[] fields)
        {
            switch (name)
            {
                case "Style":
                    return new SSAStyleLine(fields);
                default:
                    return base.CreateFieldsLine(name, fields);
            }
        }
    }
}
