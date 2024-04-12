// ****************************************************************************
// Project:  Unit Tests
// File:     T_ArgInterpreter.cs
// Author:   Latency McLaughlin
// Date:     04/11/2024
// ****************************************************************************

using CSTypes;

namespace Unit_Tests;

public partial class Program
{
    private const string Str = "\r\nthe crazy brown fox jumps over a lazy dog\nLast night I found out something\r\nThat's the spirit\n\r";

    [Fact]
    public void ArgTest_Words()
    {
        var arg = new ArgInterpreter(Str);
        Assert.Equal(18, arg.Tokens.Count);
    }

    [Fact]
    public void ArgTest_Cut()
    {
        var arg = new ArgInterpreter(Str, ArgTypes.Cut);
        Assert.Equal(2,                                                                                                  arg.Tokens.Count);
        Assert.Equal("the",                                                                                              arg.Tokens[0]);
        Assert.Equal("crazy brown fox jumps over a lazy dog\nLast night I found out something\r\nThat's the spirit\n\r", arg.Tokens[1]);
    }

    [Fact]
    public void ArgTest_Lines()
    {
        var arg = new ArgInterpreter(Str, ArgTypes.Lines);
        Assert.Equal(3, arg.Tokens.Count);
    }

    [Fact]
    public void ArgTest_ToString()
    {
        var arg = new ArgInterpreter(Str, ArgTypes.Cut);
        Assert.Equal(Str.TrimStart('\n', '\r'), arg.ToString());
    }
}