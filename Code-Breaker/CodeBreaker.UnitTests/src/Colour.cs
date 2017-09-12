using System.Runtime.Remoting.Messaging;
using CodeBreaker.UnitTests;

namespace CodeBreaker.UnitTests
{
    // Is it okay to have an empty enum?
    public enum Colour
    {
        Empty = -1,
        Red = 'r',
        Green = 'g',
        Yellow = 'y',
        Cyan = 'c',
        White = 'w'
    }

    public enum Peg
    {
        Black = 'b',
        White = 'w'
    }
}

public static class ColourExtension
{
    public static string ToFriendlyString(this Colour c)
    {
        switch (c)
        {
            case Colour.Empty:
                return "e";
            case Colour.Red:
                return "r";
            case Colour.Green:
                return "g";
            case Colour.Yellow:
                return "y";
            case Colour.Cyan:
                return "c";
            case Colour.White:
                return "w";
            default:
                return "No Enum String Assigned!";
        }
    }
}

public static class PegExtension
{
    public static string ToFriendlyString(this Peg p)
    {
        switch (p)
        {
            case Peg.Black:
                return "b";
            case Peg.White:
                return "w";
            default:
                return "No Enum String Assigned!";
        }
    }
}

