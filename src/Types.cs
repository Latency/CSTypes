// ****************************************************************************
// Project:  CSTypes
// File:     Types.cs
// Author:   Latency McLaughlin
// Date:     04/11/2024
// ****************************************************************************
// ReSharper disable UnusedMember.Global

using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace CSTypes;

public static class Types
{
    /// <summary>
    ///     Obtains the first word of a string
    /// </summary>
    /// <param name="s"></param>
    /// <returns>The first word</returns>
    public static string CopyFirstWord(string s) => s.TrimStart()?.Split(' ')?.FirstOrDefault() ?? "";


    /// <summary>
    ///     Obtains the next word in a string
    /// </summary>
    /// <param name="text"></param>
    /// <param name="withPunctuation"></param>
    /// <returns>Skips the first word of a string</returns>
    public static string AdvWord(string text, bool withPunctuation = false)
    {
        // Split by spaces and remove empty entries (caused by multiple spaces)
        // Trim punctuation like periods or commas from the edges of words
        char[] delimiters =
        [
            ' ', .. withPunctuation
                ? new[]
                {
                    '.',
                    ',',
                    '!',
                    '?',
                    ';',
                    ':'
                }
                :
#if NET46_OR_GREATER || NETSTANDARD
                Array.Empty<char>()
#else
                new char[0]
#endif
        ];
        var words = text.Split(delimiters, 2, StringSplitOptions.RemoveEmptyEntries);
        if (words.Length < 2)
            return string.Empty;

        // Find where the second word begins in the original text
        var index = text.IndexOf(words[1], StringComparison.Ordinal);

        // Extract everything from the start of the second word to the end
        return text[index..];
    }


    /// <summary>
    ///     Swaps 2 object types.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public static void Swap<T>(ref T x, ref T y) => (y, x) = (x, y);


    /// <summary>
    ///     Creates a random number in interval [from;to]
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public static int Number(int minValue, int maxValue)
    {
        // Swap if reversed.
        if (minValue > maxValue)
            Swap(ref minValue, ref maxValue);
        return new Random().Next(minValue, maxValue);
    }


    /// <summary>
    ///     Simulates a dice roll.
    /// </summary>
    /// <param name="number"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public static int Dice(int number, int size) => number <= 0 || size <= 0 ? 0 : Number(size, number * size);


    /// <summary>
    ///     Checks if string is a numeric whole number.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsNumber(string str) => int.TryParse(str, out _);


    /// <summary>
    ///     Validate IPv4, IPv6 (full and compressed), and IPv6v4 (full and compressed) addresses
    /// </summary>
    /// <param name="addr"></param>
    /// <returns></returns>
    // ReSharper disable once InconsistentNaming
    public static bool IsValidIP(string addr) => IPAddress.TryParse(addr, out var ip) && ip is { AddressFamily: AddressFamily.InterNetwork or AddressFamily.InterNetworkV6 };


    /// <summary>
    ///     Returns the suffix of a numberic number.
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static string NumericSuffix(int number)
    {
        string suf;
        switch (number)
        {
            case 1:
            case > 20 when number % 10 == 1 && number % 100 != 11:
                suf = "st";
                break;
            case 2:
            case > 20 when number % 10 == 2 && number % 100 != 12:
                suf = "nd";
                break;
            case 3:
            case > 20 when number % 10 == 3 && number % 100 != 13:
                suf = "rd";
                break;
            default:
                suf = "th";
                break;
        }
        return suf;
    }


    /// <summary>
    ///     Generate a salt key.
    /// </summary>
    /// <returns></returns>
    public static byte[] GenerateSaltKey()
    {
        var salt = new byte[8];
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
        RandomNumberGenerator.Fill(salt);
#else
        using var rng = new RNGCryptoServiceProvider();
        rng.GetBytes(salt);
#endif
        return salt;
    }


    /// <summary>
    ///     Generate a crypto salt hash.
    /// </summary>
    /// <param name="plainText"></param>
    /// <param name="salt"></param>
    /// <returns></returns>
    public static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
    {
        using var algorithm = SHA256.Create();
        if (algorithm == null)
            return [];
        algorithm.TransformBlock(plainText, 0, plainText.Length, null, 0);
        algorithm.TransformFinalBlock(salt, 0, salt.Length);
        return algorithm.Hash ?? [];
    }
}