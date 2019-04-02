using Markdig;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Newtonsoft.Json;

namespace XamarinUniverse_Backend.Test.Services
{
    public class MarkdownServiceTest
    {
        private const string MdTest = "# Markdig [![Build status](https://ci.appveyor.com/api/projects/status/hk391x8jcskxt1u8?svg=true)](https://ci.appveyor.com/project/xoofx/markdig) [![NuGet](https://img.shields.io/nuget/v/Markdig.svg)](https://www.nuget.org/packages/Markdig/) [![Donate](https://www.paypalobjects.com/en_US/i/btn/btn_donate_SM.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=FRGHXBTP442JL)"
        +"\n\n< img align=\"right\" width=\"160px\" height=\"160px\" src=\"img/markdig.png\">"
        +"\n\nMarkdig is a fast, powerful, [CommonMark](http://commonmark.org/) compliant, extensible Markdown processor for .NET."
        +"\n\n> NOTE: The repository is under construction.There will be a dedicated website and proper documentation at some point!"
        +"\n\nYou can **try Markdig online** and compare it to other implementations on[babelmark3](https://babelmark.github.io/?text=Hello+**Markdig**!)"
        +"\n\n## Features"
        + "\n- **Very fast parser and html renderer** (no-regexp), very lightweight in terms of GC pressure.See benchmarks"
        + "\n- **Abstract Syntax Tree** with precise source code location for syntax tree, useful when building a Markdown editor."
        + "\n\t- Checkout[MarkdownEditor for Visual Studio](https://visualstudiogallery.msdn.microsoft.com/eaab33c3-437b-4918-8354-872dfe5d1bfe) powered by Markdig!"
        + "\n- Converter to **HTML**"
        + "\n- Passing more than**600+ tests** from the latest [CommonMark specs(0.28)](http://spec.commonmark.org/)"
        + "\n- Includes all the core elements of CommonMark:"
        + "\n- including** GFM fenced code blocks**.";

        [Fact]
        public void MarkDownParserMarkDigTest()
        {
            var build = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            var result = Markdown.Parse(MdTest, build);
            var resultHeader = result[0];
        }

    }
}
