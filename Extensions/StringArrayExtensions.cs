using System.Reflection;

namespace Advent.Extensions;

public static class StringArrayExtensions
{
    public static int[] ToIntArray(this string[] arr)
    {
        return arr.Select(int.Parse).ToArray();
    }

    public static uint[] ToUIntArray(this string[] arr)
    {
        return arr.Select(uint.Parse).ToArray();
    }

    public static long[] ToLongArray(this string[] arr)
    {
        return arr.Select(long.Parse).ToArray();
    }

    public static List<int> GetAdjacentNumbers(this string[] arr, int x, int y)
    {
        List<int> result = new();
        char[] nrs = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        bool south = false;
        bool north = false;

        if (y != 0 && nrs.Any(n => n == arr[y - 1][x])) // n 
        {
            result.Add(GetFullNumber(arr, x, y - 1));
            north = true;
        }

        if (y != arr.Length - 1 && nrs.Any(n => n == arr[y + 1][x])) // s
        {
            result.Add(GetFullNumber(arr, x, y + 1));
            south = true;
        }

        if (x != 0 && nrs.Any(n => n == arr[y][x - 1])) // w
        {
            result.Add(GetFullNumber(arr, x - 1, y));
        }

        if (x != arr[y].Length - 1 && nrs.Any(n => n == arr[y][x + 1])) // e
        {
            result.Add(GetFullNumber(arr, x + 1, y));
        }

        if (y != 0 && x != 0 && nrs.Any(n => n == arr[y - 1][x - 1])) // nw
        {
            if (north == false)
                result.Add(GetFullNumber(arr, x - 1, y - 1));
        }

        if (y != 0 && x != arr[y].Length - 1 && nrs.Any(n => n == arr[y - 1][x + 1])) //ne
        {
            if (north == false)
                result.Add(GetFullNumber(arr, x + 1, y - 1));
        }

        if (y != arr.Length - 1 && x != arr[y].Length - 1 && nrs.Any(n => n == arr[y + 1][x + 1])) //se
        {
            if (south == false)
                result.Add(GetFullNumber(arr, x + 1, y + 1));
        }

        if (y != arr.Length - 1 && x != 0 && nrs.Any(n => n == arr[y + 1][x - 1])) // sw
        {
            if (south == false)
                result.Add(GetFullNumber(arr, x - 1, y + 1));
        }

        return result;
    }

    private static int GetFullNumber(string[] arr, int x, int y)
    {
        char[] nrs = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        int startX = arr[y][..x].LastIndexOf(arr[y][..x].LastOrDefault(v => !nrs.Any(n => n == v)));
        int endX = arr[y][x..].IndexOf(arr[y][x..].FirstOrDefault(v => !nrs.Any(n => n == v)));

        startX = startX == -1 ? 0 : startX + 1;
        endX = endX == -1 ? arr[y].Length : x + endX;

        return int.Parse(string.Concat(arr[y][startX..endX]));
    }

    public static List<char> GetAdjacentChars(this string[] arr, int x, int y)
    {
        List<char> result = new();

        if (y != 0) // n 
        {
            result.Add(arr[y - 1][x]);
        }

        if (y != arr.Length - 1) // s
        {
            result.Add(arr[y + 1][x]);
        }

        if (x != 0) // w
        {
            result.Add(arr[y][x - 1]);
        }

        if (x != arr[y].Length - 1) // e
        {
            result.Add(arr[y][x + 1]);
        }

        if (y != 0 && x != 0) // nw
        {
            result.Add(arr[y - 1][x - 1]);
        }

        if (y != 0 && x != arr[y].Length - 1) //ne
        {
            result.Add(arr[y - 1][x + 1]);
        }

        if (y != arr.Length - 1 && x != arr[y].Length - 1) //se
        {
            result.Add(arr[y + 1][x + 1]);
        }

        if (y != arr.Length - 1 && x != 0) // sw
        {
            result.Add(arr[y + 1][x - 1]);
        }

        return result;
    }
}
