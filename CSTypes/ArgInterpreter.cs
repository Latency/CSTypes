//  *****************************************************************************
//  File:       ArgInterpreter.cs
//  Solution:   CSTypes
//  Project:    CSTypes
//  Date:       09/05/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CSTypes {
  public enum ArgTypes {
    Words, // tokenize string into words.
    Cut,   // cut after 1st word of string.
    Lines  // tokenize string into lines.
  }


  public class ArgInterpreter : IFluentInterface {
    /// <summary>
    ///   Tokenizes string for processing.
    /// </summary>
    /// <param name="str">String to be processed.</param>
    /// <param name="type">Argument type.  [Cut, Words, Lines]</param>
    public ArgInterpreter(string str, ArgTypes type = ArgTypes.Words) {
      Tokens = new List<string>();
      if (string.IsNullOrEmpty(str))
        return;
      switch (type) {
        case ArgTypes.Cut:
          var m = Regex.Match(str, @"(\S+)[$|\s+](.+)", RegexOptions.Singleline);
          Tokens.Add(m.Groups[1].Value);
          Tokens.Add(m.Groups[2].Value);
          break;
        case ArgTypes.Words:
          Tokens.AddRange(Regex.Split(str.Trim(), @"\s+"));
          break;
        case ArgTypes.Lines:
          Tokens.AddRange(Regex.Split(str.Trim(), @"\r?\n|\n?\r"));
          break;
      }
    }

    public List<string> Tokens { get; }


    /// <summary>
    ///  ToString
    /// </summary>
    /// <returns></returns>
    public new string ToString() {
      return string.Join(" ", Tokens);
    }
  }
}