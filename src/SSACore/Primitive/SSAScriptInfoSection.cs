using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSA.Primitive
{
    public class SSAScriptInfoSection : SSANamedSection
    {
        public string Title
        {
            get => ((SSATitleLine)this["Title"])?.Text;
            set
            {
                if (this["Title"] == null)
                    this.Add("Title", value ?? string.Empty);
                else
                    ((SSATitleLine)this["Title"]).Text = value ?? string.Empty;
            }
        }

        public ISSALine this[string name]
        {
            get
            {
                if (name == null) throw new ArgumentNullException(nameof(name));

                return this.lines.OfType<SSANamedLine>().FirstOrDefault(line => line.Name == name);
            }
        }

        public SSAScriptInfoSection() : base("Script Info") { }

        public bool ContainsParameter(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            return this.lines.OfType<SSANamedLine>().Any(line => line.Name == name);
        }

        protected internal override ISSALine CreateNamedLine(string name, string text)
        {
            switch (name)
            {
                case "Title":
                    return new SSATitleLine(text);
                default:
                    return base.CreateNamedLine(name, text); ;
            }
        }
    }
}
