using SSA.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSA.Primitive
{
    public class SSAEventsSection : SSAFormattedSection
    {
        public SSAEventsSection() : base("Events") { }

        protected internal override ISSALine CreateNamedLine(string name, string text)
        {
            switch (name)
            {
                case "Dialogue":
                    return new SSADialogLine(text, this.FormatLine);
                case "Label":
                    return new SSALabelLine(text);
                case "PlaceHolder":
                    return new SSAPlaceHolderLine();
                case "PlaceInsert":
                    return new SSAPlaceInsertLine(this.CreateLine(text));
                default:
                    return base.CreateNamedLine(name, text);
            }
        }

        public override SSAFieldsLine CreateFieldsLine(string name, string[] fields)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (fields == null) throw new ArgumentNullException(nameof(fields));

            switch (name)
            {
                case "Dialogue":
                    return new SSADialogLine(fields);
                default:
                    return base.CreateFieldsLine(name, fields);
            }
        }
    }
}
