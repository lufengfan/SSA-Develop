using CommandLineInfo.Core.ComponentModel1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CommandLineInfo.Core.ComponentModel1
{
    public class FileOption : StringOption
    {
        private bool checkExistence;

        public FileOption(string name, string description, bool checkExistence = true) : base(name, description) { }

        public FileOption(string name, string description, string template, bool checkExistence = true) : base(name, description, template) { }

        protected override ParseResult ParseArgument(string argument)
        {
            ParseResult result = base.ParseArgument(argument);
            if (result == ParseResult.Success)
            {
                if (!this.checkExistence || File.Exists((string)this.Value))
                    return ParseResult.Success;
                else
                    return ParseResult.ArgumentNotAllowed;
            }
            else return result;
        }
    }
}
