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

        char[] values = { 'A', 'K', 'Q', 'T', '9', '8', '7', '6', '5', '4', '3', '2', 'J' };

        List<Hand> hands = new();
        foreach (var line in lines)
        {
            var parts = line.Split(' ');
            hands.Add(new Hand(parts[0], int.Parse(parts[1])));
        }

        foreach (var hand in hands)
        {
            var groups = hand.Cards.GroupBy(x => x).ToList();
            int jcount = groups.Where(x => x.First() == 'J').Any() ? groups.First(x => x.First() == 'J').Count() : 0;

            if (jcount > 0)
            {
                if (groups.Count() == 1 || groups.Count() == 2)
                {
                    hand.Tier = 0;
                }
                else if (groups.Count() == 3)
                {
                    var nonJ = groups.Where(g => g.First() != 'J').ToList();

                    if (nonJ.Any(x => x.Count() == 4 - jcount))
                    {
                        hand.Tier = 1;
                    }
                    else if ((nonJ[0].Count() == 3 - jcount && nonJ[1].Count() == 2) || (nonJ[1].Count() == 3 - jcount && nonJ[0].Count() == 2)
                    || (nonJ[0].Count() == 3 && nonJ[1].Count() == 2 - jcount) || (nonJ[1].Count() == 3 && nonJ[0].Count() == 2 - jcount))
                    {
                        hand.Tier = 2;
                    }
                    else
                    {
                        hand.Tier = 3;
                    }
                }
                else if (groups.Count() == 4)
                {
                    var nonJ = groups.Where(g => g.First() != 'J').ToList();

                    if (nonJ.Any(x => x.Count() == 4 - jcount))
                    {
                        hand.Tier = 1;
                    }
                    else if (nonJ.Any(x => x.Count() == 3 - jcount) && nonJ.Where(x => x.Count() == 2).Count() == 1 && jcount == 2)
                    {
                        hand.Tier = 2;
                    }
                    else
                    {
                        hand.Tier = 3;
                    }
                }
                else
                {
                    hand.Tier = 5;
                }
            }
            else
            {
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
        }

        hands = hands.OrderBy(x => x.Tier)
        .ThenBy(x => Array.IndexOf(values, x.Cards[0]))
        .ThenBy(x => Array.IndexOf(values, x.Cards[1]))
        .ThenBy(x => Array.IndexOf(values, x.Cards[2]))
        .ThenBy(x => Array.IndexOf(values, x.Cards[3]))
        .ThenBy(x => Array.IndexOf(values, x.Cards[4]))
        .ToList();

        int winnings = 0;

        for (int i = 0; i < hands.Count; i++)
        {
            hands[i].Rank = hands.Count - i;

            // if (hands[i].Cards.Any(x => x == 'J'))
            // {
                Console.WriteLine($"Tier {hands[i].Tier}: {hands[i].Cards} Rank {hands[i].Rank}");
            // }

            winnings += hands[i].Rank * hands[i].Bid;
        }

        WriteLine($"Winning total: {winnings}");
    }
}
