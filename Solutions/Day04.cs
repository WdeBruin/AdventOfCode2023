using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.XPath;
using static Advent.Extensions.StringArrayExtensions;

namespace Advent.Solutions;

public class Day04 : DayBase
{
    public class Card 
    {
        public int i;
        public List<int> Winning = new();
        public List<int> Mine = new();
        public int n;
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

        int j = 0;
        while(j < cards.Count)
        {
            var gamenum = cards[j].i;
            var nToAdd = cards[j].n;
            
            for(int a = 1; a <= nToAdd; a++)
            {
                if(gamenum+a < lines.Length)
                {
                    var c = GetCard(lines, gamenum+a);
                    cards.Insert(cards.LastIndexOf(cards.Last(c => c.i == gamenum+a)), c);
                }
            }

            j++;
        }

        answer = cards.Count;
        WriteLine($"{answer}");        
    }

    private static Card GetCard(string[] lines, int i)
    {
        Card c = new();
        c.i = i;
        string[] cardParts = lines[i].Split(':')[1].Split('|');
        c.Winning = cardParts[0].Split(' ').ToList().Where(x => x != "").ToArray().ToIntArray().ToList();
        c.Mine = cardParts[1].Split(' ').ToList().Where(x => x != "").ToArray().ToIntArray().ToList();
        c.n = c.Winning.Where(w => c.Mine.Any(y => y == w)).Count();
        return c;
    }
}
