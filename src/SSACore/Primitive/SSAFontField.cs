using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSA.Primitive
{
    public class SSAFontField : SSAField
    {
        public SSAFontField(string name) : base(name) { }

        public SSAFontField(string name, string defaultValue) : base(name, defaultValue) { }

        public override bool DeserializeValue(string value, out object result)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                result = null;
                return false;
            }
            else
            {
                result = value;
                return true;
            }
        }

        public override string SerializeValue(object value)
        {
            if (value == null) return string.Empty;
            else if (value is string)
                return (string)value;
            else
                throw new NotSupportedException();
        }
    }
}
