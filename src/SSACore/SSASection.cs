using SSA.Primitive;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SSA
{
    [DebuggerDisplay("LineCount = {Lines.Length}")]
    public class SSASection : ISSAScope, ISSAMultiLine
    {
        protected List<ISSALine> lines = new List<ISSALine>();

        public virtual ISSALine[] Lines => this.lines.ToArray();

        public void Add(ISSALine line) => this.lines.Add(line ?? throw new ArgumentNullException(nameof(line)));

        public void Add(string line)
        {
            if (line == null) throw new ArgumentNullException(nameof(line));

            this.lines.Add(this.CreateLine(line));
        }

        public void Add(string name, string text)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (text == null) throw new ArgumentNullException(nameof(text));

            this.AddInternal(name, text);
        }

        protected internal virtual void AddInternal(string name, string text)
        {
            this.Add(this.CreateNamedLine(name, text));
        }

        public void Insert(int index, ISSALine line) => this.lines.Insert(index, line ?? throw new ArgumentNullException(nameof(line)));

        public void Insert(int index, string line)
        {
            if (line == null) throw new ArgumentNullException(nameof(line));

            this.lines.Insert(index, this.CreateLine(line));
        }

        public bool Remove(ISSALine line) => this.lines.Remove(line ?? throw new ArgumentNullException(nameof(line)));

        public void RemoveAt(int index) => this.lines.RemoveAt(index);
        
        protected internal virtual ISSALine CreateLine(string text)
        {
            if (text.StartsWith(";"))
                return new SSAComment(text.TrimStart(';').Trim());
            else
            {
                Match match = Regex.Match(text, @"^\s*(?<LineName>(\w| )+?)\s*:\s*(?<LineText>(\s|\S)*)$");
                if (match.Success)
                {
                    return this.CreateNamedLine(match.Groups["LineName"].Value, match.Groups["LineText"].Value);
                }
                else
                    return new SSALine(text);
            }
        }

        protected internal virtual ISSALine CreateNamedLine(string name, string text)
        {
            return new SSANamedLine(name, text);
        }
    }
}
