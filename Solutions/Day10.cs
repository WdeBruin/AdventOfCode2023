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
                if (pipeMap[i, j] == 'S')
                {
                    startX = j;
                    startY = i;
                }
                Console.Write(pipeMap[i, j]);
            }
            Console.Write("\n");
        }

        List<List<(int, int, char)>> paths = new();
        var north = pipeMap.GetNorth(startY, startX);
        var south = pipeMap.GetSouth(startY, startX);
        var west = pipeMap.GetWest(startY, startX);
        var east = pipeMap.GetEast(startY, startX);
        if (north != '.')
            paths.Add(new List<(int, int, char)> { (startY, startX, 'S'), (startY - 1, startX, north) });
        if (south != '.')
            paths.Add(new List<(int, int, char)> { (startY, startX, 'S'), (startY + 1, startX, south) });
        if (east != '.')
            paths.Add(new List<(int, int, char)> { (startY, startX, 'S'), (startY, startX + 1, east) });
        if (west != '.')
            paths.Add(new List<(int, int, char)> { (startY, startX, 'S'), (startY, startX - 1, west) });

        while (!paths.Any(p => p.Last().Item3 == 'S'))
        {
            foreach (var path in paths)
            {
                var c = path.Last();
                var p = path.Count() > 1 ? path[path.Count - 2] : c;

                switch (c.Item3)
                {
                    case '|':
                        if (p.Item1 < c.Item1) // prev is north
                        {
                            AddSouth(pipeMap, path, c);
                        }
                        else if (p.Item1 > c.Item1) // prev is south
                        {
                            AddNorth(pipeMap, path, c);
                        }
                        break;
                    case '-':
                        if (p.Item2 < c.Item2) // prev is west
                        {
                            AddEast(pipeMap, path, c);
                        }
                        else if (p.Item2 > c.Item2) // prev is east
                        {
                            AddWest(pipeMap, path, c);
                        }
                        break;
                    case 'L':
                        if (p.Item1 < c.Item1) // prev is north
                        {
                            AddEast(pipeMap, path, c);
                        }
                        else if (p.Item2 > c.Item2) // prev is east
                        {
                            AddNorth(pipeMap, path, c);
                        }
                        break;
                    case 'J':
                        if (p.Item1 < c.Item1) // prev is north
                        {
                            AddWest(pipeMap, path, c);
                        }
                        else if (p.Item2 < c.Item2) // prev is west
                        {
                            AddNorth(pipeMap, path, c);
                        }
                        break;
                    case '7':
                        if (p.Item1 > c.Item1) // prev is south
                        {
                            AddWest(pipeMap, path, c);
                        }
                        else if (p.Item2 < c.Item2) // prev is west
                        {
                            AddSouth(pipeMap, path, c);
                        }
                        break;
                    case 'F':
                        if (p.Item1 > c.Item1) // prev is south
                        {
                            AddEast(pipeMap, path, c);
                        }
                        else if (p.Item2 > c.Item2) // prev is east
                        {
                            AddSouth(pipeMap, path, c);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        // Paths are done now. Need to find the middle point of the one that ends with S.
        var completePath = paths.First(x => x.Last().Item3 == 'S');
        Console.WriteLine((completePath.Count-1)/2);
    }

    private void AddWest(char[,] pipeMap, List<(int, int, char)> path, (int, int, char) c)
    {
        char west = pipeMap.GetWest(c.Item1, c.Item2);
        if (west != '.')
            path.Add((c.Item1, c.Item2 - 1, west));
    }

    private void AddEast(char[,] pipeMap, List<(int, int, char)> path, (int, int, char) c)
    {
        char east = pipeMap.GetEast(c.Item1, c.Item2);
        if (east != '.')
            path.Add((c.Item1, c.Item2 + 1, east));
    }

    private void AddNorth(char[,] pipeMap, List<(int, int, char)> path, (int, int, char) c)
    {
        char north = pipeMap.GetNorth(c.Item1, c.Item2);
        if (north != '.')
            path.Add((c.Item1 - 1, c.Item2, north));
    }

    private void AddSouth(char[,] pipeMap, List<(int, int, char)> path, (int, int, char) c)
    {
        char south = pipeMap.GetSouth(c.Item1, c.Item2);
        if (south != '.')
            path.Add((c.Item1 + 1, c.Item2, south));
    }
}
