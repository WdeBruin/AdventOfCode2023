namespace Advent.Extensions;

public static class StringArrayExtensions
{
    public static int[] ToIntArray(this string[] arr)
    {
        return arr.Select(int.Parse).ToArray();
    }

    public static List<char> GetAdjacentChars(this string[] arr, int x, int y)
    {
        List<char> result = new();

        if(y != 0) // n 
        {
            result.Add(arr[y-1][x]);
        }

        if(y != arr.Length - 1) // s
        {
            result.Add(arr[y+1][x]);
        }

        if (x != 0) // w
        {
            result.Add(arr[y][x-1]);
        }

        if (x != arr[y].Length - 1) // e
        {
            result.Add(arr[y][x+1]);
        }

        if (y != 0 && x != 0) // nw
        {
            result.Add(arr[y-1][x-1]);
        }

        if (y != 0 && x != arr[y].Length - 1) //ne
        {
            result.Add(arr[y-1][x+1]);
        }

        if (y != arr.Length - 1 && x != arr[y].Length - 1) //se
        {
            result.Add(arr[y+1][x+1]);
        }

        if (y != arr.Length - 1 && x != 0) // sw
        {
            result.Add(arr[y+1][x-1]);
        }

        return result;
    }
}
