// ****************************************************************************
// Project:  Unit Tests
// File:     T_Format.cs
// Author:   Latency McLaughlin
// Date:     04/11/2024
// ****************************************************************************

namespace Unit_Tests;

public partial class Program
{
    [Fact]
    public static void String_Format()
    {
        var s = string.Format("(C) Currency: . . . . . . . . {0:C}\n"               +                                           // ($12,433.00)
                              "(D) Decimal:. . . . . . . . . {0:D}\n"               +                                           // -12433
                              "(E) Scientific: . . . . . . . {1:E}\n"               +                                           // -1.234345E+004
                              "(F) Fixed point:. . . . . . . {1:F}\n"               +                                           // -12343.45
                              "(G) General:. . . . . . . . . {0:G}\n"               +                                           // -12433
                              "    (default):. . . . . . . . {0} (default = 'G')\n" + "(N) Number: . . . . . . . . . {0:N}\n" + // -12,433.00
                              "(P) Percent:. . . . . . . . . {1:P}\n"               +                                           // -1,234,345.00 %
                              "(R) Round-trip: . . . . . . . {1:R}\n"               +                                           // -12343.45
                              "(X) Hexadecimal:. . . . . . . {0:X}\n",                                                          // FFFFCF6F
                              -12433, -12343.45F
        );
        Assert.InRange(s, "(C)", "FFFFCF6F\n");
    }
}