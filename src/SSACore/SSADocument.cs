using SamLu;
using SSA.Primitive;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SSA
{
    [DebuggerDisplay("SectionCount={sections.Count}, LineCount={Lines.Length}")]
    public class SSADocument : ISSAScope, ISSAMultiLine
    {
        protected List<SSASection> sections = new List<SSASection>();

        public SSASection[] Sections => this.sections.ToArray();
        public ISSALine[] Lines => this.sections.Select(section => section.Lines).Join<ISSALine, ISSALine[]>(new SSARawTextLine(string.Empty)).ToArray();

        private SSAScriptInfoSection scriptInfo;
        public SSAScriptInfoSection ScriptInfo
        {
            get {
                if (this.scriptInfo is null)
                {
                    this.scriptInfo = (SSAScriptInfoSection)this.CreateNamedSection("Script Info");
                    this.sections.Add(this.scriptInfo);
                }

                return this.scriptInfo;
            }
        }

        public void Load(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));

            using (StreamReader reader = File.OpenText(path))
            {
                this.Load(reader);
            }
        }

        public void Load(TextReader reader)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));

            this.sections.Clear();
            SSASection section = null;
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null) break;

                Regex regex = new Regex(@"^\s*\[(?<Name>[^\]]+)\]\s*$");
                Match match = regex.Match(line);
                if (match.Success)
                {
                    // 节的开始
                    if (section != null) this.sections.Add(section);

                    section = this.CreateNamedSection(match.Groups["Name"].Value);
                }
                else
                {
                    if (section == null)
                        section = new SSASection(); // 创建一个匿名节。

                    section.Add(line);
                }
            }
            if (section != null) this.sections.Add(section);
        }

        public void Load(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            using (StreamReader reader = new StreamReader(stream))
            {
                this.Load(reader);
            }
        }

        public void LoadFromText(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            using (StringReader reader = new StringReader(text))
            {
                this.Load(reader);
            }
        }

        public virtual SSASection CreateSection(string name = null)
        {
            SSASection section;
            if (name == null)
                section = new SSASection();
            else if (name == "Script Info")
                section = this.ScriptInfo;
            else
                section = this.CreateNamedSection(name);
            this.sections.Add(section);
            return section;
        }

        protected internal virtual SSASection CreateNamedSection(string name)
        {
            switch (name)
            {
                case "Script Info":
                    return new SSAScriptInfoSection();
                case "V4+ Styles":
                    return new SSAV4PlusStylesSection();
                case "Events":
                    return new SSAEventsSection();
                default:
                    return new SSANamedSection(name);
            }
        }

        public void Save(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));

            using (Stream fs = File.Create(path))
            using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
            {
                this.Save(writer);
            }
        }
        
        public void Save(TextWriter writer)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            foreach (var line in this.Lines)
            {
                writer.WriteLine(line.LineText);
            }
        }

        public void Save(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                this.Save(writer);
            }
        }

        public string SaveAsText()
        {
            using (StringWriter writer = new StringWriter())
            {
                this.Save(writer);

                return writer.ToString();
            }
        }
    }
}
