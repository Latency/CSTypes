---

## Navigation

* [Introduction](#introduction)
* [Usage](#usage)
* [Installation](#installation)
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