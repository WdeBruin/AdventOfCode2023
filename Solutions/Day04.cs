using System.Security.Cryptography.X509Certificates;
using System.Xml.XPath;
using static Advent.Extensions.StringArrayExtensions;

namespace Advent.Solutions;

public class Day04 : DayBase
{
    public override void Run()
    {
        var lines = ReadInput("Day04.txt");        
        int answer = 0;

        foreach(var line in lines)
        {
            string[] cardParts = line.Split(':')[1].Split('|');
            List<int> winning = cardParts[0].Split(' ').ToList().Where(x => x != "").ToArray().ToIntArray().ToList();        
            List<int> mine = cardParts[1].Split(' ').ToList().Where(x => x != "").ToArray().ToIntArray().ToList();         

            var n = winning.Where(w => mine.Any(y => y == w)).Count();

            answer += (int)Math.Pow(2, n-1);
        }

        WriteLine($"{answer}");        
    }
}
