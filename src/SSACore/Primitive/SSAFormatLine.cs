using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SSA.Primitive
{
    public class SSAFormatLine : SSAFieldsLine
    {
        protected List<SSAField> fields;
        public new SSAField[] Fields => this.fields.ToArray();

        public override string LineText => $"{this.Name}: {string.Join(", ", this.fields.Select(field => field.Name))}";

        public SSAFormatLine(string text) : base("Format", text)
        {
            this.ParseFields();
        }

        protected internal SSAFormatLine(string[] fields) : base("Format", fields)
        {
            this.ParseFields();
        }

        private void ParseFields()
        {
            Regex regex = new Regex(@"^\s*(?<Name>(\w| )+?)\s*=\s*(?<DefaultValue>(\s|\S)*)$");
            this.fields = base.Fields.Select(str =>
            {
                Match match = regex.Match(str);
                if (match.Success)
                    return this.ParseField(match.Groups["Name"].Value.Trim(), match.Groups["DefaultValue"].Value);
                else
                    return this.ParseField(str.Trim());
            }).ToList();
        }

        protected internal virtual SSAField ParseField(string name)
        {
            switch (name)
            {
                case "Start":
                case "End":
                    return new SSATimeField(name);
                case "Style":
                    return new SSAStyleField(name);
                default:
                    return new SSAField(name);
            }
        }

        protected internal virtual SSAField ParseField(string name, string defaultValue)
        {
            switch (name)
            {
                case "Start":
                case "End":
                    return new SSATimeField(name, defaultValue);
                case "Style":
                    return new SSAStyleField(name, defaultValue);
                default:
                    return new SSAField(name, defaultValue);
            }
        }
    }
}
