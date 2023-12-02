namespace Advent.Solutions;

public class Day01 : DayBase
{
    public override void Run()
    {
        var lines = ReadInput("Day01.txt");

        int answer = 0;
        string[] vals = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "one", "two", "three", "four", "five", "six",
            "seven", "eight", "nine" };

        foreach (var line in lines)
        {
            int idxFirst = line.Length - 1;
            string first = string.Empty;
            int idxLast = 0;
            string last = string.Empty;

            foreach (var val in vals)
            {
                int firstIdx = line.IndexOf(val);
                if (firstIdx != -1 && firstIdx < idxFirst)
                {
                    idxFirst = firstIdx;
                    first = val;
                }

                int lastIdx = line.LastIndexOf(val);
                if (lastIdx != -1 && lastIdx > idxLast)
                {
                    idxLast = lastIdx;
                    last = val;
                }
            }

            if (first == string.Empty) first = last;
            if (last == string.Empty) last = first;
        
            first = first.Replace("one", "1").Replace("two", "2").Replace("three", "3").Replace("four", "4")
            .Replace("five", "5").Replace("six", "6").Replace("seven", "7").Replace("eight", "8").Replace("nine", "9");
            last = last.Replace("one", "1").Replace("two", "2").Replace("three", "3").Replace("four", "4")
            .Replace("five", "5").Replace("six", "6").Replace("seven", "7").Replace("eight", "8").Replace("nine", "9");

            Console.WriteLine($"{line} f: {first} l: {last}");
            answer += int.Parse(string.Concat(first, last));
        }

    WriteLine($"{answer}");
}
}
