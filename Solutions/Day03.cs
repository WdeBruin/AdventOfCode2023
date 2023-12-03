using static Advent.Extensions.StringArrayExtensions;

namespace Advent.Solutions;

public class Day03 : DayBase
{
    public class Field 
    {
        public Field (int y, int x)
        {
            this.y = y;
            this.x = x;
        }
        
        public int y;
        public int x;
    }

    public override void Run()
    {
        var lines = ReadInput("Day03.txt");        
        int answer = 0;

        List<Field> Fields = new();

        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines.Length; j++)
            {
                // find * store there index
                if(lines[i][j] == '*')
                {
                    Fields.Add(new Field(i, j));
                }
            }           
        }

        foreach (Field f in Fields)
        {
            List<int> numbers = lines.GetAdjacentNumbers(f.x, f.y);
            numbers = numbers.ToList(); // can be bug if two same nrs are seperate adjacent

            if(numbers.Count == 2)
            {
                answer += numbers[0] * numbers[1];
            }
        }

        WriteLine($"{answer}");        
    }
}
