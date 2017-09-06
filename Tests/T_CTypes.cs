//  *****************************************************************************
//  File:       T_CTypes.cs
//  Solution:   CSTypes
//  Project:    T_CSTypes
//  Date:       09/05/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using CSTypes;
using NUnit.Framework;

namespace Tests {
  public partial class Program {
    /// <summary>
    ///  Internal method to test delegate action.
    /// </summary>
    /// <param name="eval"></param>
    private static void Test(Action<int, int> eval) {
      const int val1 = -1, val2 = 0, val3 = 2, val4 = 10;
      var list = new[] {
        val1,
        val2,
        val3,
        val4
      };

      foreach (var x in list) {
        foreach (var y in list)
          eval(x, y);
      }
    }


    /// <summary>
    ///  AdvWord test.
    /// </summary>
    [Test]
    public void AdvWord() {
      Assert.AreEqual("World", Types.AdvWord("Hello World"));
    }


    /// <summary>
    ///  CopyFirstWord test.
    /// </summary>
    [Test]
    public void CopyFirstWord() {
      const string str = "Hello World";
      Assert.AreEqual("Hello", Types.CopyFirstWord(str));
      Assert.AreEqual("Hello", Types.CopyFirstWord(" " + str));
      Assert.AreEqual("Hello", Types.CopyFirstWord(str + " "));
    }


    /// <summary>
    ///  Dice test.
    /// </summary>
    [Test]
    public void Dice() {
      Test((x, y) => {
        var result = Types.Dice(x, y);
        if (x < 0 || y < 0)
          Assert.AreEqual(0, result);
        else
          Assert.IsTrue(result >= 0 && result <= x * y);
      });
    }


    /// <summary>
    ///  GenerateSaltedHash test.
    /// </summary>
    [Test]
    public void GenerateSaltedHash() {
      Assert.Pass("Hello World => " + Encoding.Default.GetString(Types.GenerateSaltedHash(Encoding.ASCII.GetBytes("Hello World"), Types.GenerateSaltKey())));
    }


    /// <summary>
    ///  GenerateSaltKey test.
    /// </summary>
    [Test]
    public void GenerateSaltKey() {
      Assert.Pass(Encoding.Default.GetString(Types.GenerateSaltKey()));
    }


    /// <summary>
    ///  IsNumber test.
    /// </summary>
    [Test]
    public void IsNumber() {
      var str = new[] {
        new KeyValuePair<string, bool>("-asdf", false),
        new KeyValuePair<string, bool>(" -asdf", false),
        new KeyValuePair<string, bool>(" -asdf ", false),
        new KeyValuePair<string, bool>(" asdf ", false),
        new KeyValuePair<string, bool>("asdf", false),
        new KeyValuePair<string, bool>("asdf ", false),
        new KeyValuePair<string, bool>(" asdf", false),
        new KeyValuePair<string, bool>(" 123", true),
        new KeyValuePair<string, bool>(" 123 ", true),
        new KeyValuePair<string, bool>("123 ", true),
        new KeyValuePair<string, bool>("123", true),
        new KeyValuePair<string, bool>("123.231", false),
        new KeyValuePair<string, bool>("-123.231", false),
        new KeyValuePair<string, bool>("0", true),
        new KeyValuePair<string, bool>("", false)
      };

      foreach (var s in str)
        Assert.IsTrue(Types.IsNumber(s.Key) == s.Value);
    }


    /// <summary>
    ///  IsValidIP test.
    /// </summary>
    [Test]
    // ReSharper disable once InconsistentNaming
    public void IsValidIP() {
      Assert.IsTrue(Types.IsValidIP("10.10.0.1"), "IPv4");
      Assert.IsFalse(Types.IsValidIP("10.256.0.1"), "Out of range");
      Assert.IsFalse(Types.IsValidIP("my home"), "Malformed IP");
      Assert.IsTrue(Types.IsValidIP("FE80:0000:0000:0000:0202:B3FF:FE1E:8329"), "IPv6");
    }


    /// <summary>
    ///  Number test.
    /// </summary>
    [Test]
    public void Number() {
      Test((x, y) => {
        var result = Types.Number(x, y);
        if (x <= y)
          Assert.IsTrue(x <= result && result <= y);
        else
          Assert.IsTrue(y <= result && result <= x);
      });
    }


    /// <summary>
    ///  NumericSuffix test.
    /// </summary>
    [Test]
    public void NumericSuffix() {
      //Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
      string[] list = {
        "0th",
        "1st",
        "2nd",
        "3rd",
        "4th",
        "5th",
        "6th",
        "7th",
        "8th",
        "9th",
        "10th",
        "11th",
        "12th",
        "13th",
        "14th",
        "15th",
        "16th",
        "17th",
        "18th",
        "19th",
        "20th",
        "21st",
        "22nd",
        "23rd",
        "24th",
        "25th",
        "26th",
        "27th",
        "28th",
        "29th",
        "30th",
        "31st",
        "32nd",
        "33rd",
        "34th",
        "35th",
        "36th",
        "37th",
        "38th",
        "39th",
        "40th",
        "41st",
        "42nd",
        "43rd",
        "44th",
        "45th",
        "46th",
        "47th",
        "48th",
        "49th",
        "50th",
        "51st",
        "52nd",
        "53rd",
        "54th",
        "55th",
        "56th",
        "57th",
        "58th",
        "59th",
        "60th",
        "61st",
        "62nd",
        "63rd",
        "64th",
        "65th",
        "66th",
        "67th",
        "68th",
        "69th",
        "70th",
        "71st",
        "72nd",
        "73rd",
        "74th",
        "75th",
        "76th",
        "77th",
        "78th",
        "79th",
        "80th",
        "81st",
        "82nd",
        "83rd",
        "84th",
        "85th",
        "86th",
        "87th",
        "88th",
        "89th",
        "90th",
        "91st",
        "92nd",
        "93rd",
        "94th",
        "95th",
        "96th",
        "97th",
        "98th",
        "99th",
        "100th",
        "101st",
        "102nd",
        "103rd",
        "104th",
        "105th",
        "106th",
        "107th",
        "108th",
        "109th",
        "110th",
        "111th",
        "112th",
        "113th",
        "114th",
        "115th",
        "116th",
        "117th",
        "118th",
        "119th",
        "120th",
        "121st",
        "122nd",
        "123rd",
        "124th",
        "125th",
        "126th",
        "127th",
        "128th",
        "129th",
        "130th"
      };
      for (var x = 0; x <= 130; x++) {
        //Trace.WriteLine(String.Format("{0}{1}", x, Types.NumericSuffix(x)));
        Assert.AreEqual(list[x], x + Types.NumericSuffix(x));
      }
    }


    /// <summary>
    ///  Swap test.
    /// </summary>
    [Test]
    public void Swap() {
      var ary = new[] {
        1,
        2,
        3,
        4,
        5
      };
      Types.Swap(ref ary[0], ref ary[4]);
      Assert.AreEqual(1, ary[4]);
      Assert.AreEqual(5, ary[0]);
    }
  }
}