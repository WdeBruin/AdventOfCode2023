using System.Runtime.CompilerServices;
using Advent.Extensions;

namespace Advent.Solutions;

public class Day10 : DayBase
{
    public override void Run()
    {
        var lines = ReadInput("Day10.txt");

        int numRows = lines.Length;
        int numCols = lines[0].Length;
        char[,] pipeMap = new char[numRows, numCols];
        
        int startX = 0;
        int startY = 0;

        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                pipeMap[i, j] = lines[i][j];
                if (pipeMap[i,j] == 'S')
                {
                    startX = j;
                    startY = i;
                }
                Console.Write(pipeMap[i, j]);
            }
            Console.Write("\n");
        }

        List<(int, int, char)[]> paths = new();

        while (!paths.Any(p => p.Last().Item3 == 'S'))
        {
            var north = pipeMap.GetNorth(startY, startX);
            var south = pipeMap.GetSouth(startY, startX);
            var west = pipeMap.GetWest(startY, startX);
            var east = pipeMap.GetEast(startY, startX);
        }
    }
}
