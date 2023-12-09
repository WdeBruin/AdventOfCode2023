namespace Advent.Solutions;

public class Day09 : DayBase
{

    public class SequenceAnalyzer
    {
        public void AnalyzeAndExtrapolate(int[] sequence)
        {
            List<int> differences = ComputeDifferences(sequence);

            // Extrapolate differences until the last item is all zeros
            while (!AllZeroes(differences))
            {
                differences = ExtrapolateDifferences(differences);
            }

            // Extrapolate the next value based on the extrapolated differences
            int lastValue = sequence[sequence.Length - 1];
            int extrapolatedNextValue = ExtrapolateNextValue(lastValue, differences);

            Console.WriteLine($"Original sequence: {string.Join(", ", sequence)}");
            Console.WriteLine($"Extrapolated next value: {extrapolatedNextValue}");
            Console.WriteLine();
        }

        private int ExtrapolateNextValue(int lastValue, List<int> differences)
        {
            int nextValue = lastValue;

            for (int i = 0; i < differences.Count; i++)
            {
                nextValue += differences[i];
            }

            return nextValue;
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
        // var lines = ReadInput("Day08.txt");

        SequenceAnalyzer analyzer = new SequenceAnalyzer();

        // Example sequences
        int[] sequence1 = { 0, 3, 6, 9, 12, 15 };
        int[] sequence2 = { 1, 3, 6, 10, 15, 21 };
        int[] sequence3 = { 10, 13, 16, 21, 30, 45 };

        // Extrapolate next values for each sequence
        analyzer.AnalyzeAndExtrapolate(sequence1);
        analyzer.AnalyzeAndExtrapolate(sequence2);
        analyzer.AnalyzeAndExtrapolate(sequence3);

        // Console.WriteLine($"ChatGPT LCM: {r}");
    }
}
