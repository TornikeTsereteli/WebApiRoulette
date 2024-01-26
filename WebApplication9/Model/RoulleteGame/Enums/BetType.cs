public enum BetType
{
    RED,
    BLACK,
    EVEN,
    ODD,
    FIRSTHALF,
    SECONDHALF,
    FIRSTINTERVAL,
    SECONDINTERVAL,
    THIRDINTERVAL,
    MOD3EQUALS0,
    MOD3EQUALS1,
    MOD3EQUALS2,
    NUMBER
}

public static class BetTypeExtensions
{
    private static readonly Dictionary<BetType, string> Labels = new()
    {
        { BetType.RED, "Red" },
        { BetType.BLACK, "Black" },
        { BetType.EVEN, "Even" },
        { BetType.ODD, "Odd" },
        { BetType.FIRSTHALF, "First Half" },
        { BetType.SECONDHALF, "Second Half" },
        { BetType.FIRSTINTERVAL, "First Interval" },
        { BetType.SECONDINTERVAL, "Second Interval" },
        { BetType.THIRDINTERVAL, "Third Interval" },
        { BetType.MOD3EQUALS0, "Mod 3 Equals 0" },
        { BetType.MOD3EQUALS1, "Mod 3 Equals 1" },
        { BetType.MOD3EQUALS2, "Mod 3 Equals 2" },
        { BetType.NUMBER, "Number" }
    };

    public static string GetLabel(this BetType betType)
    {
        return Labels[betType];
    }

    public static BetType FromString(string text)
    {
        foreach (BetType betType in Enum.GetValues(typeof(BetType)))
            if (Labels[betType].Replace(" ", "").Equals(text.Replace(" ", ""), StringComparison.OrdinalIgnoreCase))
                return betType;
        throw new ArgumentException($"No constant with label {text} found in BetType enum");
    }
}