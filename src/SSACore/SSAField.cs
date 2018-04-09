using SamLu;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SSA
{
    [DebuggerDisplay("{Name}")]
    public class SSAField
    {
        private string name;
        public string Name => this.name;

        private ValueBox<object> defaultValue = ValueBox<object>.Empty;
        public ValueBox<object> DefaultValue => this.defaultValue;

        public SSAField(string name) =>
            this.name = name ?? throw new ArgumentNullException(nameof(name));

        public SSAField(string name, string defaultValue) : this(name)
        {
            if (defaultValue == null) throw new ArgumentNullException(nameof(defaultValue));

            if (this.DeserializeValue(defaultValue, out object result))
            {
                this.defaultValue.Value = result;
            }
        }

        public virtual string SerializeValue(object value) => value?.ToString() ?? string.Empty;
        public virtual bool DeserializeValue(string value, out object result)
        {
            result = value;
            return true;
        }
    }
}
