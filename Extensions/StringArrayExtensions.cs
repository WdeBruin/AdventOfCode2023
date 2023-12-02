namespace Advent.Extensions;

public static class StringArrayExtensions
{
    public static int[] ToIntArray(this string[] arr)
    {
        return arr.Select(int.Parse).ToArray();
    }
}
