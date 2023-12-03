using static Advent.Extensions.StringArrayExtensions;

namespace Advent.Solutions;

public class Day03 : DayBase
{
    public class Nr 
    {
        public Nr (int y, int x, int val, int endX)
        {
            this.y = y;
            this.x = x;
            this.val = val;
            this.endX = endX;
        }
        
        public int y;
        public int x;
        public int val; 
        public int endX;
    }

    public override void Run()
    {
        var lines = ReadInput("Day03.txt");        
        int answer = 0;

        char[] nrs = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        List<Nr> Numbers = new();

        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines.Length; j++)
            {
                // find numbers and store there index
                if(nrs.Any(x => x == lines[i][j]))
                {
                    int nrEndI = lines[i][j..].IndexOf(lines[i][j..].FirstOrDefault(x => !nrs.Any(y => x == y)));
                    nrEndI = nrEndI == -1 ? lines[i].Length : j + nrEndI;
                    int val = int.Parse(lines[i][j..nrEndI]);
                    Numbers.Add(new Nr(i, j, val, nrEndI));

                    j = nrEndI; //forward
                }
            }           
        }

        foreach (Nr n in Numbers)
        {
            for(int i = n.x; i < n.endX; i++)
            {
                List<char> adjacent = lines.GetAdjacentChars(i, n.y);
                if (adjacent.Any(a => !nrs.Any(n => n == a) && a != '.'))
                {
                    answer += n.val;
                    break;
                }
            }
        }

        WriteLine($"{answer}");        
    }
}
