using CommandLineInfo.Core.ComponentModel1;
using SamLu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TimelineComposite.CommandLine
{
    public class NamedFileListOptions : ListOption
    {
        public override object Value
        {
            get
            {
                Regex regex = new Regex(@"^(?<Name>[^\=]+)=(?<FileName>[\S]+)$", RegexOptions.Compiled);
                NamedFileCollection collection = new NamedFileCollection(
                    base.values.Select(value =>
                    {
                        Match match = regex.Match(value);
                        if (match.Success)
                            return new KeyValuePair<ValueBox<string>, string>(match.Groups["Name"].Value, match.Groups["FileName"].Value);
                        else
                            return new KeyValuePair<ValueBox<string>, string>(ValueBox<string>.Empty, value);
                    }).ToDictionary(
                        pair=>pair.Key,
                        pair=>pair.Value
                    )
                );
                return collection;
            }
            protected set => throw new NotSupportedException();
        }

        public NamedFileListOptions(string name, string description) : this(name, description, "[alias=]filepath")
        {
        }

        public NamedFileListOptions(string name, string description, string template) : base(name, description, template)
        {
        }

        protected override ParseResult ParseArgument(string argument)
        {
            return base.ParseArgument(argument);
        }
    }
}
