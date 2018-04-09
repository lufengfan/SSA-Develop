using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSA.Primitive
{
    public class SSAFieldsLine : SSANamedLine
    {
        private string[] fields;
        public string[] Fields => this.fields.ToArray();

        public override string LineText => $"{this.Name}: {string.Join(",", this.fields)}";

        public SSAFieldsLine(string name, string text) : base()
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));

            this.fields = text.Split(',');
        }

        public SSAFieldsLine(string name, string[] fields) : base()
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.fields = fields ?? throw new ArgumentNullException(nameof(fields));
        }

        public SSAFieldsLine(string name, string text, SSAFormatLine formatLine) : this(name, text)
        {
            if (formatLine == null) throw new ArgumentNullException(nameof(formatLine));

#if true
            int fieldCount = formatLine.fields.Length;
#else
            int fieldCount = formatLine.Fields.Count(_field => !_field.DefaultValue.HasValue);
#endif
            this.fields = this.fields.Take(fieldCount - 1).Concat(new[] { string.Join(",", this.fields.Skip(fieldCount - 1)) }).ToArray();
        }
    }
}
