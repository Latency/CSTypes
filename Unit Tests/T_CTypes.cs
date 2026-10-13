// ****************************************************************************
// Project:  Unit Tests
// File:     T_CTypes.cs
// Author:   Latency McLaughlin
// Date:     04/11/2024
// ****************************************************************************

using System.Text;
using CSTypes;

namespace Unit_Tests;

public partial class Program
{
    /// <summary>
    ///     Internal method to test delegate action.
    /// </summary>
    /// <param name="eval"></param>
    private static void Test(Action<int, int> eval)
    {
        const int val1 = -1,
                  val2 = 0,
                  val3 = 2,
                  val4 = 10;

        var list = new[]
        {
            val1,
            val2,
            val3,
            val4
        };

        foreach (var x in list)
        {
            foreach (var y in list)
                eval(x, y);
        }
    }


    /// <summary>
    ///     AdvWord test.
    /// </summary>
    [Theory]
    [InlineData(" Hello World")]
    [InlineData("Hello World ")]
    [InlineData(" Hello World ")]
    [InlineData("Hello World")]
    public void AdvWord(string str) => Assert.Contains("World", Types.AdvWord(str));


    /// <summary>
    ///     CopyFirstWord test.
    /// </summary>
    [Theory]
    [InlineData(" Hello World")]
    [InlineData("Hello World ")]
    [InlineData(" Hello World ")]
    [InlineData("Hello World")]
    public void CopyFirstWord(string str) => Assert.Equal("Hello", Types.CopyFirstWord(str));


    /// <summary>
    ///     Dice test.
    /// </summary>
    [Fact]
    public void Dice() => Test((x, y) =>
    {
        var result = Types.Dice(x, y);
        if (x < 0 || y < 0)
            Assert.Equal(0, result);
        else
            Assert.True(result >= 0 && result <= x * y);
    });


    /// <summary>
    ///     GenerateSaltedHash test.
    /// </summary>
    [Fact]
    public void GenerateSaltedHash() => Assert.NotEmpty($"Hello World => {Encoding.Default.GetString(Types.GenerateSaltedHash([.. "Hello World"u8], Types.GenerateSaltKey()))}");


    /// <summary>
    ///     GenerateSaltKey test.
    /// </summary>
    [Fact]
    public void GenerateSaltKey() => Assert.NotEmpty(Encoding.Default.GetString(Types.GenerateSaltKey()));


    /// <summary>
    ///     IsNumber test.
    /// </summary>
    [Theory]
    [InlineData("-asdf",    false)]
    [InlineData(" -asdf",   false)]
    [InlineData(" -asdf ",  false)]
    [InlineData(" asdf ",   false)]
    [InlineData("asdf",     false)]
    [InlineData("asdf ",    false)]
    [InlineData(" asdf",    false)]
    [InlineData(" 123",     true)]
    [InlineData(" 123 ",    true)]
    [InlineData("123 ",     true)]
    [InlineData("123",      true)]
    [InlineData("123.231",  false)]
    [InlineData("-123.231", false)]
    [InlineData("0",        true)]
    [InlineData("",         false)]
    public void IsNumber(string str, bool expected) => Assert.Equal(expected, Types.IsNumber(str));


    /// <summary>
    ///     IsValidIP test.
    /// </summary>
    [Theory]
    [InlineData("10.10.0.1",                               true,  "IPv4")]
    [InlineData("10.256.0.1",                              false, "Out of range")]
    [InlineData("my home",                                 false, "Malformed IP")]
    [InlineData("FE80:0000:0000:0000:0202:B3FF:FE1E:8329", true,  "IPv6")]
    // ReSharper disable once InconsistentNaming
    public void IsValidIP(string input, bool expectedResult, string msg) => Assert.True(Types.IsValidIP(input) == expectedResult, msg);


    /// <summary>
    ///     Number test.
    /// </summary>
    [Fact]
    public void Number() => Test((x, y) =>
    {
        var result = Types.Number(x, y);
        if (x <= y)
            Assert.True(x <= result && result <= y);
        else
            Assert.True(y <= result && result <= x);
    });


    /// <summary>
    ///     NumericSuffix test.
    /// </summary>
    [Theory]
    [InlineData(0, "0th")]
    [InlineData(1, "1st")]
    [InlineData(2, "2nd")]
    [InlineData(3, "3rd")]
    [InlineData(4, "4th")]
    [InlineData(5, "5th")]
    [InlineData(6, "6th")]
    [InlineData(7, "7th")]
    [InlineData(8, "8th")]
    [InlineData(9, "9th")]
    [InlineData(10, "10th")]
    [InlineData(11, "11th")]
    [InlineData(12, "12th")]
    [InlineData(13, "13th")]
    [InlineData(14, "14th")]
    [InlineData(15, "15th")]
    [InlineData(16, "16th")]
    [InlineData(17, "17th")]
    [InlineData(18, "18th")]
    [InlineData(19, "19th")]
    [InlineData(20, "20th")]
    [InlineData(21, "21st")]
    [InlineData(22, "22nd")]
    [InlineData(23, "23rd")]
    [InlineData(24, "24th")]
    [InlineData(25, "25th")]
    [InlineData(26, "26th")]
    [InlineData(27, "27th")]
    [InlineData(28, "28th")]
    [InlineData(29, "29th")]
    [InlineData(30, "30th")]
    [InlineData(31, "31st")]
    [InlineData(32, "32nd")]
    [InlineData(33, "33rd")]
    [InlineData(34, "34th")]
    [InlineData(35, "35th")]
    [InlineData(36, "36th")]
    [InlineData(37, "37th")]
    [InlineData(38, "38th")]
    [InlineData(39, "39th")]
    [InlineData(40, "40th")]
    [InlineData(41, "41st")]
    [InlineData(42, "42nd")]
    [InlineData(43, "43rd")]
    [InlineData(44, "44th")]
    [InlineData(45, "45th")]
    [InlineData(46, "46th")]
    [InlineData(47, "47th")]
    [InlineData(48, "48th")]
    [InlineData(49, "49th")]
    [InlineData(50, "50th")]
    [InlineData(51, "51st")]
    [InlineData(52, "52nd")]
    [InlineData(53, "53rd")]
    [InlineData(54, "54th")]
    [InlineData(55, "55th")]
    [InlineData(56, "56th")]
    [InlineData(57, "57th")]
    [InlineData(58, "58th")]
    [InlineData(59, "59th")]
    [InlineData(60, "60th")]
    [InlineData(61, "61st")]
    [InlineData(62, "62nd")]
    [InlineData(63, "63rd")]
    [InlineData(64, "64th")]
    [InlineData(65, "65th")]
    [InlineData(66, "66th")]
    [InlineData(67, "67th")]
    [InlineData(68, "68th")]
    [InlineData(69, "69th")]
    [InlineData(70, "70th")]
    [InlineData(71, "71st")]
    [InlineData(72, "72nd")]
    [InlineData(73, "73rd")]
    [InlineData(74, "74th")]
    [InlineData(75, "75th")]
    [InlineData(76, "76th")]
    [InlineData(77, "77th")]
    [InlineData(78, "78th")]
    [InlineData(79, "79th")]
    [InlineData(80, "80th")]
    [InlineData(81, "81st")]
    [InlineData(82, "82nd")]
    [InlineData(83, "83rd")]
    [InlineData(84, "84th")]
    [InlineData(85, "85th")]
    [InlineData(86, "86th")]
    [InlineData(87, "87th")]
    [InlineData(88, "88th")]
    [InlineData(89, "89th")]
    [InlineData(90, "90th")]
    [InlineData(91, "91st")]
    [InlineData(92, "92nd")]
    [InlineData(93, "93rd")]
    [InlineData(94, "94th")]
    [InlineData(95, "95th")]
    [InlineData(96, "96th")]
    [InlineData(97, "97th")]
    [InlineData(98, "98th")]
    [InlineData(99, "99th")]
    [InlineData(100, "100th")]
    [InlineData(101, "101st")]
    [InlineData(102, "102nd")]
    [InlineData(103, "103rd")]
    [InlineData(104, "104th")]
    [InlineData(105, "105th")]
    [InlineData(106, "106th")]
    [InlineData(107, "107th")]
    [InlineData(108, "108th")]
    [InlineData(109, "109th")]
    [InlineData(110, "110th")]
    [InlineData(111, "111th")]
    [InlineData(112, "112th")]
    [InlineData(113, "113th")]
    [InlineData(114, "114th")]
    [InlineData(115, "115th")]
    [InlineData(116, "116th")]
    [InlineData(117, "117th")]
    [InlineData(118, "118th")]
    [InlineData(119, "119th")]
    [InlineData(120, "120th")]
    [InlineData(121, "121st")]
    [InlineData(122, "122nd")]
    [InlineData(123, "123rd")]
    [InlineData(124, "124th")]
    [InlineData(125, "125th")]
    [InlineData(126, "126th")]
    [InlineData(127, "127th")]
    [InlineData(128, "128th")]
    [InlineData(129, "129th")]
    [InlineData(130, "130th")]
    public void NumericSuffix(int number, string expected) => Assert.Equal(expected, number + Types.NumericSuffix(number));


    /// <summary>
    ///     Swap test.
    /// </summary>
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 })]
    public void Swap(int[] ary)
    {
        Types.Swap(ref ary[0], ref ary[4]);
        Assert.Equal(1, ary[4]);
        Assert.Equal(5, ary[0]);
    }
}
