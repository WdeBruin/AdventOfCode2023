using Advent.Extensions;

namespace Advent.Solutions;

public class Day09 : DayBase
{

    public class SequenceAnalyzer
    {
        public int AnalyzeAndExtrapolate(int[] sequence)
        {
            List<List<int>> differencesList = new();
            differencesList.Add(ComputeDifferences(sequence));

            // Extrapolate differences until the last item is all zeros
            while (!AllZeroes(differencesList.Last()))
            {
                differencesList.Add(ExtrapolateDifferences(differencesList.Last()));
            }

            // Extrapolate the next value based on the extrapolated differences
            int firstValue = sequence[0];
            int extrapolatedPrevValue = ExtrapolatePrevValue(firstValue, differencesList);

            return extrapolatedPrevValue;
        }

        private int ExtrapolatePrevValue(int firstValue, List<List<int>> differencesList)
        {
            int prevValue = firstValue;

            differencesList.Last().Insert(0, 0);

            for (int j = differencesList.Count - 2; j >= 0; j--)
            {
                differencesList[j].Insert(0, differencesList[j].First() - differencesList[j+1].First());
            }

            prevValue -= differencesList[0].First();

            return prevValue;
        }

        private List<int> ExtrapolateDifferences(List<int> differences)
        {
            List<int> extrapolatedDifferences = new List<int>();

            for (int i = differences.Count - 1; i > 0; i--)
            {
                extrapolatedDifferences.Insert(0, differences[i] - differences[i - 1]);
            }

            return extrapolatedDifferences;
        }

        private List<int> ComputeDifferences(int[] sequence)
        {
            List<int> differences = new List<int>();

            for (int i = 1; i < sequence.Length; i++)
            {
                differences.Add(sequence[i] - sequence[i - 1]);
            }

            return differences;
        }

        private bool AllZeroes(List<int> differences)
        {
            foreach (int diff in differences)
            {
                if (diff != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public override void Run()
    {
        var lines = ReadInput("Day09.txt");
        SequenceAnalyzer analyzer = new SequenceAnalyzer();
        int total = 0;

        // Example sequences
        foreach (var line in lines)
        {
            int[] sequence = line.Split(' ').ToArray().ToIntArray();
            int next = analyzer.AnalyzeAndExtrapolate(sequence);
            Console.WriteLine($"Original sequence: {string.Join(", ", sequence)}");
            Console.WriteLine($"Extrapolated prev value: {next}");
            Console.WriteLine();
            total += next;
        }
        
        Console.WriteLine($"Total value: {total}");
    }
}
