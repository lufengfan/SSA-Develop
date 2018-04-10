using SSA;
using SSA.Extension;
using SSA.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TimelineComposite.SSA
{
    internal class SpecializedSSAEventsSection : SSAEventsSection
    {
        public static readonly Regex FormatItemRegex = new Regex(@"^(?<StartBrace>\{\{)|(?<EndBrace>\}\})|(?<FormatItem>\{\s*(?<Start>\d+)\s*,\s*(?<Length>\d*)\s*\})", RegexOptions.Compiled);
        public static readonly Regex FormatStringRegex = new Regex(@"^\s*\\(?<Format>(\s|\S)*)\\\s*$", RegexOptions.Compiled);
        public const string DefaultPredefineLineFormat = "{0,}";
        protected string predefineLineFormat = DefaultPredefineLineFormat;
        protected bool formatSwitch = false;

        protected override ISSALine CreateLine(string text) => this.CreateFormatableLine(text, true);

        protected virtual ISSALine CreateFormatableLine(string text, bool formatable)
        {
            ISSALine line = base.CreateLine(text);
            if (!formatable) return line;
            else if (line is SSAPredefineLineFormatLine predefineLineFormatLine &&
                FormatStringRegex.Match(predefineLineFormatLine.Text) is Match match &&
                match.Success
            )
            {
                this.predefineLineFormat = match.Groups["Format"].Value;
                this.formatSwitch = true;
                return null;
            }
            else if (line is SSAPredefineLineFormatClearLine)
            {
                this.predefineLineFormat = DefaultPredefineLineFormat;
                this.formatSwitch = false;
                return null;
            }
            else if (this.formatSwitch && line is SSARawTextLine)
            {
                string[] fields = line.LineText.Split(',');

                string newText = FormatItemRegex.Replace(this.predefineLineFormat, mFormatItem =>
                {
                    if (mFormatItem.Groups["StartBrace"].Success) return "{";
                    else if (mFormatItem.Groups["EndBrace"].Success) return "}";
                    else if (mFormatItem.Groups["FormatItem"].Success)
                    {
                        int start = int.Parse(mFormatItem.Groups["Start"].Value);
                        int? length;
                        if (mFormatItem.Groups["Length"].Value is string lengthStr &&
                            !string.IsNullOrEmpty(lengthStr)
                        )
                            length = int.Parse(lengthStr);
                        else
                            length = null;

                        if (start >= fields.Length)
                        {
                            return string.Empty;
                            //throw new PredefineFormatItemException($"缺少第{start + 1}个字段。");
                        }
                        else if (length.HasValue && (start + length.Value) >= fields.Length)
                        {
                            length = fields.Length - start;
                            //throw new PredefineFormatItemException("缺少字段");
                        }
                        else if (!length.HasValue)
                            length = fields.Length - start;

                        return string.Join(",", fields.Skip(start).Take(length.Value));
                    }
                    else return string.Empty;
                });
                return this.CreateFormatableLine(newText, false);
            }
            else return line;
        }

        protected override ISSALine CreateNamedLine(string name, string text)
        {
            switch (name)
            {
                case "PredefineLineFormat":
                    return new SSAPredefineLineFormatLine(text);
                case "PredefineLineFormatClear":
                    return new SSAPredefineLineFormatClearLine();
                default:
                    return base.CreateNamedLine(name, text);
            }
        }
    }
}
