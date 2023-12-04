using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.XPath;
using static Advent.Extensions.StringArrayExtensions;

namespace Advent.Solutions;

public class Day04 : DayBase
{
    public class Card
    {
        public int idx;
        public int Copies = 1;
        public List<int> Winning = new();
        public List<int> Mine = new();
        public int Score;
    }

    public override void Run()
    {
        var lines = ReadInput("Day04.txt");
        int answer = 0;

        List<Card> cards = new();

        for(int i=0; i<lines.Length; i++) //parse input to cards
        {
            Card c = GetCard(lines, i);
            cards.Add(c);
        }

        for(int i = 0; i < cards.Count; i++)
        {
            if(cards[i].Score > 0)
            {
                for(int j=1; j<=cards[i].Score; j++)
                {
                    if(i+j < cards.Count())
                    {
                        cards[i+j].Copies += cards[i].Copies;
                    }
                }
            }
        }

        answer = cards.Sum(x => x.Copies);
        WriteLine($"{answer}");
    }

    private static Card GetCard(string[] lines, int i)
    {
        Card c = new();
        c.idx = i;
        string[] cardParts = lines[i].Split(':')[1].Split('|');
        c.Winning = cardParts[0].Split(' ').ToList().Where(x => x != "").ToArray().ToIntArray().ToList();
        c.Mine = cardParts[1].Split(' ').ToList().Where(x => x != "").ToArray().ToIntArray().ToList();
        c.Score = c.Winning.Where(w => c.Mine.Any(y => y == w)).Count();
        return c;
    }
}
