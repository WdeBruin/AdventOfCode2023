namespace Advent.Extensions;

public static class StringExtensions
{
    public static int ToInt(this string val)
    {
        return int.Parse(val);
    }

    public static int[] ToIntArray(this string val, char splitBy)
    {
        return val.Split(splitBy).ToIntArray();
    }
    
    public static IEnumerable<string> SplitInParts(this string s, int partLength) {
        if (s == null)
            throw new ArgumentNullException(nameof(s));
        if (partLength <= 0)
            throw new ArgumentException("Part length has to be positive.", nameof(partLength));

        for (var i = 0; i < s.Length; i += partLength)
            yield return s.Substring(i, Math.Min(partLength, s.Length - i)).Trim();
    }
}