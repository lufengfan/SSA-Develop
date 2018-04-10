﻿# TimelineComposite - 时间轴多语言字幕合并工具

## 说明

程序主要功能是将多个语言字幕文本合成一个文件。

目前只实现控制台版本。

## 原理

1. 首先需要提供一个【模版文件】，一般为纯时间轴，格式与SSA字幕文件的常用格式兼容。比如以`Format: `开头的行指定启用的字段名称。在此基础上增加了【默认值】功能，例如：
</br>
&nbsp;&nbsp;&nbsp;&nbsp;`
Format: Layer=0, Start, End, Style=Default, Name, MarginL=0, MarginR=0, MarginV=0, Effect, Text
`
</br>
例子中分别给出`Layer`、`Style`、`MarginL`、`MarginR`和`MarginV`的默认值，这样在语言字幕文本中未指定值的字段将自动使用这些值。

2. `[V4+ Styles]`节，即定义字幕格式的节中，合成的过程是按顺序添加，添加的顺序为：
</br>
&nbsp;&nbsp;&nbsp;&nbsp;`1)模版的所有Style` + `2)输出语言顺序最首位的语言字幕文件的所有Style` + `3)输出语言顺序第2位的语言字幕文件的所有Style` + ... + `n)输出语言顺序最末位的语言字幕文件的所有Style`。

3. `[Events]`节，即定义字幕时间轴的节中，合成的过程是逐行对应进行的，即一行模版一行语言字幕文本对应。如果程序发现不能对应，例如
   1. 只有模版而没有语言字幕文本，则不添加任何内容。
   2. 只有语言字幕文本而没有模版，则在语言字幕文本行内容的基础上补全模版启用的所有字段（有默认值则使用默认值，无则为空），添加补全后的行。
   - **注意：4. 中展示的功能允许有限度地不遵循逐行对应的规则。**

4. 拓展的命名行：
   - `PlaceInsert: `以此为开头的行可以在无论模版还是语言字幕文本中使用。若在模版中使用，则不会读取语言字幕文本的下一行；若在语言字幕文本中使用，则不会读取模版的下一行。
   - ~~`PlaceHolder: `以此为开头的行可以在无论模版还是语言字幕文本中使用。表示一个占位行。~~ ==未经过测试，不建议使用。==
   - ~~`Line: `以此为开头的行可以在无论模版还是语言字幕文本中使用。声明一个行标号。在[Events]节的处理流程中有决定性影响。~~ ==未确定使用该行后造成的行为。==

5. `[Script Info]`节，即字幕文件的信息节中，提供了简易的命名功能（没什么卵用）。
    1. 首先需要在模版文件的`[Script Info]`节中设置`Title: `（标题行）的值，不设置自动默认为空。
    2. 在各个语言的字幕文本的`[Script Info]`节中设置`LangName: `（语言名称行）的值，不设置自动默认为在命令行设置的语言名称。
    - 最后输出文件中的`[Script Info]`节中`Title: `（标题行）的值将为
</br>
&nbsp;&nbsp;&nbsp;&nbsp;`i` + `"("` + `ii[0]` + ... + `ii[n]` + `")"`。

* 在示例中，两种语言的字幕文本均只启用了`Style`和`Text`字段，因此使用的默认值补全其余的所有字段。（`Start`和`End`字段的默认值程序自行提供，为`0:00:00.00`）

## 控制台参数

**TimelineComposite** [*options*]

| *options* | 说明 |
|: ----------- |: ---- |
| /*template*:**filepath** | 指定模版文件。 |
| /*languagetexts*:[**alias**=]**filepath**[[,;][**alias**=]**filepath**[[,;][**alias**=]**filepath**[[,;])...]]] | 指定语言文本文件。 |
| /*languagesorder*:**langname**[[,;]**langname**[[,;]**langname**[[,;]...]]] | 指定输出时的语言顺序。 |
| /*output*:**filepath** | 指定输出文件路径。|
| /*?* | 显示此帮助信息。|

## 示例
    【模版文件】：timeline.ass
    【中文简体】：zh-cn.ass
    【日文】：jp.ass
    【输出文件】：output.ass
    【命令行】：
        TimelineComposite /template:timeline.ass /languagetexts:中文简体=zh-cn.ass;日文=jp.ass /languagesorder:日文,中文简体 /output:output.ass