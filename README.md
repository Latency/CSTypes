# CSTypes
 
C# Types Argument Parser
 
| | Description |
|---|---|
| ASSEMBLY NAME: | CSTypes |
| CREATED BY: | [Latency McLaughlin] |
| UPDATED: | 10/16/2026 |
| FRAMEWORKS: | net45, net451, net452, net46, net461, net462, net47, net471, net472, net48, net481, netstandard2.0, netstandard2.1, net8.0, net9.0, net10.0, net11.0 |
| LANGUAGE: | [C#] preview |
| OUTPUT TYPE: | [Library] [API] |
| SUPPORTS: | [Visual Studio] |
| GFX SUBSYS: | [None] |
| TAGS: | [ArgInterpreter], [CSTypes], [C#] |
| STATUS: | [![workflow-badge](https://github.com/Latency/CSTypes/actions/workflows/status.yml/badge.svg)](https://github.com/Latency/CSTypes/actions/workflows/status.yml) |
| LICENSE: | [![license-badge](https://img.shields.io/github/license/Latency/CSTypes?style=plastic&logo=GitHub&logoColor=black&label=License&color=yellowgreen)](https://github.com/Latency/CSTypes/blob/master/MIT-LICENSE.txt) |
| VERSION: | 1.0.9 |
 
---

## Navigation

* [Introduction](#introduction)
* [Usage](#usage)
* [Installation](#installation)
* [License](#license)
* [Installation](#installation)
* [References](#references)
* [Report An Issue](#report-an-issue)
* [Donation](#donation)
* [License](#license)

---

## Introduction

CSTypes is a lightweight C# utility library for text-driven games and command-style applications. It provides:

- **Command parsing:** split input into words, lines, or a command and its remainder with `ArgInterpreter`, and peel off words with `CopyFirstWord` and `AdvWord`.
- **Dice and random numbers:** roll dice (`Dice`), generate bounded random numbers (`Number`), and format ordinals such as 1st, 2nd and 3rd (`NumericSuffix`).
- **Validation helpers:** check for whole numbers (`IsNumber`) and valid IPv4/IPv6 addresses (`IsValidIP`).
- **Security helpers:** generate salt keys and SHA-256 salted hashes for storing passwords.

The library multi-targets .NET Framework 4.5 through 4.8.1, .NET Standard 2.0/2.1, and .NET 8 through .NET 11.

## Usage

### `ArgInterpreter`

Tokenizes a string into `Tokens` (`List<string>`).

| Member | Description |
|---|---|
| `ArgInterpreter(string str, ArgTypes type = ArgTypes.Words)` | Tokenizes `str` according to `type`. |
| `Tokens` | The resulting tokens. |
| `ToString()` | Joins the tokens with a single space. |

### `ArgTypes`

| Value | Description |
|---|---|
| `Words` | Tokenize the string into words. |
| `Cut` | Cut after the first word of the string. |
| `Lines` | Tokenize the string into lines. |

### `Types` (static)

| Method | Description |
|---|---|
| `string CopyFirstWord(string s)` | Returns the first word of a string. |
| `string AdvWord(string text, bool withPunctuation = false)` | Returns the string with its first word skipped, optionally treating punctuation as delimiters. |
| `void Swap<T>(ref T x, ref T y)` | Swaps two values. |
| `int Number(int minValue, int maxValue)` | Returns a random number in the range; reversed bounds are swapped. |
| `int Dice(int number, int size)` | Simulates rolling `number` dice with `size` sides. Returns 0 for non-positive arguments. |
| `bool IsNumber(string str)` | Checks whether a string is a whole number. |
| `bool IsValidIP(string addr)` | Validates IPv4 and IPv6 addresses (full and compressed). |
| `string NumericSuffix(int number)` | Returns the ordinal suffix of a number (`st`, `nd`, `rd`, `th`). |
| `byte[] GenerateSaltKey()` | Generates a random 8-byte salt key. |
| `byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)` | Generates a SHA-256 salted hash. |

## Installation

This library can be installed using NuGet found [here](https://www.nuget.org/packages/CSTypes/).

## License

The source code for the site is licensed under the MIT license, which you can find in
the [MIT-LICENSE].txt file.

---

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job.)

   [GNU LESSER GENERAL PUBLIC LICENSE]: <http://www.gnu.org/licenses/lgpl-3.0.en.html>
   [MIT-License]: <http://choosealicense.com/licenses/mit/>
 
## Installation

This library can be installed from [NuGet].

## References

[CSTypes], [ArgInterpreter]

## Report An Issue

If you have a patch to contribute, a feature to request, or a bug to report, please post to the [Issue Tracker](https://github.com/Latency/CSTypes/issues).

## Donation

Click the button to donate to my efforts:
[![Donate via Paypal](https://www.paypal.com/en_US/i/btn/btn_donateCC_LG.gif)](https://paypal.me/Latency2?country.x=US&locale.x=en_US)

## License

The source code for the site is licensed under the MIT license, which you can find in the [MIT-LICENSE].txt file.
  
---

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job.)

   [NuGet]: <https://github.com/Latency/CSTypes/pkgs/nuget/CSTypes/>
   [.NET]: <https://en.wikipedia.org/wiki/.NET_Framework/>
   [Visual Studio]: <https://en.wikipedia.org/wiki/Microsoft_Visual_Studio/>
   [Library]: <https://en.wikipedia.org/wiki/Software_library/>
   [Latency McLaughlin]: <https://www.linkedin.com/in/Latency/>
   [API]: <https://en.wikipedia.org/wiki/Application_programming_interface>
   [C#]: <https://en.wikipedia.org/wiki/C_Sharp_(programming_language)>
   [DLL]: <https://en.wikipedia.org/wiki/Dynamic-link_library>
   [MIT-License]: <http://choosealicense.com/licenses/mit/>
   [WPF]: <https://en.wikipedia.org/wiki/Windows_Presentation_Foundation/>
   [WinForms]: <https://en.wikipedia.org/wiki/Windows_Forms/>
   [Unit Tests]: <https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-csharp-with-xunit>
   [CSTypes]: <https://github.com/Latency/CSTypes>
   [ArgInterpreter]: <https://github.com/Special-Delights/Circle-3.5/blob/master/src/interpreter.c>
