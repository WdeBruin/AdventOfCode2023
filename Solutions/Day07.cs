namespace Advent.Solutions;

public class Day07 : DayBase
{
    public class Hand
    {
        public Hand(string cards, int bid)
        {
            Cards = cards;
            Bid = bid;
        }

        public string Cards { get; set; }
        public int Bid { get; set; }
        public int Rank { get; set; } = -1;
        public int Tier { get; set; } = -1;
    }

    public override void Run()
    {
        var lines = ReadInput("Day07.txt");

        char[] values = { 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2' };

        List<Hand> hands = new();
        foreach (var line in lines)
        {
            var parts = line.Split(' ');
            hands.Add(new Hand(parts[0], int.Parse(parts[1])));
        }

        foreach (var hand in hands)
        {
            var groups = hand.Cards.GroupBy(x => x).ToList();

            if (groups.Count() == 1)
            {
                hand.Tier = 0;
            }
            else if (groups.Count() == 2)
            {
                if (groups[0].Count() == 4 || groups[1].Count() == 4)
                {
                    hand.Tier = 1;
                }
                else if ((groups[0].Count() == 3 && groups[1].Count() == 2) || (groups[1].Count() == 3 && groups[0].Count() == 2))
                {
                    hand.Tier = 2;
                }
            }
            else if (groups.Count() == 3)
            {
                if (groups.Any(g => g.Count() == 3))
                {
                    hand.Tier = 3;
                }
                else if (groups.Where(g => g.Count() == 2).Count() == 2)
                {
                    hand.Tier = 4;
                }
            }
            else if (groups.Count() == 4)
            {
                hand.Tier = 5;
            }
            else 
            {
                hand.Tier = 6;
            }
        }

        hands = hands.OrderBy(x => x.Tier).ToList();
        
        foreach (var hand in hands)
        {
            Console.WriteLine($"Tier {hand.Tier}: {hand.Cards}");
        }

        int answer = 0;
        WriteLine($"{answer}");
    }
}