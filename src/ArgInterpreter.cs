// ****************************************************************************
// Project:  CSTypes
// File:     ArgInterpreter.cs
// Author:   Latency McLaughlin
// Date:     04/11/2024
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CSTypes;

public enum ArgTypes
{
    Words, // tokenize string into words.
    Cut,   // cut after 1st word of string.
    Lines  // tokenize string into lines.
}

public class ArgInterpreter : IFluentInterface
{
    /// <summary>
    ///     Tokenizes string for processing.
    /// </summary>
    /// <param name="str">String to be processed.</param>
    /// <param name="type">Argument type.  [Cut, Words, Lines]</param>
    public ArgInterpreter(string str, ArgTypes type = ArgTypes.Words)
    {
        Tokens = [];
        if (string.IsNullOrEmpty(str))
            return;

        switch (type)
        {
            case ArgTypes.Cut:
                var m = Regex.Match(str, @"\s*([^ ]+)\s*(.*)", RegexOptions.Singleline);
                Tokens.Add(m.Groups[1].Value);
                if (!string.IsNullOrEmpty(m.Groups[2].Value))
                    Tokens.Add(m.Groups[2].Value);
                break;
            case ArgTypes.Words:
                Tokens.AddRange(str.Trim().Split([" ", "\n", "\r\n"], StringSplitOptions.RemoveEmptyEntries));
                break;
            case ArgTypes.Lines:
                Tokens.AddRange(Regex.Split(str.Trim(), @"\r?\n|\n?\r"));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    public List<string> Tokens { get; }


    /// <summary>
    ///     ToString
    /// </summary>
    /// <returns></returns>
    public new string ToString() => string.Join(" ", Tokens);
}