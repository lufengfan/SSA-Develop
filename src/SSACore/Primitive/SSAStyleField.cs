using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSA.Primitive
{
    public class SSAStyleField : SSAField
    {
        public SSAStyleField(string name) : this(name, "Default") { }

        public SSAStyleField(string name, string defaultValue) : base(name, defaultValue) { }

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
