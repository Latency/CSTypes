// ****************************************************************************
// Project:  Unit Tests
// File:     Base.cs
// Author:   Latency McLaughlin
// Date:     04/11/2024
// ****************************************************************************

namespace Unit_Tests;

/// <summary>
///     Primary Constructor
/// </summary>
/// <param name="console"></param>
public abstract class Base(ITestOutputHelper console)
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    protected readonly ITestOutputHelper Console = console;
}