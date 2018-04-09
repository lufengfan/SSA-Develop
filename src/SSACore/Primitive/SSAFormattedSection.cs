using SamLu;
using SSA.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSA.Primitive
{
    public class SSAFormattedSection : SSANamedSection
    {
        public SSAFormatLine FormatLine { get; protected set; }

        public ValueBox<object> this[int index, string field]
        {
            get
            {
                if (index < 0 || index >= this.lines.Count)
                    throw new ArgumentOutOfRangeException(nameof(index), index, "索引超出范围。");
                if (field == null) throw new ArgumentNullException(nameof(field));

                int length = this.FormatLine.Fields.Length;
                int fieldIndex = this.FormatLine.Fields.FindIndex(_field => _field.Name, field);
                if (fieldIndex < 0)
                {
                    return ValueBox<object>.Empty;
                    //throw new ArgumentException("未添加此字段", nameof(field));
                }
                else
                {
                    if (this.FormatLine.Fields[fieldIndex].DeserializeValue(((SSAFieldsLine)this.lines[index]).Fields[fieldIndex], out object result))
                        return result;
                    else
                        return this.FormatLine.Fields[fieldIndex].DefaultValue;
                }
            }
            set
            {
                if (index < 0 || index >= this.lines.Count)
                    throw new ArgumentOutOfRangeException(nameof(index), index, "索引超出范围。");
                if (field == null) throw new ArgumentNullException(nameof(field));

                int length = this.FormatLine.Fields.Length;
                int fieldIndex = this.FormatLine.Fields.FindIndex(_field => _field.Name, field);
                if (fieldIndex < 0) throw new ArgumentException("未添加此字段", nameof(field));
                else
                {
                    if (value.HasValue)
                    {
                        ((SSAFieldsLine)this.lines[index]).Fields[fieldIndex] = this.FormatLine.Fields[fieldIndex].SerializeValue(value);
                    }
                }
            }
        }

        public SSAFormattedSection(string name) : base(name) { }
        
        protected internal override ISSALine CreateNamedLine(string name, string text)
        {
            switch (name)
            {
                case "Format":
                    SSAFormatLine formatLine = new SSAFormatLine(text);
                    if (this.FormatLine == null && this.lines.Count == 0)
                        this.FormatLine = formatLine;
                    else
                        throw new InvalidOperationException();
                    return formatLine;
                default:
                    return base.CreateNamedLine(name, text);
            }
        }

        public virtual SSAFieldsLine CreateFieldsLine(string name, string[] fields)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (fields == null) throw new ArgumentNullException(nameof(fields));

            switch (name)
            {
                case "Format":
                    SSAFormatLine formatLine = new SSAFormatLine(fields);
                    if (this.FormatLine == null)
                        this.FormatLine = formatLine;
                    else
                        throw new InvalidOperationException();
                    return formatLine;
                default:
                    return new SSAFieldsLine(name, fields);
            }
        }
    }
}
