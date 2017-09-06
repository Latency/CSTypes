// *****************************************************************************
// File:      T_ArgInterpreter.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************
using CSTypes;
using NUnit.Framework;

namespace Tests {
  [TestFixture]
  public partial class Program {
    private const string Str = "\r\nthe crazy brown fox jumps over a lazy dog\nLast night I found out something\r\nThat's the spirit\n\r";

    [Test]
    public void ArgTest_Words() {
      var arg = new ArgInterpreter(Str, ArgTypes.Words);
      Assert.AreEqual(18, arg.Tokens.Count);
    }

    [Test]
    public void ArgTest_Cut() {
      var arg = new ArgInterpreter(Str, ArgTypes.Cut);
      Assert.AreEqual(2, arg.Tokens.Count);
      Assert.AreEqual("the", arg.Tokens[0], "First token[0]");
      Assert.AreEqual("crazy brown fox jumps over a lazy dog\nLast night I found out something\r\nThat's the spirit\n\r", arg.Tokens[1], "Second token[1]");
    }

    [Test]
    public void ArgTest_Lines() {
      var arg = new ArgInterpreter(Str, ArgTypes.Lines);
      Assert.AreEqual(3, arg.Tokens.Count);
    }

    [Test]
    public void ArgTest_ToString() {
      var arg = new ArgInterpreter(Str, ArgTypes.Cut);
      Assert.AreEqual(Str.TrimStart('\n', '\r'), arg.ToString());
    }
  }
}