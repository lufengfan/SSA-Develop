﻿using SamLu;
using SSA;
using SSA.Extension;
using SSA.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimelineComposite.SSA;

namespace TimelineComposite
{
    static class Program
    {
        public static string TemplateFileName;
        public static CommandLine.NamedFileCollection LangTextFileNames;
        public static string[] LangsOrder;
        public static string OutputFileName;

        public static void Run()
        {
#if false
            string file = Console.ReadLine().Replace("\"", string.Empty);
            SSADocument document = new SSADocument();
            document.Load(file);
            ;
#endif

            SpecializedSSADocument templateDocument = new SpecializedSSADocument();
            templateDocument.Load(Program.TemplateFileName);

            SSADocument document = new SSADocument();
            IDictionary<string, Tuple<string, SSANamedSection[]>>[] dictionaries =
                Program.LangsOrder.Select(order =>
                {
                    string langTextFileName = Program.LangTextFileNames[order];
                    SpecializedSSADocument langSSADocument = new SpecializedSSADocument();
                    langSSADocument.Load(langTextFileName);
                    return langSSADocument.Sections
                        .OfType<SSANamedSection>()
                        .GroupBy(section => section.Name)
                        .ToDictionary(
                            sections => sections.Key,
                            sections => new Tuple<string, SSANamedSection[]>(order, sections.ToArray())
                        );
                }).ToArray();

            IList<string> langNames = new List<string>();
            foreach (var section in templateDocument.Sections)
            {
                if (!(section is SSANamedSection))
                {
                    var _section = document.CreateSection();
                    foreach (var line in section.Lines) _section.Add(line);
                }
                else
                {
                    SSANamedSection originalSection = (SSANamedSection)section;
                    SSASection resultSection;
                    if (originalSection is SSAScriptInfoSection)
                    {
                        var scriptInfo = document.ScriptInfo;
                        resultSection = scriptInfo;

                        foreach (var line in originalSection.Lines.OfType<SSANamedLine>())
                            resultSection.Add(line);
                        scriptInfo.Title = ((SSAScriptInfoSection)originalSection).Title;
                    }
                    else resultSection = document.CreateSection(originalSection.Name);

                    if (originalSection is SSAFormattedSection)
                        resultSection.Add(((SSAFormattedSection)originalSection).FormatLine);

                    ISet<ISSALine> templateExtensionLines = new HashSet<ISSALine>();
                    foreach (var dictionary in dictionaries)
                    {
                        if (dictionary.TryGetValue(originalSection.Name, out Tuple<string, SSANamedSection[]> tuple))
                        {
                            string langName = tuple.Item1;
                            SSANamedSection[] namedSections = tuple.Item2;
                            foreach (var newSection in namedSections)
                            {
                                if (originalSection is SSAFormattedSection originalFormattedSection && newSection is SSAFormattedSection newFormattedSection)
                                {
                                    SSAFormatLine originalFortmatLine = originalFormattedSection.FormatLine;
                                    if (originalFormattedSection is SSAEventsSection eventSection)
                                    {
                                        foreach (var group in
                                            new []
                                            {
                                                originalFormattedSection.Lines
                                                    .Skip(1)
                                                    .IndexItems()
                                                    .Where(item => !(item.Value is SSAFormatLine)),
                                                newFormattedSection.Lines
                                                    .Skip(1)
                                                    .IndexItems()
                                                    .Where(item => !(item.Value is SSAFormatLine))
                                            }.MakeGroupWhile(controlCallback: argument =>
                                                {
                                                    if (!argument.Group[0].HasValue && !argument.Group[1].HasValue)
                                                    {
                                                        argument.Cancel = true;
                                                        return true;
                                                    }
                                                    else if (argument.Group[0].HasValue ^ argument.Group[1].HasValue)
                                                    {
                                                        if (argument.Group[0].HasValue)
                                                        {
                                                            if (argument.Group[0].Value is SSALabelLine)
                                                                argument.Cancel = true;
                                                            else if (argument.Group[0].Value is SSAPlaceHolderLine)
                                                                argument.Skip[0] = true;
                                                        }
                                                        else
                                                        {
                                                            if (argument.Group[1].Value is SSALabelLine)
                                                                argument.Cancel = true;
                                                            else if (argument.Group[1].Value is SSAPlaceHolderLine)
                                                                argument.Skip[1] = true;
                                                        }

                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        IIndexing<ISSALine> line1 = argument.Group[0].Value;
                                                        IIndexing<ISSALine> line2 = argument.Group[1].Value;

                                                        if (line1.Value is SSALabelLine ^ line2.Value is SSALabelLine)
                                                            argument.Cancel = true;
                                                        else if (line1.Value is SSALabelLine && line2.Value is SSALabelLine)
                                                        {
                                                            argument.Skip[0] = true;
                                                            argument.Skip[1] = true;
                                                            argument.Cancel = ((SSALabelLine)line1).LineText != ((SSALabelLine)line2).LineText;
                                                        }
                                                        else if (line1.Value is SSAPlaceHolderLine || line1.Value is SSAPlaceInsertLine || line2.Value is SSAPlaceHolderLine || line2.Value is SSAPlaceInsertLine)
                                                        {
                                                            if (line1.Value is SSAPlaceHolderLine)
                                                            {
                                                                argument.MoveNext[0] = true;
                                                                argument.Skip[0] = true;
                                                            }
                                                            else if (line1.Value is SSAPlaceInsertLine)
                                                            {
                                                                argument.MoveNext[0] = true;
                                                                argument.Skip[0] = false;
                                                            }
                                                            else
                                                            {
                                                                argument.MoveNext[0] = false;
                                                                argument.Skip[0] = false;
                                                            }

                                                            if (line2.Value is SSAPlaceHolderLine)
                                                            {
                                                                argument.MoveNext[1] = true;
                                                                argument.Skip[1] = true;
                                                            }
                                                            else if (line2.Value is SSAPlaceInsertLine)
                                                            {
                                                                argument.MoveNext[1] = true;
                                                                argument.Skip[1] = false;
                                                            }
                                                            else
                                                            {
                                                                argument.MoveNext[1] = false;
                                                                argument.Skip[1] = false;
                                                            }

                                                            if (line1.Value is SSAPlaceInsertLine && line2.Value is SSAPlaceInsertLine)
                                                            {
                                                                argument.MoveNext[0] = true;
                                                                argument.MoveNext[1] = false;
                                                                argument.Skip[0] = false;
                                                                argument.Skip[1] = false;
                                                            }
                                                        }
                                                        else if (string.IsNullOrWhiteSpace(line1.Value.LineText) || string.IsNullOrWhiteSpace(line2.Value.LineText))
                                                        {
                                                            if (string.IsNullOrWhiteSpace(line1.Value.LineText))
                                                                argument.MoveNext[0] = true;
                                                            else
                                                                argument.MoveNext[0] = false;

                                                            if (string.IsNullOrWhiteSpace(line2.Value.LineText))
                                                                argument.MoveNext[1] = true;
                                                            else
                                                                argument.MoveNext[1] = false;

                                                            return false;
                                                        }
                                                        else
                                                            argument.Cancel = ((SSAFieldsLine)line1.Value).Name != ((SSAFieldsLine)line2.Value).Name;

                                                        return true;
                                                    }
                                                })
                                        )
                                        {
                                            if (!group[0].HasValue && !group[1].HasValue)
                                                continue;
                                            else if (group[0].HasValue ^ group[1].HasValue)
                                            {
                                                if (group[0].HasValue)
                                                {
                                                    if (group[0].Value.Value is SSAPlaceInsertLine placeInsertLine)
                                                    {
                                                        if (!templateExtensionLines.Contains(placeInsertLine))
                                                        {
                                                            resultSection.Add(placeInsertLine.InnerLine);
                                                            templateExtensionLines.Add(placeInsertLine);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //resultSection.Add(group[0].Value.Value);
                                                    }
                                                }
                                                else
                                                {
                                                    ISSALine innerLine;
                                                    if (group[1].Value.Value is SSAPlaceInsertLine)
                                                        innerLine = ((SSAPlaceInsertLine)group[1].Value.Value).InnerLine;
                                                    else innerLine = group[1].Value.Value;

                                                    if (group[1].Value.Value is SSAFieldsLine)
                                                    {
                                                        string[] fields = new string[originalFortmatLine.Fields.Length];
                                                        for (int i = 0; i < fields.Length; i++)
                                                        {
                                                            SSAField originalFormatField = originalFortmatLine.Fields[i];
                                                            var value = newFormattedSection[group[1].Value.Index, originalFormatField.Name];
                                                            if (value.HasValue)
                                                                fields[i] = originalFormatField.SerializeValue(value.Value);
                                                            else
                                                                fields[i] = originalFormatField.DefaultValue.HasValue ? originalFormatField.SerializeValue(originalFormatField.DefaultValue.Value) : string.Empty;
                                                        }
                                                        resultSection.Add(((SSAFormattedSection)resultSection).CreateFieldsLine(((SSAFieldsLine)group[1].Value.Value).Name, fields));
                                                    }
                                                    else resultSection.Add(innerLine);
                                                }
                                            }
                                            else
                                            {
                                                if (group[0].Value.Value is SSAFieldsLine && group[1].Value.Value is SSAFieldsLine)
                                                {
                                                    string[] fields = new string[originalFortmatLine.Fields.Length];
                                                    for (int i = 0; i < fields.Length; i++)
                                                    {
                                                        SSAField originalFormatField = originalFortmatLine.Fields[i];
                                                        var value = newFormattedSection[group[1].Value.Index, originalFormatField.Name];
                                                        if (value.HasValue)
                                                            fields[i] = originalFormatField.SerializeValue(value.Value);
                                                        else if ((value = originalFormattedSection[group[0].Value.Index, originalFormatField.Name]).HasValue)
                                                            fields[i] = originalFormatField.SerializeValue(value.Value);
                                                        else
                                                            fields[i] = originalFormatField.DefaultValue.HasValue ? originalFormatField.SerializeValue(originalFormatField.DefaultValue.Value) : string.Empty;
                                                    }
                                                    resultSection.Add(((SSAFormattedSection)resultSection).CreateFieldsLine(((SSAFieldsLine)group[1].Value.Value).Name, fields));
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        foreach (var originalLine in originalFormattedSection.Lines.OfType<SSAFieldsLine>().NotOfType<SSAFieldsLine, SSAFormatLine>())
                                        {
                                            resultSection.Add(originalLine);
                                        }

                                        foreach (var newLine in
                                            newFormattedSection.Lines
                                                .Skip(1)
                                                .IndexItems()
                                                .Where(item =>
                                                    item.Value is SSAFieldsLine && !(item.Value is SSAFormatLine)
                                                )
                                            )
                                        {
                                            string[] fields = new string[originalFortmatLine.Fields.Length];
                                            for (int i = 0; i < fields.Length; i++)
                                            {
                                                SSAField originalFormatField = originalFortmatLine.Fields[i];
                                                var value = newFormattedSection[newLine.Index, originalFormatField.Name];
                                                if (value.HasValue)
                                                    fields[i] = originalFormatField.SerializeValue(value.Value);
                                                else
                                                    fields[i] = originalFormatField.DefaultValue.HasValue ? originalFormatField.SerializeValue(originalFormatField.DefaultValue.Value) : string.Empty;
                                            }
                                            resultSection.Add(((SSAFormattedSection)resultSection).CreateFieldsLine(((SSAFieldsLine)newLine.Value).Name, fields));
                                        }
                                    }
                                }
                                else if (originalSection is SSAScriptInfoSection scriptInfoSection)
                                {
                                    foreach (var line in newSection.Lines.OfType<SSANamedLine>().Where(line => !((SSAScriptInfoSection)resultSection).ContainsParameter(line.Name) && line.Name != "LangName"))
                                        resultSection.Add(line);

                                    langNames.Add(((SSANamedLine)((SSAScriptInfoSection)newSection)["LangName"])?.Text ?? langName);
                                }
                                else
                                {
                                    foreach (var newLine in newSection.Lines.Skip(1).NotOfType<ISSALine, SSAComment>())
                                    {
                                        if (newLine is SSANamedLine &&
                                            originalSection.Lines.OfType<SSANamedLine>()
                                                .Any(originalLine => originalLine.Name == ((SSANamedLine)newLine).Name)
                                        )
                                            resultSection.Add(originalSection.Lines.OfType<SSANamedLine>().First(originalLine => originalLine.Name == ((SSANamedLine)newLine).Name));
                                        else
                                            resultSection.Add(newLine);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            document.ScriptInfo.Title += $"({string.Join("+", langNames)})";

            document.Save(Program.OutputFileName);
        }
    }
}
