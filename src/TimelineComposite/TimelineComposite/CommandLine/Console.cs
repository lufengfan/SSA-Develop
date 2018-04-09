using CommandLineInfo.Core.ComponentModel1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TimelineComposite.CommandLine
{
    internal static class Console
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
#if true
            OptionCollection options = new OptionCollection();
            options.Add(new FileOption("template", "模版文件。"));
            options.Add(new NamedFileListOptions("languagetexts", "语言文本文件。"));
            options.Add(new ListOption("languagesorder", "输出时的语言顺序。"));
            options.Add(new FileOption("output", "输出文件路径。"));
            options.Add(new SwitchOption("?", "显示此帮助信息。"));
            
            var result = options.ParseArguments(args);

            if (result.Options["?"].IsPresent)
            {
                System.Console.WriteLine("{0} [options]", Path.GetFileNameWithoutExtension(typeof(Program).Assembly.Location));
                options.WriteOptionSummary(System.Console.Out);
                return 1;
            }

            if (!result.Success)
            {
                result.WriteParseErrors(System.Console.Out);
                return 1;
            }
            
            if (options["template"].IsPresent)
                Program.TemplateFileName = (string)options["template"].Value;
            else
            {
                System.Console.WriteLine("未指定模版文件。");
                return 1;
            }
            if (options["languagetexts"].IsPresent)
                Program.LangTextFileNames = (NamedFileCollection)options["languagetexts"].Value;
            else {
                System.Console.WriteLine("未指定语言文本文件。");
                return 1;
            }
            if (options["languagesorder"].IsPresent)
                Program.LangsOrder = (string[])options["languagesorder"].Value;
            else
            {
                System.Console.WriteLine("未指定输出时的语言顺序。");
                return 1;
            }
            if (options["output"].IsPresent)
                Program.OutputFileName = (string)options["output"].Value;
            else
            {
                System.Console.WriteLine("未指定输出文件路径。");
                return 1;
            }
#endif

            Program.Run();
            return 0;
        }
    }
}
