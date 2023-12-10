namespace Advent.Extensions;
public static class CharArrayExtensions
{
    public static char GetNorth(this char[,] array, int row, int col)
    {
        if (row > 0)
        {
            return array[row - 1, col];
        }
        else
        {
            throw new IndexOutOfRangeException("Cannot get value to the north; index out of range.");
        }
    }

    public static char GetSouth(this char[,] array, int row, int col)
    {
        if (row < array.GetLength(0) - 1)
        {
            return array[row + 1, col];
        }
        else
        {
            throw new IndexOutOfRangeException("Cannot get value to the south; index out of range.");
        }
    }

    public static char GetEast(this char[,] array, int row, int col)
    {
        if (col < array.GetLength(1) - 1)
        {
            return array[row, col + 1];
        }
        else
        {
            throw new IndexOutOfRangeException("Cannot get value to the east; index out of range.");
        }
    }

    public static char GetWest(this char[,] array, int row, int col)
    {
        if (col > 0)
        {
            return array[row, col - 1];
        }
        else
        {
            throw new IndexOutOfRangeException("Cannot get value to the west; index out of range.");
        }
    }
}
