namespace Advent.Extensions;

public static class IntArrayExtensions
{
    public static void ReplaceLowestIfHigher(this int[] array, int value)
    {
        var idx = Array.IndexOf(array, array.Min());
        array[idx] = value > array[idx] ? value : array[idx];
    }
}