using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSA.Primitive
{
    public class SSATimeField : SSAField
    {
        public const string SSATimeFormat = @"h\:mm\:ss\.ff";
        public const string DefaultValue = "0:00:00.00";

        public SSATimeField(string name) : this(name, SSATimeField.DefaultValue) { }

        public SSATimeField(string name, string defaultValue) : base(name, defaultValue) { }

        public override bool DeserializeValue(string value, out object result)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                result = null;
                return false;
            }
            else
            {
                if (TimeSpan.TryParseExact(value.Trim(), SSATimeFormat, null, out TimeSpan ts))
                {
                    result = ts;
                    return true;
                }
                else
                {
                    result = null;
                    return false;
                }
            }
        }

        public override string SerializeValue(object value)
        {
            if (value == null) return string.Empty;
            else if (value is TimeSpan ts)
                return ts.ToString(SSATimeFormat);
            else
                throw new NotSupportedException();
        }
    }
}
